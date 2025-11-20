namespace RSBot.NavMeshApi.Edges;

[Flags]
public enum NavMeshEdgeFlag
{
    None = 0,

    BlockDst2Src = 1,

    BlockSrc2Dst = 2,

    Blocked = BlockDst2Src | BlockSrc2Dst,

    /// <summary>
    ///  Connects a <see cref="NavMeshCell"/> with another <seealso cref="NavMeshCell"/>
    /// </summary>
    Internal = 4,

    /// <summary>
    /// Connects a <see cref="NavMesh"/> with another <seealso cref="NavMesh"/>
    /// </summary>
    Global = 8,

    /// <summary>
    /// Used for Bridges, only collied if within same <see cref="NavMesh"/>
    /// </summary>
    Railing = 16,

    /// <summary>
    /// Used for Dungeon entrances (obsolete?)
    /// </summary>
    Entrance = 32,

    Bit6 = 64,

    /// <summary>
    /// Can be casted through
    /// </summary>
    Siege = 128,
}
