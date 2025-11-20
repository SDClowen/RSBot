using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.General.PacketHandler;

internal class CaptchaResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xA323;

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
        var flag = packet.ReadByte();

        if (flag == 0x01)
        {
            Log.NotifyLang("SuccessCaptcha");
        }
        else
        {
            var maxAttempts = packet.ReadUInt();
            var attempts = packet.ReadUInt();
            Log.NotifyLang("FailedCaptcha", attempts, maxAttempts);
        }
    }
}
