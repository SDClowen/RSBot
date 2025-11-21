using System.IO;

namespace RSBot.Core.Network.Protocol;

internal class PacketReader : BinaryReader
{
    public PacketReader(byte[] input)
        : base(new MemoryStream(input, false)) { }

    public PacketReader(byte[] input, int index, int count)
        : base(new MemoryStream(input, index, count, false)) { }
}
