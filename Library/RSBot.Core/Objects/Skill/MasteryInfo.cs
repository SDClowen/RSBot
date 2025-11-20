using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Skill;

public class MasteryInfo
{
    /// <summary>
    ///     Gets or sets the level.
    /// </summary>
    /// <value>
    ///     The level.
    /// </value>
    public byte Level { get; set; }

    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    /// <value>
    ///     The identifier.
    /// </value>
    public uint Id { get; set; }

    /// <summary>
    ///     Gets the record.
    /// </summary>
    /// <value>
    ///     The record.
    /// </value>
    public RefSkillMastery Record => Game.ReferenceManager.GetRefSkillMastery(Id);

    /// <summary>
    ///     Froms the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    internal static MasteryInfo FromPacket(Packet packet)
    {
        return new MasteryInfo { Id = packet.ReadUInt(), Level = packet.ReadByte() };
    }
}
