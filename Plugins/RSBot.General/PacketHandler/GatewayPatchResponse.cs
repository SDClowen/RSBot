using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Network;

namespace RSBot.General.PacketHandler;

public class GatewayPatchResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xA100;

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
            Log.NotifyLang("NoPatchRequired");

            if (Game.Clientless)
                ClientlessManager.RequestServerList();
        }
        else
        {
            var flag = packet.ReadByte(); //Error code;

            if (flag == 2)
            {
                packet.ReadString(); //DLServer IP
                packet.ReadUShort(); //DLServer Port
                var version = packet.ReadInt();
                Log.WarnLang("ClientUpdateWarn", Game.ReferenceManager.VersionInfo.Version, version);
            }

            var title = string.Empty;
            var message = string.Empty;

            switch (flag)
            {
                case 2:

                    title = LanguageManager.GetLang("PatchMsgBoxTitle2");
                    message = LanguageManager.GetLang("PatchMsgBoxContent2");
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;

                case 1:

                    title = LanguageManager.GetLang("PatchMsgBoxTitle1");
                    message = LanguageManager.GetLang("PatchMsgBoxContent1");

                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:

                    title = LanguageManager.GetLang("PatchMsgBoxTitle");
                    message = LanguageManager.GetLang("PatchMsgBoxContent");

                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
