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
            labelName = new SDUI.Controls.Label();
            labelDescription = new SDUI.Controls.Label();
            labelVersion = new SDUI.Controls.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            buttonOk.Color = System.Drawing.Color.DodgerBlue;
            buttonOk.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonOk.ForeColor = System.Drawing.Color.White;
            buttonOk.Location = new System.Drawing.Point(12, 317);
            buttonOk.Name = "buttonOk";
            buttonOk.Radius = 6;
            buttonOk.ShadowDepth = 4F;
            buttonOk.Size = new System.Drawing.Size(110, 32);
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
            richTextBox.Location = new System.Drawing.Point(160, 57);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new System.Drawing.Size(401, 281);
            richTextBox.TabIndex = 2;
            richTextBox.Text = resources.GetString("richTextBox.Text");
            // 
            // labelName
            // 
            labelName.ApplyGradient = false;
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelName.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelName.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelName.GradientAnimation = false;
            labelName.Location = new System.Drawing.Point(160, 8);
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
            labelDescription.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelDescription.GradientAnimation = false;
            labelDescription.Location = new System.Drawing.Point(162, 33);
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
            labelVersion.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelVersion.GradientAnimation = false;
            labelVersion.Location = new System.Drawing.Point(227, 12);
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
            ClientSize = new System.Drawing.Size(588, 361);
            Controls.Add(buttonOk);
            Controls.Add(labelDescription);
            Controls.Add(labelVersion);
            Controls.Add(labelName);
            Controls.Add(richTextBox);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.Black;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(604, 400);
            MinimizeBox = false;
            Name = "AboutDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "♣";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private SDUI.Controls.Button buttonOk;
        private System.Windows.Forms.RichTextBox richTextBox;
        private SDUI.Controls.Label labelName;
        private SDUI.Controls.Label labelDescription;
        private SDUI.Controls.Label labelVersion;
    }
}
