using RSBot.Core.Network;
using RSBot.Core.Objects.Item;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects
{
    public class Inventory : IBag
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public byte Size { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<InventoryItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the size of the avatar inventory.
        /// </summary>
        /// <value>
        /// The size of the avatar inventory.
        /// </value>
        public byte AvatarInventorySize { get; set; }

        /// <summary>
        /// Gets or sets the avatars.
        /// </summary>
        /// <value>
        /// The avatars.
        /// </value>
        public List<InventoryItem> Avatars { get; set; }

        /// <summary>
        /// Gets or sets the size of the avatar inventory.
        /// </summary>
        /// <value>
        /// The size of the avatar inventory.
        /// </value>
        public byte JobInventorySize { get; set; }

        /// <summary>
        /// Gets or sets the avatars.
        /// </summary>
        /// <value>
        /// The avatars.
        /// </value>
        public List<InventoryItem> JobItems { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Inventory"/> is full.
        /// </summary>
        /// <value>
        ///   <c>true</c> if full; otherwise, <c>false</c>.
        /// </value>
        public bool Full
        {
            get
            {
                var freeSlots = Size - 13 - Items.Where(i => i.Slot >= 13).ToArray().Length;
                return freeSlots == 0;
            }
        }

        /// <summary>
        /// Creates a new Inventory object from the given packet
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns>The parsed inventory</returns>
        internal static Inventory FromPacket(Packet packet)
        {
            var result = new Inventory
            {
                Items = new List<InventoryItem>(),
                Avatars = new List<InventoryItem>(),
                JobItems = new List<InventoryItem>(),
                Size = packet.ReadByte()
            };

            var itemAmount = packet.ReadByte();
            for (var i = 0; i < itemAmount; i++)
                result.Items.Add(InventoryItem.FromPacket(packet));

            if (Game.ClientType >= GameClientType.Thailand)
            {
                result.AvatarInventorySize = packet.ReadByte();
                var avatarAmount = packet.ReadByte();
                for (var i = 0; i < avatarAmount; i++)
                    result.Avatars.Add(InventoryItem.FromPacket(packet));
            }

            // JOB2
            if (Game.ClientType > GameClientType.Vietnam)
            {
                var specialtyBagSize = packet.ReadByte();
                if (specialtyBagSize > 0)
                {
                    var bagItemCount = packet.ReadByte();
                    for (int i = 0; i < bagItemCount; i++)
                    {
                        packet.ReadByte();   // slot
                        packet.ReadInt();    // maybe rental?
                        packet.ReadInt();    // itemId of 'ITEM_TRADE_SPECIAL_BOX'
                        packet.ReadUShort(); //quantity
                        packet.ReadUShort(); //unknown
                    }
                }

                result.JobInventorySize = packet.ReadByte();
                var itemCount = packet.ReadByte();
                for (int i = 0; i < itemCount; i++)
                    result.JobItems.Add(InventoryItem.FromPacket(packet));
            }

            return result;
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
        /// Gets the item at.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns></returns>
        public InventoryItem GetItemAt(byte slot)
        {
            return Items.FirstOrDefault(item => item.Slot == slot);
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
        /// Removes the item at.
        /// </summary>
        /// <param name="slot">The slot.</param>
        public void RemoveItemAt(byte slot)
        {
            Items.Remove(GetItemAt(slot));
        }

        /// <summary>
        /// Gets the item at.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns></returns>
        public InventoryItem GetAvatarItemAt(byte slot)
        {
            return Avatars.FirstOrDefault(item => item.Slot == slot);
        }

        /// <summary>
        /// Determines whether [has item at] [the specified slot].
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns></returns>
        public bool HasAvatarItemAt(byte slot)
        {
            return Avatars.FirstOrDefault(item => item.Slot == slot) != null;
        }

        /// <summary>
        /// Removes the item at.
        /// </summary>
        /// <param name="slot">The slot.</param>
        public void RemoveAvatarItemAt(byte slot)
        {
            Avatars.Remove(GetItemAt(slot));
        }

        /// <summary>
        /// Gets the item amount.
        /// </summary>
        /// <param name="itemCodeName">Name of the item code.</param>
        /// <returns></returns>
        public ushort GetItemAmount(string itemCodeName)
        {
            var items = Items.Where(i => i.Record.CodeName == itemCodeName);

            return items.Aggregate<InventoryItem, ushort>(0, (current, item) => (ushort)(current + item.Amount));
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public InventoryItem GetItem(TypeIdFilter filter)
        {
            return (from item in Items where filter.EqualsRefItem(item.Record) select item).FirstOrDefault();
        }

        /// <summary>
        /// Gets the best item.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public InventoryItem GetItemBest(TypeIdFilter filter)
        {
            var items = from item in Items where filter.EqualsRefItem(item.Record) select item;

            InventoryItem nearestItem = null;
            foreach (var item in items)
            {
                if (nearestItem == null)
                    nearestItem = item;
                else
                {
                    if (item.Record.ReqLevel1 > nearestItem.Record.ReqLevel1 && item.OptLevel > nearestItem.OptLevel)
                        nearestItem = item;
                }
            }

            return nearestItem;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<InventoryItem> GetItems(TypeIdFilter filter)
        {
            return (from item in Items where filter.EqualsRefItem(item.Record) select item).ToList();
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeEquipment">if set to <c>true</c> [include equipment].</param>
        /// <returns></returns>
        public List<InventoryItem> GetItems(uint id, bool includeEquipment = false)
        {
            return includeEquipment ? Items.Where(i => i.ItemId == id).ToList() : Items.Where(i => i.ItemId == id && i.Slot >= 13).ToList();
        }

        /// <summary>
        /// Moves the item.
        /// </summary>
        /// <param name="sourceSlot">The source slot.</param>
        /// <param name="destinationSlot">The destination slot.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public bool MoveItem(byte sourceSlot, byte destinationSlot, ushort? amount = null)
        {
            var itemAtSource = GetItemAt(sourceSlot);

            if (itemAtSource == null) return false;

            if (amount == null)
                amount = 0;
            if (amount == 0)
                amount = itemAtSource.Amount;

            var packet = new Packet(0x7034);
            packet.WriteByte(0); //kinda flag
            packet.WriteByte(sourceSlot);
            packet.WriteByte(destinationSlot);
            packet.WriteUShort(amount);

            packet.Lock();

            var asyncResult = new AwaitCallback(response =>
            {
                var result = response.ReadByte();
                if(result == 0x01)
                {
                    var operation = response.ReadByte();
                    if (operation != 0)
                        return AwaitCallbackResult.ConditionFailed;

                    var source = response.ReadByte();
                    var destination = response.ReadByte();
                    if (source == sourceSlot && destination == destinationSlot)
                        return AwaitCallbackResult.Successed;
                }

                return AwaitCallbackResult.Failed;
            }, 0xB034);

            PacketManager.SendPacket(packet, PacketDestination.Server, asyncResult);
            asyncResult.AwaitResponse(500);

            return asyncResult.IsCompleted;
        }

        /// <summary>
        /// Gets the first free slot inside the player's inventory.
        /// </summary>
        /// <returns></returns>
        public byte GetFreeSlot()
        {
            for (byte i = 13; i < Size; i++)
            {
                if (GetItemAt(i) == null)
                    return i;
            }

            return 0;
        }
    }
}