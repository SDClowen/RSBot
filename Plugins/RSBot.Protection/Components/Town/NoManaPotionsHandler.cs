using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Linq;

namespace RSBot.Protection.Components.Town
{
    public class NoManaPotionsHandler
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
            EventManager.SubscribeEvent("OnUseItem", new System.Action<byte>(OnUseItem));
            EventManager.SubscribeEvent("OnStartBot", OnStartBot);
        }

        private static void OnStartBot()
        {
            //Check if we need to return to town right after the bot started.
            CheckForMpPotions();
        }

        /// <summary>
        /// Cores the on use item.
        /// </summary>
        private static void OnUseItem(byte slot)
        {
            if (Kernel.Bot.Running) CheckForMpPotions();
 
        }

        private static void CheckForMpPotions()
        {
            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkNoMPPotions")) return;

            var typeIdFilter = new TypeIdFilter(3, 3, 1, 2);
            if (Game.Player.Inventory.GetSumAmount(typeIdFilter) > 0)
                return;

            Game.Player.UseReturnScroll();

            Log.WarnLang("ReturnToTownNoMana");
        }
    }
}