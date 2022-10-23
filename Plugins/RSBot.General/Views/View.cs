namespace RSBot.General.Views;

internal class View
{
    /// <summary>
    /// Gets or sets the instance.
    /// </summary>
    /// <value>
    /// The instance.
    /// </value>
    public static Main Instance { get; } = new();

    /// <summary>
    /// Gets or sets the instance.
    /// </summary>
    /// <value>
    /// The instance.
    /// </value>
    public static PendingWindow PendingWindow { get; } = new();

    /// <summary>
    /// Gets or sets the instance.
    /// </summary>
    /// <value>
    /// The instance.
    /// </value>
    public static Accounts AccountsWindow { get; } = new();
}