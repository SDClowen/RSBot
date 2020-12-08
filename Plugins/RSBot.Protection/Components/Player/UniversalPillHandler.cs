using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Player
{
    public class UniversalPillHandler
    {
        #region Delegates

        private delegate void OnPlayerBadEffectEventHandler();

        private static event OnPlayerBadEffectEventHandler OnPlayerBadEffect;

        #endregion Delegates

        public static void Initialize()
        {
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private static void SubscribeEvents()
        {
            OnPlayerBadEffect += Core_OnPlayerBadEffect;
            EventManager.SubscribeEvent("OnPlayerBadEffect", OnPlayerBadEffect);
        }

        /// <summary>
        /// Cores the on player bad effect.
        /// </summary>
        private static void Core_OnPlayerBadEffect()
        {
            var useUniversalPill = PlayerConfig.Get<bool>("RSBot.Protection.checkUseUniversalPills", true);

            if (useUniversalPill)
                Game.Player.UseUniversalPill();
        }
    }
}