namespace RSBot.NavMeshApi.Dungeon;

public struct DungeonVoxelID : IEquatable<DungeonVoxelID>
{
    #region Reasons to use C++

    private const int X_SIZE = 10;
    private const int X_OFFSET = 0;
    private const uint X_MASK = (1 << X_SIZE) - 1 << X_OFFSET;

    private const int Z_SIZE = 10;
    private const int Z_OFFSET = X_OFFSET + X_SIZE;
    private const uint Z_MASK = (1 << Z_SIZE) - 1 << Z_OFFSET;

    private const int Y_SIZE = 10;
    private const int Y_OFFSET = Z_OFFSET + Z_SIZE;
    private const uint Y_MASK = (1 << Y_SIZE) - 1 << Y_OFFSET;

    //private const int FLAG_SIZE = 2;
    //private const int FLAG_OFFSET = Y_OFFSET + Y_SIZE;
    //private const uint FLAG_MASK = (uint)((1 << FLAG_SIZE) - 1) << FLAG_OFFSET;

    #endregion Reasons to use C++

    #region Properties

    public int Value { get; private set; }

    public ushort X
    {
        get { return Convert.ToUInt16((this.Value & X_MASK) >> X_OFFSET); }
        set { this.Value = (int)((this.Value & ~X_MASK) | (value << X_OFFSET & X_MASK)); }
    }

    public ushort Y
    {
        get { return Convert.ToUInt16((this.Value & Y_MASK) >> Y_OFFSET); }
        set { this.Value = (int)((this.Value & ~Y_MASK) | (value << Y_OFFSET & Y_MASK)); }
    }

    public ushort Z
    {
        get { return Convert.ToUInt16((this.Value & Z_MASK) >> Z_OFFSET); }
        set { this.Value = (int)((this.Value & ~Z_MASK) | ((value << Z_OFFSET) & Z_MASK)); }
    }

    //public byte Flag
    //{
    //    get { return Convert.ToByte((this.Value & FLAG_MASK) >> FLAG_OFFSET); }
    //    set { this.Value = (int)((this.Value & ~FLAG_MASK) | ((value << FLAG_OFFSET) & FLAG_MASK)); }
    //}

    #endregion Properties

    public DungeonVoxelID(ushort x, ushort y, ushort z)
    {
        this.Value = default;
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public DungeonVoxelID(int value)
    {
        this.Value = value;
    }

    public static implicit operator DungeonVoxelID(int value) => new DungeonVoxelID(value);

    public static implicit operator int(DungeonVoxelID value) => value.Value;

    #region Boxing prevention

    public override string ToString() => $"{this.X}x{this.Y}x{this.Z}";

    public override int GetHashCode() => this.Value.GetHashCode();

    public override bool Equals(object obj)
    {
        if (obj is DungeonVoxelID voxelID)
            return this.Equals(voxelID);

        return false;
    }

    public bool Equals(DungeonVoxelID other) => this.Value == other.Value;

    #endregion Boxing prevention
}
