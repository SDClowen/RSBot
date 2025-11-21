using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Character;

internal class CharacterIncreaseIntResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB051;

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
        if (packet.ReadByte() != 1)
            return;

        Game.Player.StatPoints--;
        EventManager.FireEvent("OnIncreaseIntelligence");
    }
}
