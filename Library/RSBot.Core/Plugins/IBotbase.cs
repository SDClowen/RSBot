using RSBot.Core.Objects;

namespace RSBot.Core.Plugins;

public interface IBotbase : IExtension
{
    /// <summary>
    ///     This value will be displayed as TabPage text in the main window.
    /// </summary>
    /// <value>
    ///     The tab text.
    /// </value>
    public string TabText { get; }

    /// <summary>
    ///     Gets the area.
    /// </summary>
    /// <value>
    ///     The area.
    /// </value>
    public Area Area { get; }

    /// <summary>
    ///     Ticks this instance.
    /// </summary>
    void Tick();

    /// <summary>
    ///     Starts this instance.
    /// </summary>
    void Start();

    /// <summary>
    ///     Stops this instance.
    /// </summary>
    void Stop();

    /// <summary>
    ///     Called when the botbase was registered to the kernel.
    /// </summary>
    void Register();
}