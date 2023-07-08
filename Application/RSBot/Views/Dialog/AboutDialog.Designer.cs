namespace RSBot.Views
{
    partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            buttonOk = new SDUI.Controls.Button();
            richTextBox = new System.Windows.Forms.RichTextBox();
            bottomPanel = new SDUI.Controls.Panel();
            labelName = new SDUI.Controls.Label();
            labelDescription = new SDUI.Controls.Label();
            labelVersion = new SDUI.Controls.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.app;
            pictureBox1.Location = new System.Drawing.Point(12, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(129, 129);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonOk
            // 
            buttonOk.Color = System.Drawing.Color.Transparent;
            buttonOk.Location = new System.Drawing.Point(243, 8);
            buttonOk.Name = "buttonOk";
            buttonOk.Radius = 2;
            buttonOk.ShadowDepth = 4F;
            buttonOk.Size = new System.Drawing.Size(75, 23);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // richTextBox
            // 
            richTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox.ForeColor = System.Drawing.Color.Olive;
            richTextBox.Location = new System.Drawing.Point(147, 57);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new System.Drawing.Size(402, 158);
            richTextBox.TabIndex = 2;
            richTextBox.Text = resources.GetString("richTextBox.Text");
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = System.Drawing.Color.Transparent;
            bottomPanel.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            bottomPanel.BorderColor = System.Drawing.Color.Transparent;
            bottomPanel.Controls.Add(buttonOk);
            bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomPanel.Location = new System.Drawing.Point(0, 295);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Radius = 0;
            bottomPanel.ShadowDepth = 4F;
            bottomPanel.Size = new System.Drawing.Size(573, 38);
            bottomPanel.TabIndex = 3;
            // 
            // labelName
            // 
            labelName.ApplyGradient = false;
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelName.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelName.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            labelName.GradientAnimation = false;
            labelName.Location = new System.Drawing.Point(147, 8);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(61, 25);
            labelName.TabIndex = 4;
            labelName.Text = "RSBot";
            // 
            // labelDescription
            // 
            labelDescription.ApplyGradient = false;
            labelDescription.AutoSize = true;
            labelDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelDescription.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelDescription.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            labelDescription.GradientAnimation = false;
            labelDescription.Location = new System.Drawing.Point(149, 33);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new System.Drawing.Size(211, 17);
            labelDescription.TabIndex = 4;
            labelDescription.Text = "A Open source Silkroad Online bot";
            // 
            // labelVersion
            // 
            labelVersion.ApplyGradient = false;
            labelVersion.AutoSize = true;
            labelVersion.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelVersion.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelVersion.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            labelVersion.GradientAnimation = false;
            labelVersion.Location = new System.Drawing.Point(214, 12);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new System.Drawing.Size(46, 19);
            labelVersion.TabIndex = 4;
            labelVersion.Text = "v1.0.0";
            // 
            // AboutDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(573, 333);
            Controls.Add(labelDescription);
            Controls.Add(labelVersion);
            Controls.Add(labelName);
            Controls.Add(bottomPanel);
            Controls.Add(richTextBox);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.Black;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private SDUI.Controls.Button buttonOk;
        private System.Windows.Forms.RichTextBox richTextBox;
        private SDUI.Controls.Panel bottomPanel;
        private SDUI.Controls.Label labelName;
        private SDUI.Controls.Label labelDescription;
        private SDUI.Controls.Label labelVersion;
    }
}
