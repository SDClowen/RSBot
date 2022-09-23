using RSBot.Core.Objects;

namespace RSBot.Core.Components.Collision.Calculated;

public class CalculatedCollisionLine
{
    public Position Source;
    public Position Destination;

    public CalculatedCollisionLine(Position source, Position destination)
    {
        Source = source;
        Destination = destination;
    }
}