using System.Windows.Forms;

namespace RSBot.Core.Plugins;

public interface IPlugin
{
    /// <summary>
    ///     Gets or sets the internal name of the plugin.
    ///     This value should be unique.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string InternalName { get; }

    /// <summary>
    ///     Gets or sets the name that will be displayed in the application.
    /// </summary>
    /// <value>
    ///     The title.
    /// </value>
    public string DisplayName { get; }

    /// <summary>
    ///     Gets or sets a value indicating whether [display as tab].
    ///     If the value is set to true, the application will display the plugin as new tab-control item.
    /// </summary>
    /// <value>
    ///     <c>true</c> if [display as tab]; otherwise, <c>false</c>.
    /// </value>
    public bool DisplayAsTab { get; }

    /// <summary>
    ///     Gets or sets the index of the tab.
    ///     The lower the value the earlier the tab will be displayed.
    ///     Does not affect anything if <see cref="DisplayAsTab" /> is false.
    /// </summary>
    /// <value>
    ///     The index of the tab.
    /// </value>
    public int Index { get; }

    /// <summary>
    ///     Gets or sets a value indicating whether [require ingame].
    ///     If set to false, the tab page will be enabled all the time.
    /// </summary>
    /// <value>
    ///     <c>true</c> if [require ingame]; otherwise, <c>false</c>.
    /// </value>
    public bool RequireIngame { get; }

    /// <summary>
    ///     Gets the view that will be displayed as tab page.
    /// </summary>
    Control View { get; }

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    void Initialize();

    /// <summary>
    ///     Initialzes objects when user is loaded.
    /// </summary>
    void OnLoadCharacter();

    /// <summary>
    ///     Translate the plugin
    /// </summary>
    void Translate();
}
