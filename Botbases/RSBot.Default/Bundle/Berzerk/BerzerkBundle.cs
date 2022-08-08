using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Default.Bundle.Berzerk
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
            if (!Game.Player.CanEnterBerzerk || Game.Player.HasActiveVehicle) 
                return;

            if (Config.WhenFull)
            {
                Game.Player.EnterBerzerkMode();
                return;
            }

            if (Config.SurroundedByMonsters)
            {
                var mobAmount = SpawnManager.Count<SpawnedMonster>(m => m.AttackingPlayer && m.DistanceToPlayer < 20);
                if (mobAmount >= Config.SurroundingMonsterAmount)
                {
                    Game.Player.EnterBerzerkMode();
                    return;
                }
            }

            if (!Config.BeeingAttackedByAwareMonster) 
                return;

            var entity = Game.SelectedEntity as SpawnedMonster;
            if (entity == null)
                return;

            if(Bundles.Avoidance.AvoidMonster(entity.Rarity))
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

        public void Stop()
        {
            //Nothing to do
        }
    }
}