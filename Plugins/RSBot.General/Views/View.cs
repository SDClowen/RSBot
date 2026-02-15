namespace RSBot.General.Views;

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
    ///     Gets or sets the instance.
    /// </summary>
    /// <value>
    ///     The instance.
    /// </value>
    public static PendingWindow PendingWindow { get; } = new();

    /// <summary>
    ///     Gets or sets the instance.
    /// </summary>
    /// <value>
    ///     The instance.
    /// </value>
    public static AccountsWindow AccountsWindow { get; } = new();

    /// <summary>
    ///     Gets or sets the instance.
    /// </summary>
    /// <value>
    ///     The instance.
    /// </value>
    public static SoundNotificationWindow SoundNotificationWindow { get; } = new();
}
