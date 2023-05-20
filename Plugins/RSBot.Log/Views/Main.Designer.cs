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
            checkEnabled = new SDUI.Controls.CheckBox();
            btnReset = new SDUI.Controls.Button();
            panel1 = new SDUI.Controls.Panel();
            checkNormal = new SDUI.Controls.CheckBox();
            checkError = new SDUI.Controls.CheckBox();
            checkWarning = new SDUI.Controls.CheckBox();
            checkDebug = new SDUI.Controls.CheckBox();
            txtLog = new System.Windows.Forms.RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // checkEnabled
            // 
            checkEnabled.AutoSize = true;
            checkEnabled.BackColor = System.Drawing.Color.Transparent;
            checkEnabled.Depth = 0;
            checkEnabled.Location = new System.Drawing.Point(14, 8);
            checkEnabled.Margin = new System.Windows.Forms.Padding(0);
            checkEnabled.MouseLocation = new System.Drawing.Point(-1, -1);
            checkEnabled.Name = "checkEnabled";
            checkEnabled.Ripple = true;
            checkEnabled.Size = new System.Drawing.Size(73, 30);
            checkEnabled.TabIndex = 1;
            checkEnabled.Text = "Enabled";
            checkEnabled.UseVisualStyleBackColor = false;
            checkEnabled.CheckedChanged += checkEnabled_CheckedChanged;
            // 
            // btnReset
            // 
            btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnReset.Color = System.Drawing.Color.Transparent;
            btnReset.Location = new System.Drawing.Point(624, 13);
            btnReset.Name = "btnReset";
            btnReset.Radius = 6;
            btnReset.ShadowDepth = 4F;
            btnReset.Size = new System.Drawing.Size(75, 23);
            btnReset.TabIndex = 0;
            btnReset.Text = "Clear";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(checkNormal);
            panel1.Controls.Add(checkError);
            panel1.Controls.Add(checkWarning);
            panel1.Controls.Add(checkDebug);
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(checkEnabled);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(719, 46);
            panel1.TabIndex = 2;
            // 
            // checkNormal
            // 
            checkNormal.AutoSize = true;
            checkNormal.BackColor = System.Drawing.Color.Transparent;
            checkNormal.Checked = true;
            checkNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            checkNormal.Depth = 0;
            checkNormal.Location = new System.Drawing.Point(100, 8);
            checkNormal.Margin = new System.Windows.Forms.Padding(0);
            checkNormal.MouseLocation = new System.Drawing.Point(-1, -1);
            checkNormal.Name = "checkNormal";
            checkNormal.Ripple = true;
            checkNormal.Size = new System.Drawing.Size(70, 30);
            checkNormal.TabIndex = 6;
            checkNormal.Text = "Normal";
            checkNormal.UseVisualStyleBackColor = false;
            // 
            // checkError
            // 
            checkError.AutoSize = true;
            checkError.BackColor = System.Drawing.Color.Transparent;
            checkError.Checked = true;
            checkError.CheckState = System.Windows.Forms.CheckState.Checked;
            checkError.Depth = 0;
            checkError.Location = new System.Drawing.Point(332, 8);
            checkError.Margin = new System.Windows.Forms.Padding(0);
            checkError.MouseLocation = new System.Drawing.Point(-1, -1);
            checkError.Name = "checkError";
            checkError.Ripple = true;
            checkError.Size = new System.Drawing.Size(56, 30);
            checkError.TabIndex = 3;
            checkError.Text = "Error";
            checkError.UseVisualStyleBackColor = false;
            // 
            // checkWarning
            // 
            checkWarning.AutoSize = true;
            checkWarning.BackColor = System.Drawing.Color.Transparent;
            checkWarning.Checked = true;
            checkWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            checkWarning.Depth = 0;
            checkWarning.Location = new System.Drawing.Point(249, 8);
            checkWarning.Margin = new System.Windows.Forms.Padding(0);
            checkWarning.MouseLocation = new System.Drawing.Point(-1, -1);
            checkWarning.Name = "checkWarning";
            checkWarning.Ripple = true;
            checkWarning.Size = new System.Drawing.Size(76, 30);
            checkWarning.TabIndex = 4;
            checkWarning.Text = "Warning";
            checkWarning.UseVisualStyleBackColor = false;
            // 
            // checkDebug
            // 
            checkDebug.AutoSize = true;
            checkDebug.BackColor = System.Drawing.Color.Transparent;
            checkDebug.Checked = true;
            checkDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            checkDebug.Depth = 0;
            checkDebug.Location = new System.Drawing.Point(175, 8);
            checkDebug.Margin = new System.Windows.Forms.Padding(0);
            checkDebug.MouseLocation = new System.Drawing.Point(-1, -1);
            checkDebug.Name = "checkDebug";
            checkDebug.Ripple = true;
            checkDebug.Size = new System.Drawing.Size(66, 30);
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
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(txtLog);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "Main";
            Size = new System.Drawing.Size(719, 459);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private SDUI.Controls.Button btnReset;
        private SDUI.Controls.CheckBox checkEnabled;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.CheckBox checkError;
        private SDUI.Controls.CheckBox checkWarning;
        private SDUI.Controls.CheckBox checkDebug;
        private SDUI.Controls.CheckBox checkNormal;
        private System.Windows.Forms.RichTextBox txtLog;
    }
}
