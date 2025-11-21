namespace RSBot.NavMeshApi.Terrain;

public struct NavMeshTile
{
    public const float Width = 20.0f;
    public const float Length = 20.0f;

    public int CellIndex;
    public NavMeshTileFlag Flag;
    public short TextureID;

    public bool IsBlocked => (Flag & NavMeshTileFlag.Blocked) != 0;
}
