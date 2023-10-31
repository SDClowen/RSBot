using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Core.Objects.Party;

namespace RSBot.Party.Bundle.PartyMatching.Objects;

internal class PartyEntry
{
    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    /// <value>
    ///     The identifier.
    /// </value>
    public uint Id { get; set; }

    /// <summary>
    ///     Gets or sets the leader.
    /// </summary>
    /// <value>
    ///     The leader.
    /// </value>
    public string Leader { get; set; }

    /// <summary>
    ///     Gets or sets the maximum level.
    /// </summary>
    /// <value>
    ///     The maximum level.
    /// </value>
    public byte MaxLevel { get; set; }

    /// <summary>
    ///     Gets or sets the member count.
    /// </summary>
    /// <value>
    ///     The member count.
    /// </value>
    public byte MemberCount { get; set; }

    /// <summary>
    ///     Gets or sets the minimum level.
    /// </summary>
    /// <value>
    ///     The minimum level.
    /// </value>
    public byte MinLevel { get; set; }

    /// <summary>
    ///     Gets or sets the purpose.
    /// </summary>
    /// <value>
    ///     The purpose.
    /// </value>
    public PartyPurpose Purpose { get; set; }

    /// <summary>
    ///     Gets or sets the race.
    /// </summary>
    /// <value>
    ///     The race.
    /// </value>
    public ObjectCountry Race { get; set; }

    /// <summary>
    ///     Gets or sets the settings.
    /// </summary>
    /// <value>
    ///     The settings.
    /// </value>
    public PartySettings Settings { get; set; }

    /// <summary>
    ///     Gets or sets the title.
    /// </summary>
    /// <value>
    ///     The title.
    /// </value>
    public string Title { get; set; }

    public static PartyEntry FromPacket(Packet packet)
    {
        var result = new PartyEntry
        {
            Id = packet.ReadUInt()
        };

        packet.ReadUInt(); // leaderUniqueId

        if (Game.ClientType >= GameClientType.Global &&
            Game.ClientType != GameClientType.Rigid)
            packet.ReadUInt(); // unknown

        result.Leader = packet.ReadString();
        result.Race = (ObjectCountry)packet.ReadByte();
        result.MemberCount = packet.ReadByte();
        result.Settings = PartySettings.FromType(packet.ReadByte());
        result.Purpose = (PartyPurpose)packet.ReadByte();
        result.MinLevel = packet.ReadByte();
        result.MaxLevel = packet.ReadByte();
        result.Title = packet.ReadConditonalString();

        return result;
    }
}