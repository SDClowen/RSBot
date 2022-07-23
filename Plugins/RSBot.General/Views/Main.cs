using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.General.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    internal partial class Main : UserControl
    {
        private bool _clientVisible;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
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
            Components.Accounts.Load();
            LoadAccounts();
        }

        /// <summary>
        /// Called when gateway server disconnected.
        /// </summary>
        private void OnGatewayServerDisconnected()
        {
            View.PendingWindow?.Hide();

            if (!Kernel.Proxy.IsConnectedToAgentserver)
            {
                Game.Clientless = false;

                btnStartClient.Enabled = true;
                btnStartClientless.Enabled = true;
                btnStartClientless.Text = LanguageManager.GetLang("Start") + " Clientless";

                Kernel.Proxy.Shutdown();
            }
        }

        /// <summary>
        /// Called when main window loaded.
        /// </summary>
        private void OnInitialized()
        {
            comboBoxClientType.Items.AddRange(Enum.GetNames(typeof(GameClientType)));
            comboCharacter.SelectedIndex = 0;

            Components.Accounts.Load();
            LoadAccounts();

            //Load and display config

            txtSilkroadPath.Text = Path.Combine(GlobalConfig.Get<string>("RSBot.SilkroadDirectory"), GlobalConfig.Get<string>("RSBot.SilkroadExecutable"));
            checkEnableStaticCaptcha.Checked = GlobalConfig.Get<bool>("RSBot.General.EnableStaticCaptcha");
            checkEnableAutoLogin.Checked = GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin");
            checkStartBot.Checked = GlobalConfig.Get<bool>("RSBot.General.StartBot");
            checkUseReturnScroll.Checked = GlobalConfig.Get<bool>("RSBot.General.UseReturnScroll");
            checkStayConnected.Checked = GlobalConfig.Get<bool>("RSBot.General.StayConnected");
            checkBoxBotTrayMinimized.Checked = GlobalConfig.Get<bool>("RSBot.General.TrayWhenMinimize");
            txtStaticCaptcha.Text = GlobalConfig.Get<string>("RSBot.General.StaticCaptcha");
            comboBoxClientType.SelectedIndex = (int)Game.ClientType;

            if (File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2"))
                return;

            txtSilkroadPath.BackColor = Color.Red;
        }

        /// <summary>
        /// Called when account character list updated
        /// </summary>
        private void OnCharacterListReceived()
        {
            LoadAccounts();
        }

        /// <summary>
        /// Loads the accounts.
        /// </summary>
        private void LoadAccounts()
        {
            comboAccounts.Items.Clear();
            comboAccounts.Items.Add(LanguageManager.GetLang("NoSelected"));

            var autoLoginUserName = GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername");
            foreach (var account in Components.Accounts.SavedAccounts)
            {
                var index = comboAccounts.Items.Add(account);
                if (account.Username == autoLoginUserName)
                    comboAccounts.SelectedIndex = index;
            }

            if (comboAccounts.SelectedIndex == -1)
                comboAccounts.SelectedIndex = 0;
        }

        /// <summary>
        /// Fill the combobox on the form
        /// </summary>
        private void LoadCharacters()
        {
            comboCharacter.Items.Clear();
            comboCharacter.Items.Add(LanguageManager.GetLang("NoSelected"));

            var selectedAccount = comboAccounts.SelectedItem as Models.Account;
            if (selectedAccount?.Characters == null)
            {
                comboCharacter.SelectedIndex = 0;
                return;
            }

            foreach (var character in selectedAccount.Characters)
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
        /// Starts the client process.
        /// </summary>
        private async void StartClientProcess()
        {
            Game.Start();

            var startedResult = await ClientManager.Start().ConfigureAwait(false);
            if (!startedResult)
                Log.WarnLang("ClientStartingError");
        }

        /// <summary>
        /// Called when [start client].
        /// </summary>
        private void OnStartClient()
        {
            btnStartClient.Enabled = false;
            btnStartClientless.Enabled = false;
            _clientVisible = true;
        }

        /// <summary>
        /// Called when [exit client].
        /// </summary>
        private void OnExitClient()
        {
            _clientVisible = false;
            btnStartClient.Text = LanguageManager.GetLang("Start")  + " Client";

            if (Game.Clientless)
                return;

            btnStartClientless.Enabled = true;
            btnClientHideShow.Enabled = false;

            if (!GlobalConfig.Get<bool>("RSBot.General.StayConnected"))
            {
                btnStartClient.Enabled = true;
                Kernel.Proxy.Shutdown();
            }
            else
            {
                btnStartClient.Enabled = false;

                if (!Kernel.Proxy.IsConnectedToAgentserver)
                    return;

                ClientlessManager.GoClientless();

                btnGoClientless.Enabled = false;
                btnStartClientless.Text = LanguageManager.GetLang("Disconnect");

                Log.NotifyLang("ClientlessModeActivated");
            }
        }

        /// <summary>
        /// Called when [enter game].
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
        /// The on load version information.
        /// </summary>
        /// <param name="info">The information.</param>
        private void OnLoadVersionInfo(VersionInfo info)
        {
            lblVersion.Text = "v" + ((1000f + info.Version) / 1000f).ToString("0.000", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Called when [agent server connected].
        /// </summary>
        private void OnAgentServerConnected()
        {
            //if (!Game.Clientless)
            //    btnGoClientless.Enabled = true;
        }

        /// <summary>
        /// Called when [agent server disconnected].
        /// </summary>
        private void OnAgentServerDisconnected()
        {
            Kernel.Bot.Stop();

            // Skiped: Cuz managing from ClientlessManager
            if (Game.Clientless)
                return;

            // If user disconnected with manual from clientless, we dont need open the client automatically again.
            if (!Kernel.Proxy.ClientConnected)
                return;

            ClientManager.Kill();

            if (GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
            {
                Thread.Sleep(2000);

                StartClientProcess();
                return;
            }

            btnGoClientless.Enabled = false;
            btnStartClient.Enabled = true;
            btnStartClientless.Enabled = true;
        }

        /// <summary>
        /// Called when [client connected].
        /// </summary>
        private void OnClientConnected()
        {
            btnStartClientless.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the btnBrowseSilkroadPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
        /// Handles the CheckedChanged event of the checkStartBot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkAutoStartBot_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.General.StartBot", checkStartBot.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkUseReturnScroll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkUseReturnScroll_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.General.UseReturnScroll", checkUseReturnScroll.Checked);
        }

        /// <summary>
        /// Handles the Click event of the btnAutoLoginSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAutoLoginSettings_Click(object sender, EventArgs e)
        {
            if (View.AccountsWindow.ShowDialog() == DialogResult.OK)
                LoadAccounts();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkEnableAutoLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkEnableAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.General.EnableAutomatedLogin", checkEnableAutoLogin.Checked.ToString());
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboAccounts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAccount = comboAccounts.SelectedIndex == 0 ?
                string.Empty : comboAccounts.SelectedItem.ToString();

            GlobalConfig.Set("RSBot.General.AutoLoginAccountUsername", selectedAccount);

            LoadCharacters();
        }

        /// <summary>
        /// Handles the TextChanged event of the txtStaticCaptcha control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtStaticCaptcha_TextChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.General.StaticCaptcha", txtStaticCaptcha.Text);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkEnableStaticCaptcha control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkEnableStaticCaptcha_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.General.EnableStaticCaptcha", checkEnableStaticCaptcha.Checked.ToString());
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboCharacter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAccounts.SelectedIndex == 0)
                return;

            var selectedAccount = comboAccounts.SelectedItem as Models.Account;
            if (selectedAccount == null)
                return;

            selectedAccount.SelectedCharacter = comboCharacter.SelectedIndex == 0 ?
                string.Empty : comboCharacter.SelectedItem.ToString();

            Components.Accounts.Save();
        }

        /// <summary>
        /// Handles the Click event of the btnGoClientless control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGoClientless_Click(object sender, EventArgs e)
        {
            if (Game.Clientless)
                return;

            var msgBoxTitle = LanguageManager.GetLang("GoClientlessMsgBoxTitle");
            var msgBoxContent = LanguageManager.GetLang("GoClientlessMsgBoxContent");

            if (MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            ClientlessManager.GoClientless();
            ClientManager.Kill();

            btnStartClientless.Text = LanguageManager.GetLang("Disconnect");
            btnGoClientless.Enabled = false;
            btnStartClientless.Enabled = true;
            btnStartClient.Enabled = false;
            btnClientHideShow.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the btnStartClientless control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStartClientless_Click(object sender, EventArgs e)
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
                BotWindow.SetStatusTextLang("StartingClientless");
                Game.Start();

                btnStartClientless.Text = LanguageManager.GetLang("Disconnect");
            }
            else
            {
                var msgBoxTitle = LanguageManager.GetLang("MsgBoxDisconnectDialogTitle");
                var msgBoxContent = LanguageManager.GetLang("MsgBoxDisconnectDialogContent");

                var result = MessageBox.Show(msgBoxContent, msgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;

                Game.Clientless = false;

                btnStartClient.Enabled = true;
                btnStartClientless.Enabled = true;
                btnStartClientless.Text = LanguageManager.GetLang("Start") + " Clientless";

                Kernel.Proxy.Shutdown();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnStartClient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStartClient_Click(object sender, EventArgs e)
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

            StartClientProcess();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkStayConnected control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkStayConnected_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.General.StayConnected", checkStayConnected.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBoxBotTrayMinimized control
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
        /// Handles the SelectedIndexChanged event of the comboBoxClientType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
    }
}