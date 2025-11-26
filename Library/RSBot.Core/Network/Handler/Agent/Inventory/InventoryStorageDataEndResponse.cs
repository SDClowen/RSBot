using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Inventory;

internal class InventoryStorageDataEndResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3048;

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
        if (Game.ChunkedPacket == null)
            return;

        packet = Game.ChunkedPacket;
        packet.Lock();

        var storage = Game.Player.Storage;
        storage.Deserialize(packet);

        EventManager.FireEvent("OnStorageData");

        Log.Notify($"Found {storage.Count} item(s) in storage.");

        Game.ChunkedPacket = null;
    }
}
