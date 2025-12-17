using System.Drawing;
using System.Windows.Forms;

namespace RSBot.Python.Views;

partial class Main
{
    /// <summary>
    ///     Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    ///     Required method for Designer support - do not modify
    ///     the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        mainPanel = new SDUI.Controls.Panel();
        flowLayoutPanel1 = new SDUI.Controls.FlowLayoutPanel();
        btnReload = new SDUI.SK.Button();
        btnOpenFolder = new SDUI.SK.Button();
        tcPlugin = new SDUI.Controls.TabControl();
        tpPlugins = new TabPage();
        dgvPlugin = new DataGridView();
        tbPluginLog = new RichTextBox();
        ColEnabled = new DataGridViewCheckBoxColumn();
        ColName = new DataGridViewTextBoxColumn();
        ColDescription = new DataGridViewTextBoxColumn();
        ColAuthor = new DataGridViewTextBoxColumn();
        ColVersion = new DataGridViewTextBoxColumn();
        FileName = new DataGridViewTextBoxColumn();
        mainPanel.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        tcPlugin.SuspendLayout();
        tpPlugins.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPlugin).BeginInit();
        SuspendLayout();
        // 
        // mainPanel
        // 
        mainPanel.BackColor = Color.Transparent;
        mainPanel.Border = new Padding(0, 0, 0, 0);
        mainPanel.BorderColor = Color.Transparent;
        mainPanel.Controls.Add(flowLayoutPanel1);
        mainPanel.Controls.Add(tcPlugin);
        mainPanel.Controls.Add(tbPluginLog);
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 0);
        mainPanel.Name = "mainPanel";
        mainPanel.Radius = 10;
        mainPanel.ShadowDepth = 4F;
        mainPanel.Size = new Size(600, 467);
        mainPanel.TabIndex = 0;
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.BackColor = Color.Transparent;
        flowLayoutPanel1.Border = new Padding(0, 0, 0, 0);
        flowLayoutPanel1.BorderColor = Color.Transparent;
        flowLayoutPanel1.Controls.Add(btnReload);
        flowLayoutPanel1.Controls.Add(btnOpenFolder);
        flowLayoutPanel1.Dock = DockStyle.Bottom;
        flowLayoutPanel1.Location = new Point(0, 326);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Radius = 10;
        flowLayoutPanel1.ShadowDepth = 4F;
        flowLayoutPanel1.Size = new Size(600, 42);
        flowLayoutPanel1.TabIndex = 2;
        // 
        // btnReload
        // 
        btnReload.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnReload.BackColor = Color.Transparent;
        btnReload.Color = Color.Transparent;
        btnReload.DialogResult = DialogResult.None;
        btnReload.Image = null;
        btnReload.Location = new Point(3, 3);
        btnReload.Name = "btnReload";
        btnReload.Radius = 6;
        btnReload.ShadowDepth = 4F;
        btnReload.Size = new Size(94, 29);
        btnReload.TabIndex = 0;
        btnReload.Text = "Reload";
        btnReload.UseVisualStyleBackColor = true;
        btnReload.Click += btnReload_Click;
        // 
        // btnOpenFolder
        // 
        btnOpenFolder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnOpenFolder.BackColor = Color.Transparent;
        btnOpenFolder.Color = Color.Transparent;
        btnOpenFolder.DialogResult = DialogResult.None;
        btnOpenFolder.Image = null;
        btnOpenFolder.Location = new Point(103, 3);
        btnOpenFolder.Name = "btnOpenFolder";
        btnOpenFolder.Radius = 6;
        btnOpenFolder.ShadowDepth = 4F;
        btnOpenFolder.Size = new Size(94, 29);
        btnOpenFolder.TabIndex = 1;
        btnOpenFolder.Text = "Open Folder";
        btnOpenFolder.UseVisualStyleBackColor = true;
        btnOpenFolder.Click += btnOpenFolder_Click;
        // 
        // tcPlugin
        // 
        tcPlugin.Controls.Add(tpPlugins);
        tcPlugin.Dock = DockStyle.Fill;
        tcPlugin.ItemSize = new Size(80, 24);
        tcPlugin.Location = new Point(0, 0);
        tcPlugin.Name = "tcPlugin";
        tcPlugin.Radius = new Padding(4);
        tcPlugin.SelectedIndex = 0;
        tcPlugin.Size = new Size(600, 368);
        tcPlugin.TabIndex = 1;
        // 
        // tpPlugins
        // 
        tpPlugins.BackColor = Color.White;
        tpPlugins.Controls.Add(dgvPlugin);
        tpPlugins.Location = new Point(4, 28);
        tpPlugins.Name = "tpPlugins";
        tpPlugins.Padding = new Padding(3);
        tpPlugins.Size = new Size(592, 336);
        tpPlugins.TabIndex = 1;
        tpPlugins.Text = "Plugins";
        // 
        // dgvPlugin
        // 
        dgvPlugin.AllowUserToAddRows = false;
        dgvPlugin.AllowUserToDeleteRows = false;
        dgvPlugin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvPlugin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvPlugin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPlugin.Columns.AddRange(new DataGridViewColumn[] { ColEnabled, ColName, ColDescription, ColAuthor, ColVersion, FileName });
        dgvPlugin.Dock = DockStyle.Fill;
        dgvPlugin.Location = new Point(3, 3);
        dgvPlugin.Margin = new Padding(0);
        dgvPlugin.MultiSelect = false;
        dgvPlugin.Name = "dgvPlugin";
        dgvPlugin.RowHeadersVisible = false;
        dgvPlugin.RowHeadersWidth = 51;
        dgvPlugin.SelectionMode = DataGridViewSelectionMode.CellSelect;
        dgvPlugin.Size = new Size(586, 330);
        dgvPlugin.TabIndex = 0;
        // 
        // tbPluginLog
        // 
        tbPluginLog.Dock = DockStyle.Bottom;
        tbPluginLog.Location = new Point(0, 368);
        tbPluginLog.Name = "tbPluginLog";
        tbPluginLog.Size = new Size(600, 99);
        tbPluginLog.TabIndex = 0;
        tbPluginLog.Text = "";
        // 
        // ColEnabled
        // 
        ColEnabled.FillWeight = 12F;
        ColEnabled.HeaderText = "Enabled";
        ColEnabled.MinimumWidth = 6;
        ColEnabled.Name = "ColEnabled";
        // 
        // ColName
        // 
        ColName.FillWeight = 20F;
        ColName.HeaderText = "Name";
        ColName.MinimumWidth = 6;
        ColName.Name = "ColName";
        ColName.ReadOnly = true;
        // 
        // ColDescription
        // 
        ColDescription.FillWeight = 40F;
        ColDescription.HeaderText = "Description";
        ColDescription.MinimumWidth = 6;
        ColDescription.Name = "ColDescription";
        ColDescription.ReadOnly = true;
        // 
        // ColAuthor
        // 
        ColAuthor.FillWeight = 15F;
        ColAuthor.HeaderText = "Author";
        ColAuthor.MinimumWidth = 6;
        ColAuthor.Name = "ColAuthor";
        ColAuthor.ReadOnly = true;
        // 
        // ColVersion
        // 
        ColVersion.FillWeight = 15F;
        ColVersion.HeaderText = "Version";
        ColVersion.MinimumWidth = 6;
        ColVersion.Name = "ColVersion";
        ColVersion.ReadOnly = true;
        // 
        // FileName
        // 
        FileName.FillWeight = 1F;
        FileName.HeaderText = "FileName";
        FileName.MinimumWidth = 6;
        FileName.Name = "FileName";
        FileName.ReadOnly = true;
        FileName.Visible = false;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(mainPanel);
        Margin = new Padding(3, 4, 3, 4);
        Name = "Main";
        Size = new Size(600, 467);
        mainPanel.ResumeLayout(false);
        flowLayoutPanel1.ResumeLayout(false);
        tcPlugin.ResumeLayout(false);
        tpPlugins.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPlugin).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private SDUI.Controls.Panel mainPanel;
    private RichTextBox tbPluginLog;
    private SDUI.Controls.FlowLayoutPanel flowLayoutPanel1;
    private TabPage tpPlugins;
    public SDUI.Controls.TabControl tcPlugin;
    public SDUI.SK.Button btnReload;
    public SDUI.SK.Button btnOpenFolder;
    public DataGridView dgvPlugin;
    private DataGridViewCheckBoxColumn ColEnabled;
    private DataGridViewTextBoxColumn ColName;
    private DataGridViewTextBoxColumn ColDescription;
    private DataGridViewTextBoxColumn ColAuthor;
    private DataGridViewTextBoxColumn ColVersion;
    private DataGridViewTextBoxColumn FileName;
}