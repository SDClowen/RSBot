using System;
using System.Text;

namespace RSBot.Core.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string HexDump(this byte[] buffer)
        {
            return HexDump(buffer, 0, buffer.Length);
        }

        public static string HexDump(this byte[] buffer, int offset, int count)
        {
            const int bytesPerLine = 16;
            StringBuilder output = new StringBuilder();
            StringBuilder ascii_output = new StringBuilder();
            int length = count;
            if (length % bytesPerLine != 0)
            {
                length += bytesPerLine - length % bytesPerLine;
            }
            for (int x = 0; x <= length; ++x)
            {
                if (x % bytesPerLine == 0)
                {
                    if (x > 0)
                    {
                        output.AppendFormat("  {0}{1}", ascii_output.ToString(), Environment.NewLine);
                        //ascii_output.Remove(0, ascii_output.Length);
                        ascii_output.Clear(); //requires .NET 4.0 up
                    }
                    if (x != length)
                    {
                        output.AppendFormat("{0:d10}   ", x);
                    }
                }
                if (x < count)
                {
                    output.AppendFormat("{0:X2} ", buffer[offset + x]);
                    char ch = (char)buffer[offset + x];
                    if (!char.IsControl(ch))
                    {
                        ascii_output.AppendFormat("{0}", ch);
                    }
                    else
                    {
                        ascii_output.Append(".");
                    }
                }
                else
                {
                    output.Append("   ");
                    ascii_output.Append(".");
                }
            }
            return output.ToString().TrimEnd('\r', '\n', ' ');
        }
    }
}