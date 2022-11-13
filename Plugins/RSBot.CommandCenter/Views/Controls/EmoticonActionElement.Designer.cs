namespace RSBot.CommandCenter.Views.Controls
{
    partial class EmoticonActionElement
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.comboAction = new SDUI.Controls.ComboBox();
            this.lblName = new SDUI.Controls.Label();
            this.separator1 = new SDUI.Controls.Separator();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(11, 9);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(32, 32);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // comboAction
            // 
            this.comboAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAction.FormattingEnabled = true;
            this.comboAction.Location = new System.Drawing.Point(58, 19);
            this.comboAction.Name = "comboAction";
            this.comboAction.Radius = 5;
            this.comboAction.ShadowDepth = 4F;
            this.comboAction.Size = new System.Drawing.Size(188, 24);
            this.comboAction.TabIndex = 1;
            this.comboAction.SelectedIndexChanged += new System.EventHandler(this.comboAction_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(58, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 15);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "<name>";
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(0, 43);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(277, 10);
            this.separator1.TabIndex = 3;
            this.separator1.Text = "separator1";
            // 
            // ActionEmoticonElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.comboAction);
            this.Controls.Add(this.picIcon);
            this.Name = "ActionEmoticonElement";
            this.Size = new System.Drawing.Size(277, 53);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private SDUI.Controls.ComboBox comboAction;
        private SDUI.Controls.Label lblName;
        private SDUI.Controls.Separator separator1;
    }
}
