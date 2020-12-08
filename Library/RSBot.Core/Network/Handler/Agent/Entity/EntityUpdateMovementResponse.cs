using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;

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
                    Core.Game.Player.Tracker.SetSource(movement.Source);

                if (movement.HasDestination)
                {
                    Core.Game.Player.Tracker.Move(movement.Destination);

                    if (CollisionManager.Region == null || CollisionManager.Region.Id != movement.Destination.RegionID)
                    {
                        Core.Game.NearbyTeleporters = Core.Game.ReferenceManager.GetTeleporters(movement.Destination.RegionID);

                        Log.Debug($"Found teleporters: {Core.Game.NearbyTeleporters.Length}");

                        CollisionManager.Update(movement.Destination.RegionID);
                    }
                }
                else
                {
                    Core.Game.Player.Tracker.Move(movement.Destination.Angle);
                }

                EventManager.FireEvent("OnPlayerMove");

                return;
            }

            var bionic = Core.Game.Spawns.GetBionic(uniqueId);
            if (bionic == null) return;

            if (movement.HasSource)
                bionic.Tracker.SetSource(movement.Source);

            if (movement.HasDestination)
                bionic.Tracker.Move(movement.Destination);
            else
                bionic.Tracker.Move(movement.Destination.Angle);

            EventManager.FireEvent("OnEntityMove", uniqueId);
        }
    }
}