using System.Linq;
using RSBot.Pk2.IO;
using RSBot.Pk2.IO.Stream;
using RSBot.Pk2.Security;

namespace RSBot.Pk2.Types;

public class PK2Block
{
    #region Fields

    private readonly FileAdapter _fileAdapter;

    #endregion Fields

    /// <summary>
    ///     Initializes a new instance of the <see cref="PK2Block" /> class.
    /// </summary>
    public PK2Block()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PK2Block" /> class.
    /// </summary>
    /// <param name="fileAdapter">The file adapter.</param>
    /// <param name="buffer">The buffer.</param>
    /// <param name="offset">The block offset.</param>
    public PK2Block(FileAdapter fileAdapter, byte[] buffer, ulong offset)
    {
        _fileAdapter = fileAdapter;
        Entries = new PK2Entry[20];
        Offset = offset;

        using (var streamWorker = new StreamWorker(buffer, StreamOperation.Read))
        {
            for (var i = 0; i < 20; i++)
            {
                var entryBuffer = streamWorker.ReadByteArray(128);

                if (BlowfishUtilities.GetBlowfish() != null)
                    entryBuffer = BlowfishUtilities.GetBlowfish().Decode(entryBuffer);

                Entries[i] = new PK2Entry(_fileAdapter, entryBuffer, this, (byte)i);
            }
        }
    }

    /// <summary>
    ///     Gets or sets the entries.
    /// </summary>
    /// <value>
    ///     The entries.
    /// </value>
    public PK2Entry[] Entries { get; set; }

    /// <summary>
    ///     Gets or sets the block offset.
    /// </summary>
    /// <value>
    ///     The block offset.
    /// </value>
    public ulong Offset { get; set; }

    /// <summary>
    ///     Gets a value indicating whether this instance has blocks.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance has blocks; otherwise, <c>false</c>.
    /// </value>
    public bool HasBlocks => Entries[19].NextChain > 0;

    /// <summary>
    ///     Gets a collection of all blocks that belong to this block.
    /// </summary>
    /// <returns></returns>
    public PK2BlockCollection GetCollection()
    {
        var result = new PK2BlockCollection();

        result.Add(this);

        var block = GetNextBlock();

        while (block.HasBlocks)
        {
            result.Add(block);
            block = block.GetNextBlock();
        }

        return result;
    }

    /// <summary>
    ///     Gets the first empty entry that can be used to write new data to it.
    /// </summary>
    /// <returns></returns>
    internal PK2Entry GetFirstEmptyEntry()
    {
        var collection = GetCollection();

        return collection.GetEntries().FirstOrDefault(entry => entry.Type == PK2EntryType.Empty);
    }

    /// <summary>
    ///     A helper method that returns the last block of this chain
    /// </summary>
    /// <returns></returns>
    public PK2Block GetLastBlock()
    {
        return GetCollection().LastOrDefault();
    }

    /// <summary>
    ///     Gets the next block.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="PK2NotLoadedException"></exception>
    public PK2Block GetNextBlock()
    {
        if (_fileAdapter == null)
            throw new PK2NotLoadedException();

        return HasBlocks
            ? new PK2Block(_fileAdapter, _fileAdapter.ReadData((long)Entries[19].NextChain, 2560),
                Entries[19].NextChain)
            : this;
    }

    /// <summary>
    ///     To the byte array.
    /// </summary>
    /// <returns></returns>
    public byte[] ToByteArray()
    {
        var buffer = new byte[2560];
        using (var stream = new StreamWorker(buffer, StreamOperation.Write))
        {
            for (var i = 0; i < 20; i++) stream.WriteByteArray(Entries[i].ToByteArray());
        }

        return buffer;
    }

    /// <summary>
    ///     Saves the block back to the PK2 archive.
    /// </summary>
    /// <exception cref="PK2NotLoadedException"></exception>
    public void Save()
    {
        if (_fileAdapter == null)
            throw new PK2NotLoadedException();

        _fileAdapter.WriteData(ToByteArray(), (long)Offset);
    }
}