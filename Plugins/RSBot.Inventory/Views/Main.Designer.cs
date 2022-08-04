namespace RSBot.Inventory.Views
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
            this.label2 = new SDUI.Controls.Label();
            this.lblFreeSlots = new SDUI.Controls.Label();
            this.listViewMain = new SDUI.Controls.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colGenderRace = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new SDUI.Controls.ContextMenuStrip();
            this.useToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToPetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afterTrainingPlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beforeTrainingPlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatAfterFinishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToLastDeathPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToLastRecallPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectMapLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new SDUI.Controls.Panel();
            this.buttonInventory = new SDUI.Controls.Button();
            this.buttonEquipment = new SDUI.Controls.Button();
            this.buttonAvatars = new SDUI.Controls.Button();
            this.buttonGrabpet = new SDUI.Controls.Button();
            this.topPanel = new SDUI.Controls.Panel();
            this.buttonSpecialty = new SDUI.Controls.Button();
            this.buttonGuildStorage = new SDUI.Controls.Button();
            this.buttonFellowPet = new SDUI.Controls.Button();
            this.buttonJobTransport = new SDUI.Controls.Button();
            this.buttonStorage = new SDUI.Controls.Button();
            this.buttonJobEquipment = new SDUI.Controls.Button();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Free Slots:";
            // 
            // lblFreeSlots
            // 
            this.lblFreeSlots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFreeSlots.AutoSize = true;
            this.lblFreeSlots.BackColor = System.Drawing.Color.Transparent;
            this.lblFreeSlots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFreeSlots.Location = new System.Drawing.Point(86, 7);
            this.lblFreeSlots.Name = "lblFreeSlots";
            this.lblFreeSlots.Size = new System.Drawing.Size(13, 15);
            this.lblFreeSlots.TabIndex = 4;
            this.lblFreeSlots.Text = "0";
            // 
            // listViewMain
            // 
            this.listViewMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAmount,
            this.colGenderRace});
            this.listViewMain.ContextMenuStrip = this.contextMenuStrip;
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMain.Location = new System.Drawing.Point(0, 38);
            this.listViewMain.MultiSelect = false;
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(792, 393);
            this.listViewMain.TabIndex = 2;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            this.listViewMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMain_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 381;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 62;
            // 
            // colGenderRace
            // 
            this.colGenderRace.Text = "Rarity";
            this.colGenderRace.Width = 153;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useToolStripMenuItem,
            this.dropToolStripMenuItem,
            this.moveToPetToolStripMenuItem,
            this.moveToPlayerToolStripMenuItem,
            this.conditionsToolStripMenuItem,
            this.moveToLastDeathPositionToolStripMenuItem,
            this.moveToLastRecallPositionToolStripMenuItem,
            this.selectMapLocationToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(220, 202);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // useToolStripMenuItem
            // 
            this.useToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.useToolStripMenuItem.Name = "useToolStripMenuItem";
            this.useToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.useToolStripMenuItem.Text = "Use";
            this.useToolStripMenuItem.Click += new System.EventHandler(this.buttonUseItem_Click);
            // 
            // dropToolStripMenuItem
            // 
            this.dropToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dropToolStripMenuItem.Name = "dropToolStripMenuItem";
            this.dropToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.dropToolStripMenuItem.Text = "Drop";
            this.dropToolStripMenuItem.Click += new System.EventHandler(this.dropToolStripMenuItem_Click);
            // 
            // moveToPetToolStripMenuItem
            // 
            this.moveToPetToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.moveToPetToolStripMenuItem.Name = "moveToPetToolStripMenuItem";
            this.moveToPetToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.moveToPetToolStripMenuItem.Text = "Move to active pet";
            this.moveToPetToolStripMenuItem.Click += new System.EventHandler(this.moveToPetToolStripMenuItem_Click);
            // 
            // moveToPlayerToolStripMenuItem
            // 
            this.moveToPlayerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.moveToPlayerToolStripMenuItem.Name = "moveToPlayerToolStripMenuItem";
            this.moveToPlayerToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.moveToPlayerToolStripMenuItem.Text = "Move to player";
            this.moveToPlayerToolStripMenuItem.Click += new System.EventHandler(this.moveToPlayerToolStripMenuItem_Click);
            // 
            // conditionsToolStripMenuItem
            // 
            this.conditionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afterTrainingPlaceToolStripMenuItem,
            this.beforeTrainingPlaceToolStripMenuItem,
            this.repeatAfterFinishToolStripMenuItem});
            this.conditionsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.conditionsToolStripMenuItem.Name = "conditionsToolStripMenuItem";
            this.conditionsToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.conditionsToolStripMenuItem.Text = "Conditions";
            // 
            // afterTrainingPlaceToolStripMenuItem
            // 
            this.afterTrainingPlaceToolStripMenuItem.Enabled = false;
            this.afterTrainingPlaceToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.afterTrainingPlaceToolStripMenuItem.Name = "afterTrainingPlaceToolStripMenuItem";
            this.afterTrainingPlaceToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.afterTrainingPlaceToolStripMenuItem.Text = "After Training Place";
            // 
            // beforeTrainingPlaceToolStripMenuItem
            // 
            this.beforeTrainingPlaceToolStripMenuItem.Enabled = false;
            this.beforeTrainingPlaceToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.beforeTrainingPlaceToolStripMenuItem.Name = "beforeTrainingPlaceToolStripMenuItem";
            this.beforeTrainingPlaceToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.beforeTrainingPlaceToolStripMenuItem.Text = "Before Training Place";
            // 
            // repeatAfterFinishToolStripMenuItem
            // 
            this.repeatAfterFinishToolStripMenuItem.Enabled = false;
            this.repeatAfterFinishToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.repeatAfterFinishToolStripMenuItem.Name = "repeatAfterFinishToolStripMenuItem";
            this.repeatAfterFinishToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.repeatAfterFinishToolStripMenuItem.Text = "Repeat after finish";
            // 
            // moveToLastDeathPositionToolStripMenuItem
            // 
            this.moveToLastDeathPositionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.moveToLastDeathPositionToolStripMenuItem.Name = "moveToLastDeathPositionToolStripMenuItem";
            this.moveToLastDeathPositionToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.moveToLastDeathPositionToolStripMenuItem.Text = "Move to last death position";
            this.moveToLastDeathPositionToolStripMenuItem.Click += new System.EventHandler(this.moveToLastDeathPositionToolStripMenuItem_Click);
            // 
            // moveToLastRecallPositionToolStripMenuItem
            // 
            this.moveToLastRecallPositionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.moveToLastRecallPositionToolStripMenuItem.Name = "moveToLastRecallPositionToolStripMenuItem";
            this.moveToLastRecallPositionToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.moveToLastRecallPositionToolStripMenuItem.Text = "Move to Last recall position";
            this.moveToLastRecallPositionToolStripMenuItem.Click += new System.EventHandler(this.moveToLastRecallPositionToolStripMenuItem_Click);
            // 
            // selectMapLocationToolStripMenuItem
            // 
            this.selectMapLocationToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.selectMapLocationToolStripMenuItem.Name = "selectMapLocationToolStripMenuItem";
            this.selectMapLocationToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.selectMapLocationToolStripMenuItem.Text = "Select Map Location";
            // 
            // panel1
            // 
            this.panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblFreeSlots);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 431);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(792, 27);
            this.panel1.TabIndex = 6;
            // 
            // buttonInventory
            // 
            this.buttonInventory.Color = System.Drawing.Color.Transparent;
            this.buttonInventory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonInventory.Location = new System.Drawing.Point(9, 8);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Radius = 3;
            this.buttonInventory.Size = new System.Drawing.Size(62, 22);
            this.buttonInventory.TabIndex = 0;
            this.buttonInventory.Text = "Inventory";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonEquipment
            // 
            this.buttonEquipment.Color = System.Drawing.Color.Transparent;
            this.buttonEquipment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEquipment.Location = new System.Drawing.Point(77, 8);
            this.buttonEquipment.Name = "buttonEquipment";
            this.buttonEquipment.Radius = 3;
            this.buttonEquipment.Size = new System.Drawing.Size(69, 22);
            this.buttonEquipment.TabIndex = 1;
            this.buttonEquipment.Text = "Equipment";
            this.buttonEquipment.UseVisualStyleBackColor = true;
            this.buttonEquipment.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonAvatars
            // 
            this.buttonAvatars.Color = System.Drawing.Color.Transparent;
            this.buttonAvatars.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAvatars.Location = new System.Drawing.Point(245, 8);
            this.buttonAvatars.Name = "buttonAvatars";
            this.buttonAvatars.Radius = 3;
            this.buttonAvatars.Size = new System.Drawing.Size(57, 22);
            this.buttonAvatars.TabIndex = 2;
            this.buttonAvatars.Text = "Avatars";
            this.buttonAvatars.UseVisualStyleBackColor = true;
            this.buttonAvatars.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonGrabpet
            // 
            this.buttonGrabpet.Color = System.Drawing.Color.Transparent;
            this.buttonGrabpet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGrabpet.Location = new System.Drawing.Point(308, 8);
            this.buttonGrabpet.Name = "buttonGrabpet";
            this.buttonGrabpet.Radius = 3;
            this.buttonGrabpet.Size = new System.Drawing.Size(59, 22);
            this.buttonGrabpet.TabIndex = 3;
            this.buttonGrabpet.Text = "Grab Pet";
            this.buttonGrabpet.UseVisualStyleBackColor = true;
            this.buttonGrabpet.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // topPanel
            // 
            this.topPanel.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.topPanel.BorderColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.buttonSpecialty);
            this.topPanel.Controls.Add(this.buttonGuildStorage);
            this.topPanel.Controls.Add(this.buttonGrabpet);
            this.topPanel.Controls.Add(this.buttonInventory);
            this.topPanel.Controls.Add(this.buttonFellowPet);
            this.topPanel.Controls.Add(this.buttonJobTransport);
            this.topPanel.Controls.Add(this.buttonStorage);
            this.topPanel.Controls.Add(this.buttonJobEquipment);
            this.topPanel.Controls.Add(this.buttonEquipment);
            this.topPanel.Controls.Add(this.buttonAvatars);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(8);
            this.topPanel.Radius = 0;
            this.topPanel.Size = new System.Drawing.Size(792, 38);
            this.topPanel.TabIndex = 8;
            // 
            // buttonSpecialty
            // 
            this.buttonSpecialty.Color = System.Drawing.Color.Transparent;
            this.buttonSpecialty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSpecialty.Location = new System.Drawing.Point(553, 8);
            this.buttonSpecialty.Name = "buttonSpecialty";
            this.buttonSpecialty.Radius = 3;
            this.buttonSpecialty.Size = new System.Drawing.Size(66, 22);
            this.buttonSpecialty.TabIndex = 7;
            this.buttonSpecialty.Text = "Specialty";
            this.buttonSpecialty.UseVisualStyleBackColor = true;
            this.buttonSpecialty.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonGuildStorage
            // 
            this.buttonGuildStorage.Color = System.Drawing.Color.Transparent;
            this.buttonGuildStorage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGuildStorage.Location = new System.Drawing.Point(684, 8);
            this.buttonGuildStorage.Name = "buttonGuildStorage";
            this.buttonGuildStorage.Radius = 3;
            this.buttonGuildStorage.Size = new System.Drawing.Size(81, 22);
            this.buttonGuildStorage.TabIndex = 5;
            this.buttonGuildStorage.Text = "Guild Storage";
            this.buttonGuildStorage.UseVisualStyleBackColor = true;
            this.buttonGuildStorage.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonFellowPet
            // 
            this.buttonFellowPet.Color = System.Drawing.Color.Transparent;
            this.buttonFellowPet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFellowPet.Location = new System.Drawing.Point(373, 8);
            this.buttonFellowPet.Name = "buttonFellowPet";
            this.buttonFellowPet.Radius = 3;
            this.buttonFellowPet.Size = new System.Drawing.Size(84, 22);
            this.buttonFellowPet.TabIndex = 9;
            this.buttonFellowPet.Text = "Fellow Pet";
            this.buttonFellowPet.UseVisualStyleBackColor = true;
            this.buttonFellowPet.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonJobTransport
            // 
            this.buttonJobTransport.Color = System.Drawing.Color.Transparent;
            this.buttonJobTransport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonJobTransport.Location = new System.Drawing.Point(463, 8);
            this.buttonJobTransport.Name = "buttonJobTransport";
            this.buttonJobTransport.Radius = 3;
            this.buttonJobTransport.Size = new System.Drawing.Size(84, 22);
            this.buttonJobTransport.TabIndex = 6;
            this.buttonJobTransport.Text = "Job Transport";
            this.buttonJobTransport.UseVisualStyleBackColor = true;
            this.buttonJobTransport.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonStorage
            // 
            this.buttonStorage.Color = System.Drawing.Color.Transparent;
            this.buttonStorage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStorage.Location = new System.Drawing.Point(625, 8);
            this.buttonStorage.Name = "buttonStorage";
            this.buttonStorage.Radius = 3;
            this.buttonStorage.Size = new System.Drawing.Size(53, 22);
            this.buttonStorage.TabIndex = 4;
            this.buttonStorage.Text = "Storage";
            this.buttonStorage.UseVisualStyleBackColor = true;
            this.buttonStorage.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonJobEquipment
            // 
            this.buttonJobEquipment.Color = System.Drawing.Color.Transparent;
            this.buttonJobEquipment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonJobEquipment.Location = new System.Drawing.Point(152, 8);
            this.buttonJobEquipment.Name = "buttonJobEquipment";
            this.buttonJobEquipment.Radius = 3;
            this.buttonJobEquipment.Size = new System.Drawing.Size(87, 22);
            this.buttonJobEquipment.TabIndex = 8;
            this.buttonJobEquipment.Text = "Job Equipment";
            this.buttonJobEquipment.UseVisualStyleBackColor = true;
            this.buttonJobEquipment.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(792, 458);
            this.Load += new System.EventHandler(this.Main_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SDUI.Controls.ListView listViewMain;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label lblFreeSlots;
        private System.Windows.Forms.ColumnHeader colGenderRace;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Button buttonInventory;
        private SDUI.Controls.Button buttonEquipment;
        private SDUI.Controls.Button buttonAvatars;
        private SDUI.Controls.Button buttonGrabpet;
        private SDUI.Controls.Panel topPanel;
        private SDUI.Controls.Button buttonSpecialty;
        private SDUI.Controls.Button buttonGuildStorage;
        private SDUI.Controls.Button buttonJobTransport;
        private SDUI.Controls.Button buttonStorage;
        private SDUI.Controls.Button buttonJobEquipment;
        private SDUI.Controls.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem useToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conditionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afterTrainingPlaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beforeTrainingPlaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToLastDeathPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToLastRecallPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectMapLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeatAfterFinishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToPetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToPlayerToolStripMenuItem;
        private SDUI.Controls.Button buttonFellowPet;
    }
}
