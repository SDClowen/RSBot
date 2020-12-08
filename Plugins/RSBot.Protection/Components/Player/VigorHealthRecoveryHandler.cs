using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Timers;

namespace RSBot.Protection.Components.Player
{
    internal class VigorHealthRecoveryHandler
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
            if (!Kernel.Bot.Running) return;

            var useHealthPotion = PlayerConfig.Get<bool>("RSBot.Protection.checkUseVigorHP");
            if (!useHealthPotion) return;

            if ((Game.Player.BadEffect & BadEffect.Zombie) == BadEffect.Zombie)
            {
                _canUsePotion = false;
                return;
            }

            if (_refreshTimer == null)
            {
                _refreshTimer = new Timer(5000) { AutoReset = true };
                _refreshTimer.Elapsed += _refreshTimer_Elapsed;
                _refreshTimer.Start();

                _canUsePotion = true;
            }

            if (!_canUsePotion) return;
            var minHealth = PlayerConfig.Get<int>("RSBot.Protection.numPlayerHPVigorPotionMin", 50);

            var healthPercent = ((double)Game.Player.Health / (double)Game.Player.MaximumHealth) * 100;

            if (healthPercent <= minHealth)
                _canUsePotion = !Game.Player.UseVigorPotion();
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