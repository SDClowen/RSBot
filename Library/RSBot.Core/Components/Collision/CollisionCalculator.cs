﻿using RSBot.Core.Components.Collision.Calculated;
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
            foreach (var line in mesh.Collisions.Where(x => x.Source.DistanceToPlayer() < 150).OrderBy(x => x.Source.DistanceToPlayer()))
            {
                var collision = LineIntersection.FindIntersection(sourceLine, line);

                if (collision != null)
                {
                    return new CollisionResult
                    {
                        CollidedAt = collision.Item1,
                        CollidedWith = collision.Item2,
                        Source = source,
                        Destination = destination
                    };
                }
            }
        }

        return null;
    }
}