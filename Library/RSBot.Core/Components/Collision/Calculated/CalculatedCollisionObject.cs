using System.Collections.Generic;
using TriangleNet.Geometry;

namespace RSBot.Core.Components.Collision.Calculated;

public struct CalculatedCollisionObject
{
    public CalculatedCollisionLine[] CollisionLines;

    public IEnumerable<Vertex> GetOutlineVertices()
    {
        var result = new List<Vertex>();

        foreach (var line in CollisionLines)
        {
            result.Add(new Vertex(line.Source.XCoordinate, line.Source.YCoordinate));
            //result.Add(new Vertex(line.Destination.XCoordinate, line.Destination.YCoordinate));
        }

        return result;
    }

    public IEnumerable<ISegment> GetSegments()
    {
        var result = new List<Segment>();

        foreach (var line in CollisionLines)
        {
            result.Add(new Segment(line.GetSourceVertex(), line.GetDestinationVertex()));
        }

        return result;
    }
}