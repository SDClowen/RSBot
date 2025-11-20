using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class PlayerUpdatePointsResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x304E;

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
        var type = packet.ReadByte();
        switch (type)
        {
            case 1: //Gold
                Game.Player.Gold = packet.ReadULong();
                EventManager.FireEvent("OnUpdateGold");
                break;

            case 2: //Skill points
                Game.Player.SkillPoints = packet.ReadUInt();
                EventManager.FireEvent("OnUpdateSP");
                break;

            case 4: //Berzerker
                Game.Player.BerzerkPoints = packet.ReadByte();
                EventManager.FireEvent("OnUpdateBerzerkerPoints");
                break;
        }
    }
}
