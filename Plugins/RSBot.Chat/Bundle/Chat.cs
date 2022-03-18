using RSBot.Chat.Objects;
using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.Chat.Bundle
{
    internal class Chat
    {
        internal static bool IgnoreChatResponsePacket;

        /// <summary>
        /// Sends the chat packet.
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

            if (Game.ClientType >= GameClientType.Chinese)
                chatPacket.WriteByte(0);

            if (type == ChatType.Private)
                chatPacket.WriteString(reciever);

            if (!Game.ClientType.ToString().StartsWith("Vietnam"))
                chatPacket.WriteUnicode(message);
            else
                chatPacket.WriteString(message);

            chatPacket.Lock();

            PacketManager.SendPacket(chatPacket, PacketDestination.Server);
            IgnoreChatResponsePacket = true;
        }
    }
}