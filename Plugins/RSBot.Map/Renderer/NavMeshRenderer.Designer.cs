using System.Drawing;
using System.Windows.Forms;

namespace RSBot.Map.Renderer;

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
        contextRenderSettings = new ContextMenuStrip(components);
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
        raycastMenuItem = new ToolStripMenuItem();
        contextRenderSettings.SuspendLayout();
        SuspendLayout();
        // 
        // contextRenderSettings
        // 
        contextRenderSettings.Items.AddRange(new ToolStripItem[] { displayToolStripMenuItem, raycastMenuItem });
        contextRenderSettings.Name = "contextMenuStrip1";
        contextRenderSettings.Size = new Size(194, 74);
        // 
        // displayToolStripMenuItem
        // 
        displayToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { regionIDToolStripMenuItem, regionBorderToolStripMenuItem, terrainToolStripMenuItem, objectsToolStripMenuItem });
        displayToolStripMenuItem.Name = "displayToolStripMenuItem";
        displayToolStripMenuItem.Size = new Size(193, 24);
        displayToolStripMenuItem.Text = "&Display";
        // 
        // regionIDToolStripMenuItem
        // 
        regionIDToolStripMenuItem.Checked = true;
        regionIDToolStripMenuItem.CheckOnClick = true;
        regionIDToolStripMenuItem.CheckState = CheckState.Checked;
        regionIDToolStripMenuItem.Name = "regionIDToolStripMenuItem";
        regionIDToolStripMenuItem.Size = new Size(170, 24);
        regionIDToolStripMenuItem.Text = "RegionID";
        regionIDToolStripMenuItem.CheckedChanged += regionIDToolStripMenuItem_CheckedChange;
        // 
        // regionBorderToolStripMenuItem
        // 
        regionBorderToolStripMenuItem.Checked = true;
        regionBorderToolStripMenuItem.CheckOnClick = true;
        regionBorderToolStripMenuItem.CheckState = CheckState.Checked;
        regionBorderToolStripMenuItem.Name = "regionBorderToolStripMenuItem";
        regionBorderToolStripMenuItem.Size = new Size(170, 24);
        regionBorderToolStripMenuItem.Text = "RegionBorder";
        regionBorderToolStripMenuItem.CheckedChanged += regionBorderToolStripMenuItem_CheckedChange;
        // 
        // terrainToolStripMenuItem
        // 
        terrainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { terrainCellIDToolStripMenuItem, toolStripSeparator1, terrainGlobalEdgesToolStripMenuItem, terrainGlobalEdgeIDToolStripMenuItem, toolStripSeparator2, terrainInternalEdgesToolStripMenuItem, terrainInternalEdgeIDToolStripMenuItem });
        terrainToolStripMenuItem.Name = "terrainToolStripMenuItem";
        terrainToolStripMenuItem.Size = new Size(170, 24);
        terrainToolStripMenuItem.Text = "Terrain";
        // 
        // terrainCellIDToolStripMenuItem
        // 
        terrainCellIDToolStripMenuItem.CheckOnClick = true;
        terrainCellIDToolStripMenuItem.Name = "terrainCellIDToolStripMenuItem";
        terrainCellIDToolStripMenuItem.Size = new Size(177, 24);
        terrainCellIDToolStripMenuItem.Text = "&CellID";
        terrainCellIDToolStripMenuItem.Click += terrainCellIDToolStripMenuItem_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(174, 6);
        // 
        // terrainGlobalEdgesToolStripMenuItem
        // 
        terrainGlobalEdgesToolStripMenuItem.Checked = true;
        terrainGlobalEdgesToolStripMenuItem.CheckOnClick = true;
        terrainGlobalEdgesToolStripMenuItem.CheckState = CheckState.Checked;
        terrainGlobalEdgesToolStripMenuItem.Name = "terrainGlobalEdgesToolStripMenuItem";
        terrainGlobalEdgesToolStripMenuItem.Size = new Size(177, 24);
        terrainGlobalEdgesToolStripMenuItem.Text = "&GlobalEdges";
        terrainGlobalEdgesToolStripMenuItem.CheckedChanged += globalEdgesToolStripMenuItem_CheckedChanged;
        // 
        // terrainGlobalEdgeIDToolStripMenuItem
        // 
        terrainGlobalEdgeIDToolStripMenuItem.CheckOnClick = true;
        terrainGlobalEdgeIDToolStripMenuItem.Name = "terrainGlobalEdgeIDToolStripMenuItem";
        terrainGlobalEdgeIDToolStripMenuItem.Size = new Size(177, 24);
        terrainGlobalEdgeIDToolStripMenuItem.Text = "&GlobalEdgeID";
        terrainGlobalEdgeIDToolStripMenuItem.Click += terrainGlobalEdgeIDToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(174, 6);
        // 
        // terrainInternalEdgesToolStripMenuItem
        // 
        terrainInternalEdgesToolStripMenuItem.Checked = true;
        terrainInternalEdgesToolStripMenuItem.CheckOnClick = true;
        terrainInternalEdgesToolStripMenuItem.CheckState = CheckState.Checked;
        terrainInternalEdgesToolStripMenuItem.Name = "terrainInternalEdgesToolStripMenuItem";
        terrainInternalEdgesToolStripMenuItem.Size = new Size(177, 24);
        terrainInternalEdgesToolStripMenuItem.Text = "&InternalEdges";
        terrainInternalEdgesToolStripMenuItem.CheckedChanged += internalEdgesToolStripMenuItem_CheckedChanged;
        // 
        // terrainInternalEdgeIDToolStripMenuItem
        // 
        terrainInternalEdgeIDToolStripMenuItem.CheckOnClick = true;
        terrainInternalEdgeIDToolStripMenuItem.Name = "terrainInternalEdgeIDToolStripMenuItem";
        terrainInternalEdgeIDToolStripMenuItem.Size = new Size(177, 24);
        terrainInternalEdgeIDToolStripMenuItem.Text = "&InternalEdgeID";
        terrainInternalEdgeIDToolStripMenuItem.Click += terrainInternalEdgeIDToolStripMenuItem_Click;
        // 
        // objectsToolStripMenuItem
        // 
        objectsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { objectCellIDToolStripMenuItem, objectGroundToolStripMenuItem, toolStripSeparator3, objectGlobalEdgesToolStripMenuItem1, objectGlobalEdgeIDToolStripMenuItem, toolStripSeparator4, objectInternalEdgesToolStripMenuItem1, objectInternalEdgeIDToolStripMenuItem });
        objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
        objectsToolStripMenuItem.Size = new Size(170, 24);
        objectsToolStripMenuItem.Text = "Objects";
        // 
        // objectCellIDToolStripMenuItem
        // 
        objectCellIDToolStripMenuItem.CheckOnClick = true;
        objectCellIDToolStripMenuItem.Name = "objectCellIDToolStripMenuItem";
        objectCellIDToolStripMenuItem.Size = new Size(177, 24);
        objectCellIDToolStripMenuItem.Text = "&CellID";
        objectCellIDToolStripMenuItem.Click += objectCellIDToolStripMenuItem_Click;
        // 
        // objectGroundToolStripMenuItem
        // 
        objectGroundToolStripMenuItem.Checked = true;
        objectGroundToolStripMenuItem.CheckOnClick = true;
        objectGroundToolStripMenuItem.CheckState = CheckState.Checked;
        objectGroundToolStripMenuItem.Name = "objectGroundToolStripMenuItem";
        objectGroundToolStripMenuItem.Size = new Size(177, 24);
        objectGroundToolStripMenuItem.Text = "&Ground";
        objectGroundToolStripMenuItem.CheckedChanged += groundToolStripMenuItem_CheckedChanged;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(174, 6);
        // 
        // objectGlobalEdgesToolStripMenuItem1
        // 
        objectGlobalEdgesToolStripMenuItem1.Checked = true;
        objectGlobalEdgesToolStripMenuItem1.CheckOnClick = true;
        objectGlobalEdgesToolStripMenuItem1.CheckState = CheckState.Checked;
        objectGlobalEdgesToolStripMenuItem1.Name = "objectGlobalEdgesToolStripMenuItem1";
        objectGlobalEdgesToolStripMenuItem1.Size = new Size(177, 24);
        objectGlobalEdgesToolStripMenuItem1.Text = "&GlobalEdges";
        objectGlobalEdgesToolStripMenuItem1.CheckedChanged += globalEdgesToolStripMenuItem1_CheckedChanged;
        // 
        // objectGlobalEdgeIDToolStripMenuItem
        // 
        objectGlobalEdgeIDToolStripMenuItem.CheckOnClick = true;
        objectGlobalEdgeIDToolStripMenuItem.Name = "objectGlobalEdgeIDToolStripMenuItem";
        objectGlobalEdgeIDToolStripMenuItem.Size = new Size(177, 24);
        objectGlobalEdgeIDToolStripMenuItem.Text = "&GlobalEdgeID";
        objectGlobalEdgeIDToolStripMenuItem.Click += objectGlobalEdgeIDToolStripMenuItem_Click;
        // 
        // toolStripSeparator4
        // 
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new Size(174, 6);
        // 
        // objectInternalEdgesToolStripMenuItem1
        // 
        objectInternalEdgesToolStripMenuItem1.Checked = true;
        objectInternalEdgesToolStripMenuItem1.CheckOnClick = true;
        objectInternalEdgesToolStripMenuItem1.CheckState = CheckState.Checked;
        objectInternalEdgesToolStripMenuItem1.Name = "objectInternalEdgesToolStripMenuItem1";
        objectInternalEdgesToolStripMenuItem1.Size = new Size(177, 24);
        objectInternalEdgesToolStripMenuItem1.Text = "&InternalEdges";
        objectInternalEdgesToolStripMenuItem1.CheckedChanged += internalEdgesToolStripMenuItem1_CheckedChanged;
        // 
        // objectInternalEdgeIDToolStripMenuItem
        // 
        objectInternalEdgeIDToolStripMenuItem.CheckOnClick = true;
        objectInternalEdgeIDToolStripMenuItem.Name = "objectInternalEdgeIDToolStripMenuItem";
        objectInternalEdgeIDToolStripMenuItem.Size = new Size(177, 24);
        objectInternalEdgeIDToolStripMenuItem.Text = "&InternalEdgeID";
        objectInternalEdgeIDToolStripMenuItem.Click += objectInternalEdgeIDToolStripMenuItem_Click;
        // 
        // raycastMenuItem
        // 
        raycastMenuItem.CheckOnClick = true;
        raycastMenuItem.Name = "raycastMenuItem";
        raycastMenuItem.Size = new Size(193, 24);
        raycastMenuItem.Text = "Raycast visualizer";
        raycastMenuItem.CheckedChanged += raycastMenuItem_CheckedChanged;
        // 
        // NavMeshRenderer
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.MidnightBlue;
        ContextMenuStrip = contextRenderSettings;
        DoubleBuffered = true;
        Margin = new Padding(3, 4, 3, 4);
        Name = "NavMeshRenderer";
        Size = new Size(293, 341);
        contextRenderSettings.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ContextMenuStrip contextRenderSettings;
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
    private ToolStripMenuItem raycastMenuItem;
}
