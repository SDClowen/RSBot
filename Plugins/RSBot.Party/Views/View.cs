namespace RSBot.Party.Views;

internal class View
{
    private static Main _instance;

    /// <summary>
    ///     Gets or sets the instance.
    /// </summary>
    /// <value>
    ///     The instance.
    /// </value>
    public static Main Instance => _instance ??= new();

    /// <summary>
    ///     Gets or sets the party window.
    /// </summary>
    /// <value>
    ///     The party window.
    /// </value>
    public static AutoFormParty PartyWindow { get; } = new();
}
