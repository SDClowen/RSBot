using RSBot.FileSystem.IO;

namespace RSBot.FileSystem;

public interface IFile
{
    #region Properties

    public string Path { get; }
    public string Name { get; }
    public string Extension { get; }
    public long Size { get; }
    public IFileSystem FileSystem { get; }
    public IFolder Parent { get; }

    public long CreateTime { get; }
    public long ModifyTime { get; }

    #endregion

    #region Methods

    public IFileReader OpenRead();

    public byte[] Read(int position, int length)
    {
        return OpenRead().Read(position, length);
    }

    public string ReadAllText()
    {
        return OpenRead().ReadAllText();
    }

    public byte[] ReadAllBytes()
    {
        return OpenRead().ReadAllBytes();
    }

    public string[] ReadAllLines()
    {
        return OpenRead().ReadAllText().Split(Environment.NewLine);
    }

    #endregion
}
