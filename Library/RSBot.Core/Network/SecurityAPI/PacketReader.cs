using System.IO;

namespace RSBot.Core.Network.SecurityAPI
{
    internal class PacketReader : System.IO.BinaryReader
    {
        private byte[] m_input;

        public PacketReader(byte[] input)
            : base(new MemoryStream(input, false))
        {
            m_input = input;
        }

        public PacketReader(byte[] input, int index, int count)
            : base(new MemoryStream(input, index, count, false))
        {
            m_input = input;
        }
    }
}