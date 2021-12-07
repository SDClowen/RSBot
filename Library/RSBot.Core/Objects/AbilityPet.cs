using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects.Item;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects
{
    public class AbilityPet
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public uint UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefObjChar Record => Game.ReferenceManager.GetRefObjChar(Id);

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
        /// Gets or sets the bionic.
        /// </summary>
        /// <value>
        /// The bionic.
        /// </value>
        public Spawn.SpawnedBionic Bionic => Core.Game.Spawns.GetBionic(UniqueId);

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

            packet.ReadUInt(); //UNKNOWN
            packet.ReadUInt(); //UNKNOWN
            packet.ReadUInt(); //UNKNOWN

            result.Name = packet.ReadString();
            result.Slots = packet.ReadByte();

            var itemAmount = packet.ReadByte();

            #region Regular inventory

            for (var i = 0; i < itemAmount; i++)
            {
                // ReSharper disable once UseObjectOrCollectionInitializer
                var item = new InventoryItem
                {
                    MagicOptions = new List<MagicOptionInfo>(),
                    BindingOptions = new List<BindingOption>(),
                    Amount = 1
                };

                item.Slot = packet.ReadByte();
                item.Rental = RentInfo.FromPacket(packet);
                item.ItemId = packet.ReadUInt();

                if (item.Record.TypeID2 == 1) //Gear
                {
                    item.OptLevel = packet.ReadByte();
                    item.Variance = packet.ReadULong();
                    item.Durability = packet.ReadUInt(); //Durability?

                    //Read magic options for the item
                    var magicOptionsAmount = packet.ReadByte();
                    for (var iMagicOption = 0; iMagicOption < magicOptionsAmount; iMagicOption++)
                        item.MagicOptions.Add(MagicOptionInfo.FromPacket(packet));

                    //Read sockets & advanced elixirs
                    for (var bindingIndex = 0; bindingIndex < 2; bindingIndex++)
                    {
                        var bindingType = packet.ReadByte();
                        var bindingAmount = packet.ReadByte();
                        for (var iSocketAmount = 0; iSocketAmount < bindingAmount; iSocketAmount++)
                            item.BindingOptions.Add(BindingOption.FromPacket(packet, bindingType));
                    }
                }
                else if (item.Record.TypeID2 == 2)
                {
                    switch (item.Record.TypeID3)
                    {
                        case 1:
                            var state = packet.ReadByte(); //State
                            if (state != 1)
                            {
                                packet.ReadUInt(); //Index
                                packet.ReadString(); //CharacterName
                                packet.ReadByte(); //Unknown
                                if (item.Record.TypeID4 == 2)
                                    packet.ReadUInt(); //Rent time left in seconds
                            }
                            break;

                        case 2:
                            packet.ReadUInt(); //Monster ObjectId
                            break;

                        default:
                            if (item.Record.TypeID4 == 3) //Magic cube
                                packet.ReadUInt(); //Quantity
                            break;
                    }
                }
                else if (item.Record.TypeID2 == 3) //ITEM_ETC
                {
                    item.Amount = packet.ReadUShort();

                    if (item.Record.TypeID3 == 11) //Magic/Attr stone
                    {
                        if (item.Record.TypeID4 == 1 || item.Record.TypeID4 == 2)
                            packet.ReadByte();
                    }
                    else if (item.Record.TypeID3 == 14 && item.Record.TypeID4 == 2)
                    {
                        //ITEM_MALL_GACHA_CARD_WIN
                        //ITEM_MALL_GACHA_CARD_LOSE
                        var magParamCount = packet.ReadByte();
                        for (var iMagPara = 0; iMagPara < magParamCount; iMagPara++)
                        {
                            packet.ReadUInt();
                            packet.ReadUInt();
                        }
                    }
                }
                result.Items.Add(item);
            }

            #endregion Regular inventory

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