using RSBot.Core.Components;
using RSBot.Core.Network;
using RSBot.Core.Objects.Party;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects;

public class AcceptanceRequest
{
    /// <summary>
    ///     Gets or sets the player unique identifier.
    /// </summary>
    public uint PlayerUniqueId;

    /// <summary>
    ///     The settings [note:just need for party request]
    /// </summary>
    public PartySettings Settings;

    /// <summary>
    ///     Gets or sets the Acceptance Request type.
    /// </summary>
    public InviteRequestType Type;

    /// <summary>
    ///     Gets the player.
    /// </summary>
    /// <value>
    ///     The player.
    /// </value>
    public SpawnedPlayer Player => SpawnManager.GetEntity<SpawnedPlayer>(PlayerUniqueId);

    /// <summary>
    ///     Accepts this party request
    /// </summary>
    public void Accept()
    {
        var packet = new Packet(0x3080);
        packet.WriteByte(1);
        packet.WriteByte(1);

        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Refuses this party request.
    /// </summary>
    public void Refuse()
    {
        var packet = new Packet(0x3080);

        switch (Type)
        {
            case InviteRequestType.Party1:
            case InviteRequestType.Party2:
                packet.WriteByte(2);
                packet.WriteUShort(11276);
                break;

            case InviteRequestType.Resurrection1:
            case InviteRequestType.Resurrection2:
                packet.WriteByte(1);
                packet.WriteByte(2);
                break;
        }

        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Creates a new Acceptance from a packet
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns>Created <seealso cref="AcceptanceRequest" /></returns>
    public static AcceptanceRequest FromPacket(Packet packet)
    {
        return new AcceptanceRequest
        {
            Type = (InviteRequestType)packet.ReadByte(),
            PlayerUniqueId = packet.ReadUInt(),
        };
    }
}
