using System.Numerics;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Mathematics;
using RSBot.NavMeshApi.Object;

namespace RSBot.NavMeshApi.Edges;

[System.Diagnostics.DebuggerDisplay(
    "{Index} = {Flag} ({SrcCellIndex} [{SrcDirection}] -> {DstCellIndex} [{DstDirection}])"
)]
public abstract class NavMeshEdge
{
    public NavMesh NavMesh { get; set; }
    public int Index { get; set; }

    public NavMeshEdgeFlag Flag { get; set; }
    public NavMeshCellSide SrcSide { get; set; }
    public NavMeshCellSide DstSide { get; set; }

    public LineF Line { get; set; }
    public Vector3 Normal { get; set; }
    public short SrcCellIndex { get; set; }
    public short DstCellIndex { get; set; }

    public NavMeshCell SrcCell { get; set; }
    public NavMeshCell DstCell { get; set; }

    public bool HasNeighbour => !(this.SrcCell == null || this.DstCell == null);
    public bool IsGlobalLinker => (this.Flag & NavMeshEdgeFlag.Global) != 0;
    public bool IsLocalLinker => (this.Flag & NavMeshEdgeFlag.Internal) != 0;
    public bool IsBlocked => (this.Flag & NavMeshEdgeFlag.Blocked) != 0;
    public bool IsRailing => (this.Flag & NavMeshEdgeFlag.Railing) != 0;
    public bool IsEntrance => (this.Flag & NavMeshEdgeFlag.Entrance) != 0;
    public bool IsBit6 => (this.Flag & NavMeshEdgeFlag.Bit6) != 0;
    public bool IsSiege => (this.Flag & NavMeshEdgeFlag.Siege) != 0;

    public NavMeshVertex Vertex0 { get; internal set; } // obj only
    public NavMeshVertex Vertex1 { get; internal set; }
    public NavMeshEventZone EventZone { get; internal set; }

    protected NavMeshEdge(NavMesh mesh, int index)
    {
        this.NavMesh = mesh;
        this.Index = index;
    }

    public abstract void Link();

    internal NavMeshCellSide GetSide(NavMeshCell cell)
    {
        if (this.SrcCell == cell)
            return this.SrcSide;

        return this.DstSide;
    }

    public NavMeshCell GetRemoteCell(NavMeshCell cell)
    {
        if (this.SrcCell == cell)
            return this.DstCell;

        return this.SrcCell;
    }

    public bool IsBlockedFrom(NavMeshCell cell)
    {
        return this.SrcCell == cell
            ? (this.Flag & NavMeshEdgeFlag.BlockSrc2Dst) != 0
            : (this.Flag & NavMeshEdgeFlag.BlockDst2Src) != 0;
    }

    public virtual void Read(NavMeshReader reader)
    {
        this.Line = reader.ReadLine2D();

        this.Flag = (NavMeshEdgeFlag)reader.ReadByte();
        this.SrcSide = (NavMeshCellSide)reader.ReadByte();
        this.DstSide = (NavMeshCellSide)reader.ReadByte();
        this.SrcCellIndex = reader.ReadInt16();
        this.DstCellIndex = reader.ReadInt16();
    }

    internal NavMeshCell GetNavMeshCell(int index)
    {
        if (index == 0)
        {
            return this.SrcCell;
        }
        else if (index == 1)
        {
            return this.DstCell;
        }

        return null;
    }

    public bool Intersects(LineF line, out Vector3 point) => this.Line.Intersects(line, out point);

    public void OffsetByEdgeNormal(NavMeshCell cell, ref Vector3 point)
    {
        const float EDGE_DISPLACE_MULTIPLER = 0.009999999776482582f;
        //const float EDGE_DISPLACE_MULTIPLER = 0.01f;

        if (this.SrcCell == cell)
        {
            point += this.Normal * EDGE_DISPLACE_MULTIPLER;
            return;
        }

        point -= this.Normal * EDGE_DISPLACE_MULTIPLER;
    }

    public override string ToString()
    {
        if (this.IsGlobalLinker)
        {
            return $"GE:{this.Index}";
        }
        else if (this.IsLocalLinker)
        {
            return $"IE:{this.Index}";
        }
        else
        {
            return $"E:{this.Index}";
        }
    }
}
