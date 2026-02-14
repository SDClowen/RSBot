using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.General.Components;
using RSBot.General.Models;
using SDUI.Controls;

namespace RSBot.General.Views;

[ToolboxItem(false)]
internal partial class Main : DoubleBufferedControl
{
    private bool _clientVisible;
    private static int _reloginSeq;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        CheckForIllegalCrossThreadCalls = false;

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
    private async void OnGatewayServerDisconnected()
    {
        AutoLogin.Pending = false;
        View.PendingWindow?.Hide();
        View.PendingWindow?.StopClientlessQueueTask();

        var wasClientless = Game.Clientless;

        if (!Kernel.Proxy.IsConnectedToAgentserver && !Kernel.Proxy.IsSwitchingToAgentserver)
        {
            if (GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
            {
                var reloginSeq = Interlocked.Increment(ref _reloginSeq);

                btnStartClient.Enabled = false;
                btnStartClientless.Enabled = false;

                // Gateway disconnect can happen briefly during Gateway -> Agent switch (or the switch can start late
                // due to thread scheduling). Give it a short grace period before we decide it's a real DC.
                await Task.Delay(2000);

                if (reloginSeq != Volatile.Read(ref _reloginSeq))
                    return;

                if (Kernel.Proxy.IsConnectedToAgentserver || Kernel.Proxy.IsSwitchingToAgentserver)
                    return;

                btnStartClient.Enabled = true;
                btnStartClientless.Enabled = true;
                btnStartClientless.Text = LanguageManager.GetLang("Start") + " Clientless";
                Log.StatusLang("Ready");
                Kernel.Proxy.Shutdown();

                int delay = 10000;
                if (GlobalConfig.Get("RSBot.General.EnableWaitAfterDC", false))
                    delay = GlobalConfig.Get<int>("RSBot.General.WaitAfterDC") * 60 * 1000;

                Log.Warn($"Attempting relogin in {delay / 1000} seconds...");
                await Task.Delay(delay);

                // Prevent double-start if the disconnect event fires multiple times.
                if (reloginSeq != Volatile.Read(ref _reloginSeq))
                    return;

                if (wasClientless)
                {
                    // Clientless relogin: restart proxy flow only.
                    Game.Clientless = true;
                    Game.Start();
                }
                else
                {
                    var userAuthenticated = await HandleRegionalAuth();
                    if (!userAuthenticated)
                        Log.Warn("Regional auth failed; starting client anyway for relogin attempt...");

                    // Client relogin: restart client process.
                    ClientManager.Kill();
                    await StartClientProcess();
                }

                return;
            }

            btnStartClient.Enabled = true;
            btnStartClientless.Enabled = true;
            btnStartClientless.Text = LanguageManager.GetLang("Start") + " Clientless";
            Log.StatusLang("Ready");
            Kernel.Proxy.Shutdown();

            Game.Clientless = false;
        }
    }

    /// <summary>
    ///     Called when main window loaded.
    /// </summary>
    private void OnInitialized()
    {
        comboBoxClientType.Items.AddRange(Enum.GetNames(typeof(GameClientType)));
        comboCharacter.SelectedIndex = 0;

        Accounts.Load();
        LoadAccounts();

        //Load and display config

        txtSilkroadPath.Text = Path.Combine(
            GlobalConfig.Get<string>("RSBot.SilkroadDirectory"),
            GlobalConfig.Get<string>("RSBot.SilkroadExecutable")
        );
        checkEnableStaticCaptcha.Checked = GlobalConfig.Get<bool>("RSBot.General.EnableStaticCaptcha");
        checkEnableAutoLogin.Checked = GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin");
        checkStartBot.Checked = GlobalConfig.Get<bool>("RSBot.General.StartBot");
        checkUseReturnScroll.Checked = GlobalConfig.Get<bool>("RSBot.General.UseReturnScroll");
        checkStayConnected.Checked = GlobalConfig.Get<bool>("RSBot.General.StayConnected");
        checkBoxBotTrayMinimized.Checked = GlobalConfig.Get<bool>("RSBot.General.TrayWhenMinimize");
        txtStaticCaptcha.Text = GlobalConfig.Get<string>("RSBot.General.StaticCaptcha");
        checkEnableLoginDelay.Checked = GlobalConfig.Get<bool>("RSBot.General.EnableLoginDelay");
        numLoginDelay.Value = GlobalConfig.Get("RSBot.General.LoginDelay", 3);
        checkWaitAfterDC.Checked = GlobalConfig.Get<bool>("RSBot.General.EnableWaitAfterDC");
        numWaitAfterDC.Value = GlobalConfig.Get("RSBot.General.WaitAfterDC", 3);
        checkHideClient.Checked = GlobalConfig.Get<bool>("RSBot.General.HideOnStartClient");
        checkCharAutoSelect.Checked = GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelect");
        radioAutoSelectFirst.Checked = GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelectFirst", true);
        radioAutoSelectHigher.Checked = GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelectHigher");
        checkAutoHidePendingWindow.Checked = GlobalConfig.Get<bool>("RSBot.General.AutoHidePendingWindow");
        checkEnableQueueLogs.Checked = GlobalConfig.Get<bool>("RSBot.General.PendingEnableQueueLogs");
        checkEnableQueueNotification.Checked = GlobalConfig.Get<bool>("RSBot.General.EnableQueueNotification");
        numQueueLeft.Value = GlobalConfig.Get("RSBot.General.QueueLeft", 30);

        if (GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelect"))
        {
            radioAutoSelectFirst.Enabled = true;
            radioAutoSelectHigher.Enabled = true;
        }

        comboBoxClientType.SelectedIndex = (int)Game.ClientType;

        if (!File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2"))
            txtSilkroadPath.BackColor = Color.Red;

        if (!string.IsNullOrEmpty(Kernel.LaunchMode))
        {
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                if (Kernel.LaunchMode == "client")
                {
                    BeginInvoke(new Action(() =>
                    {
                        btnStartClient_Click(btnStartClient, EventArgs.Empty);
                    }));
                }
                else if (Kernel.LaunchMode == "clientless")
                {
                    BeginInvoke(new Action(() =>
                    {
                        btnStartClientless_Click(btnStartClientless, EventArgs.Empty);
                    }));
                }
            });
        }
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

        if (comboCharacter.SelectedIndex == -1 || string.IsNullOrWhiteSpace(selectedAccount.SelectedCharacter))
            comboCharacter.SelectedIndex = 0;
    }

    /// <summary>
    ///     Starts the client process.
    /// </summary>
    private async Task StartClientProcess()
    {
        btnStartClient.Enabled = false;
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
        btnStartClient.Enabled = false;
        btnStartClientless.Enabled = false;
        _clientVisible = true;
        btnClientHideShow.Enabled = true;

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
        btnStartClient.Text = LanguageManager.GetLang("Start") + " Client";

        if (Game.Clientless)
            return;

        btnStartClient.Enabled = true;
        btnStartClientless.Enabled = true;
        btnClientHideShow.Enabled = false;

        if (!GlobalConfig.Get<bool>("RSBot.General.StayConnected"))
        {
            Kernel.Proxy.Shutdown();
        }
        else
        {
            if (!Kernel.Proxy.IsConnectedToAgentserver)
                return;

            btnStartClient.Enabled = false;

            ClientlessManager.GoClientless();

            btnGoClientless.Enabled = false;
            btnStartClientless.Text = LanguageManager.GetLang("Disconnect");

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
            btnClientHideShow.Enabled = true;
            btnClientHideShow.Text = LanguageManager.GetLang("Hide") + " Client";
            btnStartClient.Enabled = true;
            btnStartClient.Text = LanguageManager.GetLang("Kill") + " Client";
            btnGoClientless.Enabled = true;
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
        // Cancel any pending relogin timers once we successfully connected.
        Interlocked.Increment(ref _reloginSeq);

        //if (!Game.Clientless)
        //    btnGoClientless.Enabled = true;
    }

    /// <summary>
    ///     Called when [agent server disconnected].
    /// </summary>
    private async void OnAgentServerDisconnected()
    {
        Kernel.Bot.Stop();

        // Skiped: Cuz managing from ClientlessManager
        if (Game.Clientless)
            return;

        // If user disconnected with manual from clientless, we dont need open the client automatically again.
        //if (!Kernel.Proxy.ClientConnected)
        //return;

        ClientManager.Kill();

        if (GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
        {
            var reloginSeq = Interlocked.Increment(ref _reloginSeq);

            btnStartClient.Enabled = false;
            btnStartClientless.Enabled = false;

            int delay = 10000;
            if (GlobalConfig.Get("RSBot.General.EnableWaitAfterDC", false))
                delay = GlobalConfig.Get<int>("RSBot.General.WaitAfterDC") * 60 * 1000;

            Log.Warn($"Attempting relogin in {delay / 1000} seconds...");
            await Task.Delay(delay);

            // Prevent double-start if multiple disconnect events race.
            if (reloginSeq != Volatile.Read(ref _reloginSeq))
                return;

            var userAuthenticated = await HandleRegionalAuth();
            if (!userAuthenticated)
                Log.Warn("Regional auth failed; starting client anyway for relogin attempt...");

            await StartClientProcess();
            return;
        }

        btnGoClientless.Enabled = false;
        btnStartClient.Enabled = true;
        btnStartClientless.Enabled = true;
    }

    /// <summary>
    ///     Called when [client connected].
    /// </summary>
    private void OnClientConnected()
    {
        btnStartClientless.Enabled = false;
    }

    /// <summary>
    ///     Handles the Click event of the btnBrowseSilkroadPath control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnBrowseSilkroadPath_Click(object sender, EventArgs e)
    {
        using (var dialog = new OpenFileDialog())
        {
            var title = LanguageManager.GetLang("BrowseSilkroadPathDialogTitle");

            var msgBoxTitle = LanguageManager.GetLang("BrowseSilkroadPathMsgBoxTitle");
            var msgBoxContent = LanguageManager.GetLang("BrowseSilkroadPathMsgBoxContent");

            dialog.Title = title;
            dialog.Filter = "App (*.exe)|*.exe";
            dialog.FileName = "sro_client.exe";

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            txtSilkroadPath.Text = dialog.FileName;
            GlobalConfig.Set("RSBot.SilkroadDirectory", Path.GetDirectoryName(dialog.FileName));
            GlobalConfig.Set("RSBot.SilkroadExecutable", Path.GetFileName(dialog.FileName));

            result = MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            GlobalConfig.Save();
        }

        Process.Start(Application.ExecutablePath);
        Application.Exit();
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkStartBot control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void checkAutoStartBot_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.StartBot", checkStartBot.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkUseReturnScroll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void checkUseReturnScroll_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.UseReturnScroll", checkUseReturnScroll.Checked);
    }

    /// <summary>
    ///     Handles the Click event of the btnAutoLoginSettings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnAutoLoginSettings_Click(object sender, EventArgs e)
    {
        if (View.AccountsWindow.ShowDialog() == DialogResult.OK)
            LoadAccounts();
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableAutoLogin control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void checkEnableAutoLogin_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableAutomatedLogin", checkEnableAutoLogin.Checked.ToString());
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboAccounts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void comboAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedAccount = comboAccounts.SelectedIndex == 0 ? string.Empty : comboAccounts.SelectedItem.ToString();

        GlobalConfig.Set("RSBot.General.AutoLoginAccountUsername", selectedAccount);

        LoadCharacters();
    }

    /// <summary>
    ///     Handles the TextChanged event of the txtStaticCaptcha control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void txtStaticCaptcha_TextChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.StaticCaptcha", txtStaticCaptcha.Text);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableStaticCaptcha control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void checkEnableStaticCaptcha_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableStaticCaptcha", checkEnableStaticCaptcha.Checked.ToString());
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboCharacter control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void comboCharacter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboAccounts.SelectedIndex == 0)
            return;

        checkCharAutoSelect.Enabled = comboCharacter.SelectedIndex == 0;

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
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnGoClientless_Click(object sender, EventArgs e)
    {
        if (Game.Clientless)
            return;

        var msgBoxTitle = LanguageManager.GetLang("GoClientlessMsgBoxTitle");
        var msgBoxContent = LanguageManager.GetLang("GoClientlessMsgBoxContent");

        if (
            MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            != DialogResult.Yes
        )
            return;

        ClientlessManager.GoClientless();
        ClientManager.Kill();

        btnStartClientless.Text = LanguageManager.GetLang("Disconnect");
        btnGoClientless.Enabled = false;
        btnStartClientless.Enabled = true;
        btnStartClient.Enabled = false;
        btnClientHideShow.Enabled = false;
    }

    /// <summary>
    ///     Handles the Click event of the btnStartClientless control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private async void btnStartClientless_Click(object sender, EventArgs e)
    {
        await Task.Run(async () =>
        {
            if (!Game.Clientless)
            {
                if (!checkEnableAutoLogin.Checked || comboAccounts.SelectedIndex <= 0)
                {
                    var msgBoxTitle = LanguageManager.GetLang("StartClientlessMsgBoxTitle");
                    var msgBoxContent = LanguageManager.GetLang("StartClientlessMsgBoxContent");

                    MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                btnStartClient.Enabled = false;
                btnClientHideShow.Enabled = false;

                Game.Clientless = true;
                Log.StatusLang("StartingClientless");
                btnStartClientless.Text = LanguageManager.GetLang("Disconnect");

                var userAuthenticated = await HandleRegionalAuth();

                if (userAuthenticated)
                {
                    Game.Start();
                }
            }
            else
            {
                var msgBoxTitle = LanguageManager.GetLang("MsgBoxDisconnectDialogTitle");
                var msgBoxContent = LanguageManager.GetLang("MsgBoxDisconnectDialogContent");

                var result = MessageBox.Show(
                    msgBoxContent,
                    msgBoxTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.No)
                    return;

                Game.Clientless = false;

                btnStartClient.Enabled = true;
                btnStartClientless.Enabled = true;
                btnStartClientless.Text = LanguageManager.GetLang("Start") + " Clientless";

                Kernel.Proxy.Shutdown();
            }
        });
    }

    /// <summary>
    ///     Handles the Click event of the btnStartClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private async void btnStartClient_Click(object sender, EventArgs e)
    {
        if (!Game.Clientless && Kernel.Proxy != null && Kernel.Proxy.IsConnectedToAgentserver)
        {
            var extraStr = LanguageManager.GetLang("KillClientWarnMsgBoxSplit1");
            if (!GlobalConfig.Get<bool>("RSBot.General.StayConnected"))
                extraStr = LanguageManager.GetLang("KillClientWarnMsgBoxSplit2");

            var title = LanguageManager.GetLang("Warning");
            var content = LanguageManager.GetLang("KillClientWarnMsgBoxContent", extraStr);

            if (MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                ClientManager.Kill();

            return;
        }

        var userAuthenticated = await HandleRegionalAuth();

        if (userAuthenticated)
        {
            await StartClientProcess();
        }
    }

    private async Task<bool> HandleRegionalAuth()
    {
        var clientType = (GameClientType)comboBoxClientType.SelectedIndex;

        if (clientType == GameClientType.RuSro)
            return await RuSroAuthService.Auth();
        else if (clientType == GameClientType.Japanese)
            return await JSROAuthService.GetTokenAsync();
        return true;
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkStayConnected control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void checkStayConnected_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.StayConnected", checkStayConnected.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkBoxBotTrayMinimized control
    /// </summary>
    private void checkBoxBotTrayMinimized_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.TrayWhenMinimize", checkBoxBotTrayMinimized.Checked);
    }

    private void btnClientHideShow_Click(object sender, EventArgs e)
    {
        if (!ClientManager.IsRunning)
            return;

        if (!_clientVisible)
        {
            _clientVisible = true;
            ClientManager.SetVisible(true);
            btnClientHideShow.Text = LanguageManager.GetLang("Hide") + " Client";
        }
        else
        {
            _clientVisible = false;
            ClientManager.SetVisible(false);
            btnClientHideShow.Text = LanguageManager.GetLang("Show") + " Client";
        }
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboBoxClientType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void comboBoxClientType_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Created from Activator.CreateInstance easy fix ^^
        if (comboBoxClientType.Parent.Parent == null)
            return;

        if (Game.Player != null)
        {
            MessageBox.Show(LanguageManager.GetLang("MsgBoxClientTypeWarn"));
            return;
        }

        var clientType = (GameClientType)comboBoxClientType.SelectedIndex;

        GlobalConfig.Set("RSBot.Game.ClientType", clientType);
        Game.ClientType = clientType;
        GlobalConfig.Save();

        if (clientType.ToString().StartsWith("Vietnam"))
            captchaPanel.Visible = true;
        else
            captchaPanel.Visible = false;
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableLoginDelay control.
    /// </summary>
    /// <param name="sender">
    ///     The source of the event.
    /// </param>
    /// <param name="e">
    ///     The <see cref="EventArgs" /> instance containing the event data.
    /// </param>
    private void checkEnableLoginDelay_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableLoginDelay", checkEnableLoginDelay.Checked);
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numLoginDelay control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void numLoginDelay_ValueChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.LoginDelay", numLoginDelay.Value);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkWaitAfterDC control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void checkWaitAfterDC_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableWaitAfterDC", checkWaitAfterDC.Checked);
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numWaitAfterDC control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void numWaitAfterDC_ValueChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.WaitAfterDC", numWaitAfterDC.Value);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkHideClient control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkHideClient_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.HideOnStartClient", checkHideClient.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkCharAutoSelect control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkCharAutoSelect_CheckedChanged(object sender, EventArgs e)
    {
        if (!GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelect"))
        {
            radioAutoSelectFirst.Enabled = true;
            radioAutoSelectHigher.Enabled = true;
        }
        else
        {
            radioAutoSelectFirst.Enabled = false;
            radioAutoSelectHigher.Enabled = false;
        }

        GlobalConfig.Set("RSBot.General.CharacterAutoSelect", checkCharAutoSelect.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the radioAutoSelectFirst control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void radioAutoSelectFirst_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.CharacterAutoSelectFirst", radioAutoSelectFirst.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the radioAutoSelectHigher control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void radioAutoSelectHigher_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.CharacterAutoSelectHigher", radioAutoSelectHigher.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkDontShowPendingOnStartClient control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkDontShowPendingOnStartClient_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.AutoHidePendingWindow", checkAutoHidePendingWindow.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableQuequeLogs control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkEnableQueueLogs_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.PendingEnableQueueLogs", checkEnableQueueLogs.Checked);
    }

    /// <summary>
    ///     Handles the Click event of the btnShowPending control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnShowPending_Click(object sender, EventArgs e)
    {
        if (!AutoLogin.Pending)
            return;

        if (View.PendingWindow?.Visible == false)
            View.PendingWindow.ShowAtTop(View.Instance);
        else
            View.PendingWindow.Hide();
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnableQueueNotification control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkEnableQueueNotification_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.EnableQueueNotification", checkEnableQueueNotification.Checked);
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numQuequeLeft control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numQueueLeft_ValueChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.General.QueueLeft", numQueueLeft.Value);
    }

    /// <summary>
    /// Handes the SoundSetting event for open dialog
    /// </summary>
    private void btnSoundSettingSetup_Click(object sender, EventArgs e)
    {
        if (View.SoundNotificationWindow.ShowDialog() == DialogResult.OK)
        {
            // nothing
        }
    }
}
