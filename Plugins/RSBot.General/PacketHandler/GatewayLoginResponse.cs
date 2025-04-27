using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;
using View = RSBot.General.Views.View;

namespace RSBot.General.PacketHandler;

internal class GatewayLoginResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xA102;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        if (packet.ReadByte() == 0x01)
        {
            Log.NotifyLang("AuthGetewaySuccess");
            AutoLogin.Pending = false;
            View.PendingWindow?.Hide();
            View.PendingWindow?.StopClientlessQueueTask();

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

            case 15:
                Log.WarnLang("APIServerError");
                break;

            case 26: // queue

                var count = packet.ReadUShort();
                var timestamp = packet.ReadInt();

                Task.Factory.StartNew(() =>
                {
                    SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());

                    View.PendingWindow.Start(count, timestamp);
                    if (!GlobalConfig.Get<bool>("RSBot.General.AutoHidePendingWindow"))
                        View.PendingWindow.ShowAtTop(View.Instance);
                });

                break;

            case 28: // isro block
            case 29: // ksro block
                Log.WarnLang("ServerFull");
                AutoLogin.Handle();
                break;

            case 43:
                Log.WarnLang("TooManyAttempts");
                break;

            default:
                Log.WarnLang("AuthFailed", code);
                break;
        }
    }
}