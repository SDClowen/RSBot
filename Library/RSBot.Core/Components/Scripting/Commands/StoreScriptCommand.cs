using System.Collections.Generic;

namespace RSBot.Core.Components.Scripting.Commands
{
    internal class StoreScriptCommand : IScriptCommand
    {
        #region Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => "store";

        /// <summary>
        /// Gets a value indicating whether this instance is running.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public Dictionary<string, string> Arguments => new Dictionary<string, string>
        {
            {"Codename", "The code name of the NPC"}
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
            if (arguments == null || arguments.Length == 0)
            {
                Log.Warn("[Script] Invalid store command: Position information missing.");

                return false;
            }

            try
            {
                IsRunning = true;

                Log.Notify("[Script] storing items...");
                ShoppingManager.StoreItems(arguments[0]);

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