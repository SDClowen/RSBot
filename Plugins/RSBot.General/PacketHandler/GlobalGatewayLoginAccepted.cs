using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;

namespace RSBot.General.PacketHandler
{
    public class GlobalGatewayLoginAccepted : IPacketHandler
    {
        public ushort Opcode => 0x2116;

        public PacketDestination Destination => PacketDestination.Client;

        public void Invoke(Packet packet)
        {
            var isAccepted = packet.ReadByte() != 2;

            Log.Notify("Secondary password requested!");

            if (isAccepted)
                AutoLogin.SendSecondaryPassword();
        }
    }
}
