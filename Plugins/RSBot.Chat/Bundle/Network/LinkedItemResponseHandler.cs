using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using System.Collections.Generic;

namespace RSBot.Chat.Bundle.Network
{
    internal class LinkedItemResponseHandler : IPacketHandler
    {
        public ushort Opcode => 0xB504;

        public PacketDestination Destination => PacketDestination.Client;

        private const int MaxCacheSize = 100;

        private static readonly Queue<uint> _itemHistory = new();

        public void Invoke(Packet packet)
        {
            packet.ReadByte(); //result 0x01
            byte itemsCount = packet.ReadByte(); //items count
            for (int i = 1; i <= itemsCount; i++)
            {
                uint UID = packet.ReadUInt(); //item unique ID from chat message
                packet.ReadUInt(); //???
                if (packet.ReadUInt() == 1) //event item???
                {
                    packet.ReadUShort();
                    packet.ReadULong(); //PeriodBeginTime
                    packet.ReadULong(); //PeriodEndTime
                }
                uint ID = packet.ReadUInt(); //item ID
                RefObjItem item = Game.ReferenceManager.GetRefItem(ID);
                if (item == null)
                {
                    Log.Debug($"[LinkedItemResponseHandler] Unknown item ID: {ID}");
                }
                ushort amount = 1;
                string itemName;
                if (item.IsGrowthPet)
                {
                    packet.ReadUInt(); //???
                    packet.ReadByte(); //???
                    packet.ReadString(); //Name
                    packet.ReadByte(); //Level
                    packet.ReadByte(); //???

                    itemName = item.GetRealName() ?? ID.ToString();

                    AddToCache(UID, itemName, amount);
                    continue;
                }
                if (item.IsGrabPet)
                {
                    packet.ReadUInt(); //???
                    packet.ReadByte(); //???
                    packet.ReadString(); //Name
                    packet.ReadUInt(); //ExpirationTime
                    packet.ReadByte(); //???

                    itemName = item.GetRealName() ?? ID.ToString();
                    AddToCache(UID, itemName, amount);
                    continue;
                }
                if (item.IsFellowPet)
                {
                    packet.ReadUInt(); //???
                    packet.ReadByte(); //???
                    packet.ReadString(); //Name
                    packet.ReadByte(); //Level
                    byte indicator = packet.ReadByte(); //???
                    if (indicator == 1)
                    {
                        packet.ReadUInt(); //???
                        packet.ReadByte(); //???
                        packet.ReadUInt(); //???
                    }

                    itemName = item.GetRealName() ?? ID.ToString();
                    AddToCache(UID, itemName, amount);
                    continue;
                }
                if (item.IsStackable)
                    amount = packet.ReadUShort();
                else
                    packet.ReadByte(); //OptLevel
                if (item.IsEquip)
                {
                    packet.ReadUInt(); //Variance (Attributes)
                    packet.ReadUInt(); //???
                    packet.ReadUInt(); //current Durability or Expiration time
                    byte magicOptCount = packet.ReadByte(); //magic options count
                    for (int j = 1; j <= magicOptCount; j++) //MagicOptions
                    {
                        packet.ReadUInt(); //MagicOption type
                        packet.ReadUInt(); //MagicOption value
                    }
                    //BindingOptions
                    packet.ReadByte(); //01 - sockets
                    byte socketsCount = packet.ReadByte(); //sockets count
                    for (int k = 1; k <= socketsCount; k++)
                    {
                        packet.ReadByte(); //order number
                        packet.ReadUShort(); //???
                        packet.ReadUShort(); //socket level
                        packet.ReadUInt(); //???
                    }
                    packet.ReadByte(); //02 - Advanced Elixir
                    byte advancedCount = packet.ReadByte(); //02 - Advanced Elixir count
                    for (int l = 1; l <= advancedCount; l++)
                    {
                        packet.ReadByte(); //???
                        packet.ReadUShort(); //???
                        packet.ReadUShort(); //adv level
                        packet.ReadUInt(); //???
                    }
                    packet.ReadByte(); //03 - Temporaty Enhancement Expiration Time
                    byte tempEnhanceCount = packet.ReadByte(); //03 - Temporaty Enhancement Expiration Time count???
                    for (int m = 1; m <= tempEnhanceCount; m++)
                    {
                        packet.ReadByte(); //???
                        packet.ReadUShort(); //???
                        packet.ReadUShort(); //???
                        packet.ReadUInt(); //???
                    }
                    packet.ReadByte(); //04 - ???
                    byte wtfCount = packet.ReadByte(); //04 - ??? count
                    for (int n = 1; n <= wtfCount; n++)
                    {
                        packet.ReadByte(); //???
                        packet.ReadUShort(); //???
                        packet.ReadUShort(); //???
                        packet.ReadUInt(); //???
                    }
                }
                itemName = item.GetRealName() ?? ID.ToString();
                AddToCache(UID, itemName, amount);
            }
        }

        private void AddToCache(uint uid, string name, ushort amount)
        {
            if (!Chat.LinkedItems.ContainsKey(uid))
            {
                _itemHistory.Enqueue(uid);

                if (_itemHistory.Count > MaxCacheSize)
                {
                    uint oldId = _itemHistory.Dequeue();
                    Chat.LinkedItems.Remove(oldId);
                }
            }

            Chat.LinkedItems[uid] = (name, amount);
        }
    }
}
