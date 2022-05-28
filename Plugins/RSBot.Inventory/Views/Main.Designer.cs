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
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGenderRace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new SDUI.Controls.Panel();
            this.buttonUseItem = new SDUI.Controls.Button();
            this.buttonInventory = new SDUI.Controls.Button();
            this.button2 = new SDUI.Controls.Button();
            this.button3 = new SDUI.Controls.Button();
            this.button4 = new SDUI.Controls.Button();
            this.topPanel = new SDUI.Controls.Panel();
            this.button8 = new SDUI.Controls.Button();
            this.button6 = new SDUI.Controls.Button();
            this.button7 = new SDUI.Controls.Button();
            this.button5 = new SDUI.Controls.Button();
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
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(0, 38);
            this.listViewMain.MultiSelect = false;
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(750, 393);
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
            this.panel1.Size = new System.Drawing.Size(750, 27);
            this.panel1.TabIndex = 6;
            // 
            // buttonUseItem
            // 
            this.buttonUseItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUseItem.Color = System.Drawing.Color.DodgerBlue;
            this.buttonUseItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUseItem.ForeColor = System.Drawing.Color.White;
            this.buttonUseItem.Location = new System.Drawing.Point(661, 7);
            this.buttonUseItem.Name = "buttonUseItem";
            this.buttonUseItem.Radius = 4;
            this.buttonUseItem.Size = new System.Drawing.Size(75, 23);
            this.buttonUseItem.TabIndex = 8;
            this.buttonUseItem.Text = "Use";
            this.buttonUseItem.UseVisualStyleBackColor = true;
            this.buttonUseItem.Click += new System.EventHandler(this.buttonUseItem_Click);
            // 
            // buttonInventory
            // 
            this.buttonInventory.Color = System.Drawing.Color.Transparent;
            this.buttonInventory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInventory.Location = new System.Drawing.Point(9, 7);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Radius = 4;
            this.buttonInventory.Size = new System.Drawing.Size(62, 23);
            this.buttonInventory.TabIndex = 0;
            this.buttonInventory.Text = "Inventory";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // button2
            // 
            this.button2.Color = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(77, 7);
            this.button2.Name = "button2";
            this.button2.Radius = 4;
            this.button2.Size = new System.Drawing.Size(69, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Equipment";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // button3
            // 
            this.button3.Color = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(152, 7);
            this.button3.Name = "button3";
            this.button3.Radius = 4;
            this.button3.Size = new System.Drawing.Size(57, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Avatars";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // button4
            // 
            this.button4.Color = System.Drawing.Color.Transparent;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(215, 7);
            this.button4.Name = "button4";
            this.button4.Radius = 4;
            this.button4.Size = new System.Drawing.Size(59, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Grab Pet";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // topPanel
            // 
            this.topPanel.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.topPanel.BorderColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.button8);
            this.topPanel.Controls.Add(this.button6);
            this.topPanel.Controls.Add(this.button4);
            this.topPanel.Controls.Add(this.buttonInventory);
            this.topPanel.Controls.Add(this.button7);
            this.topPanel.Controls.Add(this.button5);
            this.topPanel.Controls.Add(this.button2);
            this.topPanel.Controls.Add(this.button3);
            this.topPanel.Controls.Add(this.buttonUseItem);
            this.topPanel.Controls.Add(this.separator1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Radius = 0;
            this.topPanel.Size = new System.Drawing.Size(750, 38);
            this.topPanel.TabIndex = 8;
            // 
            // button8
            // 
            this.button8.Color = System.Drawing.Color.Transparent;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(370, 7);
            this.button8.Name = "button8";
            this.button8.Radius = 4;
            this.button8.Size = new System.Drawing.Size(66, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "Specialty";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // button6
            // 
            this.button6.Color = System.Drawing.Color.Transparent;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(501, 7);
            this.button6.Name = "button6";
            this.button6.Radius = 4;
            this.button6.Size = new System.Drawing.Size(81, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Guild Storage";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // button7
            // 
            this.button7.Color = System.Drawing.Color.Transparent;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(280, 7);
            this.button7.Name = "button7";
            this.button7.Radius = 4;
            this.button7.Size = new System.Drawing.Size(84, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Job Transport";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // button5
            // 
            this.button5.Color = System.Drawing.Color.Transparent;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(442, 7);
            this.button5.Name = "button5";
            this.button5.Radius = 4;
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Storage";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ButtonSwitcher);
            // 
            // separator1
            // 
            this.separator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.separator1.IsVertical = true;
            this.separator1.Location = new System.Drawing.Point(641, 0);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
            this.Size = new System.Drawing.Size(750, 458);
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
        private SDUI.Controls.Button button2;
        private SDUI.Controls.Button button3;
        private SDUI.Controls.Button button4;
        private SDUI.Controls.Panel topPanel;
        private SDUI.Controls.Button button8;
        private SDUI.Controls.Button button6;
        private SDUI.Controls.Button button7;
        private SDUI.Controls.Button button5;
        private SDUI.Controls.Separator separator1;
    }
}
