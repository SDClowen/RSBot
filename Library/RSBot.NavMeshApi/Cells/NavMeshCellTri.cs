using System.Diagnostics;
using System.Numerics;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Extensions;
using RSBot.NavMeshApi.Mathematics;
using RSBot.NavMeshApi.Object;

namespace RSBot.NavMeshApi.Cells;

[DebuggerDisplay("NavMeshCellTri: {Index}")]
public class NavMeshCellTri : NavMeshCell
{
    public const int EDGES_MAX = 3;

    public TriangleF Triangle { get; set; }
    public short Flag { get; set; }

    public NavMeshEdge[] _edges = new NavMeshEdge[EDGES_MAX];

    public override IEnumerable<NavMeshEdge> Edges => _edges;

    public NavMeshEdge GetEdge(int index) => _edges[index];

    public NavMeshVertex Vertex0 { get; internal set; }
    public NavMeshVertex Vertex1 { get; internal set; }
    public NavMeshVertex Vertex2 { get; internal set; }
    public NavMeshEventZone EventZone { get; internal set; }

    internal override void AddEdge(NavMeshEdge edge, NavMeshCellSide direction)
    {
        Debug.Assert(direction == NavMeshCellSide.Invalid);
        if (this.EdgeCount < EDGES_MAX)
            _edges[this.EdgeCount++] = edge;
    }

    public override void MoveTowardsCenter(ref Vector3 vPos) => this.Triangle.MoveTowardsCenter(ref vPos);

    public override bool Contains(Vector3 vPos) => this.Triangle.Contains(vPos.ToVector2());

    public override string ToString() => $"TC:{this.Index}";
}
