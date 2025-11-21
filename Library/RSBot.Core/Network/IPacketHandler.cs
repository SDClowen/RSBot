namespace RSBot.Core.Network;

/// <summary>
///     Every packet handler has to inerhit this interface.
/// </summary>
public interface IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    ushort Opcode { get; }

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    PacketDestination Destination { get; }

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    void Invoke(Packet packet);
}
