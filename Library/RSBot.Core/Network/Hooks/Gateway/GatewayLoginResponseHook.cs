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
            var success = packet.ReadByte();

            if (success == 0x01)
            {
                Kernel.Proxy.Token = packet.ReadUInt();

                Log.Debug($"Connecting to game server using the token {Kernel.Proxy.Token}");
                Kernel.Proxy.SetAgentserverAddress(packet.ReadString(), packet.ReadUShort());

                if (Game.Clientless)
                    return null;
            }
            else
                return packet;

            var result = new Packet(packet.Opcode);
            result.WriteByte(success);
            result.WriteUInt(Kernel.Proxy.Token);
            result.WriteString("127.0.0.1");
            result.WriteUShort(Kernel.Proxy.Port);

            if (Game.ClientType >= GameClientType.Global)
            {
                var unk1 = packet.ReadByte();
                result.WriteByte(unk1);

                if (unk1 == 2)
                    result.WriteString(packet.ReadString());
            }

            return result;
        }
    }
}