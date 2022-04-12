using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                Log.NotifyLang("AuthGetewaySuccess");
                Views.View.PendingWindow?.Hide();

                return;
            }

            var code = packet.ReadByte();

            switch (code)
            {
                case 1:
                    Log.NotifyLang("AuthGatewayWrongIdPw");
                    break;

                case 2:
                    Log.NotifyLang("AuthAccountBanned");
                    break;

                case 3:
                    Log.NotifyLang("AuthAccountAlreadyInGame");
                    break;

                case 4:
                    Log.WarnLang("ServerCheck");
                    AutoLogin.Handle();
                    break;

                case 5:
                    Log.WarnLang("ServerFull");
                    AutoLogin.Handle();
                    break;

                case 26: // queue

                    var count = packet.ReadUShort();
                    var timestamp = packet.ReadInt();

                    Task.Run(() =>
                    {
                        SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());

                        if (Views.View.PendingWindow == null)
                            Views.View.PendingWindow = new Views.PendingWindow();

                        Views.View.PendingWindow.Start(count, timestamp);
                        Views.View.PendingWindow.ShowDialog(Views.View.Instance.ParentForm);
                    });

                    break;

                case 29: // ksro block
                    AutoLogin.Handle();
                    break;

                default:
                    Log.WarnLang("AuthFailed", code);
                    break;
            }
        }
    }
}