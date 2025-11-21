namespace RSBot.Core.Network.Hooks;

internal class CosActionRequestHook : IPacketHook
{
    /// <summary>
    ///     Gets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x705C;

    /// <summary>
    ///     Gets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    ///     Replaces the packet and returns a new packet.
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    public Packet ReplacePacket(Packet packet)
    {
        var uniqueId = packet.ReadUInt();
        var type = packet.ReadByte();

        if (
            Kernel.Bot.Running
            && Game.Player.HasActiveAbilityPet
            && Game.Player.AbilityPet.UniqueId == uniqueId
            && type == 0x08
        )
            return null;

        return packet;
    }
}
