using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.Party.Bundle.PartyMatching.Network
{
    internal class PartyMatchingInviteRequest : IPacketHandler
    {
        public ushort Opcode => 0x706D;

        public PacketDestination Destination => PacketDestination.Client;

        public void Invoke(Packet packet)
        {
            var requestID = packet.ReadUInt();
            var requestType = packet.ReadUInt();
            //var partyMatchingID = packet.ReadUInt();
            //var memberPrimaryMastery = packet.ReadUInt();
            //var memberSecondaryMastery = packet.ReadUInt();
            //var unkByte0 = packet.ReadByte();
            //var member = PartyMember.FromPacket(packet);

            var requestPacket = new Packet(0x306E);
            requestPacket.WriteUInt(requestID);
            requestPacket.WriteUInt(requestType);
            requestPacket.WriteByte(Container.PartyMatching.Config.AutoAccept ? 1 : 2);
            requestPacket.Lock();
            PacketManager.SendPacket(requestPacket, PacketDestination.Server);

            if (Container.PartyMatching.Config.AutoReform)
                if (Game.Party != null && Game.Party.Members?.Count + 1 >= Game.Party.Settings.MaxMember)
                    Container.PartyMatching.RequestPartyList();
        }
    }
}