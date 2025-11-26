namespace RSBot.FileSystem.PackFile.Struct;

public record PackBlock
{
    public const int BlockSize = 4096;

    /// <summary>
    ///     The collection of entries inside this block
    /// </summary>
    public PackEntry[] Entries = new PackEntry[20];

    /// <summary>
    ///     The block position inside the pack file
    /// </summary>
    public long Position;

    /// <summary>
    ///     Serializes this instance to a byte array.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="IOException">
    ///     If the name exceeds 89 characters
    ///     If the payload exceeds a maximum length of 2 bytes.
    /// </exception>
    public byte[] ToByteArray()
    {
        var buffer = new byte[2560];

        using var writer = new BinaryWriter(new MemoryStream(buffer));

        for (var i = 0; i < Entries.Length; i++)
        {
            var entry = Entries[i];
            if (entry.Name.Length > 89)
                throw new IOException("The entry name exceeds the maximum length of 89");

            if (entry.Payload.Length > 2)
                throw new IOException("The entry payload exceeds the maximum count of 2 bytes");

            var name = new char[89];
            entry.Name.ToCharArray().CopyTo(name, 0);

            writer.Write((byte)entry.Type);
            writer.Write(name);
            writer.Write(entry.Type == PackEntryType.Nop ? 0 : entry.CreationTime);
            writer.Write(entry.Type == PackEntryType.Nop ? 0 : entry.ModifyTime);
            writer.Write(entry.DataPosition);
            writer.Write(entry.Size);
            writer.Write(entry.NextBlock);
            writer.Write(entry.Payload);
        }

        return buffer;
    }
}
