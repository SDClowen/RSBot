using System.Diagnostics;
using System.Numerics;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Extensions;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi.Dungeon;

public class NavMeshDungeon : NavMesh
{
    private RID _region;

    public BoundingBoxF BoundingBox { get; set; }

    private readonly Dictionary<int, NavMeshInstBlock> _blockMap = new Dictionary<int, NavMeshInstBlock>();
    private readonly List<NavMeshInstBlock> _blockList = new List<NavMeshInstBlock>();
    public IEnumerable<NavMeshInstBlock> Blocks => _blockList;

    public DungeonVoxelGrid VoxelGrid { get; set; }

    public override NavMeshType Type => NavMeshType.Dungeon;
    public override RID Region => _region;

    private readonly Dictionary<int, string> _roomStringIDs = new Dictionary<int, string>();
    private readonly Dictionary<int, string> _floorStringIDs = new Dictionary<int, string>();

    public IReadOnlyDictionary<int, string> RoomStringIDs => _roomStringIDs;
    public IReadOnlyDictionary<int, string> FloorStringIDs => _floorStringIDs;

    public NavMeshDungeon(RID region)
    {
        _region = region;
    }

    public void Load(Stream stream)
    {
        using (var reader = new NavMeshReader(stream))
        {
            var signature = reader.ReadString(12);
            if (signature != "JMXVDOF 0101")
                throw new Exception("Invalid signature");

            var header = new
            {
                BlockOffset = reader.ReadInt32(),
                LinkOffset = reader.ReadInt32(),
                VoxelOffset = reader.ReadInt32(),
                GroupOffset = reader.ReadInt32(),
                LabelOffset = reader.ReadInt32(),
                Offset5 = reader.ReadInt32(),
                Offset6 = reader.ReadInt32(),
                BoundingBoxOffset = reader.ReadInt32(),
            };

            // BoundingBox data
            stream.Seek(header.BoundingBoxOffset, SeekOrigin.Begin);
            this.BoundingBox = reader.ReadBoundingBox();

            // Block data
            stream.Seek(header.BlockOffset, SeekOrigin.Begin);
            var dunBlockCount = reader.ReadInt32();
            //_blockMap.Capacity = dunBlockCount;
            for (int i = 0; i < dunBlockCount; i++)
                this.ReadDunBlock(i, stream, reader, this);

            foreach (var block in _blockMap.Values)
                this.LinkBlock(block);

            // Voxel data
            stream.Seek(header.VoxelOffset, SeekOrigin.Begin);
            this.ReadVoxelGrid(reader);

            // Internal Edges
            stream.Seek(header.LinkOffset, SeekOrigin.Begin);
            var iBlockCount = reader.ReadInt32();
            Debug.Assert(_blockList.Count == iBlockCount);

            if (header.LabelOffset != 0)
            {
                stream.Seek(header.LabelOffset, SeekOrigin.Begin);

                var roomCount = reader.ReadInt32();
                for (int i = 0; i < roomCount; i++)
                    _roomStringIDs[i] = reader.ReadString();

                var floorCount = reader.ReadInt32();
                for (int i = 0; i < floorCount; i++)
                    _floorStringIDs[i] = reader.ReadString();
            }
        }
    }

    private void LinkBlock(NavMeshInstBlock block)
    {
        foreach (var edge in block.NavMeshObj.GlobalEdges)
        {
            if (!edge.IsGlobalLinker)
                continue;

            if (edge.IsBlocked) // Why is this not checked in original implementation?!
                continue;

            foreach (var adjecentBlockID in block.ConnectedBlocks)
            {
                var adjecentBlock = _blockMap[adjecentBlockID];
                foreach (var adjecentEdge in adjecentBlock.NavMeshObj.GlobalEdges)
                {
                    if (!adjecentEdge.IsGlobalLinker)
                        continue;

                    if (adjecentEdge.IsBlocked) // Why is this not checked in original implementation?!
                        continue;

                    var line = block.LocalToWorld.MultiplyLine(edge.Line);
                    var adjecentLine = adjecentBlock.LocalToWorld.MultiplyLine(adjecentEdge.Line);
                    if (!line.IsWithinRadius(adjecentLine))
                        continue;

                    block.LinkEdges[edge.Index] = new NavMeshLinkEdge
                    {
                        Edge = edge,
                        EdgeID = (short)edge.Index,
                        LinkedObjID = (short)adjecentBlock.ID,
                        LinkedInst = adjecentBlock,
                        LinkedObjEdge = adjecentEdge,
                        LinkedObjEdgeID = (short)adjecentEdge.Index,
                    };
                }
            }
        }
    }

