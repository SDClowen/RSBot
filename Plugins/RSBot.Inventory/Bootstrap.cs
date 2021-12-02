using RSBot.Core.Plugins;
using RSBot.Inventory.Subscriber;
using RSBot.Inventory.Views;
using System.Windows.Forms;

namespace RSBot.Inventory
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
            DisplayName = "Inventory",
            InternalName = "RSBot.Invenotry",
            LoadIndex = 6,
            TabDisplayIndex = 6
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Views.View.Instance = new Main();

            BuyItemSubscriber.SubscribeEvents();
            Core.Log.Notify("Plugin [Inventory] initialized!");
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