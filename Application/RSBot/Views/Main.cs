using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Plugins;
using RSBot.Views.Dialog;
using SDUI;
using SDUI.Controls;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static SDUI.NativeMethods;

namespace RSBot.Views
{
    public partial class Main : CleanForm
    {
        /// <summary>
        /// Bot player name [_cached]
        /// </summary>
        private string _playerName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            RegisterEvents();
        }

        /// <summary>
        /// Refreshes the theme.
        /// </summary>
        public void RefreshTheme()
        {
            BackColor = ColorScheme.BackColor;
            stripStatus.BackColor = BackColor.IsDark() ? ColorScheme.BorderColor : Color.FromArgb(33, 150, 243);
            stripStatus.ForeColor = ColorScheme.ForeColor;
            GlobalConfig.Save();
        }

        /// <summary>
        /// Registers the events.
        /// </summary>
        private void RegisterEvents()
        {
            EventManager.SubscribeEvent("OnChangeStatusText", new Action<string>(OnChangeStatusText));
            EventManager.SubscribeEvent("OnLoadPlugins", OnLoadPlugins);
            EventManager.SubscribeEvent("OnLoadDivisionInfo", new Action<DivisionInfo>(OnLoadDivisionInfo));
            EventManager.SubscribeEvent("OnLoadBotbases", OnLoadBotbases);
            EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
            EventManager.SubscribeEvent("OnStartBot", OnStartBot);
            EventManager.SubscribeEvent("OnStopBot", OnStopBot);
            EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        }

        /// <summary>
        /// Selects the botbase.
        /// </summary>
        /// <param name="index">The index.</param>
        private void SelectBotbase(int index)
        {
            if (Kernel.Bot.Running)
                return;

            if (menuBotbase.DropDownItems.Count <= index) return;

            var selectedBotbase = Kernel.BotbaseManager.Bots.ElementAt(index).Value;
            if (selectedBotbase == null)
                return;

            selectedBotbase.Translate();

            menuBotbase.Text = selectedBotbase.Info.DisplayName;
            menuBotbase.Image = selectedBotbase.Info.Image;
            menuBotbase.Tag = selectedBotbase;
            _ = tabMain.Handle; //Generate the handle for the tab control

            if (Kernel.Bot?.Botbase != null)
                tabMain.TabPages.RemoveByKey(Kernel.Bot.Botbase.Info.Name);

            //Add the tab to the tabcontrol
            var tabPage = new TabPage(LanguageManager.GetLangBySpecificKey(selectedBotbase.Info.Name, "TabText", selectedBotbase.Info.TabText))
            {
                Name = selectedBotbase.Info.Name,
                Enabled = Game.Player != null
            };

            tabPage.BackColor = Color.FromArgb(200, BackColor);
            tabPage.ForeColor = ForeColor;
            tabPage.Controls.Add(selectedBotbase.GetView());

            tabMain.TabPages.Insert(1, tabPage);

            Kernel.Bot?.SetBotbase(selectedBotbase);
            GlobalConfig.Set("RSBot.BotIndex", index.ToString());

            if (Game.Player == null)
            {
                var info = new InfoControl
                {
                    Name = "overlay",
                    Text = LanguageManager.GetLang("PleaseEnterGame"),
                    Location = new Point(tabMain.Width / 2 - 110, tabMain.Height - 150),
                };

                tabPage.Controls.Add(info);
                //So we can see it at least..
                //control.BringToFront();
                info.BringToFront();
            }
        }

