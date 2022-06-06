using RSBot.Core;
using RSBot.Core.Objects;

namespace RSBot.Default.Bundle.Avoidance
{
    internal class AvoidanceBundle : IBundle
    {
        /// <summary>
        /// Gets the avoidance list.
        /// </summary>
        /// <value>
        /// The avoidance list.
        /// </value>
        public string[] AvoidanceList { get; private set; }

        /// <summary>
        /// Gets the preferance list.
        /// </summary>
        /// <value>
        /// The preferance list.
        /// </value>
        public string[] PreferanceList { get; private set; }

        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            AvoidanceList = PlayerConfig.GetArray<string>("RSBot.Avoidance.Avoid");
            PreferanceList = PlayerConfig.GetArray<string>("RSBot.Avoidance.Prefer");
        }

        /// <summary>
        /// Avoids the monster.
        /// </summary>
        /// <param name="rarity">The rarity.</param>
        /// <returns></returns>
        public bool AvoidMonster(MonsterRarity rarity)
        {
            return CheckForRarity(AvoidanceList, rarity);
        }

        /// <summary>
        /// Prefers the monster.
        /// </summary>
        /// <param name="rarity">The rarity.</param>
        /// <returns></returns>
        public bool PreferMonster(MonsterRarity rarity)
        {
            return CheckForRarity(PreferanceList, rarity);
        }

        /// <summary>
        /// Checks for rarity blacklist.
        /// </summary>
        /// <param name="avoidanceList">The avoidance list.</param>
        /// <param name="rarity">The rarity.</param>
        /// <returns></returns>
        public bool CheckForRarity(string[] avoidanceList, MonsterRarity rarity)
        {
            foreach (var item in avoidanceList)
            {
                switch (rarity)
                {
                    case MonsterRarity.Champion:
                        return item == "Champion";

                    case MonsterRarity.ChampionParty:
                        return item == "Champion_Party";

                    case MonsterRarity.General:
                        return item == "General";

                    case MonsterRarity.Unique:
                        return item == "Unique";

                    case MonsterRarity.Giant:
                        return item == "Giant";

                    case MonsterRarity.Titan:
                        return item == "Elite";

                    case MonsterRarity.Elite:
                        return item == "Elite";

                    case MonsterRarity.EliteStrong:
                        return item == "Strong";

                    case MonsterRarity.Unique2:
                        return item == "Unique";

                    case MonsterRarity.GeneralParty:
                        return item == "General_Party";

                    case MonsterRarity.UniqueParty:
                        return item == "Unique";

                    case MonsterRarity.GiantParty:
                        return item == "Giant_Party";

                    case MonsterRarity.TitanParty:
                        return item == "Elite";

                    case MonsterRarity.EliteParty:
                        return item == "Elite";

                    case MonsterRarity.Unique2Party:
                        return item == "Unique";

                    default:
                        return false;
                }
            }

            return false;
        }
    }
}