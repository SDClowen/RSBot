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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRunNow = new Theme.Material.Button();
            this.btnSave = new Theme.Material.Button();
            this.btnClear = new Theme.Material.Button();
            this.btnStart = new Theme.Material.Button();
            this.txtScript = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRunNow);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 43);
            this.panel1.TabIndex = 0;
            // 
            // btnRunNow
            // 
            this.btnRunNow.Depth = 0;
            this.btnRunNow.Icon = null;
            this.btnRunNow.Location = new System.Drawing.Point(174, 9);
            this.btnRunNow.MouseState = Theme.IMatMouseState.HOVER;
            this.btnRunNow.Name = "btnRunNow";
            this.btnRunNow.Primary = false;
            this.btnRunNow.Raised = false;
            this.btnRunNow.Size = new System.Drawing.Size(75, 23);
            this.btnRunNow.TabIndex = 3;
            this.btnRunNow.Text = "Run now";
            this.btnRunNow.UseVisualStyleBackColor = true;
            this.btnRunNow.Click += new System.EventHandler(this.btnRunNow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Depth = 0;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(464, 9);
            this.btnSave.MouseState = Theme.IMatMouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Raised = true;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Depth = 0;
            this.btnClear.Icon = null;
            this.btnClear.Location = new System.Drawing.Point(93, 9);
            this.btnClear.MouseState = Theme.IMatMouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.Primary = false;
            this.btnClear.Raised = false;
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStart
            // 
            this.btnStart.Depth = 0;
            this.btnStart.Icon = null;
            this.btnStart.Location = new System.Drawing.Point(12, 9);
            this.btnStart.MouseState = Theme.IMatMouseState.HOVER;
            this.btnStart.Name = "btnStart";
            this.btnStart.Primary = false;
            this.btnStart.Raised = false;
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(0, 43);
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtScript.Size = new System.Drawing.Size(551, 446);
            this.txtScript.TabIndex = 1;
            this.txtScript.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(551, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(26, 17);
            this.lblStatus.Text = "Idle";
            // 
            // ScriptRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(551, 511);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScriptRecorder";
            this.Text = "RSBot - Script recorder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScriptRecorder_FormClosed);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtScript;
        private Theme.Material.Button btnStart;
        private Theme.Material.Button btnSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private Theme.Material.Button btnClear;
        private Theme.Material.Button btnRunNow;
    }
}