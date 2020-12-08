using RSBot.Core;
using RSBot.Core.Network;
using System.Windows.Forms;

namespace RSBot.General.PacketHandler
{
    public class PatchResponse : IPacketHook
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xA100;

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
        public Packet ReplacePacket(Packet packet)
        {
            if (packet.ReadByte() == 0x01)
                Log.Notify("This client is up to date, no patch required!");
            else
            {
                var flag = packet.ReadByte(); //Error code;

                if (flag == 2)
                {
                    packet.ReadString(); //DLServer IP
                    packet.ReadUShort(); //DLServer Port
                    var version = packet.ReadInt();
                    Log.Notify($"This client [{Game.ReferenceManager.VersionInfo.Version}] is not up to date [{version}]");
                }

                switch (flag)
                {
                    case 2:
                        MessageBox.Show(
                            "The client is not up to date, please manually start Launcher.exe to patch the client to the latest game version.\n\nAfter updating the client, you can use the bot again as usual.",
                            @"Silkroad client update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1:
                        MessageBox.Show(
                            @"The client version is higher than expected by the server, therefore the client can not be started. Please reinstall the game in order to continue. If this problem still occures, you may want to contact the server administrator!",
                            @"Silkroad process terminated: Server outdated!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show(
                            @"An unknown patch request has been sent by the server [" + flag.ToString() + @"], therefore the client is not able to start!",
                            @"Silkroad process terminated: Unknown patch!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }

            return packet;
        }
    }
}