using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using System.Collections.Generic;

namespace RSBot.Alchemy.Helper
{
    internal class RequestHelper
    {
        #region Methods

        public static void SendCancelPacket()
        {
            var packet = new Packet(0x7150);
            packet.WriteByte(0x01);

            packet.Lock();
            Kernel.Proxy.Server.Send(packet);
        }

        public static void SendMagicStoneRequest(InventoryItem item, InventoryItem magicStone)
        {
            Log.Notify($"[LuckyAlchemyBot] Fusing {magicStone.Record.GetRealName()}...");

            var packet = new Packet(0x7151);

            packet.WriteByte(AlchemyAction.Fuse); //Fuse
            packet.WriteByte(AlchemyType.MagicStone); //MagicStone
            packet.WriteByte(2); //Slot count

            packet.WriteByte(item.Slot);
            packet.WriteByte(magicStone.Slot);

            packet.Lock();
            Kernel.Proxy.Server.Send(packet);

            ManuallyHandleFuseRequest(packet);
        }

        /// <summary>
        /// Since the core does not fire the OnFuseRequest if the request was made inside the bot it's required to manually set everything correctly
        /// </summary>
        /// <param name="packet"></param>
        public static void ManuallyHandleFuseRequest(Packet packet)
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
                    Game.Player.AlchemySlots = new Dictionary<byte, InventoryItem>
                    {
                        { item.Slot, item },
                        { socketItem.Slot, item }
                    };

                return;
            }

            var slots = packet.ReadByteArray(packet.ReadByte());

            Game.Player.AlchemySlots = new Dictionary<byte, InventoryItem>(slots.Length);

            foreach (var slot in slots)
            {
                var item = Game.Player.Inventory.GetItemAt(slot);

                if (item != null)
                    Game.Player.AlchemySlots.Add(item.Slot, item);
            }

            EventManager.FireEvent("OnFuseRequest", action, type);
        }

        #endregion Methods
    }
}