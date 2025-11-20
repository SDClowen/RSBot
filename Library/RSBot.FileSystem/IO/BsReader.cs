using System.Runtime.CompilerServices;
using System.Text;

namespace RSBot.FileSystem.IO;

public class BsReader : BinaryReader
{
    private readonly Encoding _encoding;

    public BsReader(Stream input)
        : base(input)
    {
        _encoding = Encoding.GetEncoding(Encoding.ASCII.CodePage);
    }

    public BsReader(Stream input, Encoding encoding)
        : base(input, encoding)
    {
        _encoding = encoding;
    }

    public BsReader(Stream input, Encoding encoding, bool leaveOpen)
        : base(input, encoding, leaveOpen)
    {
        _encoding = encoding;
    }

    public override string ReadString()
    {
        var byteCount = base.ReadInt32();

        return ReadString(byteCount);
    }

    public string ReadString(int byteCount)
    {
        var buffer = base.ReadBytes(byteCount);

        var terminatorOffset = byteCount;
        for (var i = 0; i < byteCount; i++)
            if (buffer[i] == byte.MinValue)
            {
                terminatorOffset = i;
                break;
            }

        return _encoding.GetString(buffer, 0, terminatorOffset);
    }

    public long SeekOverString()
    {
        return BaseStream.Seek(base.ReadInt32(), SeekOrigin.Current);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float ReadFloat()
    {
        return ReadSingle();
    }
}
