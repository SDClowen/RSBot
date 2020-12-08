using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Linq;

namespace RSBot.Core.Network.Handler.Agent.Teleport
{
    internal class TeleportRequest : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x705A;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Server;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            var teleporterUniqueId = packet.ReadUInt();
            var teleportType = (TeleportType)packet.ReadByte();
            var destination = packet.ReadUInt();

            var npc = Core.Game.Spawns.GetPortal(teleporterUniqueId);

            if (npc == null)
            {
                var bionic = Core.Game.Spawns.GetBionic(teleporterUniqueId);
                Core.Game.Player.Teleportation = new Teleportation
                {
                    Destination = Core.Game.ReferenceManager.TeleportData.FirstOrDefault(t => t.ID == destination),
                };

                EventManager.FireEvent("OnRequestTeleport", destination, bionic.Record.CodeName);

                return;
            }

            Core.Game.Player.Teleportation = new Teleportation
            {
                Destination = Core.Game.ReferenceManager.TeleportData.FirstOrDefault(t => t.ID == destination),
            };

            EventManager.FireEvent("OnRequestTeleport", destination, npc.Record.CodeName);
        }
    }
}