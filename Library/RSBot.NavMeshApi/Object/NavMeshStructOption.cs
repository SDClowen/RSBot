namespace RSBot.NavMeshApi.Object;

[Flags]
public enum NavMeshStructOption : int
{
    None = 0,
    Edge = 1,
    Cell = 2,
    Event = 4,
}
