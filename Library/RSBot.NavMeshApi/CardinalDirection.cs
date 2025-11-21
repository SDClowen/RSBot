namespace RSBot.NavMeshApi;

[Flags]
public enum CardinalDirection
{
    Invalid = 0,
    North = 1 << 0,
    East = 1 << 1,
    South = 1 << 2,
    West = 1 << 3,
}
