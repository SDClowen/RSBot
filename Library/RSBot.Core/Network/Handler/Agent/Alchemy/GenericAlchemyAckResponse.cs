using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Alchemy;

internal static class GenericAlchemyAckResponse
{
    public static void Invoke(Packet packet, AlchemyType type)
    {
        AlchemyManager.IsFusing = false;

        EventManager.FireEvent("OnAlchemy", type);

        var result = packet.ReadByte();

        //Error
        if (result == 2)
        {
            EventManager.FireEvent("OnAlchemyError", packet.ReadUShort(), type);
            AlchemyManager.ActiveAlchemyItems = null;

            return;
        }

        var action = (AlchemyAction)packet.ReadByte();
        if (action == AlchemyAction.Cancel)
        {
            EventManager.FireEvent("OnAlchemyCanceled", type);
            AlchemyManager.ActiveAlchemyItems = null;

            return;
        }

        var isSuccess = packet.ReadBool();

        if (Game.ClientType >= GameClientType.Chinese)
            packet.ReadByte(); //???

        var slot = packet.ReadByte();

        var oldItem = Game.Player.Inventory.GetItemAt(slot);

        if (!isSuccess)
        {
            var isDestroyed = packet.ReadBool();

            if (isDestroyed)
            {
                EventManager.FireEvent("OnAlchemyDestroyed", oldItem, type);
                Game.Player.Inventory.RemoveAt(slot);
                AlchemyManager.ActiveAlchemyItems = null;

                return;
            }
        }

        var newItem = InventoryItem.FromPacket(packet, slot);

        Game.Player.Inventory.RemoveAt(slot);
        Game.Player.Inventory.Add(newItem);

        EventManager.FireEvent(isSuccess ? "OnAlchemySuccess" : "OnAlchemyFailed", oldItem, newItem, type);
        EventManager.FireEvent("OnInventoryUpdate");
        AlchemyManager.ActiveAlchemyItems = null;
    }
}
