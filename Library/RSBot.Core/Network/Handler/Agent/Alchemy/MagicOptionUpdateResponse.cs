using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Alchemy;

internal class MagicOptionUpdateResponse : IPacketHandler
{
    public ushort Opcode => 0x34AA;
    public PacketDestination Destination => PacketDestination.Client;

    public void Invoke(Packet packet)
    {
        var result = packet.ReadByte();

        if (result == 2)
        {
            var errorCode = packet.ReadUShort();

            EventManager.FireEvent("OnMagicOptionUpdateError", errorCode);
        }

        var unkByte = packet.ReadByte(); //planned counter?
        if (unkByte != 0)
        {
            var slot = packet.ReadByte();

            var oldItem = Game.Player.Inventory.GetItemAt(slot);
            var item = InventoryItem.FromPacket(packet, slot);

            EventManager.FireEvent("OnMagicOptionUpdate", oldItem, item);
        }
    }
}
