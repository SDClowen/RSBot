using RSBot.Core;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects;

namespace RSBot.Chat.Bundle;

internal class Chat
{
    internal static bool IgnoreChatResponsePacket;

    /// <summary>
    ///     Sends the chat packet.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="message">The message.</param>
    /// <param name="reciever">The reciever.</param>
    internal static void SendChatPacket(ChatType type, string message, string reciever = null)
    {
        var chatPacket = new Packet(0x7025);

        chatPacket.WriteByte(type);
        chatPacket.WriteByte(1); //chatIndex

        if (Game.ClientType > GameClientType.Vietnam)
            chatPacket.WriteByte(0); // has linking

        if (Game.ClientType >= GameClientType.Chinese_Old)
            chatPacket.WriteByte(0);

        if (type == ChatType.Private)
            chatPacket.WriteString(reciever);

        chatPacket.WriteConditonalString(message);

        PacketManager.SendPacket(chatPacket, PacketDestination.Server);
        IgnoreChatResponsePacket = true;
    }

    internal static void SendGlobalChatPacket(string message)
    {
        var inventoryItem = Game.Player.Inventory.GetItem(new TypeIdFilter(3, 3, 3, 5)); //3, 3, 3, 22 for VIP global

        if (inventoryItem != null)
        {
            var globalChatPacket = new Packet(0x704C);

            globalChatPacket.WriteByte(inventoryItem.Slot);

            if (Game.ClientType > GameClientType.Vietnam)
            {
                globalChatPacket.WriteInt(inventoryItem.Record.Tid);
                globalChatPacket.WriteByte(0); //0-3 linked items. max 500 chars when 1-3
            }
            else
            {
                globalChatPacket.WriteUShort(inventoryItem.Record.Tid);
            }

            globalChatPacket.WriteConditonalString(message);

            PacketManager.SendPacket(globalChatPacket, PacketDestination.Server);
        }
    }
}
