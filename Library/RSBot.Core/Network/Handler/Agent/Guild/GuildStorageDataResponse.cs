﻿using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Collections.Generic;

namespace RSBot.Core.Network.Handler.Agent.Guild
{
    internal class GuildStorageDataResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3255;

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
            Core.Game.Player.GuildStorage = new InventoryBase(packet.ReadByte());

            var itemAmount = packet.ReadByte();
            for (var i = 0; i < itemAmount; i++)
                Core.Game.Player.GuildStorage.AddItem(InventoryItem.FromPacket(packet));

            EventManager.FireEvent("OnGuildStorageData");
            Log.Notify($"Found {Core.Game.Player.GuildStorage.ItemsCount} item(s) in guildstorage");
        }
    }
}