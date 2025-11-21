using System.Text;

namespace RSBot.FileSystem.IO;

public class BsWriter : BinaryWriter
{
    private readonly Encoding _encoding;

    protected BsWriter()
    {
        _encoding = Encoding.GetEncoding(949);
    }

    public BsWriter(Stream output)
        : base(output)
    {
        _encoding = Encoding.GetEncoding(949);
    }

    public BsWriter(Stream output, Encoding encoding)
        : base(output, encoding)
    {
        _encoding = encoding;
    }

    public BsWriter(Stream output, Encoding encoding, bool leaveOpen)
        : base(output, encoding, leaveOpen)
    {
        _encoding = encoding;
    }

    public override void Write(string value)
    {
        Write(value.Length);
        Write(value, value.Length);
    }

    private void Write(string value, int length)
    {
        if (unchecked((uint)length) > 4096)
            throw new ArgumentOutOfRangeException(nameof(length));

        // If you're looking for the StackOverflow reason, you found it.
        Span<byte> buffer =
#if STRING_BUFFER_STACK_ALLOC
            stackalloc //stack
#else
            new //heap
#endif
            byte[length];

        _encoding.GetBytes(value, buffer);
        Write(buffer);
    }
}
