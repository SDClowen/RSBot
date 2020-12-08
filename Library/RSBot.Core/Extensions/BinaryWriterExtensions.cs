using System.IO;
using System.Text;

namespace RSBot.Core.Extensions
{
    public static class BinaryWriterExtensions
    {
        public static void WriteJoymaxString(this BinaryWriter writer, string value)
        {
            var encoding = Encoding.GetEncoding(949); //Korean
            writer.Write(encoding.GetByteCount(value));
            writer.Write(encoding.GetBytes(value));
        }
    }
}