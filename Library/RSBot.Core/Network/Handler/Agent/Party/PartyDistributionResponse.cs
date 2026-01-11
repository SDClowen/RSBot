using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects.Party;

namespace RSBot.Core.Network.Handler.Agent.Party
{
    internal class PartyDistributionResponse : IPacketHandler
    {
        public ushort Opcode => 0x3068;

        public PacketDestination Destination => PacketDestination.Client;

        public void Invoke(Packet packet)
        {
            uint partyMemberJID = packet.ReadUInt();

            PartyMember member = Game.Party.Members.Find(member => member.MemberId == partyMemberJID);

            if (member == null)
                return;

            uint itemId = packet.ReadUInt();
            RefObjItem item = Game.ReferenceManager.GetRefItem(itemId);
            if (item.TypeID1 == 3)
            {
                //ITEM_
                if (item.TypeID2 == 1)
                {
                    //ITEM_CH_
                    //ITEM_EU_
                    //ITEM_AVATAR_
                    byte optLevel = packet.ReadByte();
                    Log.Notify($"Item [{item.GetRealName() ?? itemId.ToString()} (+{optLevel})] is distributed to [{member.Name}].");
                }
                else if (item.TypeID2 == 2)
                {
                    //ITEM_COS_
                    // No message triggered by server.
                }
                else if (item.TypeID2 == 3)
                {
                    //ITEM_ETC_
                    ushort quantity = packet.ReadUShort();
                    Log.Notify($"Item [{item.GetRealName() ?? itemId.ToString()} {quantity} pieces] is distributed to [{member.Name}].");
                }
            }
        }
    }
}
