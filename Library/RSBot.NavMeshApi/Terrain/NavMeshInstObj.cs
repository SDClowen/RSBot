using System.Diagnostics;
using System.Numerics;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Object;

namespace RSBot.NavMeshApi.Terrain;

public class NavMeshInstObj : NavMeshInst
{
    public bool IsBig { get; private set; }
    public bool IsStruct { get; private set; }
    public int WorldUID { get; internal set; }

    public NavMeshInstObj(NavMesh parent)
    {
        this.Parent = parent;
    }

    internal void Read(NavMeshReader reader)
    {
        var index = reader.ReadInt32();
        if (!NavMeshManager.TryGetNavMeshObj(index, out NavMeshObj obj))
            Debug.WriteLine($"Couldn't find {nameof(Object.NavMeshObj)}#{index} for {nameof(NavMeshApi.NavMeshInst)}");
        this.NavMeshObj = obj;

        var localPosition = reader.ReadVector3();
        //while (localPosition.X >= RID.Width)
        //    localPosition.X -= RID.Width;

        //while (localPosition.X < 0.0f)
        //    localPosition.X += RID.Width;

        //while (localPosition.Z >= RID.Length)
        //    localPosition.Z -= RID.Length;

        //while (localPosition.Z < 0.0f)
        //    localPosition.Z += RID.Length;
        this.LocalPosition = localPosition;

        reader.ReadInt16(); //Type: -1 = Static, 0 = SkinedNavMesh?
        this.Yaw = reader.ReadFloat();
        this.ID = reader.ReadUInt16();

        reader.ReadUInt16(); //short0
        this.IsBig = reader.ReadBoolean(); //isBig
        this.IsStruct = reader.ReadBoolean(); //isStruct
        this.Region = reader.ReadUInt16();
        this.WorldUID = ((ushort)this.Region << 16) | this.ID;

        this.LocalToWorld = Matrix4x4.CreateRotationY(-this.Yaw) * Matrix4x4.CreateTranslation(localPosition);
        var result = Matrix4x4.Invert(this.LocalToWorld, out var worldToLocal);
        Debug.Assert(result, "Failed to invert LocalToWorld matrix");

        this.WorldToLocal = worldToLocal;

        var wLinkEdgeCount = reader.ReadInt16();
        for (int i = 0; i < wLinkEdgeCount; i++)
        {
            var link = new NavMeshLinkEdge
            {
                LinkedObjID = reader.ReadInt16(),
                LinkedObjEdgeID = reader.ReadInt16(),
                EdgeID = reader.ReadInt16(),
            };
            this.LinkEdges[link.EdgeID] = link;
        }
    }
}
