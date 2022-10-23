using RSBot.Core;
using RSBot.Core.Plugins;
using RSBot.Skills.Views;

using System.Windows.Forms;
using RSBot.Skills.Subscriber;
using RSBot.Core.Components;

namespace RSBot.Skills;

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
        LoadCharacterSubscriber.SubscribeEvents();
    }

    /// <inheritdoc />
    public Control GetView()
    {
        return Views.View.Instance ?? (Views.View.Instance = new Main());
    }

    /// <summary>
    /// Translate the plugin
    /// </summary>
    public void Translate()
    {
        LanguageManager.Translate(GetView(), Kernel.Language);
    }
}