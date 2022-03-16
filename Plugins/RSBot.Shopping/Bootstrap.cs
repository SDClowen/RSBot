using RSBot.Core;
using RSBot.Core.Plugins;
using RSBot.Shopping.Views;
using System.Windows.Forms;

namespace RSBot.Shopping
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
            DisplayName = "Items",
            InternalName = "RSBot.Items",
            LoadIndex = 5,
            TabDisplayIndex = 5,
            RequireIngame = true
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Views.View.Instance = new Main();
            Log.Notify("Plugin [Shopping] initialized!");
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