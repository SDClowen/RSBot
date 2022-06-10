using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;
using System.Linq;

namespace RSBot.Default.Bundle.Movement
{
    internal class MovementBundle : IBundle
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public MovementConfig Config { get; set; }

        /// <summary>
        /// The random
        /// </summary>
        private Random _random;

        /// <summary>
        /// Gets or sets a value indicating whether [last entity was behind obstacle].
        /// Used to move around even though the player is being attacked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [last entity was behind obstacle]; otherwise, <c>false</c>.
        /// </value>
        public bool LastEntityWasBehindObstacle { get; set; }

        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            if (Game.SelectedEntity != null && !LastEntityWasBehindObstacle)
                return;

            var playerUnderAttack = SpawnManager.Any<SpawnedMonster>(m => m.AttackingPlayer &&
               m.Movement.Source.DistanceTo(Container.Bot.Area.CenterPosition) < Container.Bot.Area.Radius);
            if (playerUnderAttack && !LastEntityWasBehindObstacle)
                return;

            if (Game.Player.Movement.Moving)
                return;

            var distance = Game.Player.Movement.Source.DistanceTo(Container.Bot.Area.CenterPosition);
            var hasCollision = CollisionManager.HasCollisionBetween(Game.Player.Movement.Source, Container.Bot.Area.CenterPosition);

            //Go back if the player is out of the radius
            if ((distance > Container.Bot.Area.Radius || (Config.WalkToCenter && distance > 10)) && !hasCollision)
                Game.Player.MoveTo(Container.Bot.Area.CenterPosition);

            if (!Config.WalkAround)
                return;

            var randomRadius = Container.Bot.Area.Radius;
            if (randomRadius > 100)
                randomRadius = 100;

            RunInWorld(randomRadius);
        }

        private void RunInWorld(int randomRadius)
        {
            var destination = Container.Bot.Area.CenterPosition;
            destination.XCoordinate += _random.Next(-randomRadius, randomRadius);
            destination.YCoordinate += _random.Next(-randomRadius, randomRadius);
            if (!CollisionManager.HasCollisionBetween(Game.Player.Movement.Source, destination))
                Game.Player.MoveTo(destination, false);
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            Config = new MovementConfig
            {
                WalkAround = PlayerConfig.Get<bool>("RSBot.Area.WalkAround"),
                WalkToCenter = PlayerConfig.Get<bool>("RSBot.Area.GoToCenter", true)
            };

            _random = new Random();
        }

        public void Stop()
        {
            LastEntityWasBehindObstacle = false;
        }
    }
}