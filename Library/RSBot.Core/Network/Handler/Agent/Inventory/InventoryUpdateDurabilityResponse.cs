using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Inventory
{
    internal class InventoryUpdateDurabilityResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3052;

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
            var slot = packet.ReadByte();
            var durability = packet.ReadUInt();

            var item = Core.Game.Player.Inventory.GetItemAt(slot);
            item.Durability = durability;

            EventManager.FireEvent("OnUpdateItemDurability", slot, durability);
        }
    }
}