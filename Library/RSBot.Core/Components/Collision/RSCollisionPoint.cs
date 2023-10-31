namespace RSBot.Core.Components.Collision;

/// <summary>
///     Represents a point within an RSCollisionMesh
/// </summary>
internal struct RSCollisionPoint
{
    public short X;
    public short Y;

    public RSCollisionPoint()
    {
        X = 0;
        Y = 0;
    }
}