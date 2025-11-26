using System.Collections.Generic;
using RSBot.Core.Event;
using RSBot.Core.Objects.Party;

namespace RSBot.Core.Network.Handler.Agent.Party;

internal class PartyCreateFromMatching : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3065;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        Game.Party = new Objects.Party.Party { Members = new List<PartyMember>() };

        packet.ReadByte(); //FF

        if (Game.ClientType > GameClientType.Thailand)
            packet.ReadUInt(); // partyId

        var leaderId = packet.ReadUInt();

        Game.Party.Settings = PartySettings.FromType(packet.ReadByte());

        var memberAmount = packet.ReadByte();
        for (var iMember = 0; iMember < memberAmount; iMember++)
            Game.Party.Members.Add(PartyMember.FromPacket(packet));

        Game.Party.Leader = Game.Party.GetMemberById(leaderId);

        EventManager.FireEvent("OnPartyData");
    }
}
