using System.Collections.Generic;
using RSBot.Core;
using RSBot.Core.Components.Scripting;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Training.Components;

internal class TrainingAreaScriptCommand : IScriptCommand
{
    #region Properties

    public string Name => "area";

    public bool IsBusy { get; private set; }

    public Dictionary<string, string> Arguments =>
        new()
        {
            { "Region", "The Region" },
            { "XOffset", "The X" },
            { "YOffset", "The Y" },
            { "ZOffset", "The Z" },
            { "Radius", "The radius" },
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
            Log.Warn("[Script] Invalid training area command: Invalid argument count.");

            return false;
        }

        try
        {
            IsBusy = true;

            Log.Notify("[Script] Setting training area");

            if (
                !Region.TryParse(arguments[0], out var region)
                || !float.TryParse(arguments[1], out var xPos)
                || !float.TryParse(arguments[2], out var yPos)
                || !float.TryParse(arguments[3], out var zPos)
                || !int.TryParse(arguments[4], out var radius)
            )
                return false;

            PlayerConfig.Set("RSBot.Area.Region", region);
            PlayerConfig.Set("RSBot.Area.X", xPos);
            PlayerConfig.Set("RSBot.Area.Y", yPos);
            PlayerConfig.Set("RSBot.Area.Z", zPos);
            PlayerConfig.Set("RSBot.Area.Radius", radius);

            EventManager.FireEvent("OnSetTrainingArea");

            return true;
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void Stop()
    {
        IsBusy = false;
    }

    #endregion Methods
}
