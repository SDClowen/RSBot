using System.Numerics;
using RSBot.NavMeshApi.Extensions;

namespace RSBot.NavMeshApi.Mathematics;

public struct CircleF
{
    public Vector2 Position { get; }
    public float Radius { get; }

    public CircleF(Vector2 position, float radius)
    {
        this.Position = position;
        this.Radius = radius;
    }

    public bool Intersects(LineF line, out Vector2 point)
    {
        var min = line.Min.ToVector2();
        var max = line.Max.ToVector2();
        var intersectionCount = this.FindLineIntersections(
            min,
            max,
            out Vector2 intersection0,
            out Vector2 intersection1
        );
        if (intersectionCount == 1)
        {
            point = intersection0;

            // Make sure the point is on the line segment.
            return line.IsBetween(point);
        }
        else if (intersectionCount == 2)
        {
            // We'll keep the closest intersection to the start of the line.
            var delta0 = (intersection0 - min).LengthSquared();
            var delta1 = (intersection1 - min).LengthSquared();
            if (delta0 < delta1)
                point = intersection0;
            else
                point = intersection1;

            // Make sure the point is on the line segment.
            return line.IsBetween(point);
        }
        else
        {
            point = default;
            return false;
        }
    }

    private int FindLineIntersections(Vector2 v0, Vector2 v1, out Vector2 hit0, out Vector2 hit1)
    {
        // http://csharphelper.com/blog/2014/09/determine-where-a-line-intersects-a-circle-in-c/
        var d = v1 - v0;
        var f = v0 - this.Position;

        var a = Vector2.Dot(d, d);
        var b = 2 * Vector2.Dot(f, d);
        var c = Vector2.Dot(f, f) - (this.Radius * this.Radius);

        var discriminantSquared = (b * b) - (4.0f * a * c);
        if ((a <= float.Epsilon) || discriminantSquared < 0)
        {
            hit0 = default;
            hit1 = default;
            return 0;
        }
        else if (discriminantSquared == 0)
        {
            // One solution.
            var t = -b / (2.0f * a);
            hit0 = v0 + (d * t);
            hit1 = default;
            return 1;
        }
        else
        {
            var discriminant = MathF.Sqrt(discriminantSquared);

            // Two solutions.
            var t0 = (-b + discriminant) / (2.0f * a);
            hit0 = v0 + (d * t0);

            var t1 = (-b - discriminant) / (2.0f * a);
            hit1 = v0 + (d * t1);
            return 2;
        }
    }
}
