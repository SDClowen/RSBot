using RSBot.Core.Event;
using RSBot.Core.Objects.Inventory;

namespace RSBot.Core.Network.Handler.Agent.Inventory;

internal class InventoryOperationRequest : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB034;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        if (packet.ReadByte() != 1)
            return;

        var operation = (InventoryOperation)packet.ReadByte();
        switch (operation)
        {
            case InventoryOperation.SP_BUY_ITEM:

                var tab = packet.ReadByte();
                var slot = packet.ReadByte();
                var quantity = packet.ReadUShort();
                var npcUniqueId = packet.ReadUInt();

                EventManager.FireEvent("OnBuyItemRequest", tab, slot, quantity, npcUniqueId);

                break;

            case InventoryOperation.SP_SELL_ITEM:

                slot = packet.ReadByte();
                quantity = packet.ReadUShort();
                npcUniqueId = packet.ReadUInt();

                EventManager.FireEvent("OnSellItemRequest", slot, quantity, npcUniqueId);

                break;

            case InventoryOperation.SP_BUY_ITEM_COS:

                var cosUniqueId = packet.ReadUInt();
                if (Game.Player.Transport?.UniqueId != cosUniqueId)
                    return;

                tab = packet.ReadByte();
                slot = packet.ReadByte();
                quantity = packet.ReadUShort();
                npcUniqueId = packet.ReadUInt();

                EventManager.FireEvent("OnBuyItemToCosRequest", tab, slot, quantity, npcUniqueId);

                break;

            case InventoryOperation.SP_SELL_ITEM_COS:

                cosUniqueId = packet.ReadUInt();
                if (Game.Player.Transport?.UniqueId != cosUniqueId)
                    return;

                slot = packet.ReadByte();
                quantity = packet.ReadUShort();
                npcUniqueId = packet.ReadUInt();

                EventManager.FireEvent("OnSellItemFromCosRequest", slot, quantity, npcUniqueId);

                break;
        }
    }
}
