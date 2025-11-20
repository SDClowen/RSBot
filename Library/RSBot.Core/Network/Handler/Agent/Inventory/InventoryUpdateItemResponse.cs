using System.Collections.Generic;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;

namespace RSBot.Core.Network.Handler.Agent.Inventory;

internal class InventoryUpdateItemResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3040;

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
        var sourceSlot = packet.ReadByte();
        var itemUpdateFlag = (ItemUpdateFlag)packet.ReadByte();

        var item = Game.Player.Inventory.GetItemAt(sourceSlot);
        if (item == null)
            return;

        if (itemUpdateFlag.HasFlag(ItemUpdateFlag.RefObjID))
            item.ItemId = packet.ReadUInt();

        if (itemUpdateFlag.HasFlag(ItemUpdateFlag.OptLevel))
            item.OptLevel = packet.ReadByte();

        if (itemUpdateFlag.HasFlag(ItemUpdateFlag.Variance))
            item.Attributes = new ItemAttributesInfo(packet.ReadULong());

        if (itemUpdateFlag.HasFlag(ItemUpdateFlag.Quanity))
            item.Amount = packet.ReadUShort();

        if (itemUpdateFlag.HasFlag(ItemUpdateFlag.Durability))
            item.Durability = packet.ReadUInt();

        if (itemUpdateFlag.HasFlag(ItemUpdateFlag.State))
            item.State = (InventoryItemState)packet.ReadByte();

        if (itemUpdateFlag.HasFlag(ItemUpdateFlag.MagParams))
        {
            item.MagicOptions = new List<MagicOptionInfo>();

            var magParamCount = packet.ReadByte();

            for (var i = 0; i < magParamCount; i++)
                item.MagicOptions.Add(MagicOptionInfo.FromPacket(packet));
        }

        if (itemUpdateFlag.HasFlag(ItemUpdateFlag.Unknown))
        {
            // When opening a pet, it comes as (ItemUpdateFlag)128, where it is used and I can't find out what the name is. Can update if anyone knows?
        }

        EventManager.FireEvent("OnUpdateInventoryItem", sourceSlot);
    }
}
