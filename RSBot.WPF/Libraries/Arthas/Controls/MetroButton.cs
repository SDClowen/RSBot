using RSBot.GUI.Utility.Element;
using System.Windows;
using System.Windows.Controls;

namespace RSBot.GUI.Controls
{
    public enum ButtonState
    {
        None,
        Red,
        Green
    }

    public class MetroButton : Button
    {
        public static readonly DependencyProperty MetroButtonStateProperty = ElementBase.Property<MetroButton, ButtonState>(nameof(MetroButtonStateProperty), ButtonState.None);

        public ButtonState MetroButtonState { get { return (ButtonState)GetValue(MetroButtonStateProperty); } set { SetValue(MetroButtonStateProperty, value); } }

        public MetroButton()
        {
            Utility.Refresh(this);
        }

        static MetroButton()
        {
            ElementBase.DefaultStyle<MetroButton>(DefaultStyleKeyProperty);
        }
    }
}