using RSBot.Core.Plugins;
using RSBot.Map.Views;
using System.Windows.Forms;

namespace RSBot.Map
{
    public class Bootstrap : IPlugin
    {
        /// <summary>
        /// Gets or sets the information of the plugin.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public PluginInfo Information => new PluginInfo
        {
            DisplayAsTab = true,
            DisplayName = "Map",
            InternalName = "RSBot.Map",
            LoadIndex = 7,
            TabDisplayIndex = 7
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Views.View.Instance = new Main();
            Core.Log.Notify("Plugin [Map] initialized!");
        }

        /// <summary>
        /// Gets the view that will be displayed as tab page.
        /// </summary>
        public Control GetView()
        {
            return Views.View.Instance;
        }
    }
}