using Avalonia.Controls;

namespace RSBot.Core.Plugins;

public interface IExtension
{
    /// <summary>
    /// Gets the internal name of the plugin
    /// </summary>
    string InternalName { get; }

    /// <summary>
    /// Gets the display name of the plugin
    /// </summary>
    string DisplayName { get; }

    /// <summary>
    ///     Gets the view.
    /// </summary>
    /// <returns></returns>
    Control View { get; }

    /// <summary>
    ///     Translate the botbase plugin
    /// </summary>
    void Translate();
}
