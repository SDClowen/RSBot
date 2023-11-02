using RSBot.Pk2.IO;

namespace RSBot.Pk2.Types;

public class PK2Directory : PK2Entry
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PK2Directory" /> class.
    /// </summary>
    /// <param name="fileAdapter"></param>
    public PK2Directory(FileAdapter fileAdapter)
        : base(fileAdapter)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PK2Directory" /> class.
    /// </summary>
    /// <param name="fileAdapter">The file adapter.</param>
    /// <param name="entry">The entry.</param>
    /// <param name="parent">The parent.</param>
    public PK2Directory(FileAdapter fileAdapter, PK2Entry entry, PK2Entry parent)
        : base(fileAdapter)
    {
        Parent = parent;

        Index = entry.Index;
        Block = entry.Block;
        AccessTime = entry.AccessTime;
        CreateTime = entry.CreateTime;
        ModifyTime = entry.ModifyTime;
        Name = entry.Name;
        NextChain = entry.NextChain;
        Position = entry.Position;
        Size = entry.Size;

        Type = PK2EntryType.Directory;
    }
}