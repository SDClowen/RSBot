using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;

namespace RSBot.ServerInfo;

public class ServerInfo : IPlugin
{
    /// <inheritdoc />
    public string InternalName => "RSBot.ServerInfo";

    /// <inheritdoc />
    public string DisplayName => "Server Information";

    /// <inheritdoc />
    public bool DisplayAsTab => false;

    /// <inheritdoc />
    public int Index => 100;

    /// <inheritdoc />
    public bool RequireIngame => false;

    /// <inheritdoc />
    public void Initialize()
    {
        Log.Notify("[Server Information] Plugin initialized!");
    }

    /// <inheritdoc />
    public Control View => Views.View.Main;

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
