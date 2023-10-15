using System.IO;

namespace RSBot.Pk2.IO.Stream;

internal class Reader : BinaryReader
{
    /// <summary>
    /// Initializes a new binary reader from a stream
    /// </summary>
    /// <param name="buffer">buffer to read from</param>
    public Reader(byte[] buffer)
        : base(new MemoryStream(buffer, false))
    { }

    /// <summary>Constructor - Advanced
    /// Initializes a new binary reader from a stream
    /// </summary>
    /// <param name="buffer">buffer to read from</param>
    /// <param name="offset">Where to start</param>
    /// <param name="length">Where to end</param>
    public Reader(byte[] buffer, int offset, int length)
        : base(new MemoryStream(buffer, offset, length, false))
    { }
}