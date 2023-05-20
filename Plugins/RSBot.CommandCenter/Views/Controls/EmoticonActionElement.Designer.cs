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
            picIcon = new System.Windows.Forms.PictureBox();
            comboAction = new SDUI.Controls.ComboBox();
            lblName = new SDUI.Controls.Label();
            separator1 = new SDUI.Controls.Separator();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            SuspendLayout();
            // 
            // picIcon
            // 
            picIcon.Location = new System.Drawing.Point(11, 9);
            picIcon.Name = "picIcon";
            picIcon.Size = new System.Drawing.Size(32, 32);
            picIcon.TabIndex = 0;
            picIcon.TabStop = false;
            // 
            // comboAction
            // 
            comboAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAction.FormattingEnabled = true;
            comboAction.Location = new System.Drawing.Point(58, 19);
            comboAction.Name = "comboAction";
            comboAction.Radius = 5;
            comboAction.ShadowDepth = 4F;
            comboAction.Size = new System.Drawing.Size(188, 24);
            comboAction.TabIndex = 1;
            comboAction.SelectedIndexChanged += comboAction_SelectedIndexChanged;
            // 
            // lblName
            // 
            lblName.ApplyGradient = false;
            lblName.AutoSize = true;
            lblName.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblName.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            lblName.Location = new System.Drawing.Point(58, 3);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(53, 15);
            lblName.TabIndex = 2;
            lblName.Text = "<name>";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(0, 43);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(277, 10);
            separator1.TabIndex = 3;
            separator1.Text = "separator1";
            // 
            // EmoticonActionElement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(separator1);
            Controls.Add(lblName);
            Controls.Add(comboAction);
            Controls.Add(picIcon);
            Name = "EmoticonActionElement";
            Size = new System.Drawing.Size(277, 53);
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private SDUI.Controls.ComboBox comboAction;
        private SDUI.Controls.Label lblName;
        private SDUI.Controls.Separator separator1;
    }
}
