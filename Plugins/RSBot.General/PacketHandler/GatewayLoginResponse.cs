using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.General.PacketHandler
{
    internal class GatewayLoginResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xA102;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            if (packet.ReadByte() == 0x01)
            {
                Log.Notify("Gateway authentication successfull!");
                return;
            }
            var code = packet.ReadByte();

            switch (code)
            {
                case 1:
                    Log.Warn("Failed to connect to login server. (C9)");
                    break;

                case 2:
                    Log.Warn("Failed to connect to login server. (C10)");
                    break;

                case 3:
                    Log.Warn("Failed to connect to login server. (C10)");
                    break;

                case 4:
                    Log.Warn("The server is full!");
                    break;

                case 5:
                    Log.Warn("Faild to connect to server because access to the current IP has exceeded its limit.");
                    break;

                default:
                    Log.Warn($"Failed to login to login server. ({code})");
                    break;
            }
        }
    }
}