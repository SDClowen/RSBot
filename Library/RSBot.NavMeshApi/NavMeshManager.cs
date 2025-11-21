using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using RSBot.FileSystem;
using RSBot.NavMeshApi.Dungeon;
using RSBot.NavMeshApi.Mathematics;
using RSBot.NavMeshApi.Object;
using RSBot.NavMeshApi.Terrain;

namespace RSBot.NavMeshApi;

public static class NavMeshManager
{
    private const int NORMAL_CACHE_SIZE = 256;

    private static IFileSystem _dataFileSystem;

    public static ObjectIndex ObjectIndex { get; } = new ObjectIndex();
    public static RegionManager RegionManager { get; } = new RegionManager();
    public static DungeonInfo DungeonInfo { get; } = new DungeonInfo();

    public static NavMeshEventZoneHandler? EventZoneHandler { get; set; }

    public static Vector2[] NormalCache = new Vector2[NORMAL_CACHE_SIZE];

    private static readonly Dictionary<RID, NavMesh> _regionCache = new Dictionary<RID, NavMesh>();
    private static readonly Dictionary<RID, NavMeshTerrain> _terrainCache = new Dictionary<RID, NavMeshTerrain>();
    private static readonly Dictionary<int, NavMeshObj> _objectCache = new Dictionary<int, NavMeshObj>();
    private static readonly Dictionary<RID, NavMeshDungeon> _dungeonCache = new Dictionary<RID, NavMeshDungeon>();

    public static void Initialize(IFileSystem dataFileSystem)
    {
        _dataFileSystem = dataFileSystem;

        LoadMapInfo("NavMesh\\MapInfo.mfo");
        LoadObjectIndex("NavMesh\\Object.ifo");
        LoadDungeonInfo("Dungeon\\DungeonInfo.txt");
        //LoadObjectString("NavMesh/ObjectString.ifo"); // EventZone data

        //_terrainCache.EnsureCapacity(RegionManager.ActiveRegions);
        //_objectCache.EnsureCapacity(ObjectIndex.)

        for (int i = 0; i < NORMAL_CACHE_SIZE; i++)
        {
            const float TwoPiOverANGLE_CACHE_SIZE = 2 * MathF.PI / NORMAL_CACHE_SIZE;
            NormalCache[i].Y = -MathF.Sin(i * TwoPiOverANGLE_CACHE_SIZE);
            NormalCache[i].X = MathF.Cos(i * TwoPiOverANGLE_CACHE_SIZE);
        }

        Debug.WriteLine("Initialized NavMeshManager!");
        Debug.WriteLine($"Mapinfo.mfo: {RegionManager.ActiveRegions} active regions");
        Debug.WriteLine($"Object.ifo: {ObjectIndex.Count()} objects");
    }

    public static bool Raycast(
        NavMeshTransform src,
        NavMeshTransform dst,
        NavMeshRaycastType type,
        [NotNullWhen(true)] out NavMeshRaycastHit? hit
    )
    {
        if (src.Region == dst.Region && src.Offset == dst.Offset)
        {
            hit = null;
            return false;
        }

        int raycastCount = 0;
        while (true)
        {
            raycastCount++;
            //if (raycastCount > 100)
            //throw new Exception("raycastCount above 100");

            // Move destination into the same region space as source.
            if (dst.Region != src.Region)
            {
                var localX = ((dst.Region.X - src.Region.X) * RID.Width) + dst.Offset.X;
                var localZ = ((dst.Region.Z - src.Region.Z) * RID.Length) + dst.Offset.Z;
                dst.Offset = new Vector3(localX, dst.Offset.Y, localZ);
                dst.Region = src.Region;
            }

            var srcMesh = src.Instance == null ? src.NavMesh : src.Instance.Parent;
            var result = srcMesh.Raycast(src, dst, type, out hit);
            Debug.WriteLine($"Source: {srcMesh} = {result} Hit:[{hit}]");
            switch (result)
            {
                case NavMeshRaycastResult.Reached:
                    return true;
                case NavMeshRaycastResult.Transition:
                    continue;
                case NavMeshRaycastResult.Collision:
                    return false;
            }
        }
    }

    public static bool Raycast(NavMeshTransform src, NavMeshTransform dst, NavMeshRaycastType type) =>
        Raycast(src, dst, type, out _);

