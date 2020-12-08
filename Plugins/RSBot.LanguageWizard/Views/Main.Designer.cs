namespace RSBot.LanguageWizard.Views
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lvValues = new Theme.Controls.ListView();
            this.comboDirectChoice = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFindKey = new Theme.Material.Button();
            this.btnSave = new Theme.Material.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. What is this tool?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 60);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 60);
            this.label3.TabIndex = 3;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "2. Who needs this tool?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(433, 45);
            this.label5.TabIndex = 5;
            this.label5.Text = "Below this text you can see a data table where you can pick the correct\r\ncolumn. " +
    "You should pick a column that displays the name of the item or you can\r\nselect t" +
    "he translation index directly. ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "3. How does this work?";
            // 
            // lvValues
            // 
            this.lvValues.FullRowSelect = true;
            this.lvValues.Location = new System.Drawing.Point(17, 322);
            this.lvValues.Name = "lvValues";
            this.lvValues.Size = new System.Drawing.Size(477, 165);
            this.lvValues.TabIndex = 6;
            this.lvValues.UseCompatibleStateImageBehavior = false;
            this.lvValues.View = System.Windows.Forms.View.Details;
            this.lvValues.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvValues_ColumnClick);
            // 
            // comboDirectChoice
            // 
            this.comboDirectChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDirectChoice.FormattingEnabled = true;
            this.comboDirectChoice.Location = new System.Drawing.Point(294, 8);
            this.comboDirectChoice.Name = "comboDirectChoice";
            this.comboDirectChoice.Size = new System.Drawing.Size(121, 23);
            this.comboDirectChoice.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(331, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Please click on the column that has \"human\" readable values:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnFindKey);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.comboDirectChoice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 507);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 37);
            this.panel1.TabIndex = 9;
            // 
            // btnFindKey
            // 
            this.btnFindKey.Depth = 0;
            this.btnFindKey.Icon = null;
            this.btnFindKey.Location = new System.Drawing.Point(17, 8);
            this.btnFindKey.MouseState = Theme.IMatMouseState.HOVER;
            this.btnFindKey.Name = "btnFindKey";
            this.btnFindKey.Primary = false;
            this.btnFindKey.Raised = false;
            this.btnFindKey.Size = new System.Drawing.Size(174, 21);
            this.btnFindKey.TabIndex = 9;
            this.btnFindKey.Text = "Find the index automatically";
            this.btnFindKey.UseVisualStyleBackColor = true;
            this.btnFindKey.Click += new System.EventHandler(this.btnFindKey_Click);
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(421, 8);
            this.btnSave.MouseState = Theme.IMatMouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Raised = true;
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lvValues);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "Main";
            this.Size = new System.Drawing.Size(513, 544);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Theme.Controls.ListView lvValues;
        private System.Windows.Forms.ComboBox comboDirectChoice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private Theme.Material.Button btnSave;
        private Theme.Material.Button btnFindKey;
    }
}
