using RSBot.Core.Network;

namespace RSBot.Core.Objects.Inventory
{
    /// <summary>
    /// Base class derived from <seealso cref="InventoryItemCollection"/> for handling Storage and GuildStorage.
    /// </summary>
    public class Storage : InventoryItemCollection
    {
        /// <summary>
        /// Create instance of the <seealso cref="Storage"/> from packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public Storage(Packet packet) : base(packet)
        {
        }

        /// <summary>
        /// The gold amount in the storage
        /// </summary>
        public ulong Gold;
    }
}
