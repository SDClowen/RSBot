using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Pet;

public class CosHGPRecoveryHandler
{
    /// <summary>
    ///     Initiliazes this instance.
    /// </summary>
    public static void Initiliaze()
    {
        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnGrowthHungerUpdate", OnGrowthHungerUpdate);
        EventManager.SubscribeEvent("OnFellowSatietyUpdate", OnFellowSatietyUpdate);
    }

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    private static void OnGrowthHungerUpdate()
    {
        if (Game.Player.Growth == null)
            return;

        var use = PlayerConfig.Get<bool>("RSBot.Protection.checkUseHGP");
        if (!use)
            return;

        var min = PlayerConfig.Get("RSBot.Protection.numPetMinHGP", 90);

        var percent = 100.0 * Game.Player.Growth.CurrentHungerPoints / Game.Player.Growth.MaxHungerPoints;
        if (percent < min)
            Game.Player.Growth.UseHungerPotion();
    }

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    private static void OnFellowSatietyUpdate()
    {
        if (Game.Player.Fellow == null)
            return;

        var use = PlayerConfig.Get<bool>("RSBot.Protection.checkUseHGP");
        if (!use)
            return;

        var min = PlayerConfig.Get("RSBot.Protection.numPetMinHGP", 90);

        var percent = 100.0 * Game.Player.Fellow.Satiety / 36000;
        if (percent < min)
            Game.Player.Fellow.UseSatietyPotion();
    }
}