    public static bool ResolveCellAndHeight(NavMeshTransform transform)
    {
        transform.Normalize();
        if (!TryGetNavMesh(transform.Region, out NavMesh mesh))
            return false;

        if (mesh.ResolveCellAndHeight(transform))
            return true;

        if (!transform.Region.IsDungeon)
            return false;

        // TOP_RIGHT
#pragma warning disable RCS1089 // Use --/++ operator instead of assignment.
        transform.Offset.X += 1.0f;
        transform.Offset.Z += 1.0f;
        if (mesh.ResolveCellAndHeight(transform))
            return true;

        // TOP_LEFT
        transform.Offset.X -= 2.0f;
        if (mesh.ResolveCellAndHeight(transform))
            return true;

        // BOTTOM_LEFT
        transform.Offset.Z -= 2.0f;
        if (mesh.ResolveCellAndHeight(transform))
            return true;

        // BOTTOM_RIGHT
        transform.Offset.X += 2.0f;
        if (mesh.ResolveCellAndHeight(transform))
            return true;
#pragma warning restore RCS1089 // Use --/++ operator instead of assignment.

        return transform.Cell != null;
    }

    #region Loading

    private static void LoadMapInfo(string fileName)
    {
        using var stream = _dataFileSystem.OpenRead(fileName).GetStream();
        RegionManager.Load(stream);
    }

    private static void LoadDungeonInfo(string fileName)
    {
        using var stream = _dataFileSystem.OpenRead(fileName).GetStream();
        DungeonInfo.Load(stream);
    }

    private static void LoadObjectIndex(string fileName)
    {
        using var stream = _dataFileSystem.OpenRead(fileName).GetStream();
        ObjectIndex.Load(stream);

        //foreach (var obj in ObjectIndex)
        //{
        //    try
        //    {
        //        LoadNavMeshObj(obj.Path);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //    }
        //}
    }

    public static void InvalidateCaches()
    {
        _objectCache.Clear();
        _regionCache.Clear();
        _dungeonCache.Clear();
        _terrainCache.Clear();
    }

    public static NavMeshObj LoadNavMeshObj(string fileName)
    {
        switch (fileName[fileName.Length - 1])
        {
            case /*cp*/
            'd':
                return LoadNavMeshObjFromCompound(fileName);
            case /*bs*/
            'r':
                return LoadNavMeshObjFromResource(fileName);
            case /*bm*/
            's':
                return LoadNavMeshObjFromPrimMesh(fileName);
            default:
                return null;
        }
    }

    public static NavMeshTerrain LoadNavMeshTerrain(string fileName, RID region)
    {
        var terrain = new NavMeshTerrain(region);
        if (!_dataFileSystem.TryGetFile(fileName, out var file))
            return null;

        using var stream = file.OpenRead().GetStream();
        terrain.Load(stream);

        return terrain;
    }

    public static NavMeshDungeon LoadNavMeshDungeon(string fileName, RID region)
    {
        var dungeon = new NavMeshDungeon(region);

        if (!_dataFileSystem.TryGetFile(fileName, out var file))
            return null;

        using var stream = file.OpenRead().GetStream();
        dungeon.Load(stream);

        return dungeon;
    }

    public static NavMeshObj LoadNavMeshObjFromPrimMesh(string fileName)
    {
        var obj = new NavMeshObj();
        if (!_dataFileSystem.TryGetFile(fileName, out var file))
            return null;

        using var stream = file.OpenRead().GetStream();

        obj.Load(stream);

        //foreach (var edge in obj.GlobalEdges)
        //    edge.Link();

        //foreach (var edge in obj.InternalEdges)
        //    edge.Link();

        return obj;
    }

