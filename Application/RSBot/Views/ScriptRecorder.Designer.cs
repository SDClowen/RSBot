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
            panel1 = new SDUI.Controls.Panel();
            btnStartStop = new SDUI.Controls.Button();
            btnSave = new SDUI.Controls.Button();
            labelStatus = new SDUI.Controls.Label();
            btnRun = new SDUI.Controls.Button();
            btnClear = new SDUI.Controls.Button();
            txtScript = new System.Windows.Forms.RichTextBox();
            panel2 = new SDUI.Controls.Panel();
            label1 = new SDUI.Controls.Label();
            btnAddCommand = new SDUI.Controls.Button();
            comboCommand = new SDUI.Controls.ComboBox();
            lblCommand = new SDUI.Controls.Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(btnStartStop);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(labelStatus);
            panel1.Controls.Add(btnRun);
            panel1.Controls.Add(btnClear);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(1, 32);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(491, 53);
            panel1.TabIndex = 0;
            // 
            // btnStartStop
            // 
            btnStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnStartStop.BackColor = System.Drawing.Color.Gold;
            btnStartStop.Color = System.Drawing.Color.Navy;
            btnStartStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStartStop.ForeColor = System.Drawing.Color.White;
            btnStartStop.Location = new System.Drawing.Point(13, 15);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Radius = 8;
            btnStartStop.ShadowDepth = 4F;
            btnStartStop.Size = new System.Drawing.Size(74, 27);
            btnStartStop.TabIndex = 6;
            btnStartStop.TabStop = false;
            btnStartStop.Tag = "private";
            btnStartStop.Text = "RECORD";
            btnStartStop.UseVisualStyleBackColor = false;
            btnStartStop.Click += btnStart_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnSave.Color = System.Drawing.Color.FromArgb(56, 155, 90);
            btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(384, 15);
            btnSave.Name = "btnSave";
            btnSave.Radius = 8;
            btnSave.ShadowDepth = 4F;
            btnSave.Size = new System.Drawing.Size(95, 27);
            btnSave.TabIndex = 5;
            btnSave.TabStop = false;
            btnSave.Tag = "private";
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // labelStatus
            // 
            labelStatus.ApplyGradient = false;
            labelStatus.AutoSize = true;
            labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelStatus.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelStatus.GradientAnimation = false;
            labelStatus.Location = new System.Drawing.Point(288, 19);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(47, 17);
            labelStatus.TabIndex = 4;
            labelStatus.Text = "<Idle>";
            // 
            // btnRun
            // 
            btnRun.Color = System.Drawing.Color.Transparent;
            btnRun.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRun.ForeColor = System.Drawing.Color.Green;
            btnRun.Location = new System.Drawing.Point(174, 15);
            btnRun.Name = "btnRun";
            btnRun.Radius = 6;
            btnRun.ShadowDepth = 4F;
            btnRun.Size = new System.Drawing.Size(30, 27);
            btnRun.TabIndex = 3;
            btnRun.Text = "►";
            btnRun.TextAlign = System.Drawing.ContentAlignment.TopRight;
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRunNow_Click;
            // 
            // btnClear
            // 
            btnClear.Color = System.Drawing.Color.RosyBrown;
            btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnClear.ForeColor = System.Drawing.Color.White;
            btnClear.Location = new System.Drawing.Point(93, 15);
            btnClear.Name = "btnClear";
            btnClear.Radius = 8;
            btnClear.ShadowDepth = 4F;
            btnClear.Size = new System.Drawing.Size(75, 27);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtScript
            // 
            txtScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            txtScript.Location = new System.Drawing.Point(1, 85);
            txtScript.Name = "txtScript";
            txtScript.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            txtScript.Size = new System.Drawing.Size(491, 398);
            txtScript.TabIndex = 1;
            txtScript.Text = "";
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel2.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            panel2.BorderColor = System.Drawing.Color.Transparent;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnAddCommand);
            panel2.Controls.Add(comboCommand);
            panel2.Controls.Add(lblCommand);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(1, 483);
            panel2.Name = "panel2";
            panel2.Radius = 0;
            panel2.ShadowDepth = 4F;
            panel2.Size = new System.Drawing.Size(491, 77);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(20, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(351, 30);
            label1.TabIndex = 3;
            label1.Text = "&Hint: Make sure you add the \"dismount\" command to your script\r\nbefore teleportations to be able to enter it";
            // 
            // btnAddCommand
            // 
            btnAddCommand.Color = System.Drawing.Color.FromArgb(33, 150, 243);
            btnAddCommand.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAddCommand.ForeColor = System.Drawing.Color.White;
            btnAddCommand.Location = new System.Drawing.Point(255, 8);
            btnAddCommand.Name = "btnAddCommand";
            btnAddCommand.Radius = 8;
            btnAddCommand.ShadowDepth = 4F;
            btnAddCommand.Size = new System.Drawing.Size(93, 27);
            btnAddCommand.TabIndex = 2;
            btnAddCommand.Text = "Add";
            btnAddCommand.UseVisualStyleBackColor = true;
            btnAddCommand.Click += btnAddCommand_Click;
            // 
            // comboCommand
            // 
            comboCommand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboCommand.DropDownHeight = 100;
            comboCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboCommand.FormattingEnabled = true;
            comboCommand.IntegralHeight = false;
            comboCommand.ItemHeight = 17;
            comboCommand.Location = new System.Drawing.Point(93, 9);
            comboCommand.Name = "comboCommand";
            comboCommand.Radius = 5;
            comboCommand.ShadowDepth = 4F;
            comboCommand.Size = new System.Drawing.Size(156, 23);
            comboCommand.TabIndex = 1;
            // 
            // lblCommand
            // 
            lblCommand.ApplyGradient = false;
            lblCommand.AutoSize = true;
            lblCommand.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblCommand.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblCommand.GradientAnimation = false;
            lblCommand.Location = new System.Drawing.Point(20, 12);
            lblCommand.Name = "lblCommand";
            lblCommand.Size = new System.Drawing.Size(67, 15);
            lblCommand.TabIndex = 0;
            lblCommand.Text = "Command:";
            // 
            // ScriptRecorder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(251, 251, 251);
            ClientSize = new System.Drawing.Size(493, 561);
            ControlBox = false;
            Controls.Add(txtScript);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Location = new System.Drawing.Point(0, 0);
            MaximizeBox = false;
            Name = "ScriptRecorder";
            Padding = new System.Windows.Forms.Padding(1, 32, 1, 1);
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

        private SDUI.Controls.Panel panel1;
        private System.Windows.Forms.RichTextBox txtScript;
        private SDUI.Controls.Button btnClear;
        private SDUI.Controls.Button btnRun;
        private SDUI.Controls.Label labelStatus;
        private SDUI.Controls.Panel panel2;
        private SDUI.Controls.Button btnAddCommand;
        private SDUI.Controls.ComboBox comboCommand;
        private SDUI.Controls.Label lblCommand;
        private SDUI.Controls.Button btnSave;
        private SDUI.Controls.Button btnStartStop;
        private SDUI.Controls.Label label1;
    }
}