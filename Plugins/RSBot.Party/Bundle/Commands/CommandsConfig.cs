namespace RSBot.Party.Bundle.Commands;

internal class CommandsConfig
{
    /// <summary>
    ///     Gets or sets the player list.
    /// </summary>
    /// <value>
    ///     The player list.
    /// </value>
    public string[] PlayerList { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [listen from list].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [listen from list]; otherwise, <c>false</c>.
    /// </value>
    public bool ListenFromList { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [only from master].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [only from master]; otherwise, <c>false</c>.
    /// </value>
    public bool ListenOnlyMaster { get; set; }
}