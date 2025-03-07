using Avalonia.Controls;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using RSBot.Items.Avalonia.Views;

namespace RSBot.Items.Avalonia;

/// <summary>
/// Bootstrap class for the Items plugin that handles plugin initialization and cleanup.
/// This class is responsible for initializing the plugin's services and views.
/// </summary>
public class Bootstrap : IPlugin
{
    /// <summary>
    /// Gets the internal name of the plugin
    /// </summary>
    public string InternalName => "RSBot.Items.Avalonia";

    /// <summary>
    /// Gets the display name of the plugin
    /// </summary>
    public string DisplayName => "Items";

    /// <summary>
    /// Gets a value indicating whether the plugin should be displayed as a tab
    /// </summary>
    public bool DisplayAsTab => true;

    /// <summary>
    /// Gets the display order of the plugin
    /// </summary>
    public int Index => 5;

    /// <summary>
    /// Gets a value indicating whether the plugin requires the game to be running
    /// </summary>
    public bool RequireIngame => false;

    /// <summary>
    /// Gets the main view of the plugin
    /// </summary>
    public Control View => Views.View.Instance;

    /// <summary>
    /// Initializes the plugin by setting up services and views
    /// </summary>
    public void Initialize()
    {
        Log.Debug($"[{DisplayName}] Plugin initialized!");
    }

    /// <summary>
    /// Translates the plugin using the language manager
    /// </summary>
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }
} 