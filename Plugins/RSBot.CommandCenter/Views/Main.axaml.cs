using Avalonia.Controls;
using RSBot.CommandCenter.Avalonia.ViewModels;

namespace RSBot.CommandCenter.Avalonia.Views;

/// <summary>
/// Main view for the Command Center plugin that provides interface for managing emoticon and chat commands
/// </summary>
public partial class Main : UserControl
{
    /// <summary>
    /// Gets the view model instance
    /// </summary>
    public MainViewModel ViewModel => DataContext as MainViewModel;

    /// <summary>
    /// Initializes a new instance of the Main class
    /// </summary>
    public Main()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
} 