using RSBot.Core.Network;
using RSBot.General.Components;

namespace RSBot.General.PacketHandler
{
    internal class GatewayLoginRequestHook : IPacketHook
    {
        public ushort Opcode => 0x610A;

        public PacketDestination Destination => PacketDestination.Server;

        public Packet ReplacePacket(Packet packet)
        {
            AutoLogin.Cts?.Cancel();
            return packet;
        }
    }
}
