using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Job;

internal class JobUpdateExperienceResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x30E6;

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
        Game.Player.JobInformation.Type = (JobType)packet.ReadByte();
        Game.Player.JobInformation.Level = packet.ReadByte();
        Game.Player.JobInformation.Experience = packet.ReadUInt();

        EventManager.FireEvent("OnJobExperienceUpdate");
    }
}
