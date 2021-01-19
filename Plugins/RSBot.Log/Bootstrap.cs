using RSBot.Core.Plugins;
using System.Windows.Forms;

namespace RSBot.Log
{
    public class Bootstrap : IPlugin
    {
        /// <summary>
        /// Created log component control
        /// </summary>
        private Views.Main _control;

        /// <summary>
        /// Gets or sets the information of the plugin.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public PluginInfo Information => new PluginInfo
        {
            DisplayAsTab = true,
            DisplayName = "Log",
            InternalName = "RSBot.Log",
            LoadIndex = 0,
            TabDisplayIndex = 100,
            RequireIngame = false
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            _control = new Views.Main();

            Core.Log.Notify("Plugin [Log] initialized!");
        }

        /// <summary>
        /// Gets the view that will be displayed as tab page.
        /// </summary>
        public Control GetView()
        {
            return _control;
        }
    }
}