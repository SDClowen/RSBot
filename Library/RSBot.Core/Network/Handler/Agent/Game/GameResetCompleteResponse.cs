using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Game
{
    internal class GameResetCompleteResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x34B6;

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
            if (Core.Game.Player.Teleportation == null) return;

            Core.Game.Player.Teleportation.IsTeleporting = true;
            EventManager.FireEvent("OnTeleportStart");
        }
    }
}