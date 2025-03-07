namespace RSBot.Core.Plugins;

/// <summary>
/// Defines the interface for RSBot plugins
/// </summary>
public interface IPlugin : IExtension
{
    /// <summary>
    /// Gets a value indicating whether the plugin should be displayed as a tab
    /// </summary>
    bool DisplayAsTab { get; }

    /// <summary>
    /// Gets the display order of the plugin
    /// </summary>
    int Index { get; }

    /// <summary>
    /// Gets a value indicating whether the plugin requires the game to be running
    /// </summary>
    bool RequireIngame { get; }

    /// <summary>
    /// Initializes the plugin
    /// </summary>
    void Initialize();
}