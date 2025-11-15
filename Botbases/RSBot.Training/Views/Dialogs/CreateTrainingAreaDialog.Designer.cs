namespace RSBot.Training.Views.Dialogs
{
    partial class CreateTrainingAreaDialog
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
            this.separator1 = new SDUI.Controls.Separator();
            this.buttonCancel = new SDUI.Controls.Button();
            this.buttonAccept = new SDUI.Controls.Button();
            this.TrainingName = new SDUI.Controls.TextBox();
            this.Radius = new SDUI.Controls.NumUpDown();
            this.labelArea = new SDUI.Controls.Label();
            this.labelPos = new SDUI.Controls.Label();
            this.label2 = new SDUI.Controls.Label();
            this.label1 = new SDUI.Controls.Label();
            this.label3 = new SDUI.Controls.Label();
            this.bottomPanel = new SDUI.Controls.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // separator1
            // 
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(66, 108);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(120, 10);
            this.separator1.TabIndex = 4;
            this.separator1.Text = "separator1";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Color = System.Drawing.Color.Transparent;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(165, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Radius = 6;
            this.buttonCancel.ShadowDepth = 4F;
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.buttonAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAccept.ForeColor = System.Drawing.Color.White;
            this.buttonAccept.Location = new System.Drawing.Point(5, 6);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Radius = 6;
            this.buttonAccept.ShadowDepth = 4F;
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // TrainingName
            // 
            this.TrainingName.Location = new System.Drawing.Point(8, 26);
            this.TrainingName.MaxLength = 32767;
            this.TrainingName.MultiLine = false;
            this.TrainingName.Name = "TrainingName";
            this.TrainingName.Radius = 2;
            this.TrainingName.Size = new System.Drawing.Size(234, 21);
            this.TrainingName.TabIndex = 0;
            this.TrainingName.Text = "My training area";
            this.TrainingName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.TrainingName.UseSystemPasswordChar = false;
            // 
            // Radius
            // 
            this.Radius.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Radius.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Radius.Location = new System.Drawing.Point(8, 78);
            this.Radius.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(234, 23);
            this.Radius.TabIndex = 1;
            this.Radius.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // labelArea
            // 
            this.labelArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelArea.Location = new System.Drawing.Point(8, 145);
            this.labelArea.Name = "labelArea";
            this.labelArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelArea.Size = new System.Drawing.Size(235, 20);
            this.labelArea.TabIndex = 0;
            this.labelArea.Text = "< Area >";
            this.labelArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPos
            // 
            this.labelPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPos.Location = new System.Drawing.Point(8, 121);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(234, 17);
            this.labelPos.TabIndex = 0;
            this.labelPos.Text = "<Coordinate>";
            this.labelPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Radius";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(55, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Create training area";
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bottomPanel.BorderColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Controls.Add(this.buttonAccept);
            this.bottomPanel.Controls.Add(this.buttonCancel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(1, 207);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Radius = 0;
            this.bottomPanel.ShadowDepth = 4F;
            this.bottomPanel.Size = new System.Drawing.Size(251, 35);
            this.bottomPanel.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 35);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TrainingName);
            this.panel2.Controls.Add(this.labelArea);
            this.panel2.Controls.Add(this.labelPos);
            this.panel2.Controls.Add(this.separator1);
            this.panel2.Controls.Add(this.Radius);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 171);
            this.panel2.TabIndex = 8;
            // 
            // CreateTrainingAreaDialog
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(253, 243);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateTrainingAreaDialog";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create training area";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateTrainingAreaDialog_FormClosing);
            this.Load += new System.EventHandler(this.CreateTrainingAreaDialog_Load);
            this.bottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SDUI.Controls.GroupBox groupBox;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Button buttonCancel;
        private SDUI.Controls.Button buttonAccept;
        public SDUI.Controls.TextBox TrainingName;
        public SDUI.Controls.NumUpDown Radius;
        private SDUI.Controls.Label labelPos;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.Label labelArea;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.Panel bottomPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}