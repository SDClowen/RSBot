using System.IO;
using System.Text;

namespace RSBot.Core.Extensions;

public static class StreamReaderExtensions
{
    public static string ReadLineByCRLF(this StreamReader reader)
    {
        var builder = new StringBuilder();
        return reader.ReadLineByCRLF(builder);
    }

    public static string ReadLineByCRLF(this StreamReader reader, StringBuilder builder)
    {
        builder.Clear(); //clear builder

        const int CODE_LF = 0x0A;
        const int CODE_CR = 0x0D;

        while (true)
        {
            var c = reader.Read();
            if (c == -1)
                break;

            if (c == CODE_CR && reader.Peek() == CODE_LF)
            {
                reader.Read(); //read LF
                break;
            }

            builder.Append((char)c);
        }

        return builder.ToString();
    }
}
