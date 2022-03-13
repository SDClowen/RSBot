using RSBot.Core;
using RSBot.Core.Network;
using RSBot.Theme.Extensions;

namespace RSBot.Chat.Network
{
    internal class AgentNotifyResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x300C;

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
            var noticeType = packet.ReadByte();

            switch (noticeType)
            {
                //[%s] has appeared
                case 0x5:
                    var refObjId = packet.ReadUInt();
                    if (!Game.ReferenceManager.CharacterData.TryGetValue(refObjId, out var obj))
                        return;

                    Views.View.Instance.UniqueText.Write($"{obj.GetRealName()} has appeared.");

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
                        Views.View.Instance.UniqueText.Write($"{obj.GetRealName()} has disappeared.");
                        return;
                    }

                    Views.View.Instance.UniqueText.Write($"{characterName} has killed the {obj.GetRealName()}.");

                    break;
            }
        }
    }
}
