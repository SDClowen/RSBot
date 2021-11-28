using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Pet
{
    public class VehiclePetHealthRecoveryHandler
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
            EventManager.SubscribeEvent("OnUpdateVehicleHPMP", OnUpdateVehicleHPMP);
        }

        /// <summary>
        /// Cores the on pet health update.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnUpdateVehicleHPMP()
        {
            if (Game.Player.Vehicle == null) 
                return;

            if ((Game.Player.Vehicle.BadEffect & BadEffect.Zombie) == BadEffect.Zombie)
                return;

            var useHPPotions = PlayerConfig.Get<bool>("RSBot.Protection.checkUseMountHP");
            if (!useHPPotions) return;

            var minHp = PlayerConfig.Get<int>("RSBot.Protection.numMountMinHP", 50);

            var hpPercent = ((double)Game.Player.Vehicle.Health / (double)Game.Player.Vehicle.Record.MaxHealth) * 100;

            if (hpPercent < minHp)
                Game.Player.Vehicle.UseHealthPotion();
        }
    }
}