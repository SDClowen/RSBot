using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.General.ViewModels;

namespace RSBot.General.Views;

/// <summary>
/// Main view for the General plugin that provides core functionality for managing the bot and client settings
/// </summary>
public partial class Main : UserControl
{
    /// <summary>
    /// Initializes a new instance of the Main view
    /// </summary>
    public Main()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
} 