using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Plugins;
using RSBot.Views.Dialog;
using SDUI;
using SDUI.Controls;
using SDUI.Helpers;

namespace RSBot.Views;

public partial class Main : UIWindow
{
    public static readonly Color LightThemeColor = Color.FromArgb(255, 255, 255);
    public static readonly Color DarkThemeColor = Color.FromArgb(16, 16, 16);

    #region Members

    /// <summary>
    ///     Bot player name [_cached]
    /// </summary>
    private string _playerName;
    private readonly Dictionary<string, UIWindow> _pluginWindows = new(8);
    private bool _isWindowLoaded;

    #endregion Members

    #region Constructor

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        InitializeComponent();
        CheckForIllegalCrossThreadCalls = false;
        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
        RegisterEvents();

        Text = "RSBot";
        Shown += Main_Shown;
    }

    #endregion Constructor

    #region Events

    public static event UserPreferenceChangingEventHandler UserPreferenceChanging;

    #endregion

    #region Methods

    private void donateButton_Click(object sender, EventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = "https://buymeacoffee.com/sdclowen", UseShellExecute = true });
        Process.Start(
            new ProcessStartInfo { FileName = "https://github.com/sponsors/SDClowen", UseShellExecute = true }
        );
        Process.Start(new ProcessStartInfo { FileName = "https://www.patreon.com/sdclowen", UseShellExecute = true });
    }

    /// <summary>
    ///     Called when user preference changing
    /// </summary>
    /// <param name="sender">The sender</param>
    /// <param name="e">The event args</param>
    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        if (BackColor.IsDark() == WindowsHelper.IsDark())
            return;

        var detectDarkLight = GlobalConfig.Get("RSBot.Theme.Auto", true);
        if (!detectDarkLight)
            return;

        if (WindowsHelper.IsDark())
            SetThemeColor(DarkThemeColor);
        else
            SetThemeColor(LightThemeColor);
    }

    /// <summary>
    ///     Set theme color
    /// </summary>
    /// <param name="color">The color</param>
    private void SetThemeColor(Color color)
    {
        GlobalConfig.Set("SDUI.Color", color.ToArgb());
        ColorScheme.BackColor = color;
        RefreshTheme();
    }

    /// <summary>
    ///     Refreshes the theme.
    /// </summary>
    public void RefreshTheme(bool save = true)
    {
        BackColor = ColorScheme.BackColor;
        stripStatus.BackColor = BackColor.IsDark() ? ColorScheme.BorderColor : Color.FromArgb(33, 150, 243);
        stripStatus.ForeColor = ColorScheme.ForeColor;

        if (save)
            GlobalConfig.Save();
    }

    /// <summary>
    ///     Registers the events.
    /// </summary>
    private void RegisterEvents()
    {
        EventManager.SubscribeEvent("OnChangeStatusText", new Action<string>(OnChangeStatusText));
        EventManager.SubscribeEvent("OnShowBotWindow", OnShowBotWindow);
        EventManager.SubscribeEvent("OnLoadPlugins", OnLoadPlugins);
        EventManager.SubscribeEvent("OnLoadDivisionInfo", new Action<DivisionInfo>(OnLoadDivisionInfo));
        EventManager.SubscribeEvent("OnLoadBotbases", OnLoadBotbases);
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnStartBot", OnStartBot);
        EventManager.SubscribeEvent("OnStopBot", OnStopBot);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        EventManager.SubscribeEvent("OnShowScriptRecorder", new Action<int, bool>(OnShowScriptRecorder));
        EventManager.SubscribeEvent("OnAddSidebarElement", new Action<Control>(OnAddSidebarElement));
    }

    private void OnAddSidebarElement(Control obj)
    {
        pSidebarCustom.Controls.Add(obj);
    }

    private void OnShowScriptRecorder(int ownerId, bool startRecording)
    {
        var recorder = new ScriptRecorder(ownerId, startRecording);
        recorder.Show();
    }

    /// <summary>
    ///     Forces to show the bot window
    /// </summary>
    private void OnShowBotWindow()
    {
        if (WindowState == FormWindowState.Minimized)
            WindowState = FormWindowState.Normal;

        TopMost = true;

        BringToFront();
        Activate();

        TopMost = false;
    }

    /// <summary>
    ///     Selects the botbase.
    /// </summary>
    /// <param name="index">The index.</param>
    private async Task SelectBotbase(string name)
    {
        if (Kernel.Bot.Running)
            return;

        var oldBotbaseName = Kernel.Bot?.Botbase?.Name;
        var previousSelectedIndex = windowPageControl.SelectedIndex;

        var newBotbase = Kernel.BotbaseManager.Bots.FirstOrDefault(bot => bot.Value.Name == name);
        if (newBotbase.Value == null)
        {
            Log.Error($"Botbase [{name}] could not be found!");

            return;
        }

        newBotbase.Value.Translate();

        var control = newBotbase.Value.View;
        control.Name = newBotbase.Value.Name;
        control.Text = LanguageManager.GetLangBySpecificKey(newBotbase.Value.Name, "TabText", newBotbase.Value.TabText);
        control.Enabled = Game.Ready;
        windowPageControl.Controls.Add(control);

        var botbaseIndex = 1;

        windowPageControl.Controls.SetChildIndex(control, botbaseIndex);

        if (_isWindowLoaded)
        {
            if (!string.IsNullOrWhiteSpace(oldBotbaseName) && previousSelectedIndex == botbaseIndex)
            {
                // If a botbase was previously selected and the new one replaces it at the same index,
                // move to the next tab if available.
                if (botbaseIndex + 1 < windowPageControl.Controls.Count)
                {
                    windowPageControl.SelectedIndex = botbaseIndex + 1;
                    await Task.Delay(100);
                    windowPageControl.SelectedIndex = botbaseIndex;
                }
            }
            else
            {
                windowPageControl.SelectedIndex = botbaseIndex;
            }
        }

        Kernel.Bot?.SetBotbase(newBotbase.Value);
        GlobalConfig.Set("RSBot.BotName", newBotbase.Value.Name);

        if (Game.Player != null)
            EventManager.FireEvent("OnLoadCharacter");

        foreach (ToolStripMenuItem item in botsToolStripMenuItem.DropDown.Items)
            item.Checked = newBotbase.Value.Name == item.Name;

        if (!string.IsNullOrWhiteSpace(oldBotbaseName) && windowPageControl.Controls.ContainsKey(oldBotbaseName))
            windowPageControl.Controls.RemoveByKey(oldBotbaseName);
    }

    /// <summary>
    ///     Loads the extensions.
    /// </summary>
    private void LoadExtensions()
    {
        foreach (var plugin in Kernel.PluginManager.Extensions.Values)
            plugin.Initialize();

        var extensions = Kernel
            .PluginManager.Extensions.OrderBy(entry => entry.Value.Index)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var extension in extensions.Where(extension => extension.Value.DisplayAsTab))
        {
            extension.Value.Translate();

            var control = extension.Value.View;
            control.Name = extension.Value.InternalName;
            
            control.Text = LanguageManager.GetLangBySpecificKey(
                extension.Value.InternalName,
                "DisplayName",
                extension.Value.DisplayName
            );
            control.Enabled = !extension.Value.RequireIngame;
            control.Dock = DockStyle.Fill;
            
            windowPageControl.Controls.Add(control);
            if (control.Name == "RSBot.Python" && !GlobalConfig.Get("RSBot.ShowPythonPlugins", true))
                windowPageControl.Controls.Remove(control);
        }

        foreach (var extension in extensions.Where(extension => !extension.Value.DisplayAsTab))
        {
            var menuItemText = LanguageManager.GetLangBySpecificKey(
                extension.Value.InternalName,
                "DisplayName",
                extension.Value.DisplayName
            );
            var menuItem = new ToolStripMenuItem(menuItemText) { Enabled = !extension.Value.RequireIngame };
            menuItem.Click += PluginMenuItem_Click;
            menuItem.Tag = extension.Value;

            menuPlugins.DropDownItems.Add(menuItem);
        }
    }

    /// <summary>
    ///     Configures the sidebar.
    /// </summary>
    private void ConfigureSidebar()
    {
        pSidebar.Visible = menuSidebar.Checked;
    }

    /// <summary>
    ///     Populates the server combobox.
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

    private void Main_Shown(object sender, EventArgs e)
    {
        _isWindowLoaded = true;
    }

    #endregion Methods

    #region Form events

    /// <summary>
    ///     Handles the Click event of the MenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    private void PluginMenuItem_Click(object sender, EventArgs e)
    {
        var menuItem = (ToolStripMenuItem)sender;
        var plugin = (IPlugin)menuItem.Tag;
        var content = plugin.View;

        if (content == null)
        {
            Log.Debug($"Plugin [{plugin.InternalName}] does not have a view defined!");
            return;
        }

        if (!_pluginWindows.TryGetValue(plugin.InternalName, out var pluginWindow) || pluginWindow.IsDisposed)
        {
            pluginWindow = new UIWindow
            {
                Text = plugin.DisplayName,
                Name = plugin.InternalName,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Icon = Icon,
                StartPosition = FormStartPosition.CenterParent,
                ShowTitle = true,
            };

            content.Dock = DockStyle.Fill;

            plugin.Translate();

            pluginWindow.Size = new Size(content.Size.Width + 16, content.Size.Height + 32);
            pluginWindow.Controls.Add(content);

            _pluginWindows[plugin.InternalName] = pluginWindow;
        }

        if (!pluginWindow.Visible)
            pluginWindow.Show();
    }

    /// <summary>
    ///     Handles the Click event of the menuScriptRecorder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
    ///     Handles the Click event of the menuSidebar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void menuSidebar_Click(object sender, EventArgs e)
    {
        menuSidebar.Checked = !menuSidebar.Checked;
        GlobalConfig.Set("RSBot.ShowSidebar", menuSidebar.Checked.ToString());

        ConfigureSidebar();
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void comboDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.DivisionIndex", comboDivision.SelectedIndex.ToString());

        if (Game.ReferenceManager.DivisionInfo != null)
            PopulateServerCombobox(Game.ReferenceManager.DivisionInfo);
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboServer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void comboServer_SelectedIndexChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.GatewayIndex", comboServer.SelectedIndex.ToString());
    }

    /// <summary>
    ///     Handles the Load event of the Main window.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Main_Load(object sender, EventArgs e)
    {
        menuSidebar.Checked = GlobalConfig.Get("RSBot.ShowSidebar", true);
        pyPluginsToolStripMenuItem.Checked = GlobalConfig.Get("RSBot.ShowPythonPlugins", true);

        foreach (var item in LanguageManager.GetLanguages())
        {
            var dropdown = new ToolStripMenuItem(item.Value);
            dropdown.Click += LanguageDropdown_Click;
            dropdown.Tag = item.Key;
            languageToolStripMenuItem.DropDownItems.Add(dropdown);

            if (Kernel.Language == dropdown.Text)
                dropdown.Checked = true;
        }

        ConfigureSidebar();
        BackColor = ColorScheme.BackColor;
        menuCurrentProfile.Text = "Profile: " + ProfileManager.SelectedProfile;

        EventManager.FireEvent("OnInitialized");
    }

    /// <summary>
    ///     Handles the Click event of the MenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

            var tabpage = windowPageControl.Controls[plugin.Key];
            if (tabpage == null)
                continue;

            tabpage.Text = LanguageManager.GetLangBySpecificKey(plugin.Key, "DisplayName", tabpage.Text);
        }

        foreach (var botbase in Kernel.BotbaseManager.Bots)
        {
            botbase.Value.Translate();

            if (!windowPageControl.Controls.ContainsKey(botbase.Key))
                continue;

            var tabpage = windowPageControl.Controls[botbase.Key];
            tabpage.Text = LanguageManager.GetLangBySpecificKey(botbase.Key, "DisplayName", tabpage.Text);
        }

        LanguageManager.Translate(this, Kernel.Language);

        dropdown.Checked = true;

        GlobalConfig.Set("RSBot.Language", Kernel.Language);
        GlobalConfig.Save();
    }

    /// <summary>
    ///     Handles the Click event of the btnStartStop control.
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

            Log.StatusLang("Running");
        }
        else
        {
            Log.NotifyLang("StopingBot", Kernel.Bot.Botbase.DisplayName);

            Kernel.Bot.Stop();
            Log.StatusLang("Ready");
        }
    }

    /// <summary>
    ///     Handles the FormClosing event of the Main control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (Kernel.Proxy == null || !Kernel.Proxy.ClientConnected || !GlobalConfig.Get("RSBot.showExitDialog", true))
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
    ///     Handles the Click event of the notifyIcon control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void notifyIcon_Click(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Normal)
            return;

        /*notifyIcon.Visible = true;
        notifyIcon.ShowBalloonTip(1000, "RSBot", "RSBot visible mode", ToolTipIcon.Info);*/

        Show();
        WindowState = FormWindowState.Normal;
    }

    /// <summary>
    ///     Handles the Click event of the menuItemExit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void menuItemExit_Click(object sender, EventArgs e)
    {
        if (Kernel.Proxy == null || !Kernel.Proxy.ClientConnected || !GlobalConfig.Get("RSBot.showExitDialog", true))
        {
            GlobalConfig.Save();
            PlayerConfig.Save();

            Environment.Exit(0);
        }

        var exitDialog = new ExitDialog();
        if (exitDialog.ShowDialog(this) != DialogResult.Yes)
            return;

        GlobalConfig.Save();
        PlayerConfig.Save();
        ClientManager.Kill();

        Environment.Exit(0);
    }

    /// <summary>
    ///     Handles the Resize event of the Main control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Main_Resize(object sender, EventArgs e)
    {
        if (WindowState != FormWindowState.Minimized)
            return;

        if (!GlobalConfig.Get<bool>("RSBot.General.TrayWhenMinimize"))
            return;

        notifyIcon.Visible = true;
        notifyIcon.ShowBalloonTip(1000);

        Hide();
    }

    /// <summary>
    ///     Handles the Click event of the menuItemThis control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void menuItemThis_Click(object sender, EventArgs e)
    {
        new AboutDialog().ShowDialog();
    }

    /// <summary>
    ///     Handles the Click event of the networkConfigToolStripMenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void networkConfigToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var configDialog = new ConfigDialog();
        configDialog.ShowDialog();
    }

    /// <summary>
    ///     Handles the Click event of the darkToolStripMenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void darkToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.Theme.Auto", false);
        SetThemeColor(DarkThemeColor);
    }

    /// <summary>
    ///     Handles the Click event of the lightToolStripMenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void lightToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.Theme.Auto", false);
        SetThemeColor(LightThemeColor);
    }

    /// <summary>
    ///     Handles the Click event of the autoToolStripMenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void autoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (WindowsHelper.IsModern)
        {
            GlobalConfig.Set("RSBot.Theme.Auto", true);
            SystemEvents_UserPreferenceChanged(null, new UserPreferenceChangedEventArgs(UserPreferenceCategory.Color));

            return;
        }

        MessageBox.Show(
            "Unfortunately, it does not support this mode because your operating system is outdated!",
            "Warning",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        );
    }

    /// <summary>
    ///     Handles the Click event of the coloredToolStripMenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void coloredToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var colorDialog = new ColorDialog { CustomColors = GlobalConfig.GetArray<int>("SDUI.CustomColors") };

        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            GlobalConfig.SetArray("SDUI.CustomColors", colorDialog.CustomColors);
            SetThemeColor(colorDialog.Color);
        }
    }

    /// <summary>
    ///     Handles the Click event of the menuSelectProfile control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
            if (
                MessageBox.Show(
                    "This profile references to a different client, do you want to restart the bot?",
                    "Restart bot?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                ) == DialogResult.OK
            )
                Application.Restart();

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

    /// <summary>
    ///     Handles the Click event of the buttonConfig control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void buttonConfig_Click(object sender, EventArgs e)
    {
        const string title = "IP Bind";

        var currentBind = GlobalConfig.Get("RSBot.Network.BindIp", "0.0.0.0");

        const string message =
            "Use your custom interface ip for connect to game.\nEnter your interface Ip:\t(default: 0.0.0.0)";

        var dialog = new InputDialog(title, title, message, defaultValue: currentBind);
        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        if (!IPAddress.TryParse(dialog.Value.ToString(), out var ipAddress))
        {
            const string errorMessage = "The IP address is incorrect or cannot be verified.You can try like '0.0.0.0'.";
            MessageBox.Show(errorMessage);

            return;
        }

        GlobalConfig.Set("RSBot.Network.BindIp", ipAddress.ToString());
    }
    private void pyPluginsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        pyPluginsToolStripMenuItem.Checked = !pyPluginsToolStripMenuItem.Checked;
        GlobalConfig.Set("RSBot.ShowPythonPlugins", pyPluginsToolStripMenuItem.Checked.ToString());
        foreach( var plugin in Kernel.PluginManager.Extensions.Values)
        {
            if (plugin.InternalName == "RSBot.Python")
            {
                var control = plugin.View;
                var pluginIndex = windowPageControl.Controls.IndexOf(control);
                var currentIndex = windowPageControl.SelectedIndex;

                if (pyPluginsToolStripMenuItem.Checked && !windowPageControl.Controls.Contains(control))
                    windowPageControl.Controls.Add(control);
                else if (!pyPluginsToolStripMenuItem.Checked && windowPageControl.Controls.Contains(control))
                {
                    windowPageControl.Controls.Remove(control);
                    if (pluginIndex == currentIndex)
                        windowPageControl.SelectedIndex = 0;
                }
                    
            }
        }
    }
    #endregion Form events

    #region Core events

    /// <summary>
    ///     Called when [start bot].
    /// </summary>
    private void OnStartBot()
    {
        btnStartStop.Text = LanguageManager.GetLang("StopBot");
    }

    /// <summary>
    ///     Called when [stop bot].
    /// </summary>
    private void OnStopBot()
    {
        btnStartStop.Text = LanguageManager.GetLang("StartBot");
    }

    /// <summary>
    ///     Called when [load botbases].
    /// </summary>
    private void OnLoadBotbases()
    {
        if (Kernel.BotbaseManager.Bots == null || Kernel.BotbaseManager.Bots.Count == 0)
        {
            var title = LanguageManager.GetLang("NoBotbaseDetected");
            var message = LanguageManager.GetLang("NoBotbaseDetectedDesc");
            var messageResult = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Error
            );

            if (messageResult == DialogResult.Retry)
                Kernel.BotbaseManager.LoadAssemblies();
            else if (messageResult == DialogResult.Abort)
                Environment.Exit(-1);
        }

        foreach (var bot in Kernel.BotbaseManager.Bots)
        {
            var item = new ToolStripMenuItem { Name = bot.Value.Name, Text = bot.Value.DisplayName };
            item.Click += Item_Click;
            botsToolStripMenuItem.DropDown.Items.Add(item);
        }

        SelectBotbase(GlobalConfig.Get("RSBot.BotName", "RSBot.Training"));
    }

    /// <summary>
    ///     Handles the Click event of the MenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    private async void Item_Click(object? sender, EventArgs e)
    {
        var item = sender as ToolStripMenuItem;
        await SelectBotbase(item.Name);
    }

    /// <summary>
    ///     Reset UI after character disconnect
    /// </summary>
    private void OnAgentServerDisconnected()
    {
        foreach (Control control in windowPageControl.Controls)
        {
            if (!control.Controls.ContainsKey("overlay"))
                continue;

            control.Enabled = false;
            control.Controls["overlay"].Show();
        }

        var disconnectedText = LanguageManager.GetLang("Disconnected");
        if (!Text.EndsWith(disconnectedText))
        {
            Text = $@"RSBot - {_playerName} - {disconnectedText}";
            notifyIcon.Text = Text;
        }
    }

    /// <summary>
    ///     Called when [change status text].
    /// </summary>
    /// <param name="text">The text.</param>
    private void OnChangeStatusText(string text)
    {
        lblIngameStatus.Text = text;
    }

    /// <summary>
    ///     Called when [load plugins].
    /// </summary>
    private void OnLoadPlugins()
    {
        LoadExtensions();
    }

    /// <summary>
    ///     Called when [load division information].
    /// </summary>
    /// <param name="info">The information.</param>
    private void OnLoadDivisionInfo(DivisionInfo info)
    {
        comboDivision.Items.Clear();
        foreach (var divInfo in info.Divisions)
            comboDivision.Items.Add(divInfo.Name);

        var divisionIndex = GlobalConfig.Get<int>("RSBot.DivisionIndex");

        if (comboDivision.Items.Count >= info.Divisions.Count)
            comboDivision.SelectedIndex = comboDivision.SelectedIndex =
                comboDivision.Items.Count - 1 >= divisionIndex ? divisionIndex : 0;

        PopulateServerCombobox(info);
    }

    /// <summary>
    ///     Called when [load character].
    /// </summary>
    private void OnLoadCharacter()
    {
        foreach (Control control in windowPageControl.Controls)
        {
            control.Enabled = true;

            control.Controls["overlay"]?.Hide();
        }

        foreach (ToolStripItem item in menuPlugins.DropDownItems)
            item.Enabled = true;

        _playerName = Game.Player.Name;
        Text = $@"RSBot - {_playerName}";
        notifyIcon.Text = Text;

        if (Game.Clientless)
            Text += " [Clientless]";

        if (Kernel.Debug)
            Text += $@" [JID = {Game.Player.JID}]";

        ApplyPlayerConfig();
    }

    /// <summary>
    /// Applys all player settings to plugins
    /// </summary>
    private static void ApplyPlayerConfig()
    {
        foreach (var plugin in Kernel.PluginManager.Extensions.Values)
            plugin.OnLoadCharacter();
    }

    #endregion Core events

    
}
