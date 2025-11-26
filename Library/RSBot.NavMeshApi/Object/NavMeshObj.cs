using System.Diagnostics;
using System.Numerics;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Extensions;
using RSBot.NavMeshApi.Mathematics;
using RSBot.NavMeshApi.Terrain;

namespace RSBot.NavMeshApi.Object;

public class NavMeshObj : NavMesh
{
    public override NavMeshType Type => NavMeshType.Object;

    public string Name { get; private set; }
    public NavMeshStructOption StructOption { get; set; }
    public override RID Region => RID.Empty;

    public List<NavMeshCellTri> Cells { get; } = new List<NavMeshCellTri>();

    public List<NavMeshEdge> Edges { get; } = new List<NavMeshEdge>();
    public List<NavMeshEdgeGlobal> GlobalEdges { get; } = new List<NavMeshEdgeGlobal>();

    public List<NavMeshEdgeInternal> InternalEdges { get; } = new List<NavMeshEdgeInternal>();
    public List<string> Events { get; } = new List<string>();
    public NavMeshObjGrid Grid { get; }
    public NavMeshVertex[] Vertices { get; private set; }
    public BoundingBoxF BoundingBox { get; private set; }
    public int IndexFlag { get; internal set; }

    public bool HasRailing { get; set; }
    public bool HasEntrance { get; set; }

    public NavMeshObj()
    {
        this.Grid = new NavMeshObjGrid(this);
    }

    public override string ToString()
    {
        return $"[{this.Type}] {this.Name}";
    }

