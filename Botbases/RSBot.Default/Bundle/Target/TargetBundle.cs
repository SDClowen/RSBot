using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Default.Bundle.Target
{
    internal class TargetBundle : IBundle
    {
        private const int BLACKLIST_TIMEOUT = 5_000;

        #region Fields

        private Dictionary<uint, int> _blacklist;

        #endregion Fields

        #region Constructor

        public TargetBundle()
        {
            SubscribeEvents();
        }

        #endregion Constructor

        #region Methods

        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnTargetBehindObstacle", OnTargetBehindObstacle);
        }

        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            _blacklist?.RemoveAll((uniqueId, tick) =>
            {
                var flag = Kernel.TickCount - tick > BLACKLIST_TIMEOUT;
                if (flag)
                    Log.Debug($"Removed mob [{uniqueId} from blacklist!");

                return flag;
            });

            var attacker = GetFromCurrentAttackers();
            if (attacker != null && Game.SelectedEntity == null)
            {

                Log.Debug("[TargetBundle] Emergency situation: Attacking the weaker mob first!");

                if (attacker.TrySelect())
                    Bundles.Movement.LastEntityWasBehindObstacle = false;

                return;
            }

            if (attacker != null && SpawnManager.TryGetEntity<SpawnedMonster>(Game.SelectedEntity.UniqueId, out var selectedMonster) && (byte)attacker.Rarity < (byte)selectedMonster.Rarity)
            {
                Log.Debug("[TargetBundle] Emergency situation: Found a weaker mob to attack first, switching target!");

                if (attacker.TrySelect())
                    Bundles.Movement.LastEntityWasBehindObstacle = false;

                return;
            }

            var warlockModeEnabled = PlayerConfig.Get<bool>("RSBot.Skills.WarlockMode", false);
            if (warlockModeEnabled && Game.SelectedEntity.State.HasTwoDots())
                return;

            if (Game.SelectedEntity != null && Game.SelectedEntity is not SpawnedMonster)
                Game.SelectedEntity = null;

            if (Game.SelectedEntity?.State.LifeState == LifeState.Alive)
                return;

            var monster = GetNearestEnemy();
            if (monster == null)
                return;

            if (!Container.Bot.Area.IsInSight(monster))
                return;

            if (monster.TrySelect())
                Bundles.Movement.LastEntityWasBehindObstacle = false;
        }

        private SpawnedMonster GetFromCurrentAttackers()
        {
            var attackWeakerFirst = PlayerConfig.Get<bool>("RSBot.Advanced.AttackWeakerMobsFirst");
            if (!attackWeakerFirst || !IsEmergencySituation())
                return null;

            if (!SpawnManager.TryGetEntities<SpawnedMonster>(e => e.AttackingPlayer == true && e.State.LifeState == LifeState.Alive, out var entities))
                return null;

            return entities.OrderBy(e => (byte)e.Rarity)
                        .OrderBy(e => e.Record.Level)
                        .OrderByDescending(e => e.Position.DistanceToPlayer())
                        .FirstOrDefault();
        }

        private bool IsEmergencySituation()
        {
            return SpawnManager.Any<SpawnedMonster>(e => e.AttackingPlayer == true && e.State.LifeState == LifeState.Alive && Bundles.Avoidance.AvoidMonster(e.Rarity));
        }

        /// <summary>
        /// Gets the nearest enemy.
        /// </summary>
        /// <returns></returns>
        private SpawnedMonster GetNearestEnemy()
        {
            var warlockModeEnabled = PlayerConfig.Get<bool>("RSBot.Skills.WarlockMode");
            var ignorePillar = PlayerConfig.Get<bool>("RSBot.Ignores.DimensionPillar");

            if (!SpawnManager.TryGetEntities<SpawnedMonster>(m =>
                    m.State.LifeState == LifeState.Alive &&
                    !(warlockModeEnabled && m.State.HasTwoDots()) &&
                    m.IsBehindObstacle == false &&
                    _blacklist?.ContainsKey(m.UniqueId) == false &&
                    Container.Bot.Area.IsInSight(m) &&
                    !m.Record.IsPandora &&
                    //m.DistanceToPlayer <= 40 &&
                    !(m.Record.IsDimensionPillar && ignorePillar) &&
                    !m.Record.IsSummonFlower, out var entities))
                return default;

            return entities.OrderBy(m => m.Movement.Source.DistanceTo(Container.Bot.Area.Position))
                .OrderBy(m => Bundles.Avoidance.PreferMonster(m.Rarity))
                .OrderByDescending(m => m.AttackingPlayer)
                .FirstOrDefault();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            _blacklist = new(8);
        }

        public void Stop()
        {
            _blacklist = null;
        }

        #endregion Methods

        #region Events

        private void OnTargetBehindObstacle()
        {
            if (Game.SelectedEntity == null)
                return;

            var selectedEntityUniqueId = Game.SelectedEntity.UniqueId;
            Game.SelectedEntity?.TryDeselect();
            Game.SelectedEntity = null;

            Bundles.Movement.LastEntityWasBehindObstacle = true;

            if (_blacklist?.TryAdd(selectedEntityUniqueId, Kernel.TickCount) == true)
                Log.Debug($"Add mob [{selectedEntityUniqueId} to blacklist for {BLACKLIST_TIMEOUT}ms");
        }

        #endregion Events
    }
}