using System;
using System.Windows.Forms;

namespace RSBot.Map.Views
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label4 = new SDUI.Controls.Label();
            comboViewType = new SDUI.Controls.ComboBox();
            trmInterval = new Timer(components);
            lvMonster = new SDUI.Controls.ListView();
            colName = new ColumnHeader();
            colType = new ColumnHeader();
            colLevel = new ColumnHeader();
            colPosition = new ColumnHeader();
            checkBoxAutoSelectUniques = new SDUI.Controls.CheckBox();
            label3 = new SDUI.Controls.Label();
            timerUniqueChecker = new Timer(components);
            checkEnableCollisions = new SDUI.Controls.CheckBox();
            tabControl1 = new SDUI.Controls.TabControl();
            mapCanvas = new TabPage();
            tabNavMeshViewer = new TabPage();
            panelNavMeshRendererCanvas = new Panel();
            panel2 = new Panel();
            btnNvmResetToPlayer = new SDUI.Controls.Button();
            labelSectorInfo = new SDUI.Controls.Label();
            panel1 = new Panel();
            panel3 = new Panel();
            tabControl1.SuspendLayout();
            tabNavMeshViewer.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.ApplyGradient = false;
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label4.GradientAnimation = false;
            label4.Location = new System.Drawing.Point(18, 12);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 15);
            label4.TabIndex = 9;
            label4.Text = "Show:";
            // 
            // comboViewType
            // 
            comboViewType.DrawMode = DrawMode.OwnerDrawFixed;
            comboViewType.DropDownHeight = 100;
            comboViewType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboViewType.IntegralHeight = false;
            comboViewType.ItemHeight = 17;
            comboViewType.Items.AddRange(new object[] { "Monsters", "Players", "Party", "NPCs", "COS", "Portals", "All" });
            comboViewType.Location = new System.Drawing.Point(65, 11);
            comboViewType.Margin = new Padding(2, 2, 2, 2);
            comboViewType.Name = "comboViewType";
            comboViewType.Radius = 5;
            comboViewType.ShadowDepth = 4F;
            comboViewType.Size = new System.Drawing.Size(158, 23);
            comboViewType.TabIndex = 10;
            // 
            // trmInterval
            // 
            trmInterval.Enabled = true;
            trmInterval.Interval = 150;
            trmInterval.Tick += trmInterval_Tick;
            // 
            // lvMonster
            // 
            lvMonster.BackColor = System.Drawing.Color.White;
            lvMonster.Columns.AddRange(new ColumnHeader[] { colName, colType, colLevel, colPosition });
            lvMonster.Dock = DockStyle.Top;
            lvMonster.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lvMonster.FullRowSelect = true;
            lvMonster.Location = new System.Drawing.Point(0, 39);
            lvMonster.Margin = new Padding(2, 2, 2, 2);
            lvMonster.Name = "lvMonster";
            lvMonster.Size = new System.Drawing.Size(307, 234);
            lvMonster.TabIndex = 8;
            lvMonster.UseCompatibleStateImageBehavior = false;
            lvMonster.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            colName.Text = "Name";
            colName.Width = 130;
            // 
            // colType
            // 
            colType.Text = "Type";
            colType.Width = 64;
            // 
            // colLevel
            // 
            colLevel.Text = "Level";
            colLevel.Width = 50;
            // 
            // colPosition
            // 
            colPosition.Text = "Position";
            colPosition.Width = 120;
            // 
            // checkBoxAutoSelectUniques
            // 
            checkBoxAutoSelectUniques.AutoSize = true;
            checkBoxAutoSelectUniques.BackColor = System.Drawing.Color.Transparent;
            checkBoxAutoSelectUniques.Depth = 0;
            checkBoxAutoSelectUniques.Location = new System.Drawing.Point(18, 306);
            checkBoxAutoSelectUniques.Margin = new Padding(0);
            checkBoxAutoSelectUniques.MouseLocation = new System.Drawing.Point(-1, -1);
            checkBoxAutoSelectUniques.Name = "checkBoxAutoSelectUniques";
            checkBoxAutoSelectUniques.Ripple = true;
            checkBoxAutoSelectUniques.Size = new System.Drawing.Size(185, 30);
            checkBoxAutoSelectUniques.TabIndex = 17;
            checkBoxAutoSelectUniques.Text = "Automatically select uniques";
            checkBoxAutoSelectUniques.UseVisualStyleBackColor = false;
            checkBoxAutoSelectUniques.CheckedChanged += checkBoxAutoSelectUniques_CheckedChanged;
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(18, 333);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(245, 39);
            label3.TabIndex = 18;
            label3.Text = "This function does not work while the bot is active.\r\n If you want the bot to auto attack while active,\r\n set Avoidance.";
            // 
            // timerUniqueChecker
            // 
            timerUniqueChecker.Enabled = true;
            timerUniqueChecker.Interval = 700;
            timerUniqueChecker.Tick += timerUniqueChecker_Tick;
            // 
            // checkEnableCollisions
            // 
            checkEnableCollisions.AutoSize = true;
            checkEnableCollisions.BackColor = System.Drawing.Color.Transparent;
            checkEnableCollisions.Depth = 0;
            checkEnableCollisions.Location = new System.Drawing.Point(18, 284);
            checkEnableCollisions.Margin = new Padding(0);
            checkEnableCollisions.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnableCollisions.Name = "checkEnableCollisions";
            checkEnableCollisions.Ripple = true;
            checkEnableCollisions.Size = new System.Drawing.Size(168, 30);
            checkEnableCollisions.TabIndex = 19;
            checkEnableCollisions.Text = "Enable collision detection";
            checkEnableCollisions.UseVisualStyleBackColor = false;
            checkEnableCollisions.CheckedChanged += checkEnableCollisions_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(mapCanvas);
            tabControl1.Controls.Add(tabNavMeshViewer);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new System.Drawing.Size(80, 24);
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new Padding(2, 2, 2, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.Radius = new Padding(4);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(293, 401);
            tabControl1.TabIndex = 20;
            // 
            // mapCanvas
            // 
            mapCanvas.BackColor = System.Drawing.Color.White;
            mapCanvas.Location = new System.Drawing.Point(4, 28);
            mapCanvas.Margin = new Padding(2, 2, 2, 2);
            mapCanvas.Name = "mapCanvas";
            mapCanvas.Padding = new Padding(2, 2, 2, 2);
            mapCanvas.Size = new System.Drawing.Size(285, 369);
            mapCanvas.TabIndex = 0;
            mapCanvas.Text = "Minimap";
            mapCanvas.Paint += tabMinimap_Paint;
            mapCanvas.MouseClick += mapCanvas_MouseClick;
            // 
            // tabNavMeshViewer
            // 
            tabNavMeshViewer.BackColor = System.Drawing.Color.White;
            tabNavMeshViewer.Controls.Add(panelNavMeshRendererCanvas);
            tabNavMeshViewer.Controls.Add(panel2);
            tabNavMeshViewer.Location = new System.Drawing.Point(4, 28);
            tabNavMeshViewer.Margin = new Padding(2, 2, 2, 2);
            tabNavMeshViewer.Name = "tabNavMeshViewer";
            tabNavMeshViewer.Padding = new Padding(2, 2, 2, 2);
            tabNavMeshViewer.Size = new System.Drawing.Size(285, 369);
            tabNavMeshViewer.TabIndex = 1;
            tabNavMeshViewer.Text = "NavMesh Viewer";
            // 
            // panelNavMeshRendererCanvas
            // 
            panelNavMeshRendererCanvas.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            panelNavMeshRendererCanvas.BorderStyle = BorderStyle.FixedSingle;
            panelNavMeshRendererCanvas.Dock = DockStyle.Fill;
            panelNavMeshRendererCanvas.Location = new System.Drawing.Point(2, 2);
            panelNavMeshRendererCanvas.Margin = new Padding(2, 2, 2, 2);
            panelNavMeshRendererCanvas.Name = "panelNavMeshRendererCanvas";
            panelNavMeshRendererCanvas.Size = new System.Drawing.Size(281, 336);
            panelNavMeshRendererCanvas.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel2.Controls.Add(btnNvmResetToPlayer);
            panel2.Controls.Add(labelSectorInfo);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(2, 338);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(281, 29);
            panel2.TabIndex = 17;
            // 
            // btnNvmResetToPlayer
            // 
            btnNvmResetToPlayer.Color = System.Drawing.Color.Transparent;
            btnNvmResetToPlayer.Location = new System.Drawing.Point(11, 6);
            btnNvmResetToPlayer.Margin = new Padding(2, 2, 2, 2);
            btnNvmResetToPlayer.Name = "btnNvmResetToPlayer";
            btnNvmResetToPlayer.Radius = 6;
            btnNvmResetToPlayer.ShadowDepth = 4F;
            btnNvmResetToPlayer.Size = new System.Drawing.Size(98, 18);
            btnNvmResetToPlayer.TabIndex = 16;
            btnNvmResetToPlayer.Text = "Reset to player";
            btnNvmResetToPlayer.UseVisualStyleBackColor = true;
            btnNvmResetToPlayer.Click += btnNvmResetToPlayer_Click;
            // 
            // labelSectorInfo
            // 
            labelSectorInfo.ApplyGradient = false;
            labelSectorInfo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelSectorInfo.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelSectorInfo.GradientAnimation = false;
            labelSectorInfo.Location = new System.Drawing.Point(495, 8);
            labelSectorInfo.Margin = new Padding(2, 0, 2, 0);
            labelSectorInfo.Name = "labelSectorInfo";
            labelSectorInfo.Size = new System.Drawing.Size(102, 14);
            labelSectorInfo.TabIndex = 15;
            labelSectorInfo.Text = "000x000";
            labelSectorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Controls.Add(lvMonster);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(checkEnableCollisions);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(checkBoxAutoSelectUniques);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new System.Drawing.Point(293, 0);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(307, 401);
            panel1.TabIndex = 21;
            // 
            // panel3
            // 
            panel3.Controls.Add(comboViewType);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Margin = new Padding(2, 2, 2, 2);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(307, 39);
            panel3.TabIndex = 20;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Main";
            Size = new System.Drawing.Size(600, 401);
            Load += Main_Load;
            tabControl1.ResumeLayout(false);
            tabNavMeshViewer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private SDUI.Controls.ListView lvMonster;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colLevel;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.ComboBox comboViewType;
        private System.Windows.Forms.ColumnHeader colPosition;
        private System.Windows.Forms.Timer trmInterval;
        private SDUI.Controls.CheckBox checkBoxAutoSelectUniques;
        private SDUI.Controls.Label label3;
        private System.Windows.Forms.Timer timerUniqueChecker;
        private SDUI.Controls.CheckBox checkEnableCollisions;
        private SDUI.Controls.TabControl tabControl1;
        private System.Windows.Forms.TabPage mapCanvas;
        private System.Windows.Forms.TabPage tabNavMeshViewer;
        private System.Windows.Forms.Panel panelNavMeshRendererCanvas;
        private SDUI.Controls.Label labelSectorInfo;
        private SDUI.Controls.Button btnNvmResetToPlayer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
