using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Threading;
namespace RSBot.Core.Components.Scripting.Commands;
internal class MoveScriptCommand : IScriptCommand
{
    #region Properties

    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name => "move";

    /// <summary>
    /// Gets a value indicating whether this instance is running.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is running; otherwise, <c>false</c>.
    /// </value>
    public bool IsBusy { get; private set; }

    /// <summary>
    /// Gets the arguments.
    /// </summary>
    /// <value>
    /// The arguments.
    /// </value>
    public Dictionary<string, string> Arguments => new Dictionary<string, string>
        {
            {"XSector", "The X sector of the region"},
            {"YSector", "The Y sector of the region"},
            {"XOffset", "The X offset inside the region"},
            {"YOffset", "The Y offset inside the region"},
            {"ZOffset", "The Z offset inside the region"}
        };

    #endregion Properties

    #region Methods

    /// <summary>
    /// Executes this instance.
    /// </summary>
    /// <param name="arguments"></param>
    /// <returns>
    /// A value indicating if the command has been executed successfully.
    /// </returns>
    public bool Execute(string[] arguments = null)
    {
        if (arguments == null || arguments.Length != Arguments.Count)
        {
            Log.Warn("[Script] Invalid move command: Position information missing / invalid format.");

            return false;
        }

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
                    Log.Warn("[Script] The move command failed due to an unknown reason! Please check the walk script.");

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
    /// Executes the movement.
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
   
        Position pos = new(xSector, ySector, xOffset, yOffset, zOffset);

        if (PlayerConfig.Get("RSBot.Walkback.UseMount", true))
        {
            if (!Game.Player.HasActiveVehicle && !Game.Player.IsInDungeon && !Game.Player.InAction)
                Game.Player.SummonVehicle();
        }

        //Check if the new position is nearby a cave entrance.
        //If so dismount the vehicle
        //TODO: Find out how to get the ingame positions of ground teleporters like dw cave...

        var distance = pos.DistanceTo(Game.Player.Position);
        if (distance > 100)
        {
            Log.Warn("[Script] Target position too far away, bot logic aborted!");

            IsBusy = false;
            return false;
        }

        Log.Debug($"[Script] Move to position {pos.Region}({pos.Region.X},{pos.Region.Y}) X={pos.X}, Y={pos.Y}");

        return Game.Player.MoveTo(pos);
    }

    public void Stop()
    {
        IsBusy = false;
    }

    #endregion Methods
}
