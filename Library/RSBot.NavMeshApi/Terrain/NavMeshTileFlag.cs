namespace RSBot.NavMeshApi.Terrain;

[Flags]
public enum NavMeshTileFlag : short
{
    None = 0,
    Blocked = 1,
    Blue = 2, // Seems to be painted under bridges
    //Flag4 = 4, // 0 samples
    //Flag8 = 8,

    // This could actually be the 1 bit of a seperate byte flag
    //Flag256 = 256,
    //Flag512 = 512,
    //Flag1024 = 1024,
}
