using System.Diagnostics;
using System.Numerics;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Mathematics;
using RSBot.NavMeshApi.Terrain;

namespace RSBot.NavMeshApi.Cells;

[DebuggerDisplay("NavMeshCellQuad: {Index}")]
public class NavMeshCellQuad : NavMeshCell
{
    public RectangleF RectangleF { get; set; }

    private readonly HashSet<NavMeshEdge> _edges = new HashSet<NavMeshEdge>();
    public override IEnumerable<NavMeshEdge> Edges => _edges;

    public List<NavMeshInstObj> Instances { get; set; } = new List<NavMeshInstObj>();

    public bool IsBlocked { get; set; }

    public NavMeshCellQuad(NavMeshTerrain mesh, int index)
    {
        this.NavMesh = mesh;
        this.Index = index;
    }

    internal override void AddEdge(NavMeshEdge edge, NavMeshCellSide side)
    {
        Debug.Assert(side != NavMeshCellSide.Invalid);

        _edges.Add(edge);
        this.EdgeCount++;
    }

    public override void MoveTowardsCenter(ref Vector3 vPos) => this.RectangleF.MoveTowardsCenter(ref vPos);

    public Vector3 MoveTowardsCenter(Vector3 vPos) => this.RectangleF.MoveTowardsCenter(vPos);

    public override bool Contains(Vector3 pos) => this.RectangleF.Contains(pos);

    public override string ToString() => $"QC:{this.Index}";
}
