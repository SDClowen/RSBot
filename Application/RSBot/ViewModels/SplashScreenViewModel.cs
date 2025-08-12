using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using RSBot.Core.UI;
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

            Kernel.Language = GlobalConfig.Get("RSBot.Language", "en_US");
            LanguageManager.Translate(_owner, Kernel.Language);

            if (!GlobalConfig.Exists("RSBot.SilkroadDirectory") ||
                !File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2"))
            {
                var dialog = new OpenFileDialog
                {
                    Title = LanguageManager.GetLang("OpenFileDialogTitle"),
                    Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter { Name = "Executable", Extensions = new List<string> { "exe" } }
                },
                    InitialFileName = "sro_client.exe"
                };

                var result = await dialog.ShowAsync(_owner);
                if (result != null && result.Length > 0)
                {
                    var silkroadDirectory = Path.GetDirectoryName(result[0]);
                    if (File.Exists(Path.Combine(silkroadDirectory, "media.pk2")))
                    {
                        GlobalConfig.Set("RSBot.SilkroadDirectory", silkroadDirectory);
                        GlobalConfig.Set("RSBot.SilkroadExecutable", Path.GetFileName(result[0]));

                        var title = LanguageManager.GetLang("ClientTypeInputDialogTitle");
                        var content = LanguageManager.GetLang("ClientTypeInputDialogContent");

                        var clientTypeDialog = new InputDialog(title, title, content, InputDialog.InputType.Combobox);
                        clientTypeDialog.Selector.ItemsSource = Enum.GetNames(typeof(GameClientType));
                        clientTypeDialog.Selector.SelectedIndex = 2;

                        var dialogResult = await clientTypeDialog.ShowDialog<bool>(_owner);
                        if (dialogResult)
                        {
                            if (Enum.TryParse<GameClientType>(clientTypeDialog.Value.ToString(), out var clientType))
                                GlobalConfig.Set("RSBot.Game.ClientType", clientType);
                        }
                        else
                        {
                            await MessageBox.Show(_owner, LanguageManager.GetLang("ClientTypeNotSelected"));
                            GlobalConfig.Set("RSBot.Game.ClientType", GameClientType.Vietnam);
                        }
                    }
                    else
                    {
                        await MessageBox.Show(_owner, LanguageManager.GetLang("SelectSroDirWarn"));
                        Environment.Exit(0);
                    }
                }
                else
                {
                    await MessageBox.Show(_owner, LanguageManager.GetLang("SelectSroDirWarn"));
                    Environment.Exit(0);
                }
            }

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

        LoadingText = "Loading game data...";
        LoadingProgress = 40;

        if (!Game.InitializeArchiveFiles())
        {
            await MessageBox.Show(_owner, "Failed to load game data. Boot process canceled!", "Initialize Application - Error");
            return;
        }

        await Task.Run(async () =>
        {
            await Game.ReferenceManager.LoadAsync(GlobalConfig.Get("RSBot.TranslationIndex", 9), (progress, text) =>
            {
                LoadingProgress = 40 + (int)(progress * 0.3); // 70 to 100
                LoadingText = $"Loading {text} data...";
            });
        });

        LoadingText = "Loading plugins...";
        LoadingProgress = 70;

        if (!ExtensionManager.LoadAssemblies<IPlugin>())
        {
            await MessageBox.Show(_owner, "Failed to load plugins. Process canceled!", "Initialize Application - Error");
            return;
        }

        LoadingText = "Loading botbases...";
        LoadingProgress = 80;

        //if (!await Task.Run(() => ExtensionManager.LoadAssemblies<IBotbase>()))
        if (!ExtensionManager.LoadAssemblies<IBotbase>())
            await MessageBox.Show(_owner, "Failed to load botbases. Process canceled!", "Initialize Application - Error");

        LoadingText = "Initializing commands...";
        LoadingProgress = 90;

        CommandManager.Initialize();

        LoadingProgress = 100;
        LoadingText = "Initialization complete!";
        await Task.Delay(500);

        GlobalConfig.Save();
    }
}