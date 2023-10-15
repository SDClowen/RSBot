using RSBot.Core.Objects;

namespace RSBot.Party.Bundle.AutoParty;

internal class AutoPartyConfig
{
    /// <summary>
    ///     Gets or sets the player list.
    /// </summary>
    /// <value>
    ///     The player list.
    /// </value>
    public string[] PlayerList { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [invite from list].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [invite from list]; otherwise, <c>false</c>.
    /// </value>
    public bool InviteFromList { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [invite all].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [invite all]; otherwise, <c>false</c>.
    /// </value>
    public bool InviteAll { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [accept from list].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [accept from list]; otherwise, <c>false</c>.
    /// </value>
    public bool AcceptFromList { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [accept all].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [accept all]; otherwise, <c>false</c>.
    /// </value>
    public bool AcceptAll { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [only at training place].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [only at training place]; otherwise, <c>false</c>.
    /// </value>
    public bool OnlyAtTrainingPlace { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [experience automatic share].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [experience automatic share]; otherwise, <c>false</c>.
    /// </value>
    public bool ExperienceAutoShare { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [item automatic share].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [item automatic share]; otherwise, <c>false</c>.
    /// </value>
    public bool ItemAutoShare { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [allow invitations].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [allow invitations]; otherwise, <c>false</c>.
    /// </value>
    public bool AllowInvitations { get; set; }

    /// <summary>
    ///     Gets or sets the center position.
    /// </summary>
    /// <value>
    ///     The center position.
    /// </value>
    public Position CenterPosition { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [accept if bot is stopped].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [accept if bot is stopped]; otherwise, <c>false</c>.
    /// </value>
    public bool AcceptIfBotIsStopped { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [leave if party master is not N].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [leave if party master is not N]; otherwise, <c>false</c>.
    /// </value>
    public bool LeaveIfMasterNot { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [leave if party master is not N].
    /// </summary>
    public string LeaveIfMasterNotName { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether auto join by name.
    /// </summary>
    /// <value>
    ///     <c>true</c> if [auto join by name]; otherwise, <c>false</c>.
    /// </value>
    public bool AutoJoinByName { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether auto join by title.
    /// </summary>
    /// <value>
    ///     <c>true</c> if [auto join by title]; otherwise, <c>false</c>.
    /// </value>
    public bool AutoJoinByTitle { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether auto join by name content.
    /// </summary>
    public string AutoJoinByNameContent { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether auto join by title content.
    /// </summary>
    public string AutoJoinByTitleContent { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether always follow the party master.
    /// </summary>
    public bool AlwaysFollowThePartyMaster { get; set; }
}