namespace RSBot.FileSystem;

public interface IFolder
{
    #region Properties

    public string Path { get; }

    public string Name { get; }

    public IFolder Parent { get; }

    public IFileSystem FileSystem { get; }

    public long CreationTime { get; }

    public long ModifyTime { get; }

    #endregion

    #region Methods

    public IFolder[] GetFolders();
    public IEnumerable<IFile> GetFiles();
    public string[] GetChildren();

    #endregion
}
