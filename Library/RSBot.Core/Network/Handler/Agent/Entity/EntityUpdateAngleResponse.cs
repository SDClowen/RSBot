using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityUpdateAngleResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB024;

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
        var angle = packet.ReadShort();

        if (Game.Player.UniqueId == uniqueId)
        {
            Game.Player.SetAngle(angle);
            return;
        }

        if (!SpawnManager.TryGetEntity<SpawnedEntity>(uniqueId, out var entity))
            return;

        entity.SetAngle(angle);
    }
}
