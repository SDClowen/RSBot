namespace RSBot.Log.Views
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
            this.checkEnabled = new System.Windows.Forms.CheckBox();
            this.btnReset = new RSBot.Theme.Material.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkNormal = new System.Windows.Forms.CheckBox();
            this.checkError = new System.Windows.Forms.CheckBox();
            this.checkWarning = new System.Windows.Forms.CheckBox();
            this.checkDebug = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkEnabled
            // 
            this.checkEnabled.AutoSize = true;
            this.checkEnabled.Location = new System.Drawing.Point(14, 17);
            this.checkEnabled.Name = "checkEnabled";
            this.checkEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkEnabled.TabIndex = 1;
            this.checkEnabled.Text = "Enabled";
            this.checkEnabled.UseVisualStyleBackColor = true;
            this.checkEnabled.CheckedChanged += new System.EventHandler(this.checkEnabled_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Depth = 0;
            this.btnReset.Icon = null;
            this.btnReset.Location = new System.Drawing.Point(627, 17);
            this.btnReset.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.Primary = false;
            this.btnReset.Raised = false;
            this.btnReset.SingleColor = System.Drawing.Color.Empty;
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkNormal);
            this.panel1.Controls.Add(this.checkError);
            this.panel1.Controls.Add(this.checkWarning);
            this.panel1.Controls.Add(this.checkDebug);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.checkEnabled);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 52);
            this.panel1.TabIndex = 2;
            // 
            // checkNormal
            // 
            this.checkNormal.AutoSize = true;
            this.checkNormal.Checked = true;
            this.checkNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNormal.Location = new System.Drawing.Point(85, 17);
            this.checkNormal.Name = "checkNormal";
            this.checkNormal.Size = new System.Drawing.Size(59, 17);
            this.checkNormal.TabIndex = 6;
            this.checkNormal.Text = "Normal";
            this.checkNormal.UseVisualStyleBackColor = true;
            // 
            // checkError
            // 
            this.checkError.AutoSize = true;
            this.checkError.Checked = true;
            this.checkError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkError.Location = new System.Drawing.Point(286, 17);
            this.checkError.Name = "checkError";
            this.checkError.Size = new System.Drawing.Size(48, 17);
            this.checkError.TabIndex = 3;
            this.checkError.Text = "Error";
            this.checkError.UseVisualStyleBackColor = true;
            // 
            // checkWarning
            // 
            this.checkWarning.AutoSize = true;
            this.checkWarning.Checked = true;
            this.checkWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkWarning.Location = new System.Drawing.Point(214, 17);
            this.checkWarning.Name = "checkWarning";
            this.checkWarning.Size = new System.Drawing.Size(66, 17);
            this.checkWarning.TabIndex = 4;
            this.checkWarning.Text = "Warning";
            this.checkWarning.UseVisualStyleBackColor = true;
            // 
            // checkDebug
            // 
            this.checkDebug.AutoSize = true;
            this.checkDebug.Checked = true;
            this.checkDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDebug.Location = new System.Drawing.Point(150, 17);
            this.checkDebug.Name = "checkDebug";
            this.checkDebug.Size = new System.Drawing.Size(58, 17);
            this.checkDebug.TabIndex = 5;
            this.checkDebug.Text = "Debug";
            this.checkDebug.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 52);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(719, 407);
            this.txtLog.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(719, 459);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Theme.Material.Button btnReset;
        private System.Windows.Forms.CheckBox checkEnabled;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.CheckBox checkError;
        private System.Windows.Forms.CheckBox checkWarning;
        private System.Windows.Forms.CheckBox checkDebug;
        private System.Windows.Forms.CheckBox checkNormal;
    }
}
