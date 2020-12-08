using RSBot.Core;
using System.Linq;

namespace RSBot.Bot.Default.Bundle.Berzerk
{
    internal class BerzerkBundle : IBundle
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public BerzerkConfig Config { get; set; }

        /// <summary>
        /// Invokes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Invoke()
        {
            if (!Game.Player.CanEnterBerzerk) return;

            if (Config.WhenFull)
            {
                Game.Player.EnterBerzerkMode();
                return;
            }

            if (Config.SurroundedByMonsters)
            {
                var mobAmount = Game.Spawns.GetMonsters().Count(m => m.Character.Bionic.AttackingPlayer && m.DistanceToPlayer < 20);
                if (mobAmount >= Config.SurroundingMonsterAmount)
                {
                    Game.Player.EnterBerzerkMode();
                    return;
                }
            }

            if (!Config.BeeingAttackedByAwareMonster) return;

            var awareMonsterAttacking = Game.Spawns.GetMonsters().Count(m => m.Character.Bionic.AttackingPlayer && Bundles.Avoidance.AvoidMonster(m.Rarity)) > 0;

            if (awareMonsterAttacking)
                Game.Player.EnterBerzerkMode();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            Config = new BerzerkConfig
            {
                WhenFull = PlayerConfig.Get<bool>("RSBot.Berzerk.WhenFull"),
                BeeingAttackedByAwareMonster = PlayerConfig.Get<bool>("RSBot.Berzerk.MonsterAvoidance"),
                SurroundedByMonsters = PlayerConfig.Get<bool>("RSBot.Berzerk.MonsterAmount"),
                SurroundingMonsterAmount = PlayerConfig.Get<byte>("RSBot.Berzerk.MonsterAmountNumber", 5)
            };
        }
    }
}