using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Town
{
    public class InventoryFullHandler
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
            EventManager.SubscribeEvent("OnInventoryUpdate", OnUpdateInventory);
        }

        /// <summary>
        /// </summary>
        private static void OnUpdateInventory()
        {
            if (!Kernel.Bot.Running) return;
            if (ScriptManager.Running) return;
            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkInventory")) return;
            if (!Game.Player.Inventory.Full) return;

            Log.NotifyLang("ReturnToTownInventoryFull");

            Game.Player.UseReturnScroll();
        }
    }
}