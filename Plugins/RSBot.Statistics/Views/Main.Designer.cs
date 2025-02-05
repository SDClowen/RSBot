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
            panelStaticFilters = new System.Windows.Forms.GroupBox();
            separator1 = new System.Windows.Forms.Panel();
            panelLiveFilters = new System.Windows.Forms.GroupBox();
            lvStatistics = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new System.Windows.Forms.Panel();
            btnReset = new System.Windows.Forms.Button();
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
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelStaticFilters);
            splitContainer1.Panel1.Controls.Add(separator1);
            splitContainer1.Panel1.Controls.Add(panelLiveFilters);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lvStatistics);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            splitContainer1.Size = new System.Drawing.Size(952, 632);
            splitContainer1.SplitterDistance = 318;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // panelStaticFilters
            // 
            panelStaticFilters.Dock = System.Windows.Forms.DockStyle.Top;
            panelStaticFilters.Location = new System.Drawing.Point(12, 265);
            panelStaticFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelStaticFilters.Name = "panelStaticFilters";
            panelStaticFilters.Padding = new System.Windows.Forms.Padding(10, 12, 4, 12);
            panelStaticFilters.Size = new System.Drawing.Size(294, 348);
            panelStaticFilters.TabIndex = 9;
            panelStaticFilters.TabStop = false;
            panelStaticFilters.Text = "Tracking";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Top;
            separator1.Location = new System.Drawing.Point(12, 250);
            separator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(294, 15);
            separator1.TabIndex = 10;
            separator1.Text = "separator1";
            // 
            // panelLiveFilters
            // 
            panelLiveFilters.Dock = System.Windows.Forms.DockStyle.Top;
            panelLiveFilters.Location = new System.Drawing.Point(12, 12);
            panelLiveFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelLiveFilters.Name = "panelLiveFilters";
            panelLiveFilters.Padding = new System.Windows.Forms.Padding(10, 12, 4, 12);
            panelLiveFilters.Size = new System.Drawing.Size(294, 238);
            panelLiveFilters.TabIndex = 1;
            panelLiveFilters.TabStop = false;
            panelLiveFilters.Text = "Prognosis";
            // 
            // lvStatistics
            // 
            lvStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            lvStatistics.ContextMenuStrip = contextMenuStrip;
            lvStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
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
            lvStatistics.Location = new System.Drawing.Point(12, 12);
            lvStatistics.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            lvStatistics.Name = "lvStatistics";
            lvStatistics.Size = new System.Drawing.Size(605, 564);
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
            contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { resetToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(115, 28);
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReset);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(12, 576);
            panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(605, 44);
            panel1.TabIndex = 2;
            // 
            // btnReset
            // 
            btnReset.Location = new System.Drawing.Point(501, 8);
            btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(94, 29);
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
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(splitContainer1);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "Main";
            Size = new System.Drawing.Size(952, 632);
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
        private System.Windows.Forms.ListView lvStatistics;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox panelLiveFilters;
        private System.Windows.Forms.GroupBox panelStaticFilters;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
    }
}
