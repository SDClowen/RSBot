using RSBot.Core;
using RSBot.Core.Components.Command;

namespace RSBot.CommandCenter.Avalonia.Components.Command;

/// <summary>
/// Executes the start command to start the bot
/// </summary>
internal class StartCommandExecutor : ICommandExecutor
{
    /// <summary>
    /// Gets the name of the command
    /// </summary>
    public string CommandName => "start";

    /// <summary>
    /// Gets the description of the command
    /// </summary>
    public string CommandDescription => "Start the bot";

    /// <summary>
    /// Executes the start command
    /// </summary>
    public bool Execute(bool silent = false)
    {
        if (!silent)
            Game.ShowNotification($"[RSBot] Starting bot [{Kernel.Bot?.Botbase.DisplayName}]");

        Kernel.Bot?.Start();

        return Kernel.Bot?.Running == true;
    }
} 