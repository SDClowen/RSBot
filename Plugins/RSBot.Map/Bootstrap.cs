using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using SDUI.Controls;

namespace RSBot.Map;

public class Bootstrap : IPlugin
{
    /// <inheritdoc />
    public string InternalName => "RSBot.Map";

    /// <inheritdoc />
    public string DisplayName => "Map";

    /// <inheritdoc />
    public bool DisplayAsTab => true;

    /// <inheritdoc />
    public int Index => 6;

    /// <inheritdoc />
    public bool RequireIngame => true;

    /// <inheritdoc />
    public void Initialize() { }

    /// <inheritdoc />
    public IUIElement View => Views.View.Instance;

    /// <inheritdoc />
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <inheritdoc />
    public void OnLoadCharacter()
    {
        Views.View.Instance.InitUniqueObjects();
    }
}
