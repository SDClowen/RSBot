using RSBot.Core.Network;
using RSBot.General.Components;
using RSBot.General.Views;

namespace RSBot.General.PacketHandler;

internal class GatewayPendingCancelingResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xA10F;

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
        if (packet.ReadByte() == 0x01)
        {
            AutoLogin.Pending = false;
            View.PendingWindow?.Hide();
            View.PendingWindow?.StopClientlessQueueTask();
        }
    }
}