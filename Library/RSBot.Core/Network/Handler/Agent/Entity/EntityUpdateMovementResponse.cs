using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityUpdateMovementResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB021;

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

        var movement = Movement.MotionFromPacket(packet);
        if (uniqueId == Game.Player.UniqueId)
        {
            // Set source from movement
            if (movement.HasSource)
                Game.Player.SetSource(movement.Source);

            if (movement.HasAngle)
            {
                // Movement through angle
                Game.Player.Move(movement.Angle);
                EventManager.FireEvent("OnPlayerMoveAngle");

                return;
            }

            // Movement through click
            Game.Player.Move(movement.Destination);
            EventManager.FireEvent("OnPlayerMove");

            return;
        }

        if (!SpawnManager.TryGetEntity<SpawnedEntity>(uniqueId, out var entity))
            return;

        // Set source from movement
        if (movement.HasSource)
            entity.SetSource(movement.Source);

        if (movement.HasAngle)
        {
            // Movement through angle
            entity.Move(movement.Angle);
            EventManager.FireEvent("OnEntityMoveAngle", uniqueId);

            return;
        }

        if (Game.Player.Vehicle?.UniqueId == uniqueId)
            EventManager.FireEvent("OnVehicleMove");
        else
            EventManager.FireEvent("OnEntityMove", uniqueId);

        // Movement through click
        entity.Move(movement.Destination);
    }
}
