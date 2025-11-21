namespace RSBot.NavMeshApi.Terrain;

[Flags]
public enum NavMeshPlaneType : byte
{
    Solid = 0,
    Water = 1,
    Ice = 2,
}
