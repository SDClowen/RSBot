using System.Numerics;

namespace RSBot.NavMeshApi.Mathematics;

public readonly struct BoundingBoxF
{
    #region Properties

    public float Width => this.Max.X - this.Min.X;
    public float Height => this.Max.Y - this.Min.Y;
    public float Length => this.Max.Z - this.Min.Z;
    public Vector3 Center => (this.Max + this.Min) * 0.5f;

    public Vector3 Min { get; }
    public Vector3 Max { get; }

    public Vector3 Size => new Vector3(this.Width, this.Height, this.Length);

    #endregion Properties

    public BoundingBoxF(Vector3 min, Vector3 max)
    {
        this.Min = min;
        this.Max = max;
    }

    public readonly bool Contains(in Vector3 p)
    {
        return p.X >= this.Min.X
            && p.X <= this.Max.X
            && p.Y >= this.Min.Y
            && p.Y <= this.Max.Y
            && p.Z >= this.Min.Z
            && p.Z <= this.Max.Z;
    }
}
