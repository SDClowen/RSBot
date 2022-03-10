using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;

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
            packet.ReadByte(); //count?
            var destination = packet.ReadByte();
            var amount = packet.ReadUShort();

            var bionic = Game.SelectedEntity;
            if (bionic == null)
                return packet;

            var refPackageItem = Game.ReferenceManager.GetRefPackageItem(
                bionic.Record.CodeName, tab, slot);

            var refItem = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

            if (refItem == null)
            {
                Log.Notify("You bought an item without any reference...");
                return packet;
            }

            Log.Debug($"Bought x{amount} {refPackageItem.RefItemCodeName}");

            var response = new Packet(0xB034);
            response.WriteByte(0x01); //Success
            response.WriteByte(0x06);
            response.WriteByte(destination);
            response.WriteInt(0); //Unknwon (could be unique id)
            response.WriteInt(refItem.ID);

            switch (refItem.TypeID2)
            {
                case 1: //ITEM_EU | ITEM_CH
                    response.WriteByte(refPackageItem.OptLevel);
                    response.WriteLong(refPackageItem.Variance);
                    response.WriteUInt(refPackageItem.Data);

                    response.WriteByte(0); //No magic options!
                    response.WriteShort(1); //No bindings option!
                    response.WriteShort(2); //No bindings
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

            return response;
        }
    }
}