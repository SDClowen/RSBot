using System.Diagnostics;
using System.Text;
using RSBot.FileSystem.IO;
using RSBot.FileSystem.PackFile.Cryptography;
using RSBot.FileSystem.PackFile.Struct;

namespace RSBot.FileSystem.PackFile;

internal class PackReader
{
    private Blowfish? _blowfish;
    private BsReader _reader;
    private PackResolver _resolver;

    public PackArchive Read(
        Stream fileStream,
        Blowfish? blowfish = null,
        char pathSeparator = '\\',
        bool caseSensitive = false
    )
    {
        var sw = Stopwatch.StartNew();

        _blowfish = blowfish;

        PackHeader header;
        _reader = new BsReader(fileStream);

        header = ReadHeader(_reader);

        //Check decryption key
        if (_blowfish != null && header.Encrypted == 0x01)
        {
            var tempChecksum = _blowfish.Encode(Encoding.ASCII.GetBytes(PackHeader.BlowfishChecksumDecoded));

            //Check if the security checksum equals the generated checksum
            if (
                tempChecksum == null
                || tempChecksum[0] != header.EncryptionChecksum[0]
                || tempChecksum[1] != header.EncryptionChecksum[1]
                || tempChecksum[2] != header.EncryptionChecksum[2]
            )
                throw new IOException("Failed to open JoymaxPackFile: The password or salt is wrong.");
        }

        sw.Stop();
        Debug.WriteLine($"Reading pack file took {sw.ElapsedMilliseconds}ms");

        _resolver = new PackResolver(this, pathSeparator, caseSensitive);

        return new PackArchive(header, blowfish, _resolver, pathSeparator);
    }

    public PackHeader ReadHeader(BinaryReader reader)
    {
        var result = new PackHeader
        {
            Signature = reader.ReadChars(30),
            Version = reader.ReadInt32(),
            Encrypted = reader.ReadByte(),
            EncryptionChecksum = reader.ReadBytes(16),
            Payload = reader.ReadBytes(205),
        };

        return result;
    }

    private PackBlock ReadBlockAt(long position)
    {
        _reader.BaseStream.Position = position;

        var block = new PackBlock { Position = position, Entries = ReadEntries(_reader) };

        return block;
    }

    public IEnumerable<PackBlock> ReadBlocksAt(long position)
    {
        var result = new List<PackBlock>(16);

        var block = ReadBlockAt(position);
        result.Add(block);

        //Read next block
        if (block.Entries[19].NextBlock > 0)
            result.AddRange(ReadBlocksAt(block.Entries[19].NextBlock));

        return result;
    }

    private PackEntry[] ReadEntries(BinaryReader reader)
    {
        var result = new PackEntry[20];

        var buffer = reader.ReadBytes(128 * result.Length);
        var entryBuffer = _blowfish != null ? _blowfish.Decode(buffer) : buffer;

        using var entryReader = new BsReader(new MemoryStream(entryBuffer));
        //Read entries
        for (var iEntry = 0; iEntry < 20; iEntry++)
            result[iEntry] = new PackEntry
            {
                Type = (PackEntryType)entryReader.ReadByte(),
                Name = entryReader.ReadString(89).Trim('\0'),
                CreationTime = entryReader.ReadInt64(),
                ModifyTime = entryReader.ReadInt64(),
                DataPosition = entryReader.ReadInt64(),
                Size = entryReader.ReadInt32(),
                NextBlock = entryReader.ReadInt64(),
                Payload = entryReader.ReadBytes(2), //Padding to reach 128 bytes length
            };

        return result;
    }
}