    public void Load(Stream stream)
    {
        using (var reader = new NavMeshReader(stream))
        {
            var signature = reader.ReadString(12);
            if (signature != "JMXVBMS 0110")
                throw new Exception("Invalid signature");

            var header = new
            {
                VertexOffset = reader.ReadInt32(),
                SkinOffset = reader.ReadInt32(),
                FaceOffset = reader.ReadInt32(),
                ClothVertexOffset = reader.ReadInt32(),
                ClothEdgeOffset = reader.ReadInt32(),
                BoundingBoxOffset = reader.ReadInt32(),
                OcclusionPortalOffset = reader.ReadInt32(),
                NavMeshObjOffset = reader.ReadInt32(),
                SkinedNavMeshOffset = reader.ReadInt32(),
                Offset9 = reader.ReadInt32(),
                Int1 = reader.ReadInt32(),
                StructOption = (NavMeshStructOption)reader.ReadInt32(),
            };

            stream.Seek(4, SeekOrigin.Current); // SubPrimCount
            stream.Seek(4, SeekOrigin.Current); // VertexFlag
            stream.Seek(4, SeekOrigin.Current); // 0

            this.Name = reader.ReadString();

            this.StructOption = header.StructOption;
            if (header.NavMeshObjOffset == 0)
                throw new Exception("Failed to load NavMesh obj. (no data)");

            stream.Seek(header.BoundingBoxOffset, SeekOrigin.Begin);
            this.BoundingBox = reader.ReadBoundingBox();

            stream.Seek(header.NavMeshObjOffset, SeekOrigin.Begin);

            // Vertices
            var vertexCount = reader.ReadInt32();
            this.Vertices = new NavMeshVertex[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                this.Vertices[i] = new NavMeshVertex
                {
                    Index = i,
                    Position = reader.ReadVector3(),
                    Normal = NavMeshManager.NormalCache[reader.ReadByte()],
                };
            }

            // Cells
            var cellCount = reader.ReadInt32();
            this.Cells.Capacity = cellCount;
            for (int i = 0; i < cellCount; i++)
            {
                var v0 = this.Vertices[reader.ReadInt16()];
                var v1 = this.Vertices[reader.ReadInt16()];
                var v2 = this.Vertices[reader.ReadInt16()];
                var triangle = new TriangleF(v0.Position, v1.Position, v2.Position);
                //if (!triangle.IsClockwise)
                //{
                //    //var tmpVertex = v0;
                //    //v0 = v1;
                //    //v1 = v2;
                //    //v2 = tmpVertex;

                //    var tmpVertex = v0;
                //    v0 = v1;
                //    v1 = tmpVertex;
                //    triangle = new TriangleF(v0.Position, v1.Position, v2.Position);
                //    Debug.Assert(triangle.IsClockwise, "Eh?");
                //}

                var cell = new NavMeshCellTri
                {
                    NavMesh = this,
                    Index = i,
                    Vertex0 = v0,
                    Vertex1 = v1,
                    Vertex2 = v2,
                    Triangle = triangle,
                    Flag = reader.ReadInt16(),
                };
                Debug.Assert(cell.Flag == 0, $"{nameof(NavMeshCellTri)} with Flag = {cell.Flag} found!!!");
                //Debug.Assert(triangle.IsClockwise, $"{cell} in {this} is not CW!");

                if ((this.StructOption & NavMeshStructOption.Cell) != 0)
                    cell.EventZone = (NavMeshEventZone)reader.ReadByte();

                this.Cells.Add(cell);
            }

            // GlobalEdges
            var globalEdgeCount = reader.ReadInt32();
            this.GlobalEdges.Capacity = globalEdgeCount;
            for (int i = 0; i < globalEdgeCount; i++)
            {
                var v0 = this.Vertices[reader.ReadInt16()];
                var v1 = this.Vertices[reader.ReadInt16()];
                var edge = new NavMeshEdgeGlobal(this, i)
                {
                    Line = new LineF(v0.Position, v1.Position),
                    Normal = Vector3.Normalize(
                        new Vector3(v1.Position.Z - v0.Position.Z, 0.0f, v0.Position.X - v1.Position.X)
                    ),
                    SrcCellIndex = reader.ReadInt16(),
                    DstCellIndex = reader.ReadInt16(),
                    SrcSide = NavMeshCellSide.Invalid,
                    DstSide = NavMeshCellSide.Invalid,
                    SrcMeshIndex = -1,
                    DstMeshIndex = -1,
                    Vertex0 = v0,
                    Vertex1 = v1,
                    Flag = (NavMeshEdgeFlag)reader.ReadByte() | NavMeshEdgeFlag.Global,
                };

                //Debug.Assert((edge.Flag & NavMeshEdgeFlag.Entrance) == 0, $"Bit5 found in {nameof(NavMeshEdgeGlobal)} #{edge.Index} Obj:{this.Name}");
                Debug.Assert(
                    (edge.Flag & NavMeshEdgeFlag.Bit6) == 0,
                    $"Bit6 found in {nameof(NavMeshEdgeGlobal)} #{edge.Index} Obj:{this.Name}"
                );

                if ((this.StructOption & NavMeshStructOption.Edge) != 0)
                    edge.EventZone = (NavMeshEventZone)reader.ReadByte();

                // We found a railing edges, mark the object!
                if ( /*!this.HasRailing &&*/
                    edge.IsRailing
                )
                    this.HasRailing = true;

                // We found an entrance edges, mark the object!
                if ( /*!this.HasEntrance &&*/
                    (edge.Flag & NavMeshEdgeFlag.Blocked) == 0
                )
                    this.HasEntrance = true;

                edge.Link();

                // Check if we need to invert the normal to point outside
                // TODO: Is there a faster method to check if the normal is pointing outside or not?
                var edgeCenter = edge.Line.Center;
                edge.OffsetByEdgeNormal(edge.SrcCell, ref edgeCenter);
                if (edge.SrcCell.Contains(edgeCenter))
                    edge.Normal = -edge.Normal;

                this.Edges.Add(edge);
                this.GlobalEdges.Add(edge);
            }

            // InternalEdges
            var internalEdgeCount = reader.ReadInt32();
            this.InternalEdges.Capacity = internalEdgeCount;
            for (int iInternalEdge = 0; iInternalEdge < internalEdgeCount; iInternalEdge++)
            {
                var vi0 = reader.ReadInt16();
                var vi1 = reader.ReadInt16();
                var v0 = this.Vertices[vi0];
                var v1 = this.Vertices[vi1];

                var edge = new NavMeshEdgeInternal(this, iInternalEdge)
                {
                    Line = new LineF(v0.Position, v1.Position),
                    SrcCellIndex = reader.ReadInt16(),
                    DstCellIndex = reader.ReadInt16(),
                    SrcSide = NavMeshCellSide.Invalid,
                    DstSide = NavMeshCellSide.Invalid,
                    Vertex0 = v0,
                    Vertex1 = v1,
                    Flag = (NavMeshEdgeFlag)reader.ReadByte() | NavMeshEdgeFlag.Internal,
                };
                //Debug.Assert((edge.Flag & NavMeshEdgeFlag.Entrance) == 0, $"Bit5 found in {nameof(NavMeshEdgeInternal)} #{edge.Index} Obj:{this.Name}");
                Debug.Assert(
                    (edge.Flag & NavMeshEdgeFlag.Bit6) == 0,
                    $"Bit6 found in {nameof(NavMeshEdgeInternal)} #{edge.Index} Obj:{this.Name}"
                );

                if ((this.StructOption & NavMeshStructOption.Edge) != 0)
                    edge.EventZone = (NavMeshEventZone)reader.ReadByte();

                edge.Link();
                this.Edges.Add(edge);
                this.InternalEdges.Add(edge);
            }

            // Events
            if ((this.StructOption & NavMeshStructOption.Event) != 0)
            {
                var eventCount = reader.ReadInt32();
                this.Events.Capacity = eventCount;
                for (int i = 0; i < eventCount; i++)
                    this.Events.Add(reader.ReadString());
            }

            // Grid
            //StopwatchHelper.Begin("ObjGridLoad");
            this.Grid.Load(reader);
            //StopwatchHelper.End();
        }
    }

