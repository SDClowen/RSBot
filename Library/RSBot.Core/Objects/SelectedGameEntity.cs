using RSBot.Core.Components;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects
{
    public class SelectedGameEntity
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
                if (!(Entity is SpawnedMonster monster))
                    return 0;

                var baseHealth = (uint)monster.Record.MaxHealth;
                switch (monster.Rarity)
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
        /// Gets or sets the talk options.
        /// </summary>
        /// <value>
        /// The talk options.
        /// </value>
        public NpcTalk Talk { get; set; }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        public SpawnedBionic Entity => SpawnManager.TryGetEntity<SpawnedBionic>(UniqueId);

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        internal static SelectedGameEntity FromPacket(Packet packet)
        {
            var result = new SelectedGameEntity
            {
                UniqueId = packet.ReadUInt(),
                Talk = new NpcTalk()
            };

            return result;

            if (result.Entity is SpawnedMonster)
            {
                var hasHealth = packet.ReadBool();
                if (hasHealth)
                    result.Health = packet.ReadUInt();

                result.Talk.Deserialize(packet);
            }
            else if (result.Entity is SpawnedNpcNpc)
            {
                var hasHealth = packet.ReadBool();
                if (hasHealth)
                    result.Health = packet.ReadUInt();

                result.Talk.Deserialize(packet);
                packet.ReadByte(); // ??
            }
            else if (result.Entity is SpawnedPlayer)
            {
                result.Talk.Deserialize(packet);
            }
            else if (result.Entity is SpawnedPortal)
            {
                result.Talk.Deserialize(packet);
            }

            return result;
        }
    }
}