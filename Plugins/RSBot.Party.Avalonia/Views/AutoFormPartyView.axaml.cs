using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.Party.ViewModels;

namespace RSBot.Party.Views;

/// <summary>
/// View for auto-forming party settings and configuration
/// </summary>
public partial class AutoFormPartyView : Window
{
    public AutoFormPartyView()
    {
        InitializeComponent();
        DataContext = App.GetService<AutoFormPartyViewModel>();
    }
} 