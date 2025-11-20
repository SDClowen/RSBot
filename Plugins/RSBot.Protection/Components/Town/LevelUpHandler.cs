using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Town;

public class LevelUpHandler : AbstractTownHandler
{
    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLevelUp", OnPlayerLevelUp);
    }

    /// <summary>
    ///     Cores the on player level up.
    /// </summary>
    private static void OnPlayerLevelUp()
    {
        if (!Kernel.Bot.Running)
            return;

        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkLevelUp"))
            return;

        if (PlayerInTownScriptRegion())
            return;

        Log.NotifyLang("ReturnToTownLevelUpAchieved");

        Game.Player.UseReturnScroll();
    }
}
