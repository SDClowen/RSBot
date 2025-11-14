namespace RSBot.Default.Views.Dialogs
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
            separator1 = new SDUI.Controls.Separator();
            buttonCancel = new SDUI.Controls.Button();
            buttonAccept = new SDUI.Controls.Button();
            TrainingName = new SDUI.Controls.TextBox();
            Radius = new SDUI.Controls.NumUpDown();
            labelArea = new SDUI.Controls.Label();
            labelPos = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            label1 = new SDUI.Controls.Label();
            label3 = new SDUI.Controls.Label();
            bottomPanel = new SDUI.Controls.Panel();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            bottomPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // separator1
            // 
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(66, 108);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(120, 10);
            separator1.TabIndex = 4;
            // 
            // buttonCancel
            // 
            buttonCancel.Color = System.Drawing.Color.Transparent;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(165, 6);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Radius = 6;
            buttonCancel.ShadowDepth = 4F;
            buttonCancel.Size = new System.Drawing.Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            buttonAccept.Color = System.Drawing.Color.FromArgb(33, 150, 243);
            buttonAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonAccept.ForeColor = System.Drawing.Color.White;
            buttonAccept.Location = new System.Drawing.Point(5, 6);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Radius = 6;
            buttonAccept.ShadowDepth = 4F;
            buttonAccept.Size = new System.Drawing.Size(75, 23);
            buttonAccept.TabIndex = 2;
            buttonAccept.Text = "Accept";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // TrainingName
            // 
            TrainingName.Location = new System.Drawing.Point(8, 26);
            TrainingName.MaxLength = 32767;
            TrainingName.MultiLine = false;
            TrainingName.Name = "TrainingName";
            TrainingName.PassFocusShow = false;
            TrainingName.Radius = 2;
            TrainingName.Size = new System.Drawing.Size(234, 21);
            TrainingName.TabIndex = 0;
            TrainingName.Text = "My training area";
            TrainingName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            TrainingName.UseSystemPasswordChar = false;
            // 
            // Radius
            // 
            Radius.BackColor = System.Drawing.Color.Transparent;
            Radius.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            Radius.Location = new System.Drawing.Point(8, 78);
            Radius.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            Radius.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            Radius.MinimumSize = new System.Drawing.Size(80, 25);
            Radius.Name = "Radius";
            Radius.Size = new System.Drawing.Size(234, 25);
            Radius.TabIndex = 1;
            Radius.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // labelArea
            // 
            labelArea.ApplyGradient = false;
            labelArea.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelArea.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelArea.GradientAnimation = false;
            labelArea.Location = new System.Drawing.Point(8, 145);
            labelArea.Name = "labelArea";
            labelArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            labelArea.Size = new System.Drawing.Size(235, 20);
            labelArea.TabIndex = 0;
            labelArea.Text = "< Area >";
            labelArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPos
            // 
            labelPos.ApplyGradient = false;
            labelPos.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelPos.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelPos.GradientAnimation = false;
            labelPos.Location = new System.Drawing.Point(8, 121);
            labelPos.Name = "labelPos";
            labelPos.Size = new System.Drawing.Size(234, 17);
            labelPos.TabIndex = 0;
            labelPos.Text = "<Coordinate>";
            labelPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(6, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 15);
            label2.TabIndex = 0;
            label2.Text = "Radius";
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
            label1.Location = new System.Drawing.Point(6, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(55, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(140, 20);
            label3.TabIndex = 0;
            label3.Text = "Create training area";
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = System.Drawing.Color.Transparent;
            bottomPanel.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            bottomPanel.BorderColor = System.Drawing.Color.Transparent;
            bottomPanel.Controls.Add(buttonAccept);
            bottomPanel.Controls.Add(buttonCancel);
            bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomPanel.Location = new System.Drawing.Point(1, 201);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Radius = 0;
            bottomPanel.ShadowDepth = 4F;
            bottomPanel.Size = new System.Drawing.Size(245, 35);
            bottomPanel.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(245, 35);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(TrainingName);
            panel2.Controls.Add(labelArea);
            panel2.Controls.Add(labelPos);
            panel2.Controls.Add(separator1);
            panel2.Controls.Add(Radius);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(1, 36);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(245, 165);
            panel2.TabIndex = 8;
            // 
            // CreateTrainingAreaDialog
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new System.Drawing.Size(247, 237);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(bottomPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Location = new System.Drawing.Point(0, 0);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateTrainingAreaDialog";
            Padding = new System.Windows.Forms.Padding(1);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Create training area";
            FormClosing += CreateTrainingAreaDialog_FormClosing;
            Load += CreateTrainingAreaDialog_Load;
            bottomPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);

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