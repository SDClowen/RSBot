using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Player
{
    public class HealthManaRecoveryHandler
    {
        /// <summary>
        /// Initialize the <see cref="HealthRecoveryHandler"/>
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
            EventManager.SubscribeEvent("OnUpdateHP", OnUpdateHP);
            EventManager.SubscribeEvent("OnUpdateMP", OnUpdateMP);
        }

        /// <summary>
        /// Cores the on player HP update.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnUpdateHP()
        {
            var autoHealth = PlayerConfig.Get<bool>("RSBot.Protection.checkUseHPPotionsPlayer");
            if (!autoHealth) 
                return;

            if ((Game.Player.BadEffect & BadEffect.Zombie) == BadEffect.Zombie)
                return;

            var minHealth = PlayerConfig.Get("RSBot.Protection.numPlayerHPPotionMin", 50);
            var healthPercent = ((double)Game.Player.Health / (double)Game.Player.MaximumHealth) * 100.0;
            if (healthPercent <= minHealth)
                Game.Player.UseHealthPotion();
        }

        /// <summary>
        /// Cores the on player MP update.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnUpdateMP()
        {
            var autoMana = PlayerConfig.Get<bool>("RSBot.Protection.checkUseMPPotionsPlayer");
            if (!autoMana)
                return;

            var minMana = PlayerConfig.Get("RSBot.Protection.numPlayerMPPotionMin", 50);
            var manaPercent = ((double)Game.Player.Mana / (double)Game.Player.MaximumMana) * 100;
            if (manaPercent <= minMana)
                Game.Player.UseManaPotion();
        }
    }
}