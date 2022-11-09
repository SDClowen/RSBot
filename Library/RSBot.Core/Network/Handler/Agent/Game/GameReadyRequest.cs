using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent
{
    internal class GameReadyRequest : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3012;

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
            Game.Ready = true;
            Game.Player.Teleportation = null;
            
            Log.Debug("Game loaded!");
            EventManager.FireEvent("OnTeleportComplete");
        }
    }
}
