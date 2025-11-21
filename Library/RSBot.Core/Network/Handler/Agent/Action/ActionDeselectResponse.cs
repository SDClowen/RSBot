using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Action;

internal class ActionDeselectResponse : IPacketHandler
{
    /// <summary>
    ///     B
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB04B;

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
        if (packet.ReadByte() != 1)
            return;

        if (
            Game.Player.State.DialogState is { IsInDialog: true }
            && Game.Player.State.DialogState.RequestedCloseNpcId != 0
        )
            Game.Player.State.DialogState = null;

        //Game.SelectedEntity = null;
        EventManager.FireEvent("OnDeselectEntity");
    }
}
