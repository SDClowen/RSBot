using RSBot.Core.Plugins;
using RSBot.Views.Controls;
using SDUI.Controls;
using System.Windows.Forms;

namespace RSBot.Views;

public partial class PluginManager : UIWindow
{
    private InstalledPlugins _installedPluginsControl;
    private PluginStore _pluginStoreControl;

    public PluginManager()
    {
        InitializeComponent();
        _installedPluginsControl = new();
        _pluginStoreControl = new();

        _installedPluginsControl.LoadLocalPlugins();

        SetupKeyboardShortcuts();

        var localInstalledPluginsControl = (Control)_installedPluginsControl;
        localInstalledPluginsControl.Text = "Installed Plugins";
        windowPageControl.Controls.Add( localInstalledPluginsControl );

        var webPluginStoreControl = (Control)_pluginStoreControl;
        webPluginStoreControl.Text = "Plugin Store";
        windowPageControl.Controls.Add( webPluginStoreControl );

        // Subscribe to download progress
        ExtensionManager.DownloadProgressChanged += _pluginStoreControl.On_DownloadProgressChanged;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _pluginStoreControl.Stop();
        ExtensionManager.DownloadProgressChanged -= _pluginStoreControl.On_DownloadProgressChanged;
        base.OnFormClosing(e);
    }

    private void SetupKeyboardShortcuts()
    {
        KeyPreview = true;
        KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.F5)
            {
                if (windowPageControl.SelectedIndex == 0)
                    _installedPluginsControl.LoadLocalPlugins();
                else
                    _pluginStoreControl.LoadWebPlugins();
                e.Handled = true;
            }
        };
    }

    private void windowPageControl_SelectedIndexChanged(object sender, int e)
    {
        if (windowPageControl.SelectedIndex == 1)
        {
            _pluginStoreControl.LoadWebPlugins();
        }
    }
}
