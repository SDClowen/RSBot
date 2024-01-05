using RSBot.GUI.Controls;
using System;
using System.Windows;
using System.Windows.Media;

namespace RSBot.GUI
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (FrameworkElement fe in lists.Children)
            {
                if (fe is MetroExpander)
                {
                    (fe as MetroExpander).Click += delegate (object sender, EventArgs e)
                    {
                        if ((fe as MetroExpander).CanHide)
                        {
                            foreach (FrameworkElement fe1 in lists.Children)
                            {
                                if (fe1 is MetroExpander && fe1 != sender)
                                {
                                    (fe1 as MetroExpander).IsExpanded = false;
                                }
                            }
                        }
                    };
                }
            }
        }

        public bool IsDarkerColor(Color color)
        {
            var a = color.A;
            var r = color.R;
            var g = color.G;
            var b = color.B;
            var hsp = Math.Sqrt(0.299 * (r * r) + 0.587 * (g * g) + 0.114 * (b * b));

            return hsp < 127.5;
        }

        private void MetroColorPicker_ColorChange(object sender, EventArgs e)
        {
            var colorPicker = sender as MetroColorPicker;

            BorderBrush = colorPicker.CurrentColor.OpaqueSolidColorBrush;

            if (IsDarkerColor(colorPicker.CurrentColor.OpaqueSolidColorBrush.Color))
                TitleForeground = Foreground = Brushes.White;
            else
                TitleForeground = Foreground = Brushes.Black;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {// Get PresentationSource
            PresentationSource presentationSource = PresentationSource.FromVisual((Visual)sender);
            
        }
    }
}