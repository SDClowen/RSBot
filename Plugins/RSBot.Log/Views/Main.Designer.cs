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
            checkEnabled = new System.Windows.Forms.CheckBox();
            btnReset = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            checkNormal = new System.Windows.Forms.CheckBox();
            checkError = new System.Windows.Forms.CheckBox();
            checkWarning = new System.Windows.Forms.CheckBox();
            checkDebug = new System.Windows.Forms.CheckBox();
            txtLog = new System.Windows.Forms.RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // checkEnabled
            // 
            checkEnabled.AutoSize = true;
            checkEnabled.Checked = true;
            checkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            checkEnabled.Location = new System.Drawing.Point(10, 12);
            checkEnabled.Margin = new System.Windows.Forms.Padding(0);
            checkEnabled.Name = "checkEnabled";
            checkEnabled.Size = new System.Drawing.Size(85, 24);
            checkEnabled.TabIndex = 1;
            checkEnabled.Text = "Enabled";
            checkEnabled.UseVisualStyleBackColor = true;
            checkEnabled.CheckedChanged += checkEnabled_CheckedChanged;
            // 
            // btnReset
            // 
            btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnReset.AutoSize = true;
            btnReset.Location = new System.Drawing.Point(614, 8);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(92, 30);
            btnReset.TabIndex = 0;
            btnReset.Text = "Clear";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkNormal);
            panel1.Controls.Add(checkError);
            panel1.Controls.Add(checkWarning);
            panel1.Controls.Add(checkDebug);
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(checkEnabled);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(719, 46);
            panel1.TabIndex = 2;
            // 
            // checkNormal
            // 
            checkNormal.AutoSize = true;
            checkNormal.Checked = true;
            checkNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            checkNormal.Location = new System.Drawing.Point(96, 12);
            checkNormal.Margin = new System.Windows.Forms.Padding(0);
            checkNormal.Name = "checkNormal";
            checkNormal.Size = new System.Drawing.Size(81, 24);
            checkNormal.TabIndex = 6;
            checkNormal.Text = "Normal";
            checkNormal.UseVisualStyleBackColor = false;
            // 
            // checkError
            // 
            checkError.AutoSize = true;
            checkError.Checked = true;
            checkError.CheckState = System.Windows.Forms.CheckState.Checked;
            checkError.Location = new System.Drawing.Point(339, 12);
            checkError.Margin = new System.Windows.Forms.Padding(0);
            checkError.Name = "checkError";
            checkError.Size = new System.Drawing.Size(63, 24);
            checkError.TabIndex = 3;
            checkError.Text = "Error";
            checkError.UseVisualStyleBackColor = false;
            // 
            // checkWarning
            // 
            checkWarning.AutoSize = true;
            checkWarning.Checked = true;
            checkWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            checkWarning.Location = new System.Drawing.Point(253, 12);
            checkWarning.Margin = new System.Windows.Forms.Padding(0);
            checkWarning.Name = "checkWarning";
            checkWarning.Size = new System.Drawing.Size(86, 24);
            checkWarning.TabIndex = 4;
            checkWarning.Text = "Warning";
            checkWarning.UseVisualStyleBackColor = false;
            // 
            // checkDebug
            // 
            checkDebug.AutoSize = true;
            checkDebug.Checked = true;
            checkDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            checkDebug.Location = new System.Drawing.Point(177, 12);
            checkDebug.Margin = new System.Windows.Forms.Padding(0);
            checkDebug.Name = "checkDebug";
            checkDebug.Size = new System.Drawing.Size(76, 24);
            checkDebug.TabIndex = 5;
            checkDebug.Text = "Debug";
            checkDebug.UseVisualStyleBackColor = false;
            // 
            // txtLog
            // 
            txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            txtLog.Location = new System.Drawing.Point(0, 46);
            txtLog.Name = "txtLog";
            txtLog.Size = new System.Drawing.Size(719, 413);
            txtLog.TabIndex = 3;
            txtLog.Text = "";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(txtLog);
            Controls.Add(panel1);
            Name = "Main";
            Size = new System.Drawing.Size(719, 459);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox checkEnabled;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkError;
        private System.Windows.Forms.CheckBox checkWarning;
        private System.Windows.Forms.CheckBox checkDebug;
        private System.Windows.Forms.CheckBox checkNormal;
        private System.Windows.Forms.RichTextBox txtLog;
    }
}
