using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Pet
{
    public class CosHGPRecoveryHandler
    {
        /// <summary>
        /// Initiliazes this instance.
        /// </summary>
        public static void Initiliaze()
        {
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnGrowthHungerUpdate", OnGrowthHungerUpdate);
            EventManager.SubscribeEvent("OnFellowSatietyUpdate", OnFellowSatietyUpdate);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        private static void OnGrowthHungerUpdate()
        {
            if (Game.Player.Growth == null)
                return;

            var useHGPPotions = PlayerConfig.Get<bool>("RSBot.Protection.checkUseHGP");
            if (!useHGPPotions)
                return;

            var minHGP = PlayerConfig.Get<int>("RSBot.Protection.numPetMinHGP", 50);

            var hgpPercent = ((double)Game.Player.Growth.CurrentHungerPoints / (double)Game.Player.Growth.MaxHungerPoints) * 100;

            if (hgpPercent < minHGP)
                Game.Player.Growth.UseHungerPotion();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        private static void OnFellowSatietyUpdate()
        {
            if (Game.Player.Fellow == null)
                return;

            var useSatietyPotions = PlayerConfig.Get<bool>("RSBot.Protection.checkUseHGP");
            if (!useSatietyPotions)
                return;

            var minHGP = PlayerConfig.Get<int>("RSBot.Protection.numPetMinHGP", 50);

            var hgpPercent = ((double)Game.Player.Fellow.Satiety / 36000.0) * 100;

            if (hgpPercent < minHGP)
                Game.Player.Fellow.UseSatietyPotion();
        }
    }
}