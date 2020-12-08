namespace RSBot.Core.Network.Hooks
{
    internal class GatewayLoginResponseHook : IPacketHook
    {
        /// <summary>
        /// Gets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xA102;

        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Replaces the packet and returns a new packet.
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public Packet ReplacePacket(Packet packet)
        {
            //Fake the agentserver packet
            var success = packet.ReadByte();

            if (success == 0x01)
            {
                Kernel.Proxy.Token = packet.ReadUInt();

                Log.Debug($"Connecting to game server using the token {Kernel.Proxy.Token}");
                Kernel.Proxy.SetAgentserverAddress(packet.ReadString(), packet.ReadUShort());

                if (Game.Clientless)
                    return null;
            }
            else return packet;

            packet = new Packet(0xA102);
            packet.WriteByte(success);
            packet.WriteUInt(Kernel.Proxy.Token);
            packet.WriteString("127.0.0.1");
            packet.WriteUShort(Kernel.Proxy.Port);

            return packet;
        }
    }
}