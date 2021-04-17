using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedItem
    {
        /// <summary>
        /// The UniqueId
        /// </summary>
        public uint UniqueId;

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public uint Id;

        /// <summary>
        /// Gets or sets the opt level.
        /// </summary>
        /// <value>
        /// The opt level.
        /// </value>
        public byte OptLevel;

        /// <summary>
        /// Gets or sets the name of the owner.
        /// </summary>
        /// <value>
        /// The name of the owner.
        /// </value>
        public string OwnerName;

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public uint Amount;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has owner.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has owner; otherwise, <c>false</c>.
        /// </value>
        public bool HasOwner;

        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        public uint OwnerJID;

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        /// <value>
        /// The rarity.
        /// </value>
        public ObjectRarity Rarity;

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefObjItem Record => Game.ReferenceManager.GetRefItem(Id);

        /// <summary>
        /// The position
        /// </summary>
        public Position Position;

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <returns></returns>
        internal static SpawnedItem FromPacket(Packet packet, uint itemId)
        {
            var result = new SpawnedItem { Id = itemId };

            if (result.Record.IsWear)
            {
                result.OptLevel = packet.ReadByte();
            }
            else if (result.Record.IsGold)
            {
                result.Amount = packet.ReadUInt();
            }
            else if (result.Record.IsQuest || result.Record.IsTrading)
            {
                result.OwnerName = packet.ReadString();
            }
            else
            {
                // TODO: Write log
                Log.Debug($"Unknown item type:{result.Record}\nThe package will still be tried to be read.");
            }

            result.UniqueId = packet.ReadUInt();
            result.Position = Position.FromPacket(packet);
            result.HasOwner = packet.ReadBool();

            if (result.HasOwner)
                result.OwnerJID = packet.ReadUInt();

            result.Rarity = (ObjectRarity)packet.ReadByte();

            return result;
        }
    }
}