using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RSBot.Chat.Bundle.Network
{
    internal class LinkedItemResponseHandler : IPacketHandler
    {
        public ushort Opcode => 0xB504;

        public PacketDestination Destination => PacketDestination.Client;

        private const int MAX_CACHE_COUNT = 100;

        private static readonly Queue<ulong> _itemHistory = new();

        public void Invoke(Packet packet)
        {
            packet.ReadByte(); //result 0x01
            var itemsCount = packet.ReadByte(); //items count
            for (byte i = 1; i <= itemsCount; i++)
            {
                
                var uid = packet.ReadULong(); //item unique ID from chat message
                
                var inventoryItem = InventoryItem.FromPacket(packet, i);

                if (!Chat.LinkedItems.ContainsKey(uid))
                {
                    _itemHistory.Enqueue(uid);

                    if (_itemHistory.Count > MAX_CACHE_COUNT)
                    {
                        var oldId = _itemHistory.Dequeue();
                        Chat.LinkedItems.Remove(oldId);
                    }
                }

                Chat.LinkedItems[uid] = inventoryItem;
            }
        }
    }
}
