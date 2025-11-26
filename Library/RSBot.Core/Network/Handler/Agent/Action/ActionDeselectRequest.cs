namespace RSBot.Core.Network.Handler.Agent.Action;

internal class ActionDeselectRequest : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x704B;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var entityId = packet.ReadUInt();

        if (
            Game.Player.State.DialogState is { IsInDialog: true }
            && Game.Player.State.DialogState.Npc != null
            && Game.Player.State.DialogState.Npc.UniqueId == entityId
        )
            Game.Player.State.DialogState.RequestedCloseNpcId = entityId;
    }
}
