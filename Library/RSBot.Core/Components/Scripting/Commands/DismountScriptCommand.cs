using System.Collections.Generic;
using System.Threading;

namespace RSBot.Core.Components.Scripting.Commands;

internal class DismountScriptCommand : IScriptCommand
{
    #region Properties

    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name => "dismount";

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
    public Dictionary<string, string> Arguments => null;

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
        try
        {
            IsBusy = true;

            Log.Notify("[Script] Dismounting vehicle...");
            if (!Game.Player.HasActiveVehicle)
                return true;

            Game.Player.Vehicle.Dismount();
            Thread.Sleep(500);

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
