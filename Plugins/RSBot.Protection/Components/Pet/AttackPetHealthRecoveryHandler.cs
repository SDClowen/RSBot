using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;

namespace RSBot.Protection.Components.Pet
{
    public static class AttackPetHealthRecoveryHandler
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            SubscribeEvents();
        }

        private static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnTick", OnTick);
        }

        /// <summary>
        /// Cores the on pet health update.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnTick()
        {
            if (Game.Player.AttackPet == null) return;

            if ((Game.Player.AttackPet.BadEffect & BadEffect.Zombie) == BadEffect.Zombie)
                return;

            var useHPPotions = PlayerConfig.Get<bool>("RSBot.Protection.checkUsePetHP");
            if (!useHPPotions) return;

            var minHp = PlayerConfig.Get<int>("RSBot.Protection.numPetMinHP", 50);

            var hpPercent = Math.Round((double)Game.Player.AttackPet.Health / (double)Game.Player.AttackPet.Record.MaxHealth * 100, 0);

            if (hpPercent < minHp)
                Game.Player.AttackPet.UseHealthPotion();
        }
    }
}