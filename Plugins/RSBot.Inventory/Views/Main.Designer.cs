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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboInventoryType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFreeSlots = new System.Windows.Forms.Label();
            this.imgItems = new System.Windows.Forms.ImageList(this.components);
            this.listViewMain = new RSBot.Theme.Controls.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGenderRace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonUseItem = new RSBot.Theme.Material.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory:";
            // 
            // comboInventoryType
            // 
            this.comboInventoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInventoryType.FormattingEnabled = true;
            this.comboInventoryType.Items.AddRange(new object[] {
            "Player",
            "Equipment",
            "Avatars",
            "Pet",
            "Storage"});
            this.comboInventoryType.Location = new System.Drawing.Point(73, 4);
            this.comboInventoryType.Name = "comboInventoryType";
            this.comboInventoryType.Size = new System.Drawing.Size(186, 21);
            this.comboInventoryType.TabIndex = 1;
            this.comboInventoryType.SelectedIndexChanged += new System.EventHandler(this.comboInventoryType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Free slots:";
            // 
            // lblFreeSlots
            // 
            this.lblFreeSlots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFreeSlots.AutoSize = true;
            this.lblFreeSlots.Location = new System.Drawing.Point(69, 3);
            this.lblFreeSlots.Name = "lblFreeSlots";
            this.lblFreeSlots.Size = new System.Drawing.Size(74, 13);
            this.lblFreeSlots.TabIndex = 4;
            this.lblFreeSlots.Text = "not calculated";
            // 
            // imgItems
            // 
            this.imgItems.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgItems.ImageSize = new System.Drawing.Size(24, 24);
            this.imgItems.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewMain
            // 
            this.listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAmount,
            this.colGenderRace});
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(6, 36);
            this.listViewMain.MultiSelect = false;
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(738, 394);
            this.listViewMain.SmallImageList = this.imgItems;
            this.listViewMain.TabIndex = 2;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            this.listViewMain.SelectedIndexChanged += new System.EventHandler(this.listViewMain_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 441;
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblFreeSlots);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(6, 430);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(738, 22);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonUseItem);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboInventoryType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 30);
            this.panel2.TabIndex = 7;
            // 
            // buttonUseItem
            // 
            this.buttonUseItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUseItem.Depth = 0;
            this.buttonUseItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUseItem.Icon = null;
            this.buttonUseItem.Location = new System.Drawing.Point(657, 3);
            this.buttonUseItem.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.buttonUseItem.Name = "buttonUseItem";
            this.buttonUseItem.Primary = true;
            this.buttonUseItem.Raised = true;
            this.buttonUseItem.SingleColor = System.Drawing.Color.Empty;
            this.buttonUseItem.Size = new System.Drawing.Size(75, 23);
            this.buttonUseItem.TabIndex = 6;
            this.buttonUseItem.Text = "Use";
            this.buttonUseItem.UseVisualStyleBackColor = true;
            this.buttonUseItem.Click += new System.EventHandler(this.buttonUseItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(750, 458);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboInventoryType;
        private Theme.Controls.ListView listViewMain;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFreeSlots;
        private System.Windows.Forms.ColumnHeader colGenderRace;
        private System.Windows.Forms.ImageList imgItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Theme.Material.Button buttonUseItem;
    }
}
