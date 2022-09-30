using RSBot.Core.Objects;

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
}