using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntityUpdateMovementResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB021;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            var uniqueId = packet.ReadUInt();

            var movement = Movement.MotionFromPacket(packet);
            if (uniqueId == Game.Player.UniqueId || uniqueId == Game.Player.Vehicle?.UniqueId)
            {
                // Set source from movement
                if (movement.HasSource)
                    Game.Player.SetSource(movement.Source);

                if (movement.HasAngle)
                {
                    // Movement through angle
                    if (movement.HasDestination)
                    {
                        Game.Player.Move(movement.Angle);
                        EventManager.FireEvent("OnPlayerMove");
                    }
                    else
                    {
                        Game.Player.SetAngle(movement.Angle);
                    }
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
                if (movement.HasDestination)
                {
                    entity.Move(movement.Angle);
                    EventManager.FireEvent("OnEntityMove");
                }
                else
                {
                    entity.SetAngle(movement.Angle);
                }
                return;
            }

            // Movement through click
            entity.Move(movement.Destination);
            EventManager.FireEvent("OnEntityMove", uniqueId);
        }
    }
}