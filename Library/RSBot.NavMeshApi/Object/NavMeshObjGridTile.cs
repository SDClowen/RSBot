using System.Numerics;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi.Object;

public class NavMeshObjGridTile
{
    public const float Width = 100.0f;
    public const float Height = 100.0f;

    public static readonly Vector2 Size = new Vector2(Width, Height);

    private readonly NavMeshObjGrid _grid;
    private readonly HashSet<NavMeshEdgeGlobal> _globalEdges = new HashSet<NavMeshEdgeGlobal>();
    private readonly HashSet<NavMeshEdgeInternal> _internalEdge = new HashSet<NavMeshEdgeInternal>();
    private readonly HashSet<NavMeshCellTri> _cells = new HashSet<NavMeshCellTri>();

    public int Index { get; }
    public int X => this.Index % _grid.Width;
    public int Y => this.Index / _grid.Width;
    public RectangleF Rectangle { get; }

    public IReadOnlyCollection<NavMeshEdgeGlobal> GlobalEdges => _globalEdges;
    public IReadOnlyCollection<NavMeshEdgeInternal> InternalEdges => _internalEdge;
    public IReadOnlyCollection<NavMeshCellTri> Cells => _cells;

    public bool IsEmpty => this.Cells.Count == 0;

    public NavMeshObjGridTile(NavMeshObjGrid grid, int index)
    {
        _grid = grid;
        this.Index = index;
        this.Rectangle = new RectangleF(
            _grid.Origin.X + (this.X * Width),
            _grid.Origin.Y + (this.Y * Height),
            Width,
            Height
        );
    }

    public bool AddGlobalEdge(NavMeshEdgeGlobal edge) => _globalEdges.Add(edge);

    public bool AddInternalEdge(NavMeshEdgeInternal edge) => _internalEdge.Add(edge);

    public bool AddCell(NavMeshCellTri cell) => _cells.Add(cell);

    public override string ToString()
    {
        return $"GT:{this.Index} [{this.X}x{this.Y}]";
    }
}
