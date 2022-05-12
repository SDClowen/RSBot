using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Alchemy
{
    internal static class GenericAlchemyAckResponse
    {
        public static void Invoke(Packet packet, AlchemyType type)
        {
            EventManager.FireEvent("OnAlchemy", type);
            Game.Player.ActiveAlchemyItems = null;

            var result = packet.ReadByte();

            //Error
            if (result == 2)
            {
                EventManager.FireEvent("OnAlchemyError", packet.ReadUShort(), type);

                return;
            }

            var action = (AlchemyAction)packet.ReadByte();
            if (action == AlchemyAction.Cancel)
            {
                EventManager.FireEvent("OnAlchemyCanceled", type);

                return;
            }

            var isSuccess = packet.ReadBool();
            var slot = packet.ReadByte();

            var oldItem = Game.Player.Inventory.GetItemAt(slot);

            if (!isSuccess)
            {
                var isDestroyed = packet.ReadBool();

                if (isDestroyed)
                {

                    EventManager.FireEvent("OnAlchemyDestroyed", oldItem, type);
                    Game.Player.Inventory.RemoveAt(slot);

                    return;
                }
            }
            
            var newItem = InventoryItem.FromPacket(packet, slot);

            Game.Player.Inventory.RemoveAt(slot);
            Game.Player.Inventory.Add(newItem);

            EventManager.FireEvent(isSuccess ? "OnAlchemySuccess" : "OnAlchemyFailed", oldItem, newItem, type);
        }
    }
}