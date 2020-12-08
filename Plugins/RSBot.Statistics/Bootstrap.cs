using RSBot.Core;
using RSBot.Core.Plugins;
using RSBot.Statistics.Stats;
using System.Windows.Forms;

namespace RSBot.Statistics
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
            InternalName = "RSBot.Statistics",
            DisplayName = "Statistics",
            LoadIndex = 100,
            RequireIngame = true,
            TabDisplayIndex = 99
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Initialize()
        {
            CalculatorRegistry.Initialize();

            Log.Notify("Plugin [Statistics] initialized!");
        }

        /// <summary>
        /// Gets the view that will be displayed as tab page.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Control GetView()
        {
            return new Views.Main();
        }
    }
}