using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Party;

namespace RSBot.Core.Network.Handler.Agent.Party;

internal class PartyInviteResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3080;

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
        Game.AcceptanceRequest = AcceptanceRequest.FromPacket(packet);

        switch (Game.AcceptanceRequest.Type)
        {
            case InviteRequestType.Party1:
            case InviteRequestType.Party2:

                Game.AcceptanceRequest.Settings = PartySettings.FromType(packet.ReadByte());

                if (Game.Party.HasPendingRequest)
                    EventManager.FireEvent("OnPartyRequest");

                break;

            case InviteRequestType.Resurrection1:
            case InviteRequestType.Resurrection2:
                EventManager.FireEvent("OnResurrectionRequest");
                break;
        }
    }
}
