using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects.Item;
using System.Collections.Generic;

namespace RSBot.Core.Objects
{
    public class InventoryItem
    {
        /// <summary>
        /// Gets or sets the slot.
        /// </summary>
        /// <value>
        /// The slot.
        /// </value>
        public byte Slot { get; set; }

        /// <summary>
        /// Gets or sets the rental.
        /// </summary>
        /// <value>
        /// The rental.
        /// </value>
        public RentInfo Rental { get; set; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public uint ItemId { get; set; }

        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefObjItem Record => Game.ReferenceManager.GetRefItem(ItemId);

        /// <summary>
        /// Gets or sets the opt level.
        /// </summary>
        /// <value>
        /// The opt level.
        /// </value>
        public byte OptLevel { get; set; }

        /// <summary>
        /// Gets or sets the variance.
        /// </summary>
        /// <value>
        /// The variance.
        /// </value>
        public ulong Variance { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public uint Durability { get; set; }

        /// <summary>
        /// Gets or sets the magic options.
        /// </summary>
        /// <value>
        /// The magic options.
        /// </value>
        public List<MagicOptionInfo> MagicOptions { get; set; }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public List<BindingOption> BindingOptions { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public ushort Amount { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public InventoryItemState State { get; set; }

        public static InventoryItem FromPacket(Packet packet, byte destinationSlot = 0, bool hasDestinationSlot = false)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var item = new InventoryItem
            {
                MagicOptions = new List<MagicOptionInfo>(),
                BindingOptions = new List<BindingOption>(),
                Amount = 1
            };

            item.Slot = destinationSlot;

            if (destinationSlot == 0 && !hasDestinationSlot)
            {
                item.Slot = packet.ReadByte();
            }
            item.Rental = RentInfo.FromPacket(packet);
            item.ItemId = packet.ReadUInt();

            if (item.Record == null)
            {
                Log.Notify("No item found for " + item.ItemId);
                return null;
            }
            if (item.Record.TypeID1 == 3)
            {
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
                        case 1: // COS
                            var state = packet.ReadByte(); //State
                            item.State = (InventoryItemState)state;
                            item.Amount = 1;

                            if (state != 0x01)
                            {
                                packet.ReadUInt(); //RefCharID
                                packet.ReadString(); //Name
                                if (item.Record.TypeID4 == 2)
                                    packet.ReadUInt(); //Rent time

                                var buffCount = packet.ReadByte();

                                for (int i = 0; i < buffCount; i++)
                                {
                                    var p1 = packet.ReadByte(); // type, but for what?
                                    packet.ReadUInt(); // skillId??? if p1 == 0
                                    packet.ReadUInt(); // skillLeftTime?? if p1 == 0

                                    if (p1 == 5)
                                    {
                                        var unk1 = packet.ReadUInt(); // ??
                                        var unk2 = packet.ReadByte(); // ??
                                    }
                                }
                            }
                            break;

                        case 2:
                            packet.ReadUInt(); //Monster ObjectId
                            break;

                        case 3:
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
            }

            return item;
        }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <returns></returns>
        public TypeIdFilter GetFilter()
        {
            return new TypeIdFilter(Record.TypeID1, Record.TypeID2, Record.TypeID3, Record.TypeID4);
        }
    }
}