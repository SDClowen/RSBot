namespace RSBot.NavMeshApi.Object;

public struct NavMeshEventZone : IEquatable<NavMeshEventZone>
{
    public static readonly NavMeshEventZone Empty;

    #region Reasons to use C++

    private const int INDEX_SIZE = 6;
    private const int INDEX_OFFSET = 0;
    private const byte INDEX_MASK = ((1 << INDEX_SIZE) - 1) << INDEX_OFFSET;

    private const int FLAG_SIZE = 2;
    private const int FLAG_OFFSET = INDEX_OFFSET + INDEX_SIZE;
    private const byte FLAG_MASK = ((1 << FLAG_SIZE) - 1) << FLAG_OFFSET;

    #endregion Reasons to use C++

    // (MSB)                               (LSB)
    // | 07 | 06 | 05 | 04 | 03 | 02 | 01 | 00 |
    // |   Flag  |         EventIndex          |
    // Flag:
    // 1 = Bit0
    // 2 = Bit1
    private byte _value;

    public NavMeshEventZone(byte value)
    {
        _value = value;
    }

    #region Properties

    public byte Index
    {
        get { return Convert.ToByte((_value & INDEX_MASK) >> INDEX_OFFSET); }
        set { _value = (byte)((_value & ~INDEX_MASK) | ((value << INDEX_OFFSET) & INDEX_MASK)); }
    }

    public NavMeshEventZoneFlag Flag
    {
        get { return (NavMeshEventZoneFlag)Convert.ToByte((_value & FLAG_MASK) >> FLAG_OFFSET); }
        set { _value = (byte)((_value & ~FLAG_MASK) | (((byte)value << FLAG_OFFSET) & FLAG_MASK)); }
    }

    #endregion Properties

    #region Operators

    public static explicit operator byte(NavMeshEventZone zone) => zone._value;

    public static explicit operator NavMeshEventZone(byte value) => new NavMeshEventZone(value);

    public static bool operator ==(NavMeshEventZone left, NavMeshEventZone right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NavMeshEventZone left, NavMeshEventZone right)
    {
        return !(left == right);
    }

    public override bool Equals(object obj) => obj is NavMeshEventZone zone && this.Equals(zone);

    public bool Equals(NavMeshEventZone other) => _value == other._value;

    public override int GetHashCode() => _value.GetHashCode();

    #endregion Operators
}
