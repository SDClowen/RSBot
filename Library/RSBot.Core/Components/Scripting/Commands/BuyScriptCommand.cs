using System.Collections.Generic;
using System.Threading;

namespace RSBot.Core.Components.Scripting.Commands;

internal class BuyScriptCommand : IScriptCommand
{
    #region Properties

    public string Name => "buy";

    public bool IsBusy { get; private set; }

    public Dictionary<string, string> Arguments => new() { { "Codename", "The code name of the NPC" } };

    #endregion Properties

    #region Methods

    public bool Execute(string[] arguments = null)
    {
        if (arguments == null || arguments.Length < Arguments.Count)
        {
            Log.Warn("[Script] Invalid buy command: NPC code name information missing.");

            return false;
        }

        try
        {
            IsBusy = true;
            Log.Notify("[Script] Purchasing items...");

            ShoppingManager.Run(arguments[0]);
            while (!ShoppingManager.Finished)
                Thread.Sleep(50); //Wait until shopping is finished

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
