using RSBot.GUI.Utility.Element;
using System.Windows.Controls;

namespace RSBot.GUI.Controls
{
    public class MetroTextButton : Button
    {
        static MetroTextButton()
        {
            ElementBase.DefaultStyle<MetroTextButton>(DefaultStyleKeyProperty);
        }
    }
}