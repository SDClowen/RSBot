using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Collections.Generic;

namespace RSBot.Core.Network.Handler.Agent.Alchemy
{
    internal static class GenericAlchemyRequestHandler
    {
        public static void Invoke(Packet packet)
        {
            var action = (AlchemyAction)packet.ReadByte();

            if (action != AlchemyAction.Fuse) return;

            var type = (AlchemyType)packet.ReadByte();
            if (type == AlchemyType.SocketInsert)
            {
                var item = Game.Player.Inventory.GetItemAt(packet.ReadByte()); //Target item
                var socketItem = Game.Player.Inventory.GetItemAt(packet.ReadByte()); //Target item

                if (item != null && socketItem != null)
                    Game.Player.ActiveAlchemyItems = new Dictionary<byte, InventoryItem>
                    {
                        { item.Slot, item },
                        { socketItem.Slot, item }
                    };

                return;
            }

            var slots = packet.ReadByteArray(packet.ReadByte());

            Game.Player.ActiveAlchemyItems = new Dictionary<byte, InventoryItem>(slots.Length);

            foreach (var slot in slots)
            {
                var item = Game.Player.Inventory.GetItemAt(slot);

                if (item != null)
                    Game.Player.ActiveAlchemyItems.Add(item.Slot, item);
            }

            EventManager.FireEvent("OnFuseRequest", action, type);
        }
    }
}