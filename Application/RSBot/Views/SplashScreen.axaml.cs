using Avalonia.Controls;
using RSBot.ViewModels;

namespace RSBot.Views;

/// <summary>
/// Splash screen window that shows loading progress and initializes the application
/// </summary>
public partial class SplashScreen : Window
{
    public SplashScreen(MainWindow window)
    {
        InitializeComponent();
        DataContext = new SplashScreenViewModel(this);

        this.Opened += (_, __) =>
        {
            this.EnableMica();
            this.EnableDarkMode();
        };
    }
}