using Avalonia.Controls;

namespace RSBot.Core.UI;

/// <summary>
/// Dialog for getting text input from the user
/// </summary>
public partial class TextInputDialog : Window
{
    public TextInputDialog(string title, string message)
    {
        InitializeComponent();
        DataContext = new TextInputDialogViewModel(this, title, message);
    }
} 