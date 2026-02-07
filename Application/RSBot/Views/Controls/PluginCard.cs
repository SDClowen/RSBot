using RSBot.Core.Plugins;
using SDUI.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RSBot.Views.Controls;

/// <summary>
///     Modern card control for displaying plugin information.
/// </summary>
public partial class PluginCard : DoubleBufferedControl
{
    private IPlugin _plugin;
    private PluginInfo _pluginInfo;
    private bool _isWebPlugin;

    public PluginCard()
    {
        InitializeComponent();
        
        Click += (s, e) => CardClicked?.Invoke(this, e);
    }

    /// <summary>
    ///     Gets or sets the local plugin.
    /// </summary>
    public IPlugin Plugin
    {
        get => _plugin;
        set
        {
            _plugin = value;
            _isWebPlugin = false;
            UpdateDisplay();
        }
    }

    /// <summary>
    ///     Gets or sets the web plugin info.
    /// </summary>
    public PluginInfo PluginInfo
    {
        get => _pluginInfo;
        set
        {
            _pluginInfo = value;
            _isWebPlugin = true;
            UpdateDisplay();
        }
    }

    /// <summary>
    ///     Event raised when toggle button is clicked.
    /// </summary>
    public event EventHandler ToggleClicked;

    /// <summary>
    ///     Event raised when download button is clicked.
    /// </summary>
    public event EventHandler DownloadClicked;

    /// <summary>
    ///     Event raised when card is clicked.
    /// </summary>
    public event EventHandler CardClicked;

