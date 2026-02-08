using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;

namespace RSBot.ServerInfo;

public class ServerInfo : IPlugin
{
    /// <inheritdoc />
    public string Author => "RSBot Team";

    /// <inheritdoc />
    public string Description => "Provides information about the server, such as uptime, player count, and more.";

    /// <inheritdoc />
    public string Name => "RSBot.ServerInfo";

    /// <inheritdoc />
    public string Title => "Server Information";

    /// <inheritdoc />
    public string Version => "1.0.0";

    /// <inheritdoc />
    public bool Enabled { get; set; }

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

    /// <inheritdoc />
    public void Enable()
    {
        if (View != null)
            View.Enabled = true;
    }

    /// <inheritdoc />
    public void Disable()
    {
        if (View != null)
            View.Enabled = false;
    }
}
