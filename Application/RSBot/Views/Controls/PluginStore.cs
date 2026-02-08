using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Views.Controls
{
    public partial class PluginStore : UserControl
    {
        private PluginRepository _currentRepository;
        private CancellationTokenSource _downloadCancellation;

        public PluginStore()
        {
            InitializeComponent();
        }

        private static string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double size = bytes;

            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }

            return $"{size:0.##} {sizes[order]}";
        }

        public void On_DownloadProgressChanged(object sender, DownloadProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => On_DownloadProgressChanged(sender, e)));
                return;
            }

            progressBarDownload.Value = e.ProgressPercentage;
            labelStatus.Text = $"Downloading {e.FileName}: {e.ProgressPercentage}% ({FormatBytes(e.BytesReceived)} / {FormatBytes(e.TotalBytesToReceive)})";
            progressBarDownload.Visible = true;
            labelStatus.Visible = true;
        }

        private void BtnRefreshWeb_Click(object sender, EventArgs e)
        {
            LoadWebPlugins();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadWebPlugins();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadWebPlugins();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        internal async void LoadWebPlugins()
        {
            // ⭐ Suspend layout
            flowPanelWeb.SuspendLayout();

            try
            {
                flowPanelWeb.Controls.Clear();
                labelStatus.Text = "Loading plugins from repository...";
                btnRefreshWeb.Enabled = false;

                try
                {
                    var repoUrl = "https://raw.githubusercontent.com/sdclowen/rsbot-plugins/main/repository.json";


                    _currentRepository = await ExtensionManager.LoadRepositoryFromUrl(repoUrl);

                    if (_currentRepository == null || _currentRepository.Plugins.Count == 0)
                    {
                        labelStatus.Text = "No plugins found in repository";
                        return;
                    }

                    // Apply search filter
                    var searchTerm = txtSearch.Text.Trim().ToLower();
                    var filteredPlugins = string.IsNullOrEmpty(searchTerm)
                        ? _currentRepository.Plugins
                        : _currentRepository.Plugins.Where(p =>
                            p.DisplayName.ToLower().Contains(searchTerm) ||
                            p.Description.ToLower().Contains(searchTerm) ||
                            p.Category.ToLower().Contains(searchTerm) ||
                            p.Tags.Any(t => t.ToLower().Contains(searchTerm))
                        ).ToList();

                    // ⭐ Batch create all cards
                    var cards = new List<PluginCard>();

                    foreach (var pluginInfo in filteredPlugins.OrderByDescending(p => p.Rating))
                    {
                        var card = new PluginCard
                        {
                            PluginInfo = pluginInfo,
                            Dock = DockStyle.Top,
                        };

                        card.DownloadClicked += async (s, e) => await DownloadPlugin(pluginInfo);

                        cards.Add(card);
                    }

                    // ⭐ Add all cards at once
                    if (cards.Count > 0)
                    {
                        foreach (var cardItem in cards)
                        {
                            flowPanelWeb.Controls.Add(new System.Windows.Forms.Panel() { Height = 10, Dock = DockStyle.Top });
                            flowPanelWeb.Controls.Add(cardItem);
                        }
                    }

                    labelStatus.Text = $"Found {filteredPlugins.Count} plugins in repository '{_currentRepository.Name}'";
                }
                catch (Exception ex)
                {
                    labelStatus.Text = $"Error loading repository: {ex.Message}";
                    Log.Error($"Failed to load web plugins: {ex.Message}");
                }
                finally
                {
                    btnRefreshWeb.Enabled = true;
                }
            }
            finally
            {
                // ⭐ Resume layout
                flowPanelWeb.ResumeLayout(true);
            }
        }


        private async Task DownloadPlugin(PluginInfo pluginInfo)
        {
            try
            {
                _downloadCancellation = new CancellationTokenSource();
                progressBarDownload.Value = 0;
                progressBarDownload.Visible = true;
                labelStatus.Text = $"Starting download: {pluginInfo.DisplayName}...";

                var success = await ExtensionManager.DownloadAndInstallPlugin<IPlugin>(
                    pluginInfo.DownloadUrl,
                    autoLoad: true,
                    _downloadCancellation.Token
                );

                if (success)
                {
                    labelStatus.Text = $"✓ {pluginInfo.DisplayName} downloaded and installed successfully!";
                    EventManager.FireEvent("OnPluginListChanged");

                    MessageBox.Show(
                        $"Plugin '{pluginInfo.DisplayName}' has been installed successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    labelStatus.Text = $"✗ Failed to download {pluginInfo.DisplayName}";
                }
            }
            catch (Exception ex)
            {
                labelStatus.Text = $"✗ Error: {ex.Message}";
                Log.Error($"Download failed: {ex.Message}");
            }
            finally
            {
                progressBarDownload.Visible = false;
                _downloadCancellation?.Dispose();
                _downloadCancellation = null;
            }
        }

        public void Stop()
        {
            _downloadCancellation?.Cancel();
        }
    }
}
