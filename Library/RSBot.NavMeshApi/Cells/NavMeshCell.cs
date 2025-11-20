using System.Diagnostics;
using System.Numerics;
using RSBot.NavMeshApi.Edges;

namespace RSBot.NavMeshApi.Cells;

[DebuggerDisplay("NavMeshCell: {Index}")]
public abstract class NavMeshCell
{
    public NavMesh NavMesh { get; set; }
    public int Index { get; set; }

    public int EdgeCount { get; private protected set; }

    internal abstract void AddEdge(NavMeshEdge edge, NavMeshCellSide direction);

    public abstract IEnumerable<NavMeshEdge> Edges { get; }

    public abstract void MoveTowardsCenter(ref Vector3 vPos);

    public override string ToString()
    {
        return $"C:{this.Index}";
    }

    public abstract bool Contains(Vector3 position);
}
