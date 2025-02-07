using Avalonia.Controls;

namespace RSBot.Core.Plugins;

/// <summary>
/// Defines the interface for RSBot plugins
/// </summary>
public interface IPlugin
{
    /// <summary>
    /// Gets the internal name of the plugin
    /// </summary>
    string InternalName { get; }

    /// <summary>
    /// Gets the display name of the plugin
    /// </summary>
    string DisplayName { get; }

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
    /// Gets the main view of the plugin
    /// </summary>
    Control View { get; }

    /// <summary>
    /// Initializes the plugin
    /// </summary>
    void Initialize();

    /// <summary>
    /// Translates the plugin's UI elements
    /// </summary>
    void Translate();
}