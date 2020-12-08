using RSBot.Core;
using RSBot.Core.Plugins;
using RSBot.LanguageWizard.Views;
using System.Windows.Forms;

namespace RSBot.LanguageWizard
{
    public class Bootstrap : IPlugin
    {
        /// <summary>
        /// Gets or sets the information of the plugin.
        /// </summary>
        /// <value>The information.</value>
        public PluginInfo Information => new PluginInfo
        {
            DisplayAsTab = false,
            DisplayName = "Language Wizard",
            InternalName = "RSBot.LanguageWizard",
            RequireIngame = false,
            LoadIndex = 0
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Log.Notify("Plugin [LanguageWizard] initialized!");
        }

        /// <summary>
        /// Gets the view that will be displayed as tab page.
        /// </summary>
        /// <returns>Control.</returns>
        public Control GetView()
        {
            return new Main();
        }
    }
}