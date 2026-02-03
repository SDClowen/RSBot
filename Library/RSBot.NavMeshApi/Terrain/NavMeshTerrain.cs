using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Extensions;
using RSBot.NavMeshApi.Mathematics;
using RSBot.NavMeshApi.Object;

namespace RSBot.NavMeshApi.Terrain;

public class NavMeshTerrain : NavMesh
{
    public override NavMeshType Type => NavMeshType.Terrain;

    public const int BLOCKS_X = 6;
    public const int BLOCKS_Z = 6;
    public const int BLOCKS_TOTAL = BLOCKS_X * BLOCKS_Z;

    public const int TILES_X = 96;
    public const int TILES_Z = 96;
    public const int TILES_TOTAL = TILES_X * TILES_Z;

    public const int VERTICES_X = TILES_X + 1;
    public const int VERTICES_Z = TILES_Z + 1;
    public const int VERTICES_TOTAL = VERTICES_X * VERTICES_Z;

    public const float Width = TILES_X * NavMeshTile.Width;
    public const float Length = TILES_Z * NavMeshTile.Length;

    private RID _region;

    public List<NavMeshInstObj> Instances { get; set; } = new List<NavMeshInstObj>();
    public List<NavMeshCellQuad> Cells { get; set; } = new List<NavMeshCellQuad>();

    public List<NavMeshEdgeGlobal> GlobalEdges { get; set; } = new List<NavMeshEdgeGlobal>();
    public List<NavMeshEdgeInternal> InternalEdges { get; set; } = new List<NavMeshEdgeInternal>();

    public override RID Region => _region;

    private readonly NavMeshTile[] _tileMap = new NavMeshTile[TILES_TOTAL];
    private readonly float[] _heightMap = new float[VERTICES_TOTAL];
    private readonly NavMeshPlane[] _planeMap = new NavMeshPlane[BLOCKS_TOTAL];

    public NavMeshTerrain(RID region)
    {
        _region = region;
    }

