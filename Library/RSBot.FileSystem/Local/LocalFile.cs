using RSBot.FileSystem.IO;

namespace RSBot.FileSystem.Local;

public class LocalFile : IFile
{
    private readonly FileInfo _fileInfo;

    public LocalFile(string filePath, IFileSystem fileSystem)
    {
        Path = filePath;
        FileSystem = fileSystem;

        _fileInfo = new FileInfo(filePath);
    }

    public IFileSystem FileSystem { get; }
    public IFolder Parent => FileSystem.GetFolder(System.IO.Path.GetDirectoryName(Path) ?? "");
    public string Path { get; }
    public string Name => _fileInfo.Name;
    public string Extension => _fileInfo.Extension;
    public long Size => _fileInfo.Length;

    public long CreateTime => _fileInfo.CreationTime.Ticks;

    public long ModifyTime => _fileInfo.LastWriteTime.Ticks;

    public IFileReader OpenRead()
    {
        return FileSystem.OpenRead(Path);
    }
}
