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
            this.checkEnabled = new SDUI.Controls.CheckBox();
            this.btnReset = new SDUI.Controls.Button();
            this.panel1 = new SDUI.Controls.Panel();
            this.checkNormal = new SDUI.Controls.CheckBox();
            this.checkError = new SDUI.Controls.CheckBox();
            this.checkWarning = new SDUI.Controls.CheckBox();
            this.checkDebug = new SDUI.Controls.CheckBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkEnabled
            // 
            this.checkEnabled.BackColor = System.Drawing.Color.Transparent;
            this.checkEnabled.Checked = false;
            this.checkEnabled.Location = new System.Drawing.Point(14, 17);
            this.checkEnabled.Name = "checkEnabled";
            this.checkEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkEnabled.TabIndex = 1;
            this.checkEnabled.Text = "Enabled";
            this.checkEnabled.CheckedChanged += new System.EventHandler(this.checkEnabled_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Color = System.Drawing.Color.Transparent;
            this.btnReset.Location = new System.Drawing.Point(624, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Controls.Add(this.checkNormal);
            this.panel1.Controls.Add(this.checkError);
            this.panel1.Controls.Add(this.checkWarning);
            this.panel1.Controls.Add(this.checkDebug);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.checkEnabled);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(719, 52);
            this.panel1.TabIndex = 2;
            // 
            // checkNormal
            // 
            this.checkNormal.BackColor = System.Drawing.Color.Transparent;
            this.checkNormal.Checked = true;
            this.checkNormal.Location = new System.Drawing.Point(100, 17);
            this.checkNormal.Name = "checkNormal";
            this.checkNormal.Size = new System.Drawing.Size(59, 17);
            this.checkNormal.TabIndex = 6;
            this.checkNormal.Text = "Normal";
            // 
            // checkError
            // 
            this.checkError.BackColor = System.Drawing.Color.Transparent;
            this.checkError.Checked = true;
            this.checkError.Location = new System.Drawing.Point(332, 17);
            this.checkError.Name = "checkError";
            this.checkError.Size = new System.Drawing.Size(48, 17);
            this.checkError.TabIndex = 3;
            this.checkError.Text = "Error";
            // 
            // checkWarning
            // 
            this.checkWarning.BackColor = System.Drawing.Color.Transparent;
            this.checkWarning.Checked = true;
            this.checkWarning.Location = new System.Drawing.Point(249, 17);
            this.checkWarning.Name = "checkWarning";
            this.checkWarning.Size = new System.Drawing.Size(66, 17);
            this.checkWarning.TabIndex = 4;
            this.checkWarning.Text = "Warning";
            // 
            // checkDebug
            // 
            this.checkDebug.BackColor = System.Drawing.Color.Transparent;
            this.checkDebug.Checked = true;
            this.checkDebug.Location = new System.Drawing.Point(175, 17);
            this.checkDebug.Name = "checkDebug";
            this.checkDebug.Size = new System.Drawing.Size(58, 17);
            this.checkDebug.TabIndex = 5;
            this.checkDebug.Text = "Debug";
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 52);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(719, 407);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
            this.Size = new System.Drawing.Size(719, 459);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
