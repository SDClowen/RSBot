using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Views.Dialog;
using SDUI;
using SDUI.Controls;
using SDUI.Helpers;

namespace RSBot.Views;

public partial class SplashScreen : UIWindow
{
    public readonly Main _mainForm;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SplashScreen" /> class.
    /// </summary>
    public SplashScreen(Main mainForm)
    {
        InitializeComponent();

        ColorScheme.BackColor = Main.DarkThemeColor;
        BackColor = Main.DarkThemeColor;
        CheckForIllegalCrossThreadCalls = false;

        _mainForm = mainForm;

        labelVersion.Text = Program.AssemblyVersion;
        referenceDataLoader.RunWorkerCompleted += ReferenceDataLoaderCompleted;
    }

    /// <summary>
    ///     Handles the Load event of the SplashScreen control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void SplashScreen_Load(object sender, EventArgs e)
    {
        if (!LoadProfileConfig())
        {
            Environment.Exit(0);
            return;
        }

        Kernel.Language = GlobalConfig.Get("RSBot.Language", "en_US");

        LanguageManager.Translate(_mainForm, Kernel.Language);

        if (
            !GlobalConfig.Exists("RSBot.SilkroadDirectory")
            || !File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2")
        )
        {
            var dialog = new OpenFileDialog
            {
                Title = LanguageManager.GetLang("OpenFileDialogTitle"),
                Filter = "Executable (*.exe)|*.exe",
                FileName = "sro_client.exe",
            };

            var result = dialog.ShowDialog(this);

            var silkroadDirectory = Path.GetDirectoryName(dialog.FileName);

            if (result == DialogResult.OK && File.Exists(Path.Combine(silkroadDirectory, "media.pk2")))
            {
                GlobalConfig.Set("RSBot.SilkroadDirectory", silkroadDirectory);
                GlobalConfig.Set("RSBot.SilkroadExecutable", Path.GetFileName(dialog.FileName));

                var title = LanguageManager.GetLang("ClientTypeInputDialogTitle");
                var content = LanguageManager.GetLang("ClientTypeInputDialogContent");

                var clientTypeDialog = new InputDialog(title, title, content, InputDialog.InputType.Combobox);
                clientTypeDialog.ShowInTaskbar = true;
                clientTypeDialog.StartPosition = FormStartPosition.CenterScreen;
                clientTypeDialog.Selector.Items.AddRange(Enum.GetNames(typeof(GameClientType)));
                clientTypeDialog.Selector.SelectedIndex = 2;
                clientTypeDialog.TopMost = true;
                clientTypeDialog.StartPosition = FormStartPosition.CenterScreen;

                if (clientTypeDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Enum.TryParse<GameClientType>(clientTypeDialog.Value.ToString(), out var clientType))
                        GlobalConfig.Set("RSBot.Game.ClientType", clientType);
                }
                else
                {
                    MessageBox.Show(LanguageManager.GetLang("ClientTypeNotSelected"));
                    GlobalConfig.Set("RSBot.Game.ClientType", GameClientType.Vietnam);
                }
            }
            else
            {
                MessageBox.Show(LanguageManager.GetLang("SelectSroDirWarn"));
                Environment.Exit(0);
            }
        }

        InitializeBot();

        referenceDataLoader.RunWorkerAsync();
    }

    /// <summary>
    ///     Handles the RunWorkerCompleted event of the Initializer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">
    ///     The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs" /> instance containing the event
    ///     data.
    /// </param>
    private void ReferenceDataLoaderCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        var detectDarkLight = GlobalConfig.Get("RSBot.Theme.Auto", true);
        if (detectDarkLight)
        {
            if (WindowsHelper.IsDark())
                ColorScheme.BackColor = Main.DarkThemeColor;
            else
                ColorScheme.BackColor = Main.LightThemeColor;
        }
        else
        {
            ColorScheme.BackColor = Color.FromArgb(GlobalConfig.Get("SDUI.Color", Color.White.ToArgb()));
        }

        _mainForm.RefreshTheme();

        Close();
    }

    /// <summary>
    ///     Loads the profile configuration.
    /// </summary>
    private bool LoadProfileConfig()
    {
        if (!ProfileManager.IsProfileLoadedByArgs)
        {
            if (ProfileManager.ShowProfileDialog)
            {
                var dialog = new ProfileSelectionDialog();
                if (dialog.ShowDialog() != DialogResult.Cancel)
                    ProfileManager.SetSelectedProfile(dialog.SelectedProfile);
                else
                    return false;
            }
            else //Load selected profile without dialog
            {
                var selectedProfile = ProfileManager.SelectedProfile;
                var profilePath = ProfileManager.GetProfileFile(selectedProfile);

                //Configured profile could not be found. Fallback to default profile
                if (!string.IsNullOrEmpty(selectedProfile) && !File.Exists(profilePath))
                    selectedProfile = "Default";

                ProfileManager.SetSelectedProfile(selectedProfile);
            }
        }

        GlobalConfig.Load();
        Log.Notify($"Loaded profile {ProfileManager.SelectedProfile}");

        return true;
    }

    /// <summary>
    ///     Initializes the bot.
    /// </summary>
    private void InitializeBot()
    {
        //---- Boot kernel -----
        Kernel.Initialize();
        Game.Initialize();

        //---- Load Plugins ----
        if (!Kernel.PluginManager.LoadAssemblies())
        {
            MessageBox.Show(
                @"Failed to load plugins. Process canceled!",
                @"Initialize Application - Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            return;
        }

        //---- Load Botbases ----
        if (!Kernel.BotbaseManager.LoadAssemblies())
            MessageBox.Show(
                @"Failed to load botbases. Process canceled!",
                @"Initialize Application - Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

        CommandManager.Initialize();
    }

    /// <summary>
    ///     Handles the DoWork event of the referenceDataLoader control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs" /> instance containing the event data.</param>
    private void referenceDataLoader_DoWork(object sender, DoWorkEventArgs e)
    {
        if (!Game.InitializeArchiveFiles())
        {
            MessageBox.Show(
                @"Failed to load game data. Boot process canceled!",
                @"Initialize Application - Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            return;
        }

        Game.ReferenceManager.Load(GlobalConfig.Get("RSBot.TranslationIndex", 9), referenceDataLoader);
    }

    private void referenceDataLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        lblLoading.Text = $"Loading: {e.UserState}";
        progressLoading.Value = e.ProgressPercentage;
    }
}
