using RSBot.Core.Event;
using RSBot.Core.Objects.Job;

namespace RSBot.Core.Network.Handler.Agent.Job;

internal class JobCosStuckResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x30E7;

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
        var reason = (TransportStuckReason)packet.ReadByte();
        EventManager.FireEvent("OnJobCosStuck", reason);

        Log.Notify("[Job] Your transport is stuck!");
    }
}
