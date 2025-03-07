using RSBot.Core;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects;

namespace RSBot.Chat.Bundle;

/// <summary>
/// Handles chat packet sending operations
/// </summary>
internal class Chat
{
    /// <summary>
    /// Flag to indicate whether to ignore the next chat response packet
    /// </summary>
    internal static bool IgnoreChatResponsePacket;

    /// <summary>
    /// Sends a chat packet to the server
    /// </summary>
    /// <param name="type">The type of chat message</param>
    /// <param name="message">The message content</param>
    /// <param name="receiver">The message receiver (for private messages)</param>
    internal static void SendChatPacket(ChatType type, string message, string receiver = null)
    {
        var chatPacket = new Packet(0x7025);

        chatPacket.WriteByte(type);
        chatPacket.WriteByte(1); //chatIndex

        if (Game.ClientType > GameClientType.Vietnam)
            chatPacket.WriteByte(0); // has linking

        if (Game.ClientType >= GameClientType.Chinese)
            chatPacket.WriteByte(0);

        if (type == ChatType.Private)
            chatPacket.WriteString(receiver);

        chatPacket.WriteConditonalString(message);

        PacketManager.SendPacket(chatPacket, PacketDestination.Server);
        IgnoreChatResponsePacket = true;
    }
} 