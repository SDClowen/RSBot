using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent;

internal class GameResetRequest : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x34B5;

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
        Game.Ready = false;
        Log.Debug("Game client is loading...");

        if (Game.Clientless)
        {
            Packet gameResetResponse = new Packet(0x34B6);
            PacketManager.SendPacket(gameResetResponse, PacketDestination.Server);
        }

        if (Game.Player.Teleportation == null)
            return;

        Game.Player.Teleportation.IsTeleporting = true;
        Game.Player.State.DialogState = null;

        EventManager.FireEvent("OnTeleportStart");
    }
}
