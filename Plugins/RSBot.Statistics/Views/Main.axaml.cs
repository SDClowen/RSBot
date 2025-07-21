using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using RSBot.Statistics.ViewModels;

namespace RSBot.Statistics.Views
{
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            this.Loaded += (sender, args) =>
            {
                if (DataContext is IActivatableViewModel activatable)
                {
                    activatable.Activator.Activate();
                }
            };

            this.Unloaded += (sender, args) =>
            {
                if (DataContext is IActivatableViewModel activatable)
                {
                    activatable.Activator.Deactivate();
                }
            };
        }
    }
}