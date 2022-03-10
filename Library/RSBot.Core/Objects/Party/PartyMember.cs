﻿using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects.Party
{
    public class PartyMember
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public uint MemberId;

        /// <summary>
        /// Get the party member spawned info
        /// </summary>
        public SpawnedPlayer Player => SpawnManager.GetEntity<SpawnedPlayer>(p => p.Name == Name);

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name;

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefObjChar Record => Game.ReferenceManager.GetRefObjChar(ObjectId);

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public byte Level;

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Position Position;

        /// <summary>
        /// Gets or sets the guild.
        /// </summary>
        /// <value>
        /// The guild.
        /// </value>
        public string Guild;

        /// <summary>
        /// Gets or sets the mastery id1.
        /// </summary>
        /// <value>
        /// The mastery id1.
        /// </value>
        public uint MasteryId1;

        /// <summary>
        /// Gets or sets the mastery id2.
        /// </summary>
        /// <value>
        /// The mastery id2.
        /// </value>
        public uint MasteryId2;

        /// <summary>
        /// Gets or sets the world identifier.
        /// </summary>
        /// <value>
        /// The world identifier.
        /// </value>
        public short WorldId;

        /// <summary>
        /// Gets or sets the layer identifier.
        /// </summary>
        /// <value>
        /// The layer identifier.
        /// </value>
        public short LayerId;

        /// <summary>
        /// Gets or sets the health mana.
        /// </summary>
        /// var hpmp = HealthMana.ToString("X2");
        /// int hpPer= Convert.ToByte(hpmp[0].ToString(), 16) * 10;
        /// int mpPer= Convert.ToByte(hpmp[1].ToString(), 16) * 10;
        /// <value>
        /// The health mana.
        /// </value>
        public byte HealthMana;

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static PartyMember FromPacket(Packet packet)
        {
            var result = new PartyMember();

            packet.ReadByte(); //FF
            result.MemberId = packet.ReadUInt();

            result.Name = packet.ReadString();
            result.ObjectId = packet.ReadUInt();
            result.Level = packet.ReadByte();

            result.HealthMana = packet.ReadByte(); //0-A|0-A -> 0%-100%|0%-100%

            result.Position = new Position
            {
                XSector = packet.ReadByte(),
                YSector = packet.ReadByte()
            };
            if (!result.Position.IsInDungeon)
            {
                result.Position.XOffset = packet.ReadShort();
                result.Position.ZOffset = packet.ReadShort();
                result.Position.YOffset = packet.ReadShort();
            }
            else
            {
                result.Position.XOffset = packet.ReadInt();
                result.Position.ZOffset = packet.ReadInt();
                result.Position.YOffset = packet.ReadInt();
            }
            result.WorldId = packet.ReadShort();
            result.LayerId = packet.ReadShort();

            result.Guild = packet.ReadString();

            packet.ReadByte(); //04

            result.MasteryId1 = packet.ReadUInt();
            result.MasteryId2 = packet.ReadUInt();
            return result;
        }

        /// <summary>
        /// Bans this player from the party.
        /// </summary>
        public void Banish()
        {
            if (!Game.Party.IsLeader) return;

            var packet = new Packet(0x7063);
            packet.WriteUInt(MemberId);
            packet.Lock();

            PacketManager.SendPacket(packet, PacketDestination.Server);
        }
    }
}