using RSBot.Core.Objects;
using System.Collections.Generic;

namespace RSBot.Core.Components.Collision.Calculated;

/// <summary>
/// Represents the calculated version of the collision mesh.
/// Calculated means, that it positions are mapped to the in game world.
/// </summary>
public class CalculatedCollisionMesh
{
    public ushort RegionId;

    public List<CalculatedCollisionLine> Collisions;

    public CalculatedCollisionMesh(List<CalculatedCollisionLine> collisions)
    {
        Collisions = collisions;
    }

    internal CalculatedCollisionMesh(RSCollisionMesh original)
    {
        RegionId = original.RegionId;
        Collisions = new List<CalculatedCollisionLine>(original.CollisionLines.Length);

        Calculate(original);
    }

    private void Calculate(RSCollisionMesh original)
    {
        foreach (var line in original.CollisionLines)
        {
            var posSource = new Position(line.Source.X, line.Source.Y, 0, original.RegionId);
            var posDestination = new Position(line.Destination.X, line.Destination.Y, 0, original.RegionId);

            Collisions.Add(new CalculatedCollisionLine(posSource, posDestination));
        }
    }
}