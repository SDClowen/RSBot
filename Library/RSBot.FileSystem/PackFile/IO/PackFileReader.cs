using RSBot.FileSystem.IO;

namespace RSBot.FileSystem.PackFile.IO;

public class PackFileReader : IFileReader
{
    private readonly Stream _stream;

    public PackFileReader(Stream stream)
    {
        _stream = stream;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _stream.Close();
    }

    /// <inheritdoc />
    public byte[] ReadAllBytes()
    {
        var buffer = new byte[_stream.Length];

        _stream.Read(buffer, 0, buffer.Length);

        return buffer;
    }

    /// <inheritdoc />
    public byte[] Read(int offset, int length)
    {
        if (offset + length > _stream.Length)
            throw new IOException("Can not read beyond the stream.");

        var buffer = new byte[length];

        _stream.Read(buffer, offset, length);

        return buffer;
    }

    /// <inheritdoc />
    public string ReadAllText()
    {
        using var reader = new StreamReader(_stream);

        return reader.ReadToEnd();
    }

    /// <inheritdoc />
    public string[] ReadAllLines()
    {
        return ReadAllText().Split(Environment.NewLine);
    }

    /// <inheritdoc />
    public Stream GetStream()
    {
        return _stream;
    }

    /// <inheritdoc />
    public void Close()
    {
        _stream.Close();
    }
}
