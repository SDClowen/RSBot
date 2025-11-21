using RSBot.FileSystem.IO;

namespace RSBot.FileSystem.Local.IO;

public class LocalFileReader : IFileReader
{
    private readonly Stream _fileStream;

    public LocalFileReader(Stream fileStream)
    {
        _fileStream = fileStream;
    }

    public void Dispose()
    {
        _fileStream.Close();
    }

    public byte[] ReadAllBytes()
    {
        var buffer = new byte[_fileStream.Length];

        _fileStream.Read(buffer, 0, buffer.Length);

        return buffer;
    }

    public byte[] Read(int offset, int length)
    {
        if (offset + length > _fileStream.Length)
            throw new IOException("");

        var buffer = new byte[length];

        _fileStream.Read(buffer, offset, length);

        return buffer;
    }

    public string ReadAllText()
    {
        using var reader = new StreamReader(_fileStream);

        return reader.ReadToEnd();
    }

    public string[] ReadAllLines()
    {
        return ReadAllText().Split(Environment.NewLine);
    }

    public Stream GetStream()
    {
        return _fileStream;
    }

    public void Close()
    {
        _fileStream.Close();
    }
}
