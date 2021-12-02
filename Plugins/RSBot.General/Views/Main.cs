using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.General.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    internal partial class Main : UserControl
    {
        #region Fields

        private bool _clientVisible;

        #endregion Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            comboCharacter.SelectedIndex = 0;

            SubscribeEvents();
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

            if (File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2"))
                return;

            txtSilkroadPath.BackColor = Color.Red;
            txtSilkroadPath.Text += @" (Not a Silkroad directory!)";
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLoadVersionInfo", new Action<VersionInfo>(OnLoadVersionInfo));
            EventManager.SubscribeEvent("OnAgentServerConnected", OnAgentServerConnected);
            EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
            EventManager.SubscribeEvent("OnClientConnected", OnClientConnected);
            EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
            EventManager.SubscribeEvent("OnStartClient", OnStartClient);
            EventManager.SubscribeEvent("OnExitClient", OnExitClient);
            EventManager.SubscribeEvent("OnCharacterListReceived", OnCharacterListReceived);
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
            comboAccounts.SelectedIndex = comboAccounts.Items.Add("No Selected");

            var autoLoginUserName = GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername");
            foreach (var account in Components.Accounts.SavedAccounts)
            {
                var index = comboAccounts.Items.Add(account);
                if (account.Username == autoLoginUserName)
                    comboAccounts.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Fill the combobox on the form
        /// </summary>
        private void LoadCharacters()
        {
            comboCharacter.Items.Clear();
            comboCharacter.SelectedIndex = comboCharacter.Items.Add("No Selected");

            var selectedAccount = comboAccounts.SelectedItem as Models.Account;
            if (selectedAccount?.Characters == null)
                return;

            foreach (var character in selectedAccount.Characters)
            {
                var index = comboCharacter.Items.Add(character);
                if (character == selectedAccount.SelectedCharacter)
                    comboCharacter.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Starts the client process.
        /// </summary>
        private static void StartClientProcess()
        {
            Game.Start();

            using (var processLoader = new Process())
            {
                const string paramterFormat = "\"{0}\" ";

                var silkroadDirectory = GlobalConfig.Get<string>("RSBot.SilkroadDirectory");
                var silkroadExecuteable = GlobalConfig.Get<string>("RSBot.SilkroadExecutable");
                var divisionIndex = GlobalConfig.Get<byte>("RSBot.DivisionIndex");
                byte contentID = Game.ReferenceManager.DivisionInfo.Locale;
                var division = Game.ReferenceManager.DivisionInfo.Divisions[divisionIndex];
                var gatewayIndex = GlobalConfig.Get<byte>("RSBot.GatewayIndex");
                var gatewayPort = Game.ReferenceManager.GatewayInfo.Port;

                var argsBuilder = new StringBuilder();
                argsBuilder.AppendFormat(paramterFormat, GlobalConfig.Get<bool>("RSBot.Loader.DebugMode") ? 1 : 0);
                argsBuilder.AppendFormat(paramterFormat, Path.Combine(silkroadDirectory, silkroadExecuteable));
                argsBuilder.AppendFormat(paramterFormat, $"/{contentID} {divisionIndex} {gatewayIndex}");
                argsBuilder.AppendFormat(paramterFormat, Path.GetFullPath("Loader.dll"));
                argsBuilder.AppendFormat(paramterFormat, "127.0.0.1"); //RedirectIP
                argsBuilder.AppendFormat(paramterFormat, Kernel.Proxy.Port); //RedirectPort
                argsBuilder.AppendFormat(paramterFormat, division.GatewayServers.Count); //GatewayIPCount
                foreach (var gatewayServer in division.GatewayServers)
                    argsBuilder.AppendFormat(paramterFormat, gatewayServer); //GatewayIP[n]
                argsBuilder.AppendFormat(paramterFormat, gatewayPort); //GatewayPort

                processLoader.StartInfo.FileName = Path.GetFullPath("Loader.exe");
                processLoader.StartInfo.Arguments = argsBuilder.ToString();
                if (!processLoader.Start()) return;

                processLoader.WaitForExit();
                Kernel.ClientProcessId = processLoader.ExitCode;
            }
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
            btnStartClient.Text = "Start Client";

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
                btnStartClientless.Text = "Disconnect";

                Log.Notify("Clientless mode has been activated.");
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
                btnClientHideShow.Text = "Hide Client";
                btnStartClient.Enabled = true;
                btnStartClient.Text = "Kill Client";
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
            lblVersion.Text = "Client v" + ((1000f + info.Version) / 1000f).ToString("0.000", CultureInfo.InvariantCulture);
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

            if (GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
            {
                Kernel.KillClient();
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
                dialog.Title = "Please select the silkroad client's executable.";
                dialog.Filter = "Executable (*.exe)|*.exe";
                dialog.FileName = "sro_client.exe";

                var result = dialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                txtSilkroadPath.Text = dialog.FileName;
                GlobalConfig.Set("RSBot.SilkroadDirectory", Path.GetDirectoryName(dialog.FileName));
                GlobalConfig.Set("RSBot.SilkroadExecutable", Path.GetFileName(dialog.FileName));

                result = MessageBox.Show(
                    "You have set a new path to your silkroad directory. In order to apply these changes, please restart your bot. Do you want to restart the bot now?",
                    "New path",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

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
            var accountSettings = new Accounts();
            if (accountSettings.ShowDialog() == DialogResult.OK)
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
            if (comboAccounts.SelectedIndex == 0)
                return;

            GlobalConfig.Set("RSBot.General.AutoLoginAccountUsername", comboAccounts.SelectedItem.ToString());

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
            if (comboCharacter.SelectedIndex == 0)
                return;

            if (comboAccounts.SelectedIndex == 0)
                return;

            var selectedAccount = comboAccounts.SelectedItem as Models.Account;
            if (selectedAccount == null)
                return;

            selectedAccount.SelectedCharacter = comboCharacter.SelectedItem.ToString();
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

            if (MessageBox.Show(
                    "Do you want to go clientless?\n\nYou will need to restart the bot in order to get into client again.",
                    "Clientless", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            ClientlessManager.GoClientless();
            Kernel.KillClient();

            btnStartClientless.Text = "Disconnect";
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
                    MessageBox.Show(
                        "To start the clientless mode, you must first define a user account that can be used for automated login.\nPlease make also sure that the automated login is enabled.",
                        "The automatic login is set up incorrectly!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                btnStartClient.Enabled = false;
                btnClientHideShow.Enabled = false;

                Game.Clientless = true;
                BotWindow.SetStatusText("Starting clientless session...");
                Game.Start();

                btnStartClientless.Text = "Disconnect";
            }
            else
            {
                var result = MessageBox.Show(
                        "Your character will be disconnect! Are you sure about that?",
                        "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;

                Game.Clientless = false;

                btnStartClient.Enabled = true;
                btnStartClientless.Enabled = true;
                btnStartClientless.Text = "Start Clientless";

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
            if(!Game.Clientless && Kernel.Proxy != null && Kernel.Proxy.IsConnectedToAgentserver)
            {
                var extraStr = ".\nDon't worry your character will stay online (clientless)!";
                if (!GlobalConfig.Get<bool>("RSBot.General.StayConnected"))
                    extraStr = " and your character will be disconnected!";

                if(MessageBox.Show($"The game client will now be closed{extraStr}\n\nAre you sure about this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Kernel.KillClient();

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
            if (Kernel.ClientProcess == null)
                return;

            if (!_clientVisible)
            {
                _clientVisible = true;
                NativeExtensions.ShowWindow(Kernel.ClientProcess.MainWindowHandle, NativeExtensions.SW_SHOW);
                btnClientHideShow.Text = "Hide Client";
            }
            else
            {
                _clientVisible = false;
                NativeExtensions.ShowWindow(Kernel.ClientProcess.MainWindowHandle, NativeExtensions.SW_HIDE);
                btnClientHideShow.Text = "Show Client";
            }
        }
    }
}