        /// <summary>
        /// Loads the extensions.
        /// </summary>
        private void LoadExtensions()
        {
            foreach (var plugin in Kernel.PluginManager.Extensions.Values)
                plugin.Initialize();

            var extensions =
                Kernel.PluginManager.Extensions.OrderBy(entry => entry.Value.Information.TabDisplayIndex)
                    .ToDictionary(x => x.Key, x => x.Value);

            foreach (var extension in extensions.Where(extension => extension.Value.Information.DisplayAsTab))
            {
                extension.Value.Translate();

                var tabPage = new TabPage
                {
                    Text = LanguageManager.GetLangBySpecificKey(extension.Value.Information.InternalName, "DisplayName", extension.Value.Information.DisplayName),
                    Enabled = !extension.Value.Information.RequireIngame,
                    Name = extension.Value.Information.InternalName
                };

                var control = extension.Value.GetView();

                control.Dock = DockStyle.Fill;

                tabPage.BackColor = Color.FromArgb(200, BackColor);
                tabPage.ForeColor = ForeColor;

                tabPage.Controls.Add(control);
                tabMain.TabPages.Add(tabPage);

                if (tabPage.Enabled)
                    continue;

                var info = new InfoControl
                {
                    Name = "overlay",
                    Text = LanguageManager.GetLang("PleaseEnterGame"),
                    Location = new Point(tabMain.Width / 2 - 110, tabMain.Height - 150)
                };

                tabPage.Controls.Add(info);

                //So we can see it at least..
                //control.BringToFront();
                info.BringToFront();
            }

            foreach (var extension in extensions.Where(extension => !extension.Value.Information.DisplayAsTab))
            {
                var menuItemText = LanguageManager.GetLangBySpecificKey(extension.Value.Information.InternalName, "DisplayName", extension.Value.Information.DisplayName);
                var menuItem = new ToolStripMenuItem(menuItemText)
                {
                    Enabled = !extension.Value.Information.RequireIngame
                };
                menuItem.Click += PluginMenuItem_Click;
                menuItem.Tag = extension.Value;

                menuPlugins.DropDownItems.Add(menuItem);
            }
        }

        /// <summary>
        /// Configures the sidebar.
        /// </summary>
        private void ConfigureSidebar()
        {
            var size = Size;
            if (menuSidebar.Checked)
            {
                size.Width = 1048;
                pSidebar.Visible = true;
            }
            else
            {
                size.Width = 800;
                pSidebar.Visible = false;
            }

            size.Height = 724;
            Size = size;
            Width = size.Width;
            Height = size.Height;
            MinimumSize = size;
            MaximumSize = size;
        }

        /// <summary>
        /// Populates the server combobox.
        /// </summary>
        /// <param name="info">The information.</param>
        private void PopulateServerCombobox(DivisionInfo info)
        {
            comboServer.Items.Clear();
            foreach (var item in info.Divisions[comboDivision.SelectedIndex].GatewayServers)
                comboServer.Items.Add(item);

            var gatewayIndex = GlobalConfig.Get<int>("RSBot.GatewayIndex");

            if (comboServer.Items.Count > 0)
                comboServer.SelectedIndex = comboServer.Items.Count - 1 >= gatewayIndex ? gatewayIndex : 0;

            GlobalConfig.Set("RSBot.GatewayIndex", comboServer.SelectedIndex.ToString());
        }

        /// <summary>
        /// Handles the Click event of the MenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void PluginMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var plugin = (IPlugin)menuItem.Tag;

            var window = new CleanForm
            {
                Text = plugin.Information.DisplayName,
                Name = plugin.Information.InternalName,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Icon = Icon,
                StartPosition = FormStartPosition.CenterScreen
            };

            var content = plugin.GetView();
            plugin.Translate();
            content.Dock = DockStyle.Fill;

