using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.General.PacketHandler;

internal class AgentLoginResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xA103;

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
        Log.Debug("Agent login response received!");

        var flag = packet.ReadByte();

        if (flag == 0x01)
        {
            if (!Game.Clientless)
                return;

            var response = new Packet(0x7007);
            response.WriteByte(0x02); //List
            PacketManager.SendPacket(response, PacketDestination.Server);

            return;
        }

        var code = packet.ReadByte();

        switch (code)
        {
            case 1:
                Log.WarnLang("C9");
                break;

            case 2:
                Log.WarnLang("C10");
                break;

            case 3:
                Log.WarnLang("C10");
                break;

            case 4:
                Log.WarnLang("ServerFull");
                break;

            case 5:
                Log.WarnLang("IpLimit");
                break;
            default:
                Log.Warn($"Unknown agent server login error code: {code:X}");
                break;
        }
    }
}
