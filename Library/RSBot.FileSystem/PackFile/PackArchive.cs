using RSBot.FileSystem.PackFile.Cryptography;
using RSBot.FileSystem.PackFile.Struct;

namespace RSBot.FileSystem.PackFile;

internal class PackArchive
{
    public const string ShadowRootName = "";
    public const string ShadowRootPath = "";

    private readonly PackResolver _packResolver;

    /// <summary>
    ///     Creates a new instance of <see cref="PackArchive" />
    /// </summary>
    /// <param name="header">The header of the pack file.</param>
    /// <param name="blowfish">The cryptographic blowfish for this pack file or null if the file is not encrypted.</param>
    /// <param name="resolver"></param>
    /// <param name="pathSeparator">The character to determine path separation.</param>
    public PackArchive(PackHeader header, Blowfish? blowfish, PackResolver resolver, char pathSeparator = '\\')
    {
        Header = header;
        Blowfish = blowfish;
        PathSeparator = pathSeparator;

        _packResolver = resolver;
    }

    #region Properties

    /// <summary>
    ///     Gets the character that determines path separation.
    /// </summary>
    public char PathSeparator { get; }

    /// <summary>
    ///     Gets the header of this pack file.
    /// </summary>
    public PackHeader Header { get; }

    /// <summary>
    ///     Gets the cryptographic blowfish for this pack file.
    ///     Can be null if the pack file is not encrypted.
    /// </summary>
    public Blowfish? Blowfish { get; }

    #endregion

    #region Methods

    /// <summary>
    ///     Returns a pack block by its path.
    /// </summary>
    /// <param name="path">The path to the pack block.</param>
    /// <returns>The found pack block or null if the path does not exist.</returns>
    public PackEntry? GetEntry(string path)
    {
        if (path is ShadowRootPath or null)
            return GetShadowRoot();

        return _packResolver.ResolveFile(path);
    }

    public IEnumerable<PackBlock> GetBlock(string path)
    {
        if (path is ShadowRootPath or null)
            return _packResolver.Root;

        return _packResolver.ResolveBlock(path);
    }

    public bool TryGetEntry(string path, out PackEntry? entry)
    {
        try
        {
            entry = GetEntry(path);

            return true;
        }
        catch
        {
            entry = null;

            return false;
        }
    }

    public bool TryGetBlock(string path, out IEnumerable<PackBlock>? block)
    {
        try
        {
            block = GetBlock(path);

            return true;
        }
        catch
        {
            block = null;

            return false;
        }
    }

    /// <summary>
    ///     Returns a collection of child entries for the given path.
    /// </summary>
    /// <param name="path">The path of the folder.</param>
    /// <returns></returns>
    public IEnumerable<PackEntry> GetEntries(string path)
    {
        var entry = GetEntry(path);
        if (entry == null)
            return Array.Empty<PackEntry>();

        var block = _packResolver.ResolveBlock(path);

        return block == null ? Array.Empty<PackEntry>() : block.GetEntries();
    }

    public IEnumerable<PackEntry> GetEntryListByNames(string parent, params string[] fileNames)
    {
        return _packResolver.ResolveFileList(parent, fileNames);
    }

    /// <summary>
    ///     Returns the default shadow root block. The block points to the root block at position 256.
    /// </summary>
    /// <returns></returns>
    private PackEntry GetShadowRoot()
    {
        return new PackEntry
        {
            CreationTime = DateTime.Now.Ticks,
            DataPosition = 256,
            ModifyTime = DateTime.Now.Ticks,
            Name = ShadowRootName,
            NextBlock = 0,
            Payload = new byte[2],
            Size = 0,
            Type = PackEntryType.Folder,
        };
    }

    #endregion
}
