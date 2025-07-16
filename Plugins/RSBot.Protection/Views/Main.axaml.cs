using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RSBot.Protection.ViewModels;
using System.Reactive;

namespace RSBot.Protection.Views;

public partial class Main : UserControl
{
    private static Main _instance;

    /// <summary>
    /// Gets the singleton instance of the Main view
    /// </summary>
    public static Main Instance { get; } = _instance ?? new();

    public Main()
    {
        InitializeComponent();
        _instance = this;
    }

    private void Main_Load(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel viewModel)
            viewModel.LoadedCommand.Execute(Unit.Default);
    }
}