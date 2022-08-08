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
        public MonsterRarity[] AvoidanceList { get; private set; }

        /// <summary>
        /// Gets the preferance list.
        /// </summary>
        /// <value>
        /// The preferance list.
        /// </value>
        public MonsterRarity[] PreferanceList { get; private set; }

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
            AvoidanceList = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Avoid");
            PreferanceList = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Prefer");
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
        public bool CheckForRarity(MonsterRarity[] avoidanceList, MonsterRarity rarity)
        {
            foreach (var item in avoidanceList)
                if ((item & rarity) == rarity)
                    return true;

            return false;
        }

        public void Stop()
        {
            //Nothing to do
        }
    }
}