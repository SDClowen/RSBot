using System.Numerics;

namespace RSBot.NavMeshApi.Extensions;

public static class VectorExtensions
{
    public static Vector3 ToVector3(this Vector2 v) => new Vector3(v.X, 0, v.Y);

    public static Vector2 ToVector2(this Vector3 v) => new Vector2(v.X, v.Z);

    public static Vector3 Flatten(this Vector3 v) => new Vector3(v.X, 0, v.Z);

    public static Vector3 UpdateY(this Vector3 v, float y) => new Vector3(v.X, y, v.Z);
}
