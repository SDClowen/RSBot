namespace RSBot.NavMeshApi.Object;

[Flags]
public enum NavMeshEventZoneFlag
{
    None = 0,
    Bit0 = 1 << 0,
    Bit1 = 1 << 1,

    All = Bit0 | Bit1,
}
