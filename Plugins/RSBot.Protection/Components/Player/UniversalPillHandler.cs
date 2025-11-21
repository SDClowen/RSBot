using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Player;

public class UniversalPillHandler
{
    /// <summary>
    ///     Initialize the <see cref="UniversalPillHandler" />
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
        EventManager.SubscribeEvent("OnTick", OnPlayerBadEffect);
    }

    /// <summary>
    ///     Cores the on player bad effect.
    /// </summary>
    private static void OnPlayerBadEffect()
    {
        var useUniversalPill = PlayerConfig.Get<bool>("RSBot.Protection.checkUseUniversalPills", true);
        if (!useUniversalPill)
            return;

        if ((Game.Player.BadEffect & BadEffectAll.UniversallPillEffects) != 0)
            Game.Player.UseUniversalPill();

        if ((Game.Player.BadEffect & BadEffectAll.PurificationPillEffects) != 0)
            Game.Player.UsePurificationPill();
    }
}
