using System.Numerics;
using RSBot.NavMeshApi.Extensions;
using RSBot.NavMeshApi.Helper;

namespace RSBot.NavMeshApi.Mathematics;

public readonly struct LineF
{
    public Vector3 Min { get; }
    public Vector3 Max { get; }

    public Vector3 Length => this.Max - this.Min;
    public Vector3 Center => (this.Min + this.Max) * 0.5f;

    //public Vector2 Normal2D => new Vector2(this.Max.Z - this.Min.Z, this.Min.X - this.Max.X).normalized;
    //public Vector3 Normal => Vector3.Cross(this.Max, this.Min).normalized;

    public LineF(Vector2 min, Vector2 max)
    {
        this.Min = min.ToVector3();
        this.Max = max.ToVector3();
    }

    public LineF(Vector3 min, Vector3 max)
    {
        this.Min = min;
        this.Max = max;
    }

    public bool IsBetween(Vector2 point)
    {
        // https://stackoverflow.com/questions/328107/how-can-you-determine-a-point-is-between-two-other-points-on-a-line-segment
        var cross =
            ((this.Max.Z - this.Min.Z) * (point.X - this.Min.X)) - ((this.Max.X - this.Min.X) * (point.Y - this.Min.Z));

        if (MathF.Abs(cross).IsApproximatelyZero())
            return false;

        var dot =
            ((this.Max.X - this.Min.X) * (point.X - this.Min.X)) + ((this.Max.Z - this.Min.Z) * (point.Y - this.Min.Z));
        if (dot < 0)
            return false;

        return dot > (point - this.Min.ToVector2()).LengthSquared();
    }

    public bool Intersects(LineF other, out Vector3 point)
    {
        //http://thirdpartyninjas.com/blog/2008/10/07/line-segment-intersection/
        float denominator =
            ((other.Max.Z - other.Min.Z) * (this.Max.X - this.Min.X))
            - ((other.Max.X - other.Min.X) * (this.Max.Z - this.Min.Z));

        if (denominator != 0)
        {
            float u_a =
                (
                    ((other.Max.X - other.Min.X) * (this.Min.Z - other.Min.Z))
                    - ((other.Max.Z - other.Min.Z) * (this.Min.X - other.Min.X))
                ) / denominator;
            float u_b =
                (
                    ((this.Max.X - this.Min.X) * (this.Min.Z - other.Min.Z))
                    - ((this.Max.Z - this.Min.Z) * (this.Min.X - other.Min.X))
                ) / denominator;

            //if (u_a > 0f && u_a < 1f && u_b > 0f && u_b < 1f) //
            if (u_a >= 0f && u_a <= 1f && u_b >= 0f && u_b <= 1f)
            {
                point = (this.Min + (u_a * this.Length));
                return true;
            }
        }

        point = Vector3.Zero;
        return false;
    }

    public CardinalDirection GetDirection()
    {
        var forward = this.Max - this.Min;
        var yaw = MathF.Atan2(forward.Z, forward.X) * MathHelper.Rad2Deg;
        return NavMeshHelper.ToDirection(yaw >= 0.0f ? yaw : yaw + 360.0f);
    }

    public bool IsWithinRadius(LineF other, float radius = 5.0f)
    {
        return (Vector3.Distance(this.Min, other.Min) < radius && Vector3.Distance(this.Max, other.Max) < radius)
            || (Vector3.Distance(this.Max, other.Min) < radius && Vector3.Distance(this.Min, other.Max) < radius);
    }
}
//public readonly struct Line2
//{
//    public Vector2 Min { get; }
//    public Vector2 Max { get; }

//    public Vector2 Length => this.Max - this.Min;
//    public Vector2 Center => (this.Min + this.Max) * 0.5f;

//    public Vector2 Normal => new Vector2(this.Max.Y - this.Min.Y, this.Min.X - this.Max.X).normalized;

//    public Line2(Vector2 min, Vector2 max)
//    {
//        this.Min = min;
//        this.Max = max;
//    }

//    public Line2(Vector3 min, Vector3 max)
//    {
//        this.Min = min.Flatten();
//        this.Max = max.Flatten();
//    }

