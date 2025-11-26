using System.IO;
using System.Text;

namespace RSBot.Core.Extensions;

public static class BinaryWriterExtensions
{
    public static void WriteAscii(this BinaryWriter writer, string value)
    {
        var encoding = Encoding.UTF8;

        var buffer = encoding.GetBytes(value);

        writer.Write(buffer.Length);
        writer.Write(buffer);
    }

    public static byte[] GetSnapshot(this BinaryWriter binary) => ((MemoryStream)binary.BaseStream).ToArray();
}
