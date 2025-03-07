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
            buttonOk = new System.Windows.Forms.Button();
            richTextBox = new System.Windows.Forms.RichTextBox();
            labelName = new System.Windows.Forms.Label();
            labelDescription = new System.Windows.Forms.Label();
            labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.app;
            pictureBox1.Location = new System.Drawing.Point(15, 10);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(161, 161);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonOk.Location = new System.Drawing.Point(15, 382);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(138, 40);
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
            richTextBox.Location = new System.Drawing.Point(200, 71);
            richTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            
            richTextBox.Size = new System.Drawing.Size(501, 351);
            richTextBox.TabIndex = 2;
            richTextBox.Text = resources.GetString("richTextBox.Text");
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            labelName.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelName.Location = new System.Drawing.Point(200, 10);
            labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            
            labelName.Size = new System.Drawing.Size(77, 32);
            labelName.TabIndex = 4;
            labelName.Text = "RSBot";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelDescription.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelDescription.Location = new System.Drawing.Point(202, 41);
            labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            
            labelDescription.TabIndex = 4;
            labelDescription.Text = "A Open source Silkroad Online bot";
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            labelVersion.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelVersion.Location = new System.Drawing.Point(284, 15);
            labelVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new System.Drawing.Size(59, 25);
            
            labelVersion.Text = "v1.0.0";
            // 
            // AboutDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(732, 441);
            Controls.Add(buttonOk);
            Controls.Add(labelDescription);
            Controls.Add(labelVersion);
            Controls.Add(labelName);
            Controls.Add(richTextBox);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.Black;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(750, 488);
            MinimizeBox = false;
            Name = "AboutDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelVersion;
    }
}
