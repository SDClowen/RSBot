using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Pet
{
    public class HungerRecoveryHandler
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
            EventManager.SubscribeEvent("OnTick", OnTick);
        }

        /// <summary>
        /// </summary>
        private static void OnTick()
        {
            if (Game.Player.AttackPet == null) return;

            var useHPPotions = PlayerConfig.Get<bool>("RSBot.Protection.checkUseHGP");
            if (!useHPPotions) return;

            var minHGP = PlayerConfig.Get<int>("RSBot.Protection.numPetMinHGP", 50);

            var hgpPercent = ((double)Game.Player.AttackPet.CurrentHungerPoints / (double)Game.Player.AttackPet.MaxHungerPoints) * 100;

            if (hgpPercent < minHGP)
                Game.Player.AttackPet.UseHungerPotion();
        }
    }
}