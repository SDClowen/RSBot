using RSBot.Core;
using RSBot.Core.Event;
using System.Timers;

namespace RSBot.Protection.Components.Player
{
    public class VigorManaRecoveryHandler
    {
        private static Timer _refreshTimer;

        private static bool _canUsePotion;

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
            EventManager.SubscribeEvent("OnUpdateHPMP", OnTick);
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
            if (!Kernel.Bot.Running) return;

            var useManaPotion = PlayerConfig.Get<bool>("RSBot.Protection.checkUseVigorMP");
            if (!useManaPotion) return;

            if (_refreshTimer == null)
            {
                _refreshTimer = new Timer(5000) { AutoReset = true };
                _refreshTimer.Elapsed += _refreshTimer_Elapsed;
                _refreshTimer.Start();

                _canUsePotion = true;
            }

            if (!_canUsePotion) return;

            var minMana = PlayerConfig.Get<int>("RSBot.Protection.numPlayerMPVigorPotionMin", 50);
            var manaPercent = ((double)Game.Player.Mana / (double)Game.Player.MaximumMana) * 100;

            if (manaPercent <= minMana)
                _canUsePotion = !Game.Player.UseVigorPotion();
        }
    }
}