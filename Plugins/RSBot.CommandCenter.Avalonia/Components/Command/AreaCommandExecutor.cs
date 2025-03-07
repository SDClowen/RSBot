using RSBot.Core;
using RSBot.Core.Components.Command;
using RSBot.Core.Event;

namespace RSBot.CommandCenter.Avalonia.Components.Command;

/// <summary>
/// Executes the area command to set the training area
/// </summary>
internal class AreaCommandExecutor : ICommandExecutor
{
    /// <summary>
    /// Gets the name of the command
    /// </summary>
    public string CommandName => "area";

    /// <summary>
    /// Gets the description of the command
    /// </summary>
    public string CommandDescription => "Set the training area";

    /// <summary>
    /// Executes the area command
    /// </summary>
    public bool Execute(bool silent = false)
    {
        if (!silent)
            Game.ShowNotification(
                $"[RSBot] Setting training area to X={Game.Player.Position.X:0.00} Y={Game.Player.Position.Y:0.00} R=50");

        PlayerConfig.Set("RSBot.Area.Region", Game.Player.Position.Region);
        PlayerConfig.Set("RSBot.Area.X", Game.Player.Position.XOffset.ToString("0.0"));
        PlayerConfig.Set("RSBot.Area.Y", Game.Player.Position.YOffset.ToString("0.0"));
        PlayerConfig.Set("RSBot.Area.Z", Game.Player.Position.ZOffset.ToString("0.0"));
        PlayerConfig.Get("RSBot.Area.Radius", 50);

        EventManager.FireEvent("OnSetTrainingArea");

        return true;
    }
} 