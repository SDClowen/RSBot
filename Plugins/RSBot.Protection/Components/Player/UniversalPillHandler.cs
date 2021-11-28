using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Player
{
    public class UniversalPillHandler
    {
        /// <summary>
        /// Initialize the <see cref="UniversalPillHandler"/>
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
            EventManager.SubscribeEvent("OnPlayerBadEffect", OnPlayerBadEffect);
        }

        /// <summary>
        /// Cores the on player bad effect.
        /// </summary>
        private static void OnPlayerBadEffect()
        {
            var useUniversalPill = PlayerConfig.Get<bool>("RSBot.Protection.checkUseUniversalPills", true);

            if (useUniversalPill)
                Game.Player.UseUniversalPill();
        }
    }
}