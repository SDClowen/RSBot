using RSBot.Core.Network;

namespace RSBot.Core.Objects
{
    /// <summary>
    /// The Inventories Of Character.<br/>
    /// 1. The Character's Inventory.<br/>
    /// 2. The Avatar Inventory.<br/>
    /// 3. The Job2 Inventory.<br/>
    /// </summary>
    public class InventoriesOfCharacter
    {
        /// <summary>
        /// The Character's Inventory.
        /// </summary>
        public CharacterInventory Inventory;

        /// <summary>
        /// The Avatar Inventory.
        /// </summary>
        public InventoryBase Avatars;

        /// <summary>
        /// The Job2 Inventory.
        /// </summary>
        public InventoryBase Job2;

        /// <summary>
        /// Creates a new <see cref="InventoriesOfCharacter"/> object from the given packet.
        /// </summary>
        /// <param name="packet">The given packet.</param>
        /// <returns>The parsed <see cref="InventoriesOfCharacter"/> instance.</returns>
        public static InventoriesOfCharacter FromPacket(Packet packet)
        {
            InventoryBase avatars = null;
            InventoryBase job2 = null;

            CharacterInventory inventory = new CharacterInventory(packet.ReadByte());
            var itemAmount = packet.ReadByte();
            for (var i = 0; i < itemAmount; i++)
                inventory.AddItem(InventoryItem.FromPacket(packet));

            if (Game.ClientType >= GameClientType.Thailand)
            {
                avatars = new InventoryBase(packet.ReadByte());
                var avatarAmount = packet.ReadByte();
                for (var i = 0; i < avatarAmount; i++)
                    avatars.AddItem(InventoryItem.FromPacket(packet));
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

                job2 = new InventoryBase(packet.ReadByte());
                var itemCount = packet.ReadByte();
                for (int i = 0; i < itemCount; i++)
                    job2.AddItem(InventoryItem.FromPacket(packet));
            }

            if (avatars == null)
                avatars = new InventoryBase(0);
            if (job2 == null)
                job2 = new InventoryBase(0);

            return new InventoriesOfCharacter()
            {
                Inventory = inventory,
                Avatars = avatars,
                Job2 = job2
            };
        }
    }
}