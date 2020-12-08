using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;
using System.Collections.Generic;

namespace RSBot.Core.Objects
{
    public class Entity
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public uint UniqueId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has health.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has health; otherwise, <c>false</c>.
        /// </value>
        public bool HasHealth => Health > 0;

        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        /// <value>
        /// The health.
        /// </value>
        public uint Health { get; set; }

        /// <summary>
        /// Gets the maximum health.
        /// </summary>
        /// <value>
        /// The maximum health.
        /// </value>
        public uint MaxHealth
        {
            get
            {
                if (Monster == null)
                    return 0;

                if (Bionic == null)
                    return 0;

                var baseHealth = (uint)Bionic.Record.MaxHealth;
                switch (Monster.Rarity)
                {
                    case MonsterRarity.Champion:
                        return baseHealth * 2;

                    case MonsterRarity.ChampionParty:
                        return baseHealth * 20;

                    case MonsterRarity.GeneralParty:
                        return baseHealth * 10;

                    case MonsterRarity.Elite:
                        return baseHealth * 30;

                    case MonsterRarity.EliteParty:
                        return baseHealth * 300;

                    case MonsterRarity.Giant:
                        return baseHealth * 20;

                    case MonsterRarity.GiantParty:
                        return baseHealth * 200;

                    default:
                        return baseHealth;
                }
            }
        }

        /// <summary>
        /// Gets or sets the bionic.
        /// </summary>
        /// <value>
        /// The bionic.
        /// </value>
        public SpawnedBionic Bionic => Game.Spawns.GetBionic(UniqueId);

        /// <summary>
        /// Gets or sets the talk options.
        /// </summary>
        /// <value>
        /// The talk options.
        /// </value>
        public byte[] TalkOptions { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is a portal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is gate; otherwise, <c>false</c>.
        /// </value>
        public bool IsPortal => Bionic == null && TeleportLinks != null;

        /// <summary>
        /// Gets or sets the teleport links.
        /// </summary>
        /// <value>
        /// The teleport links.
        /// </value>
        public List<RefTeleportLink> TeleportLinks { get; set; }

        /// <summary>
        /// Gets the monster.
        /// </summary>
        /// <value>
        /// The monster.
        /// </value>
        public SpawnedMonster Monster => Game.Spawns.GetMonster(UniqueId);

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        public SpawnedPlayer Player => Game.Spawns.GetPlayer(UniqueId);

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        internal static Entity FromPacket(Packet packet)
        {
            var result = new Entity
            {
                UniqueId = packet.ReadUInt()
            };

            #region Portal

            if (result.Bionic == null) //Only gates have no bionic record
            {
                //GATE
                var portal = Game.Spawns.GetPortal(result.UniqueId);
                if (portal == null) return null; //could be an item either but that's invalid anyway^^

                result.TeleportLinks = portal.GetLinks();

                //STORE_
                result.TalkOptions = packet.ReadByteArray(packet.ReadByte());
                return result;
            }

            #endregion Portal

            #region Monster

            if (result.Bionic.Record.TypeID2 == 2 && result.Bionic.Record.TypeID3 == 1)
            {
                var hasHealth = packet.ReadBool();
                if (hasHealth)
                    result.Health = packet.ReadUInt();

                result.TalkOptions = packet.ReadByteArray(packet.ReadByte());
                return result;
            }

            #endregion Monster

            #region NPC

            if (result.Bionic.Record.TypeID2 == 2 && result.Bionic.Record.TypeID3 == 2)
            {
                var hasHealth = packet.ReadBool();
                if (hasHealth)
                    result.Health = packet.ReadUInt();

                result.TalkOptions = packet.ReadByteArray(packet.ReadByte());
                packet.ReadByte(); //CTF NPC
                return result;
            }

            #endregion NPC

            #region Player

            if (result.Bionic.Record.TypeID2 == 1)
                result.TalkOptions = packet.ReadByteArray(packet.ReadByte());

            #endregion Player

            #region Cos

            if (result.Bionic.Record.TypeID2 == 2 && result.Bionic.Record.TypeID3 == 3)
                return result;

            #endregion Cos

            return result;
        }
    }
}