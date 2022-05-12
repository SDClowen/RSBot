using RSBot.Core.Network;

namespace RSBot.Core.Objects.Inventory
{
    public class Storage : InventoryItemCollection
    {

        /// <summary>
        /// Create instance of the <seealso cref="Storage"/>
        /// </summary>
        /// <param name="size">The standart 150(5 page)</param>
        public Storage(byte size = 150)
            : base(size) {}

        /// <summary>
        /// The gold amount in the storage
        /// </summary>
        public ulong Gold;

        /// <summary>
        /// Deserialize the storage packet
        /// </summary>
        /// <param name="packet">The storage packet</param>
        public void Deserialize(Packet packet)
        {
            Capacity = packet.ReadByte();
            var itemAmount = packet.ReadByte();
            for (var i = 0; i < itemAmount; i++)
                Add(InventoryItem.FromPacket(packet));
        }
    }
}