            window.Size = new Size(content.Size.Width + 15, content.Size.Height + 15);
            window.Controls.Add(content);
            window.Show();
        }

        /// <summary>
        /// Handles the Click event of the menuScriptRecorder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuScriptRecorder_Click(object sender, EventArgs e)
        {
            var scriptRecorder = new ScriptRecorder();
            scriptRecorder.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GlobalConfig.Save();
            PlayerConfig.Save();
        }

        /// <summary>
        /// Handles the Click event of the menuSidebar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuSidebar_Click(object sender, EventArgs e)
        {
            menuSidebar.Checked = !menuSidebar.Checked;
            GlobalConfig.Set("RSBot.ShowSidebar", menuSidebar.Checked.ToString());

            ConfigureSidebar();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboDivision control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.DivisionIndex", comboDivision.SelectedIndex.ToString());

            if (Game.ReferenceManager.DivisionInfo != null)
                PopulateServerCombobox(Game.ReferenceManager.DivisionInfo);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.GatewayIndex", comboServer.SelectedIndex.ToString());
        }

        /// <summary>
        /// Handles the Load event of the Main window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Main_Load(object sender, EventArgs e)
        {
            menuSidebar.Checked = GlobalConfig.Get("RSBot.ShowSidebar", true);

            foreach (var item in LanguageManager.GetLanguages())
            {
                var dropdown = new ToolStripMenuItem(item.Value);
                dropdown.Click += LanguageDropdown_Click;
                dropdown.Tag = item.Key;
                languageToolStripMenuItem.DropDownItems.Add(dropdown);

                if (Kernel.Language.ToString() == dropdown.Text)
                    dropdown.Checked = true;
            }

            ConfigureSidebar();
            BackColor = ColorScheme.BackColor;
            menuCurrentProfile.Text = ProfileManager.SelectedProfile;

            EventManager.FireEvent("OnInitialized");
        }

        /// <summary>
        /// Handles the Click event of the MenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void LanguageDropdown_Click(object sender, EventArgs e)
        {
            var dropdown = sender as ToolStripMenuItem;
            if (dropdown.Checked)
                return;

            Kernel.Language = dropdown.Tag.ToString();

            foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
                item.Checked = false;

            foreach (var plugin in Kernel.PluginManager.Extensions)
            {
                plugin.Value.Translate();

                var tabpage = tabMain.TabPages[plugin.Key];
                tabpage.Text = LanguageManager.GetLangBySpecificKey(plugin.Key, "DisplayName");
            }

            foreach (var botbase in Kernel.BotbaseManager.Bots)
            {
                botbase.Value.Translate();

                var tabpage = tabMain.TabPages[botbase.Key];
                tabpage.Text = LanguageManager.GetLangBySpecificKey(botbase.Key, "DisplayName");
            }

            LanguageManager.Translate(this, Kernel.Language);

            dropdown.Checked = true;

            GlobalConfig.Set("RSBot.Language", Kernel.Language);
            GlobalConfig.Save();
        }

        /// <summary>
        ///Handles the Click event of the btnStartStop control.
        /// </summary>
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (Kernel.Proxy == null)
                return;

            if (!Kernel.Proxy.IsConnectedToAgentserver)
                return;

            if (Kernel.Bot == null)
            {
                Log.NotifyLang("NotifyPleaseSelectProperBotBase");
                return;
            }

            if (Game.Player == null)
            {
                Log.WarnLang("NotifyPlayerWasNull");
                return;
            }

            if (!Kernel.Bot.Running)
            {
                Kernel.Bot.Start();

                BotWindow.SetStatusTextLang("Running");
            }
            else
            {
                Log.NotifyLang("StopingBot", Kernel.Bot.Botbase.Info.DisplayName);

                Kernel.Bot.Stop();
                BotWindow.SetStatusTextLang("Ready");
            }
        }

        /// <summary>
        /// Handles the Click event of the BotbaseItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BotbaseItem_Click(object sender, EventArgs e)
        {
            var index = (int)((ToolStripMenuItem)sender).Tag;
            SelectBotbase(index);
        }

        /// <summary>
        /// Handles the Click event of the picLogo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void picLogo_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/sdclowen/rsbot");
        }

        /// <summary>
        /// Handles the FormClosing event of the Main control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Kernel.Proxy == null || !Kernel.Proxy.ClientConnected || !GlobalConfig.Get<bool>("RSBot.showExitDialog", true))
            {
                GlobalConfig.Save();
                PlayerConfig.Save();

                Environment.Exit(0);
            }

            var exitDialog = new ExitDialog();
            if (exitDialog.ShowDialog(this) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            GlobalConfig.Save();
            PlayerConfig.Save();
            ClientManager.Kill();

            Environment.Exit(0);
        }

        /// <summary>
        /// Called when [start bot].
        /// </summary>
        private void OnStartBot()
        {
            btnStartStop.Text = LanguageManager.GetLang("StopBot");
        }

        /// <summary>
        /// Called when [stop bot].
        /// </summary>
        private void OnStopBot()
        {
            btnStartStop.Text = LanguageManager.GetLang("StartBot");
        }

        private void OnLoadBotbases()
        {
            if (Kernel.BotbaseManager.Bots == null || Kernel.BotbaseManager.Bots.Count == 0)
            {
                var title = LanguageManager.GetLang("NoBotbaseDetected");
                var message = LanguageManager.GetLang("NoBotbaseDetectedDesc");
                var messageResult = MessageBox.Show(message, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                if (messageResult == DialogResult.Retry)
                    Kernel.BotbaseManager.LoadAssemblies();
                else if (messageResult == DialogResult.Abort)
                    Environment.Exit(-1);
            }
            var index = 0;
            foreach (var item in Kernel.BotbaseManager.Bots.Select(botbase => new ToolStripMenuItem
            {
                Tag = index,
                Text = botbase.Value.Info.DisplayName,
                Image = botbase.Value.Info.Image
            }))
            {
                item.Click += BotbaseItem_Click;
                menuBotbase.DropDownItems.Add(item);
                index++;
            }

            SelectBotbase(GlobalConfig.Get<int>("RSBot.BotIndex"));
        }

        /// <summary>
        /// Reset UI after character disconnect
        /// </summary>
        private void OnAgentServerDisconnected()
        {
            foreach (TabPage tabPage in tabMain.TabPages)
            {
                if (!tabPage.Controls.ContainsKey("overlay"))
                    continue;

                tabPage.Enabled = false;
                tabPage.Controls["overlay"].Show();
            }

            var disconnectedText = LanguageManager.GetLang("Disconnected");
            if (!Text.EndsWith(disconnectedText))
            {
                Text = $@"RSBot - {_playerName} - {disconnectedText}";
                notifyIcon.Text = Text;
            }
        }

        private void OnChangeStatusText(string text)
        {
            lblIngameStatus.Text = text;
        }

        private void OnLoadPlugins()
        {
            LoadExtensions();
        }

        private void OnLoadDivisionInfo(DivisionInfo info)
        {
            comboDivision.Items.Clear();
            foreach (var divInfo in info.Divisions)
                comboDivision.Items.Add(divInfo.Name);

            var divisionIndex = GlobalConfig.Get<int>("RSBot.DivisionIndex");

            if (comboDivision.Items.Count >= info.Divisions.Count)
                comboDivision.SelectedIndex = comboDivision.SelectedIndex = comboDivision.Items.Count - 1 >= divisionIndex ? divisionIndex : 0;

            PopulateServerCombobox(info);
        }

        /// <summary>
        /// Cores the on enter game.
        /// </summary>
        private void OnLoadCharacter()
        {
            foreach (TabPage tabPage in tabMain.TabPages)
            {
                tabPage.Enabled = true;

                tabPage.Controls["overlay"]?.Hide();
            }

            foreach (ToolStripItem item in menuPlugins.DropDownItems)
                item.Enabled = true;

            _playerName = Game.Player.Name;
            Text = $@"RSBot - {_playerName}";
            notifyIcon.Text = Text;

            if (Game.Clientless)
                Text += " [Clientless]";
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                return;

            /*notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(1000, "RSBot", "RSBot visible mode", ToolTipIcon.Info);*/

            Show();
            WindowState = FormWindowState.Normal;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                return;

            if (!GlobalConfig.Get<bool>("RSBot.General.TrayWhenMinimize"))
                return;

            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(1000);

            Hide();
        }

        private void menuItemThis_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalConfig.Set("SDUI.Color", Color.Black.ToArgb());
            ColorScheme.BackColor = Color.Black;

            RefreshTheme();
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalConfig.Set("SDUI.Color", Color.White.ToArgb());
            ColorScheme.BackColor = Color.White;

            RefreshTheme();
        }

        private void coloredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            var customColors = GlobalConfig.GetArray<int>("SDUI.CustomColors");
            colorDialog.CustomColors = customColors;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                GlobalConfig.Set("SDUI.Color", colorDialog.Color.ToArgb());
                GlobalConfig.SetArray("SDUI.CustomColors", colorDialog.CustomColors);
                ColorScheme.BackColor = colorDialog.Color;
                BackColor = ColorScheme.BackColor;

                RefreshTheme();
            }
        }

        private void menuSelectProfile_Click(object sender, EventArgs e)
        {
            var dialog = new ProfileSelectionDialog();
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ShowInTaskbar = false;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            if (dialog.SelectedProfile == ProfileManager.SelectedProfile)
                return;

            var oldSroPath = GlobalConfig.Get("RSBot.SilkroadDirectory", "");

            //We need this to check if the sro directories are different
            var tempNewConfig = new Config(ProfileManager.GetProfileFile(dialog.SelectedProfile));

            if (oldSroPath != tempNewConfig.Get("RSBot.SilkroadDirectory", ""))
            {
                if (MessageBox.Show("This profile references to a different client, do you want to restart the bot?", "Restart bot?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    Application.Restart();

            }

            ProfileManager.SetSelectedProfile(dialog.SelectedProfile);
            GlobalConfig.Load();

            EventManager.FireEvent("OnProfileChanged");
            menuCurrentProfile.Text = dialog.SelectedProfile;

            if (Game.Player == null)
                return;

            //Reload player config
            PlayerConfig.Load(Game.Player.Name);

            //A little hack to tell all plugins to reload their UI
            EventManager.FireEvent("OnLoadCharacter");
        }
    }
}