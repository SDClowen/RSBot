using System.IO;

namespace RSBot.Core.Network.Protocol;

internal class PacketWriter : BinaryWriter
{
    private readonly MemoryStream m_ms;

    public PacketWriter()
    {
        m_ms = new MemoryStream();
        OutStream = m_ms;
    }

    public byte[] GetBytes()
    {
        return m_ms.ToArray();
    }
}
