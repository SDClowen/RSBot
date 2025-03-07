using Avalonia.Controls;
using RSBot.Core;
using RSBot.Core.Plugins;
using RSBot.Party.Views;
using RSBot.Party.Subscribers;
using RSBot.Party;
using RSBot.Core.Components;

namespace RSBot.Party;

/// <summary>
/// Plugin implementation for the Party management system in RSBot
/// </summary>
public class Plugin : IPlugin
{
    /// <summary>
    /// Gets the display name of the plugin
    /// </summary>
    public string DisplayName => "Party";

    /// <summary>
    /// Gets the internal name of the plugin
    /// </summary>
    public string InternalName => "RSBot.Party";

    /// <summary>
    /// Gets if the plugin should be displayed as a tab
    /// </summary>
    public bool DisplayAsTab => true;

    /// <summary>
    /// Gets the tab control for the plugin
    /// </summary>
    private Control _view;

    /// <summary>
    /// Initializes the plugin
    /// </summary>
    public void Initialize()
    {
        App.Initialize();
        _view = new MainView();

        Bundle.Container.Refresh();
        PartySubscriber.Initialize();

        Log.Debug("[Party] Plugin initialized!");
    }

    /// <summary>
    /// Gets the view that will be displayed in the tab
    /// </summary>
    public Control View => _view;

    /// <summary>
    /// Gets the display order of the plugin
    /// </summary>
    public int Index => 33;

    /// <summary>
    /// Gets a value indicating whether the plugin requires the game to be running
    /// </summary>
    public bool RequireIngame => true;

    /// <summary>
    /// Translates the plugin
    /// </summary>
    public void Translate()
    {
        LanguageManager.Translate(View);
    }
} 