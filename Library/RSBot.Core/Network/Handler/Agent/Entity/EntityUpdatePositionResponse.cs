using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntityUpdatePositionResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB023;

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
            var position = Position.FromPacket(packet);
            if (uniqueId == Core.Game.Player.UniqueId || (Core.Game.Player.Vehicle != null && uniqueId == Core.Game.Player.Vehicle.UniqueId))
            {
                Core.Game.Player.Tracker.StopMoving(position);
                return;
            }

            var bionic = Core.Game.Spawns.GetBionic(uniqueId);
            if (bionic == null)
                return;

            bionic.Tracker.StopMoving(position);
        }
    }
}