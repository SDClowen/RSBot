using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System.Linq;

namespace RSBot.Bot.Default.Bundle.Target
{
    internal class TargetBundle : IBundle
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            bool warlockModeEnabled = PlayerConfig.Get<bool>("RSBot.Skills.WarlockMode", false);
            if (Game.SelectedEntity != null && Game.SelectedEntity.State.LifeState == LifeState.Alive && !(warlockModeEnabled && Game.SelectedEntity.State.HasTwoDots()))
                return;

            var monster = GetNearestEnemy();
            if (monster == null)
                return;

            //Check if the monster is still inside our range
            var distanceToCenter = monster.Movement.Source.DistanceTo(Container.Bot.Area.CenterPosition);

            const int tolarance = 10;
            if (distanceToCenter > Container.Bot.Area.Radius + tolarance)
                return;

            //Move closer to the monster
            //var distanceToPlayer = monster.Movement.Source.DistanceTo(Game.Player.Movement.Source);
            //if (distanceToPlayer >= 80)
                //Game.Player.MoveTo(monster.Movement.Source/*.BehindTo(monster.Character.Bionic.Tracker.Position, 20)*/);
            
            monster.TrySelect();
        }

        /// <summary>
        /// Gets the nearest enemy.
        /// </summary>
        /// <returns></returns>
        private SpawnedMonster GetNearestEnemy()
        {
            bool warlockModeEnabled = PlayerConfig.Get<bool>("RSBot.Skills.WarlockMode", false);
            if (!SpawnManager.TryGetEntities<SpawnedMonster>(out var entities, m => m.State.LifeState == LifeState.Alive &&
                            !(warlockModeEnabled && m.State.HasTwoDots()) &&
                            m.IsBehindObstacle == false &&
                            !Bundles.Avoidance.AvoidMonster(m.Rarity) && 
                            m.DistanceToPlayer <= 40))
                    return default(SpawnedMonster);

            return entities.OrderBy(m => m.Movement.Source.DistanceTo(Container.Bot.Area.CenterPosition))
                           .OrderByDescending(m => m.AttackingPlayer)
                           .OrderByDescending(m => Bundles.Avoidance.PreferMonster(m.Rarity))
                           .FirstOrDefault();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            //Nothing to do here
        }
    }
}