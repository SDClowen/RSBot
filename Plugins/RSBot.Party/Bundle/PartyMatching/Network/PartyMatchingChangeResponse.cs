using RSBot.Core;
using RSBot.Core.Network;
using RSBot.Core.Objects.Party;

namespace RSBot.Party.Bundle.PartyMatching.Network
{
    internal class PartyMatchingChangeResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>The opcode.</value>
        public ushort Opcode => 0xB06A;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            if (packet.ReadByte() != 0x01) return;

            Container.PartyMatching.Id = packet.ReadUInt();
            packet.ReadUInt();

            Game.Party.Settings = PartySettings.FromType(packet.ReadByte());
            Container.PartyMatching.Config.Purpose = (PartyPurpose)packet.ReadByte();
            Container.PartyMatching.Config.LevelFrom = packet.ReadByte();
            Container.PartyMatching.Config.LevelTo = packet.ReadByte();

            string title;
            if (!Game.ClientType.ToString().StartsWith("Vietnam") &&
                Game.ClientType != GameClientType.Chinese)
                title = packet.ReadUnicode();
            else
                title = packet.ReadString();

            Container.PartyMatching.Config.Title = title;

            Core.Event.EventManager.FireEvent("OnChangePartyEntry");
        }
    }
}