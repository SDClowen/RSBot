using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

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

            var playerUnderAttack = SpawnManager.Any<SpawnedMonster>(m => m.AttackingPlayer && Container.Bot.Area.IsInSight(m));
            if (playerUnderAttack && !LastEntityWasBehindObstacle)
                return;

            if (Game.Player.Movement.Moving)
                return;

            var distance = Game.Player.Movement.Source.DistanceTo(Container.Bot.Area.Position);
            var hasCollision = CollisionManager.HasCollisionBetween(Game.Player.Movement.Source, Container.Bot.Area.Position);

            //Go back if the player is out of the radius
            if ((distance > Container.Bot.Area.Radius || (Config.WalkToCenter && distance > 10)) && !hasCollision)
            {
                EventManager.FireEvent("OnChangeStatusText", "Walking to center");
                Game.Player.MoveTo(Container.Bot.Area.Position);

                return;
            }

            if (Config.WalkToCenter)
                return;

            EventManager.FireEvent("OnChangeStatusText", "Walking around");

            //Find a not colliding position. Do it in a while loop to prevent the bot from processing it in the next cycle (tick).
            //This is how we can find our next position very fast instead of waiting for the next circle to come.
            var destination = Container.Bot.Area.GetRandomPosition();

            while (CollisionManager.HasCollisionBetween(Game.Player.Position, destination))
                destination = Container.Bot.Area.GetRandomPosition();

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
        }

        public void Stop()
        {
            LastEntityWasBehindObstacle = false;
        }
    }
}