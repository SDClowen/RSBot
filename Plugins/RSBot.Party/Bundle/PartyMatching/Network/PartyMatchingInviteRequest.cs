using RSBot.Core;
using RSBot.Core.Network;
using System.Threading.Tasks;

namespace RSBot.Party.Bundle.PartyMatching.Network;

internal class PartyMatchingInviteRequest : IPacketHandler
{
    public ushort Opcode => 0x706D;

    public PacketDestination Destination => PacketDestination.Client;

    public void Invoke(Packet packet)
    {
        if (Container.PartyMatching.Config.AutoAccept)
        {
            var requestID = packet.ReadUInt();
            var requestType = packet.ReadUInt();
            //var partyMatchingID = packet.ReadUInt();
            //var memberPrimaryMastery = packet.ReadUInt();
            //var memberSecondaryMastery = packet.ReadUInt();
            //var unkByte0 = packet.ReadByte();
            //var member = PartyMember.FromPacket(packet);

            ushort opcode = 0x306E;
            if (Game.ClientType > GameClientType.Chinese)
                opcode = 0x308D;

            var requestPacket = new Packet(opcode);
            requestPacket.WriteUInt(requestID);
            requestPacket.WriteUInt(requestType);
            requestPacket.WriteByte(1); //1 - accept, 2 - decline
            PacketManager.SendPacket(requestPacket, PacketDestination.Server);
        }

        if (Container.PartyMatching.Config.AutoReform)
            if (Game.Party != null && Game.Party.Members?.Count + 1 >= Game.Party.Settings.MaxMember)
                _ = Task.Run(() => Container.PartyMatching.RequestPartyList());
    }
}