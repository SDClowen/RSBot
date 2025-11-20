using RSBot.Core.Network;

namespace RSBot.General.PacketHandler;

internal class GatewayLoginRequestGlobal : IPacketHandler
{
    /// <summary>
    ///     Gets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x610A;

    /// <summary>
    ///     Gets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    ///     Replaces the packet and returns a new packet.
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    public void Invoke(Packet packet)
    {
        new GatewayLoginRequest().Invoke(packet);
    }
}
