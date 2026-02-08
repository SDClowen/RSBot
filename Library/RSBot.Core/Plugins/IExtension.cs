using System.Windows.Forms;

namespace RSBot.Core.Plugins;

public interface IExtension
{
    /// <summary>
    /// Gets the name of the author associated with the content.
    /// </summary>
    string Author { get; }

    /// <summary>
    /// Gets the description associated with the current instance.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Gets the internal name of the plugin
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the display name of the plugin
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Gets the version information for the current instance.
    /// </summary>
    string Version { get; }

    /// <summary>
    ///     Gets or sets a value indicating whether the plugin is enabled.
    /// </summary>
    /// <value>
    ///     <c>true</c> if enabled; otherwise, <c>false</c>.
    /// </value>
    public bool Enabled { get; set; }

    /// <summary>
    /// Initializes the component and prepares it for use.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Gets the control that represents the view associated with this instance.
    /// </summary>
    Control View { get; }

    /// <summary>
    /// Applies a translation operation to the current object.
    /// </summary>
    void Translate();

    /// <summary>
    /// Enables the plugin.
    /// </summary>
    void Enable();

    /// <summary>
    /// Disables the plugin.
    /// </summary>
    void Disable();
}
