using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Pet;

internal class CosBadStatusHandler
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
        EventManager.SubscribeEvent("OnTick", OnTick);
    }

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    private static void OnTick()
    {
        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkUseAbnormalStatePotion", true))
            return;

        if (
            Game.Player.Growth != null
            && (
                (Game.Player.Growth.BadEffect & BadEffectAll.UniversallPillEffects) != 0
                || (Game.Player.Growth.BadEffect & BadEffectAll.PurificationPillEffects) != 0
            )
        )
            Game.Player.Growth.UseBadStatusPotion();

        if (Game.Player.Fellow != null && (Game.Player.Fellow.BadEffect & BadEffectAll.UniversallPillEffects) != 0)
            Game.Player.Fellow.UseBadStatusPotion(); //PurificationPillEffects are not removed on fellow by pills

        if (
            Game.Player.Transport != null
            && (
                (Game.Player.Transport.BadEffect & BadEffectAll.UniversallPillEffects) != 0
                || (Game.Player.Transport.BadEffect & BadEffectAll.PurificationPillEffects) != 0
            )
        )
            Game.Player.Transport.UseBadStatusPotion();

        if (
            Game.Player.JobTransport != null
            && (
                (Game.Player.JobTransport.BadEffect & BadEffectAll.UniversallPillEffects) != 0
                || (Game.Player.JobTransport.BadEffect & BadEffectAll.PurificationPillEffects) != 0
            )
        )
            Game.Player.JobTransport.UseBadStatusPotion();
    }
}
