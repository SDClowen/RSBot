using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;
using System.Linq;
using RSBot.Core.Event;

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
            {
                EventManager.FireEvent("OnChangeStatusText", "Walking to center");
                Game.Player.MoveTo(Container.Bot.Area.CenterPosition);

                return;
            }

            var randomRadius = Container.Bot.Area.Radius;
            if (randomRadius > 100)
                randomRadius = 100;
            
            EventManager.FireEvent("OnChangeStatusText", "Walking around");

            RunInWorld(randomRadius);
        }

        private void RunInWorld(int randomRadius)
        {
            var destination = GetRandomDestination( Container.Bot.Area.CenterPosition, randomRadius );
            if (!CollisionManager.HasCollisionBetween(Game.Player.Movement.Source, destination))
                Game.Player.MoveTo(destination, false);
        }

        /// <summary>
        /// Thanks to https://gamedev.stackexchange.com/questions/26713/calculate-random-points-pixel-within-a-circle-image
        /// I chose the concentrated to the middle method. Bot should walk rather in the middle then from edge to edge.
        /// </summary>
        private Position GetRandomDestination( Position centerPosition, int radius) {
            var angle = _random.NextDouble() * Math.PI * 2;
            var randomRadius = _random.NextDouble() * radius;
            var x = centerPosition.XCoordinate + randomRadius * Math.Cos( angle );
            var y = centerPosition.YCoordinate + randomRadius * Math.Sin( angle );
            var destination = new Position( (float)x, (float)y, centerPosition.RegionID );
            return destination;
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