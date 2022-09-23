using RSBot.Core.Components.Collision.Calculated;
using RSBot.Core.Objects;

namespace RSBot.Core.Components.Collision;

/// <summary>
/// The result of a collision request
/// </summary>
public struct CollisionResult
{
    /// <summary>
    /// Gets the line the ray collided with
    /// </summary>
    public CalculatedCollisionLine CollidedWith;

    /// <summary>
    /// The collided at position
    /// </summary>
    public Position CollidedAt;

    /// <summary>
    /// The source position from where the check started
    /// </summary>
    public Position Source;

    /// <summary>
    /// The destination of the check
    /// </summary>
    public Position Destination;
}