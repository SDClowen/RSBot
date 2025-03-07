using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.Party.ViewModels;

namespace RSBot.Party.Views;

/// <summary>
/// Main view for the Party plugin that displays party management and matching functionality
/// </summary>
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = App.GetService<MainViewModel>();
    }
} 