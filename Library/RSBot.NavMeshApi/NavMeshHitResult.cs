namespace RSBot.NavMeshApi;

[Flags]
public enum NavMeshHitResult
{
    None = 0,
    Terrain = 1,
    Object = 2,
    Any = Terrain | Object,
}
