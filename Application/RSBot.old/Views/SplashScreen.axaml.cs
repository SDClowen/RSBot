using System;
using System.ComponentModel;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Client;
using RSBot.Views.Dialog;

namespace RSBot.Views;

/// <summary>
/// The splash screen window that appears when the application starts
/// Handles initialization of the bot and loading of game data
/// </summary>
public partial class SplashScreen : Window
{
    private readonly Main _mainWindow;
    private readonly BackgroundWorker _referenceDataLoader;

    /// <summary>
    /// Initializes a new instance of the <see cref="SplashScreen"/> class.
    /// </summary>
    public SplashScreen()
    {
        InitializeComponent();

        _mainWindow = new Main();
        _referenceDataLoader = new BackgroundWorker { WorkerReportsProgress = true };
        _referenceDataLoader.DoWork += ReferenceDataLoader_DoWork;
        _referenceDataLoader.ProgressChanged += ReferenceDataLoader_ProgressChanged;
        _referenceDataLoader.RunWorkerCompleted += ReferenceDataLoader_RunWorkerCompleted;

        labelVersion.Text = Program.AssemblyVersion;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        if (!LoadProfileConfig())
        {
            Environment.Exit(0);
            return;
        }

        Kernel.Language = GlobalConfig.Get("RSBot.Language", "en_US");
        LanguageManager.Translate(_mainWindow, Kernel.Language);

        if (!GlobalConfig.Exists("RSBot.SilkroadDirectory") ||
            !File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2"))
        {
            var dialog = new OpenFileDialog
            {
                Title = LanguageManager.GetLang("OpenFileDialogTitle"),
                Filters = new[] { new FileDialogFilter { Name = "Executable", Extensions = new[] { "exe" } } },
                InitialFileName = "sro_client.exe"
            };

            var result = dialog.ShowAsync(this).Result;
            if (result != null && result.Length > 0)
            {
                var silkroadDirectory = Path.GetDirectoryName(result[0]);
                if (File.Exists(Path.Combine(silkroadDirectory, "media.pk2")))
                {
                    GlobalConfig.Set("RSBot.SilkroadDirectory", silkroadDirectory);
                    GlobalConfig.Set("RSBot.SilkroadExecutable", Path.GetFileName(result[0]));

                    var clientTypeDialog = new ClientTypeDialog();
                    if (clientTypeDialog.ShowDialog(this).Result)
                    {
                        if (Enum.TryParse<GameClientType>(clientTypeDialog.SelectedClientType, out var clientType))
                            GlobalConfig.Set("RSBot.Game.ClientType", clientType);
                    }
                    else
                    {
                        GlobalConfig.Set("RSBot.Game.ClientType", GameClientType.Vietnam);
                    }
                }
                else
                {
                    await MessageBox.Show(this, LanguageManager.GetLang("SelectSroDirWarn"));
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        InitializeBot();
        _referenceDataLoader.RunWorkerAsync();
    }

    private void ReferenceDataLoader_DoWork(object sender, DoWorkEventArgs e)
    {
        if (!Game.InitializeArchiveFiles())
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                await MessageBox.Show(this, "Failed to load game data. Boot process canceled!", "Initialize Application - Error");
            });
            return;
        }

        Game.ReferenceManager.Load(GlobalConfig.Get("RSBot.TranslationIndex", 9), _referenceDataLoader);
    }

    private void ReferenceDataLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            lblLoading.Text = $"Loading: {e.UserState}";
            progressLoading.Value = e.ProgressPercentage;
        });
    }

    private void ReferenceDataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            _mainWindow.Show();
            Close();
        });
    }

    private bool LoadProfileConfig()
    {
        if (!ProfileManager.IsProfileLoadedByArgs)
        {
            if (ProfileManager.ShowProfileDialog)
            {
                var dialog = new ProfileSelectionDialog();
                if (dialog.ShowDialog(this).Result)
                    ProfileManager.SetSelectedProfile(dialog.SelectedProfile);
                else
                    return false;
            }
            else
            {
                var selectedProfile = ProfileManager.SelectedProfile;
                var profilePath = ProfileManager.GetProfileFile(selectedProfile);

                if (!string.IsNullOrEmpty(selectedProfile) && !File.Exists(profilePath))
                    selectedProfile = "Default";

                ProfileManager.SetSelectedProfile(selectedProfile);
            }
        }

        GlobalConfig.Load();
        Log.Notify($"Loaded profile {ProfileManager.SelectedProfile}");

        return true;
    }

    private void InitializeBot()
    {
        Kernel.Initialize();
        Game.Initialize();

        if (!Kernel.PluginManager.LoadAssemblies())
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                await MessageBox.Show(this, "Failed to load plugins. Process canceled!", "Initialize Application - Error");
            });
            return;
        }

        if (!Kernel.BotbaseManager.LoadAssemblies())
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                await MessageBox.Show(this, "Failed to load botbases. Process canceled!", "Initialize Application - Error");
            });
        }

        CommandManager.Initialize();
    }
} 