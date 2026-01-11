using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using SDUI.Controls;

namespace RSBot.CommandCenter;

public class CommandCenterPlugin : IPlugin
{
    /// <inheritdoc />
    public string InternalName => "RSBot.CommandCenter";

    /// <inheritdoc />
    public string DisplayName => "Command center";

    /// <inheritdoc />
    public bool DisplayAsTab => false;

    /// <inheritdoc />
    public int Index => 100;

    /// <inheritdoc />
    public bool RequireIngame => true;

    /// <inheritdoc />
    public void Initialize()
    {
        Log.Notify("[Command Center] Plugin initialized!");
    }

    /// <inheritdoc />
    public IUIElement View => Views.View.Main;

    /// <inheritdoc />
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <inheritdoc />
    public void OnLoadCharacter()
    {
        // do nothing
    }
}
