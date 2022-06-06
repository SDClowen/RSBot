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
            this.panel1 = new SDUI.Controls.Panel();
            this.buttonUseItem = new SDUI.Controls.Button();
            this.buttonInventory = new SDUI.Controls.Button();
            this.buttonEquipment = new SDUI.Controls.Button();
            this.buttonAvatars = new SDUI.Controls.Button();
            this.buttonGrabpet = new SDUI.Controls.Button();
            this.topPanel = new SDUI.Controls.Panel();
            this.buttonSpecialty = new SDUI.Controls.Button();
            this.buttonGuildStorage = new SDUI.Controls.Button();
            this.buttonJobTransport = new SDUI.Controls.Button();
            this.buttonStorage = new SDUI.Controls.Button();
            this.buttonJobEquipment = new SDUI.Controls.Button();
            this.separator1 = new SDUI.Controls.Separator();
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
            this.listViewMain.SelectedIndexChanged += new System.EventHandler(this.listViewMain_SelectedIndexChanged);
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
            // buttonUseItem
            // 
            this.buttonUseItem.Color = System.Drawing.Color.DodgerBlue;
            this.buttonUseItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonUseItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUseItem.ForeColor = System.Drawing.Color.White;
            this.buttonUseItem.Location = new System.Drawing.Point(709, 8);
            this.buttonUseItem.Name = "buttonUseItem";
            this.buttonUseItem.Radius = 4;
            this.buttonUseItem.Size = new System.Drawing.Size(75, 22);
            this.buttonUseItem.TabIndex = 9;
            this.buttonUseItem.Text = "Use";
            this.buttonUseItem.UseVisualStyleBackColor = true;
            this.buttonUseItem.Click += new System.EventHandler(this.buttonUseItem_Click);
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
            this.topPanel.Controls.Add(this.buttonJobTransport);
            this.topPanel.Controls.Add(this.buttonStorage);
            this.topPanel.Controls.Add(this.buttonJobEquipment);
            this.topPanel.Controls.Add(this.buttonEquipment);
            this.topPanel.Controls.Add(this.buttonAvatars);
            this.topPanel.Controls.Add(this.buttonUseItem);
            this.topPanel.Controls.Add(this.separator1);
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
            this.buttonSpecialty.Location = new System.Drawing.Point(463, 8);
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
            this.buttonGuildStorage.Location = new System.Drawing.Point(594, 8);
            this.buttonGuildStorage.Name = "buttonGuildStorage";
            this.buttonGuildStorage.Radius = 3;
            this.buttonGuildStorage.Size = new System.Drawing.Size(81, 22);
            this.buttonGuildStorage.TabIndex = 5;
            this.buttonGuildStorage.Text = "Guild Storage";
            this.buttonGuildStorage.UseVisualStyleBackColor = true;
            this.buttonGuildStorage.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // buttonJobTransport
            // 
            this.buttonJobTransport.Color = System.Drawing.Color.Transparent;
            this.buttonJobTransport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonJobTransport.Location = new System.Drawing.Point(373, 8);
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
            this.buttonStorage.Location = new System.Drawing.Point(535, 8);
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
            // separator1
            // 
            this.separator1.IsVertical = true;
            this.separator1.Location = new System.Drawing.Point(701, 0);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(2, 38);
            this.separator1.TabIndex = 8;
            this.separator1.Text = "separator1";
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
        private SDUI.Controls.Button buttonUseItem;
        private SDUI.Controls.Button buttonInventory;
        private SDUI.Controls.Button buttonEquipment;
        private SDUI.Controls.Button buttonAvatars;
        private SDUI.Controls.Button buttonGrabpet;
        private SDUI.Controls.Panel topPanel;
        private SDUI.Controls.Button buttonSpecialty;
        private SDUI.Controls.Button buttonGuildStorage;
        private SDUI.Controls.Button buttonJobTransport;
        private SDUI.Controls.Button buttonStorage;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.Button buttonJobEquipment;
    }
}
