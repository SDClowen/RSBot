using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntitySingleDespawnResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3016;

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
        var uniqueId = packet.ReadUInt();

        //Check if it's a vehicle for any player
        var player = SpawnManager.GetEntity<SpawnedPlayer>(e => e.TransportUniqueId == uniqueId);

        if (player != null)
        {
            player.OnTransport = false;
            player.TransportUniqueId = 0;
        }

        SpawnManager.TryRemove(uniqueId, out var removedEntity);
        EventManager.FireEvent("OnDespawnEntity", removedEntity);
    }
}
