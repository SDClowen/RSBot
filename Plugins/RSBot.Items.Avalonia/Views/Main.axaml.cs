using Avalonia.Controls;

namespace RSBot.Items.Avalonia.Views;

/// <summary>
/// Main view for the RSBot Items plugin.
/// This view provides the user interface for managing shopping lists and item filters,
/// using Avalonia UI framework and ReactiveUI for MVVM implementation.
/// </summary>
public partial class Main : UserControl
{
    public Main()
    {
        InitializeComponent();

        DataContext = new ViewModels.MainViewModel();
    }
} 