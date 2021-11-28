using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Player
{
    internal class VigorRecoveryHandler
    {
        /// <summary>
        /// Initialize the <see cref="VigorRecoveryHandler"/>
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
            EventManager.SubscribeEvent("OnUpdateHPMP", OnUpdateHPMP);
        }

        /// <summary>
        /// Cores the on player HPMP update.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnUpdateHPMP()
        {
            var useManaPotion = PlayerConfig.Get<bool>("RSBot.Protection.checkUseVigorMP");
            if (useManaPotion)
            {
                var minMana = PlayerConfig.Get<int>("RSBot.Protection.numPlayerMPVigorPotionMin", 50);
                var manaPercent = ((double)Game.Player.Mana / (double)Game.Player.MaximumMana) * 100;

                if (manaPercent <= minMana)
                    Game.Player.UseVigorPotion();
            }

            var useHealthPotion = PlayerConfig.Get<bool>("RSBot.Protection.checkUseVigorHP");
            if (!useHealthPotion) 
                return;

            if ((Game.Player.BadEffect & BadEffect.Zombie) == BadEffect.Zombie)
                return;
            
            var minHealth = PlayerConfig.Get<int>("RSBot.Protection.numPlayerHPVigorPotionMin", 50);

            var healthPercent = ((double)Game.Player.Health / (double)Game.Player.MaximumHealth) * 100;
            if (healthPercent <= minHealth)
                Game.Player.UseVigorPotion();
        }
    }
}