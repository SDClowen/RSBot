using RSBot.GUI.Utility.Element;
using System.Windows.Controls;

namespace RSBot.GUI.Controls
{
    public class MetroTitleMenu : Menu
    {
        public MetroTitleMenu()
        {
            Utility.Refresh(this);
        }

        static MetroTitleMenu()
        {
            ElementBase.DefaultStyle<MetroTitleMenu>(DefaultStyleKeyProperty);
        }
    }
}