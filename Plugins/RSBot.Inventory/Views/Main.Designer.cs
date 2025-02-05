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
            components = new System.ComponentModel.Container();
            lblFreeSlots = new System.Windows.Forms.Label();
            listViewMain = new System.Windows.Forms.ListView();
            colName = new System.Windows.Forms.ColumnHeader();
            colAmount = new System.Windows.Forms.ColumnHeader();
            colGenderRace = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            useToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveToPetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveToPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveToLastDeathPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveToLastRecallPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            selectMapLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            useItemAtTrainingPlaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            autoUseAccordingToPurposeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new System.Windows.Forms.Panel();
            checkAutoSort = new System.Windows.Forms.CheckBox();
            btnSort = new System.Windows.Forms.Button();
            buttonInventory = new System.Windows.Forms.Button();
            buttonEquipment = new System.Windows.Forms.Button();
            buttonAvatars = new System.Windows.Forms.Button();
            buttonGrabpet = new System.Windows.Forms.Button();
            topPanel = new System.Windows.Forms.Panel();
            buttonSpecialty = new System.Windows.Forms.Button();
            buttonGuildStorage = new System.Windows.Forms.Button();
            buttonFellowPet = new System.Windows.Forms.Button();
            buttonJobTransport = new System.Windows.Forms.Button();
            buttonStorage = new System.Windows.Forms.Button();
            buttonJobEquipment = new System.Windows.Forms.Button();
            contextMenuStrip.SuspendLayout();
            panel1.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblFreeSlots
            // 
            lblFreeSlots.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblFreeSlots.AutoSize = true;
            lblFreeSlots.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            lblFreeSlots.Location = new System.Drawing.Point(11, 9);
            lblFreeSlots.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFreeSlots.Name = "lblFreeSlots";
            lblFreeSlots.Size = new System.Drawing.Size(22, 25);
            lblFreeSlots.TabIndex = 4;
            lblFreeSlots.Text = "0";
            // 
            // listViewMain
            // 
            listViewMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colName, colAmount, colGenderRace });
            listViewMain.ContextMenuStrip = contextMenuStrip;
            listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewMain.FullRowSelect = true;
            listViewMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewMain.Location = new System.Drawing.Point(0, 48);
            listViewMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            listViewMain.MultiSelect = false;
            listViewMain.Name = "listViewMain";
            listViewMain.Size = new System.Drawing.Size(990, 476);
            listViewMain.TabIndex = 2;
            listViewMain.UseCompatibleStateImageBehavior = false;
            listViewMain.View = System.Windows.Forms.View.Details;
            listViewMain.MouseDoubleClick += listViewMain_MouseDoubleClick;
            // 
            // colName
            // 
            colName.Text = "Name";
            colName.Width = 381;
            // 
            // colAmount
            // 
            colAmount.Text = "Amount";
            colAmount.Width = 62;
            // 
            // colGenderRace
            // 
            colGenderRace.Text = "Rarity";
            colGenderRace.Width = 153;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { useToolStripMenuItem, dropToolStripMenuItem, moveToPetToolStripMenuItem, moveToPlayerToolStripMenuItem, moveToLastDeathPositionToolStripMenuItem, moveToLastRecallPositionToolStripMenuItem, selectMapLocationToolStripMenuItem, useItemAtTrainingPlaceMenuItem, autoUseAccordingToPurposeToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(283, 220);
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // useToolStripMenuItem
            // 
            useToolStripMenuItem.Name = "useToolStripMenuItem";
            useToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            useToolStripMenuItem.Text = "Use";
            useToolStripMenuItem.Click += buttonUseItem_Click;
            // 
            // dropToolStripMenuItem
            // 
            dropToolStripMenuItem.Name = "dropToolStripMenuItem";
            dropToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            dropToolStripMenuItem.Text = "Drop";
            dropToolStripMenuItem.Click += dropToolStripMenuItem_Click;
            // 
            // moveToPetToolStripMenuItem
            // 
            moveToPetToolStripMenuItem.Name = "moveToPetToolStripMenuItem";
            moveToPetToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            moveToPetToolStripMenuItem.Text = "Move to active pet";
            moveToPetToolStripMenuItem.Click += moveToPetToolStripMenuItem_Click;
            // 
            // moveToPlayerToolStripMenuItem
            // 
            moveToPlayerToolStripMenuItem.Name = "moveToPlayerToolStripMenuItem";
            moveToPlayerToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            moveToPlayerToolStripMenuItem.Text = "Move to player";
            moveToPlayerToolStripMenuItem.Click += moveToPlayerToolStripMenuItem_Click;
            // 
            // moveToLastDeathPositionToolStripMenuItem
            // 
            moveToLastDeathPositionToolStripMenuItem.Name = "moveToLastDeathPositionToolStripMenuItem";
            moveToLastDeathPositionToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            moveToLastDeathPositionToolStripMenuItem.Text = "Move to last death position";
            moveToLastDeathPositionToolStripMenuItem.Click += moveToLastDeathPositionToolStripMenuItem_Click;
            // 
            // moveToLastRecallPositionToolStripMenuItem
            // 
            moveToLastRecallPositionToolStripMenuItem.Name = "moveToLastRecallPositionToolStripMenuItem";
            moveToLastRecallPositionToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            moveToLastRecallPositionToolStripMenuItem.Text = "Move to Last recall position";
            moveToLastRecallPositionToolStripMenuItem.Click += moveToLastRecallPositionToolStripMenuItem_Click;
            // 
            // selectMapLocationToolStripMenuItem
            // 
            selectMapLocationToolStripMenuItem.Name = "selectMapLocationToolStripMenuItem";
            selectMapLocationToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            selectMapLocationToolStripMenuItem.Text = "Select Map Location";
            // 
            // useItemAtTrainingPlaceMenuItem
            // 
            useItemAtTrainingPlaceMenuItem.Name = "useItemAtTrainingPlaceMenuItem";
            useItemAtTrainingPlaceMenuItem.Size = new System.Drawing.Size(282, 24);
            useItemAtTrainingPlaceMenuItem.Text = "Use item at training place";
            useItemAtTrainingPlaceMenuItem.Click += useItemAtTrainingPlaceMenuItem_Click;
            // 
            // autoUseAccordingToPurposeToolStripMenuItem
            // 
            autoUseAccordingToPurposeToolStripMenuItem.Name = "autoUseAccordingToPurposeToolStripMenuItem";
            autoUseAccordingToPurposeToolStripMenuItem.Size = new System.Drawing.Size(282, 24);
            autoUseAccordingToPurposeToolStripMenuItem.Text = "Auto use according to purpose";
            autoUseAccordingToPurposeToolStripMenuItem.Click += autoUseAccordingToPurposeToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkAutoSort);
            panel1.Controls.Add(btnSort);
            panel1.Controls.Add(lblFreeSlots);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 524);
            panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panel1.Size = new System.Drawing.Size(990, 48);
            panel1.TabIndex = 6;
            // 
            // checkAutoSort
            // 
            checkAutoSort.AutoSize = true;
            checkAutoSort.Location = new System.Drawing.Point(792, 12);
            checkAutoSort.Margin = new System.Windows.Forms.Padding(0);
            checkAutoSort.Name = "checkAutoSort";
            checkAutoSort.Size = new System.Drawing.Size(92, 24);
            checkAutoSort.TabIndex = 6;
            checkAutoSort.Text = "Auto sort";
            checkAutoSort.UseVisualStyleBackColor = true;
            checkAutoSort.CheckedChanged += checkAutoSort_CheckedChanged;
            // 
            // btnSort
            // 
            btnSort.AutoSize = true;
            btnSort.Location = new System.Drawing.Point(888, 8);
            btnSort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnSort.Name = "btnSort";
            btnSort.Size = new System.Drawing.Size(94, 30);
            btnSort.TabIndex = 5;
            btnSort.Text = "Sort";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // buttonInventory
            // 
            buttonInventory.AutoSize = true;
            buttonInventory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonInventory.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonInventory.Location = new System.Drawing.Point(11, 10);
            buttonInventory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonInventory.Name = "buttonInventory";
            buttonInventory.Size = new System.Drawing.Size(80, 30);
            buttonInventory.TabIndex = 0;
            buttonInventory.Text = "Inventory";
            buttonInventory.UseVisualStyleBackColor = true;
            buttonInventory.Click += ButtonSwitcher;
            // 
            // buttonEquipment
            // 
            buttonEquipment.AutoSize = true;
            buttonEquipment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonEquipment.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonEquipment.Location = new System.Drawing.Point(99, 10);
            buttonEquipment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonEquipment.Name = "buttonEquipment";
            buttonEquipment.Size = new System.Drawing.Size(91, 30);
            buttonEquipment.TabIndex = 1;
            buttonEquipment.Text = "Equipment";
            buttonEquipment.UseVisualStyleBackColor = true;
            buttonEquipment.Click += ButtonSwitcher;
            // 
            // buttonAvatars
            // 
            buttonAvatars.AutoSize = true;
            buttonAvatars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonAvatars.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonAvatars.Location = new System.Drawing.Point(324, 10);
            buttonAvatars.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonAvatars.Name = "buttonAvatars";
            buttonAvatars.Size = new System.Drawing.Size(68, 30);
            buttonAvatars.TabIndex = 2;
            buttonAvatars.Text = "Avatars";
            buttonAvatars.UseVisualStyleBackColor = true;
            buttonAvatars.Click += ButtonSwitcher;
            // 
            // buttonGrabpet
            // 
            buttonGrabpet.AutoSize = true;
            buttonGrabpet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonGrabpet.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonGrabpet.Location = new System.Drawing.Point(400, 10);
            buttonGrabpet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonGrabpet.Name = "buttonGrabpet";
            buttonGrabpet.Size = new System.Drawing.Size(75, 30);
            buttonGrabpet.TabIndex = 3;
            buttonGrabpet.Text = "Grab Pet";
            buttonGrabpet.UseVisualStyleBackColor = true;
            buttonGrabpet.Click += ButtonSwitcher;
            // 
            // topPanel
            // 
            topPanel.Controls.Add(buttonSpecialty);
            topPanel.Controls.Add(buttonGuildStorage);
            topPanel.Controls.Add(buttonGrabpet);
            topPanel.Controls.Add(buttonInventory);
            topPanel.Controls.Add(buttonFellowPet);
            topPanel.Controls.Add(buttonJobTransport);
            topPanel.Controls.Add(buttonStorage);
            topPanel.Controls.Add(buttonJobEquipment);
            topPanel.Controls.Add(buttonEquipment);
            topPanel.Controls.Add(buttonAvatars);
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Location = new System.Drawing.Point(0, 0);
            topPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            topPanel.Name = "topPanel";
            topPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            topPanel.Size = new System.Drawing.Size(990, 48);
            topPanel.TabIndex = 8;
            // 
            // buttonSpecialty
            // 
            buttonSpecialty.AutoSize = true;
            buttonSpecialty.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonSpecialty.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonSpecialty.Location = new System.Drawing.Point(693, 10);
            buttonSpecialty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonSpecialty.Name = "buttonSpecialty";
            buttonSpecialty.Size = new System.Drawing.Size(79, 30);
            buttonSpecialty.TabIndex = 7;
            buttonSpecialty.Text = "Specialty";
            buttonSpecialty.UseVisualStyleBackColor = true;
            buttonSpecialty.Click += ButtonSwitcher;
            // 
            // buttonGuildStorage
            // 
            buttonGuildStorage.AutoSize = true;
            buttonGuildStorage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonGuildStorage.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonGuildStorage.Location = new System.Drawing.Point(859, 10);
            buttonGuildStorage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonGuildStorage.Name = "buttonGuildStorage";
            buttonGuildStorage.Size = new System.Drawing.Size(110, 30);
            buttonGuildStorage.TabIndex = 5;
            buttonGuildStorage.Text = "Guild Storage";
            buttonGuildStorage.UseVisualStyleBackColor = true;
            buttonGuildStorage.Click += ButtonSwitcher;
            // 
            // buttonFellowPet
            // 
            buttonFellowPet.AutoSize = true;
            buttonFellowPet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonFellowPet.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonFellowPet.Location = new System.Drawing.Point(483, 10);
            buttonFellowPet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonFellowPet.Name = "buttonFellowPet";
            buttonFellowPet.Size = new System.Drawing.Size(86, 30);
            buttonFellowPet.TabIndex = 9;
            buttonFellowPet.Text = "Fellow Pet";
            buttonFellowPet.UseVisualStyleBackColor = true;
            buttonFellowPet.Click += ButtonSwitcher;
            // 
            // buttonJobTransport
            // 
            buttonJobTransport.AutoSize = true;
            buttonJobTransport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonJobTransport.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonJobTransport.Location = new System.Drawing.Point(577, 10);
            buttonJobTransport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonJobTransport.Name = "buttonJobTransport";
            buttonJobTransport.Size = new System.Drawing.Size(108, 30);
            buttonJobTransport.TabIndex = 6;
            buttonJobTransport.Text = "Job Transport";
            buttonJobTransport.UseVisualStyleBackColor = true;
            buttonJobTransport.Click += ButtonSwitcher;
            // 
            // buttonStorage
            // 
            buttonStorage.AutoSize = true;
            buttonStorage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonStorage.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonStorage.Location = new System.Drawing.Point(780, 10);
            buttonStorage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonStorage.Name = "buttonStorage";
            buttonStorage.Size = new System.Drawing.Size(71, 30);
            buttonStorage.TabIndex = 4;
            buttonStorage.Text = "Storage";
            buttonStorage.UseVisualStyleBackColor = true;
            buttonStorage.Click += ButtonSwitcher;
            // 
            // buttonJobEquipment
            // 
            buttonJobEquipment.AutoSize = true;
            buttonJobEquipment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonJobEquipment.Font = new System.Drawing.Font("Segoe UI", 9F);
            buttonJobEquipment.Location = new System.Drawing.Point(198, 10);
            buttonJobEquipment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonJobEquipment.Name = "buttonJobEquipment";
            buttonJobEquipment.Size = new System.Drawing.Size(118, 30);
            buttonJobEquipment.TabIndex = 8;
            buttonJobEquipment.Text = "Job Equipment";
            buttonJobEquipment.UseVisualStyleBackColor = true;
            buttonJobEquipment.Click += ButtonSwitcher;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(listViewMain);
            Controls.Add(topPanel);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "Main";
            Size = new System.Drawing.Size(990, 572);
            Load += Main_Load;
            VisibleChanged += Main_VisibleChanged;
            contextMenuStrip.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFreeSlots;
        private System.Windows.Forms.ColumnHeader colGenderRace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.Button buttonEquipment;
        private System.Windows.Forms.Button buttonAvatars;
        private System.Windows.Forms.Button buttonGrabpet;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button buttonSpecialty;
        private System.Windows.Forms.Button buttonGuildStorage;
        private System.Windows.Forms.Button buttonJobTransport;
        private System.Windows.Forms.Button buttonStorage;
        private System.Windows.Forms.Button buttonJobEquipment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem useToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToLastDeathPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToLastRecallPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectMapLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToPetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToPlayerToolStripMenuItem;
        private System.Windows.Forms.Button buttonFellowPet;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.CheckBox checkAutoSort;
        private System.Windows.Forms.ToolStripMenuItem useItemAtTrainingPlaceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoUseAccordingToPurposeToolStripMenuItem;
    }
}
