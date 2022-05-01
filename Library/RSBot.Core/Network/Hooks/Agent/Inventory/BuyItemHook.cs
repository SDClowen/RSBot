using RSBot.Core.Components;

namespace RSBot.Core.Network.Hooks.Agent.Inventory
{
    internal class BuyItemHook : IPacketHook
    {
        /// <summary>
        /// Gets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB034;

        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Replaces the packet and returns a new packet.
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public Packet ReplacePacket(Packet packet)
        {
            if (packet.ReadByte() != 0x01 || !ShoppingManager.Running)
                return packet;

            var type = packet.ReadByte();

            if (type != 0x08)
                return packet;

            var tab = packet.ReadByte();
            var slot = packet.ReadByte();

            byte[] destinationSlots = null;
            ushort amount = 0;
            byte itemAmount = 0;
            if (Game.ClientType > GameClientType.Chinese)
            {
                amount = packet.ReadUShort();
                itemAmount = packet.ReadByte();
                destinationSlots = packet.ReadByteArray(itemAmount);
            }
            else
            {
                itemAmount = packet.ReadByte();
                destinationSlots = packet.ReadByteArray(itemAmount);
                amount = packet.ReadUShort();
            }

            var bionic = Game.SelectedEntity;
            if (bionic == null)
                return packet;

            var refPackageItem = Game.ReferenceManager.GetRefPackageItem(bionic.Record.CodeName, tab, slot);
            var refItem = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

            if (refItem == null)
            {
                Log.Notify("You bought an item without any reference...");
                return packet;
            }

            if(itemAmount <= 0)
                itemAmount = 1;

            for (int i = 0; i < itemAmount; i++)
            {
                var destination = destinationSlots[i];

                var response = new Packet(0xB034);
                response.WriteByte(0x01); //Success
                response.WriteByte(0x06);
                response.WriteByte(destination);
                
                if (Game.ClientType > GameClientType.Thailand)
                    response.WriteInt(0);

                response.WriteInt(refItem.ID);

                switch (refItem.TypeID2)
                {
                    case 1:
                    case 4:
                    case 5:
                        response.WriteByte(refPackageItem.OptLevel);
                        response.WriteLong(refPackageItem.Variance);
                        response.WriteUInt(refPackageItem.Data);

                        response.WriteByte(0); //No magic options!

                        if (Game.ClientType > GameClientType.Thailand)
                        {
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

                            for (int j = 1; j <= bindingCount; j++)
                                response.WriteShort(j);
                        }

                        break;

                    case 2: //ITEM_COS
                        switch (refItem.TypeID3)
                        {
                            case 1:
                                response.WriteByte(1); //State
                                break;

                            case 2:
                                packet.WriteUInt(0); //Monster mask or so
                                break;

                            case 3:
                                packet.WriteUShort(0); //Monster mask or so
                                break;

                            default:
                                if (refItem.TypeID4 == 3) //Magic cube
                                    packet.WriteInt(amount);
                                break;
                        }
                        break;

                    case 3: //ITEM_ETC
                        response.WriteUShort(amount);

                        if (refItem.TypeID3 == 11) //Magic stones
                            if (refItem.TypeID4 == 1 || refItem.TypeID4 == 2)
                                packet.WriteByte(0); //AttributeAssimilationProbability
                            else if (refItem.TypeID3 == 14 && refItem.TypeID4 == 2) //ITEM_MALL_GACHA_CARD_WIN & LOSE
                                packet.WriteByte(0);
                        break;
                }

                if (itemAmount > 1)
                    PacketManager.SendPacket(response, Destination);
                else
                    return response;
            }

            return null;
        }
    }
}