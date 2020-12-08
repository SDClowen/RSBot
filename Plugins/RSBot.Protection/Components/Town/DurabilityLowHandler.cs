using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Town
{
    public class DurabilityLowHandler
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
            EventManager.SubscribeEvent("OnUpdateItemDurability", new System.Action<byte, uint>(OnUpdateItemDurability));
        }

        /// <summary>
        /// Cores the on update item.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <param name="durability">The durability.</param>
        private static void OnUpdateItemDurability(byte slot, uint durability)
        {
            if (!Kernel.Bot.Running) return;
            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkDurability")) return;

            var item = Game.Player.Inventory.GetItemAt(slot);
            if (item.Slot > 12) return; //Only equipment
            if (durability > 5) return;

            Log.Notify($"Returning to town: The durability of the item {item.Record.GetRealName()} low.");
            Game.Player.UseReturnScroll();
        }
    }
}