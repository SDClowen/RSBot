using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Pet
{
    internal class PetBadStatusHandler
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
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
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnTick()
        {
            if (Game.Player.AttackPet == null || !PlayerConfig.Get<bool>("RSBot.Protection.checkUseAbnormalStatePotion"))
                return;

            Game.Player.AttackPet.UseBadStatusPotion();
        }
    }
}