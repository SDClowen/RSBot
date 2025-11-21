using System.Diagnostics;
using System.Numerics;

namespace RSBot.NavMeshApi.Mathematics;

[DebuggerDisplay("{_value} [{this.X}x{this.Z}]")]
public struct RID : IEquatable<RID>
{
    public const float Width = 1920f;
    public const float Length = 1920f;

    public const int CenterX = 135;
    public const int CenterZ = 92;
    public static readonly RID Center = new RID(CenterX, CenterZ);
    public static readonly RID Empty = new RID(0);

    #region Reasons to use C++

    private const int X_SIZE = 8;
    private const int X_OFFSET = 0;
    private const ushort X_MASK = ((1 << X_SIZE) - 1) << X_OFFSET;

    private const int Z_SIZE = 7;
    private const int Z_OFFSET = X_OFFSET + X_SIZE;
    private const ushort Z_MASK = ((1 << Z_SIZE) - 1) << Z_OFFSET;

    private const int DUNGEON_SIZE = 1;
    private const int DUNGEON_OFFSET = Z_OFFSET + Z_SIZE;
    private const ushort DUNGEON_MASK = ((1 << DUNGEON_SIZE) - 1) << DUNGEON_OFFSET;

    #endregion Reasons to use C++

    //(MSB)                                                                       (LSB)
    // | 15 | 14 | 13 | 12 | 11 | 10 | 09 | 08 | 07 | 06 | 05 | 04 | 03 | 02 | 01 | 00 |
    // | DF |            ZSector               |                XSector                |
    // DF = Dungeon flag
    private ushort _value;

    #region Properties

    public byte X
    {
        get { return Convert.ToByte((_value & X_MASK) >> X_OFFSET); }
        set { _value = (ushort)((_value & ~X_MASK) | ((value << X_OFFSET) & X_MASK)); }
    }

    public byte Z
    {
        get { return Convert.ToByte((_value & Z_MASK) >> Z_OFFSET); }
        set { _value = (ushort)((_value & ~Z_MASK) | ((value << Z_OFFSET) & Z_MASK)); }
    }

    public bool IsDungeon
    {
        get { return Convert.ToBoolean((_value & DUNGEON_MASK) >> DUNGEON_OFFSET); }
        set
        {
            _value = (ushort)((_value & ~DUNGEON_MASK) | ((Convert.ToByte(value) << DUNGEON_OFFSET) & DUNGEON_MASK));
        }
    }

    public Vector3 Position => new Vector3(this.WorldX, 0.0f, this.WorldZ);

    public float WorldX
    {
        get
        {
            if (this.IsDungeon)
                return 0.0f;

            return (
                    this.X /*- CenterX*/
                ) * Width;
        }
    }

    public float WorldZ
    {
        get
        {
            if (this.IsDungeon)
                return 0.0f;

            return (
                    this.Z /*- CenterZ*/
                ) * Length;
        }
    }

    #endregion Properties

    #region Constructors

    public RID(short id)
    {
        _value = unchecked(((ushort)id));
    }

    public RID(ushort id)
    {
        _value = id;
    }

    public RID(byte x, byte z)
    {
        _value = 0;

        this.X = x;
        this.Z = z;
        this.IsDungeon = (z & 0x80) != 0;
    }

    #endregion Constructors

    #region Methods

    public static Vector3 Transform(Vector3 value, RID sourceRegion, RID targetRegion)
    {
        if (sourceRegion != targetRegion)
        {
            var localX = value.X + ((targetRegion.X - sourceRegion.X) * Width);
            var localZ = value.Z + ((targetRegion.Z - sourceRegion.Z) * Length);

            value = new Vector3(localX, 0, localZ);
        }
        return value;
    }

    public override string ToString() => $"{_value} [{this.X}x{this.Z}]";

    public override bool Equals(object obj)
    {
        if (obj is RID region)
            return this.Equals(region);

        return false;
    }

    public bool Equals(RID other) => _value == other._value;

    public override int GetHashCode() => _value.GetHashCode();

    #endregion Methods

    public static RID Create(byte x, byte z)
    {
        return new RID(x, z);
    }

    #region Operators

    public static implicit operator short(RID region) => unchecked((short)region._value);

    public static implicit operator RID(short value) => new RID(value);

    public static implicit operator ushort(RID region) => region._value;

    public static implicit operator RID(ushort value) => new RID(value);

    public static bool operator ==(RID left, RID right) => left.Equals(right);

    public static bool operator !=(RID left, RID right) => !(left == right);

    #endregion Operators
}
