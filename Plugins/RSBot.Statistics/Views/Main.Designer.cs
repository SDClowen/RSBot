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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Player", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Loot", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Enemy", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Bot", System.Windows.Forms.HorizontalAlignment.Left);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelStaticFilters = new SDUI.Controls.GroupBox();
            this.separator1 = new SDUI.Controls.Separator();
            this.panelLiveFilters = new SDUI.Controls.GroupBox();
            this.lvStatistics = new SDUI.Controls.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new SDUI.Controls.Panel();
            this.btnReset = new SDUI.Controls.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelStaticFilters);
            this.splitContainer1.Panel1.Controls.Add(this.separator1);
            this.splitContainer1.Panel1.Controls.Add(this.panelLiveFilters);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvStatistics);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(762, 506);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelStaticFilters
            // 
            this.panelStaticFilters.BackColor = System.Drawing.Color.Transparent;
            this.panelStaticFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStaticFilters.Location = new System.Drawing.Point(10, 218);
            this.panelStaticFilters.Name = "panelStaticFilters";
            this.panelStaticFilters.Padding = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.panelStaticFilters.Radius = 2;
            this.panelStaticFilters.Size = new System.Drawing.Size(235, 278);
            this.panelStaticFilters.TabIndex = 9;
            this.panelStaticFilters.TabStop = false;
            this.panelStaticFilters.Text = "Tracking";
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(10, 200);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(235, 18);
            this.separator1.TabIndex = 10;
            this.separator1.Text = "separator1";
            // 
            // panelLiveFilters
            // 
            this.panelLiveFilters.BackColor = System.Drawing.Color.Transparent;
            this.panelLiveFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLiveFilters.Location = new System.Drawing.Point(10, 10);
            this.panelLiveFilters.Name = "panelLiveFilters";
            this.panelLiveFilters.Padding = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.panelLiveFilters.Radius = 2;
            this.panelLiveFilters.Size = new System.Drawing.Size(235, 190);
            this.panelLiveFilters.TabIndex = 1;
            this.panelLiveFilters.TabStop = false;
            this.panelLiveFilters.Text = "Prognosis";
            // 
            // lvStatistics
            // 
            this.lvStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStatistics.FullRowSelect = true;
            listViewGroup1.Header = "Player";
            listViewGroup1.Name = "grpPlayer";
            listViewGroup2.Header = "Loot";
            listViewGroup2.Name = "grpLoot";
            listViewGroup3.Header = "Enemy";
            listViewGroup3.Name = "grpEnemy";
            listViewGroup4.Header = "Bot";
            listViewGroup4.Name = "grpBot";
            this.lvStatistics.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.lvStatistics.Location = new System.Drawing.Point(10, 10);
            this.lvStatistics.Name = "lvStatistics";
            this.lvStatistics.Size = new System.Drawing.Size(483, 451);
            this.lvStatistics.TabIndex = 0;
            this.lvStatistics.UseCompatibleStateImageBehavior = false;
            this.lvStatistics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 245;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 228;
            // 
            // panel1
            // 
            this.panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 461);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(483, 35);
            this.panel1.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Color = System.Drawing.Color.Transparent;
            this.btnReset.Location = new System.Drawing.Point(401, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Radius = 1;
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset ";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.RefreshTimer_Elapsed);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(762, 506);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}
