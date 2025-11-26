using System.Collections.Generic;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Alchemy;

internal static class GenericAlchemyRequestHandler
{
    public static void Invoke(Packet packet)
    {
        var action = (AlchemyAction)packet.ReadByte();

        if (action != AlchemyAction.Fuse)
            return;

        var type = (AlchemyType)packet.ReadByte();
        if (type == AlchemyType.SocketInsert)
        {
            var item = Game.Player.Inventory.GetItemAt(packet.ReadByte()); //Target item
            var socketItem = Game.Player.Inventory.GetItemAt(packet.ReadByte()); //Target item

            if (item != null && socketItem != null)
                AlchemyManager.ActiveAlchemyItems = new List<InventoryItem> { item, socketItem };

            return;
        }

        var slots = packet.ReadBytes(packet.ReadByte());

        AlchemyManager.ActiveAlchemyItems = new List<InventoryItem>(slots.Length);

        foreach (var slot in slots)
        {
            var item = Game.Player.Inventory.GetItemAt(slot);

            if (item != null)
                AlchemyManager.ActiveAlchemyItems.Add(item);
        }

        EventManager.FireEvent("OnFuseRequest", action, type);

        AlchemyManager.IsFusing = true;
        AlchemyManager.StartTimer();
    }
}
