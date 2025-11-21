using RSBot.Core;
using RSBot.Core.Components.Command;

namespace RSBot.CommandCenter.Components.Command;

internal class StartCommandExecutor : ICommandExecutor
{
    public string CommandName => "start";

    public string CommandDescription => "Start the bot";

    public bool Execute(bool silent)
    {
        if (!silent)
            Game.ShowNotification($"[RSBot] Starting bot [{Kernel.Bot?.Botbase.DisplayName}]");

        Kernel.Bot?.Start();

        return Kernel.Bot?.Running == true;
    }
}
