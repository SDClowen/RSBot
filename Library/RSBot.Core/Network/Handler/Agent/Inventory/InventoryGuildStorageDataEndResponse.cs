using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Inventory;

internal class InventoryGuildStorageDataEndResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3254;

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

        var storage = Game.Player.GuildStorage;
        storage.Deserialize(packet);

        EventManager.FireEvent("OnGuildStorageData");

        Log.Notify($"Found {storage.Count} item(s) in guild storage.");

        Game.ChunkedPacket = null;
    }
}
