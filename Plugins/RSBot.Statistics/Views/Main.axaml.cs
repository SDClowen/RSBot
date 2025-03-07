using Avalonia.Controls;
using Avalonia.ReactiveUI;
using RSBot.Statistics.ViewModels;

namespace RSBot.Statistics.Views;

/// <summary>
/// Main view for displaying statistics and managing filters
/// </summary>
public partial class Main : UserControl
{
    private static Main _instance;

    /// <summary>
    /// Gets the singleton instance of the Main view
    /// </summary>
    public static Main Instance => _instance ??= new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class
    /// </summary>
    public Main()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
} 