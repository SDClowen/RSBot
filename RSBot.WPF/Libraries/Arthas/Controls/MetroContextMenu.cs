using RSBot.GUI.Utility.Element;
using System.Windows.Controls;

namespace RSBot.GUI.Controls
{
    public class MetroContextMenu : ContextMenu
    {
        public MetroContextMenu()
        {
            Utility.Refresh(this);
        }

        static MetroContextMenu()
        {
            ElementBase.DefaultStyle<MetroContextMenu>(DefaultStyleKeyProperty);
        }
    }
}