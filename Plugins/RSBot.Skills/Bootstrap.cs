using RSBot.Core.Plugins;
using RSBot.Skills.Views;
using System.Windows.Forms;

namespace RSBot.Skills
{
    public class Bootstrap : IPlugin
    {
        public PluginInfo Information => new PluginInfo
        {
            DisplayAsTab = true,
            DisplayName = "Skills",
            InternalName = "RSBot.Skills",
            LoadIndex = 2,
            TabDisplayIndex = 2
        };

        /// <inheritdoc />
        public void Initialize()
        {
            Views.View.Instance = new Main();
            Core.Log.Notify("Plugin [Skills] initialized!");
        }

        /// <inheritdoc />
        public Control GetView()
        {
            return Views.View.Instance;
        }
    }
}