    private void ReadVoxelGrid(NavMeshReader reader)
    {
        this.VoxelGrid = new DungeonVoxelGrid
        {
            Width = reader.ReadInt32(),
            Height = reader.ReadInt32(),
            Length = reader.ReadInt32(),
        };

        var voxelCount = reader.ReadInt32(); // voxles with data
        for (int i = 0; i < voxelCount; i++)
        {
            var voxel = new DungeonVoxel(reader.ReadInt32());

            var blockCount = reader.ReadInt32();
            for (int ii = 0; ii < blockCount; ii++)
                voxel.AddBlock(_blockList[reader.ReadInt32()]);

            this.VoxelGrid[voxel.ID] = voxel;
        }
    }

    private void ReadDunBlock(int index, Stream stream, NavMeshReader reader, NavMeshDungeon parent)
    {
        var path = reader.ReadString();
        var name = reader.ReadString();

        stream.Seek(4, SeekOrigin.Current);

        var position = reader.ReadVector3();
        var yaw = reader.ReadFloat();
        var isEntrance = reader.ReadInt32();
        var boundingBox = reader.ReadBoundingBox();

        var localToWorld = Matrix4x4.CreateRotationY(-yaw) * Matrix4x4.CreateTranslation(position);
        var result = Matrix4x4.Invert(localToWorld, out var worldToLocal);
        Debug.Assert(result, "Failed to invert localToWorld matrix");

        stream.Seek(20, SeekOrigin.Current);
        var blockHasHeightFog = reader.ReadBoolean();
        if (blockHasHeightFog)
            stream.Seek(16, SeekOrigin.Current);

        var blockHasUnknownVector = reader.ReadBoolean();
        if (blockHasUnknownVector)
            stream.Seek(28, SeekOrigin.Current);

        stream.Seek(reader.ReadInt32(), SeekOrigin.Current); //SeekOverString
        var roomIndex = reader.ReadInt32();
        var floorIndex = reader.ReadInt32();

        var block = new NavMeshInstBlock
        {
            ID = index,
            Region = this.Region,
            Parent = parent,
            NavMeshObj = NavMeshManager.LoadNavMeshObj(path),
            LocalPosition = position,
            LocalToWorld = localToWorld,
            WorldToLocal = worldToLocal,
            BoundingBox = boundingBox,
            Yaw = yaw,
            RoomIndex = roomIndex,
            FloorIndex = floorIndex,
        };

        var connectedBlockCount = reader.ReadInt32();
        for (int i = 0; i < connectedBlockCount; i++)
            block.ConnectedBlocks.Add(reader.ReadInt32());

        var visibleBlockCount = reader.ReadInt32();
        stream.Seek(visibleBlockCount * sizeof(int), SeekOrigin.Current);

        var blockObjCount = reader.ReadInt32();
        var blockColObjCount = reader.ReadInt32();
        Debug.Assert(blockColObjCount <= blockObjCount);
        for (int ii = 0; ii < blockObjCount; ii++)
        {
            //stream.Seek(reader.ReadInt32(), SeekOrigin.Current);
            var blockObjName = reader.ReadString();
            var blockObjPath = reader.ReadString();
            var blockObjPosition = reader.ReadVector3();
            stream.Seek(24, SeekOrigin.Current);
            var blockObjFlag = reader.ReadInt32();
            var blockObjInt = reader.ReadInt32();
            var blockObjRadius = MathF.Sqrt(reader.ReadFloat());
            if ((blockObjFlag & 4) != 0)
                stream.Seek(4, SeekOrigin.Current); // Color

            if ((blockObjFlag & 2) != 0)
            {
                block.ObjectList.Add(
                    new DungeonColObj
                    {
                        Name = blockObjName,
                        Circle = new CircleF(blockObjPosition.ToVector2(), blockObjRadius),
                    }
                );
            }
        }

        var blockLightCount = reader.ReadInt32();
        for (int ii = 0; ii < blockLightCount; ii++)
        {
            stream.Seek(reader.ReadInt32(), SeekOrigin.Current); //SeekOverString
            stream.Seek(60, SeekOrigin.Current);
        }

        _blockList.Add(block);
        _blockMap[index] = block;
    }

