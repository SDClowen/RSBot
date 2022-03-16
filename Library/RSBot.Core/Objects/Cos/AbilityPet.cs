using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects
{
    public class AbilityPet : SpawnedEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the size of the inventory.
        /// </summary>
        /// <value>
        /// The size of the inventory.
        /// </value>
        public byte Slots { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<InventoryItem> Items { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="AbilityPet"/> is full.
        /// </summary>
        /// <value>
        ///   <c>true</c> if full; otherwise, <c>false</c>.
        /// </value>
        public bool Full => Items.Count >= Slots;

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static AbilityPet FromPacket(Packet packet, uint uniqueId, uint id)
        {
            var result = new AbilityPet
            {
                Items = new List<InventoryItem>(),
                UniqueId = uniqueId,
                Id = id
            };

            packet.ReadUInt(); // COS.CurHP
            packet.ReadUInt(); // COS.MaxHP
            packet.ReadUInt(); // COS.Settings

            result.Name = packet.ReadString();
            result.Slots = packet.ReadByte();

            var itemAmount = packet.ReadByte();

            for (var i = 0; i < itemAmount; i++)
                result.Items.Add(InventoryItem.FromPacket(packet));

            return result;
        }

        /// <summary>
        /// Releases this instance.
        /// </summary>
        public void Release()
        {
            var packet = new Packet(0x7117);
            packet.WriteUInt(UniqueId);
            packet.Lock();

            PacketManager.SendPacket(packet, PacketDestination.Server);
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
        /// Pickups the specified item unique identifier.
        /// </summary>
        /// <param name="itemUniqueId">The item unique identifier.</param>
        public void Pickup(uint itemUniqueId)
        {
            var packet = new Packet(0x70C5);
            packet.WriteUInt(UniqueId);
            packet.WriteByte(0x08);
            packet.WriteUInt(itemUniqueId);
            packet.Lock();

            var callback = new AwaitCallback(response =>
            {
                var result = response.ReadByte();
                if (result == 0x01)
                {
                    response.ReadByte();
                    return response.ReadUInt() == UniqueId ? AwaitCallbackResult.Received : AwaitCallbackResult.None;
                }

                return AwaitCallbackResult.Failed;
            }, 0xB034);
            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse();
        }

        /// <summary>
        /// Moves the item to player.
        /// </summary>
        /// <param name="slot">The slot.</param>
        public void MoveItemToPlayer(byte slot)
        {
            if (Game.Player.Inventory.Full) return;

            var destinationSlot = Game.Player.Inventory.GetFreeSlot();

            var packet = new Packet(0x7034);
            packet.WriteByte(0x1A);
            packet.WriteUInt(UniqueId);
            packet.WriteByte(slot);
            packet.WriteByte(destinationSlot);
            packet.Lock();

            var callback = new AwaitCallback(null, 0xB034);
            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse();
        }
    }
}