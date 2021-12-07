using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Invoke(Packet packet)
        {
            var position = Position.FromPacket(packet);
            var uniqueId = packet.ReadUInt();

            if(uniqueId == Core.Game.Player.UniqueId)
            {
                Core.Game.Player.Tracker.SetSource(position);
                return;
            }

            var bionic = Core.Game.Spawns.GetBionic(uniqueId);
            if (bionic == null)
                return;

            bionic.Tracker?.SetSource(position);
        }
    }
}
