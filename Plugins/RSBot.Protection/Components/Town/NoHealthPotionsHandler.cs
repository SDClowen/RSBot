using System;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Town;

public class NoHealthPotionsHandler : AbstractTownHandler
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
        EventManager.SubscribeEvent("OnUseItem", new Action<byte>(OnUseItem));
        EventManager.SubscribeEvent("OnStartBot", OnStartBot);
    }

    private static void OnStartBot()
    {
        //Check if we need to return to town right after the bot started.
        CheckForHpPotions();
    }

    /// <summary>
    ///     Cores the on use item.
    /// </summary>
    private static void OnUseItem(byte slot)
    {
        if (Kernel.Bot.Running)
            CheckForHpPotions();
    }

    private static void CheckForHpPotions()
    {
        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkNoHPPotions"))
            return;

        if (PlayerInTownScriptRegion())
            return;

        if (Game.Player.State.LifeState == LifeState.Dead)
            return;

        var typeIdFilter = new TypeIdFilter(3, 3, 1, 1);
        if (
            Game.Player.Inventory.GetSumAmount(typeIdFilter)
            > PlayerConfig.Get<int>("RSBot.Protection.numHPPotionsLeft")
        )
            return;

        Game.Player.UseReturnScroll();

        Log.WarnLang("ReturnToTownNoHealth");
    }
}
