using Avalonia.Controls;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;

namespace RSBot.Chat;

/// <summary>
/// Bootstrap class for the chat plugin
/// </summary>
public class Bootstrap : IPlugin
{
    /// <summary>
    /// Gets the internal name of the plugin
    /// </summary>
    public string InternalName => "RSBot.Chat";

    /// <summary>
    /// Gets the display name of the plugin
    /// </summary>
    public string DisplayName => "Chat";

    /// <summary>
    /// Gets a value indicating whether the plugin should be displayed as a tab
    /// </summary>
    public bool DisplayAsTab => true;

    /// <summary>
    /// Gets the display order of the plugin
    /// </summary>
    public int Index => 98;

    /// <summary>
    /// Gets a value indicating whether the plugin requires the game to be running
    /// </summary>
    public bool RequireIngame => true;

    /// <summary>
    /// Gets the main view of the plugin
    /// </summary>
    public Control View => Views.View.Instance;

    /// <summary>
    /// Initializes the plugin
    /// </summary>
    public void Initialize()
    {
    }

    /// <summary>
    /// Translates the plugin's UI elements
    /// </summary>
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }
} 