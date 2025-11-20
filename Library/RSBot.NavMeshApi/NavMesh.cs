using System.Numerics;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi;

public abstract class NavMesh
{
    public abstract NavMeshType Type { get; }
    public abstract RID Region { get; }

    public virtual NavMeshCell GetNavMeshCell(int index) => throw new NotImplementedException();

    public virtual NavMeshCell ResolveCellAndHeight(ref Vector3 offset) => throw new NotImplementedException();

    public virtual bool ResolveCellAndHeight(NavMeshTransform position) => throw new NotImplementedException();

    public virtual NavMeshRaycastResult Raycast(
        NavMeshTransform src,
        NavMeshTransform dst,
        NavMeshRaycastType type,
        out NavMeshRaycastHit hit
    ) => throw new NotImplementedException();

    public override string ToString() => $"[{this.Type}] {this.Region}";
}
