using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn;

public class SpawnedSpellArea : SpawnedEntity
{
    /// <summary>
    ///     Gets or sets the skill identifier.
    /// </summary>
    public uint SkillId;

    /// <summary>
    ///     Gets or sets the record.
    /// </summary>
    /// <value>
    ///     The record.
    /// </value>
    public new RefSkill Record => Game.ReferenceManager.GetRefSkill(SkillId);

    /// <summary>
    ///     Froms the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    internal static SpawnedSpellArea FromPacket(Packet packet)
    {
        //UNK0
        if (Game.ClientType >= GameClientType.Chinese)
            packet.ReadUInt();
        else
            packet.ReadUShort();

        var spellArea = new SpawnedSpellArea { SkillId = packet.ReadUInt(), UniqueId = packet.ReadUInt() };

        spellArea.Movement.Source = Position.FromPacket(packet);

        return spellArea;
    }
}
