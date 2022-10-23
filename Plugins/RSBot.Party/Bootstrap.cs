using RSBot.Core;
using RSBot.Core.Components;
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
            LoadIndex = 4,
            TabDisplayIndex = 4
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Views.View.PartyWindow = new AutoFormParty();

            PartySubscriber.SubscribeEvents();
        }

        /// <summary>
        /// Gets the view that will be displayed as tab page.
        /// </summary>
        public Control GetView()
        {
            return Views.View.Instance ?? (Views.View.Instance = new Main());
        }

        /// <summary>
        /// Translate the plugin
        /// </summary>
        /// <param name="language">The language</param>
        public void Translate()
        {
            LanguageManager.Translate(GetView(), Kernel.Language);
            LanguageManager.Translate(Views.View.PartyWindow, Kernel.Language);
        }
    }
}