using RSBot.Core.Plugins;
using RSBot.General.Views;
using System.Windows.Forms;

namespace RSBot.General
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
            DisplayName = "General",
            InternalName = "RSBot.General",
            LoadIndex = 1,
            TabDisplayIndex = 0,
            RequireIngame = false
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Views.View.Instance = new Main();

            Core.Log.Notify("Plugin [General] initialized!");
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