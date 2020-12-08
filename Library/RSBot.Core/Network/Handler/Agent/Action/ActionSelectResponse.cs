using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Action
{
    internal class ActionSelectResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB045;

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
            if (packet.ReadByte() != 0x01) return;
            Core.Game.LastSelectedEntity = Core.Game.SelectedEntity;
            Core.Game.SelectedEntity = Objects.Entity.FromPacket(packet);

            EventManager.FireEvent("OnSelectEntity");
        }
    }
}