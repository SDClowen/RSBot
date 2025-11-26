using RSBot.NavMeshApi.Terrain;

namespace RSBot.NavMeshApi.Edges;

public class NavMeshEdgeGlobal : NavMeshEdge
{
    public short SrcMeshIndex { get; set; }
    public short DstMeshIndex { get; set; }

    public NavMesh SrcMesh { get; set; }
    public NavMesh DstMesh { get; set; }

    public NavMeshEdgeGlobal(NavMesh mesh, int index)
        : base(mesh, index) { }

    public override void Read(NavMeshReader reader)
    {
        base.Read(reader);

        this.SrcMeshIndex = reader.ReadInt16();
        this.DstMeshIndex = reader.ReadInt16();
    }

    public override void Link()
    {
        this.SrcCell = this.NavMesh.GetNavMeshCell(this.SrcCellIndex);
        this.SrcCell.AddEdge(this, this.SrcSide);

        if ((this.Flag & NavMeshEdgeFlag.Blocked) == 0 && this.DstMeshIndex > 0)
        {
            if (!NavMeshManager.TryGetNavMeshTerrain(this.DstMeshIndex, out NavMeshTerrain dstNavMesh))
                return;

            this.DstCell = dstNavMesh.Cells[this.DstCellIndex];
            //this.DstCell.AddEdge(this, this.DstDirection);
        }
    }
}
