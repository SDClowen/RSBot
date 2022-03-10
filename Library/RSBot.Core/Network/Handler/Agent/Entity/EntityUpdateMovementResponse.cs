﻿using RSBot.Core.Components;
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
            if (uniqueId == Core.Game.Player.UniqueId || uniqueId == Core.Game.Player.Vehicle?.UniqueId)
            {
                if (movement.HasSource)
                    Core.Game.Player.SetSource(movement.Source);

                if (movement.HasDestination)
                {
                    Core.Game.Player.Move(movement.Destination);

                    if (CollisionManager.Region == null || CollisionManager.Region.Id != movement.Destination.RegionID)
                    {
                        Core.Game.NearbyTeleporters = Core.Game.ReferenceManager.GetTeleporters(movement.Destination.RegionID);

                        Log.Debug($"Found teleporters: {Core.Game.NearbyTeleporters.Length}");

                        CollisionManager.Update(movement.Destination.RegionID);
                    }
                }
                else
                {
                    Core.Game.Player.Move(movement.Destination.Angle);
                }

                EventManager.FireEvent("OnPlayerMove");

                return;
            }

            if (!SpawnManager.TryGetEntity<SpawnedEntity>(uniqueId, out var entity)) 
                return;

            if (movement.HasSource)
                entity.SetSource(movement.Source);

            if (movement.HasDestination)
                entity.Move(movement.Destination);
            else
                entity.Move(movement.Destination.Angle);

            EventManager.FireEvent("OnEntityMove", uniqueId);
        }
    }
}