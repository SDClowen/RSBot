using System;

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
            label4 = new System.Windows.Forms.Label();
            comboViewType = new System.Windows.Forms.ComboBox();
            trmInterval = new System.Windows.Forms.Timer(components);
            lvMonster = new System.Windows.Forms.ListView();
            colName = new System.Windows.Forms.ColumnHeader();
            colType = new System.Windows.Forms.ColumnHeader();
            colLevel = new System.Windows.Forms.ColumnHeader();
            colPosition = new System.Windows.Forms.ColumnHeader();
            checkBoxAutoSelectUniques = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            timerUniqueChecker = new System.Windows.Forms.Timer(components);
            checkEnableCollisions = new System.Windows.Forms.CheckBox();
            tabControl1 = new System.Windows.Forms.TabControl();
            mapCanvas = new System.Windows.Forms.TabPage();
            tabNavMeshViewer = new System.Windows.Forms.TabPage();
            panelNavMeshRendererCanvas = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            btnNvmResetToPlayer = new System.Windows.Forms.Button();
            labelSectorInfo = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            tabControl1.SuspendLayout();
            tabNavMeshViewer.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(33, 15);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(48, 20);
            label4.TabIndex = 9;
            label4.Text = "Show:";
            // 
            // comboViewType
            // 
            comboViewType.DropDownHeight = 100;
            comboViewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboViewType.IntegralHeight = false;
            comboViewType.ItemHeight = 20;
            comboViewType.Items.AddRange(new object[] { "Monsters", "Players", "Party", "NPCs", "COS", "Portals", "All" });
            comboViewType.Location = new System.Drawing.Point(87, 12);
            comboViewType.Name = "comboViewType";
            comboViewType.Size = new System.Drawing.Size(197, 28);
            comboViewType.TabIndex = 10;
            // 
            // trmInterval
            // 
            trmInterval.Enabled = true;
            trmInterval.Interval = 50;
            trmInterval.Tick += trmInterval_Tick;
            // 
            // lvMonster
            // 
            lvMonster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colName, colType, colLevel, colPosition });
            lvMonster.Dock = System.Windows.Forms.DockStyle.Top;
            lvMonster.FullRowSelect = true;
            lvMonster.Location = new System.Drawing.Point(0, 49);
            lvMonster.Name = "lvMonster";
            lvMonster.Size = new System.Drawing.Size(384, 343);
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
            colPosition.Width = 125;
            // 
            // checkBoxAutoSelectUniques
            // 
            checkBoxAutoSelectUniques.AutoSize = true;
            checkBoxAutoSelectUniques.Location = new System.Drawing.Point(22, 435);
            checkBoxAutoSelectUniques.Margin = new System.Windows.Forms.Padding(0);
            checkBoxAutoSelectUniques.Name = "checkBoxAutoSelectUniques";
            checkBoxAutoSelectUniques.Size = new System.Drawing.Size(220, 24);
            checkBoxAutoSelectUniques.TabIndex = 17;
            checkBoxAutoSelectUniques.Text = "Automatically select uniques";
            checkBoxAutoSelectUniques.UseVisualStyleBackColor = false;
            checkBoxAutoSelectUniques.CheckedChanged += checkBoxAutoSelectUniques_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic);
            label3.Location = new System.Drawing.Point(22, 468);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(325, 57);
            label3.TabIndex = 18;
            label3.Text = "This function does not work while the bot is active.\r\n If you want the bot to auto attack while active,\r\n set Avoidance.";
            // 
            // timerUniqueChecker
            // 
            timerUniqueChecker.Enabled = true;
            timerUniqueChecker.Interval = 2500;
            timerUniqueChecker.Tick += timerUniqueChecker_Tick;
            // 
            // checkEnableCollisions
            // 
            checkEnableCollisions.AutoSize = true;
            checkEnableCollisions.Checked = true;
            checkEnableCollisions.CheckState = System.Windows.Forms.CheckState.Checked;
            checkEnableCollisions.Location = new System.Drawing.Point(22, 407);
            checkEnableCollisions.Margin = new System.Windows.Forms.Padding(0);
            checkEnableCollisions.Name = "checkEnableCollisions";
            checkEnableCollisions.Size = new System.Drawing.Size(202, 24);
            checkEnableCollisions.TabIndex = 19;
            checkEnableCollisions.Text = "Enable collision detection";
            checkEnableCollisions.UseVisualStyleBackColor = false;
            checkEnableCollisions.CheckedChanged += checkEnableCollisions_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(mapCanvas);
            tabControl1.Controls.Add(tabNavMeshViewer);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.ItemSize = new System.Drawing.Size(80, 24);
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(527, 547);
            tabControl1.TabIndex = 20;
            // 
            // mapCanvas
            // 
            mapCanvas.Location = new System.Drawing.Point(4, 28);
            mapCanvas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            mapCanvas.Name = "mapCanvas";
            mapCanvas.Size = new System.Drawing.Size(519, 515);
            mapCanvas.TabIndex = 0;
            mapCanvas.Text = "Minimap";
            mapCanvas.Paint += tabMinimap_Paint;
            mapCanvas.MouseClick += mapCanvas_MouseClick;
            // 
            // tabNavMeshViewer
            // 
            tabNavMeshViewer.Controls.Add(panelNavMeshRendererCanvas);
            tabNavMeshViewer.Controls.Add(panel2);
            tabNavMeshViewer.Location = new System.Drawing.Point(4, 28);
            tabNavMeshViewer.Name = "tabNavMeshViewer";
            tabNavMeshViewer.Padding = new System.Windows.Forms.Padding(3);
            tabNavMeshViewer.Size = new System.Drawing.Size(519, 515);
            tabNavMeshViewer.TabIndex = 1;
            tabNavMeshViewer.Text = "NavMesh Viewer";
            // 
            // panelNavMeshRendererCanvas
            // 
            panelNavMeshRendererCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelNavMeshRendererCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            panelNavMeshRendererCanvas.Location = new System.Drawing.Point(3, 3);
            panelNavMeshRendererCanvas.Name = "panelNavMeshRendererCanvas";
            panelNavMeshRendererCanvas.Size = new System.Drawing.Size(513, 473);
            panelNavMeshRendererCanvas.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnNvmResetToPlayer);
            panel2.Controls.Add(labelSectorInfo);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(3, 476);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(513, 36);
            panel2.TabIndex = 17;
            // 
            // btnNvmResetToPlayer
            // 
            btnNvmResetToPlayer.AutoSize = true;
            btnNvmResetToPlayer.Location = new System.Drawing.Point(15, 3);
            btnNvmResetToPlayer.Name = "btnNvmResetToPlayer";
            btnNvmResetToPlayer.Size = new System.Drawing.Size(122, 30);
            btnNvmResetToPlayer.TabIndex = 16;
            btnNvmResetToPlayer.Text = "Reset to player";
            btnNvmResetToPlayer.UseVisualStyleBackColor = true;
            btnNvmResetToPlayer.Click += btnNvmResetToPlayer_Click;
            // 
            // labelSectorInfo
            // 
            labelSectorInfo.Location = new System.Drawing.Point(619, 10);
            labelSectorInfo.Name = "labelSectorInfo";
            labelSectorInfo.Size = new System.Drawing.Size(128, 17);
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
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(527, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(384, 547);
            panel1.TabIndex = 21;
            // 
            // panel3
            // 
            panel3.Controls.Add(comboViewType);
            panel3.Controls.Add(label4);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(384, 49);
            panel3.TabIndex = 20;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoSize = true;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "Main";
            Size = new System.Drawing.Size(911, 547);
            Load += Main_Load;
            tabControl1.ResumeLayout(false);
            tabNavMeshViewer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ListView lvMonster;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboViewType;
        private System.Windows.Forms.ColumnHeader colPosition;
        private System.Windows.Forms.Timer trmInterval;
        private System.Windows.Forms.CheckBox checkBoxAutoSelectUniques;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerUniqueChecker;
        private System.Windows.Forms.CheckBox checkEnableCollisions;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mapCanvas;
        private System.Windows.Forms.TabPage tabNavMeshViewer;
        private System.Windows.Forms.Panel panelNavMeshRendererCanvas;
        private System.Windows.Forms.Label labelSectorInfo;
        private System.Windows.Forms.Button btnNvmResetToPlayer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
