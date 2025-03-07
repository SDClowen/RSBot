using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.General.ViewModels;

namespace RSBot.General.Views;

/// <summary>
/// Window for managing accounts, including adding new accounts and removing existing ones
/// </summary>
public partial class AccountsWindow : Window
{
    public AccountsWindow()
    {
        InitializeComponent();
        DataContext = new AccountsWindowViewModel(this);
    }
} 