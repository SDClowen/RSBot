using System.Numerics;
using RSBot.NavMeshApi.Extensions;

namespace RSBot.NavMeshApi.Mathematics;

public struct TriangleF
{
    private Vector3 _p1;
    private Vector3 _p2;
    private Vector3 _p3;

    public Vector3 P1 => _p1;
    public Vector3 P2 => _p2;
    public Vector3 P3 => _p3;

    public Vector3 Center => (_p1 + _p2 + _p3) / 3.0f;

    public LineF Edge1 => new LineF(_p1, _p2);
    public LineF Edge2 => new LineF(_p1, _p3);
    public LineF Edge3 => new LineF(_p2, _p3);

    public TriangleF(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        _p1 = p1;
        _p2 = p2;
        _p3 = p3;
    }

    //https://math.stackexchange.com/questions/1324179/how-to-tell-if-3-connected-points-are-connected-clockwise-or-counter-clockwise
    //https://en.wikipedia.org/wiki/Curve_orientation
    public bool IsClockwise =>
        (_p1.X * _p2.Z) + (_p3.X * _p1.Z) + (_p2.X * _p3.Z) - (_p1.X * _p3.Z) - (_p3.X * _p2.Z) - (_p2.X * _p1.Z)
        > 0.0f;

    public bool FindHeight(ref Vector3 vPos)
    {
        //From http://totologic.blogspot.se/2014/01/accurate-point-in-triangle-test.html

        //Based on Barycentric coordinates
        float denominator = ((_p2.Z - _p3.Z) * (_p1.X - _p3.X)) + ((_p3.X - _p2.X) * (_p1.Z - _p3.Z));

        float a = (((_p2.Z - _p3.Z) * (vPos.X - _p3.X)) + ((_p3.X - _p2.X) * (vPos.Z - _p3.Z))) / denominator;
        float b = (((_p3.Z - _p1.Z) * (vPos.X - _p3.X)) + ((_p1.X - _p3.X) * (vPos.Z - _p3.Z))) / denominator;
        float c = 1 - a - b;

        vPos.Y = ((a * _p1.Y) + (b * _p2.Y) + (c * _p3.Y)) / (a + b + c);
        //return a > 0f && a < 1f && b > 0f && b < 1f && c > 0f && c < 1f; // point is within the triangle
        return a >= 0f && a <= 1f && b >= 0f && b <= 1f && c >= 0f && c <= 1f; // point can be on border
    }

    public bool Contains(Vector3 vPos)
    {
        //From http://totologic.blogspot.se/2014/01/accurate-point-in-triangle-test.html

        //Based on Barycentric coordinates
        float denominator = ((_p2.Z - _p3.Z) * (_p1.X - _p3.X)) + ((_p3.X - _p2.X) * (_p1.Z - _p3.Z));

        float a = (((_p2.Z - _p3.Z) * (vPos.X - _p3.X)) + ((_p3.X - _p2.X) * (vPos.Z - _p3.Z))) / denominator;
        float b = (((_p3.Z - _p1.Z) * (vPos.X - _p3.X)) + ((_p1.X - _p3.X) * (vPos.Z - _p3.Z))) / denominator;
        float c = 1 - a - b;

        //return a > 0f && a < 1f && b > 0f && b < 1f && c > 0f && c < 1f; // point is within the triangle
        return a >= 0f && a <= 1f && b >= 0f && b <= 1f && c >= 0f && c <= 1f; // point can be on border
    }

    public bool Contains(Vector2 vPos)
    {
        //From http://totologic.blogspot.se/2014/01/accurate-point-in-triangle-test.html

        //Based on Barycentric coordinates
        float denominator = ((_p2.Z - _p3.Z) * (_p1.X - _p3.X)) + ((_p3.X - _p2.X) * (_p1.Z - _p3.Z));

        float a = (((_p2.Z - _p3.Z) * (vPos.X - _p3.X)) + ((_p3.X - _p2.X) * (vPos.Y - _p3.Z))) / denominator;
        float b = (((_p3.Z - _p1.Z) * (vPos.X - _p3.X)) + ((_p1.X - _p3.X) * (vPos.Y - _p3.Z))) / denominator;
        float c = 1 - a - b;

        //return a > 0f && a < 1f && b > 0f && b < 1f && c > 0f && c < 1f; // point is within the triangle
        return a >= 0f && a <= 1f && b >= 0f && b <= 1f && c >= 0f && c <= 1f; // point can be on border
    }

    public void MoveTowardsCenter(ref Vector3 vPos)
    {
        const float TOLERANCE = 0.199999988079071f;

        var delta = this.Center.ToVector2() - vPos.ToVector2();
        if (delta.LengthSquared() > TOLERANCE)
        {
            delta = Vector2.Normalize(delta);
            delta *= TOLERANCE;
        }
        vPos.X += delta.X;
        vPos.Z += delta.Y;
    }

    public RectangleF GetAABB()
    {
        var min = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        var max = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        min.X = MathF.Min(this.P1.X, min.X);
        min.Y = MathF.Min(this.P1.Z, min.Y);
        max.X = MathF.Max(this.P1.X, max.X);
        max.Y = MathF.Max(this.P1.Z, max.Y);

        min.X = MathF.Min(this.P2.X, min.X);
        min.Y = MathF.Min(this.P2.Z, min.Y);
        max.X = MathF.Max(this.P2.X, max.X);
        max.Y = MathF.Max(this.P2.Z, max.Y);

        min.X = MathF.Min(this.P3.X, min.X);
        min.Y = MathF.Min(this.P3.Z, min.Y);
        max.X = MathF.Max(this.P3.X, max.X);
        max.Y = MathF.Max(this.P3.Z, max.Y);

        return new RectangleF(min, max);
    }
}
