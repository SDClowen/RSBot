using System.Diagnostics;
using System.Text;
using RSBot.FileSystem.IO;
using RSBot.FileSystem.PackFile;
using RSBot.FileSystem.PackFile.Cryptography;
using RSBot.FileSystem.PackFile.IO;
using RSBot.FileSystem.PackFile.Struct;

namespace RSBot.FileSystem;

public class PackFileSystem : IFileSystem
{
    private void AssertFileExists(string path)
    {
        if (!this.FileExists(path))
            throw new FileNotFoundException($"The file {path} does not exist.");
    }

    private void AssertFolderExists(string path)
    {
        if (path != this.Root.Path && !this.FolderExists(path))
            throw new DirectoryNotFoundException($"The folder {path} does not exist.");
    }

    #region Properties

    /// <inheritdoc />
    public IFolder Root =>
        new PackFolder(
            "",
            new PackEntry
            {
                CreationTime = DateTime.Now.Ticks,
                ModifyTime = DateTime.Now.Ticks,
                DataPosition = 256,
                Name = string.Empty,
                NextBlock = 0,
                Size = 0,
                Type = PackEntryType.Folder,
            },
            this
        );

    /// <inheritdoc />
    public string BasePath { get; }

    /// <inheritdoc />
    public char PathSeparator => '\\';

    public Encoding Encoding { get; set; } = Encoding.Default;

    #endregion

    #region Constructor

    private readonly FileStream _fileStream;
    private readonly PackArchive _archive;

    public PackFileSystem(string path)
    {
        this.BasePath = path;

        var packFileReader = new PackReader();

        _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

        _archive = packFileReader.Read(_fileStream, null, this.PathSeparator);

        PathUtil.PathSeparator = this.PathSeparator;
    }

    public PackFileSystem(string path, string password, byte[] salt)
    {
        this.BasePath = path;

        _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

        var packFileReader = new PackReader();

        var key = BlowfishUtil.GenerateFinalBlowfishKey(password, salt);
        var blowfish = new Blowfish(key);

        _archive = packFileReader.Read(_fileStream, blowfish, this.PathSeparator);

        PathUtil.PathSeparator = this.PathSeparator;
    }

    public PackFileSystem(string path, string password)
        : this(path, password, new byte[] { 0x03, 0xF8, 0xE4, 0x44, 0x88, 0x99, 0x3F, 0x64, 0xFE, 0x35 }) { }

    #endregion

    #region Implementations

    /// <inheritdoc />
    public bool FileExists(string path)
    {
        if (string.IsNullOrEmpty(path))
            return false;

        if (!_archive.TryGetEntry(path, out var entry))
            return false;

        return entry is { Type: PackEntryType.File };
    }

    /// <inheritdoc />
    public bool FolderExists(string path)
    {
        if (string.IsNullOrEmpty(path) || path == this.Root.Path)
            return true;

        if (!_archive.TryGetBlock(path, out _))
            return false;

        return true;
    }

    /// <inheritdoc />
    public IFile GetFile(string path)
    {
        this.AssertFileExists(path);

        var entry = _archive.GetEntry(path);

        return new PackFile.PackFile(path, entry!, this);
    }

    /// <inheritdoc />
    public IFolder GetFolder(string path)
    {
        this.AssertFolderExists(path);

        var folderEntry = _archive.GetEntry(path)!;

        return new PackFolder(path, folderEntry, this);
    }

    /// <inheritdoc />
    public IEnumerable<IFile> GetFiles(string folderPath)
    {
        this.AssertFolderExists(folderPath);

        if (!_archive.TryGetBlock(folderPath, out var block))
            return Array.Empty<IFile>();

        var entries = block!.GetEntries().Where(e => e.Type == PackEntryType.File).ToArray();

        var result = new List<IFile>();

        for (var iFile = 0; iFile < entries.Length; iFile++)
        {
            var file = entries[iFile];

            result.Add(new PackFile.PackFile($"{folderPath}{file.Name}", file, this));
        }

        return result.ToArray();
    }

    /// <inheritdoc />
    public IFolder[] GetFolders(string folderPath)
    {
        this.AssertFolderExists(folderPath);

        if (!_archive.TryGetBlock(folderPath, out var block))
            return Array.Empty<IFolder>();

        var entries = block!.GetEntries().Where(e => e.Type == PackEntryType.Folder).ToArray();

        var result = new List<IFolder>();

        for (var iFolder = 0; iFolder < entries.Length; iFolder++)
        {
            var folder = entries[iFolder];
            var currentFolderPath = PathUtil.Append(folderPath, folder.Name);

            result.Add(new PackFolder(currentFolderPath, folder, this));
        }

        return result.ToArray();
    }

    /// <inheritdoc />
    public string[] GetChildren(string folderPath)
    {
        this.AssertFolderExists(folderPath);

        if (!_archive.TryGetBlock(folderPath, out var block))
            return Array.Empty<string>();

        var entries = block!.GetEntries().Where(e => e.Type != PackEntryType.Nop && !e.IsNavigator()).ToArray();

        var result = new Span<string>();

        for (var iEntry = 0; iEntry < entries.Length; iEntry++)
        {
            var entry = entries[iEntry];

            var entryPath = PathUtil.Append(folderPath, entry.Name);
            result[iEntry] = entryPath;
        }

        return result.ToArray();
    }

    /// <inheritdoc />
    public IEnumerable<IFile> GetFileList(string parent, params string[] fileNames)
    {
        var entries = _archive.GetEntryListByNames(parent, fileNames).ToArray();

        var result = new List<IFile>();

        for (var iFile = 0; iFile < entries.Length; iFile++)
        {
            var file = entries[iFile];

            var path = PathUtil.Append(parent, file.Name);

            result.Add(new PackFile.PackFile(path, file, this));
        }

        return result;
    }

    /// <inheritdoc />
    public IFileReader OpenRead(string path)
    {
        this.AssertFileExists(path);

        var entry = _archive.GetEntry(path);
        if (entry is not { Type: PackEntryType.File })
            throw new FileNotFoundException($"The file {path} does not exist!");

        var bsRead = new BsReader(_fileStream);
        bsRead.BaseStream.Position = entry.DataPosition;
        var buffer = bsRead.ReadBytes(entry.Size);

        return new PackFileReader(new MemoryStream(buffer));
    }

    /// <inheritdoc />
    public IFileReader OpenRead(object entry)
    {
        if (entry == null)
            throw new ArgumentNullException();

        if (entry is not PackEntry packEntry)
            throw new ArgumentException("Entry should be of type PackEntry");

        Debug.WriteLine(
            $"Reading file '{packEntry.Name}' (Offset: 0x{packEntry.DataPosition:X}, Size: {packEntry.Size}B)"
        );

        var bsRead = new BsReader(_fileStream);
        bsRead.BaseStream.Position = packEntry.DataPosition;
        var buffer = bsRead.ReadBytes(packEntry.Size);

        return new PackFileReader(new MemoryStream(buffer));
    }

    /// <inheritdoc />s
    public bool TryGetFile(string path, out IFile? file)
    {
        try
        {
            file = this.GetFile(path);

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
            folder = this.GetFolder(path);

            return true;
        }
        catch
        {
            folder = default;

            return false;
        }
    }

    public void Dispose()
    {
        _fileStream.Close();
        _fileStream.Dispose();
    }

    #endregion
}
