namespace RSBot.Protection.Views;

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
}
