using RSBot.Core;
using RSBot.Core.Components.Command;

namespace RSBot.CommandCenter.Avalonia.Components.Command;

/// <summary>
/// Executes the stop command to stop the bot
/// </summary>
internal class StopCommandExecutor : ICommandExecutor
{
    /// <summary>
    /// Gets the name of the command
    /// </summary>
    public string CommandName => "stop";

    /// <summary>
    /// Gets the description of the command
    /// </summary>
    public string CommandDescription => "Stop the bot";

    /// <summary>
    /// Executes the stop command
    /// </summary>
    public bool Execute(bool silent = false)
    {
        if (!silent)
            Game.ShowNotification($"[RSBot] Stopping bot [{Kernel.Bot?.Botbase.DisplayName}]");

        Kernel.Bot?.Stop();

        return Kernel.Bot?.Running == false;
    }
} 