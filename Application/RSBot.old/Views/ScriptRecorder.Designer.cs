namespace RSBot.Views
{
    partial class ScriptRecorder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptRecorder));
            panel1 = new System.Windows.Forms.Panel();
            btnStartStop = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            labelStatus = new System.Windows.Forms.Label();
            btnRun = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            txtScript = new System.Windows.Forms.RichTextBox();
            panel2 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            btnAddCommand = new System.Windows.Forms.Button();
            comboCommand = new System.Windows.Forms.ComboBox();
            lblCommand = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnStartStop);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(labelStatus);
            panel1.Controls.Add(btnRun);
            panel1.Controls.Add(btnClear);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(616, 66);
            panel1.TabIndex = 0;
            // 
            // btnStartStop
            // 
            btnStartStop.AutoSize = true;
            btnStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnStartStop.Location = new System.Drawing.Point(16, 19);
            btnStartStop.Margin = new System.Windows.Forms.Padding(0);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new System.Drawing.Size(76, 30);
            btnStartStop.TabIndex = 6;
            btnStartStop.TabStop = false;
            btnStartStop.Text = "RECORD";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStart_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.AutoSize = true;
            btnSave.Location = new System.Drawing.Point(503, 19);
            btnSave.Margin = new System.Windows.Forms.Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(98, 30);
            btnSave.TabIndex = 5;
            btnSave.TabStop = false;
            btnSave.Tag = "private";
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            labelStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelStatus.Location = new System.Drawing.Point(205, 24);
            labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(57, 21);
            labelStatus.TabIndex = 4;
            labelStatus.Text = "<Idle>";
            // 
            // btnRun
            // 
            btnRun.AutoSize = true;
            btnRun.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnRun.Location = new System.Drawing.Point(154, 19);
            btnRun.Name = "btnRun";
            btnRun.Size = new System.Drawing.Size(44, 30);
            btnRun.TabIndex = 3;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRunNow_Click;
            // 
            // btnClear
            // 
            btnClear.AutoSize = true;
            btnClear.Location = new System.Drawing.Point(95, 19);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(53, 30);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtScript
            // 
            txtScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            txtScript.Location = new System.Drawing.Point(0, 66);
            txtScript.Margin = new System.Windows.Forms.Padding(4);
            txtScript.Name = "txtScript";
            txtScript.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            txtScript.Size = new System.Drawing.Size(616, 539);
            txtScript.TabIndex = 1;
            txtScript.Text = "";
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.Control;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnAddCommand);
            panel2.Controls.Add(comboCommand);
            panel2.Controls.Add(lblCommand);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 605);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(616, 96);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Location = new System.Drawing.Point(25, 50);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(434, 40);
            label1.TabIndex = 3;
            label1.Text = "&Hint: Make sure you add the \"dismount\" command to your script\r\nbefore teleportations to be able to enter it";
            // 
            // btnAddCommand
            // 
            btnAddCommand.AutoSize = true;
            btnAddCommand.Location = new System.Drawing.Point(319, 10);
            btnAddCommand.Margin = new System.Windows.Forms.Padding(4);
            btnAddCommand.Name = "btnAddCommand";
            btnAddCommand.Size = new System.Drawing.Size(63, 30);
            btnAddCommand.TabIndex = 2;
            btnAddCommand.Text = "Add";
            btnAddCommand.UseVisualStyleBackColor = true;
            btnAddCommand.Click += btnAddCommand_Click;
            // 
            // comboCommand
            // 
            comboCommand.DropDownHeight = 100;
            comboCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboCommand.FormattingEnabled = true;
            comboCommand.IntegralHeight = false;
            comboCommand.ItemHeight = 20;
            comboCommand.Location = new System.Drawing.Point(116, 11);
            comboCommand.Margin = new System.Windows.Forms.Padding(4);
            comboCommand.Name = "comboCommand";
            comboCommand.Size = new System.Drawing.Size(194, 28);
            comboCommand.TabIndex = 1;
            // 
            // lblCommand
            // 
            lblCommand.AutoSize = true;
            lblCommand.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblCommand.Location = new System.Drawing.Point(25, 15);
            lblCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCommand.Name = "lblCommand";
            lblCommand.Size = new System.Drawing.Size(81, 20);
            lblCommand.TabIndex = 0;
            lblCommand.Text = "Command:";
            // 
            // ScriptRecorder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(616, 701);
            Controls.Add(txtScript);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "ScriptRecorder";
            ShowInTaskbar = false;
            Text = "RSBot - File recorder";
            FormClosed += ScriptRecorder_FormClosed;
            Load += ScriptRecorder_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtScript;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddCommand;
        private System.Windows.Forms.ComboBox comboCommand;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label label1;
    }
}