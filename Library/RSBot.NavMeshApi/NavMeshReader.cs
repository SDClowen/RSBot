using System.Diagnostics;
using System.Numerics;
using System.Text;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi;

public class NavMeshReader : BinaryReader
{
    private protected readonly Encoding _encoding;

    public NavMeshReader(Stream input)
        : base(input)
    {
        _encoding = Encoding.ASCII;
    }

    public NavMeshReader(Stream input, Encoding encoding)
        : base(input, encoding)
    {
        _encoding = encoding;
    }

    public NavMeshReader(Stream input, Encoding encoding, bool leaveOpen)
        : base(input, encoding, leaveOpen)
    {
        _encoding = encoding;
    }

    public override string ReadString()
    {
        var byteCount = base.ReadInt32();
        Debug.Assert(byteCount >= 0 || byteCount <= 8192);

        return this.ReadString(byteCount);
    }

    public string ReadString(int byteCount)
    {
        var buffer = base.ReadBytes(byteCount);

        int terminatorOffset = byteCount;
        for (int i = 0; i < byteCount; i++)
        {
            if (buffer[i] == byte.MinValue)
            {
                terminatorOffset = i;
                break;
            }
        }
        return _encoding.GetString(buffer, 0, terminatorOffset);
    }

    public float ReadFloat() => this.ReadSingle();

    public RID ReadRegion() => new RID(this.ReadUInt16());

    public Vector2 ReadVector2() => new Vector2(this.ReadFloat(), this.ReadFloat());

    public Vector3 ReadVector3() => new Vector3(this.ReadFloat(), this.ReadFloat(), this.ReadFloat());

    public Vector4 ReadVector4() => new Vector4(this.ReadFloat(), this.ReadFloat(), this.ReadFloat(), this.ReadFloat());

    public RectangleF ReadRectangle() => new RectangleF(this.ReadVector2(), this.ReadVector2());

    public BoundingBoxF ReadBoundingBox() => new BoundingBoxF(this.ReadVector3(), this.ReadVector3());

    public TriangleF ReadTriangle() => new TriangleF(this.ReadVector3(), this.ReadVector3(), this.ReadVector3());

    public LineF ReadLine2D() => new LineF(this.ReadVector2(), this.ReadVector2());

    public LineF ReadLine3D() => new LineF(this.ReadVector3(), this.ReadVector3());
}
