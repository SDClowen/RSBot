using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Character;

internal class CharacterUpdateStatsResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x303D;

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
        var player = Game.Player;
        player.PhysicalAttackMin = packet.ReadUInt();
        player.PhysicalAttackMax = packet.ReadUInt();
        player.MagicalAttackMin = packet.ReadUInt();
        player.MagicalAttackMax = packet.ReadUInt();

        player.PhysicalDefence = packet.ReadUShort();
        player.MagicalDefence = packet.ReadUShort();

        player.HitRate = packet.ReadUShort();
        player.ParryRate = packet.ReadUShort();

        player.MaximumHealth = packet.ReadInt();
        player.MaximumMana = packet.ReadInt();

        player.Strength = packet.ReadUShort();
        player.Intelligence = packet.ReadUShort();

        EventManager.FireEvent("OnLoadCharacterStats");
    }
}
