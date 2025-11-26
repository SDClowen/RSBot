namespace RSBot.Core.Objects;

public enum GuideTeleportType : byte
{
    /// <summary>
    ///     Teleport to last recall point
    /// </summary>
    Recall = 2,

    /// <summary>
    ///     Teleport to place where you died.
    /// </summary>
    Death = 3,
}
