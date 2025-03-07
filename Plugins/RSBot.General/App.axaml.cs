using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace RSBot.General;

/// <summary>
/// The main application class for the RSBot.General plugin
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Initializes the application by loading XAML resources
    /// </summary>
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <summary>
    /// Called when the application starts up
    /// </summary>
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Initialize desktop-specific resources here
        }

        base.OnFrameworkInitializationCompleted();
    }
} 