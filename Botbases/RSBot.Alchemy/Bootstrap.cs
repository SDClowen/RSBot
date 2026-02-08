using RSBot.Alchemy.Bot;
using RSBot.Alchemy.Subscriber;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Plugins;
using System.Windows.Forms;

namespace RSBot.Alchemy;

public class Bootstrap : IBotbase
{
    private static readonly string _name = "RSBot.Alchemy";

    /// <summary>
    /// Gets a value indicating whether the bot instance with the specified name is currently active.
    /// </summary>
    /// <remarks>The property returns <see langword="true"/> only if the bot is running and its base name
    /// matches the specified name. Use this property to check the operational status of a particular bot
    /// instance.</remarks>
    public static bool IsActive => Kernel.Bot.Running && Kernel.Bot.Botbase.Name == _name;

    /// <inheritdoc />
    public string Author => "RSBot Team";

    /// <inheritdoc />
    public string Description => "Automates the alchemy process in RuneScape, allowing players to efficiently convert items into gold or other valuable resources.";

    /// <inheritdoc />
    public string Name => _name;

    /// <inheritdoc />
    public string Title => "Alchemy";

    /// <inheritdoc />
    public string Version => "1.0.0";

    /// <inheritdoc />
    public bool Enabled { get; set; }

    /// <inheritdoc />
    public Area Area => new();

    /// <inheritdoc />
    public Control View => Globals.View;

    /// <inheritdoc />
    public void Start()
    {
        Globals.Botbase?.Start();

        Log.AppendFormat(LogLevel.Debug, "[Alchemy] Starting automated alchemy...");
    }

    /// <inheritdoc />
    public void Stop()
    {
        if (Globals.Botbase != null)
            Globals.Botbase.Stop();

        Log.AppendFormat(LogLevel.Debug, "[Alchemy] Stopped automated alchemy");
    }

    /// <inheritdoc />
    public void Tick()
    {
        if (!Globals.View.IsRefreshing && !AlchemyManager.IsFusing)
            Globals.Botbase.Tick();
    }

    /// <inheritdoc />
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <inheritdoc />
    public void Initialize()
    {
        AlchemyEventsSubscriber.Subscribe();
        Globals.Botbase = new Botbase();

        Log.AppendFormat(LogLevel.Notify, "[Alchemy] Initialized botbase");
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
