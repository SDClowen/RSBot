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

    public CalculatedCollisionLine[] Collisions;

    internal CalculatedCollisionMesh(RSCollisionMesh original)
    {
        RegionId = original.RegionId;

        var collisions = original.Collisions;
        Collisions = new CalculatedCollisionLine[collisions.Length];

        Calculate(collisions);
    }
    
    private void Calculate(IReadOnlyList<RSCollisionLine> collisions)
    {
        for (var iLine = 0; iLine < collisions.Count; iLine++)
        {
            var line = collisions[iLine];

            var posSource = new Position(line.Source.X, line.Source.Y, 0, RegionId);
            var posDestination = new Position(line.Destination.X, line.Destination.Y, 0, RegionId);

            Collisions[iLine] = new CalculatedCollisionLine(posSource, posDestination);
        }
    }
}