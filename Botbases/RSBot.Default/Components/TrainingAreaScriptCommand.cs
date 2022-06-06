using RSBot.Core;
using RSBot.Core.Components.Scripting;
using System.Collections.Generic;
using RSBot.Core.Event;

namespace RSBot.Default.Components
{
    internal class TrainingAreaScriptCommand : IScriptCommand
    {
        #region Properties

        public string Name => "area";

        public bool IsRunning { get; private set; }

        public Dictionary<string, string> Arguments => new Dictionary<string, string>
        {
            {"PosX", "The X position"},
            {"PosY", "The Y position"},
            {"Radius", "The radius"}
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
                Log.Warn("[Script] Invalid training area command: Invalid argument count.");

                return false;
            }

            try
            {
                IsRunning = true;

                Log.Notify("[Script] Setting training area");

                if (!float.TryParse(arguments[0], out var xPos)
                    || !float.TryParse(arguments[1], out var yPos)
                    || !int.TryParse(arguments[2], out var radius))
                    return false;

                PlayerConfig.Set("RSBot.Area.X", xPos);
                PlayerConfig.Set("RSBot.Area.Y", yPos);
                PlayerConfig.Set("RSBot.Area.Radius", radius);

                EventManager.FireEvent("OnSetTrainingArea");

                return true;
            }
            finally
            {
                IsRunning = false;
            }
        }

        #endregion Methods
    }
}