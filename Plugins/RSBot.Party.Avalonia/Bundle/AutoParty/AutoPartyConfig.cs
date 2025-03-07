using RSBot.Core.Objects;

namespace RSBot.Party.Bundle.AutoParty;

/// <summary>
/// Configuration settings for auto party functionality
/// </summary>
public class AutoPartyConfig
{
    /// <summary>
    /// Gets or sets the list of players for auto party
    /// </summary>
    public string[] PlayerList { get; set; }

    /// <summary>
    /// Gets or sets whether to invite all players
    /// </summary>
    public bool InviteAll { get; set; }

    /// <summary>
    /// Gets or sets whether to accept all invitations
    /// </summary>
    public bool AcceptAll { get; set; }

    /// <summary>
    /// Gets or sets whether to accept invitations from listed players
    /// </summary>
    public bool AcceptFromList { get; set; }

    /// <summary>
    /// Gets or sets whether to invite players from the list
    /// </summary>
    public bool InviteFromList { get; set; }

    /// <summary>
    /// Gets or sets whether to only accept/invite at training place
    /// </summary>
    public bool OnlyAtTrainingPlace { get; set; }

    /// <summary>
    /// Gets or sets whether to auto share experience
    /// </summary>
    public bool ExperienceAutoShare { get; set; }

    /// <summary>
    /// Gets or sets whether to auto share items
    /// </summary>
    public bool ItemAutoShare { get; set; }

    /// <summary>
    /// Gets or sets whether to allow invitations
    /// </summary>
    public bool AllowInvitations { get; set; }

    /// <summary>
    /// Gets or sets whether to accept invitations when bot is stopped
    /// </summary>
    public bool AcceptIfBotIsStopped { get; set; }

    /// <summary>
    /// Gets or sets whether to leave if party master is not specified
    /// </summary>
    public bool LeaveIfMasterNot { get; set; }

    /// <summary>
    /// Gets or sets the name of the required party master
    /// </summary>
    public string LeaveIfMasterNotName { get; set; }

    /// <summary>
    /// Gets or sets the center position for training place check
    /// </summary>
    public Position CenterPosition { get; set; }

    /// <summary>
    /// Gets or sets whether to auto join by player name
    /// </summary>
    public bool AutoJoinByName { get; set; }

    /// <summary>
    /// Gets or sets whether to auto join by party title
    /// </summary>
    public bool AutoJoinByTitle { get; set; }

    /// <summary>
    /// Gets or sets the player name to auto join
    /// </summary>
    public string AutoJoinByNameContent { get; set; }

    /// <summary>
    /// Gets or sets the party title to auto join
    /// </summary>
    public string AutoJoinByTitleContent { get; set; }

    /// <summary>
    /// Gets or sets whether to always follow the party master
    /// </summary>
    public bool AlwaysFollowThePartyMaster { get; set; }
} 