    internal void Load(Stream stream)
    {
        using (var reader = new NavMeshReader(stream))
        {
            var signature = reader.ReadString(12);
            if (signature != "JMXVNVM 1000")
                throw new Exception("Invalid signature");

            var instanceCount = reader.ReadInt16();
            this.Instances.Capacity = instanceCount;
            for (short i = 0; i < instanceCount; i++)
            {
                var instance = new NavMeshInstObj(this);
                instance.Read(reader);
                this.Instances.Add(instance);
            }

            // Cells
            var totalCellCount = reader.ReadInt32();
            var openCellCount = reader.ReadInt32();
            Debug.Assert(totalCellCount >= openCellCount);

            this.Cells.Capacity = totalCellCount;
            for (int i = 0; i < totalCellCount; i++)
            {
                var cell = new NavMeshCellQuad(this, i) { RectangleF = reader.ReadRectangle() };

                instanceCount = reader.ReadByte();
                cell.Instances.Capacity = instanceCount;
                for (int ii = 0; ii < instanceCount; ii++)
                    cell.Instances.Add(this.Instances[reader.ReadInt16()]);

                this.Cells.Add(cell);
            }

            // GlobalEdges
            var globalEdgeCount = reader.ReadInt32();
            this.GlobalEdges.Capacity = globalEdgeCount;
            for (int i = 0; i < globalEdgeCount; i++)
            {
                var edge = new NavMeshEdgeGlobal(this, i);
                edge.Read(reader);

                //edge.Flag |= NavMeshEdgeFlag.Global;

                Debug.Assert(
                    (edge.Flag & NavMeshEdgeFlag.Entrance) == 0,
                    $"Bit5 found in {nameof(NavMeshEdgeGlobal)} #{edge.Index}"
                );
                Debug.Assert(
                    (edge.Flag & NavMeshEdgeFlag.Bit6) == 0,
                    $"Bit6 found in {nameof(NavMeshEdgeGlobal)} #{edge.Index}"
                );

                this.GlobalEdges.Add(edge);
            }

            // InternalEdges
            var internalEdgeCount = reader.ReadInt32();
            this.InternalEdges.Capacity = globalEdgeCount;
            for (int i = 0; i < internalEdgeCount; i++)
            {
                var edge = new NavMeshEdgeInternal(this, i);
                edge.Read(reader);

                //edge.Flag |= NavMeshEdgeFlag.Internal;

                Debug.Assert(
                    (edge.Flag & NavMeshEdgeFlag.Entrance) == 0,
                    $"Bit5 found in {nameof(NavMeshEdgeInternal)} #{edge.Index}"
                );
                Debug.Assert(
                    (edge.Flag & NavMeshEdgeFlag.Bit6) == 0,
                    $"Bit6 found in {nameof(NavMeshEdgeInternal)} #{edge.Index}"
                );

                this.InternalEdges.Add(edge);
            }

            // TileMap
            for (int i = 0; i < TILES_TOTAL; i++)
            {
                var tile = new NavMeshTile
                {
                    CellIndex = reader.ReadInt32(),
                    Flag = (NavMeshTileFlag)reader.ReadInt16(),
                    TextureID = reader.ReadInt16(),
                };

                if (tile.IsBlocked)
                    this.Cells[tile.CellIndex].IsBlocked = true;

                _tileMap[i] = tile;
            }

            // HeightMap
            for (int i = 0; i < VERTICES_TOTAL; i++)
                _heightMap[i] = reader.ReadFloat();

            // SurfaceMap
            for (int i = 0; i < BLOCKS_TOTAL; i++)
                _planeMap[i].Type = (NavMeshPlaneType)reader.ReadByte();

            for (int i = 0; i < BLOCKS_TOTAL; i++)
                _planeMap[i].Height = reader.ReadFloat();

            // Link objects
            foreach (var instance in this.Instances)
            {
                foreach (var linkEdge in instance.LinkEdges.Values)
                {
                    if (linkEdge.EdgeID == -1)
                        continue;

                    var linkedObj = this.Instances[linkEdge.LinkedObjID];

                    linkEdge.LinkedInst = linkedObj;
                    linkEdge.LinkedObjEdge = linkedObj.GetGlobalEdgeByID(linkEdge.LinkedObjEdgeID);
                    linkEdge.Edge = instance.GetGlobalEdgeByID(linkEdge.EdgeID);
                }
            }

            foreach (var edge in this.InternalEdges)
                edge.Link();

            //this.PreprocessInstCellLinks();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NavMeshTile GetTile(int x, int z) => this.GetTile((z * TILES_Z) + x);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NavMeshTile GetTile(int index) => _tileMap[index];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float GetHeight(int x, int z) => this.GetHeight((z * VERTICES_Z) + x);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float GetHeight(int index) => _heightMap[index];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private NavMeshPlane GetPlane(int xBlock, int zBlock) => this.GetPlane((zBlock * BLOCKS_Z) + xBlock);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private NavMeshPlane GetPlane(int index) => _planeMap[index];

    public override NavMeshCell ResolveCellAndHeight(ref Vector3 vPos)
    {
        if (vPos.X < 0.0f || vPos.X >= Width || vPos.Z < 0.0 || vPos.Z >= Length)
            return null;

        Debug.Assert(this.TryFindHeight(ref vPos), "if(FindHeight(vPos) == FALSE)");

        var tile = this.GetTile((int)(vPos.X / NavMeshTile.Width), (int)(vPos.Z / NavMeshTile.Length));
        return this.Cells[tile.CellIndex];
    }

    public bool TryFindHeight(ref Vector3 vPos)
    {
        if (vPos.X < 0.0f || vPos.X >= Width || vPos.Z < 0.0f || vPos.Z >= Length)
            return false;

        int integerX = (int)(vPos.X / NavMeshTile.Width);
        int integerZ = (int)(vPos.Z / NavMeshTile.Length);
        float fractionX = (vPos.X - (integerX * NavMeshTile.Width)) / NavMeshTile.Width;
        float fractionZ = (vPos.Z - (integerZ * NavMeshTile.Length)) / NavMeshTile.Length;

        vPos.Y =
            (
                (1 - fractionX)
                * (
                    ((1 - fractionZ) * this.GetHeight(integerX, integerZ))
                    + (fractionZ * this.GetHeight(integerX, integerZ + 1))
                )
            )
            + (
                fractionX
                * (
                    ((1 - fractionZ) * this.GetHeight(integerX + 1, integerZ))
                    + (fractionZ * this.GetHeight(integerX + 1, integerZ + 1))
                )
            );

        // Is it a slippery situation?
        var xBlock = integerX / (int)(NavMeshPlane.Width / NavMeshTile.Width);
        var zBlock = integerZ / (int)(NavMeshPlane.Length / NavMeshTile.Length);
        var surface = this.GetPlane(xBlock, zBlock);
        if ((surface.Type & NavMeshPlaneType.Ice) != 0)
            vPos.Y = MathF.Max(vPos.Y, surface.Height); // only applied if higher than ground

        return true;
    }

    public bool TryFindHeightNoSurface(ref Vector3 vPos)
    {
        if (vPos.X < 0.0f || vPos.X >= Width || vPos.Z < 0.0f || vPos.Z >= Length)
            return false;

        int integerX = (int)(vPos.X / NavMeshTile.Width);
        int integerZ = (int)(vPos.Z / NavMeshTile.Length);
        float fractionX = (vPos.X - (integerX * NavMeshTile.Width)) / NavMeshTile.Width;
        float fractionZ = (vPos.Z - (integerZ * NavMeshTile.Length)) / NavMeshTile.Length;

        vPos.Y =
            (
                (1 - fractionX)
                * (
                    ((1 - fractionZ) * this.GetHeight(integerX, integerZ))
                    + (fractionZ * this.GetHeight(integerX, integerZ + 1))
                )
            )
            + (
                fractionX
                * (
                    ((1 - fractionZ) * this.GetHeight(integerX + 1, integerZ))
                    + (fractionZ * this.GetHeight(integerX + 1, integerZ + 1))
                )
            );

        return true;
    }

    public override bool ResolveCellAndHeight(NavMeshTransform position)
    {
        var inputHeight = position.Offset.Y;
        var vTerrainTest = position.Offset;
        var vObjectTest = position.Offset;

        if (!(this.ResolveCellAndHeight(ref vTerrainTest) is NavMeshCellQuad quad))
            return false;

        position.Cell = quad;
        position.Instance = null;

        var deltaTerrain = vTerrainTest.Y - inputHeight;
        var deltaTerrainAbs = MathF.Abs(deltaTerrain);

        foreach (var inst in quad.Instances)
        {
            if (!inst.TryGetNavMeshCell(ref vObjectTest, out NavMeshCell triangle))
                continue;

            var deltaObj = vObjectTest.Y - inputHeight;
            var deltaObjAbs = Math.Abs(deltaObj);

            if (deltaObjAbs < deltaTerrainAbs)
            {
                deltaTerrain = deltaObj;
                position.Cell = triangle;
                position.Instance = inst;
            }
        }

        if (position.Instance == null)
            position.Offset = vTerrainTest;

        position.Offset.Y = deltaTerrain + inputHeight;

        // Manually blocked tiles?
        if (position.Instance == null)
        {
            var tileX = (int)(position.Offset.X / NavMeshTile.Width);
            var tileZ = (int)(position.Offset.Z / NavMeshTile.Length);
            if (this.GetTile(tileX, tileZ).IsBlocked)
                position.Cell = null;
        }
        return position.Cell != null;
    }

    public override NavMeshCell GetNavMeshCell(int index)
    {
        if (index < 0 || index >= this.Cells.Count)
            return null;

        return this.Cells[index];
    }

    private NavMeshHitResult GetCellIntersection(
        in LineF line,
        NavMeshCellQuad curCell,
        NavMeshCellQuad prevCell,
        out NavMeshRaycastHit hit
    )
    {
        var direction = line.GetDirection();

        foreach (var edge in curCell.Edges)
        {
            // Optimize using cardinal direction
            var side = edge.GetSide(curCell);
            if (side == NavMeshCellSide.North && (direction & CardinalDirection.North) == 0)
                continue;

            if (side == NavMeshCellSide.East && (direction & CardinalDirection.East) == 0)
                continue;

            if (side == NavMeshCellSide.South && (direction & CardinalDirection.South) == 0)
                continue;

            if (side == NavMeshCellSide.West && (direction & CardinalDirection.West) == 0)
                continue;

            if (edge.Intersects(line, out Vector3 point))
            {
                var remoteCell = edge.GetRemoteCell(curCell);
                if (remoteCell == prevCell)
                    continue;

                hit = new NavMeshRaycastHit
                {
                    Region = this.Region,
                    Position = point,
                    Cell = curCell,
                    Edge = edge,
                };
                return NavMeshHitResult.Terrain;
            }
        }

        hit = null;
        return NavMeshHitResult.None;
    }

    private NavMeshHitResult GetInstanceIntersection(in LineF line, NavMeshCellQuad curCell, out NavMeshRaycastHit? hit)
    {
        NavMeshEdge? hitEdge = null;
        NavMeshInst? hitInstance = null;
        Vector3 hitPoint = Vector3.Zero;
        float hitDistanceSqrt = float.PositiveInfinity;

        foreach (var instance in curCell.Instances)
        {
            var obj = instance.NavMeshObj;
            var localLine = instance.WorldToLocal.MultiplyLine(line);

            // do we intersect with the object grids bounding box?
            if (!obj.Grid.Rectangle.Intersects(localLine))
                continue;

            obj.Grid.Raytrace(
                localLine,
                (tile) =>
                {
                    foreach (var edge in tile.GlobalEdges)
                    {
                        // bridges are not considered blocked from outside.
                        if (edge.IsRailing)
                            continue;

                        if (!edge.Intersects(localLine, out Vector3 point))
                            continue;

                        var distanceSqrt = (localLine.Min - point).LengthSquared();
                        if (hitEdge == null || hitDistanceSqrt > distanceSqrt)
                        {
                            hitInstance = instance;
                            hitEdge = edge;
                            hitPoint = point;
                            hitDistanceSqrt = distanceSqrt;
                        }
                    }
                }
            );
        }

        // Did we hit anything?
        if (hitEdge == null || hitInstance == null)
        {
            hit = null;
            return NavMeshHitResult.None;
        }

        // transform the hitPoint into world space
        hit = new NavMeshRaycastHit
        {
            Region = this.Region,
            Position = hitInstance.LocalToWorld.MultiplyPoint(hitPoint),
            Edge = hitEdge,
            Cell = curCell,
            Instance = hitInstance,
        };
        return NavMeshHitResult.Object;
    }

    public override NavMeshRaycastResult Raycast(
        NavMeshTransform src,
        NavMeshTransform dst,
        NavMeshRaycastType rayType,
        out NavMeshRaycastHit hit
    )
    {
        if (src.Instance != null)
            return src.Instance.NavMeshObj.Raycast(src, dst, rayType, out hit);

        var line = new LineF(src.Offset, dst.Offset);

        NavMeshCellQuad curCell = src.Cell as NavMeshCellQuad;
        NavMeshCellQuad prevCell = curCell;
        NavMeshCellQuad lastCell = null;

        int sameCellCount = 0;
        int raycastCount = 0;
        const int MAX_ITERATIONS = 500;
        const float HIT_EPS = 1e-4f;
        const float COLLISION_PUSHBACK = 0.05f;

        while (true)
        {
            if (curCell == lastCell)
            {
                if (++sameCellCount > 3)
                {
                    Debug.WriteLine("[Warning] Raycast stuck in same cell");
                    hit = null;
                    return NavMeshRaycastResult.Collision;
                }
            }
            else
            {
                sameCellCount = 0;
                lastCell = curCell;
            }

            if (raycastCount++ > MAX_ITERATIONS)
            {
                Debug.WriteLine($"[Warning] Raycast stuck after {MAX_ITERATIONS} iterations.");
                hit = null;
                return NavMeshRaycastResult.Collision;
            }

            var result = NavMeshHitResult.None;

            // Are we intersecting with objects in this cell?
            result |= this.GetInstanceIntersection(line, curCell, out NavMeshRaycastHit objectHit);

            if ((result & NavMeshHitResult.Object) == 0)
            {
                // Objects are out of the way, we can check if we've reached destination.
                if (curCell == dst.Cell)
                {
                    hit = null;
                    return NavMeshRaycastResult.Reached;
                }
            }

            // Do we have intersections with cells
            result |= this.GetCellIntersection(line, curCell, prevCell, out NavMeshRaycastHit terrainHit);

            if (result == NavMeshHitResult.None)
            {
                hit = null;
                return NavMeshRaycastResult.Reached;
            }

            if ((result & NavMeshHitResult.Any) == NavMeshHitResult.Any)
            {
                Debug.WriteLine("Object & Terrain hit (keeping closest)");

                // We've hit an object edge AND a terrain edge.
                var objectDistSq = (objectHit.Position - line.Min).LengthSquared();
                var terrainDistSq = (terrainHit.Position - line.Min).LengthSquared();

                if (MathF.Abs(objectDistSq - terrainDistSq) < HIT_EPS)
                {
                    result &= ~NavMeshHitResult.Terrain;
                }
                else if (objectDistSq < terrainDistSq)
                {
                    result &= ~NavMeshHitResult.Terrain;
                }
                else
                {
                    result &= ~NavMeshHitResult.Object;
                }
            }

            if ((result & NavMeshHitResult.Object) != 0)
            {
                Debug.WriteLine($"Object hit ({objectHit})");

                // We hit an object edge, is it blocked?
                var isBulletProof = rayType != NavMeshRaycastType.Attack || !objectHit.Edge.IsSiege;
                if (objectHit.Edge.IsBlockedFrom(curCell) && isBulletProof)
                {
                    hit = objectHit;
                    hit.Region = _region;

                    var dir = Vector3.Normalize(line.Max - line.Min);
                    hit.Position -= dir * COLLISION_PUSHBACK;

                    return NavMeshRaycastResult.Collision;
                }

                // Check if we hit an edge with an EventZone
                if ((objectHit.Edge.EventZone.Flag & NavMeshEventZoneFlag.All) != 0)
                {
                    var eventZoneInvoker = objectHit.Instance;
                    var eventZone = objectHit.Edge.EventZone;
                    if (!(NavMeshManager.EventZoneHandler?.Invoke(eventZoneInvoker, eventZone) ?? false))
                    {
                        Debug.WriteLine(
                            $"EventZone ({eventZoneInvoker.NavMeshObj.Events[eventZone.Index]}, {eventZone.Flag}) returned collision."
                        );
                        hit = objectHit;
                        hit.Region = _region;
                        return NavMeshRaycastResult.Collision;
                    }
                }

                // Check if remoteCell has an EventZone
                var remoteCell = (NavMeshCellTri)objectHit.Edge.GetRemoteCell(curCell);
                if ((remoteCell.EventZone.Flag & NavMeshEventZoneFlag.All) != 0)
                {
                    var eventZoneInvoker = objectHit.Instance;
                    var eventZone = remoteCell.EventZone;
                    if (!(NavMeshManager.EventZoneHandler?.Invoke(eventZoneInvoker, eventZone) ?? false))
                    {
                        Debug.WriteLine(
                            $"EventZone ({eventZoneInvoker.NavMeshObj.Events[eventZone.Index]}, {eventZone.Flag}) returned collision."
                        );
                        hit = objectHit;
                        hit.Region = _region;
                        return NavMeshRaycastResult.Collision;
                    }
                }

                // Transition into object if possible.
                src.Instance = objectHit.Instance;
                src.Cell = remoteCell;

                var offset = objectHit.Position;

                offset = Vector3.Transform(offset, objectHit.Instance.WorldToLocal);
                src.Cell.MoveTowardsCenter(ref offset);
                offset = Vector3.Transform(offset, objectHit.Instance.LocalToWorld);

                src.Offset = offset;
                hit = null;
                return NavMeshRaycastResult.Transition;
            }

            if ((result & NavMeshHitResult.Terrain) != 0)
            {
                Debug.WriteLine($"Terrain hit ({terrainHit})");

                // We've hit a terrain edge
                if (terrainHit.Edge.IsBlockedFrom(curCell))
                {
                    hit = terrainHit;
                    hit.Region = _region;

                    var dir = Vector3.Normalize(line.Max - line.Min);
                    hit.Position -= dir * COLLISION_PUSHBACK;

                    return NavMeshRaycastResult.Collision;
                }

                // Transition into neighbor terrain cell if possible
                prevCell = curCell;
                curCell = terrainHit.Edge.GetRemoteCell(curCell) as NavMeshCellQuad;
                if (curCell.NavMesh == this) // cell is within this navmesh
                    continue;

                src.Instance = null;
                src.Cell = curCell;
                src.Region = curCell.NavMesh.Region;
                src.Offset = terrainHit.Position;
                src.Break();
                curCell.RectangleF.MoveTowardsCenter(ref src.Offset);
                hit = null;
                return NavMeshRaycastResult.Transition;
            }
        }
    }
}
