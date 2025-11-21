using System.Numerics;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi;

public class NavMeshRaycastHit
{
    public RID Region { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 World => this.Region.Position + this.Position;
    public NavMeshEdge? Edge { get; set; }
    public NavMeshCell Cell { get; set; }
    public NavMeshInst Instance { get; set; }
    public NavMesh NavMesh => this.Cell?.NavMesh;

    public override string ToString() => $"{this.NavMesh} -> [{this.Cell}; {this.Edge}; {this.Instance}]";
}
