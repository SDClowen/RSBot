using RSBot.Core.Plugins;
using RSBot.Party.Subscribers;
using RSBot.Party.Views;
using System.Windows.Forms;

namespace RSBot.Party
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
            DisplayName = "Party",
            InternalName = "RSBot.Party",
            LoadIndex = 5,
            TabDisplayIndex = 5
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Views.View.Instance = new Main();
            PartySubscriber.SubscribeEvents();

            Core.Log.Notify("Plugin [Party] initialized!");
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