using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Town;

public class AmmunitionHandler : AbstractTownHandler
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
        EventManager.SubscribeEvent("OnUpdateAmmunition", OnUpdateAmmunition);
        EventManager.SubscribeEvent("OnStartBot", OnStartBot);
    }

    private static void OnStartBot()
    {
        CheckForAmmunition();
    }

    /// <summary>
    ///     Cores the on update ammunition.
    /// </summary>
    private static void OnUpdateAmmunition()
    {
        if (Kernel.Bot.Running)
            CheckForAmmunition();
    }

    private static void CheckForAmmunition()
    {
        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkNoArrows"))
            return;

        var currentAmmunition = Game.Player.GetAmmunitionAmount(true);
        if (currentAmmunition == -1 || currentAmmunition > 10)
            return;

        if (PlayerInTownScriptRegion())
            return;

        Log.WarnLang("ReturnToTownNoAmmo");
        Game.Player.UseReturnScroll();
    }
}
