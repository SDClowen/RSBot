using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Components.Command;

namespace RSBot.CommandCenter.Components.Command;

internal class StartHereCommandExecutor : ICommandExecutor
{
    public string CommandName => "here";

    public string CommandDescription => "Set training area and start bot";

    public bool Execute(bool silent)
    {
        if (!silent)
            Game.ShowNotification("[RSBot] Starting bot at the current location");

        return CommandManager.Execute("area", true) && CommandManager.Execute("start", true);
    }
}
