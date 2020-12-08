using RSBot.Core;
using RSBot.Core.Event;
using System.Timers;

namespace RSBot.Protection.Components.Player
{
    public class ManaRecoveryHandler
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
        /// Handles the Elapsed event of the _refreshTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private static void _refreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _canUsePotion = true;
        }

        /// <summary>
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnTick()
        {
            var useManaPotion = PlayerConfig.Get<bool>("RSBot.Protection.checkUseMPPotionsPlayer");
            if (!useManaPotion) return;

            if (_refreshTimer == null)
            {
                _refreshTimer = new Timer(Game.Player.PotionRefreshInterval * 1000) { AutoReset = true };
                _refreshTimer.Elapsed += _refreshTimer_Elapsed;
                _refreshTimer.Start();

                _canUsePotion = true;
            }

            if (!_canUsePotion) return;

            var minMana = PlayerConfig.Get<int>("RSBot.Protection.numPlayerMPPotionMin", 50);
            var manaPercent = ((double)Game.Player.Mana / (double)Game.Player.MaximumMana) * 100;

            if (manaPercent <= minMana)
                _canUsePotion = !Game.Player.UseManaPotion();
        }
    }
}