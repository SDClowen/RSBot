using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.General.PacketHandler
{
    internal class AgentLoginResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xA103;

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
            Log.Debug("Agent login response received!");

            var flag = packet.ReadByte();

            if (flag == 0x01)
            {
                if (!Game.Clientless) return;

                var response = new Packet(0x7007);
                response.WriteByte(0x02); //List
                response.Lock();

                var callback = new AwaitCallback(null, 0xB007);
                PacketManager.SendPacket(response, PacketDestination.Server, callback);
                callback.AwaitResponse();

                return;
            }
            var code = packet.ReadByte();

            switch (code)
            {
                case 1:
                    Log.Error("Failed to connect to server. (C9)");
                    break;

                case 2:
                    Log.Error("Failed to connect to server. (C10)");
                    break;

                case 3:
                    Log.Error("Failed to connect to server. (C10)");
                    break;

                case 4:
                    Log.Error("The server is full!");
                    break;

                case 5:
                    Log.Notify("Faild to connect to server because access to the current IP has exceeded its limit.");
                    break;
            }
        }
    }
}