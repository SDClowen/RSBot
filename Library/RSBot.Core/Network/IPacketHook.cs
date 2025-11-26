namespace RSBot.Core.Network;

public interface IPacketHook
{
    /// <summary>
    ///     Gets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    ushort Opcode { get; }

    /// <summary>
    ///     Gets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    PacketDestination Destination { get; }

    /// <summary>
    ///     Replaces the packet and returns a new packet.
    /// </summary>
    /// <returns></returns>
    Packet ReplacePacket(Packet packet);
}
