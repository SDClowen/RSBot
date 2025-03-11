using Avalonia.Controls;
using RSBot.Core.Plugins;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.CommandCenter.Components;

namespace RSBot.CommandCenter;

/// <summary>
/// Bootstrap class for the command center plugin
/// </summary>
public class Bootstrap : IPlugin
{
    /// <summary>
    /// Gets the internal name of the plugin
    /// </summary>
    public string InternalName => "RSBot.CommandCenter";

    /// <summary>
    /// Gets the display name of the plugin
    /// </summary>
    public string DisplayName => "Command Center";

    /// <summary>
    /// Gets a value indicating whether the plugin should be displayed as a tab
    /// </summary>
    public bool DisplayAsTab => false;

    /// <summary>
    /// Gets the display order of the plugin
    /// </summary>
    public int Index => 97;

    /// <summary>
    /// Gets a value indicating whether the plugin requires the game to be running
    /// </summary>
    public bool RequireIngame => false;

    /// <summary>
    /// Gets the main view of the plugin
    /// </summary>
    public Control View => Views.View.Instance;

    /// <summary>
    /// Initializes the plugin
    /// </summary>
    public void Initialize()
    {
        // Subscribe to events
        //EventManager.SubscribeEvent("OnEmoticonReceived", OnEmoticonReceived);
        //EventManager.SubscribeEvent("OnChatReceived", OnChatReceived);
    }

    /// <summary>
    /// Translates the plugin's UI elements
    /// </summary>
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <summary>
    /// Handles the emoticon received event
    /// </summary>
    private void OnEmoticonReceived(string emoticonName)
    {
        if (!PlayerConfig.Get("RSBot.CommandCenter.Enabled", true))
            return;

        var command = PluginConfig.GetAssignedEmoteCommand(emoticonName);
        if (string.IsNullOrEmpty(command) || command == "none")
            return;

        CommandManager.Execute(command);
    }

    /// <summary>
    /// Handles the chat received event
    /// </summary>
    private void OnChatReceived(string message)
    {
        if (!PlayerConfig.Get("RSBot.CommandCenter.Enabled", true))
            return;

        if (!message.StartsWith("\\"))
            return;

        var command = message.TrimStart('\\').Split(' ')[0];
        CommandManager.Execute(command);
    }
} 