using RSBot.Core.Objects;
using System.Collections.Generic;
using TriangleNet.Geometry;

namespace RSBot.Core.Components.Collision.Calculated;

public class CalculatedWalkGrid
{
    public CalculatedCollisionObject[] Objects;

    public CalculatedCollisionLine[] Floor;

    public ushort RegionId;

    internal CalculatedWalkGrid(RSCollisionMesh original)
    {
        RegionId = original.RegionId;

        Calculate(original.ObjectCollisions, original.FloorCollisions);
    }

    private void Calculate(IReadOnlyList<RSCollisionObject> objects, IReadOnlyList<RSCollisionLine> floor)
    {
        Objects = new CalculatedCollisionObject[objects.Count];

        for (var iObj = 0; iObj < Objects.Length; iObj++)
        {
            var obj = objects[iObj];

            var entry = new CalculatedCollisionObject
            {
                CollisionLines = new CalculatedCollisionLine[obj.Outlines.Length]
            };

            for (var iLine = 0; iLine < obj.Outlines.Length; iLine++)
            {
                var line = obj.Outlines[iLine];
                var posSource = new Position(line.Source.X, line.Source.Y, 0, RegionId);
                var posDestination = new Position(line.Destination.X, line.Destination.Y, 0, RegionId);

                entry.CollisionLines[iLine] = new CalculatedCollisionLine(posSource, posDestination);
            }

            Objects[iObj] = entry;
        }

        Floor = new CalculatedCollisionLine[floor.Count];

        for (var iLine = 0; iLine < Floor.Length; iLine++)
        {
            var line = floor[iLine];

            var posSource = new Position(line.Source.X, line.Source.Y, 0, RegionId);
            var posDestination = new Position(line.Destination.X, line.Destination.Y, 0, RegionId);

            Floor[iLine] = new CalculatedCollisionLine(posSource, posDestination);
        }
    }
}