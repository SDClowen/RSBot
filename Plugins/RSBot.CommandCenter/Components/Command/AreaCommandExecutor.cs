using RSBot.Core;
using RSBot.Core.Components.Command;
using RSBot.Core.Event;

namespace RSBot.CommandCenter.Components.Command;

internal class AreaCommandExecutor : ICommandExecutor
{
    public string CommandName => "area";

    public string CommandDescription => "Set the training area";

    public bool Execute(bool silent)
    {
        if (!silent)
            Game.ShowNotification(
                $"[RSBot] Setting training area to X={Game.Player.Position.X:0.00} Y={Game.Player.Position.Y:0.00} R=50"
            );

        PlayerConfig.Set("RSBot.Area.Region", Game.Player.Position.Region);
        PlayerConfig.Set("RSBot.Area.X", Game.Player.Position.XOffset.ToString("0.0"));
        PlayerConfig.Set("RSBot.Area.Y", Game.Player.Position.YOffset.ToString("0.0"));
        PlayerConfig.Set("RSBot.Area.Z", Game.Player.Position.ZOffset.ToString("0.0"));
        PlayerConfig.Get("RSBot.Area.Radius", 50);

        EventManager.FireEvent("OnSetTrainingArea");

        return true;
    }
}
