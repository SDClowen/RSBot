namespace RSBot.NavMeshVisualizer;

partial class NavMeshRenderer
{
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        contextMenuStrip1 = new ContextMenuStrip(components);
        displayToolStripMenuItem = new ToolStripMenuItem();
        regionIDToolStripMenuItem = new ToolStripMenuItem();
        regionBorderToolStripMenuItem = new ToolStripMenuItem();
        terrainToolStripMenuItem = new ToolStripMenuItem();
        terrainCellIDToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        terrainGlobalEdgesToolStripMenuItem = new ToolStripMenuItem();
        terrainGlobalEdgeIDToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        terrainInternalEdgesToolStripMenuItem = new ToolStripMenuItem();
        terrainInternalEdgeIDToolStripMenuItem = new ToolStripMenuItem();
        objectsToolStripMenuItem = new ToolStripMenuItem();
        objectCellIDToolStripMenuItem = new ToolStripMenuItem();
        objectGroundToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        objectGlobalEdgesToolStripMenuItem1 = new ToolStripMenuItem();
        objectGlobalEdgeIDToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator4 = new ToolStripSeparator();
        objectInternalEdgesToolStripMenuItem1 = new ToolStripMenuItem();
        objectInternalEdgeIDToolStripMenuItem = new ToolStripMenuItem();
        contextMenuStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] { displayToolStripMenuItem });
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(181, 48);
        // 
        // displayToolStripMenuItem
        // 
        displayToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { regionIDToolStripMenuItem, regionBorderToolStripMenuItem, terrainToolStripMenuItem, objectsToolStripMenuItem });
        displayToolStripMenuItem.Name = "displayToolStripMenuItem";
        displayToolStripMenuItem.Size = new Size(180, 22);
        displayToolStripMenuItem.Text = "&Display";
        // 
        // regionIDToolStripMenuItem
        // 
        regionIDToolStripMenuItem.Checked = true;
        regionIDToolStripMenuItem.CheckOnClick = true;
        regionIDToolStripMenuItem.CheckState = CheckState.Checked;
        regionIDToolStripMenuItem.Name = "regionIDToolStripMenuItem";
        regionIDToolStripMenuItem.Size = new Size(180, 22);
        regionIDToolStripMenuItem.Text = "RegionID";
        regionIDToolStripMenuItem.CheckedChanged += this.regionIDToolStripMenuItem_CheckedChange;
        // 
        // regionBorderToolStripMenuItem
        // 
        regionBorderToolStripMenuItem.Checked = true;
        regionBorderToolStripMenuItem.CheckOnClick = true;
        regionBorderToolStripMenuItem.CheckState = CheckState.Checked;
        regionBorderToolStripMenuItem.Name = "regionBorderToolStripMenuItem";
        regionBorderToolStripMenuItem.Size = new Size(180, 22);
        regionBorderToolStripMenuItem.Text = "RegionBorder";
        regionBorderToolStripMenuItem.CheckedChanged += this.regionBorderToolStripMenuItem_CheckedChange;
        // 
        // terrainToolStripMenuItem
        // 
        terrainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { terrainCellIDToolStripMenuItem, toolStripSeparator1, terrainGlobalEdgesToolStripMenuItem, terrainGlobalEdgeIDToolStripMenuItem, toolStripSeparator2, terrainInternalEdgesToolStripMenuItem, terrainInternalEdgeIDToolStripMenuItem });
        terrainToolStripMenuItem.Name = "terrainToolStripMenuItem";
        terrainToolStripMenuItem.Size = new Size(180, 22);
        terrainToolStripMenuItem.Text = "Terrain";
        // 
        // terrainCellIDToolStripMenuItem
        // 
        terrainCellIDToolStripMenuItem.CheckOnClick = true;
        terrainCellIDToolStripMenuItem.Name = "terrainCellIDToolStripMenuItem";
        terrainCellIDToolStripMenuItem.Size = new Size(180, 22);
        terrainCellIDToolStripMenuItem.Text = "&CellID";
        terrainCellIDToolStripMenuItem.Click += this.terrainCellIDToolStripMenuItem_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(177, 6);
        // 
        // terrainGlobalEdgesToolStripMenuItem
        // 
        terrainGlobalEdgesToolStripMenuItem.Checked = true;
        terrainGlobalEdgesToolStripMenuItem.CheckOnClick = true;
        terrainGlobalEdgesToolStripMenuItem.CheckState = CheckState.Checked;
        terrainGlobalEdgesToolStripMenuItem.Name = "terrainGlobalEdgesToolStripMenuItem";
        terrainGlobalEdgesToolStripMenuItem.Size = new Size(180, 22);
        terrainGlobalEdgesToolStripMenuItem.Text = "&GlobalEdges";
        terrainGlobalEdgesToolStripMenuItem.CheckedChanged += this.globalEdgesToolStripMenuItem_CheckedChanged;
        // 
        // terrainGlobalEdgeIDToolStripMenuItem
        // 
        terrainGlobalEdgeIDToolStripMenuItem.CheckOnClick = true;
        terrainGlobalEdgeIDToolStripMenuItem.Name = "terrainGlobalEdgeIDToolStripMenuItem";
        terrainGlobalEdgeIDToolStripMenuItem.Size = new Size(180, 22);
        terrainGlobalEdgeIDToolStripMenuItem.Text = "&GlobalEdgeID";
        terrainGlobalEdgeIDToolStripMenuItem.Click += this.terrainGlobalEdgeIDToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(177, 6);
        // 
        // terrainInternalEdgesToolStripMenuItem
        // 
        terrainInternalEdgesToolStripMenuItem.Checked = true;
        terrainInternalEdgesToolStripMenuItem.CheckOnClick = true;
        terrainInternalEdgesToolStripMenuItem.CheckState = CheckState.Checked;
        terrainInternalEdgesToolStripMenuItem.Name = "terrainInternalEdgesToolStripMenuItem";
        terrainInternalEdgesToolStripMenuItem.Size = new Size(180, 22);
        terrainInternalEdgesToolStripMenuItem.Text = "&InternalEdges";
        terrainInternalEdgesToolStripMenuItem.CheckedChanged += this.internalEdgesToolStripMenuItem_CheckedChanged;
        // 
        // terrainInternalEdgeIDToolStripMenuItem
        // 
        terrainInternalEdgeIDToolStripMenuItem.CheckOnClick = true;
        terrainInternalEdgeIDToolStripMenuItem.Name = "terrainInternalEdgeIDToolStripMenuItem";
        terrainInternalEdgeIDToolStripMenuItem.Size = new Size(180, 22);
        terrainInternalEdgeIDToolStripMenuItem.Text = "&InternalEdgeID";
        terrainInternalEdgeIDToolStripMenuItem.Click += this.terrainInternalEdgeIDToolStripMenuItem_Click;
        // 
        // objectsToolStripMenuItem
        // 
        objectsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { objectCellIDToolStripMenuItem, objectGroundToolStripMenuItem, toolStripSeparator3, objectGlobalEdgesToolStripMenuItem1, objectGlobalEdgeIDToolStripMenuItem, toolStripSeparator4, objectInternalEdgesToolStripMenuItem1, objectInternalEdgeIDToolStripMenuItem });
        objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
        objectsToolStripMenuItem.Size = new Size(180, 22);
        objectsToolStripMenuItem.Text = "Objects";
        // 
        // objectCellIDToolStripMenuItem
        // 
        objectCellIDToolStripMenuItem.CheckOnClick = true;
        objectCellIDToolStripMenuItem.Name = "objectCellIDToolStripMenuItem";
        objectCellIDToolStripMenuItem.Size = new Size(180, 22);
        objectCellIDToolStripMenuItem.Text = "&CellID";
        objectCellIDToolStripMenuItem.Click += this.objectCellIDToolStripMenuItem_Click;
        // 
        // objectGroundToolStripMenuItem
        // 
        objectGroundToolStripMenuItem.Checked = true;
        objectGroundToolStripMenuItem.CheckOnClick = true;
        objectGroundToolStripMenuItem.CheckState = CheckState.Checked;
        objectGroundToolStripMenuItem.Name = "objectGroundToolStripMenuItem";
        objectGroundToolStripMenuItem.Size = new Size(180, 22);
        objectGroundToolStripMenuItem.Text = "&Ground";
        objectGroundToolStripMenuItem.CheckedChanged += this.groundToolStripMenuItem_CheckedChanged;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(177, 6);
        // 
        // objectGlobalEdgesToolStripMenuItem1
        // 
        objectGlobalEdgesToolStripMenuItem1.Checked = true;
        objectGlobalEdgesToolStripMenuItem1.CheckOnClick = true;
        objectGlobalEdgesToolStripMenuItem1.CheckState = CheckState.Checked;
        objectGlobalEdgesToolStripMenuItem1.Name = "objectGlobalEdgesToolStripMenuItem1";
        objectGlobalEdgesToolStripMenuItem1.Size = new Size(180, 22);
        objectGlobalEdgesToolStripMenuItem1.Text = "&GlobalEdges";
        objectGlobalEdgesToolStripMenuItem1.CheckedChanged += this.globalEdgesToolStripMenuItem1_CheckedChanged;
        // 
        // objectGlobalEdgeIDToolStripMenuItem
        // 
        objectGlobalEdgeIDToolStripMenuItem.CheckOnClick = true;
        objectGlobalEdgeIDToolStripMenuItem.Name = "objectGlobalEdgeIDToolStripMenuItem";
        objectGlobalEdgeIDToolStripMenuItem.Size = new Size(180, 22);
        objectGlobalEdgeIDToolStripMenuItem.Text = "&GlobalEdgeID";
        objectGlobalEdgeIDToolStripMenuItem.Click += this.objectGlobalEdgeIDToolStripMenuItem_Click;
        // 
        // toolStripSeparator4
        // 
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new Size(177, 6);
        // 
        // objectInternalEdgesToolStripMenuItem1
        // 
        objectInternalEdgesToolStripMenuItem1.Checked = true;
        objectInternalEdgesToolStripMenuItem1.CheckOnClick = true;
        objectInternalEdgesToolStripMenuItem1.CheckState = CheckState.Checked;
        objectInternalEdgesToolStripMenuItem1.Name = "objectInternalEdgesToolStripMenuItem1";
        objectInternalEdgesToolStripMenuItem1.Size = new Size(180, 22);
        objectInternalEdgesToolStripMenuItem1.Text = "&InternalEdges";
        objectInternalEdgesToolStripMenuItem1.CheckedChanged += this.internalEdgesToolStripMenuItem1_CheckedChanged;
        // 
        // objectInternalEdgeIDToolStripMenuItem
        // 
        objectInternalEdgeIDToolStripMenuItem.CheckOnClick = true;
        objectInternalEdgeIDToolStripMenuItem.Name = "objectInternalEdgeIDToolStripMenuItem";
        objectInternalEdgeIDToolStripMenuItem.Size = new Size(180, 22);
        objectInternalEdgeIDToolStripMenuItem.Text = "&InternalEdgeID";
        objectInternalEdgeIDToolStripMenuItem.Click += this.objectInternalEdgeIDToolStripMenuItem_Click;
        // 
        // NavMeshRenderer
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.CornflowerBlue;
        this.ContextMenuStrip = contextMenuStrip1;
        this.DoubleBuffered = true;
        this.Name = "NavMeshRenderer";
        this.Size = new Size(256, 256);
        contextMenuStrip1.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem displayToolStripMenuItem;
    private ToolStripMenuItem regionIDToolStripMenuItem;
    private ToolStripMenuItem regionBorderToolStripMenuItem;
    private ToolStripMenuItem terrainToolStripMenuItem;
    private ToolStripMenuItem terrainGlobalEdgesToolStripMenuItem;
    private ToolStripMenuItem terrainInternalEdgesToolStripMenuItem;
    private ToolStripMenuItem objectsToolStripMenuItem;
    private ToolStripMenuItem objectGlobalEdgesToolStripMenuItem1;
    private ToolStripMenuItem objectInternalEdgesToolStripMenuItem1;
    private ToolStripMenuItem objectGroundToolStripMenuItem;
    private ToolStripMenuItem terrainCellIDToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem terrainGlobalEdgeIDToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem terrainInternalEdgeIDToolStripMenuItem;
    private ToolStripMenuItem objectCellIDToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem objectGlobalEdgeIDToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem objectInternalEdgeIDToolStripMenuItem;
}
