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
            label1 = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            lblX = new SDUI.Controls.Label();
            lblY = new SDUI.Controls.Label();
            lblRegion = new SDUI.Controls.Label();
            mapCanvas = new System.Windows.Forms.Panel();
            label4 = new SDUI.Controls.Label();
            comboViewType = new SDUI.Controls.ComboBox();
            trmInterval = new System.Windows.Forms.Timer(components);
            lvMonster = new SDUI.Controls.ListView();
            colName = new System.Windows.Forms.ColumnHeader();
            colType = new System.Windows.Forms.ColumnHeader();
            colLevel = new System.Windows.Forms.ColumnHeader();
            colPosition = new System.Windows.Forms.ColumnHeader();
            checkBoxAutoSelectUniques = new SDUI.Controls.CheckBox();
            label3 = new SDUI.Controls.Label();
            timerUniqueChecker = new System.Windows.Forms.Timer(components);
            checkEnableCollisions = new SDUI.Controls.CheckBox();
            tabControl1 = new SDUI.Controls.TabControl();
            tabMinimap = new System.Windows.Forms.TabPage();
            tabNavMeshViewer = new System.Windows.Forms.TabPage();
            btnNvmResetToPlayer = new SDUI.Controls.Button();
            labelSectorInfo = new SDUI.Controls.Label();
            panelNavMeshRendererCanvas = new System.Windows.Forms.Panel();
            tabControl1.SuspendLayout();
            tabMinimap.SuspendLayout();
            tabNavMeshViewer.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(21, 343);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 13);
            label1.TabIndex = 1;
            label1.Text = "X:";
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(92, 343);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(17, 13);
            label2.TabIndex = 2;
            label2.Text = "Y:";
            // 
            // lblX
            // 
            lblX.ApplyGradient = false;
            lblX.AutoSize = true;
            lblX.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblX.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblX.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            lblX.GradientAnimation = false;
            lblX.Location = new System.Drawing.Point(38, 343);
            lblX.Name = "lblX";
            lblX.Size = new System.Drawing.Size(13, 13);
            lblX.TabIndex = 4;
            lblX.Text = "0";
            // 
            // lblY
            // 
            lblY.ApplyGradient = false;
            lblY.AutoSize = true;
            lblY.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblY.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblY.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            lblY.GradientAnimation = false;
            lblY.Location = new System.Drawing.Point(115, 343);
            lblY.Name = "lblY";
            lblY.Size = new System.Drawing.Size(13, 13);
            lblY.TabIndex = 5;
            lblY.Text = "0";
            // 
            // lblRegion
            // 
            lblRegion.ApplyGradient = false;
            lblRegion.AutoSize = true;
            lblRegion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblRegion.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblRegion.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            lblRegion.GradientAnimation = false;
            lblRegion.Location = new System.Drawing.Point(21, 20);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new System.Drawing.Size(72, 13);
            lblRegion.TabIndex = 7;
            lblRegion.Text = "Not in game";
            // 
            // mapCanvas
            // 
            mapCanvas.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            mapCanvas.Location = new System.Drawing.Point(21, 40);
            mapCanvas.Name = "mapCanvas";
            mapCanvas.Size = new System.Drawing.Size(300, 300);
            mapCanvas.TabIndex = 0;
            mapCanvas.MouseClick += mapCanvas_MouseClick;
            // 
            // label4
            // 
            label4.ApplyGradient = false;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            label4.GradientAnimation = false;
            label4.Location = new System.Drawing.Point(398, 14);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 13);
            label4.TabIndex = 9;
            label4.Text = "Show:";
            // 
            // comboViewType
            // 
            comboViewType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboViewType.DropDownHeight = 100;
            comboViewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboViewType.IntegralHeight = false;
            comboViewType.ItemHeight = 17;
            comboViewType.Items.AddRange(new object[] { "Monsters", "Players", "Party", "NPCs", "COS", "Portals", "All" });
            comboViewType.Location = new System.Drawing.Point(456, 10);
            comboViewType.Name = "comboViewType";
            comboViewType.Radius = 5;
            comboViewType.ShadowDepth = 4F;
            comboViewType.Size = new System.Drawing.Size(180, 23);
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
            lvMonster.BackColor = System.Drawing.Color.White;
            lvMonster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colName, colType, colLevel, colPosition });
            lvMonster.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lvMonster.FullRowSelect = true;
            lvMonster.Location = new System.Drawing.Point(398, 39);
            lvMonster.Name = "lvMonster";
            lvMonster.Size = new System.Drawing.Size(327, 272);
            lvMonster.TabIndex = 8;
            lvMonster.UseCompatibleStateImageBehavior = false;
            lvMonster.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            colName.Text = "Name";
            colName.Width = 146;
            // 
            // colType
            // 
            colType.Text = "Type";
            colType.Width = 64;
            // 
            // colLevel
            // 
            colLevel.Text = "Level";
            colLevel.Width = 42;
            // 
            // colPosition
            // 
            colPosition.Text = "Position";
            colPosition.Width = 125;
            // 
            // checkBoxAutoSelectUniques
            // 
            checkBoxAutoSelectUniques.AutoSize = true;
            checkBoxAutoSelectUniques.BackColor = System.Drawing.Color.Transparent;
            checkBoxAutoSelectUniques.Depth = 0;
            checkBoxAutoSelectUniques.Location = new System.Drawing.Point(398, 342);
            checkBoxAutoSelectUniques.Margin = new System.Windows.Forms.Padding(0);
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
            label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(398, 375);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(245, 39);
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
            checkEnableCollisions.BackColor = System.Drawing.Color.Transparent;
            checkEnableCollisions.Checked = true;
            checkEnableCollisions.CheckState = System.Windows.Forms.CheckState.Checked;
            checkEnableCollisions.Depth = 0;
            checkEnableCollisions.Location = new System.Drawing.Point(398, 314);
            checkEnableCollisions.Margin = new System.Windows.Forms.Padding(0);
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
            tabControl1.Controls.Add(tabMinimap);
            tabControl1.Controls.Add(tabNavMeshViewer);
            tabControl1.ItemSize = new System.Drawing.Size(80, 24);
            tabControl1.Location = new System.Drawing.Point(6, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.Radius = new System.Windows.Forms.Padding(4);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(359, 450);
            tabControl1.TabIndex = 20;
            // 
            // tabMinimap
            // 
            tabMinimap.BackColor = System.Drawing.Color.White;
            tabMinimap.Controls.Add(lblRegion);
            tabMinimap.Controls.Add(lblY);
            tabMinimap.Controls.Add(label2);
            tabMinimap.Controls.Add(mapCanvas);
            tabMinimap.Controls.Add(lblX);
            tabMinimap.Controls.Add(label1);
            tabMinimap.Location = new System.Drawing.Point(4, 28);
            tabMinimap.Name = "tabMinimap";
            tabMinimap.Padding = new System.Windows.Forms.Padding(3);
            tabMinimap.Size = new System.Drawing.Size(351, 418);
            tabMinimap.TabIndex = 0;
            tabMinimap.Text = "Minimap";
            // 
            // tabNavMeshViewer
            // 
            tabNavMeshViewer.BackColor = System.Drawing.Color.White;
            tabNavMeshViewer.Controls.Add(btnNvmResetToPlayer);
            tabNavMeshViewer.Controls.Add(labelSectorInfo);
            tabNavMeshViewer.Controls.Add(panelNavMeshRendererCanvas);
            tabNavMeshViewer.Location = new System.Drawing.Point(4, 28);
            tabNavMeshViewer.Name = "tabNavMeshViewer";
            tabNavMeshViewer.Padding = new System.Windows.Forms.Padding(3);
            tabNavMeshViewer.Size = new System.Drawing.Size(351, 418);
            tabNavMeshViewer.TabIndex = 1;
            tabNavMeshViewer.Text = "NavMesh viewer";
            // 
            // btnNvmResetToPlayer
            // 
            btnNvmResetToPlayer.Color = System.Drawing.Color.Transparent;
            btnNvmResetToPlayer.Location = new System.Drawing.Point(114, 354);
            btnNvmResetToPlayer.Name = "btnNvmResetToPlayer";
            btnNvmResetToPlayer.Radius = 6;
            btnNvmResetToPlayer.ShadowDepth = 4F;
            btnNvmResetToPlayer.Size = new System.Drawing.Size(122, 23);
            btnNvmResetToPlayer.TabIndex = 16;
            btnNvmResetToPlayer.Text = "Reset to player";
            btnNvmResetToPlayer.UseVisualStyleBackColor = true;
            btnNvmResetToPlayer.Click += btnNvmResetToPlayer_Click;
            // 
            // labelSectorInfo
            // 
            labelSectorInfo.ApplyGradient = false;
            labelSectorInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelSectorInfo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelSectorInfo.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            labelSectorInfo.GradientAnimation = false;
            labelSectorInfo.Location = new System.Drawing.Point(220, 353);
            labelSectorInfo.Name = "labelSectorInfo";
            labelSectorInfo.Size = new System.Drawing.Size(128, 17);
            labelSectorInfo.TabIndex = 15;
            labelSectorInfo.Text = "000x000";
            labelSectorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelNavMeshRendererCanvas
            // 
            panelNavMeshRendererCanvas.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            panelNavMeshRendererCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelNavMeshRendererCanvas.Location = new System.Drawing.Point(0, 0);
            panelNavMeshRendererCanvas.Name = "panelNavMeshRendererCanvas";
            panelNavMeshRendererCanvas.Size = new System.Drawing.Size(350, 350);
            panelNavMeshRendererCanvas.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(checkEnableCollisions);
            Controls.Add(comboViewType);
            Controls.Add(checkBoxAutoSelectUniques);
            Controls.Add(label4);
            Controls.Add(tabControl1);
            Controls.Add(lvMonster);
            Controls.Add(label3);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "Main";
            Size = new System.Drawing.Size(750, 458);
            Load += Main_Load;
            tabControl1.ResumeLayout(false);
            tabMinimap.ResumeLayout(false);
            tabMinimap.PerformLayout();
            tabNavMeshViewer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel mapCanvas;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label lblX;
        private SDUI.Controls.Label lblY;
        private SDUI.Controls.Label lblRegion;
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
        private System.Windows.Forms.TabPage tabMinimap;
        private System.Windows.Forms.TabPage tabNavMeshViewer;
        private System.Windows.Forms.Panel panelNavMeshRendererCanvas;
        private SDUI.Controls.Label labelSectorInfo;
        private SDUI.Controls.Button btnNvmResetToPlayer;
    }
}
