using Avalonia.Controls;
using RSBot.Extensions;
using RSBot.ViewModels.Dialogs;

namespace RSBot.Views.Dialogs;

/// <summary>
/// Dialog for selecting and managing profiles
/// </summary>
public partial class ProfileSelectionDialog : Window
{
    public string SelectedProfile => (DataContext as ProfileSelectionDialogViewModel)?.SelectedProfile;

    public ProfileSelectionDialog()
    {
        InitializeComponent();
        DataContext = new ProfileSelectionDialogViewModel(this);

        this.Opened += (_, __) =>
        {
            this.EnableMica();
            this.EnableDarkMode();
        };
    }
} 