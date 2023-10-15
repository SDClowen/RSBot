using System.IO;

namespace RSBot.Pk2.IO.Stream;

internal class Writer : BinaryWriter
{
    /// <summary>
    /// Represents the stream this class uses for writing stuff
    /// </summary>
    private readonly MemoryStream _stream;

    /// <summary>
    /// Initializes a new instance of the <see cref="Writer"/> class.
    /// </summary>
    public Writer()
    {
        _stream = new MemoryStream();
        OutStream = _stream;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Writer"/> class.
    /// </summary>
    /// <param name="buffer">The buffer.</param>
    public Writer(byte[] buffer)
    {
        _stream = new MemoryStream(buffer);
        OutStream = _stream;
    }

    /// <summary>
    /// Returns the current buffer from the stream as byte[]
    /// </summary>
    /// <returns>buffer</returns>
    public byte[] GetBuffer()
    {
        return _stream.ToArray();
    }
}