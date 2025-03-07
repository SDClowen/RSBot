using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Components.Command;

namespace RSBot.CommandCenter.Avalonia.Components.Command;

/// <summary>
/// Executes the starthere command to start the bot at current position
/// </summary>
internal class StartHereCommandExecutor : ICommandExecutor
{
    /// <summary>
    /// Gets the name of the command
    /// </summary>
    public string CommandName => "here";

    /// <summary>
    /// Gets the description of the command
    /// </summary>
    public string CommandDescription => "Set training area and start bot";

    /// <summary>
    /// Executes the starthere command
    /// </summary>
    public bool Execute(bool silent = false)
    {
        if (!silent)
            Game.ShowNotification("[RSBot] Starting bot at the current location");

        return CommandManager.Execute("area", true) && CommandManager.Execute("start", true);
    }
} 