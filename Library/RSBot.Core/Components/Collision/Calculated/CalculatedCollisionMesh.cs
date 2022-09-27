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

    /// <summary>
    /// Calculates the specified original.
    /// </summary>
    /// <param name="original">The original.</param>
    private void Calculate(RSCollisionMesh original)
    {
        foreach (var line in original.CollisionLines)
        {
            Position posSource = new()
            {
                XOffset = line.Source.X,
                ZOffset = 0,
                YOffset = line.Source.Y,
                RegionId = original.RegionId
            };

            Position posDestination = new()
            {
                XOffset = line.Destination.X,
                ZOffset = 0,
                YOffset = line.Destination.Y,
                RegionId = original.RegionId
            };

            Collisions.Add(new CalculatedCollisionLine(posSource, posDestination));
        }
    }
}