namespace RSBot.FileSystem.PackFile.Struct;

public enum PackEntryType : byte
{
    /// <summary>
    ///     For NOP entries.
    /// </summary>
    Nop = 0,

    /// <summary>
    ///     For folder entries.
    /// </summary>
    Folder = 1,

    /// <summary>
    ///     For file entries.
    /// </summary>
    File = 2,
}
