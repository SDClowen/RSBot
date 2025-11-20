using RSBot.Core.Network;

namespace RSBot.Core.Objects.Spawn;

public sealed class SpawnedFortressStructure : SpawnedNpc
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    /// <param name="objId">The ref obj id</param>
    public SpawnedFortressStructure(uint objId)
        : base(objId) { }

    /// <summary>
    /// </summary>
    /// <value>
    ///     The hp.
    /// </value>
    public uint HP { get; set; }

    /// <summary>
    ///     Gets or sets the reference event structure identifier.
    /// </summary>
    /// <value>
    ///     The reference event structure identifier.
    /// </value>
    public uint RefEventStructID { get; set; }

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    /// <value>
    ///     The state.
    /// </value>
    public ushort CurrentState { get; set; }

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    /// <value>
    ///     The state.
    /// </value>
    public uint GuildId { get; set; }

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    /// <value>
    ///     The state.
    /// </value>
    public string GuildName { get; set; }

    /// <summary>
    ///     Froms the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="bionic">The bionic.</param>
    /// <returns></returns>
    internal override void Deserialize(Packet packet)
    {
        HP = packet.ReadUInt();
        RefEventStructID = packet.ReadUInt();
        CurrentState = packet.ReadUShort();

        ParseBionicDetails(packet);

        base.Deserialize(packet);

        GuildId = packet.ReadUInt();
        GuildName = packet.ReadString();
    }
}
