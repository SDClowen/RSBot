using RSBot.GUI.Utility.Element;
using System.Windows.Controls;

namespace RSBot.GUI.Controls
{
    public class MetroMenuSeparator : Separator
    {
        static MetroMenuSeparator()
        {
            ElementBase.DefaultStyle<MetroMenuSeparator>(DefaultStyleKeyProperty);
        }
    }
}