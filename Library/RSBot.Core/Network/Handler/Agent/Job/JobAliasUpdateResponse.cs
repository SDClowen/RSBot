using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Job;

internal class JobAliasUpdateResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB0E3;

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

        packet.ReadByte(); //IsUpdate
        Game.Player.JobInformation.Name = packet.ReadString();

        Log.Notify($"[Job] New job alias assigned: {Game.Player.JobInformation.Name}");

        EventManager.FireEvent("OnJobAliasUpdate");
    }
}
