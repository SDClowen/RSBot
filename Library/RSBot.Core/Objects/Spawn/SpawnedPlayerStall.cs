﻿using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedPlayerStall
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the decoration identifier.
        /// </summary>
        /// <value>
        /// The decoration identifier.
        /// </value>
        public uint DecorationId { get; set; }

        /// <summary>
        /// Gets the decoration.
        /// </summary>
        /// <value>
        /// The decoration.
        /// </value>
        public RefObjItem Decoration => Game.ReferenceManager.GetRefItem(DecorationId);

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        internal static SpawnedPlayerStall FromPacket(Packet packet)
        {
            var spawnedPlayerStall = new SpawnedPlayerStall();

            if (!Game.ClientType.ToString().StartsWith("Vietnam") && 
                Game.ClientType != GameClientType.Chinese)
                spawnedPlayerStall.Name = packet.ReadUnicode();
            else
                spawnedPlayerStall.Name = packet.ReadString();

            spawnedPlayerStall.DecorationId = packet.ReadUInt();

            return spawnedPlayerStall;
        }
    }
}