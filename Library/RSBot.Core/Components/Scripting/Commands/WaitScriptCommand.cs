using System.Collections.Generic;
using System.Threading;

namespace RSBot.Core.Components.Scripting.Commands;

internal class WaitScriptCommand : IScriptCommand
{
    #region Properties

    public string Name => "wait";

    public bool IsBusy { get; private set; }

    public Dictionary<string, string> Arguments => new() { { "Time", "The time to wait in seconds" } };

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
        if (arguments == null || arguments.Length == 0)
        {
            Log.Warn("[Script] Invalid wait command: Waiting time information missing.");

            return false;
        }

        try
        {
            IsBusy = true;

            Log.Notify("[Script] Waiting...");

            if (!int.TryParse(arguments[0], out var time))
                return false;

            Thread.Sleep(time);

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
