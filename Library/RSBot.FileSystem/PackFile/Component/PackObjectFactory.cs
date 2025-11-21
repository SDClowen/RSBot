using RSBot.FileSystem.PackFile.Struct;

namespace RSBot.FileSystem.PackFile.Component;

internal static class PackObjectFactory
{
    public static PackBlock GetEmptyBlock(
        long blockPosition,
        long parentBlockPosition = 0,
        bool isFolder = false,
        bool isRoot = false
    )
    {
        var result = new PackBlock { Entries = new PackEntry[20], Position = blockPosition };

        //In case of a folder Navigate up/down entries
        if (isFolder)
        {
            result.Entries[0] = GetDotFolder(blockPosition);

            //The root folder doesn't have a go up navigator ".."
            if (isRoot)
                result.Entries[1] = GetNopEntry();
            else
                result.Entries[1] = GetDotDotFolder(parentBlockPosition);
        }
        //In case of a continuation of a block most likely
        else
        {
            result.Entries[0] = GetNopEntry();
            result.Entries[1] = GetNopEntry();
        }

        for (var i = 2; i < 20; i++)
            result.Entries[i] = GetNopEntry();

        return result;
    }

    public static PackEntry GetNopEntry()
    {
        return new PackEntry
        {
            CreationTime = DateTime.Now.Ticks,
            ModifyTime = DateTime.Now.Ticks,
            DataPosition = 0,
            Type = PackEntryType.Nop,
            Name = string.Empty,
            NextBlock = 0,
            Payload = new byte[2],
            Size = 0,
        };
    }

    public static PackEntry GetDotFolder(long parentFolderPosition)
    {
        return new PackEntry
        {
            CreationTime = DateTime.Now.Ticks,
            ModifyTime = DateTime.Now.Ticks,
            DataPosition = parentFolderPosition,
            Type = PackEntryType.Folder,
            Name = ".",
            NextBlock = 0,
            Payload = new byte[2],
            Size = 0,
        };
    }

    public static PackEntry GetDotDotFolder(long parentBlockPosition)
    {
        return new PackEntry
        {
            CreationTime = DateTime.Now.Ticks,
            ModifyTime = DateTime.Now.Ticks,
            DataPosition = parentBlockPosition,
            Type = PackEntryType.Folder,
            Name = "..",
            NextBlock = 0,
            Payload = new byte[2],
            Size = 0,
        };
    }
}
