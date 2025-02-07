using Avalonia.Controls;
using RSBot.Extensions;
using RSBot.ViewModels.Dialogs;

namespace RSBot.Views.Dialogs;

/// <summary>
/// Dialog for configuring network settings
/// </summary>
public partial class NetworkConfigDialog : Window
{
    public NetworkConfigDialog()
    {
        InitializeComponent();
        DataContext = new NetworkConfigDialogViewModel(this);

        this.Opened += (_, __) =>
        {
            this.EnableMica();
            this.EnableDarkMode();
        };
    }
} 