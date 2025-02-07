using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Views.Dialogs;

namespace RSBot.ViewModels;

public class SplashScreenViewModel : ReactiveObject
{
    private string _version;
    private string _loadingText;
    private int _loadingProgress;
    private readonly Window _owner;

    /// <summary>
    /// Initializes a new instance of the SplashScreenViewModel class
    /// </summary>
    /// <param name="owner">The owner window</param>
    public SplashScreenViewModel(Window owner)
    {
        _owner = owner;
        Version = Program.AssemblyVersion;
        LoadingText = "Initializing...";
        LoadingProgress = 0;
    }

    /// <summary>
    /// Gets or sets the version of the application
    /// </summary>
    public string Version
    {
        get => _version;
        private set => this.RaiseAndSetIfChanged(ref _version, value);
    }

    /// <summary>
    /// Gets or sets the loading text displayed during initialization
    /// </summary>
    public string LoadingText
    {
        get => _loadingText;
        private set => this.RaiseAndSetIfChanged(ref _loadingText, value);
    }

    /// <summary>
    /// Gets or sets the loading progress percentage (0-100)
    /// </summary>
    public int LoadingProgress
    {
        get => _loadingProgress;
        private set => this.RaiseAndSetIfChanged(ref _loadingProgress, value);
    }

    /// <summary>
    /// Initializes the application asynchronously
    /// </summary>
    /// <returns>A task representing the initialization operation</returns>
    public async Task InitializeAsync()
    {
        try
        {
            await LoadProfileConfigAsync();
            await InitializeBot();
        }
        catch (Exception ex)
        {
            Log.Error($"Error during initialization: {ex}");
            throw;
        }
    }

    /// <summary>
    /// Loads the profile configuration asynchronously
    /// </summary>
    /// <returns>A task representing the profile loading operation</returns>
    private async Task LoadProfileConfigAsync()
    {
        LoadingText = "Loading profile...";
        LoadingProgress = 10;

        if (!ProfileManager.IsProfileLoadedByArgs)
        {
            if (ProfileManager.ShowProfileDialog || string.IsNullOrWhiteSpace(ProfileManager.SelectedProfile))
            {
                var profileSelectionDialog = new ProfileSelectionDialog();
                await profileSelectionDialog.ShowDialog(_owner);
            }

            var selectedProfile = ProfileManager.SelectedProfile;
            var profilePath = ProfileManager.GetProfileFile(selectedProfile);

            if (!string.IsNullOrEmpty(selectedProfile) && !File.Exists(profilePath))
            {
                selectedProfile = "Default";
                ProfileManager.SetSelectedProfile(selectedProfile);
            }
        }

        GlobalConfig.Load();
        LoadingProgress = 20;
    }

    /// <summary>
    /// Initializes the bot components and loads game data asynchronously
    /// </summary>
    /// <returns>A task representing the bot initialization operation</returns>
    private async Task InitializeBot()
    {
        LoadingText = "Initializing core components...";
        LoadingProgress = 30;

        await Task.Run(() =>
        {
            Kernel.Initialize();
            Game.Initialize();
        });

        LoadingText = "Loading plugins...";
        LoadingProgress = 40;

        if (!await Task.Run(() => Kernel.PluginManager.LoadAssemblies()))
        {
            await MessageBox.Show(_owner, "Failed to load plugins. Process canceled!", "Initialize Application - Error");
            return;
        }

        LoadingText = "Loading botbases...";
        LoadingProgress = 50;

        if (!await Task.Run(() => Kernel.BotbaseManager.LoadAssemblies()))
            await MessageBox.Show(_owner, "Failed to load botbases. Process canceled!", "Initialize Application - Error");

        LoadingText = "Initializing commands...";
        LoadingProgress = 60;

        CommandManager.Initialize();

        LoadingText = "Loading game data...";
        LoadingProgress = 70;

        if (!Game.InitializeArchiveFiles())
        {
            await MessageBox.Show(_owner, "Failed to load game data. Boot process canceled!", "Initialize Application - Error");
            return;
        }

        await Task.Run(async () =>
        {
            await Game.ReferenceManager.LoadAsync(GlobalConfig.Get("RSBot.TranslationIndex", 9), (progress, text) =>
            {
                LoadingProgress = 70 + (int)(progress * 0.3); // 70 to 100
                LoadingText = $"Loading {text} data...";
            });
        });

        

        LoadingProgress = 100;
        LoadingText = "Initialization complete!";
        await Task.Delay(500);
    }
}