using RSBot.Core.Network;

namespace RSBot.Core.Objects.Cos;

public class Transport : Cos
{
    /// <summary>
    ///     Dismounts this instance.
    /// </summary>
    public override bool Dismount()
    {
        var packet = new Packet(0x70CB);
        packet.WriteByte(0);
        packet.WriteUInt(UniqueId);

        PacketManager.SendPacket(packet, PacketDestination.Server);

        return base.Dismount();
    }
}
