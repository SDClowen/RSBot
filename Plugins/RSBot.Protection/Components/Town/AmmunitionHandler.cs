using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Town
{
    public class AmmunitionHandler
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
            EventManager.SubscribeEvent("OnUpdateAmmunition", OnUpdateAmmunition);
        }

        /// <summary>
        /// Cores the on update ammunition.
        /// </summary>
        private static void OnUpdateAmmunition()
        {
            if (!Kernel.Bot.Running)
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkNoArrows"))
                return;

            var currentAmmuniton = Game.Player.GetAmmunationAmount(true);
            if (currentAmmuniton == -1 || currentAmmuniton > 10) 
                return;

            Log.WarnLang("ReturnToTownNoAmmo");
            Game.Player.UseReturnScroll();
        }
    }
}