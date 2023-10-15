using RSBot.Pk2;

namespace RSBot.Core.Components.Pk2;

public class ArchiveManager
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ArchiveManager" /> class.
    /// </summary>
    /// <param name="archive">The media PK2.</param>
    public ArchiveManager(PK2Archive archive)
    {
        Archive = archive;
    }

    /// <summary>
    ///     Gets or sets the Media.pk2 reader.
    /// </summary>
    /// <value>
    ///     The PK2 reader.
    /// </value>
    public PK2Archive Archive { get; set; }

    /// <summary>
    ///     Gets the file.
    /// </summary>
    /// <param name="filename">The filename.</param>
    public ArchiveFile GetFile(string filename, bool absolutePath = false)
    {
        return new ArchiveFile(filename, absolutePath);
    }

    /// <summary>
    ///     Files the exists.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <returns></returns>
    public bool FileExists(string filename)
    {
        return Archive?.FileExists(filename) ?? false;
    }

    /// <summary>
    ///     Loads the state.
    /// </summary>
    /// <param name="pk2">The PK2.</param>
    /// <returns></returns>
    public static ArchiveManager Initialize(string pk2)
    {
        var config = new PK2Config
        {
            Key = GlobalConfig.Get("RSBot.Pk2Key", "169841"),
            Mode = PK2Mode.Index,
            BaseKey = new byte[] { 0x03, 0xF8, 0xE4, 0x44, 0x88, 0x99, 0x3F, 0x64, 0xFE, 0x35 }
        };

        return new ArchiveManager(new PK2Archive(pk2, config));
    }
}