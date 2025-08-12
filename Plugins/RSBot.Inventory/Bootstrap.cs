using Avalonia.Controls;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using RSBot.Inventory.Subscribers;

namespace RSBot.Inventory;

/// <summary>
/// Bootstrap class for the inventory plugin
/// </summary>
public class Bootstrap : IPlugin
{
    /// <summary>
    /// Gets the internal name of the plugin
    /// </summary>
    public string InternalName => "RSBot.Inventory";

    /// <summary>
    /// Gets the display name of the plugin
    /// </summary>
    public string DisplayName => "Inventory";

    /// <summary>
    /// Gets a value indicating whether the plugin should be displayed as a tab
    /// </summary>
    public bool DisplayAsTab => true;

    /// <summary>
    /// Gets the display order of the plugin
    /// </summary>
    public int Index => 4;

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
        BuyItemSubscriber.SubscribeEvents();
        InventoryUpdateSubscriber.SubscribeEvents();
        UseItemAtTrainplaceSubscriber.SubscribeEvents();
    }

    /// <summary>
    /// Translates the plugin's UI elements
    /// </summary>
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }
} 