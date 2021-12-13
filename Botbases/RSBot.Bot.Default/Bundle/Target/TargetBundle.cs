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
            if (Game.SelectedEntity != null)
                return;

            /*var entity = Game.SelectedEntity.Entity;
            if (entity.State.LifeState == LifeState.Alive && !entity.IsBehindObstacle)
                return;
            */
            var monster = GetNearestEnemy();
            if (monster == null)
                return;

            //Check if the monster is still inside our range
            var distanceToCenter = monster.Tracker.Position.DistanceTo(Container.Bot.Area.CenterPosition);

            const int tolarance = 10;
            if (distanceToCenter > Container.Bot.Area.Radius + tolarance)
                return;

            //Move closer to the monster
            var distanceToPlayer = monster.Tracker.Position.DistanceTo(Game.Player.Tracker.Position);
            if (distanceToPlayer >= 80)
                Game.Player.Move(monster.Tracker.Position/*.BehindTo(monster.Character.Bionic.Tracker.Position, 20)*/);

            if (!Game.Player.SelectEntity(monster.UniqueId))
                Invoke();
        }

        /// <summary>
        /// Gets the nearest enemy.
        /// </summary>
        /// <returns></returns>
        private SpawnedMonster GetNearestEnemy()
        {
            if (!SpawnManager.TryGetEntities<SpawnedMonster>(out var entities, m => m.State.LifeState != LifeState.Dead &&
                            m.IsBehindObstacle == false &&
                            !Bundles.Avoidance.AvoidMonster(m.Rarity)))
                    return default(SpawnedMonster);

            return entities.OrderBy(m => m.Tracker?.Position.DistanceTo(Container.Bot.Area.CenterPosition))
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