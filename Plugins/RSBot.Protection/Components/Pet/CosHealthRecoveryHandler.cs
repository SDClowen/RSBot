using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Cos;

namespace RSBot.Protection.Components.Pet;

public static class CosHealthRecoveryHandler
{
    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        EventManager.SubscribeEvent("OnGrowthHealthUpdate", OnGrowthHealthUpdate);
        EventManager.SubscribeEvent("OnFellowHealthUpdate", OnFellowHealthUpdate);
        EventManager.SubscribeEvent("OnUpdateTransportHealth", OnUpdateTransportHealth);
        EventManager.SubscribeEvent("OnUpdateJobTransportHealth", OnUpdateJobTransportHealth);
    }

    /// <summary>
    ///     Cores the on pet health update.
    /// </summary>
    private static void OnCosHealthUpdate(Cos cos)
    {
        var useHPPotions = PlayerConfig.Get<bool>("RSBot.Protection.checkUsePetHP");
        if (!useHPPotions)
            return;

        var minHp = PlayerConfig.Get("RSBot.Protection.numPetMinHP", 80);

        if (cos == null)
            return;

        if ((cos.BadEffect & BadEffect.Zombie) == BadEffect.Zombie)
            return;

        var percent = 100.0 * cos.Health / cos.MaxHealth;
        if (percent < minHp)
            cos.UseHealthPotion();
    }

    /// <summary>
    ///     Cores the on pet health update.
    /// </summary>
    private static void OnGrowthHealthUpdate()
    {
        OnCosHealthUpdate(Game.Player.Growth);
    }

    /// <summary>
    ///     Cores the on pet health update.
    /// </summary>
    private static void OnFellowHealthUpdate()
    {
        OnCosHealthUpdate(Game.Player.Fellow);
    }

    /// <summary>
    ///     Cores the on pet health update.
    /// </summary>
    private static void OnUpdateTransportHealth()
    {
        OnCosHealthUpdate(Game.Player.Transport);
    }

    /// <summary>
    ///     Cores the on pet health update.
    /// </summary>
    private static void OnUpdateJobTransportHealth()
    {
        OnCosHealthUpdate(Game.Player.JobTransport);
    }
}
