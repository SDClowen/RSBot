using System.IO;
using RSBot.Pk2.Types;

namespace RSBot.Core.Components.Pk2;

public class ArchiveFile
{
    /// <summary>
    ///     Gets or sets the pk2 file.
    /// </summary>
    /// <value>
    ///     The pk2 file.
    /// </value>
    private readonly PK2File _file;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArchiveFile" /> class.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="isPk2File">if set to <c>true</c> [is PK2 file].</param>
    public ArchiveFile(string path, bool absolutePath = false)
    {
        Path = path;
        _file = Game.MediaPk2.Archive.GetFile(path, absolutePath);
    }

    /// <summary>
    ///     Gets or sets the path.
    /// </summary>
    /// <value>
    ///     The path.
    /// </value>
    public string Path { get; set; }

    /// <summary>
    ///     If file null <c>false</c> otherwise <c>true</c>
    /// </summary>
    public bool IsValid => _file != null;

    /// <summary>
    ///     Gets the data.
    /// </summary>
    public byte[] GetData()
    {
        return _file.GetData();
    }

    /// <summary>
    ///     Read all text.
    /// </summary>
    /// <returns></returns>
    public string ReadAllText()
    {
        return _file.ReadAllText();
    }

    /// <summary>
    ///     Gets the stream.
    /// </summary>
    /// <returns></returns>
    public Stream GetStream()
    {
        return _file.GetStream();
    }
}