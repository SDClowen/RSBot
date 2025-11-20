using System;
using System.Drawing;
using System.Numerics;
using RSBot.Core.Objects;

namespace RSBot.Core.Extensions;

public static class Geometry
{
    public static Vector2 ToVector2(this Vector3 v)
    {
        return new Vector2(v.X, v.Z);
    }

    public static Vector3 ToVector3(this Vector2 v)
    {
        return new Vector3(v.X, 0f, v.Y); //TO DO: navmesh height for y position
    }

    public static Vector3 ToVector3(this Vector2 v, float y)
    {
        return new Vector3(v.X, y, v.Y);
    }

    public static Vector2 Perpendicular(this Vector2 v)
    {
        return new Vector2(-v.Y, v.X);
    }

    public static Vector2 Rotated(this Vector2 v, float angle)
    {
        var c = Math.Cos(angle);
        var s = Math.Sin(angle);

        return new Vector2((float)(v.X * c - v.Y * s), (float)(v.Y * c + v.X * s));
    }

    public static float CrossProduct(this Vector2 self, Vector2 other)
    {
        return other.Y * self.X - other.X * self.Y;
    }

    public static float RadianToDegree(double angle)
    {
        return (float)(angle * (180.0 / Math.PI));
    }

    public static float DegreeToRadian(double angle)
    {
        return (float)(Math.PI * angle / 180.0);
    }

    public static bool Close(float a, float b, float eps)
    {
        if (Math.Abs(eps) < float.Epsilon)
            eps = (float)1e-9;
        return Math.Abs(a - b) <= eps;
    }

    public static float Polar(this Vector2 v1)
    {
        if (Close(v1.X, 0, 0))
        {
            if (v1.Y > 0)
                return 90;
            return v1.Y < 0 ? 270 : 0;
        }

        var theta = RadianToDegree(Math.Atan(v1.Y / v1.X));
        if (v1.X < 0)
            theta = theta + 180;
        if (theta < 0)
            theta = theta + 360;
        return theta;
    }

    public static float AngleBetween(this Vector2 p1, Vector2 p2)
    {
        var theta = p1.Polar() - p2.Polar();
        if (theta < 0)
            theta = theta + 360;
        if (theta > 180)
            theta = 360 - theta;
        return theta;
    }

    public static Vector2 RotateAroundPoint(this Vector2 rotated, Vector2 around, float angle)
    {
        var sin = Math.Sin(angle);
        var cos = Math.Cos(angle);

        var x = cos * (rotated.X - around.X) - sin * (rotated.Y - around.Y) + around.X;
        var y = sin * (rotated.X - around.X) + cos * (rotated.Y - around.Y) + around.Y;

        return new Vector2((float)x, (float)y);
    }

    public static float Distance(this Vector2 from, Vector2 to, bool squared = false)
    {
        if (squared)
            return Vector2.DistanceSquared(from, to);

        return Vector2.Distance(from, to);
    }

    public static float Distance(this Vector3 from, Vector3 to, bool squared = false)
    {
        if (squared)
            return Vector3.DistanceSquared(from, to);

        return Vector3.Distance(from, to);
    }

    /// <summary>
    ///     Rounds up.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="n">The n.</param>
    /// <returns></returns>
    public static Point RoundUp(this Point point, int n)
    {
        point.X = (int)(Math.Ceiling((decimal)point.X / n) * n);
        point.Y = (int)(Math.Ceiling((decimal)point.Y / n) * n);

        return point;
    }

    /// <summary>
    ///     To the point.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns></returns>
    public static Point ToPoint(this Vector2 vector)
    {
        return new Point { X = Convert.ToInt32(vector.X), Y = Convert.ToInt32(vector.Y) };
    }

    /// <summary>
    ///     Gets the point at.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <param name="distance">The distance.</param>
    /// <returns></returns>
    public static Point GetPointAt(Vector2 a, Vector2 b, int distance)
    {
        var result = distance * Vector2.Normalize(b - a) + a;

        return result.ToPoint();
    }

    /// <summary>
    ///     To the vector2.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <returns></returns>
    public static Vector2 ToVector2(this Position position)
    {
        return new Vector2(position.X, position.Y);
    }
}
