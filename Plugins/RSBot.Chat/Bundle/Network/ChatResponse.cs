using RSBot.Chat.Views;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RSBot.Chat.Network;

internal class ChatResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3026;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var type = (ChatType)packet.ReadByte();

        var message = string.Empty;

        switch (type)
        {
            case ChatType.All:
            case ChatType.AllGM:
                var senderId = packet.ReadUInt();
                message = packet.ReadConditonalString();

                message = ReadChatWithLinkedItems(message);

                if (senderId != Game.Player.UniqueId)
                {
                    if (!SpawnManager.TryGetEntity<SpawnedPlayer>(senderId, out var player))
                        return;

                    View.Instance.AppendMessage(message, player.Name, ChatType.All);
                }
                else
                {
                    View.Instance.AppendMessage(message, Game.Player.Name, ChatType.All);
                }

                break;

            case ChatType.Notice:

                message = packet.ReadConditonalString();

                message = ReadChatWithLinkedItems(message);

                View.Instance.AppendMessage(message, "Notice", type);
                break;

            case ChatType.Npc:
                //TODO: get npc by guid
                break;

            default:
                var sender = packet.ReadString();
                message = packet.ReadConditonalString();

                message = ReadChatWithLinkedItems(message);

                View.Instance.AppendMessage(message, sender, type);
                break;
        }
    }

    public static string ReadChatWithLinkedItems(string message)
    {
        string pattern = "\u0002(.*?)\u0003";
        HashSet<uint> idsToRemove = new HashSet<uint>();

        string result = Regex.Replace(message, pattern, match =>
        {
            string rawValue = match.Groups[1].Value;

            if (uint.TryParse(rawValue, out uint uid))
            {
                if (Bundle.Chat.LinkedItems.TryGetValue(uid, out var data) && data.itemName != null)
                {
                    idsToRemove.Add(uid);

                    return data.amount > 1
                        ? $" < {data.itemName} > [{data.amount}] "
                        : $" < {data.itemName} > ";
                }
            }
            return match.Value;
        });

        foreach (uint id in idsToRemove)
        {
            Bundle.Chat.LinkedItems.Remove(id);
        }

        return result;
    }
}
