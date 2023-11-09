﻿using NavMeshApi.Cells;
using NavMeshApi.Edges;
using NavMeshApi.Mathematics;
using NavMeshApi.Object;

using System.Numerics;

namespace NavMeshApi;

public abstract class NavMeshInst
{
    public NavMesh Parent { get; set; }
    public NavMeshObj NavMeshObj { get; set; }

    public int ID { get; set; }
    public Vector3 LocalPosition { get; set; }
    public Matrix4x4 LocalToWorld { get; set; }
    public Matrix4x4 WorldToLocal { get; set; }

    public Dictionary<int, NavMeshLinkEdge> LinkEdges { get; } = new Dictionary<int, NavMeshLinkEdge>();
    public Region Region { get; set; }
    public float Yaw { get; set; }

    public bool TryGetNavMeshCell(ref Vector3 position, out NavMeshCell cell)
    {
        var localPosition = Vector3.Transform(position, this.WorldToLocal);
        cell = this.NavMeshObj.ResolveCellAndHeight(ref localPosition);
        if (cell == null)
            return false;

        position = Vector3.Transform(localPosition, this.LocalToWorld);
        return true;
    }

    public NavMeshEdgeInternal GetInternalEdgeByID(short edgeID) => this.NavMeshObj?.InternalEdges[edgeID];

    public NavMeshEdgeGlobal GetGlobalEdgeByID(short edgeID) => this.NavMeshObj?.GlobalEdges[edgeID];

    public override string ToString() => $"INS:{this.ID} ({this.NavMeshObj?.Name})";

    public bool TryGetLinkEdge(int edgeID, out NavMeshLinkEdge linkEdge) => this.LinkEdges.TryGetValue(edgeID, out linkEdge);
}