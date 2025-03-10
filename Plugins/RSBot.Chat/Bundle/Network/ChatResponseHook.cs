using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.Chat.Bundle.Network;

/// <summary>
/// Hooks chat response packets to handle ignore states
/// </summary>
internal class ChatResponseHook : IPacketHook
{
    /// <summary>
    /// Gets the opcode for this packet hook
    /// </summary>
    public ushort Opcode => 0xB025;

    /// <summary>
    /// Gets the destination for this packet
    /// </summary>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    /// Replaces or filters the incoming packet based on ignore state
    /// </summary>
    /// <param name="packet">The packet to process</param>
    /// <returns>The modified packet or null if packet should be ignored</returns>
    public Packet ReplacePacket(Packet packet)
    {
        if (!Game.Clientless && Chat.IgnoreChatResponsePacket)
        {
            Chat.IgnoreChatResponsePacket = false;
            return null;
        }

        return packet;
    }
} 