//    public CardinalDirection GetDirection()
//    {
//        var forward = this.Length;
//        var yaw = MathF.Atan2(forward.Y, forward.X) * MathF.Rad2Deg;
//        return NavMeshHelper.ToDirection(yaw >= 0.0f ? yaw : yaw + 360.0f);
//    }

//    public bool IsWithinRadius(Line2 other, float radius = 5.0f)
//    {
//        return (Vector2.Distance(this.Min, other.Min) < radius && Vector2.Distance(this.Max, other.Max) < radius)
//            || (Vector2.Distance(this.Max, other.Min) < radius && Vector2.Distance(this.Min, other.Max) < radius);
//    }

//    //http://thirdpartyninjas.com/blog/2008/10/07/line-segment-intersection/
//    public bool Intersects(Line2 other, out Vector2 point)
//    {
//        float denominator = ((other.Max.Y - other.Min.Y) * (this.Max.X - this.Min.X)) - ((other.Max.X - other.Min.X) * (this.Max.Y - this.Min.Y));

//        if (denominator != 0)
//        {
//            float u_a = (((other.Max.X - other.Min.X) * (this.Min.Y - other.Min.Y)) - ((other.Max.Y - other.Min.Y) * (this.Min.X - other.Min.X))) / denominator;
//            float u_b = (((this.Max.X - this.Min.X) * (this.Min.Y - other.Min.Y)) - ((this.Max.Y - this.Min.Y) * (this.Min.X - other.Min.X))) / denominator;

//            //if (u_a > 0f && u_a < 1f && u_b > 0f && u_b < 1f) //
//            if (u_a >= 0f && u_a <= 1f && u_b >= 0f && u_b <= 1f)
//            {
//                point = this.Min + (u_a * this.Length);
//                return true;
//            }
//        }

//        point = default;
//        return false;
//    }

//    public static implicit operator Line3(Line2 line) => new Line3(line.Min.ToVector3(), line.Max.ToVector3());
//}

//public readonly struct Line3
//{
//    public Vector3 Min { get; }
//    public Vector3 Max { get; }

//    public Vector3 Length => this.Max - this.Min;
//    public Vector3 Center => (this.Min + this.Max) * 0.5f;
//    public Vector3 Normal => Vector3.Cross(this.Max, this.Min).normalized;

//    public Line3(Vector3 min, Vector3 max)
//    {
//        this.Min = min;
//        this.Max = max;
//    }

//    public CardinalDirection GetDirection()
//    {
//        var forward = this.Length;
//        var yaw = MathF.Atan2(forward.Z, forward.X) * MathF.Rad2Deg;
//        return NavMeshHelper.ToDirection(yaw >= 0.0f ? yaw : yaw + 360.0f);
//    }

//    public bool IsWithinRadius(Line3 other, float radius = 5.0f)
//    {
//        return (Vector3.Distance(this.Min, other.Min) < radius && Vector3.Distance(this.Max, other.Max) < radius)
//            || (Vector3.Distance(this.Max, other.Min) < radius && Vector3.Distance(this.Min, other.Max) < radius);
//    }

//    //http://thirdpartyninjas.com/blog/2008/10/07/line-segment-intersection/
//    public bool Intersects(Line3 other, out Vector3 point)
//    {
//        float denominator = ((other.Max.Z - other.Min.Z) * (this.Max.X - this.Min.X)) - ((other.Max.X - other.Min.X) * (this.Max.Z - this.Min.Z));

//        if (denominator != 0)
//        {
//            float u_a = (((other.Max.X - other.Min.X) * (this.Min.Z - other.Min.Z)) - ((other.Max.Z - other.Min.Z) * (this.Min.X - other.Min.X))) / denominator;
//            float u_b = (((this.Max.X - this.Min.X) * (this.Min.Z - other.Min.Z)) - ((this.Max.Z - this.Min.Z) * (this.Min.X - other.Min.X))) / denominator;

//            //if (u_a > 0f && u_a < 1f && u_b > 0f && u_b < 1f) //
//            if (u_a >= 0f && u_a <= 1f && u_b >= 0f && u_b <= 1f)
//            {
//                point = this.Min + (u_a * this.Length);
//                return true;
//            }
//        }

//        point = Vector3.zero;
//        return false;
//    }

//    public static explicit operator Line2(Line3 line) => new Line2(line.Min.Flatten(), line.Max.Flatten());
//}
