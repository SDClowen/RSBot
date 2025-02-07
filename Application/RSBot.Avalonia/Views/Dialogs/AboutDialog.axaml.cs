using Avalonia.Controls;
using RSBot.Extensions;
using RSBot.ViewModels.Dialogs;

namespace RSBot.Views.Dialogs;

/// <summary>
/// Dialog that displays information about the application
/// </summary>
public partial class AboutDialog : Window
{
    public AboutDialog()
    {
        InitializeComponent();
        DataContext = new AboutDialogViewModel(this);

        this.Opened += (_, __) =>
        {
            this.EnableMica();
            this.EnableDarkMode();
        };
    }
} 