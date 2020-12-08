using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using System;
using System.Linq;

namespace RSBot.Bot.Default.Bundle.Movement
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
        /// Invokes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Invoke()
        {
            if (Game.SelectedEntity != null && (Game.SelectedEntity.Monster != null || Game.SelectedEntity.Player != null)) return;
            var playerUnderAttack = Game.Spawns.GetMonsters().Where(m => m.Character.Bionic.AttackingPlayer).ToArray()?.Length > 0;

            if (playerUnderAttack) return;

            //Go back if the player is out of the radius
            if (Game.Player.Tracker.Position.DistanceTo(Container.Bot.Area.CenterPosition) > Container.Bot.Area.Radius &&
                !CollisionManager.HasCollisionBetween(Game.Player.Tracker.Position, Container.Bot.Area.CenterPosition))
                Game.Player.Move(Container.Bot.Area.CenterPosition);

            if (!Config.WalkAround || Game.Player.Tracker.MovementState != MovementState.Standing) return;

            var randomRadius = Container.Bot.Area.Radius;
            if (randomRadius > 50)
                randomRadius = 50;

            RunInWorld(randomRadius);
        }

        private void RunInWorld(int randomRadius)
        {
            var destination = Container.Bot.Area.CenterPosition;
            destination.XCoordinate += _random.Next(-randomRadius, randomRadius);
            destination.YCoordinate += _random.Next(-randomRadius, randomRadius);
            if (!CollisionManager.HasCollisionBetween(Game.Player.Tracker.Position, destination))
                Game.Player.Move(destination, false);
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
    }
}