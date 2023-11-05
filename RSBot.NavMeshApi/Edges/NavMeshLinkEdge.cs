using NavMeshApi.Cells;

namespace NavMeshApi.Edges;

public class NavMeshLinkEdge
{
    public short LinkedObjID { get; set; }
    public short LinkedObjEdgeID { get; set; }
    public short EdgeID { get; set; }

    public NavMeshInst LinkedInst { get; set; }
    public NavMeshEdgeGlobal LinkedObjEdge { get; set; }
    public NavMeshCellTri LinkedCell => (NavMeshCellTri)this.LinkedObjEdge.SrcCell;
    public NavMeshEdgeGlobal Edge { get; set; }
    public NavMeshCellTri Cell => (NavMeshCellTri)this.Edge.SrcCell;
}