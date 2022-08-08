using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Default.Bundle.Target
{
    internal class TargetBundle : IBundle
    {
        private class BlacklistTimer : System.Timers.Timer
        {
            public const int Timeout = 5_000;

            public SpawnedBionic Target { get; }

            public BlacklistTimer(SpawnedBionic target)
            {
                Target = target;
                AutoReset = false;
                Interval = Timeout;

                Start();
            }
        }

        #region Fields

        private Dictionary<SpawnedBionic, BlacklistTimer>? _blacklistTimers;

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
            bool warlockModeEnabled = PlayerConfig.Get<bool>("RSBot.Skills.WarlockMode", false);
            if (Game.SelectedEntity != null && Game.SelectedEntity.State.LifeState == LifeState.Alive && !(warlockModeEnabled && Game.SelectedEntity.State.HasTwoDots()))
                return;

            var monster = GetNearestEnemy();
            if (monster == null)
                return;

            //Check if the monster is still inside our range
            var distanceToCenter = monster.Movement.Source.DistanceTo(Container.Bot.Area.CenterPosition);

            const int tolerance = 10;
            if (distanceToCenter > Container.Bot.Area.Radius + tolerance)
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
            var warlockModeEnabled = PlayerConfig.Get<bool>("RSBot.Skills.WarlockMode");
            if (!SpawnManager.TryGetEntities<SpawnedMonster>(out var entities, m => m.State.LifeState == LifeState.Alive &&
                            !(warlockModeEnabled && m.State.HasTwoDots()) &&
                            m.IsBehindObstacle == false &&
                            !_blacklistTimers.ContainsKey(m) &&
                            //!Bundles.Avoidance.AvoidMonster(m.Rarity) &&
                            m.DistanceToPlayer <= 40))
                return default(SpawnedMonster);

            return entities.Where(e => _blacklistTimers.Count(be => be.Key.Id == e.Id) == 0)
                .OrderBy(m => m.Movement.Source.DistanceTo(Container.Bot.Area.CenterPosition))
                .OrderByDescending(m => m.AttackingPlayer)
                .OrderByDescending(m => Bundles.Avoidance.PreferMonster(m.Rarity))
                .FirstOrDefault();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            _blacklistTimers = new Dictionary<SpawnedBionic, BlacklistTimer>(8);
        }

        public void Stop()
        {
            _blacklistTimers = null;
        }

        #endregion Methods

        #region Events

        private void OnTargetBehindObstacle()
        {
            if (Game.SelectedEntity == null)
                return;

            Bundles.Movement.LastEntityWasBehindObstacle = true;

            if (_blacklistTimers == null)
                return;

            //Target already blacklisted?
            if (_blacklistTimers.Count(e => e.Key.UniqueId == Game.SelectedEntity.UniqueId) != 0) return;

            var timer = new BlacklistTimer(Game.SelectedEntity);
            timer.Elapsed += BlacklistTimer_Elapsed;

            _blacklistTimers.Add(Game.SelectedEntity, timer);

            Log.Debug($"Add mob [{Game.SelectedEntity.UniqueId} to blacklist for {BlacklistTimer.Timeout}ms");

            Game.SelectedEntity?.TryDeselect();
            Game.SelectedEntity = null;
        }

        private void BlacklistTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (_blacklistTimers == null)
                return;

            if (sender is not BlacklistTimer timer) return;

            _blacklistTimers.Remove(timer.Target);

            Log.Debug($"Removed mob [{timer.Target.UniqueId} from blacklist");
        }

        #endregion Events
    }
}