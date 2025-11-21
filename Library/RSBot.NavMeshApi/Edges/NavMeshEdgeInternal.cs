using System.Diagnostics;

namespace RSBot.NavMeshApi.Edges;

public class NavMeshEdgeInternal : NavMeshEdge
{
    public NavMeshEdgeInternal(NavMesh mesh, int index)
        : base(mesh, index) { }

    public override void Link()
    {
        this.SrcCell = this.NavMesh.GetNavMeshCell(this.SrcCellIndex);
        if (this.SrcCell == null)
            Debug.WriteLine($"Couldn't find SrcCellIndex {this.SrcCellIndex} on {this.NavMesh} when linking {this}");
        this.SrcCell?.AddEdge(this, this.SrcSide);

        if ( /*!this.IsBlocked &&*/
            this.DstCellIndex > 0
        )
        {
            this.DstCell = this.NavMesh.GetNavMeshCell(this.DstCellIndex);
            if (this.DstCell == null)
                Debug.WriteLine(
                    $"Couldn't find DstCellIndex {this.DstCellIndex} on {this.NavMesh} when linking {this}"
                );
            this.DstCell.AddEdge(this, this.DstSide);
        }
    }
}
