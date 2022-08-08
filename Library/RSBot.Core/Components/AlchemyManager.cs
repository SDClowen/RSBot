using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Network.Handler.Agent.Alchemy;
using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Components
{
    public class AlchemyManager
    {
        /// <summary>
        /// Gets or sets a list of inventory items currently used in an alchemy operation.
        ///
        /// Attention! This object is only set during alchemy operations and will be set to NULL if any ACK response has been received!
        /// </summary>
        public static List<InventoryItem>? ActiveAlchemyItems { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the player is performing an alchemy operation
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public static bool IsActive => ActiveAlchemyItems == null || !ActiveAlchemyItems.Any();

        /// <summary>
        /// Cancels the pending alchemy operation.
        /// </summary>
        public static void CancelPending()
        {
            var packet = new Packet(0x7150);
            packet.WriteByte(0x01);

            packet.Lock();
            Kernel.Proxy.Server.Send(packet);
        }

        /// <summary>
        /// Fuses the elixir with the specified item using the given lucky powder ingredient.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="elixir">The elixir.</param>
        /// <param name="powder">The powder.</param>
        public static void FuseElixir(InventoryItem item, InventoryItem elixir, InventoryItem? powder)
        {
            Log.Notify($"[Alchemy] Fusing elixir {elixir.Record.GetRealName()} to {item.Record.GetRealName()}");

            var packet = new Packet(0x7150);
            packet.WriteByte(AlchemyAction.Fuse); //fuse
            packet.WriteByte(AlchemyType.Elixir); //type (Elixir)
            packet.WriteByte(powder != null ? (byte)3 : (byte)2); //slots
            packet.WriteByte(item.Slot);
            packet.WriteByte(elixir.Slot);

            if (powder != null)
                packet.WriteByte(powder.Slot);

            packet.Lock();

            Kernel.Proxy.Server.Send(packet);

            GenericAlchemyRequestHandler.Invoke(packet);
        }

        /// <summary>
        /// Fuses the magic stone with the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="magicStone">The elixir.</param>
        public static void FuseMagicStone(InventoryItem item, InventoryItem magicStone)
        {
            Log.Notify($"[Alchemy] Fusing magic stone {magicStone.Record.GetRealName()} to item {item.Record.GetRealName()}");

            var packet = new Packet(0x7151);

            packet.WriteByte(AlchemyAction.Fuse); //Fuse
            packet.WriteByte(AlchemyType.MagicStone); //MagicStone
            packet.WriteByte(2); //Slot count

            packet.WriteByte(item.Slot);
            packet.WriteByte(magicStone.Slot);

            packet.Lock();
            Kernel.Proxy.Server.Send(packet);

            GenericAlchemyRequestHandler.Invoke(packet);
        }

        /// <summary>
        /// Fuses the attribute stone with the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="attributeStone">The attribute stone.</param>
        public static void FuseAttributeStone(InventoryItem item, InventoryItem attributeStone)
        {
            Log.Notify($"[Alchemy] Fusing attribute stone {attributeStone.Record.GetRealName()} to item {item.Record.GetRealName()}");

            var packet = new Packet(0x7151);

            packet.WriteByte(AlchemyAction.Fuse); //Fuse
            packet.WriteByte(AlchemyType.AttributeStone); //MagicStone
            packet.WriteByte(2); //Slot count

            packet.WriteByte(item.Slot);
            packet.WriteByte(attributeStone.Slot);

            packet.Lock();
            Kernel.Proxy.Server.Send(packet);

            GenericAlchemyRequestHandler.Invoke(packet);
        }
    }
}