    private DungeonVoxel GetVoxel(Vector3 vPos)
    {
        var vDelta = vPos - this.BoundingBox.Min;
        if (vDelta.X < 0.0f || vDelta.Y < 0.0f || vDelta.Z < 0.0f)
            return null;

        return this.VoxelGrid[vDelta];
    }

    public override NavMeshCell ResolveCellAndHeight(ref Vector3 vPos)
    {
        var voxel = this.GetVoxel(vPos);
        if (voxel == null)
            return null;

        NavMeshCell cell = null;
        //NavMeshInstBlock instance = null;

        var vBlockTest = vPos;
        var y = float.PositiveInfinity;
        var minDeltaHeight = float.PositiveInfinity;

        foreach (var block in voxel.Blocks)
        {
            if (!block.TryGetNavMeshCell(ref vBlockTest, out NavMeshCell blockCell))
                continue;

            var deltaHeight = Math.Abs(vBlockTest.Y - vPos.Y);
            if (deltaHeight < minDeltaHeight)
            {
                minDeltaHeight = deltaHeight;
                y = vBlockTest.Y;
                cell = blockCell;
                //instance = block;
            }
        }

        vPos.Y = y;
        return cell;
    }

    public override bool ResolveCellAndHeight(NavMeshTransform transform)
    {
        var voxel = this.GetVoxel(transform.Offset);
        if (voxel == null)
            return false;

        var inputHeight = transform.Offset.Y;
        var deltaHeight = float.PositiveInfinity;

        var positionOnBlock = transform.Offset;
        foreach (var block in voxel.Blocks)
        {
            if (!block.TryGetNavMeshCell(ref positionOnBlock, out NavMeshCell triangle))
                continue;

            var delta = MathF.Abs(positionOnBlock.Y - inputHeight);
            if (delta < deltaHeight)
            {
                transform.Instance = block;
                transform.Cell = triangle;
                deltaHeight = delta;
            }
        }

        if (transform.Cell == null)
            return false;

        transform.Offset.Y = deltaHeight + inputHeight;
        return true;
    }

    private static bool TryGetCollisionObjectIntersection(NavMeshInstBlock block, LineF line, out Vector3 hit)
    {
        var min = line.Min.ToVector2();
        var max = line.Max.ToVector2();

        var distanceSrcToDst = Vector2.Distance(min, max);
        foreach (var obj in block.ObjectList)
        {
            var distanceSrcToObj = Vector2.Distance(min, obj.Circle.Position);
            var distanceDstToObj = Vector2.Distance(max, obj.Circle.Position);
            var closestToObj = MathF.Max(distanceSrcToObj, distanceDstToObj);

            if (distanceSrcToDst + obj.Circle.Radius >= closestToObj)
            {
                // We found the closest circle now check if we collide and where.
                if (!obj.Circle.Intersects(line, out Vector2 intersectionPoint))
                    break;

                hit = intersectionPoint.ToVector3();
                return true;
            }
        }

        hit = Vector3.Zero;
        return false;
    }

    public override NavMeshRaycastResult Raycast(
        NavMeshTransform src,
        NavMeshTransform dst,
        NavMeshRaycastType type,
        out NavMeshRaycastHit hit
    )
    {
        var line = new LineF(src.Offset, dst.Offset);

        var block = (NavMeshInstBlock)src.Instance;
        var blockCell = src.Cell;
        var blockResult = src.Instance.NavMeshObj.Raycast(src, dst, type, out hit);
        Debug.WriteLine($"Block hit = {blockResult} [{hit}]");

        // Check if we hit an object
        if (!TryGetCollisionObjectIntersection(block, line, out var objectHit))
            return blockResult; // no object hit, we're good to leave here.

        // We also hit an object, figure out if it's closer than transition, collison or destination.
        Debug.WriteLine("Object & Block hit");
        var blockHit = blockResult == NavMeshRaycastResult.Reached ? line.Max : hit.Position;
        var distanceToBlockHit = (blockHit - line.Min).LengthSquared();
        var distanceToObjectHitSqrt = (objectHit - line.Min).LengthSquared();
        if (distanceToObjectHitSqrt > distanceToBlockHit)
            return blockResult; // we're good to leave here.

        // Object was closer. Report hit
        Debug.WriteLine("Object was closer");
        hit = new NavMeshRaycastHit()
        {
            Edge = null,
            Cell = blockCell,
            Instance = block,
            Region = this.Region,
            Position = objectHit,
        };
        return NavMeshRaycastResult.Collision;
    }
}
