using RSBot.FileSystem.IO;
using RSBot.FileSystem.Local;
using RSBot.FileSystem.Local.IO;

namespace RSBot.FileSystem;

/// <inheritdoc />
public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string basePath, bool readOnly)
    {
        BasePath = basePath;
        ReadOnly = readOnly;

        Root = new LocalFolder("", this);
    }

    public bool ReadOnly { get; }

    /// <summary>
    ///     Gets the root folder of the local file system.
    /// </summary>
    public IFolder Root { get; }

    /// <summary>
    ///     Gets the base path for the local file system.
    /// </summary>
    public string BasePath { get; }

    /// <summary>
    ///     Gets the path separator for the local file system.
    /// </summary>
    public char PathSeparator => Path.DirectorySeparatorChar;

    public bool FileExists(string path)
    {
        var absolutePath = GetAbsolutePath(path);

        return File.Exists(absolutePath);
    }

    public bool FolderExists(string path)
    {
        var absolutePath = GetAbsolutePath(path);

        return Directory.Exists(absolutePath);
    }

    public IFile GetFile(string path)
    {
        AssertFileExists(path);

        return new LocalFile(path, this);
    }

    public IFolder GetFolder(string path)
    {
        AssertFolderExists(path);

        return new LocalFolder(path, this);
    }

    public IEnumerable<IFile> GetFiles(string folderPath)
    {
        AssertFolderExists(folderPath);

        var absolutePath = GetAbsolutePath(folderPath);

        var fileNames = Directory.GetFiles(absolutePath);
        var result = new List<IFile>(fileNames.Length);
        result.AddRange(fileNames.Select(GetRelativePath).Select(relativePath => new LocalFile(relativePath, this)));

        return result.ToArray();
    }

    public IFolder[] GetFolders(string folderPath)
    {
        AssertFolderExists(folderPath);

        var absolutePath = GetAbsolutePath(folderPath);

        var folderNames = Directory.GetDirectories(absolutePath);
        var result = new List<IFolder>(folderNames.Length);
        result.AddRange(
            folderNames.Select(GetRelativePath).Select(relativePath => new LocalFolder(relativePath, this))
        );

        return result.ToArray();
    }

    public string[] GetChildren(string folderPath)
    {
        AssertFolderExists(folderPath);

        var absolutePath = GetAbsolutePath(folderPath);

        var childrenNames = Directory.GetFileSystemEntries(absolutePath);
        var result = new string[childrenNames.Length];

        for (var iChild = 0; iChild < childrenNames.Length; iChild++)
            result[iChild] = GetRelativePath(childrenNames[iChild]);

        return result;
    }

    public IFileReader OpenRead(string path)
    {
        AssertFileExists(path);

        var absolutePath = GetAbsolutePath(path);

        return new LocalFileReader(File.OpenRead(absolutePath));
    }

    public IFileReader OpenRead(object entry)
    {
        if (entry is not LocalFolder folder)
            throw new ArgumentException("Entry should be of type LocalFolder.");

        return OpenRead(folder.Path);
    }

    /// <inheritdoc />s
    public bool TryGetFile(string path, out IFile? file)
    {
        try
        {
            file = GetFile(path);

            return true;
        }
        catch
        {
            file = default;

            return false;
        }
    }

    /// <inheritdoc />
    public bool TryGetFolder(string path, out IFolder? folder)
    {
        try
        {
            folder = GetFolder(path);

            return true;
        }
        catch
        {
            folder = default;

            return false;
        }
    }

    public IEnumerable<IFile> GetFileList(string parent, params string[] fileNames)
    {
        throw new NotSupportedException("The local filesystem doesn't support filename discovery yet!");
    }

    private string GetAbsolutePath(string path)
    {
        if (!path.StartsWith(PathSeparator))
            path = PathSeparator + path;

        if (path.Contains('/') && PathSeparator != '/')
            path = path.Replace('/', PathSeparator);

        if (path.Contains('\\') && PathSeparator != '\\')
            path = path.Replace('\\', PathSeparator);

        return BasePath + path;
    }

    private string GetRelativePath(string absolutePath)
    {
        if (!absolutePath.StartsWith(BasePath))
            return absolutePath;

        var relativePathOffset = BasePath.Length + 1;
        var relativePathLength = absolutePath.Length - BasePath.Length - 1;

        var relativePath = absolutePath.Substring(relativePathOffset, relativePathLength);

        return relativePath;
    }

    private void AssertFolderExists(string path)
    {
        if (!FolderExists(path))
            throw new DirectoryNotFoundException($"The folder {path} does not exist.");
    }

    private void AssertFileExists(string path)
    {
        if (!FileExists(path))
            throw new FileNotFoundException($"The file {path} does not exist.");
    }

    public void Dispose() { }
}
