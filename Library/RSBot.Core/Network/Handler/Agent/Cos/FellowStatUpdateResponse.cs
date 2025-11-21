namespace RSBot.Core.Network.Handler.Agent;

public class FellowStatUpdateResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3422;

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
        var uniqueId = packet.ReadUInt();

        var fellow = Game.Player.Fellow;
        if (fellow?.UniqueId != uniqueId)
            return;

        fellow.Strength = packet.ReadUShort();
        fellow.Intelligence = packet.ReadUShort();

        fellow.PhysicalAttackMin = packet.ReadUInt();
        fellow.PhysicalAttackMax = packet.ReadUInt();
        fellow.MagicalAttackMin = packet.ReadUInt();
        fellow.MagicalAttackMax = packet.ReadUInt();

        fellow.PhysicalDefence = packet.ReadUShort();
        fellow.MagicalDefence = packet.ReadUShort();
        packet.ReadUShort(); // phy absorb
        packet.ReadUShort(); // mag absorb

        fellow.HitRate = packet.ReadUShort();
        packet.ReadUShort(); // parry rate
        packet.ReadUShort(); // critical
        packet.ReadUShort(); // blocking rate

        fellow.MaxHealth = packet.ReadInt();
    }
}
