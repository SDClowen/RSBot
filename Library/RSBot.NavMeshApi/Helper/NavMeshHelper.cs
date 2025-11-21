using System.Numerics;

namespace RSBot.NavMeshApi.Helper;

public static class NavMeshHelper
{
    public static CardinalDirection ToDirection(Vector3 euler)
    {
        const float ZERO_OFFSET = 90; // East is 0° in silkroad

        var direction = CardinalDirection.Invalid;
        var yaw = euler.Y - ZERO_OFFSET;
        if (yaw > 270.0f - ZERO_OFFSET || yaw < 90.0f - ZERO_OFFSET)
            direction |= CardinalDirection.North;

        if (yaw > 0.0f - ZERO_OFFSET && yaw < 180.0f - ZERO_OFFSET)
            direction |= CardinalDirection.East;

        if (yaw > 180.0f - ZERO_OFFSET && yaw < 360.0f - ZERO_OFFSET)
            direction |= CardinalDirection.West;

        if (yaw > 90.0f - ZERO_OFFSET && yaw < 270.0f - ZERO_OFFSET)
            direction |= CardinalDirection.South;

        return direction;
    }

    public static CardinalDirection ToDirection(float yaw)
    {
        var direction = CardinalDirection.Invalid;

        if (yaw > 0.0f && yaw < 180.0f)
            direction |= CardinalDirection.North;

        if (yaw < 90.0f || yaw > 270.0f)
            direction |= CardinalDirection.East;

        if (yaw > 180.0f && yaw < 360.0f)
            direction |= CardinalDirection.South;

        if (yaw > 90.0f && yaw < 270.0f)
            direction |= CardinalDirection.West;

        return direction;
    }
}
