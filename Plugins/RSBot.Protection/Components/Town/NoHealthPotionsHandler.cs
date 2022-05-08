using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Linq;

namespace RSBot.Protection.Components.Town
{
    public class NoHealthPotionsHandler
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
            CheckForHpPotions();
        }

        /// <summary>
        /// Cores the on use item.
        /// </summary>
        private static void OnUseItem(byte slot)
        {
            if (Kernel.Bot.Running) CheckForHpPotions();
        }

        private static void CheckForHpPotions()
        {
            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkNoHPPotions")) return;

            var typeIdFilter = new TypeIdFilter(3, 3, 1, 1);
            if (Game.Player.Inventory.GetSumAmount(typeIdFilter) > 0)
                return;

            Game.Player.UseReturnScroll();

            Log.WarnLang("ReturnToTownNoHealth");
        }
    }
}