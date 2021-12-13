using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntityUpdateMoveSpeedResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x30D0;

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
            var walkSpeed = packet.ReadFloat();
            var runSpeed = packet.ReadFloat();
            if (uniqueId == Core.Game.Player.UniqueId || (Core.Game.Player.Vehicle != null && uniqueId == Core.Game.Player.Vehicle.UniqueId))
            {
                Core.Game.Player.State.WalkSpeed = walkSpeed;
                Core.Game.Player.State.RunSpeed = runSpeed;

                Core.Game.Player.Tracker.SetSpeed(Core.Game.Player.State.WalkSpeed, Core.Game.Player.State.RunSpeed);

                EventManager.FireEvent("OnUpdatePlayerSpeed");
            }
            else
            {
                if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var bionic))
                    return;

                bionic.State.WalkSpeed = walkSpeed;
                bionic.State.RunSpeed = runSpeed;

                bionic.Tracker.SetSpeed(walkSpeed, runSpeed);

                EventManager.FireEvent("OnUpdateEntitySpeed", uniqueId);
            }
        }
    }
}