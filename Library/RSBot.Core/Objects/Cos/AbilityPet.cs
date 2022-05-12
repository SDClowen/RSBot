using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;

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
        /// Gets or sets the AbilityPet's Inventory.
        /// </summary>
        /// <value>
        /// The AbilityPet's Inventory.
        /// </value>
        public InventoryItemCollection Inventory { get; set; }

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
                UniqueId = uniqueId,
                Id = id
            };

            packet.ReadUInt(); // COS.CurHP
            packet.ReadUInt(); // COS.MaxHP
            packet.ReadUInt(); // COS.Settings

            result.Name = packet.ReadString();
            result.Inventory = new InventoryItemCollection(packet.ReadByte());

            result.ParseInventory(packet);

            return result;
        }

        /// <summary>
        /// Parse ability pet inventory
        /// </summary>
        /// <param name="Packet">The packet</param>
        public void ParseInventory(Packet packet)
        {
            var itemAmount = packet.ReadByte();
            for (var i = 0; i < itemAmount; i++)
                Inventory.Add(InventoryItem.FromPacket(packet));
        }

        /// <summary>
        /// Releases this instance.
        /// </summary>
        public void Release()
        {
            var packet = new Packet(0x7117);
            packet.WriteUInt(UniqueId);

            PacketManager.SendPacket(packet, PacketDestination.Server);
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

            var callback = new AwaitCallback(response =>
            {
                var result = response.ReadByte();
                if (result == 0x01)
                {
                    response.ReadByte();
                    return response.ReadUInt() == UniqueId ? AwaitCallbackResult.Successed : AwaitCallbackResult.ConditionFailed;
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
        public byte? MoveItemToPlayer(byte slot)
        {
            if (Game.Player.Inventory.Full) return null;

            var destinationSlot = Game.Player.Inventory.GetFreeSlot();

            var packet = new Packet(0x7034);
            packet.WriteByte(0x1A);
            packet.WriteUInt(UniqueId);
            packet.WriteByte(slot);
            packet.WriteByte(destinationSlot);

            var callback = new AwaitCallback(null, 0xB034);
            PacketManager.SendPacket(packet, PacketDestination.Server, callback);
            callback.AwaitResponse();
            return destinationSlot;
        }
    }
}