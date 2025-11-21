using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityUpdatePositionResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB023;

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
        var position = Position.FromPacket(packet);
        if (uniqueId == Game.Player.UniqueId)
        {
            Game.Player.StopMoving(position);

            return;
        }

        if (!SpawnManager.TryGetEntity<SpawnedEntity>(uniqueId, out var entity))
            return;

        entity.StopMoving(position);
    }
}
