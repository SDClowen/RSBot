using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

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
            EventManager.SubscribeEvent("OnTick", OnPlayerBadEffect);
        }

        /// <summary>
        /// Bad effects curable by universal pills.
        /// </summary>
        private static readonly BadEffect universalPillEffects =
            BadEffect.Frozen |
            BadEffect.Frostbitten |
            BadEffect.Shocked |
            BadEffect.Burnt |
            BadEffect.Poisoned |
            BadEffect.Zombie;

        /// <summary>
        /// Bad effects curable by purification pills.
        /// </summary>
        private static readonly BadEffect purificationPillEffects =
            BadEffect.Sleep |
            BadEffect.Bind |
            BadEffect.Dull |
            BadEffect.Fear |
            BadEffect.ShortSighted |
            BadEffect.Bleed |
            BadEffect.Darkness |
            BadEffect.Disease |
            BadEffect.Decay |
            BadEffect.Weak |
            BadEffect.Impotent |
            BadEffect.Division |
            BadEffect.Panic |
            BadEffect.Hidden;

        /// <summary>
        /// Cores the on player bad effect.
        /// </summary>
        private static void OnPlayerBadEffect()
        {
            var useUniversalPill = PlayerConfig.Get<bool>("RSBot.Protection.checkUseUniversalPills", true);

            if (useUniversalPill)
            {
                if ((Game.Player.BadEffect & universalPillEffects) != 0)
                {
                    Game.Player.UseUniversalPill();
                }
                else if ((Game.Player.BadEffect & purificationPillEffects) != 0)
                {
                    Game.Player.UsePurificationPill();
                }
            }
        }
    }
}