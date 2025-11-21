using RSBot.Quest.Views.Sidebar;

namespace RSBot.Quest.Views;

internal class View
{
    private static Main _main = new();

    public static Main Main
    {
        get
        {
            if (_main == null || _main.IsDisposed)
                _main = new Main();

            return _main;
        }
    }

    public static QuestSidebarElement SidebarElement { get; internal set; } = null;
}
