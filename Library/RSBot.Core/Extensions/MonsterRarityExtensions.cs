using RSBot.Core.Objects;

namespace RSBot.Core.Extensions
{
    public static class MonsterRarityExtensions
    {
        public static string GetName(this MonsterRarity rarity)
        {
            switch (rarity)
            {
                case MonsterRarity.General: //regular
                    return "General";

                case MonsterRarity.Champion: //blue
                    return "Champion";

                case MonsterRarity.Unique:
                case MonsterRarity.Unique2:
                    return "Unique";

                case MonsterRarity.Giant:
                    return "Giant";

                case MonsterRarity.Titan:
                    return "Titan";

                case MonsterRarity.Elite:
                    return "Elite";

                case MonsterRarity.EliteStrong:
                    return "Elite (Strong)";

                case MonsterRarity.GeneralParty:
                    return "General (Party)";

                case MonsterRarity.ChampionParty:
                    return "Champion (Party)";

                case MonsterRarity.Unique2Party:
                case MonsterRarity.UniqueParty:
                    return "Unique (Party)";

                case MonsterRarity.GiantParty:
                    return "Giant (Party)";

                case MonsterRarity.TitanParty:
                    return "Titan (Party)";

                case MonsterRarity.EliteParty:
                    return "Elite (Party)";

                default:
                    return "Unknown";
            }
        }
    }
}