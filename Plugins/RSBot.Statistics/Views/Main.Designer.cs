namespace RSBot.Statistics.Views
{
    partial class Main
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Player", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Loot", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Enemy", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Bot", System.Windows.Forms.HorizontalAlignment.Left);
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panelStaticFilters = new SDUI.Controls.GroupBox();
            separator1 = new SDUI.Controls.Separator();
            panelLiveFilters = new SDUI.Controls.GroupBox();
            lvStatistics = new SDUI.Controls.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip = new SDUI.Controls.ContextMenuStrip();
            resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new SDUI.Controls.Panel();
            btnReset = new SDUI.Controls.Button();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelStaticFilters);
            splitContainer1.Panel1.Controls.Add(separator1);
            splitContainer1.Panel1.Controls.Add(panelLiveFilters);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lvStatistics);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            splitContainer1.Size = new System.Drawing.Size(762, 506);
            splitContainer1.SplitterDistance = 255;
            splitContainer1.TabIndex = 0;
            // 
            // panelStaticFilters
            // 
            panelStaticFilters.BackColor = System.Drawing.Color.Transparent;
            panelStaticFilters.Dock = System.Windows.Forms.DockStyle.Top;
            panelStaticFilters.Location = new System.Drawing.Point(10, 212);
            panelStaticFilters.Name = "panelStaticFilters";
            panelStaticFilters.Padding = new System.Windows.Forms.Padding(8, 10, 3, 10);
            panelStaticFilters.Radius = 10;
            panelStaticFilters.ShadowDepth = 4;
            panelStaticFilters.Size = new System.Drawing.Size(235, 278);
            panelStaticFilters.TabIndex = 9;
            panelStaticFilters.TabStop = false;
            panelStaticFilters.Text = "Tracking";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Top;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(10, 200);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(235, 12);
            separator1.TabIndex = 10;
            separator1.Text = "separator1";
            // 
            // panelLiveFilters
            // 
            panelLiveFilters.BackColor = System.Drawing.Color.Transparent;
            panelLiveFilters.Dock = System.Windows.Forms.DockStyle.Top;
            panelLiveFilters.Location = new System.Drawing.Point(10, 10);
            panelLiveFilters.Name = "panelLiveFilters";
            panelLiveFilters.Padding = new System.Windows.Forms.Padding(8, 10, 3, 10);
            panelLiveFilters.Radius = 10;
            panelLiveFilters.ShadowDepth = 4;
            panelLiveFilters.Size = new System.Drawing.Size(235, 190);
            panelLiveFilters.TabIndex = 1;
            panelLiveFilters.TabStop = false;
            panelLiveFilters.Text = "Prognosis";
            // 
            // lvStatistics
            // 
            lvStatistics.BackColor = System.Drawing.Color.White;
            lvStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            lvStatistics.ContextMenuStrip = contextMenuStrip;
            lvStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            lvStatistics.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lvStatistics.FullRowSelect = true;
            listViewGroup1.Header = "Player";
            listViewGroup1.Name = "grpPlayer";
            listViewGroup2.Header = "Loot";
            listViewGroup2.Name = "grpLoot";
            listViewGroup3.Header = "Enemy";
            listViewGroup3.Name = "grpEnemy";
            listViewGroup4.Header = "Bot";
            listViewGroup4.Name = "grpBot";
            lvStatistics.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4 });
            lvStatistics.Location = new System.Drawing.Point(10, 10);
            lvStatistics.Name = "lvStatistics";
            lvStatistics.Size = new System.Drawing.Size(483, 451);
            lvStatistics.TabIndex = 0;
            lvStatistics.UseCompatibleStateImageBehavior = false;
            lvStatistics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 245;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Value";
            columnHeader2.Width = 228;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { resetToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(103, 26);
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(btnReset);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(10, 461);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(483, 35);
            panel1.TabIndex = 2;
            // 
            // btnReset
            // 
            btnReset.Color = System.Drawing.Color.Transparent;
            btnReset.Location = new System.Drawing.Point(401, 6);
            btnReset.Name = "btnReset";
            btnReset.Radius = 6;
            btnReset.ShadowDepth = 4F;
            btnReset.Size = new System.Drawing.Size(75, 23);
            btnReset.TabIndex = 0;
            btnReset.Text = "Reset ";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += RefreshTimer_Elapsed;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(splitContainer1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "Main";
            Size = new System.Drawing.Size(762, 506);
            Load += Main_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            contextMenuStrip.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private SDUI.Controls.ListView lvStatistics;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Button btnReset;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private SDUI.Controls.GroupBox panelLiveFilters;
        private SDUI.Controls.GroupBox panelStaticFilters;
        private SDUI.Controls.Separator separator1;
        private System.Windows.Forms.Timer timer;
        private SDUI.Controls.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
    }
}
