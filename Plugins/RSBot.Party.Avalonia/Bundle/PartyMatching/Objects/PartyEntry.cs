using RSBot.Core.Objects.Party;

namespace RSBot.Party.Bundle.PartyMatching.Objects;

/// <summary>
/// Represents a party entry in the party matching system
/// </summary>
public class PartyEntry
{
    /// <summary>
    /// Gets or sets the unique identifier of the party
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the party
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the name of the party leader
    /// </summary>
    public string Leader { get; set; }

    /// <summary>
    /// Gets or sets the purpose of the party
    /// </summary>
    public PartyPurpose Purpose { get; set; }

    /// <summary>
    /// Gets or sets the minimum level requirement
    /// </summary>
    public byte LevelFrom { get; set; }

    /// <summary>
    /// Gets or sets the maximum level requirement
    /// </summary>
    public byte LevelTo { get; set; }

    /// <summary>
    /// Gets or sets the current number of members
    /// </summary>
    public byte Members { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of members allowed
    /// </summary>
    public byte MaxMembers { get; set; }

    /// <summary>
    /// Gets or sets whether the party is set to auto reform
    /// </summary>
    public bool AutoReform { get; set; }

    /// <summary>
    /// Gets or sets whether the party is set to auto accept members
    /// </summary>
    public bool AutoAccept { get; set; }
} 