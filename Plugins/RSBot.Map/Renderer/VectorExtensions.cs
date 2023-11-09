using System.Drawing;
using System.Numerics;

namespace RSBot.Map.Renderer;

public static class VectorExtensions
{
    public static PointF ToPointF(this Vector2 value) => new PointF(value.X, value.Y);

    public static PointF ToPointF(this Vector3 value) => new PointF(value.X, value.Z);
}
