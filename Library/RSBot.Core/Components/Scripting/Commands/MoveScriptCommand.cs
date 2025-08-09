using System.Collections.Generic;
using System.Threading;
using RSBot.Core.Objects;

namespace RSBot.Core.Components.Scripting.Commands;

internal class MoveScriptCommand : IScriptCommand
{
    #region Properties

    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name => "move";

    /// <summary>
    ///     Gets a value indicating whether this instance is running.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is running; otherwise, <c>false</c>.
    /// </value>
    public bool IsBusy { get; private set; }

    /// <summary>
    ///     Gets or sets flag if you must dismount for teleporting.
    /// </summary>
    public static bool MustDismount { get; set; }

    /// <summary>
    ///     Gets the arguments.
    /// </summary>
    /// <value>
    ///     The arguments.
    /// </value>
    public Dictionary<string, string> Arguments => new()
    {
        { "XSector", "The X sector of the region" },
        { "YSector", "The Y sector of the region" },
        { "XOffset", "The X offset inside the region" },
        { "YOffset", "The Y offset inside the region" },
        { "ZOffset", "The Z offset inside the region" }
    };

    #endregion Properties

    #region Methods

    /// <summary>
    ///     Executes this instance.
    /// </summary>
    /// <param name="arguments"></param>
    /// <returns>
    ///     A value indicating if the command has been executed successfully.
    /// </returns>
    public bool Execute(string[] arguments = null)
    {
        if (arguments == null || arguments.Length != Arguments.Count)
        {
            Log.Warn("[Script] Invalid move command: Position information missing / invalid format.");

            return false;
        }

        if (IsBusy)
            return false;

        try
        {
            IsBusy = true;

            while (Game.Player.InAction)
                Thread.Sleep(100);

            const int retryAttempts = 5;
            var stepRetryCounter = 0;

            while (!ExecuteMove(arguments))
            {
                if (!IsBusy)
                    return false;

                if (stepRetryCounter++ >= retryAttempts)
                {
                    Log.Warn(
                        "[Script] The move command failed due to an unknown reason! Please check the walk script.");

                    return false;
                }

                Log.Debug($"[Script] Retry this step {stepRetryCounter}/{retryAttempts}...");

                //Wait until executing the next step so the server can get its shit done so most likely the next step will not fail.
                Thread.Sleep(1000);
            }

            return true;
        }
        finally
        {
            IsBusy = false;
        }
    }

    /// <summary>
    ///     Executes the movement.
    /// </summary>
    /// <param name="arguments">The arguments.</param>
    private bool ExecuteMove(IReadOnlyList<string> arguments)
    {
        if (!float.TryParse(arguments[0], out var xOffset)
            || !float.TryParse(arguments[1], out var yOffset)
            || !float.TryParse(arguments[2], out var zOffset)
            || !byte.TryParse(arguments[3], out var xSector)
            || !byte.TryParse(arguments[4], out var ySector))
        {
            IsBusy = false;

            return false; //Invalid format
        }

        Position previousPosition = Game.Player.Position;
        Position pos = new(xSector, ySector, xOffset, yOffset, zOffset);

        if (PlayerConfig.Get("RSBot.Training.checkUseMount", true))
        {
            if (!Game.Player.HasActiveVehicle && !Game.Player.InAction
                && !(ScriptManager.Running && ScriptManager.File == PlayerConfig.Get("RSBot.Lure.SelectedScriptPath", string.Empty)))
            {
                Game.Player.SummonFellow();

                var fellow = Game.Player.Fellow;

                if (fellow != null)
                {
                    fellow.CastSkill("P2SKILL_SPECIAL_SP_GET_A"); //SP Recall

                    double distanceToFellow = previousPosition.DistanceTo(fellow.Position);
                    if (distanceToFellow <= 5.0)
                    {
                        fellow.Mount();
                    }
                    else
                        Log.Debug($"Can't mount fellow pet because it's {distanceToFellow}m away");
                }
            }

            if (!Game.Player.HasActiveVehicle && !Game.Player.IsInDungeon && !Game.Player.InAction)
                Game.Player.SummonVehicle();
        }

        //Check if the new position is nearby a cave entrance.
        //If so dismount the vehicle
        //TODO: Find out how to get the ingame positions of ground teleporters like dw cave...

        var distance = pos.DistanceTo(previousPosition);
        if (distance > 100)
        {
            Log.Warn("[Script] Target position too far away, bot logic aborted!");

            IsBusy = false;
            return false;
        }

        Log.Debug($"[Script] Move to position {pos.Region}({pos.Region.X},{pos.Region.Y}) X={pos.X}, Y={pos.Y}");

        
        bool posResult = Game.Player.MoveTo(pos);

        if (MustDismount)
        {
            MustDismount = false;
            Game.Player.Vehicle.Dismount();
            bool previousPositionResult = Game.Player.MoveTo(previousPosition);
            return previousPositionResult;
        }
        else
            return posResult;
    }

    public void Stop()
    {
        IsBusy = false;
    }

    #endregion Methods
}