﻿using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Buffers;

namespace RSBot.Core.Extensions;

/// <summary>
/// Extension methods for StreamReader to provide efficient line reading capabilities
/// </summary>
public static class StreamReaderExtensions
{
    /// <summary>
    /// Asynchronously reads a line from the StreamReader using CRLF as line ending
    /// </summary>
    /// <param name="reader">The StreamReader instance</param>
    /// <returns>The read line as string, or null if end of stream is reached</returns>
    public static Task<string> ReadLineByCRLFAsync(this StreamReader reader)
    {
        return ReadLineByCRLFAsync(reader, new StringBuilder(), CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously reads a line from the StreamReader using CRLF as line ending with a provided StringBuilder
    /// </summary>
    /// <param name="reader">The StreamReader instance</param>
    /// <param name="builder">StringBuilder instance for efficient string building</param>
    /// <param name="cancellationToken">Token to cancel the operation</param>
    /// <returns>The read line as string, or null if end of stream is reached</returns>
    public static async Task<string> ReadLineByCRLFAsync(this StreamReader reader, StringBuilder builder, CancellationToken cancellationToken = default)
    {
        builder.Clear();

        const int CODE_LF = 0x0A;
        const int CODE_CR = 0x0D;
        const int BUFFER_SIZE = 1024;

        var buffer = ArrayPool<char>.Shared.Rent(BUFFER_SIZE);
        try
        {
            while (!reader.EndOfStream)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var read = await reader.ReadAsync(buffer, 0, BUFFER_SIZE).ConfigureAwait(false);
                if (read == 0) break;

                for (var i = 0; i < read; i++)
                {
                    var c = buffer[i];
                    if (c == CODE_CR && i + 1 < read && buffer[i + 1] == CODE_LF)
                    {
                        i++; // Skip LF
                        return builder.ToString();
                    }
                    else if (c == CODE_CR && i == read - 1)
                    {
                        // CR at end of buffer, check next char
                        var nextChar = reader.Peek();
                        if (nextChar == CODE_LF)
                        {
                            await reader.ReadAsync(buffer, 0, 1).ConfigureAwait(false); // Skip LF
                            return builder.ToString();
                        }
                    }

                    builder.Append(c);
                }
            }

            return builder.Length > 0 ? builder.ToString() : null;
        }
        finally
        {
            ArrayPool<char>.Shared.Return(buffer);
        }
    }

    /// <summary>
    /// Synchronously reads a line from the StreamReader using CRLF as line ending
    /// </summary>
    /// <param name="reader">The StreamReader instance</param>
    /// <returns>The read line as string</returns>
    public static string ReadLineByCRLF(this StreamReader reader)
    {
        var builder = new StringBuilder();
        return reader.ReadLineByCRLF(builder);
    }

    /// <summary>
    /// Synchronously reads a line from the StreamReader using CRLF as line ending with a provided StringBuilder
    /// </summary>
    /// <param name="reader">The StreamReader instance</param>
    /// <param name="builder">StringBuilder instance for efficient string building</param>
    /// <returns>The read line as string</returns>
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