﻿using NavMeshApi.Cells;
using NavMeshApi.Edges;
using NavMeshApi.Extensions;

using NavMeshApi.Mathematics;

using System.Diagnostics;
using System.Numerics;

namespace NavMeshApi.Dungeon;

public class NavMeshDungeon : NavMesh
{
    private Region _region;

    public BoundingBoxF BoundingBox { get; set; }

    private readonly Dictionary<int, NavMeshInstBlock> _blockMap = new Dictionary<int, NavMeshInstBlock>();
    private readonly List<NavMeshInstBlock> _blockList = new List<NavMeshInstBlock>();
    public IEnumerable<NavMeshInstBlock> Blocks => _blockList;

    public DungeonVoxelGrid VoxelGrid { get; set; }

    public override NavMeshType Type => NavMeshType.Dungeon;
    public override Region Region => _region;

    public NavMeshDungeon(Region region)
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
                this.ReadDunBlock(i, stream, reader);

            foreach (var block in _blockMap.Values)
                this.LinkBlock(block);

            // Voxel data
            stream.Seek(header.VoxelOffset, SeekOrigin.Begin);
            this.ReadVoxelGrid(reader);

            // Internal Edges
            stream.Seek(header.LinkOffset, SeekOrigin.Begin);
            var iBlockCount = reader.ReadInt32();
            Debug.Assert(_blockList.Count == iBlockCount);

            //for (int i = 0; i < iBlockCount; i++)
            //{
            //    var linkBlockCount = reader.ReadInt32();
            //    for (int ii = 0; ii < linkBlockCount; ii++)
            //    {
            //        var block = _blockList[reader.ReadInt32()];
            //        // TODO: Add InternalEdge to Block
            //    }
            //}
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
            Length = reader.ReadInt32()
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

    private void ReadDunBlock(int index, Stream stream, NavMeshReader reader)
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


        var block = new NavMeshInstBlock
        {
            ID = index,
            Region = this.Region,
            Parent = null,
            NavMeshObj = NavMeshManager.LoadNavMeshObj(path),
            LocalPosition = position,
            LocalToWorld = localToWorld,
            WorldToLocal = worldToLocal,

            BoundingBox = boundingBox,
        };

        stream.Seek(20, SeekOrigin.Current);

        var blockHasHeightFog = reader.ReadBoolean();
        if (blockHasHeightFog)
            stream.Seek(16, SeekOrigin.Current);

        var blockHasUnknownVector = reader.ReadBoolean();
        if (blockHasUnknownVector)
            stream.Seek(28, SeekOrigin.Current);

        stream.Seek(reader.ReadInt32(), SeekOrigin.Current); //SeekOverString
        stream.Seek(8, SeekOrigin.Current);

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
                block.ObjectList.Add(new DungeonColObj
                {
                    Name = blockObjName,
                    Circle = new CircleF(blockObjPosition.ToVector2(), blockObjRadius),
                });
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

    public override NavMeshRaycastResult Raycast(NavMeshTransform src, NavMeshTransform dst, NavMeshRaycastType type, out NavMeshRaycastHit hit)
    {
        var block = (NavMeshInstBlock)src.Instance;

        var line = new LineF(src.Offset, dst.Offset);

        // TODO: Make this part of the NavMeshInstBlock Raycast logic as we're never really placed inside the Dungeon
        var distanceSrcToDst = Vector2.Distance(src.Offset.ToVector2(), dst.Offset.ToVector2());
        foreach (var obj in block.ObjectList)
        {
            var distanceSrcToObj = Vector2.Distance(src.Offset.ToVector2(), obj.Circle.Position);
            var distanceDstToObj = Vector2.Distance(dst.Offset.ToVector2(), obj.Circle.Position);
            var closestToObj = MathF.Max(distanceSrcToObj, distanceDstToObj);

            if (distanceSrcToDst + obj.Circle.Radius >= closestToObj)
            {
                // We found the closest circle now check if we collide and where.
                if (!obj.Circle.Intersects(line, out Vector2 intersectionPoint))
                    break;

                hit = null;
                return NavMeshRaycastResult.Collision;
            }
        }
        hit = null;
        return NavMeshRaycastResult.Reached;
    }
}