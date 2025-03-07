using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using RSBot.Chat.Views;

namespace RSBot.Chat.Bundle.Network;

/// <summary>
/// Handles incoming chat response packets
/// </summary>
internal class ChatResponse : IPacketHandler
{
    /// <summary>
    /// Gets the opcode for this packet handler
    /// </summary>
    public ushort Opcode => 0x3026;

    /// <summary>
    /// Gets the destination for this packet
    /// </summary>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    /// Processes the incoming chat packet
    /// </summary>
    /// <param name="packet">The packet to process</param>
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
                View.Instance.AppendMessage(message, "Notice", type);
                break;

            case ChatType.Npc:
                //TODO: get npc by guid
                break;

            default:
                var sender = packet.ReadString();
                message = packet.ReadConditonalString();
                View.Instance.AppendMessage(message, sender, type);
                break;
        }
    }
} 