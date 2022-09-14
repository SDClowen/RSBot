namespace RSBot.Assistant.Views
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
            this.checkBuff = new SDUI.Controls.CheckBox();
            this.checkAttack = new SDUI.Controls.CheckBox();
            this.lblTitle = new SDUI.Controls.Label();
            this.lblDescription = new SDUI.Controls.Label();
            this.separator1 = new SDUI.Controls.Separator();
            this.SuspendLayout();
            // 
            // checkBuff
            // 
            this.checkBuff.AutoSize = true;
            this.checkBuff.BackColor = System.Drawing.Color.Transparent;
            this.checkBuff.Location = new System.Drawing.Point(12, 225);
            this.checkBuff.Name = "checkBuff";
            this.checkBuff.ShadowDepth = 1;
            this.checkBuff.Size = new System.Drawing.Size(74, 15);
            this.checkBuff.TabIndex = 2;
            this.checkBuff.Text = "Auto buff";
            this.checkBuff.UseVisualStyleBackColor = false;
            this.checkBuff.CheckedChanged += new System.EventHandler(this.config_CheckedChanged);
            // 
            // checkAttack
            // 
            this.checkAttack.AutoSize = true;
            this.checkAttack.BackColor = System.Drawing.Color.Transparent;
            this.checkAttack.Location = new System.Drawing.Point(12, 204);
            this.checkAttack.Name = "checkAttack";
            this.checkAttack.ShadowDepth = 1;
            this.checkAttack.Size = new System.Drawing.Size(177, 15);
            this.checkAttack.TabIndex = 1;
            this.checkAttack.Text = "Auto attack selected monster";
            this.checkAttack.UseVisualStyleBackColor = false;
            this.checkAttack.CheckedChanged += new System.EventHandler(this.config_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(128, 21);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Player\'s assistant";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDescription.Location = new System.Drawing.Point(12, 43);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(311, 105);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Automatically runs certain bot actions in the background.\r\nThe user will not lose" +
    " control of the character!\r\n\r\nThe bot will NOT\r\n- Walk around\r\n- Select monsters" +
    "\r\n- Pick up items";
            // 
            // separator1
            // 
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(12, 167);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(120, 10);
            this.separator1.TabIndex = 3;
            this.separator1.Text = "separator1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.checkBuff);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.checkAttack);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(765, 474);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SDUI.Controls.Label lblTitle;
        private SDUI.Controls.Label lblDescription;
        private SDUI.Controls.CheckBox checkBuff;
        private SDUI.Controls.CheckBox checkAttack;
        private SDUI.Controls.Separator separator1;
    }
}
