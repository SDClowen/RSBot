using RSBot.Core;
using RSBot.Core.Network;
using System;

namespace RSBot.General.PacketHandler
{
    public class GlobalSecondaryPasswordResponse : IPacketHandler
    {
        public ushort Opcode => 0xA117;

        public PacketDestination Destination => PacketDestination.Client;

        public void Invoke(Packet packet)
        {
            var type = packet.ReadByte();
            if (type != 4)
                return;

            var result = packet.ReadByte();
            if(result == 1)
            {
                Log.Notify("Secondary password was successfully entered!");
                return;
            }

            var errorCode = packet.ReadByte();
            switch (errorCode)
            {
                case 1:
                    Log.Warn("The secondary password is incorrect!");
                    break;
                default:
                    break;
            }
        }
    }
}
