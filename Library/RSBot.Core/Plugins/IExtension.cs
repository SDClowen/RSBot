using System.Windows.Forms;

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
    ///     Gets or sets a value indicating whether the plugin is enabled.
    /// </summary>
    /// <value>
    ///     <c>true</c> if enabled; otherwise, <c>false</c>.
    /// </value>
    public bool Enabled { get; set; }

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    void Initialize();

    /// <summary>
    ///     Gets the view.
    /// </summary>
    /// <returns></returns>
    Control View { get; }

    /// <summary>
    ///     Translate the botbase plugin
    /// </summary>
    void Translate();

    /// <summary>
    ///     Enables the plugin.
    /// </summary>
    void Enable();

    /// <summary>
    ///     Disables the plugin.
    /// </summary>
    void Disable();
}
