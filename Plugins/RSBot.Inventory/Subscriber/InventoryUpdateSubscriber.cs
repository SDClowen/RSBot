using RSBot.Core.Event;
using RSBot.Core;

namespace RSBot.Inventory.Subscriber;

internal static class InventoryUpdateSubscriber
    {
        /// <summary>
        /// Subscribes the events.
        /// </summary>
        public static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnInventoryUpdate", OnInventoryUpdate);
        }

        private static void OnInventoryUpdate()
        {
            var autoSort = PlayerConfig.Get("RSBot.Inventory.AutoSort", true);
            if (autoSort)
                Game.Player.Inventory.Sort();
        }
    }