    public override NavMeshCell ResolveCellAndHeight(ref Vector3 vPos)
    {
        NavMeshCellTri result = null;

        var vPos2D = vPos.ToVector2();
        if (!this.Grid.Rectangle.Contains(vPos2D))
            return null;

        var minDeltaY = float.PositiveInfinity;
        var y = float.PositiveInfinity;
        var vTest = vPos;

        foreach (NavMeshCellTri cell in this.Cells)
        {
            if (cell.Triangle.FindHeight(ref vTest))
            {
                var deltaY = MathF.Abs(vTest.Y - vPos.Y);
                if (deltaY < minDeltaY)
                {
                    minDeltaY = deltaY;

                    result = cell;
                    y = vTest.Y;
                }
            }
        }

        vPos.Y = y;
        //if (result is not null && ((result.EventZone.Flag & NavMeshEventZoneFlag.All) != 0))
        //    NavMeshManager.EventZoneHandler?.Invoke(null, result.EventZone, result, null);
        return result;
    }

    public override NavMeshCell GetNavMeshCell(int index)
    {
        if (index < 0 || index >= this.Cells.Count)
            return null;

        return this.Cells[index];
    }

    public override NavMeshRaycastResult Raycast(
        NavMeshTransform src,
        NavMeshTransform dst,
        NavMeshRaycastType rayType,
        out NavMeshRaycastHit hit
    )
    {
        var curCell = (NavMeshCellTri)src.Cell;
        var prevCell = curCell;
        var instance = src.Instance;
        var line = new LineF(src.Offset, dst.Offset);
        var localLine = (instance.WorldToLocal).MultiplyLine(line);

        int raycastCount = 0;
        while (true)
        {
            //if (raycastCount++ > 100)
            //throw new Exception("raycastCount (obj) above 100");

            if (curCell == dst.Cell)
            {
                hit = null;
                return NavMeshRaycastResult.Reached;
            }

            NavMeshCellTri remoteCell = null;
            NavMeshEdge intersectionEdge = null;
            Vector3 intersectionPoint = Vector3.Zero;
            for (int i = 0; i < NavMeshCellTri.EDGES_MAX; i++)
            {
                var edge = curCell.GetEdge(i);
                if (edge == null)
                    continue;

                remoteCell = (NavMeshCellTri)edge.GetRemoteCell(curCell);
                if (remoteCell == prevCell)
                    continue; // do not backtrack.

                if (!edge.Intersects(localLine, out Vector3 point))
                    continue;

                // Found a suitable edge for intersection testing
                Debug.WriteLine($"NavMeshObj: Intersected with {edge}");

                intersectionEdge = edge;
                intersectionPoint = point;
                break;
            }

            // We haven't found a suitable edge, the destination may be unreachable.
            if (intersectionEdge == null)
            {
                // TODO: Maybe report a hit with the last known location?
                hit = null;
                return NavMeshRaycastResult.Reached;
            }

            // Check if the object can pass through this wall.
            var isBulletProof = rayType != NavMeshRaycastType.Attack || !intersectionEdge.IsSiege;
            var isOuterRailing = intersectionEdge.IsRailing && intersectionEdge.IsGlobalLinker;
            if (isBulletProof && (intersectionEdge.IsBlockedFrom(curCell) || isOuterRailing))
            {
                curCell.MoveTowardsCenter(ref intersectionPoint);
                hit = new NavMeshRaycastHit
                {
                    Cell = curCell,
                    Instance = instance,
                    Edge = intersectionEdge,
                    Position = instance.LocalToWorld.MultiplyPoint(intersectionPoint),
                    Region = instance.Parent.Region,
                };
                return NavMeshRaycastResult.Collision;
            }

            // Check if we hit an edge with an EventZone
            var eventZone = intersectionEdge.EventZone;
            if (
                (eventZone.Flag & NavMeshEventZoneFlag.All) != 0
                && (!(NavMeshManager.EventZoneHandler?.Invoke(instance, eventZone) ?? false))
            )
            {
                Debug.WriteLine(
                    $"EventZone ({instance.NavMeshObj.Events[eventZone.Index]}, {eventZone.Flag}) returned collision."
                );
                hit = new NavMeshRaycastHit
                {
                    Cell = curCell,
                    Instance = instance,
                    Edge = intersectionEdge,
                    Position = instance.LocalToWorld.MultiplyPoint(intersectionPoint),
                    Region = instance.Parent.Region,
                };
                return NavMeshRaycastResult.Collision;
            }

            if (remoteCell is not null)
            {
                // Check if remoteCell has an EventZone
                eventZone = remoteCell.EventZone;
                if (
                    (eventZone.Flag & NavMeshEventZoneFlag.All) != 0
                    && (!(NavMeshManager.EventZoneHandler?.Invoke(instance, eventZone) ?? false))
                )
                {
                    Debug.WriteLine(
                        $"EventZone ({instance.NavMeshObj.Events[eventZone.Index]}, {eventZone.Flag}) returned collision."
                    );
                    hit = new NavMeshRaycastHit
                    {
                        Cell = curCell,
                        Instance = instance,
                        Edge = intersectionEdge,
                        Position = instance.LocalToWorld.MultiplyPoint(intersectionPoint),
                        Region = instance.Parent.Region,
                    };
                    return NavMeshRaycastResult.Collision;
                }
            }

            // If remoteCell is NULL we've hit an outline edge
            if (remoteCell == null)
            {
                Debug.WriteLine("NavMeshObj: remoteCell was NULL, now trying to transition");

                if (instance.TryGetLinkEdge(intersectionEdge.Index, out NavMeshLinkEdge linkEdge))
                {
                    Debug.WriteLine($"NavMeshObj: trying to transiton via LinkEdge {linkEdge}");

                    var linkedInst = linkEdge.LinkedInst;
                    var linkedCell = linkEdge.LinkedCell;

                    // transform the intersection point to world space
                    var worldIntersectionPoint = Vector3.Transform(intersectionPoint, instance.LocalToWorld);

                    // transform the world space intersection point into the linked objects local space
                    var linkedObjFrom = Vector3.Transform(worldIntersectionPoint, linkEdge.LinkedInst.WorldToLocal);
                    var linkedObjTo = linkedCell.Triangle.Center;

                    // create a line to the linked cell center
                    var linkedObjLine = new LineF(linkedObjFrom, linkedObjTo);

                    NavMeshEdge linkedIntersectionEdge = null;
                    Vector3 linkedIntersectionPoint = Vector3.Zero;
                    for (int i = 0; i < NavMeshCellTri.EDGES_MAX; i++)
                    {
                        var edge = linkedCell.GetEdge(i);
                        if (edge == null)
                            continue;

                        if (!edge.Intersects(linkedObjLine, out linkedIntersectionPoint))
                            continue;

                        linkedIntersectionEdge = edge;
                        break;
                    }

                    // If we haven't found an intersection we're already inside the linkedCell due to overlap.
                    if (linkedIntersectionEdge == null)
                        linkedIntersectionPoint = linkedObjFrom;

                    // nudge the intersection point to the center
                    linkedCell.MoveTowardsCenter(ref linkedIntersectionPoint);

                    // update the position
                    src.Instance = linkedInst;
                    src.Cell = linkedCell;
                    src.Offset = Vector3.Transform(linkedIntersectionPoint, linkedInst.LocalToWorld);
                    src.Normalize();

                    // we're ready to transition
                    hit = null;
                    return NavMeshRaycastResult.Transition;
                }

                Debug.WriteLine($"NavMeshObj: trying to transtion to terrain");

                var outsidePoint = intersectionPoint; // vIntersection
                intersectionEdge.OffsetByEdgeNormal(curCell, ref outsidePoint);

                src.Offset = Vector3.Transform(outsidePoint, instance.LocalToWorld);
                src.Normalize();

                if (!NavMeshManager.TryGetNavMeshTerrain(src.Region, out NavMeshTerrain terrain))
                {
                    curCell.MoveTowardsCenter(ref intersectionPoint);
                    hit = new NavMeshRaycastHit
                    {
                        Cell = curCell,
                        Instance = instance,
                        Edge = intersectionEdge,
                        Region = instance.Parent.Region,
                        Position = instance.LocalToWorld.MultiplyPoint(intersectionPoint),
                    };
                    return NavMeshRaycastResult.Collision;
                }
                //src.Cell = terrain.ResolveCellAndHeight(ref src.Offset);
                terrain.ResolveCellAndHeight(src);

                hit = null;
                return NavMeshRaycastResult.Transition;
            }

            // Nothing blocked the ray, we can transition to remoteCell
            prevCell = curCell;
            curCell = remoteCell;
        }
    }
}
