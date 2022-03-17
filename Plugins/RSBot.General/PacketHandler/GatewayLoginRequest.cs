using RSBot.Core.Network;

namespace RSBot.General.PacketHandler
{
    internal class GatewayLoginRequest : IPacketHandler
    {
        /// <summary>
        /// Gets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x6102;

        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Server;

        /// <summary>
        /// Replaces the packet and returns a new packet.
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public void Invoke(Packet packet)
        {
            packet.ReadByte(); // locale
            packet.ReadString();//username
            packet.ReadString();//password

            if (packet.Opcode == 0x610A)
                packet.ReadByteArray(6);

            var shardId = packet.ReadUShort();
            
            Components.Serverlist.SetJoining(shardId);
        }
    }
}
