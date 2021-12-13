using RSBot.Core.Components;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public uint UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the model identifier.
        /// </summary>
        /// <value>
        /// The model identifier.
        /// </value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the tracker.
        /// </summary>
        /// <value>
        /// The tracker.
        /// </value>
        public PositionTracker Tracker;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is behind obstacle.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is behind obstacle; otherwise, <c>false</c>.
        /// </value>
        public bool IsBehindObstacle => Tracker != null && CollisionManager.HasCollisionBetween(Tracker.Position, Game.Player.Tracker.Position);

        /// <summary>
        /// Update the instance
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return false;
        }

        /// <summary>
        /// Dispose the instance
        /// </summary>
        public virtual bool Dispose()
        {
            // TODO:!!!!!!
            return true;
        }
    }
}
