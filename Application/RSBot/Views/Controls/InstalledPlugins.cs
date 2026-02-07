using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Views.Controls
{
    public partial class InstalledPlugins : UserControl
    {
        public InstalledPlugins()
        {
            InitializeComponent();

            EventManager.SubscribeEvent("OnPluginListChanged", LoadLocalPlugins);
        }

        internal void LoadLocalPlugins()
        {
            // ⭐ CRITICAL: Suspend all layout operations
            flowPanelLocal.SuspendLayout();

            try
            {
                // Clear all controls at once
                flowPanelLocal.Controls.Clear();

                if (ExtensionManager.Plugins == null)
                {
                    lblLocalStatus.Text = "No plugins loaded";
                    return;
                }

                // ⭐ Batch create all cards first (without adding to panel)
                var cards = new List<PluginCard>();

                foreach (var plugin in ExtensionManager.Plugins)
                {
                    var card = new PluginCard
                    {
                        Plugin = plugin,
                        Margin = new Padding(10),
                        Width = 350,
                        Height = 150
                    };

                    card.ToggleClicked += (s, e) =>
                    {
                        if (plugin.Enabled)
                            ExtensionManager.DisablePlugin(plugin.InternalName);
                        else
                            ExtensionManager.EnablePlugin(plugin.InternalName);

                        LoadLocalPlugins(); // Refresh
                    };

                    cards.Add(card);
                }

                // ⭐ Add all cards at once (much faster!)
                if (cards.Count > 0)
                {
                    flowPanelLocal.Controls.AddRange(cards.ToArray());
                }

                var enabledCount = ExtensionManager.Plugins.Count(p => p.Enabled);
                lblLocalStatus.Text = $"Total: {cards.Count} plugins ({enabledCount} enabled)";
            }
            finally
            {
                // ⭐ Resume layout and perform single layout operation
                flowPanelLocal.ResumeLayout(true);
            }
        }

        private void btnRefreshLocal_Click(object sender, EventArgs e)
        {
            LoadLocalPlugins();
        }

        private void btnLoadPlugin_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Title = "Select Plugin DLL",
                Filter = "Plugin DLL (*.dll)|*.dll|All Files (*.*)|*.*",
                InitialDirectory = Path.Combine(Kernel.BasePath, "Data", "Plugins"),
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (ExtensionManager.LoadPluginFromFile<IPlugin>(openFileDialog.FileName))
                {
                    LoadLocalPlugins();
                    EventManager.FireEvent("OnPluginListChanged");
                    MessageBox.Show("Plugin loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to load plugin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
