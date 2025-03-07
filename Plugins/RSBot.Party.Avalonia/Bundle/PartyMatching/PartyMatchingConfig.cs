using RSBot.Core.Objects.Party;

namespace RSBot.Party.Bundle.PartyMatching;

/// <summary>
/// Configuration settings for party matching functionality
/// </summary>
public class PartyMatchingConfig
{
    /// <summary>
    /// Gets or sets the title of the party
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the minimum level requirement
    /// </summary>
    public byte LevelFrom { get; set; }

    /// <summary>
    /// Gets or sets the maximum level requirement
    /// </summary>
    public byte LevelTo { get; set; }

    /// <summary>
    /// Gets or sets the purpose of the party
    /// </summary>
    public PartyPurpose Purpose { get; set; }

    /// <summary>
    /// Gets or sets whether to automatically reform the party
    /// </summary>
    public bool AutoReform { get; set; }

    /// <summary>
    /// Gets or sets whether to automatically accept members
    /// </summary>
    public bool AutoAccept { get; set; }

    /// <summary>
    /// Gets or sets whether to automatically refresh the party list
    /// </summary>
    public bool AutoRefresh { get; set; }

    /// <summary>
    /// Gets or sets the refresh interval in milliseconds
    /// </summary>
    public int RefreshInterval { get; set; }

    /// <summary>
    /// Gets or sets whether to automatically join parties
    /// </summary>
    public bool AutoJoin { get; set; }

    /// <summary>
    /// Gets or sets whether to join only parties with specific titles
    /// </summary>
    public bool JoinByTitle { get; set; }

    /// <summary>
    /// Gets or sets the title pattern to match when auto-joining
    /// </summary>
    public string JoinTitlePattern { get; set; }
} 