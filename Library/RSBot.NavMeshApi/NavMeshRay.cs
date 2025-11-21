namespace RSBot.NavMeshApi;

public struct NavMeshRay
{
    public NavMeshTransform Source { get; set; }
    public NavMeshTransform Destination { get; set; }
    public NavMeshRaycastType Type { get; set; }
}
