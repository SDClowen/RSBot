using System.Numerics;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi.Extensions;

public static class Matrix4x4Extensions
{
    public static Vector3 MultiplyPoint(this Matrix4x4 matrix, Vector3 point)
    {
        return Vector3.Transform(point, matrix);
    }

    public static LineF MultiplyLine(this Matrix4x4 matrix, LineF line)
    {
        var min = Vector3.Transform(line.Min, matrix);
        var max = Vector3.Transform(line.Max, matrix);

        return new LineF(min, max);
    }

    public static TriangleF MultiplyTriangle(this Matrix4x4 matrix, TriangleF triangle)
    {
        var p1 = Vector3.Transform(triangle.P1, matrix);
        var p2 = Vector3.Transform(triangle.P2, matrix);
        var p3 = Vector3.Transform(triangle.P3, matrix);

        return new TriangleF(p1, p2, p3);
    }

    public static RectangleF MultiplyRectangleF(this Matrix4x4 matrix, RectangleF rectangle)
    {
        var min = Vector3.Transform(rectangle.Min.ToVector3(), matrix);
        var max = Vector3.Transform(rectangle.Max.ToVector3(), matrix);

        return new RectangleF(min.ToVector2(), max.ToVector2());
    }
}
