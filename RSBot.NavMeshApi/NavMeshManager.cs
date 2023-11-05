﻿using NavMeshApi.Dungeon;
using NavMeshApi.Mathematics;
using NavMeshApi.Object;
using NavMeshApi.Terrain;

using System.Diagnostics;
using System.Numerics;

namespace NavMeshApi;

public static class NavMeshManager
{
    private const int NORMAL_CACHE_SIZE = 256;

    private static string _path;

    public static ObjectIndex ObjectIndex { get; } = new ObjectIndex();
    public static RegionManager RegionManager { get; } = new RegionManager();
    public static DungeonInfo DungeonInfo { get; } = new DungeonInfo();

    public static Vector2[] NormalCache = new Vector2[NORMAL_CACHE_SIZE];

    private static readonly Dictionary<Region, NavMesh> _regionCache = new Dictionary<Region, NavMesh>();
    private static readonly Dictionary<Region, NavMeshTerrain> _terrainCache = new Dictionary<Region, NavMeshTerrain>();
    private static readonly Dictionary<int, NavMeshObj> _objectCache = new Dictionary<int, NavMeshObj>();
    private static readonly Dictionary<Region, NavMeshDungeon> _dungeonCache = new Dictionary<Region, NavMeshDungeon>();

    public static void Initialize(string path)
    {
        _path = path;

        LoadMapInfo("NavMesh/MapInfo.mfo");
        LoadObjectIndex("NavMesh/Object.ifo");
        LoadObjectExtensions("NavMesh/ObjExt.ifo"); // DunBlock extensions
                                                    //LoadTextureIndex("NavMesh/Tile2D.ifo");
        LoadDungeonInfo("Dungeon/DungeonInfo.txt");
        //LoadObjectString("NavMesh/ObjectString.ifo"); // EventZone data

        //_terrainCache.EnsureCapacity(RegionManager.ActiveRegions);
        //_objectCache.EnsureCapacity(ObjectIndex.)

        for (int i = 0; i < NORMAL_CACHE_SIZE; i++)
        {
            const float TwoPiOverANGLE_CACHE_SIZE = 2 * MathF.PI / NORMAL_CACHE_SIZE;
            NormalCache[i].Y = -MathF.Sin(i * TwoPiOverANGLE_CACHE_SIZE);
            NormalCache[i].X = MathF.Cos(i * TwoPiOverANGLE_CACHE_SIZE);
        }
    }

    public static bool Raycast(NavMeshTransform src, NavMeshTransform dst, NavMeshRaycastType type)
    {
        if (src.Region == dst.Region && src.Offset == dst.Offset)
            return false;

        int raycastCount = 0;
        while (true)
        {
            raycastCount++;
            if (raycastCount > 100)
                throw new Exception("raycastCount above 100");

            // Move destination into the same region space as source.
            if (dst.Region != src.Region)
            {
                var localX = ((dst.Region.X - src.Region.X) * Region.Width) + dst.Offset.X;
                var localZ = ((dst.Region.Z - src.Region.Z) * Region.Length) + dst.Offset.Z;
                dst.Offset = new Vector3(localX, dst.Offset.Y, localZ);
                dst.Region = src.Region;
            }

            var result = src.NavMesh.Raycast(src, dst, type, out NavMeshRaycastHit hit);
            Debug.WriteLine($"{src.NavMesh} = {result} [{hit}]");
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
        using (var stream = File.OpenRead(Path.Combine(_path, fileName)))
            RegionManager.Load(stream);
    }

    private static void LoadDungeonInfo(string fileName)
    {
        using (var stream = File.OpenRead(Path.Combine(_path, fileName)))
            DungeonInfo.Load(stream);
    }

    private static void LoadObjectIndex(string fileName)
    {
        using (var stream = File.OpenRead(Path.Combine(_path, fileName)))
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

    private static void LoadObjectExtensions(string fileName)
    {
    }

    public static NavMeshObj LoadNavMeshObj(string fileName)
    {
        switch (fileName[fileName.Length - 1])
        {
            case /*cp*/'d': return LoadNavMeshObjFromCompound(fileName);
            case /*bs*/'r': return LoadNavMeshObjFromResource(fileName);
            case /*bm*/'s': return LoadNavMeshObjFromPrimMesh(fileName);
            default: return null;
        }
    }

    public static NavMeshTerrain LoadNavMeshTerrain(string fileName, Region region)
    {
        var terrain = new NavMeshTerrain(region);
        var path = Path.Combine(_path, fileName);
        if (!File.Exists(path))
            return null;

        using (var stream = File.OpenRead(path))
            terrain.Load(stream);

        return terrain;
    }

    public static NavMeshDungeon LoadNavMeshDungeon(string fileName, Region region)
    {
        var dungeon = new NavMeshDungeon(region);
        var path = Path.Combine(_path, fileName);
        if (!File.Exists(path))
            return null;

        using (var stream = File.OpenRead(path))
            dungeon.Load(stream);

        return dungeon;
    }

    public static NavMeshObj LoadNavMeshObjFromPrimMesh(string fileName)
    {
        var obj = new NavMeshObj();
        var path = Path.Combine(_path, fileName);
        if (!File.Exists(path))
            return null;

        using (var stream = File.OpenRead(path))
            obj.Load(stream);

        //foreach (var edge in obj.GlobalEdges)
        //    edge.Link();

        //foreach (var edge in obj.InternalEdges)
        //    edge.Link();

        return obj;
    }

    public static NavMeshObj LoadNavMeshObjFromResource(string fileName)
    {
        var path = Path.Combine(_path, fileName);
        if (!File.Exists(path))
            return null;

        using (var stream = File.OpenRead(path))
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
        string path = Path.Combine(_path, fileName);
        if (!File.Exists(path))
            return null;

        using (var stream = File.OpenRead(path))
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

    public static bool TryGetNavMesh(Region region, out NavMesh mesh)
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

    public static bool TryGetNavMeshTerrain(Region region, out NavMeshTerrain terrain)
    {
        if (!RegionManager.IsEnabled(region))
        {
            terrain = null;
            return false;
        }

        if (!_terrainCache.TryGetValue(region, out terrain))
        {
            terrain = LoadNavMeshTerrain($"NavMesh/nv_{(ushort)region:X4}.nvm", region);
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

    public static bool TryGetNavMeshDungeon(Region region, out NavMeshDungeon dungeon)
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