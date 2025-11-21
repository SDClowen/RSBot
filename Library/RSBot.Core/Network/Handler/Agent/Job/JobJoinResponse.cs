using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Job;

internal class JobJoinResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB0E1;

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
        var result = packet.ReadByte();

        if (result != 1)
            return;

        Game.Player.JobInformation = new JobInfo
        {
            Type = (JobType)packet.ReadByte(),
            Level = packet.ReadByte(),
            Experience = packet.ReadUInt(),
        };

        Log.Notify($"[Job] Joined job guild {Game.Player.JobInformation.Type}.");

        EventManager.FireEvent("OnJobJoin");
    }
}
