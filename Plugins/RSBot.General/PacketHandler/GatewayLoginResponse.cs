﻿using RSBot.Core;
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
                AutoLogin.Pending = false;
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

                    Task.Factory.StartNew(() =>
                    {
                        SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());

                        Views.View.PendingWindow.Start(count, timestamp);
                        if (!GlobalConfig.Get<bool>("RSBot.General.AutoHidePendingWindow"))
                            Views.View.PendingWindow.ShowAtTop(Views.View.Instance);
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