using System.Numerics;
using RSBot.NavMeshApi.Extensions;

namespace RSBot.NavMeshApi.Mathematics;

public struct RectangleF
{
    #region Fields

    private Vector2 _min;
    private Vector2 _max;

    #endregion Fields

    #region Properties

    public Vector2 Min => _min;
    public Vector2 Max => _max;

    public float X => _min.X;
    public float Y => _min.Y;
    public float Width => _max.X - _min.X;
    public float Height => _max.Y - _min.Y;
    public Vector2 Center => (_min + _max) * 0.5f;
    public Vector2 Size => new Vector2(this.Width, this.Height);

    public Vector2 BottomLeft => new Vector2(_min.X, _min.Y);

    public Vector2 TopLeft => new Vector2(_min.X, _max.Y);
    public Vector2 BottomRight => new Vector2(_max.X, _min.Y);
    public Vector2 TopRight => new Vector2(_max.X, _max.Y);

    public LineF Left => new LineF(this.BottomLeft, this.TopLeft);
    public LineF Bottom => new LineF(this.BottomLeft, this.BottomRight);
    public LineF Right => new LineF(this.BottomRight, this.TopRight);
    public LineF Top => new LineF(this.TopLeft, this.TopRight);

    #endregion Properties

    public RectangleF(Vector2 min, Vector2 max)
    {
        _min = min;
        _max = max;
    }

    public RectangleF(float x, float y, float width, float height)
    {
        _min = new Vector2(x, y);
        _max = new Vector2(x + width, y + height);
    }

    public bool Contains(Vector2 p) => this.Contains(p.X, p.Y);

    public bool Contains(Vector3 p) => this.Contains(p.X, p.Z);

    public bool Contains(float x, float y)
    {
        return x >= _min.X && x <= _max.X && y >= _min.Y && y <= _max.Y;
    }

    public bool Intersects(LineF line)
    {
        // Check if any point of the line is inside the rectangle
        if (this.Contains(line.Min) || this.Contains(line.Max))
            return true;

        // Check if any rectangle edge is intersecting with the line
        return line.Intersects(this.Left, out Vector3 _)
            || line.Intersects(this.Top, out Vector3 _)
            || line.Intersects(this.Right, out Vector3 _)
            || line.Intersects(this.Bottom, out Vector3 _);
    }

    public bool Intersects(TriangleF triangle)
    {
        // TODO: Find a faster approach as this does way too many line intersection tests.

        // Check if any triangle vertex is inside the rectangle (rectangle contains triangle)
        if (this.Contains(triangle.P1) || this.Contains(triangle.P2) || this.Contains(triangle.P3))
            return true;

        // Check if any rectangle vertex is inside the triangle (triangle contains rectangle)
        if (
            triangle.Contains(this.BottomLeft)
            || triangle.Contains(this.TopLeft)
            || triangle.Contains(this.BottomRight)
            || triangle.Contains(this.TopRight)
        )
            return true;

        // Check if any triangle edge intersects with any rectangle edge
        return this.Intersects(triangle.Edge1) || this.Intersects(triangle.Edge2) || this.Intersects(triangle.Edge3);
    }

    public bool Intersects(RectangleF rect)
    {
        if (rect.X < this.X + this.Width && this.X < rect.X + rect.Width && rect.Y < this.Y + this.Height)
            return this.Y < rect.Y + rect.Height;
        else
            return false;
    }

    public void MoveTowardsCenter(ref Vector3 vPos)
    {
        const float TOLERANCE = 0.199999988079071f;

        var delta = this.Center - vPos.ToVector2();
        if (delta.LengthSquared() > TOLERANCE)
        {
            delta = Vector2.Normalize(delta);
            delta *= TOLERANCE;
        }
        vPos.X += delta.X;
        vPos.Z += delta.Y;
    }

    public Vector3 MoveTowardsCenter(Vector3 vPos)
    {
        this.MoveTowardsCenter(ref vPos);
        return vPos;
    }

    #region Operators

    public static RectangleF operator +(RectangleF left, RectangleF right) =>
        new RectangleF(left._min + right._min, left._max + right._max);

    public static RectangleF operator -(RectangleF left, RectangleF right) =>
        new RectangleF(left._min - right._min, left._max - right._max);

    public static RectangleF operator *(RectangleF left, RectangleF right) =>
        new RectangleF(left._min * right._min, left._max * right._max);

    public static RectangleF operator /(RectangleF left, RectangleF right) =>
        new RectangleF(left._min / right._min, left._max / right._max);

    #endregion Operators
}
