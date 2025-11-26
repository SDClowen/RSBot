using System.Numerics;

namespace RSBot.NavMeshApi.Dungeon;

public class DungeonVoxelGrid
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Length { get; set; }

    private readonly Dictionary<DungeonVoxelID, DungeonVoxel> _voxels;

    public DungeonVoxelGrid()
    {
        _voxels = new Dictionary<DungeonVoxelID, DungeonVoxel>();
    }

    public DungeonVoxel this[DungeonVoxelID id]
    {
        get
        {
            if (_voxels.TryGetValue(id, out DungeonVoxel voxel))
                return voxel;

            return null;
        }
        set => _voxels[id] = value;
    }

    public DungeonVoxel this[ushort x, ushort y, ushort z] => this[new DungeonVoxelID(x, y, z)];

    public DungeonVoxel this[Vector3 vPos]
    {
        get
        {
            ushort x = (ushort)(vPos.X / DungeonVoxel.Width);
            ushort y = (ushort)(vPos.Y / DungeonVoxel.Height);
            ushort z = (ushort)(vPos.Z / DungeonVoxel.Length);
            return this[x, y, z];
        }
    }
}
