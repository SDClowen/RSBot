using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using SDUI.Controls;

namespace RSBot.Log;

public class Bootstrap : IPlugin
{
    /// <inheritdoc />
    public string InternalName => "RSBot.Log";

    /// <inheritdoc />
    public string DisplayName => "Log";

    /// <inheritdoc />
    public bool DisplayAsTab => true;

    /// <inheritdoc />
    public int Index => 99;

    /// <inheritdoc />
    public bool RequireIngame => false;

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
        // do nothing
    }
}
