using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RSBot.ViewModels;
using RSBot.Views;

namespace RSBot;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var main = new MainWindow();

            var splashScreen = new SplashScreen(main);
            desktop.MainWindow = splashScreen;

            if (splashScreen.DataContext is SplashScreenViewModel viewModel)
                await viewModel.InitializeAsync();

            desktop.MainWindow = main;
            main.Show();
            splashScreen.Close();
            main.TranslatePoint(new Point(0, 0), splashScreen);

        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
        }

        base.OnFrameworkInitializationCompleted();
    }
}
