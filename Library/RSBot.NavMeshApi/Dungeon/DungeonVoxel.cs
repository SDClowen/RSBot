using System.Numerics;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi.Dungeon;

public class DungeonVoxel
{
    public const float Width = 200.0f;
    public const float Height = 200.0f;
    public const float Length = 200.0f;

    private readonly List<NavMeshInstBlock> _blocks = new List<NavMeshInstBlock>();

    public BoundingBoxF BoundingBox { get; }
    public DungeonVoxelID ID { get; set; }
    public IReadOnlyList<NavMeshInstBlock> Blocks => _blocks;

    public DungeonVoxel(DungeonVoxelID id)
    {
        this.ID = id;

        var min = new Vector3(this.ID.X * Width, this.ID.Y * Height, this.ID.Z * Length);
        this.BoundingBox = new BoundingBoxF(min, min + new Vector3(Width, Height, Length));
    }

    public void AddBlock(NavMeshInstBlock block) => _blocks.Add(block);
}
