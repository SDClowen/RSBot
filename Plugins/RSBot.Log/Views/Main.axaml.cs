using Avalonia.Controls;
using RSBot.Log.ViewModels;

namespace RSBot.Log.Views;

/// <summary>
/// Main log view that displays and manages application logs with different log levels
/// </summary>
public partial class Main : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class
    /// </summary>
    public Main()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
} 