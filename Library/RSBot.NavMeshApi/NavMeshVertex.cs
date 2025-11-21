using System.Numerics;

namespace RSBot.NavMeshApi;

public class NavMeshVertex
{
    public int Index { get; set; }
    public Vector3 Position { get; set; }
    public Vector2 Normal { get; set; }
}
