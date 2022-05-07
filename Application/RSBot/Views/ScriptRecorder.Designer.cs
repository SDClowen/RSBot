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
            this.labelStatus = new SDUI.Controls.Label();
            this.btnRunNow = new SDUI.Controls.Button();
            this.btnSave = new SDUI.Controls.Button();
            this.btnClear = new SDUI.Controls.Button();
            this.btnStart = new SDUI.Controls.Button();
            this.txtScript = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.btnRunNow);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(543, 43);
            this.panel1.TabIndex = 0;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(313, 13);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(42, 15);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "<Idle>";
            // 
            // btnRunNow
            // 
            this.btnRunNow.Color = System.Drawing.Color.Transparent;
            this.btnRunNow.Location = new System.Drawing.Point(174, 11);
            this.btnRunNow.Name = "btnRunNow";
            this.btnRunNow.Radius = 2;
            this.btnRunNow.Size = new System.Drawing.Size(75, 23);
            this.btnRunNow.TabIndex = 3;
            this.btnRunNow.Text = "Run now";
            this.btnRunNow.UseVisualStyleBackColor = true;
            this.btnRunNow.Click += new System.EventHandler(this.btnRunNow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Color = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(456, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 2;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Color = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(93, 11);
            this.btnClear.Name = "btnClear";
            this.btnClear.Radius = 2;
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStart
            // 
            this.btnStart.Color = System.Drawing.Color.Transparent;
            this.btnStart.Location = new System.Drawing.Point(12, 11);
            this.btnStart.Name = "btnStart";
            this.btnStart.Radius = 2;
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtScript
            // 
            this.txtScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(1, 44);
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtScript.Size = new System.Drawing.Size(543, 461);
            this.txtScript.TabIndex = 1;
            this.txtScript.Text = "";
            // 
            // ScriptRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(545, 506);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptRecorder";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.Text = "RSBot - Script recorder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScriptRecorder_FormClosed);
            this.Load += new System.EventHandler(this.ScriptRecorder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SDUI.Controls.Panel panel1;
        private System.Windows.Forms.RichTextBox txtScript;
        private SDUI.Controls.Button btnStart;
        private SDUI.Controls.Button btnSave;
        private SDUI.Controls.Button btnClear;
        private SDUI.Controls.Button btnRunNow;
        private SDUI.Controls.Label labelStatus;
    }
}