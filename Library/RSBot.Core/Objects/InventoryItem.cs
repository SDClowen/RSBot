using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects.Item;
using System.Collections.Generic;
using System.Threading;

namespace RSBot.Core.Objects
{
    public class InventoryItem
    {
        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public uint ItemId { get; set; }

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

        /// <summary>
        /// Uses the item
        /// </summary>
        /// <returns></returns>
        public bool Use()
        {
            Log.Debug($"Using item tid: 0x{Record.Tid:x2} {Record.CodeName} {Record}");

            var packet = new Packet(0x704C);
            packet.WriteByte(Slot);

            if(Game.ClientType > GameClientType.Vietnam)
                packet.WriteInt(Record.Tid);
            else
                packet.WriteUShort(Record.Tid);

            var result = false;
            var asyncCallback = new AwaitCallback(response => 
            { 
                return response.ReadByte() == 0x01 ? 
                    AwaitCallbackResult.Successed : AwaitCallbackResult.Failed; 
            }, 0xB04C);

            PacketManager.SendPacket(packet, PacketDestination.Server, asyncCallback);
            asyncCallback.AwaitResponse(500);

            return result;
        }

        /// <summary>
        /// Use the item for destination item
        /// </summary>
        /// <param name="destinationSlot">The destination item slot</param>
        public void UseTo(byte destinationSlot)
        {
            var packet = new Packet(0x704C);
            packet.WriteByte(Slot);
            packet.WriteUShort(Record.Tid);
            packet.WriteByte(destinationSlot);

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Use the item for destination item
        /// </summary>
        /// <param name="destinationSlot">The destination item slot</param>
        public void UseFor(uint uniqueId)
        {
            var packet = new Packet(0x704C);
            packet.WriteByte(Slot);
            packet.WriteUShort(Record.Tid);
            packet.WriteUInt(uniqueId);

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Equip the item
        /// </summary>
        /// <param name="slot">The slot</param>
        public bool Equip(byte slot)
        {
            int attempt = 0;
            while (!Game.Player.Inventory.MoveItem(Slot, slot) && 
                Kernel.Bot.Running && 
                Game.Player.State.ScrollState == ScrollState.Cancel)
            {
                if (attempt++ > 5)
                    return false;

                Thread.Sleep(250);
            }

            return true;
        }

        /// <summary>
        /// Parse from incoming packet
        /// </summary>
        /// <param name="packet">The packet</param>
        /// <param name="destinationSlot">The destination slot</param>
        /// <param name="hasDestinationSlot">The has destination slot</param>
        /// <returns></returns>
        public static InventoryItem FromPacket(Packet packet, byte destinationSlot = 0xFE)
        {
            var item = new InventoryItem
            {
                MagicOptions = new List<MagicOptionInfo>(),
                BindingOptions = new List<BindingOption>(),
                Amount = 1
            };

            item.Slot = destinationSlot;

            if (destinationSlot == 0xFE)
            {
                item.Slot = packet.ReadByte();
            }
            
            if(Game.ClientType > GameClientType.Thailand)
                item.Rental = RentInfo.FromPacket(packet);

            item.ItemId = packet.ReadUInt();

            if (item.Record == null)
            {
                Log.Notify("No item found for " + item.ItemId);

                return null;
            }
            if (item.Record.TypeID1 == 3)
            {
                if (item.Record.TypeID2 == 1 || 
                    item.Record.TypeID2 == 4 ||
                    item.Record.TypeID2 == 5
                    ) //Gear
                {
                    item.OptLevel = packet.ReadByte();
                    item.Variance = packet.ReadULong();
                    item.Durability = packet.ReadUInt(); //Durability?

                    //Read magic options for the item
                    var magicOptionsAmount = packet.ReadByte();
                    for (var iMagicOption = 0; iMagicOption < magicOptionsAmount; iMagicOption++)
                        item.MagicOptions.Add(MagicOptionInfo.FromPacket(packet));

                    if (Game.ClientType > GameClientType.Thailand)
                    {
                        //Read sockets & advanced elixirs

                        var bindingCount = 2;
                        switch (Game.ClientType)
                        {
                            case GameClientType.Chinese:
                            case GameClientType.Global:
                            case GameClientType.Turkey:
                                bindingCount = 4;
                                break;
                            case GameClientType.Korean:
                                bindingCount = 3;
                                break;
                        }

                        for (var bindingIndex = 0; bindingIndex < bindingCount; bindingIndex++)
                        {
                            var bindingType = packet.ReadByte();
                            var bindingAmount = packet.ReadByte();
                            for (var iSocketAmount = 0; iSocketAmount < bindingAmount; iSocketAmount++)
                                item.BindingOptions.Add(BindingOption.FromPacket(packet, bindingType));
                        }
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
                                else if (Game.ClientType >= GameClientType.Chinese)
                                    packet.ReadByte(); // cos level

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

        public override string ToString()
        {
            return Record.CodeName;
        }
    }
}