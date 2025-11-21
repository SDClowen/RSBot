namespace RSBot.NavMeshApi.Terrain;

public struct NavMeshPlane
{
    // 20.0 * 16 = 320.0

    public const float Width = 320.0f;
    public const float Length = 320.0f;

    public NavMeshPlaneType Type { get; set; }
    public float Height { get; set; }
}
