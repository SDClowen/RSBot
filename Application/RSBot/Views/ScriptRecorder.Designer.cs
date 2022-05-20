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
            this.panel1 = new SDUI.Controls.Panel();
            this.btnStartStop = new SDUI.Controls.Button();
            this.btnSave = new SDUI.Controls.Button();
            this.labelStatus = new SDUI.Controls.Label();
            this.btnRun = new SDUI.Controls.Button();
            this.btnClear = new SDUI.Controls.Button();
            this.txtScript = new System.Windows.Forms.RichTextBox();
            this.panel2 = new SDUI.Controls.Panel();
            this.btnAddCommand = new SDUI.Controls.Button();
            this.comboCommand = new SDUI.Controls.ComboBox();
            this.lblCommand = new SDUI.Controls.Label();
            this.label1 = new SDUI.Controls.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Controls.Add(this.btnStartStop);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(543, 53);
            this.panel1.TabIndex = 0;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartStop.BackColor = System.Drawing.Color.Gold;
            this.btnStartStop.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStartStop.ForeColor = System.Drawing.Color.White;
            this.btnStartStop.Location = new System.Drawing.Point(13, 15);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Radius = 2;
            this.btnStartStop.Size = new System.Drawing.Size(74, 23);
            this.btnStartStop.TabIndex = 6;
            this.btnStartStop.TabStop = false;
            this.btnStartStop.Tag = "private";
            this.btnStartStop.Text = "RECORD";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Color = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(155)))), ((int)(((byte)(90)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(436, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 2;
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "private";
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(288, 19);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(42, 15);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "<Idle>";
            // 
            // btnRun
            // 
            this.btnRun.Color = System.Drawing.Color.Transparent;
            this.btnRun.ForeColor = System.Drawing.Color.Green;
            this.btnRun.Location = new System.Drawing.Point(174, 15);
            this.btnRun.Name = "btnRun";
            this.btnRun.Radius = 2;
            this.btnRun.Size = new System.Drawing.Size(24, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "▶";
            this.btnRun.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRunNow_Click);
            // 
            // btnClear
            // 
            this.btnClear.Color = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(93, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Radius = 2;
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtScript
            // 
            this.txtScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(1, 54);
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(543, 465);
            this.txtScript.TabIndex = 1;
            this.txtScript.Text = "";
            // 
            // panel2
            // 
            this.panel2.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnAddCommand);
            this.panel2.Controls.Add(this.comboCommand);
            this.panel2.Controls.Add(this.lblCommand);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 519);
            this.panel2.Name = "panel2";
            this.panel2.Radius = 1;
            this.panel2.Size = new System.Drawing.Size(543, 83);
            this.panel2.TabIndex = 2;
            // 
            // btnAddCommand
            // 
            this.btnAddCommand.Color = System.Drawing.Color.Transparent;
            this.btnAddCommand.Location = new System.Drawing.Point(255, 15);
            this.btnAddCommand.Name = "btnAddCommand";
            this.btnAddCommand.Radius = 2;
            this.btnAddCommand.Size = new System.Drawing.Size(75, 23);
            this.btnAddCommand.TabIndex = 2;
            this.btnAddCommand.Text = "Add";
            this.btnAddCommand.UseVisualStyleBackColor = true;
            this.btnAddCommand.Click += new System.EventHandler(this.btnAddCommand_Click);
            // 
            // comboCommand
            // 
            this.comboCommand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboCommand.DropDownHeight = 100;
            this.comboCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCommand.FormattingEnabled = true;
            this.comboCommand.IntegralHeight = false;
            this.comboCommand.ItemHeight = 17;
            this.comboCommand.Location = new System.Drawing.Point(93, 16);
            this.comboCommand.Name = "comboCommand";
            this.comboCommand.Size = new System.Drawing.Size(156, 23);
            this.comboCommand.TabIndex = 1;
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(20, 19);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(67, 15);
            this.lblCommand.TabIndex = 0;
            this.lblCommand.Text = "Command:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Hint: Make sure you add the \"dismount\" command to your script\r\nbefore teleportat" +
    "ions to be able to enter it";
            // 
            // ScriptRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(545, 603);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptRecorder";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "RSBot - File recorder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScriptRecorder_FormClosed);
            this.Load += new System.EventHandler(this.ScriptRecorder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

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