using System.Collections.Generic;
using System.Drawing;

namespace RSBot.Core.Components.Collision
{
    internal class CollisionDetector
    {
        /// <summary>
        /// Determines whether [has collision between] [the specified source and destination].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="obsctacles">The obsctacles.</param>
        /// <returns>
        ///   <c>true</c> if [has collision between] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasCollisionBetween(Point source, Point destination, List<Line> obsctacles)
        {
            var lineTrace = new Line
            {
                Source = source,
                Destination = destination
            };

            foreach (var lineObstacle in obsctacles)
            {
                var intersection = LineIntersection.FindIntersection(lineTrace, lineObstacle);
                if (intersection)
                    return true;
            }

            return false;
        }
    }
}