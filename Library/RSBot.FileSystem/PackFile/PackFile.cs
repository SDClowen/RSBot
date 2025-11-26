using RSBot.FileSystem.IO;
using RSBot.FileSystem.PackFile.Struct;

namespace RSBot.FileSystem.PackFile;

public class PackFile : IFile
{
    public readonly PackEntry Entry;

    public PackFile(string path, PackEntry entry, IFileSystem fileSystem)
    {
        Path = path;
        FileSystem = fileSystem;
        Entry = entry;
    }

    public long CreateTime => Entry.CreationTime;
    public long ModifyTime => Entry.ModifyTime;

    public IFileSystem FileSystem { get; }
    public string Path { get; }
    public string Name => Entry.Name;
    public string Extension => System.IO.Path.GetExtension(Name);

    public long Size => Entry.Size;

    public IFolder Parent => FileSystem.GetFolder(System.IO.Path.GetDirectoryName(Path) ?? "");

    public IFileReader OpenRead()
    {
        return FileSystem.OpenRead(Entry);
    }

    public override string ToString()
    {
        return Path;
    }
}
