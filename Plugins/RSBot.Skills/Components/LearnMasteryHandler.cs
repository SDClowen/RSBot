using RSBot.Core.Network;

namespace RSBot.Skills.Components;

internal class LearnMasteryHandler
{
    public static void LearnMastery(uint masteryId)
    {
        var packet = new Packet(0x70A2);
        packet.WriteInt(masteryId);
        packet.WriteByte(0x01); //level

        var callback = new AwaitCallback(null, 0xB0A2);
        PacketManager.SendPacket(packet, PacketDestination.Server, callback);
        callback.AwaitResponse(1000);
    }
}
