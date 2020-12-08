using RSBot.Chat.Objects;
using RSBot.Chat.Views;
using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.Chat.Network
{
    internal class ChatResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3026;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            var type = (ChatType)packet.ReadByte();

            switch (type)
            {
                case ChatType.All:
                case ChatType.AllGM:
                    var senderId = packet.ReadUInt();

                    var messageAll = packet.ReadString();
                    if (senderId != Game.Player.UniqueId)
                    {
                        var playerName = Game.Spawns.GetPlayer(senderId).Name;
                        View.Instance.AppendMessage(messageAll, playerName, ChatType.All);
                    }
                    else
                        View.Instance.AppendMessage(messageAll, Game.Player.Name, ChatType.All);

                    break;

                case ChatType.Notice:
                    var messageNotice = packet.ReadString();
                    View.Instance.AppendMessage(messageNotice, "Notice", type);
                    break;

                case ChatType.Npc:
                    //TODO: get npc by guid
                    break;

                default:
                    var sender = packet.ReadString();
                    var message = packet.ReadString();

                    View.Instance.AppendMessage(message, sender, type);
                    break;
            }
        }
    }
}