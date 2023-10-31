using RSBot.FileSystem.PackFile.Struct;

namespace RSBot.FileSystem.PackFile;

internal class PackResolver
{
    private readonly PackReader _packReader;
    private readonly char _pathSeparator;

    private readonly Dictionary<string, IEnumerable<PackBlock>> _blocksInMemory;
    private readonly Dictionary<string, PackEntry> _filesInMemory;

    public PackResolver(PackReader packReader, char pathSeparator = '\\')
    {
        _packReader = packReader;
        _pathSeparator = pathSeparator;

        Root = packReader.ReadBlocksAt(256);

        //Add root block to memory
        _blocksInMemory = new Dictionary<string, IEnumerable<PackBlock>>(128)
        {
            [""] = Root
        };

        _filesInMemory = new Dictionary<string, PackEntry>(128);
    }

    public IEnumerable<PackBlock> Root { get; }

    public IEnumerable<PackBlock> ResolveBlock(string path)
    {
        path = PathUtil.Prepare(path);

        if (_blocksInMemory.TryGetValue(path, out var block))
            return block;

        var paths = ExplodePath(path);

        var lastBlocks = _blocksInMemory[""];
        var currentPath = string.Empty;

        foreach (var subFolderName in paths)
        {
            //Search in all blocks for the subfolder
            var subFolderEntry = lastBlocks.GetEntries()
                .FirstOrDefault(e => e.Name == subFolderName && e.Type == PackEntryType.Folder);

            //Path not found
            if (subFolderEntry == null)
                return Array.Empty<PackBlock>();

            currentPath = PathUtil.Append(currentPath, subFolderName);

            if (!_blocksInMemory.TryGetValue(currentPath, out lastBlocks))
                lastBlocks = _packReader.ReadBlocksAt(subFolderEntry.DataPosition);

            if (!_blocksInMemory.ContainsKey(currentPath))
                _blocksInMemory.TryAdd(currentPath, lastBlocks);
        }

        return lastBlocks;
    }

    public PackEntry? ResolveFile(string path)
    {
        path = PathUtil.Prepare(path);

        if (_filesInMemory.TryGetValue(path, out var file))
            return file;

        var folder = PathUtil.GetFolderName(path);

        var fileName = PathUtil.GetFileName(path);
        var resolvedFolderBlock = ResolveBlock(folder);

        var entries = resolvedFolderBlock.GetEntries();
        var entry =
            entries.FirstOrDefault(e => e.Type == PackEntryType.File && e.Name == fileName);

        if (entry == null)
            return null;

        _filesInMemory.Add(path, entry);

        return entry;
    }

    private string[] ExplodePath(string path)
    {
        return path.Split(_pathSeparator);
    }
}