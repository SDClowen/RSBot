using Avalonia.Controls;
using RSBot.Protection.ViewModels;

namespace RSBot.Protection.Views;

/// <summary>
/// Main view for protection settings that manages HP and MP protection configurations
/// </summary>
public partial class Main : UserControl
{
    private static Main _instance;

    /// <summary>
    /// Gets the singleton instance of the Main view
    /// </summary>
    public static Main Instance => _instance ??= new();

    /// <summary>
    /// Initializes a new instance of the Main view
    /// </summary>
    public Main()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
} 