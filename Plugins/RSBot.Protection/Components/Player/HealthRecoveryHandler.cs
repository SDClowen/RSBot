using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Timers;

namespace RSBot.Protection.Components.Player
{
    public class HealthRecoveryHandler
    {
        private static Timer _refreshTimer;

        private static bool _canUsePotion;

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
        /// Cores the on player HPMP update.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnTick()
        {
            var useHealthPotion = PlayerConfig.Get<bool>("RSBot.Protection.checkUseHPPotionsPlayer");
            if (!useHealthPotion) return;

            if (_refreshTimer == null)
            {
                _refreshTimer = new Timer(Game.Player.PotionRefreshInterval * 1000) { AutoReset = true };
                _refreshTimer.Elapsed += _refreshTimer_Elapsed;
                _refreshTimer.Start();

                _canUsePotion = true;
            }

            if (!_canUsePotion) return;

            if ((Game.Player.BadEffect & BadEffect.Zombie) == BadEffect.Zombie)
            {
                _canUsePotion = false;
                return;
            }

            var minHealth = PlayerConfig.Get<int>("RSBot.Protection.numPlayerHPPotionMin", 50);

            var healthPercent = ((double)Game.Player.Health / (double)Game.Player.MaximumHealth) * 100;

            if (healthPercent <= minHealth)
                _canUsePotion = !Game.Player.UseHealthPotion();
        }

        /// <summary>
        /// Handles the Elapsed event of the _refreshTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private static void _refreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _canUsePotion = true;
        }
    }
}