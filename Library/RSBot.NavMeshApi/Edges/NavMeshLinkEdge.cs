using RSBot.NavMeshApi.Cells;

namespace RSBot.NavMeshApi.Edges;

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

    public override string ToString()
    {
        return $"{this.LinkedInst}: {this.Cell}-{this.Edge} --> {this.LinkedObjEdge}-{this.LinkedCell}";
    }
}
