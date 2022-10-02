using RSBot.Core.Components.Collision.Calculated;
using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Components.Collision;

internal class CollisionCalculator
{
    /// <summary>
    /// Gets the calculated collision between the two positions.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <param name="meshes">The meshes.</param>
    /// <returns></returns>
    public static CollisionResult? GetCalculatedCollisionBetween(Position source,
        Position destination, List<CalculatedCollisionMesh> meshes)
    {
        var sourceLine = new CalculatedCollisionLine(source, destination);

        foreach (var mesh in meshes)
        {
            foreach (var line in mesh.Collisions.Where(x => x.Source.DistanceToPlayer() <= destination.DistanceToPlayer() || x.Destination.DistanceToPlayer() <= destination.DistanceToPlayer()).OrderBy(x => x.Source.DistanceToPlayer()))
            {
                var collision = Intersection.FindIntersection(sourceLine, line, 0.05);

                if (collision.HasValue)
                {
                    return new CollisionResult
                    {
                        CollidedAt = collision.Value.collidedAt,
                        CollidedWith = collision.Value.collidedWith,
                        Source = source,
                        Destination = destination
                    };
                }
            }
        }

        return null;
    }
}