﻿using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntityAnimationPromoteResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3054;

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
            if (uniqueId == Core.Game.Player.UniqueId)
            {
                EventManager.FireEvent("OnLevelUp");
                Log.Notify($"Congratulations, your level has increased to [{Core.Game.Player.Level}]");
            }
            else if (Core.Game.Player.HasActiveAttackPet && uniqueId == Core.Game.Player.AttackPet.UniqueId)
                EventManager.FireEvent("OnPetLevelUp");
        }
    }
}