    public static NavMeshObj LoadNavMeshObjFromResource(string fileName)
    {
        if (!_dataFileSystem.TryGetFile(fileName, out var file))
            return null;

        using var stream = file.OpenRead().GetStream();

        using (var reader = new NavMeshReader(stream))
        {
            var signature = reader.ReadString(12);
            if (signature != "JMXVRES 0109")
                throw new Exception("Invalid signature");

            var header = new
            {
                PrimMtrlSetOffset = reader.ReadInt32(),
                PrimMeshOffset = reader.ReadInt32(),
                PrimBranchOffset = reader.ReadInt32(),
                PrimAnimationOffset = reader.ReadInt32(),
                PrimMeshGroupOffset = reader.ReadInt32(),
                PrimAniGroupOffset = reader.ReadInt32(),
                ModPaletteOffset = reader.ReadInt32(),
                NavMeshObjOffset = reader.ReadInt32(),
                Int0 = reader.ReadInt32(),
                Int1 = reader.ReadInt32(),
                Int2 = reader.ReadInt32(),
                Int3 = reader.ReadInt32(),
                Int4 = reader.ReadInt32(),
            };

            if (header.NavMeshObjOffset == 0)
                return null;

            stream.Seek(header.NavMeshObjOffset, SeekOrigin.Begin);

            var navMeshObjPath = reader.ReadString();
            if (string.IsNullOrEmpty(navMeshObjPath))
                return null;

            return LoadNavMeshObj(navMeshObjPath);
        }
    }

    public static NavMeshObj LoadNavMeshObjFromCompound(string fileName)
    {
        if (!_dataFileSystem.TryGetFile(fileName, out var file))
            return null;

        using var stream = file.OpenRead().GetStream();
        using (var reader = new NavMeshReader(stream))
        {
            var signature = reader.ReadString(12);
            if (signature != "JMXVCPD 0101")
                throw new Exception("Invalid signature");

            var header = new
            {
                NavMeshObjOffset = reader.ReadInt32(),
                ResObjListOffset = reader.ReadInt32(),
                Int0 = reader.ReadInt32(),
                Int1 = reader.ReadInt32(),
                Int2 = reader.ReadInt32(),
                Int3 = reader.ReadInt32(),
                Int4 = reader.ReadInt32(),
            };
            if (header.NavMeshObjOffset == 0)
                return null;

            stream.Seek(header.NavMeshObjOffset, SeekOrigin.Begin);

            var navMeshObjPath = reader.ReadString();
            if (string.IsNullOrEmpty(navMeshObjPath))
                return null;

            return LoadNavMeshObjFromResource(navMeshObjPath);
        }
    }

    #endregion Loading

    public static bool TryGetNavMesh(RID region, out NavMesh mesh)
    {
        if (_regionCache.TryGetValue(region, out mesh))
            return true;

        if (region.IsDungeon)
        {
            if (!TryGetNavMeshDungeon(region, out NavMeshDungeon dungeon))
            {
                mesh = null;
                return false;
            }

            mesh = dungeon;
            return true;
        }
        else
        {
            if (!TryGetNavMeshTerrain(region, out NavMeshTerrain terrain))
            {
                mesh = null;
                return false;
            }

            mesh = terrain;
            return true;
        }
    }

    public static bool TryGetNavMeshTerrain(RID region, out NavMeshTerrain terrain)
    {
        if (!RegionManager.IsEnabled(region))
        {
            terrain = null;
            return false;
        }

        if (!_terrainCache.TryGetValue(region, out terrain))
        {
            terrain = LoadNavMeshTerrain($"navmesh\\nv_{(ushort)region:X4}.nvm", region);
            _regionCache[region] = terrain;
            _terrainCache[region] = terrain;
        }
        return terrain != null;
    }

    public static bool TryGetNavMeshObj(int index, out NavMeshObj obj)
    {
        if (!_objectCache.TryGetValue(index, out obj))
        {
            var objectIndex = ObjectIndex[index];
            if (objectIndex == null)
                return false;

            _objectCache[index] = obj = LoadNavMeshObj(objectIndex.Path);
            obj.IndexFlag = objectIndex.Flag;
        }

        return obj != null;
    }

    public static bool TryGetNavMeshDungeon(RID region, out NavMeshDungeon dungeon)
    {
        if (!region.IsDungeon)
        {
            dungeon = null;
            return false;
        }

        if (!_dungeonCache.TryGetValue(region, out dungeon))
        {
            var dungeonInfo = DungeonInfo[region];
            if (dungeonInfo == null)
                return false;

            dungeon = LoadNavMeshDungeon(dungeonInfo, region);
            _regionCache[region] = dungeon;
            _dungeonCache[region] = dungeon;
        }

        return dungeon != null;
    }
}
