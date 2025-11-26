using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Plugins;
using RSBot.Quest.Views.Sidebar;

namespace RSBot.Quest;

public class QuestPlugin : IPlugin
{
    public string InternalName => "RSBot.QuestLog";
    public string DisplayName => "Quests";
    public bool DisplayAsTab => false;
    public int Index => 0;
    public bool RequireIngame => true;

    public void Initialize()
    {
        Views.View.SidebarElement = new QuestSidebarElement();

        EventManager.FireEvent("OnAddSidebarElement", Views.View.SidebarElement);
    }

    public Control View => Views.View.Main;

    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <inheritdoc />
    public void OnLoadCharacter()
    {
        // do nothing
    }
}
