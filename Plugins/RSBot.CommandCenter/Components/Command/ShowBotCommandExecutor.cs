using RSBot.Core;
using RSBot.Core.Components.Command;
using RSBot.Core.Event;

namespace RSBot.CommandCenter.Components.Command;

internal class ShowBotCommandExecutor : ICommandExecutor
{
    public string CommandName => "show";

    public string CommandDescription => "Show the bot window";

    public bool Execute(bool silent)
    {
        if (!silent)
            Game.ShowNotification("[RSBot] Showing bot window");

        EventManager.FireEvent("OnShowBotWindow");

        return true;
    }
}
