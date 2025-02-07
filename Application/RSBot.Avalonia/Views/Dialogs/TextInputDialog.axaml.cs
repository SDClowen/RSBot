using Avalonia.Controls;
using RSBot.Extensions;
using RSBot.ViewModels.Dialogs;

namespace RSBot.Views.Dialogs;

/// <summary>
/// Dialog for getting text input from the user
/// </summary>
public partial class TextInputDialog : Window
{
    public TextInputDialog(string title, string message)
    {
        InitializeComponent();
        DataContext = new TextInputDialogViewModel(this, title, message);

        this.Opened += (_, __) =>
        {
            this.EnableMica();
            this.EnableDarkMode();
        };
    }
} 