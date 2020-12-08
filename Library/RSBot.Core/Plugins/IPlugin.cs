namespace RSBot.Core.Plugins
{
    public interface IPlugin
    {
        /// <summary>
        /// Gets or sets the information of the plugin.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        PluginInfo Information { get; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Gets the view that will be displayed as tab page.
        /// </summary>
        System.Windows.Forms.Control GetView();
    }
}