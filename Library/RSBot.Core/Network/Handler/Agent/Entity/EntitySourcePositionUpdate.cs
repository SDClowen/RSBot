﻿using RSBot.Core.Components;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntitySourcePositionUpdate : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3028;

        /// <summary>
        /// Invoke the packet handler
        /// </summary>
        /// <param name="packet"></param>
        public void Invoke(Packet packet)
        {
            var position = Position.FromPacket(packet);
            var uniqueId = packet.ReadUInt();

            if(uniqueId == Core.Game.Player.UniqueId)
            {
                Core.Game.Player.SetSource(position);
                return;
            }

            if (!SpawnManager.TryGetEntity(uniqueId, out var entity))
                return;

            entity.SetSource(position);
        }
    }
}
