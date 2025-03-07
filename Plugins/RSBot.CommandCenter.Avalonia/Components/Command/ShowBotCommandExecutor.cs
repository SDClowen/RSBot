using RSBot.Core;
using RSBot.Core.Components.Command;
using RSBot.Core.Event;

namespace RSBot.CommandCenter.Avalonia.Components.Command;

/// <summary>
/// Executes the show command to show/hide the bot window
/// </summary>
internal class ShowBotCommandExecutor : ICommandExecutor
{
    /// <summary>
    /// Gets the name of the command
    /// </summary>
    public string CommandName => "show";

    /// <summary>
    /// Gets the description of the command
    /// </summary>
    public string CommandDescription => "Show the bot window";

    /// <summary>
    /// Executes the show command
    /// </summary>
    public bool Execute(bool silent = false)
    {
        if (!silent)
            Game.ShowNotification("[RSBot] Showing bot window");

        EventManager.FireEvent("OnShowBotWindow");

        return true;
    }
} 