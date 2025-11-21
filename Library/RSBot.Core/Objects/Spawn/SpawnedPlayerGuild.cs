using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn;

public class SpawnedPlayerGuild
{
    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    /// <value>
    ///     The identifier.
    /// </value>
    public uint Id { get; set; }

    /// <summary>
    ///     Gets or sets the member.
    /// </summary>
    /// <value>
    ///     The member.
    /// </value>
    public SpawnedPlayerGuildMember Member { get; set; }

    /// <summary>
    ///     Gets or sets the union.
    /// </summary>
    /// <value>
    ///     The union.
    /// </value>
    public SpawnedPlayerUnion Union { get; set; }

    /// <summary>
    ///     Gets or sets the last crest rev.
    /// </summary>
    /// <value>
    ///     The last crest rev.
    /// </value>
    public uint LastCrestRev { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is friendly.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is friendly; otherwise, <c>false</c>.
    /// </value>
    public bool IsFriendly { get; set; }

    /// <summary>
    ///     Froms the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    internal static SpawnedPlayerGuild FromPacket(Packet packet)
    {
        var result = new SpawnedPlayerGuild
        {
            Id = packet.ReadUInt(),
            Member = new SpawnedPlayerGuildMember { Nickname = packet.ReadString() },
            LastCrestRev = packet.ReadUInt(),
            Union = new SpawnedPlayerUnion { Id = packet.ReadUInt(), LastCrestRev = packet.ReadUInt() },
        };

        if (Game.ClientType >= GameClientType.Thailand)
        {
            result.IsFriendly = packet.ReadBool();
            result.Member.FortSiegeAuthority = (FortSiegeAuthority)packet.ReadByte();
        }

        return result;
    }
}
