using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Action;

internal class ActionCommandResponse : IPacketHandler
{
    /// <summary>
    /// Gets or sets the opcode.
    /// </summary>
    /// <value>
    /// The opcode.
    /// </value>
    public ushort Opcode => 0xB071;

    /// <summary>
    /// Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;


    /// <summary>
    ///     Invokes the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        if (packet.ReadByte() != 0x01)
            return;

        var action = new Objects.Action();
        action.Id = packet.ReadUInt(); //ActionId
        action.TargetId = packet.ReadUInt(); //originalTargetId
        action.Flag = (ActionStateFlag)packet.ReadByte();

        action.ReadPacket(packet);
    }
}
