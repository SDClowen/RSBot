namespace RSBot.CommandCenter.Views;

/// <summary>
/// Static class to manage the main view instance
/// </summary>
internal class View
{
    /// <summary>
    /// Gets the singleton instance of the main view
    /// </summary>
    public static Main Instance { get; } = new();
} 