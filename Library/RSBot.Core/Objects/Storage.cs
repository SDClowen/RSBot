using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects
{
    public class Storage : IBag
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<InventoryItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        public byte Size { get; set; }

        /// <summary>
        /// Gets the item at.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns></returns>
        public InventoryItem GetItemAt(byte slot)
        {
            return Items.FirstOrDefault(item => item.Slot == slot);
        }

        /// <summary>
        /// Removes the item at.
        /// </summary>
        /// <param name="slot">The slot.</param>
        public void RemoveItemAt(byte slot)
        {
            Items.Remove(GetItemAt(slot));
        }

        /// <summary>
        /// Updates the item amount.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <param name="amount">The amount.</param>
        public void UpdateItemAmount(byte slot, ushort amount)
        {
            var itemToUpdate = Items.FirstOrDefault(item => item.Slot == slot);
            if (itemToUpdate != null) itemToUpdate.Amount = amount;
        }

        /// <summary>
        /// Updates the item slot.
        /// </summary>
        /// <param name="sourceSlot">The source slot.</param>
        /// <param name="desintationSlot">The desintation slot.</param>
        public void UpdateItemSlot(byte sourceSlot, byte desintationSlot)
        {
            GetItemAt(sourceSlot).Slot = desintationSlot;
        }

        /// <summary>
        /// Determines whether [has item at] [the specified slot].
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns></returns>
        public bool HasItemAt(byte slot)
        {
            return Items.FirstOrDefault(item => item.Slot == slot) != null;
        }

        /// <summary>
        /// Gets the free slot.
        /// </summary>
        /// <returns></returns>
        public byte GetFreeSlot()
        {
            for (byte i = 0; i < 255; i++)
            {
                var item = Items.FirstOrDefault(x => x.Slot == i);

                if (item == null)
                    return i;
            }

            return 0xFF;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public InventoryItem GetItemById(uint id)
        {
            return (from item in Items where item.Record.ID == id select item).FirstOrDefault();
        }
    }
}