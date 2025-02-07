using Avalonia.Controls;
using RSBot.Extensions;
using RSBot.ViewModels.Dialogs;

namespace RSBot.Views.Dialogs;

/// <summary>
/// Dialog for configuring application settings
/// </summary>
public partial class SettingsDialog : Window
{
    public SettingsDialog()
    {
        InitializeComponent();
        DataContext = new SettingsDialogViewModel(this);

        this.Opened += (_, __) =>
        {
            this.EnableMica();
            this.EnableDarkMode();
        };
    }
} 