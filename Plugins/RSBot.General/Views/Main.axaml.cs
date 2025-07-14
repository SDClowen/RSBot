using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;
using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.UI;
using RSBot.General.Components;
using RSBot.General.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.General.Views;

public partial class Main : UserControl
{
    private bool _clientVisible;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        InitializeComponent();
        SubscribeEvents();

        //btnStartClient.SetUseAsync(true);
        //btnStartClientless.SetUseAsync(true);
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadVersionInfo", new Action<VersionInfo>(OnLoadVersionInfo));
        EventManager.SubscribeEvent("OnAgentServerConnected", OnAgentServerConnected);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        EventManager.SubscribeEvent("OnGatewayServerDisconnected", OnGatewayServerDisconnected);
        EventManager.SubscribeEvent("OnClientConnected", OnClientConnected);
        EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
        EventManager.SubscribeEvent("OnStartClient", OnStartClient);
        EventManager.SubscribeEvent("OnExitClient", OnExitClient);
        EventManager.SubscribeEvent("OnCharacterListReceived", OnCharacterListReceived);
        EventManager.SubscribeEvent("OnInitialized", OnInitialized);
        EventManager.SubscribeEvent("OnProfileChanged", OnProfileChanged);
    }

    private void OnProfileChanged()
    {
        Accounts.Load();
        LoadAccounts();
    }

    /// <summary>
    ///     Called when gateway server disconnected.
    /// </summary>
    private void OnGatewayServerDisconnected()
    {
        AutoLogin.Pending = false;
        View.PendingWindow?.Hide();
        View.PendingWindow?.StopClientlessQueueTask();

        if (!Kernel.Proxy.IsConnectedToAgentserver)
        {
            Game.Clientless = false;

            btnStartClient.IsEnabled = true;
            btnStartClientless.IsEnabled = true;
            btnStartClientless.Content = LanguageManager.GetLang("Start") + " Clientless";
            Log.StatusLang("Ready");
            Kernel.Proxy.Shutdown();
        }
    }

    /// <summary>
    ///     Called when main window loaded.
    /// </summary>
    private void OnInitialized()
    {
        foreach (var item in Enum.GetNames(typeof(GameClientType)))
            comboBoxClientType.Items.Add(item);

        comboCharacter.SelectedIndex = 0;

        Accounts.Load();
        LoadAccounts();

        //Load and display config

        txtSilkroadPath.Text = Path.Combine(GlobalConfig.Get<string>("RSBot.SilkroadDirectory"),
            GlobalConfig.Get<string>("RSBot.SilkroadExecutable"));
        checkEnableStaticCaptcha.IsChecked = GlobalConfig.Get<bool>("RSBot.General.EnableStaticCaptcha");
        checkEnableAutoLogin.IsChecked = GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin");
        checkStartBot.IsChecked = GlobalConfig.Get<bool>("RSBot.General.StartBot");
        checkUseReturnScroll.IsChecked = GlobalConfig.Get<bool>("RSBot.General.UseReturnScroll");
        checkStayConnected.IsChecked = GlobalConfig.Get<bool>("RSBot.General.StayConnected");
        checkBoxBotTrayMinimized.IsChecked = GlobalConfig.Get<bool>("RSBot.General.TrayWhenMinimize");
        txtStaticCaptcha.Text = GlobalConfig.Get<string>("RSBot.General.StaticCaptcha");
        checkEnableLoginDelay.IsChecked = GlobalConfig.Get<bool>("RSBot.General.EnableLoginDelay");
        numLoginDelay.Value = GlobalConfig.Get("RSBot.General.LoginDelay", 3);
        checkWaitAfterDC.IsChecked = GlobalConfig.Get<bool>("RSBot.General.EnableWaitAfterDC");
        numWaitAfterDC.Value = GlobalConfig.Get("RSBot.General.WaitAfterDC", 3);
        checkHideClient.IsChecked = GlobalConfig.Get<bool>("RSBot.General.HideOnStartClient");
        checkCharAutoSelect.IsChecked = GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelect");
        radioAutoSelectFirst.IsChecked = GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelectFirst", true);
        radioAutoSelectHigher.IsChecked = GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelectHigher");
        checkAutoHidePendingWindow.IsChecked = GlobalConfig.Get<bool>("RSBot.General.AutoHidePendingWindow");
        checkEnableQueueLogs.IsChecked = GlobalConfig.Get<bool>("RSBot.General.PendingEnableQueueLogs");
        checkEnableQueueNotification.IsChecked = GlobalConfig.Get<bool>("RSBot.General.EnableQueueNotification");
        numQueueLeft.Value = GlobalConfig.Get("RSBot.General.QueueLeft", 30);

        if (GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelect"))
        {
            radioAutoSelectFirst.IsEnabled = true;
            radioAutoSelectHigher.IsEnabled = true;
        }

        comboBoxClientType.SelectedIndex = (int)Game.ClientType;

        if (File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2"))
            return;

        txtSilkroadPath.Background = new SolidColorBrush(Colors.Red, .3);
    }

    /// <summary>
    ///     Called when account character list updated
    /// </summary>
    private void OnCharacterListReceived()
    {
        LoadAccounts();
    }

    /// <summary>
    ///     Loads the accounts.
    /// </summary>
    private void LoadAccounts()
    {
        comboAccounts.Items.Clear();
        comboAccounts.Items.Add(LanguageManager.GetLang("NotSelected"));

        var autoLoginUserName = GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername");
        foreach (var account in Accounts.SavedAccounts)
        {
            var index = comboAccounts.Items.Add(account);
            if (account.Username == autoLoginUserName)
                comboAccounts.SelectedIndex = index;
        }

        if (comboAccounts.SelectedIndex == -1)
            comboAccounts.SelectedIndex = 0;
    }

    /// <summary>
    ///     Fill the combobox on the form
    /// </summary>
    private void LoadCharacters()
    {
        comboCharacter.Items.Clear();
        comboCharacter.Items.Add(LanguageManager.GetLang("NotSelected"));

        var selectedAccount = comboAccounts.SelectedItem as Account;
        if (selectedAccount?.Characters == null)
        {
            comboCharacter.SelectedIndex = 0;
            return;
        }

        foreach (var character in selectedAccount.Characters.Where(n => n != null))
        {
            var index = comboCharacter.Items.Add(character);
            if (character == selectedAccount.SelectedCharacter)
                comboCharacter.SelectedIndex = index;
        }

        if (comboCharacter.SelectedIndex == -1 ||
            string.IsNullOrWhiteSpace(selectedAccount.SelectedCharacter))
            comboCharacter.SelectedIndex = 0;
    }

    /// <summary>
    ///     Starts the client process.
    /// </summary>
    private async Task StartClientProcess()
    {
        btnStartClient.IsEnabled = false;
        Game.Start();

        await Task.Run(async () =>
        {
            var startedResult = await ClientManager.Start();
            if (!startedResult)
            {
                OnExitClient();
                Log.WarnLang("ClientStartingError");
            }
        });
    }

    /// <summary>
    ///     Called when [start client].
    /// </summary>
    private void OnStartClient()
    {
        btnStartClient.IsEnabled = false;
        btnStartClientless.IsEnabled = false;
        _clientVisible = true;
        btnClientHideShow.IsEnabled = true;

        if (GlobalConfig.Get<bool>("RSBot.General.HideOnStartClient"))
            ClientManager.SetVisible(false);
    }

    /// <summary>
    ///     Called when [exit client].
    /// </summary>
    private void OnExitClient()
    {
        Log.StatusLang("Ready");
        _clientVisible = false;
        btnStartClient.Content = LanguageManager.GetLang("Start") + " Client";

        if (Game.Clientless)
            return;

        btnStartClient.IsEnabled = true;
        btnStartClientless.IsEnabled = true;
        btnClientHideShow.IsEnabled = false;

        if (!GlobalConfig.Get<bool>("RSBot.General.StayConnected"))
        {
            Kernel.Proxy.Shutdown();
        }
        else
        {
            if (!Kernel.Proxy.IsConnectedToAgentserver)
                return;

            btnStartClient.IsEnabled = false;

            ClientlessManager.GoClientless();

            btnGoClientless.IsEnabled = false;
            btnStartClientless.Content = LanguageManager.GetLang("Disconnect");

            Log.NotifyLang("ClientlessModeActivated");
        }
    }

    /// <summary>
    ///     Called when [enter game].
    /// </summary>
    private async void OnEnterGame()
    {
        if (!Game.Clientless)
        {
            btnClientHideShow.IsEnabled = true;
            btnClientHideShow.Content = LanguageManager.GetLang("Hide") + " Client";
            btnStartClient.IsEnabled = true;
            btnStartClient.Content = LanguageManager.GetLang("Kill") + " Client";
            btnGoClientless.IsEnabled = true;
        }

        //Wait for the game to be ready!
        while (!Game.Ready)
            await Task.Delay(100);

        var startBot = GlobalConfig.Get<bool>("RSBot.General.StartBot");
        var useReturnScroll = GlobalConfig.Get<bool>("RSBot.General.UseReturnScroll");

        if (useReturnScroll)
            Game.Player.UseReturnScroll();

        if (startBot)
            Kernel.Bot.Start();
    }

    /// <summary>
    ///     The on load version information.
    /// </summary>
    /// <param name="info">The information.</param>
    private void OnLoadVersionInfo(VersionInfo info)
    {
        lblVersion.Text = "v" + ((1000f + info.Version) / 1000f).ToString("0.000", CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     Called when [agent server connected].
    /// </summary>
    private void OnAgentServerConnected()
    {
        //if (!Game.Clientless)
        //    btnGoClientless.IsEnabled = true;
    }

    /// <summary>
    ///     Called when [agent server disconnected].
    /// </summary>
    private async void OnAgentServerDisconnected()
    {
        Kernel.Bot.Stop();

        var ruSroAuthenticated = await HandleRuSroAuth();

        // Skiped: Cuz managing from ClientlessManager
        if (Game.Clientless && ruSroAuthenticated)
            return;

        // If user disconnected with manual from clientless, we dont need open the client automatically again.
        //if (!Kernel.Proxy.ClientConnected)
        //return;

        ClientManager.Kill();

        if (GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
        {
            btnStartClient.IsEnabled = false;
            btnStartClientless.IsEnabled = false;

            int delay = 10000;
            if (GlobalConfig.Get("RSBot.General.EnableWaitAfterDC", false))
                delay = GlobalConfig.Get<int>("RSBot.General.WaitAfterDC") * 60 * 1000;

            Log.Warn($"Attempting relogin in {delay / 1000} seconds...");
            Thread.Sleep(delay);

            if (ruSroAuthenticated)
            {
                await StartClientProcess().ConfigureAwait(false);
            }
            return;
        }

        btnGoClientless.IsEnabled = false;
        btnStartClient.IsEnabled = true;
        btnStartClientless.IsEnabled = true;
    }

    /// <summary>
    ///     Called when [client connected].
    /// </summary>
    private void OnClientConnected()
    {
        btnStartClientless.IsEnabled = false;
    }

    /// <summary>
    ///     Handles the Click event of the btnBrowseSilkroadPath control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void btnBrowseSilkroadPath_Click(object sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null)
            return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = LanguageManager.GetLang("BrowseSilkroadPathDialogTitle"),
            AllowMultiple = false,
            FileTypeFilter = new List<FilePickerFileType>
            {
                new("Sro_Client")
                {
                    Patterns = ["*.exe"],
                }
            },
        });

        if (files.Count == 0)
            return;

        var selectedPath = files[0].TryGetLocalPath();

        var msgBoxTitle = LanguageManager.GetLang("BrowseSilkroadPathMsgBoxTitle");
        var msgBoxContent = LanguageManager.GetLang("BrowseSilkroadPathMsgBoxContent");

        txtSilkroadPath.Text = selectedPath;
        GlobalConfig.Set("RSBot.SilkroadDirectory", Path.GetDirectoryName(selectedPath));
        GlobalConfig.Set("RSBot.SilkroadExecutable", Path.GetFileName(selectedPath));

        var result = await MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.YesNo);

        if (result == MessageBoxResult.No)
            return;

        GlobalConfig.Save();

        string exePath = Environment.ProcessPath ??
                        Process.GetCurrentProcess().MainModule.FileName;

        Process.Start(exePath);

        if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkStartBot control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void checkAutoStartBot_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.StartBot", checkStartBot.IsChecked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkUseReturnScroll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void checkUseReturnScroll_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.UseReturnScroll", checkUseReturnScroll.IsChecked);
    }

    /// <summary>
    ///     Handles the Click event of the btnAutoLoginSettings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void btnAutoLoginSettings_Click(object sender, RoutedEventArgs e)
    {
        var result = await View.AccountsWindow.ShowDialog<DialogResult>(this.FindAncestorOfType<Window>());
        if (result == DialogResult.Ok)
            LoadAccounts();
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableAutoLogin control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void checkEnableAutoLogin_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableAutomatedLogin", checkEnableAutoLogin.IsChecked.ToString());
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboAccounts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void comboAccounts_SelectedIndexChanged(object sender, RoutedEventArgs e)
    {
        var selectedAccount = comboAccounts.SelectedIndex == 0 ? string.Empty : comboAccounts.SelectedItem.ToString();

        GlobalConfig.Set("RSBot.General.AutoLoginAccountUsername", selectedAccount);

        LoadCharacters();
    }

    /// <summary>
    ///     Handles the TextChanged event of the txtStaticCaptcha control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void txtStaticCaptcha_TextChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.StaticCaptcha", txtStaticCaptcha.Text);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableStaticCaptcha control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void checkEnableStaticCaptcha_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableStaticCaptcha", checkEnableStaticCaptcha.IsChecked.ToString());
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboCharacter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void comboCharacter_SelectedIndexChanged(object sender, RoutedEventArgs e)
    {
        if (comboAccounts.SelectedIndex == 0)
            return;

        checkCharAutoSelect.IsEnabled = comboCharacter.SelectedIndex == 0;

        var selectedAccount = comboAccounts.SelectedItem as Account;
        if (selectedAccount == null)
            return;

        selectedAccount.SelectedCharacter =
            comboCharacter.SelectedIndex == 0 ? string.Empty : comboCharacter.SelectedItem.ToString();

        Accounts.Save();
    }

    /// <summary>
    ///     Handles the Click event of the btnGoClientless control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void btnGoClientless_Click(object sender, RoutedEventArgs e)
    {
        if (Game.Clientless)
            return;

        var msgBoxTitle = LanguageManager.GetLang("GoClientlessMsgBoxTitle");
        var msgBoxContent = LanguageManager.GetLang("GoClientlessMsgBoxContent");

        if (await MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.YesNo) !=
            MessageBoxResult.Yes) return;

        ClientlessManager.GoClientless();
        ClientManager.Kill();

        btnStartClientless.Content = LanguageManager.GetLang("Disconnect");
        btnGoClientless.IsEnabled = false;
        btnStartClientless.IsEnabled = true;
        btnStartClient.IsEnabled = false;
        btnClientHideShow.IsEnabled = false;
    }

    /// <summary>
    ///     Handles the Click event of the btnStartClientless control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void btnStartClientless_Click(object sender, RoutedEventArgs e)
    {
        await Task.Run(async () =>
        {
            if (!Game.Clientless)
            {
                if (!checkEnableAutoLogin.IsChecked == true || comboAccounts.SelectedIndex <= 0)
                {
                    var msgBoxTitle = LanguageManager.GetLang("StartClientlessMsgBoxTitle");
                    var msgBoxContent = LanguageManager.GetLang("StartClientlessMsgBoxContent");

                    await MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.Ok);

                    return;
                }

                btnStartClient.IsEnabled = false;
                btnClientHideShow.IsEnabled = false;

                Game.Clientless = true;
                Log.StatusLang("StartingClientless");
                btnStartClientless.Content = LanguageManager.GetLang("Disconnect");

                var ruSroAuthenticated = await HandleRuSroAuth();

                if (ruSroAuthenticated)
                {
                    Game.Start();
                }

            }
            else
            {
                var msgBoxTitle = LanguageManager.GetLang("MsgBoxDisconnectDialogTitle");
                var msgBoxContent = LanguageManager.GetLang("MsgBoxDisconnectDialogContent");

                var result = await MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.YesNo);
                if (result == MessageBoxResult.No)
                    return;

                Game.Clientless = false;

                btnStartClient.IsEnabled = true;
                btnStartClientless.IsEnabled = true;
                btnStartClientless.Content = LanguageManager.GetLang("Start") + " Clientless";

                Kernel.Proxy.Shutdown();
            }
        });
    }

    /// <summary>
    ///     Handles the Click event of the btnStartClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void btnStartClient_Click(object sender, RoutedEventArgs e)
    {
        if (!Game.Clientless && Kernel.Proxy != null && Kernel.Proxy.IsConnectedToAgentserver)
        {
            var extraStr = LanguageManager.GetLang("KillClientWarnMsgBoxSplit1");
            if (!GlobalConfig.Get<bool>("RSBot.General.StayConnected"))
                extraStr = LanguageManager.GetLang("KillClientWarnMsgBoxSplit2");

            var title = LanguageManager.GetLang("Warning");
            var content = LanguageManager.GetLang("KillClientWarnMsgBoxContent", extraStr);

            if (await MessageBox.Show(content, title, MessageBoxButtons.YesNo) == MessageBoxResult.Yes)
                ClientManager.Kill();

            return;
        }

        var ruSroAuthenticated = await HandleRuSroAuth();

        if (ruSroAuthenticated)
        {
            await StartClientProcess();
        }
    }

    private async Task<bool> HandleRuSroAuth()
    {
        var clientType = (GameClientType)comboBoxClientType.SelectedIndex;
        if (clientType != GameClientType.RuSro) return true;

        return await RuSroAuthService.Auth();
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkStayConnected control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void checkStayConnected_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.StayConnected", checkStayConnected.IsChecked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkBoxBotTrayMinimized control
    /// </summary>
    private void checkBoxBotTrayMinimized_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.TrayWhenMinimize", checkBoxBotTrayMinimized.IsChecked);
    }

    private void btnClientHideShow_Click(object sender, RoutedEventArgs e)
    {
        if (!ClientManager.IsRunning)
            return;

        if (!_clientVisible)
        {
            _clientVisible = true;
            ClientManager.SetVisible(true);
            btnClientHideShow.Content = LanguageManager.GetLang("Hide") + " Client";
        }
        else
        {
            _clientVisible = false;
            ClientManager.SetVisible(false);
            btnClientHideShow.Content = LanguageManager.GetLang("Show") + " Client";
        }
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboBoxClientType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void comboBoxClientType_SelectedIndexChanged(object sender, RoutedEventArgs e)
    {
        // Created from Activator.CreateInstance easy fix ^^
        if (comboBoxClientType.Parent.Parent == null)
            return;

        if (Game.Player != null)
        {
            await MessageBox.Show(LanguageManager.GetLang("MsgBoxClientTypeWarn"));
            return;
        }

        var clientType = (GameClientType)comboBoxClientType.SelectedIndex;

        GlobalConfig.Set("RSBot.Game.ClientType", clientType);
        Game.ClientType = clientType;
        GlobalConfig.Save();

        if (clientType.ToString().StartsWith("Vietnam"))
            captchaPanel.IsVisible = true;
        else
            captchaPanel.IsVisible = false;
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableLoginDelay control.
    /// </summary>
    /// <param name="sender">
    ///     The source of the event.
    /// </param>
    /// <param name="e">
    ///     The <see cref="RoutedEventArgs" /> instance containing the event data.
    /// </param>
    private void checkEnableLoginDelay_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableLoginDelay", checkEnableLoginDelay.IsChecked);
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numLoginDelay control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void numLoginDelay_ValueChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.LoginDelay", numLoginDelay.Value);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkWaitAfterDC control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void checkWaitAfterDC_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableWaitAfterDC", checkWaitAfterDC.IsChecked);
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numWaitAfterDC control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void numWaitAfterDC_ValueChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.WaitAfterDC", numWaitAfterDC.Value);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkHideClient control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkHideClient_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.HideOnStartClient", checkHideClient.IsChecked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkCharAutoSelect control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkCharAutoSelect_CheckedChanged(object sender, RoutedEventArgs e)
    {
        if (!GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelect"))
        {
            radioAutoSelectFirst.IsEnabled = true;
            radioAutoSelectHigher.IsEnabled = true;
        }
        else
        {
            radioAutoSelectFirst.IsEnabled = false;
            radioAutoSelectHigher.IsEnabled = false;
        }


        GlobalConfig.Set("RSBot.General.CharacterAutoSelect", checkCharAutoSelect.IsChecked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the radioAutoSelectFirst control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void radioAutoSelectFirst_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.CharacterAutoSelectFirst", radioAutoSelectFirst.IsChecked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the radioAutoSelectHigher control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void radioAutoSelectHigher_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.CharacterAutoSelectHigher", radioAutoSelectHigher.IsChecked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkDontShowPendingOnStartClient control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkDontShowPendingOnStartClient_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.AutoHidePendingWindow", checkAutoHidePendingWindow.IsChecked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableQuequeLogs control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkEnableQueueLogs_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.PendingEnableQueueLogs", checkEnableQueueLogs.IsChecked);
    }

    /// <summary>
    ///     Handles the Click event of the btnShowPending control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnShowPending_Click(object sender, RoutedEventArgs e)
    {
        if (!AutoLogin.Pending)
            return;

        if (View.PendingWindow?.IsVisible == false)
            View.PendingWindow.ShowAtTop(this.FindAncestorOfType<Window>());
        else
            View.PendingWindow.Hide();
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableQueueNotification control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkEnableQueueNotification_CheckedChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableQueueNotification", checkEnableQueueNotification.IsChecked);
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numQuequeLeft control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numQueueLeft_ValueChanged(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Set("RSBot.General.QueueLeft", numQueueLeft.Value);
    }
}