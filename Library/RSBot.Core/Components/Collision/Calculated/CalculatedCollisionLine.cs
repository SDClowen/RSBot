using RSBot.Core.Objects;
using TriangleNet.Geometry;

namespace RSBot.Core.Components.Collision.Calculated;

public struct CalculatedCollisionLine
{
    public Position Source;
    public Position Destination;

    public CalculatedCollisionLine(Position source, Position destination)
    {
        Source = source;
        Destination = destination;
    }

    public Vertex GetSourceVertex()
    {
        return new Vertex(Source.XCoordinate, Source.YCoordinate);
    }
    public Vertex GetDestinationVertex()
    {
        return new Vertex(Destination.XCoordinate, Destination.YCoordinate);
    }
}