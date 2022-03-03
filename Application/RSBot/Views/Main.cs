using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Plugins;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Views
{
    public partial class Main : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            RegisterEvents();

            toolStripStatusLabelBeta.Alignment = ToolStripItemAlignment.Right;
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
            if (menuBotbase.DropDownItems.Count <= index) return;

            var selectedBotbase = Kernel.BotbaseManager.Bots.ElementAt(index).Value;
            if (selectedBotbase == null) return;

            menuBotbase.Text = selectedBotbase.Info.DisplayName;
            menuBotbase.Image = selectedBotbase.Info.Image;
            menuBotbase.Tag = selectedBotbase;
            var tempHandle = tabMain.Handle; //Generate the handle for this bitch

            tabMain.TabPages.RemoveByKey("tabBotbase");
            //Add the tab to the tabcontrol
            var tabPage = new TabPage(selectedBotbase.Info.TabText)
            {
                Name = "tabBotbase",
                Enabled = false
            };

            tabPage.Controls.Add(selectedBotbase.GetView());

            tabMain.TabPages.Insert(1, tabPage);

            Kernel.Bot.SetBotbase(selectedBotbase);
            GlobalConfig.Set("RSBot.BotIndex", index.ToString());

            var info = new Theme.Controls.TabDisabledInfo { Name = "overlay", Location = new Point(tabMain.Width / 2 - 110, tabMain.Height - 150) };
            tabPage.Controls.Add(info);

            //So we can see it at least..
            //control.BringToFront();
            info.BringToFront();
        }

        /// <summary>
        /// Loads the extensions.
        /// </summary>
        private void LoadExtensions()
        {
            foreach (var ext in Kernel.PluginManager.Extensions.Values)
                ext.Initialize();

            var tempExtensions =
                Kernel.PluginManager.Extensions.OrderBy(entry => entry.Value.Information.TabDisplayIndex)
                    .ToDictionary(x => x.Key, x => x.Value);

            foreach (var extension in tempExtensions.Where(extension => extension.Value.Information.DisplayAsTab))
            {
                var tabPage = new TabPage
                {
                    Text = extension.Value.Information.DisplayName,
                    Enabled = !extension.Value.Information.RequireIngame
                };

                var control = extension.Value.GetView();

                control.Dock = DockStyle.Fill;

                tabPage.Controls.Add(control);
                tabMain.TabPages.Add(tabPage);

                if (tabPage.Enabled) continue;

                var info = new Theme.Controls.TabDisabledInfo
                {
                    Name = "overlay",
                    Location = new Point(tabMain.Width / 2 - 110, tabMain.Height - 150)
                };

                tabPage.Controls.Add(info);

                //So we can see it at least..
                //control.BringToFront();
                info.BringToFront();
            }

            foreach (var extension in tempExtensions.Where(extension => !extension.Value.Information.DisplayAsTab))
            {
                var menuItem = new MenuItem(extension.Value.Information.DisplayName)
                {
                    Enabled = !extension.Value.Information.RequireIngame
                };
                menuItem.Click += PluginMenuItem_Click;
                menuItem.Tag = extension.Value;

                menuPlugins.MenuItems.Add(menuItem);
            }
        }

        /// <summary>
        /// Configures the sidebar.
        /// </summary>
        private void ConfigureSidebar()
        {
            if (menuSidebar.Checked)
            {
                Size = new Size(1048, 724);
                pSidebar.Visible = true;
            }
            else
            {
                Size = new Size(800, 724);
                pSidebar.Visible = false;
            }
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
        /// Clears the cache.
        /// </summary>
        private static Task ClearCacheAsync()
        {
            try
            {
                var files = Directory.GetFiles(CacheController.CacheDirectory);
                foreach (var file in files)
                    File.Delete(file);

                Directory.Delete(CacheController.CacheDirectory);

                if (Game.MediaPk2.Archive == null)
                    Game.MediaPk2 = CacheController.Initialize(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2");

                Log.Notify($"[Cache] Clearing finished. [{files.Length}] files were deleted from the file system.");
                BotWindow.SetStatusText("Cache cleared");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the Click event of the MenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void PluginMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var plugin = (IPlugin)menuItem.Tag;

            var window = new Form()
            {
                Text = plugin.Information.DisplayName,
                Name = plugin.Information.InternalName,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Icon = Icon,
                StartPosition = FormStartPosition.CenterScreen
            };

            var content = plugin.GetView();
            content.Dock = DockStyle.Fill;

            window.Size = new Size(content.Size.Width + 15, content.Size.Height + 15);
            window.Controls.Add(content);
            window.Show();
        }

        /// <summary>
        /// Handles the Click event of the menuEnableCache control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuEnableCache_Click(object sender, EventArgs e)
        {
            menuEnableCache.Checked = !menuEnableCache.Checked;
            GlobalConfig.Set("RSBot.EnableFileCache", menuEnableCache.Checked.ToString());
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

        /// <summary>
        /// Handles the Click event of the menuClearCache control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void menuClearCache_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you realy want to clear the cache? \n It may impact the performance, because the bot has to rebuild it dynamically during the runtime.",
                    "Clear Cache", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Log.Notify("[Cache] Deleting cached file(s)...");
                BotWindow.SetStatusText("Clearing cache...");

                await ClearCacheAsync();
            }
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
            menuEnableCache.Checked = GlobalConfig.Get<bool>("RSBot.EnableFileCache", true);
            menuSidebar.Checked = GlobalConfig.Get<bool>("RSBot.ShowSidebar", true);
            ConfigureSidebar();
        }

        /// <summary>
        ///Handles the Click event of the btnStartStop control.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (Kernel.Proxy == null)
                return;

            if (!Kernel.Proxy.IsConnectedToAgentserver)
                return;

            if (Kernel.Bot == null)
            {
                Log.Notify("Please select a proper botbase and try again");
                return;
            }

            if (Game.Player == null)
            {
                Log.Notify("Your character has to be in the game in order to start the bot.");
                return;
            }

            if (btnStartStop.Text == @"START BOT")
            {
                Kernel.Bot.Start();

                BotWindow.SetStatusText("Running");
            }
            else
            {
                Log.Notify($"Stopping bot [{Kernel.Bot.Botbase.Info.DisplayName}]");
                Kernel.Bot.Stop();
                BotWindow.SetStatusText("Ready");
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
        /// Handles the Click event of the menuAboutCaching control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuAboutCaching_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If the cache is enabled, the bot does not require a silkroad installation in order to run. " +
                            "But to build the cache for the first time, the bot needs to have a valid silkroad directory. " +
                            "Files will be cached as they are requested by the bot or plugins, if a file was not cached, and no silkroad directory is selected (as backup)" +
                            "it may cause exceptions.\n\nKeep in mind to clear the cache after silkroad client updates to avoid undesirable behaviors.", "About caching", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handles the Click event of the picLogo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void picLogo_Click(object sender, EventArgs e)
        {
            Process.Start("http://roadshark-bot.com");
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

            if (exitDialog.ShowDialog() != DialogResult.Yes)
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
            btnStartStop.Text = @"STOP BOT";
        }

        /// <summary>
        /// Called when [stop bot].
        /// </summary>
        private void OnStopBot()
        {
            btnStartStop.Text = @"START BOT";
        }

        private void OnLoadBotbases()
        {
            if (Kernel.BotbaseManager.Bots == null || Kernel.BotbaseManager.Bots.Count == 0)
            {
                var messageResult = MessageBox.Show(
                    "The bot can not be run without any botbase!\n Please install a proper botbase and try again.\n You can find help at http://roadshark-bot.com/",
                    "No botbase detected!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

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

            foreach (MenuItem item in menuPlugins.MenuItems)
                item.Enabled = true;

            Text = $@"RSBot - {Game.Player.Name}";

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
    }
}