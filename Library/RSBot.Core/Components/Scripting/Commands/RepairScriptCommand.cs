using System.Collections.Generic;

namespace RSBot.Core.Components.Scripting.Commands;

internal class RepairScriptCommand : IScriptCommand
{
    #region Properties

    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name => "repair";

    /// <summary>
    ///     Gets a value indicating whether this instance is running.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is running; otherwise, <c>false</c>.
    /// </value>
    public bool IsBusy { get; private set; }

    /// <summary>
    ///     Gets the arguments.
    /// </summary>
    /// <value>
    ///     The arguments.
    /// </value>
    public Dictionary<string, string> Arguments => new() { { "Codename", "The code name of the NPC" } };

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
            Log.Warn("[Script] Invalid repair command: NPC code name information missing.");

            return false;
        }

        if (!ScriptManager.Running)
        {
            IsBusy = false;

            return false;
        }

        try
        {
            IsBusy = true;

            Log.Notify("[Script] Repairing items...");
            ShoppingManager.RepairItems(arguments[0]);

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
