using System.IO;

namespace RSBot.Core.Network.SecurityAPI
{
    internal class PacketWriter : BinaryWriter
    {
        private MemoryStream m_ms;

        public PacketWriter()
        {
            m_ms = new MemoryStream();
            this.OutStream = m_ms;
        }

        public byte[] GetBytes()
        {
            return m_ms.ToArray();
        }
    }
}