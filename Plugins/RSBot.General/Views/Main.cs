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

        private bool _clientIsShowed;

        #endregion Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
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

            if (File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2")) return;

            txtSilkroadPath.BackColor = Color.Red;
            txtSilkroadPath.Text += @" (Not a Silkroad directory!)";
        }

        /// <summary>
        /// Loads the accounts.
        /// </summary>
        private void LoadAccounts()
        {
            comboAccounts.Items.Clear();
            foreach (var account in Components.Accounts.SavedAccounts)
                comboAccounts.Items.Add(account.Username);

            if (comboAccounts.Items.Count > GlobalConfig.Get<int>("RSBot.General.AccountIndex"))
                comboAccounts.SelectedIndex = GlobalConfig.Get<int>("RSBot.General.AccountIndex");
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
        }

        /// <summary>
        /// Starts the client process.
        /// </summary>
        private static void StartClientProcess()
        {
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
            btnClientHideShow.Enabled = true;
            btnClientHideShow.Text = "Hide Client";
            _clientIsShowed = true;
        }

        /// <summary>
        /// Called when [exit client].
        /// </summary>
        private void OnExitClient()
        {
            _clientIsShowed = false;
            //Client -> Clientless
            if (Game.Clientless)
                return;

            btnGoClientless.Enabled = false;

            if (!GlobalConfig.Get<bool>("RSBot.General.StayConnected"))
            {
                btnStartClient.Enabled = true;
                btnGoClientless.Enabled = false;
                btnStartClientless.Enabled = true;
                btnClientHideShow.Enabled = false;

                Game.Start();
            }
            else
            {
                Game.Clientless = true;
                btnStartClientless.Text = "Disconnect";
                btnStartClientless.Enabled = true;
            }
        }

        /// <summary>
        /// Called when [enter game].
        /// </summary>
        private void OnEnterGame()
        {
            Task.Run(() =>
            {
                //Wait for the game to be ready!
                while (!Game.Ready)
                    Thread.Sleep(100);

                var startBot = GlobalConfig.Get<bool>("RSBot.General.StartBot");
                var useReturnScroll = GlobalConfig.Get<bool>("RSBot.General.UseReturnScroll");

                if (useReturnScroll)
                    Game.Player.UseReturnScroll();

                if (startBot)
                    Kernel.Bot.Start();
            });
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
            if (!Game.Clientless)
                btnGoClientless.Enabled = true;
        }

        /// <summary>
        /// Called when [agent server disconnected].
        /// </summary>
        private void OnAgentServerDisconnected()
        {
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
            GlobalConfig.Set("RSBot.General.AccountIndex", comboAccounts.SelectedIndex.ToString());

            var selectedAccount = Components.Accounts.SavedAccounts[GlobalConfig.Get<int>("RSBot.General.AccountIndex")];

            comboCharacter.Items.Clear();
            if (selectedAccount?.Characters == null) return;
            foreach (var character in selectedAccount.Characters.Where(name => !string.IsNullOrEmpty(name)))
                comboCharacter.Items.Add(character);

            if (comboCharacter.Items.Count > GlobalConfig.Get<int>("RSBot.General.CharacterIndex"))
                comboCharacter.SelectedIndex = GlobalConfig.Get<int>("RSBot.General.CharacterIndex");
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
            GlobalConfig.Set("RSBot.General.CharacterIndex", comboCharacter.SelectedIndex.ToString());
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
            btnStartClientless.Text = "Disconnect";
            btnGoClientless.Enabled = false;
            btnStartClientless.Enabled = true;
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
                if (!checkEnableAutoLogin.Checked || (string)comboAccounts.SelectedItem == "")
                {
                    MessageBox.Show(
                        "To start the clientless mode, you must first define a user account that can be used for automated login.\nPlease make also sure that the automated login is enabled.",
                        "The automatic login is set up incorrectly!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                btnStartClient.Enabled = false;
                Game.Clientless = true;
                BotWindow.SetStatusText("Starting clientless session...");
                Game.Start();

                btnStartClientless.Text = "Disconnect";
            }
            else
            {
                Game.Clientless = false;
                Game.Start();

                btnStartClientless.Text = "Start clientless";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnStartClient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStartClient_Click(object sender, EventArgs e)
        {
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

            if (!_clientIsShowed)
            {
                _clientIsShowed = true;
                NativeExtensions.ShowWindow(Kernel.ClientProcess.MainWindowHandle, NativeExtensions.SW_SHOW);
                btnClientHideShow.Text = "Hide Client";
            }
            else
            {
                _clientIsShowed = false;
                NativeExtensions.ShowWindow(Kernel.ClientProcess.MainWindowHandle, NativeExtensions.SW_HIDE);
                btnClientHideShow.Text = "Show Client";
            }
        }
    }
}