    private void UpdateDisplay()
    {
        // ⭐ Suspend layout during update to prevent flickering
        SuspendLayout();
        
        try
        {
            if (_isWebPlugin && _pluginInfo != null)
            {
                lblPluginName.Text = _pluginInfo.DisplayName;
                lblDescription.Text = _pluginInfo.Description;
                lblVersion.Text = $"v{_pluginInfo.Version}";
                lblAuthor.Text = $"by {_pluginInfo.Author}";
                
                // Show download button for web plugins
                btnToggle.Visible = false;
                btnDownload.Visible = true;
                
                // Show rating
                if (_pluginInfo.Rating > 0)
                {
                    lblRating.Text = $"⭐ {_pluginInfo.Rating:F1}/5";
                    lblRating.Visible = true;
                }
                
                // Show category badge
                if (!string.IsNullOrEmpty(_pluginInfo.Category))
                {
                    lblCategory.Text = _pluginInfo.Category;
                    lblCategory.Visible = true;
                }
            }
            else if (!_isWebPlugin && _plugin != null)
            {
                lblPluginName.Text = _plugin.DisplayName;
                lblDescription.Text = _plugin.GetType().Assembly.GetName().Version?.ToString() ?? "Local Plugin";
                lblVersion.Text = _plugin.Enabled ? "✓ Enabled" : "✗ Disabled";
                lblAuthor.Text = _plugin.InternalName;
                
                // Show toggle button for local plugins
                btnToggle.Visible = true;
                btnDownload.Visible = false;
                btnToggle.Text = _plugin.Enabled ? "Disable" : "Enable";
                btnToggle.BackColor = _plugin.Enabled ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69);
                
                // Hide web-specific elements
                lblRating.Visible = false;
                lblCategory.Visible = false;
            }
        }
        finally
        {
            ResumeLayout(true); // Perform layout once
            Refresh(); // Single refresh
        }
    }

    private void InitializeComponent()
    {

        lblPluginName = new SDUI.Controls.Label();
        lblDescription = new SDUI.Controls.Label();
        lblVersion = new SDUI.Controls.Label();
        lblAuthor = new SDUI.Controls.Label();
        lblRating = new SDUI.Controls.Label();
        lblCategory = new SDUI.Controls.Label();
        btnToggle = new SDUI.Controls.Button();
        btnDownload = new SDUI.Controls.Button();
        SuspendLayout();
        
        Controls.Add(lblPluginName);
        Controls.Add(lblDescription);
        Controls.Add(lblVersion);
        Controls.Add(lblAuthor);
        Controls.Add(lblRating);
        Controls.Add(lblCategory);
        Controls.Add(btnToggle);
        Controls.Add(btnDownload);
        
        // lblPluginName
        lblPluginName.ApplyGradient = false;
        lblPluginName.AutoSize = true;
        lblPluginName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblPluginName.Location = new Point(15, 15);
        lblPluginName.Name = "lblPluginName";
        lblPluginName.Size = new Size(100, 21);
        lblPluginName.TabIndex = 0;
        lblPluginName.Text = "Plugin Name";
        
        // lblDescription
        lblDescription.ApplyGradient = false;
        lblDescription.Font = new Font("Segoe UI", 9F);
        lblDescription.ForeColor = Color.FromArgb(108, 117, 125);
        lblDescription.Location = new Point(15, 45);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(320, 40);
        lblDescription.TabIndex = 1;
        lblDescription.Text = "Plugin description goes here...";
        
        // lblVersion
        lblVersion.ApplyGradient = false;
        lblVersion.AutoSize = true;
        lblVersion.Font = new Font("Segoe UI", 8.25F);
        lblVersion.ForeColor = Color.FromArgb(108, 117, 125);
        lblVersion.Location = new Point(15, 90);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new Size(50, 13);
        lblVersion.TabIndex = 2;
        lblVersion.Text = "v1.0.0";
        
        // lblAuthor
        lblAuthor.ApplyGradient = false;
        lblAuthor.AutoSize = true;
        lblAuthor.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
        lblAuthor.ForeColor = Color.FromArgb(108, 117, 125);
        lblAuthor.Location = new Point(15, 108);
        lblAuthor.Name = "lblAuthor";
        lblAuthor.Size = new Size(80, 13);
        lblAuthor.TabIndex = 3;
        lblAuthor.Text = "by Author";
        
        // lblRating
        lblRating.ApplyGradient = false;
        lblRating.AutoSize = true;
        lblRating.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRating.ForeColor = Color.FromArgb(255, 193, 7);
        lblRating.Location = new Point(240, 15);
        lblRating.Name = "lblRating";
        lblRating.Size = new Size(60, 15);
        lblRating.TabIndex = 4;
        lblRating.Text = "⭐ 4.5/5";
        lblRating.Visible = false;
        
        // lblCategory
        lblCategory.ApplyGradient = false;
        lblCategory.AutoSize = true;
        lblCategory.BackColor = Color.FromArgb(0, 123, 255);
        lblCategory.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        lblCategory.ForeColor = Color.White;
        lblCategory.Location = new Point(240, 40);
        lblCategory.Name = "lblCategory";
        lblCategory.Padding = new Padding(5, 2, 5, 2);
        lblCategory.Size = new Size(50, 17);
        lblCategory.TabIndex = 5;
        lblCategory.Text = "Tools";
        lblCategory.Visible = false;
        
        // btnToggle
        btnToggle.BackColor = Color.FromArgb(40, 167, 69);
        btnToggle.Color = Color.FromArgb(40, 167, 69);
        btnToggle.Cursor = Cursors.Hand;
        btnToggle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnToggle.ForeColor = Color.White;
        btnToggle.Location = new Point(240, 105);
        btnToggle.Name = "btnToggle";
        btnToggle.Radius = 6;
        btnToggle.ShadowDepth = 2F;
        btnToggle.Size = new Size(95, 30);
        btnToggle.TabIndex = 6;
        btnToggle.Text = "Enable";
        btnToggle.UseVisualStyleBackColor = false;
        btnToggle.Click += BtnToggle_Click;
        
        // btnDownload
        btnDownload.BackColor = Color.FromArgb(0, 123, 255);
        btnDownload.Color = Color.FromArgb(0, 123, 255);
        btnDownload.Cursor = Cursors.Hand;
        btnDownload.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDownload.ForeColor = Color.White;
        btnDownload.Location = new Point(240, 105);
        btnDownload.Name = "btnDownload";
        btnDownload.Radius = 6;
        btnDownload.ShadowDepth = 2F;
        btnDownload.Size = new Size(95, 30);
        btnDownload.TabIndex = 7;
        btnDownload.Text = "Download";
        btnDownload.UseVisualStyleBackColor = false;
        btnDownload.Visible = false;
        btnDownload.Click += BtnDownload_Click;

        Name = "PluginCard";
        Size = new Size(350, 150);
        ResumeLayout(false);
    }

    private void BtnToggle_Click(object sender, EventArgs e)
    {
        ToggleClicked?.Invoke(this, e);
    }

    private void BtnDownload_Click(object sender, EventArgs e)
    {
        DownloadClicked?.Invoke(this, e);
    }

    private SDUI.Controls.Label lblPluginName;
    private SDUI.Controls.Label lblDescription;
    private SDUI.Controls.Label lblVersion;
    private SDUI.Controls.Label lblAuthor;
    private SDUI.Controls.Label lblRating;
    private SDUI.Controls.Label lblCategory;
    private SDUI.Controls.Button btnToggle;
    private SDUI.Controls.Button btnDownload;
}
