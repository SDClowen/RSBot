using System.IO;

namespace RSBot.Pk2.IO;

public class FileAdapter
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FileAdapter" /> class.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <exception cref="System.IO.FileNotFoundException"></exception>
    public FileAdapter(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException(path);

        Path = path;
    }

    /// <summary>
    ///     Gets or sets the path.
    /// </summary>
    /// <value>
    ///     The path.
    /// </value>
    public string Path { get; set; }

    /// <summary>
    ///     Reads the bytes.
    /// </summary>
    /// <returns></returns>
    public byte[] ReadData(long offset, int count)
    {
        var buffer = new byte[count];

        using (var stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
        {
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Read(buffer, 0, count);
        }

        return buffer;
    }

    /// <summary>
    ///     Writes the bytes at.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="offset">The offset.</param>
    public void WriteData(byte[] data, long offset)
    {
        using (var stream = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite))
        {
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Write(data, 0, data.Length);
        }
    }

    /// <summary>
    ///     Appends the specified data to the end of the file.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns>The position of where the data has been written to</returns>
    public long AppendData(byte[] data)
    {
        using (var stream = new FileStream(Path, FileMode.Append, FileAccess.Write))
        {
            var position = stream.Length;

            if (data == null) return position;

            stream.Write(data, 0, data.Length);
            return position;
        }
    }
}