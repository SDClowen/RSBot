using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi.Dungeon;

public class NavMeshInstBlock : NavMeshInst
{
    public BoundingBoxF BoundingBox { get; set; }

    public List<DungeonColObj> ObjectList { get; set; } = new List<DungeonColObj>();

    /// <summary>
    /// Used for navigation
    /// </summary>
    public List<int> ConnectedBlocks { get; } = new List<int>();

    /// <summary>
    /// Used for occlustion culling
    /// </summary>
    public List<int> VisibleBlocks { get; } = new List<int>();

    /// <summary>
    /// Used for caching
    /// </summary>
    public List<int> NeighborBlocks { get; } = new List<int>();

    /// <summary>
    /// The floor index of this block.
    /// </summary>
    public int FloorIndex { get; set; }

    /// <summary>
    /// The room index of this block.
    /// </summary>
    public int RoomIndex { get; set; }
}
