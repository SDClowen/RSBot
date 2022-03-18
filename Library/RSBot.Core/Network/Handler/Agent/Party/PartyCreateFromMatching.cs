using RSBot.Core.Event;
using RSBot.Core.Objects.Party;
using System.Collections.Generic;

namespace RSBot.Core.Network.Handler.Agent.Party
{
    internal class PartyCreateFromMatching : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3065;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            Core.Game.Party = new Objects.Party.Party
            {
                Members = new List<PartyMember>()
            };

            packet.ReadByte(); //FF

            if (Core.Game.ClientType > GameClientType.Thailand)
                packet.ReadUInt(); // partyId

            var leaderId = packet.ReadUInt();

            Core.Game.Party.Settings = PartySettings.FromType(packet.ReadByte());

            var memberAmount = packet.ReadByte();
            for (var iMember = 0; iMember < memberAmount; iMember++)
                Core.Game.Party.Members.Add(PartyMember.FromPacket(packet));

            Core.Game.Party.Leader = Core.Game.Party.GetMemberById(leaderId);

            EventManager.FireEvent("OnPartyData");
        }
    }
}