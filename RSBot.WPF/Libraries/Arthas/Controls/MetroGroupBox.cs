using RSBot.GUI.Utility.Element;
using System.Windows.Controls;

namespace RSBot.GUI.Controls
{
    public class MetroGroupBox : GroupBox
    {
        static MetroGroupBox()
        {
            ElementBase.DefaultStyle<MetroGroupBox>(DefaultStyleKeyProperty);
        }
    }
}