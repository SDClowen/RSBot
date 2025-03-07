using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Network;
using RSBot.Chat.Views;

namespace RSBot.Chat.Bundle.Network;

/// <summary>
/// Handles agent notification packets
/// </summary>
internal class AgentNotifyResponse : IPacketHandler
{
    /// <summary>
    /// Gets the opcode for this packet handler
    /// </summary>
    public ushort Opcode => 0x300C;

    /// <summary>
    /// Gets the destination for this packet
    /// </summary>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    /// Processes the incoming agent notification packet
    /// </summary>
    /// <param name="packet">The packet to process</param>
    public void Invoke(Packet packet)
    {
        var noticeType = packet.ReadByte();
        if (Game.ClientType > GameClientType.Thailand)
            packet.ReadByte();

        switch (noticeType)
        {
            //[%s] has appeared
            case 0x5:
                var refObjId = packet.ReadUInt();
                if (!Game.ReferenceManager.CharacterData.TryGetValue(refObjId, out var obj))
                    return;

                View.Instance.AppendUniqueMessage(LanguageManager.GetLang("UniqueAppeared", obj.GetRealName()));
                break;

            //[%s] has disappeared or killed
            case 0x6:
                refObjId = packet.ReadUInt();
                if (!Game.ReferenceManager.CharacterData.TryGetValue(refObjId, out obj))
                    return;

                var characterName = packet.ReadString();

                // If name equals "???" then "[%s] has disappeared." is displayed.
                if (characterName == "???")
                {
                    View.Instance.AppendUniqueMessage($"{obj.GetRealName()} has disappeared.");
                    return;
                }

                View.Instance.AppendUniqueMessage(LanguageManager.GetLang("UniqueKilled", characterName, obj.GetRealName()));
                break;
        }
    }
} 