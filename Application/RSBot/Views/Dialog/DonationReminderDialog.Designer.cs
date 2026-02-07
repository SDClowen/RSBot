namespace RSBot.Views.Dialog
{
    partial class DonationReminderDialog
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
            btnBuyMeCoffee = new SDUI.Controls.Button();
            btnGitHubSponsors = new SDUI.Controls.Button();
            btnPatreon = new SDUI.Controls.Button();
            lblMessage = new SDUI.Controls.Label();
            lblTitle = new SDUI.Controls.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            labelOr = new SDUI.Controls.Label();
            separator1 = new SDUI.Controls.Separator();
            separator2 = new SDUI.Controls.Separator();
            pictureBoxMaxicardImage = new System.Windows.Forms.PictureBox();
            buttonClose = new SDUI.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMaxicardImage).BeginInit();
            SuspendLayout();
            // 
            // btnBuyMeCoffee
            // 
            btnBuyMeCoffee.Color = System.Drawing.Color.FromArgb(255, 221, 0);
            btnBuyMeCoffee.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuyMeCoffee.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            btnBuyMeCoffee.ForeColor = System.Drawing.Color.Black;
            btnBuyMeCoffee.Location = new System.Drawing.Point(32, 341);
            btnBuyMeCoffee.Margin = new System.Windows.Forms.Padding(4);
            btnBuyMeCoffee.Name = "btnBuyMeCoffee";
            btnBuyMeCoffee.Radius = 10;
            btnBuyMeCoffee.ShadowDepth = 10F;
            btnBuyMeCoffee.Size = new System.Drawing.Size(194, 56);
            btnBuyMeCoffee.TabIndex = 0;
            btnBuyMeCoffee.Text = "Buy Me a Coffee";
            btnBuyMeCoffee.UseVisualStyleBackColor = false;
            btnBuyMeCoffee.Click += btnBuyMeCoffee_Click;
            // 
            // btnGitHubSponsors
            // 
            btnGitHubSponsors.BackColor = System.Drawing.Color.FromArgb(88, 96, 105);
            btnGitHubSponsors.Color = System.Drawing.Color.Black;
            btnGitHubSponsors.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGitHubSponsors.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnGitHubSponsors.ForeColor = System.Drawing.Color.White;
            btnGitHubSponsors.Location = new System.Drawing.Point(234, 341);
            btnGitHubSponsors.Margin = new System.Windows.Forms.Padding(4);
            btnGitHubSponsors.Name = "btnGitHubSponsors";
            btnGitHubSponsors.Radius = 10;
            btnGitHubSponsors.ShadowDepth = 10F;
            btnGitHubSponsors.Size = new System.Drawing.Size(194, 56);
            btnGitHubSponsors.TabIndex = 1;
            btnGitHubSponsors.Text = "GitHub Sponsors";
            btnGitHubSponsors.UseVisualStyleBackColor = false;
            btnGitHubSponsors.Click += btnGitHubSponsors_Click;
            // 
            // btnPatreon
            // 
            btnPatreon.BackColor = System.Drawing.Color.FromArgb(255, 66, 77);
            btnPatreon.Color = System.Drawing.Color.FromArgb(255, 66, 77);
            btnPatreon.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPatreon.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnPatreon.ForeColor = System.Drawing.Color.White;
            btnPatreon.Location = new System.Drawing.Point(436, 341);
            btnPatreon.Margin = new System.Windows.Forms.Padding(4);
            btnPatreon.Name = "btnPatreon";
            btnPatreon.Radius = 10;
            btnPatreon.ShadowDepth = 10F;
            btnPatreon.Size = new System.Drawing.Size(194, 56);
            btnPatreon.TabIndex = 2;
            btnPatreon.Text = "Patreon";
            btnPatreon.UseVisualStyleBackColor = false;
            btnPatreon.Click += btnPatreon_Click;
            // 
            // lblMessage
            // 
            lblMessage.ApplyGradient = false;
            lblMessage.BackColor = System.Drawing.Color.Transparent;
            lblMessage.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            lblMessage.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            lblMessage.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblMessage.GradientAnimation = false;
            lblMessage.Location = new System.Drawing.Point(32, 227);
            lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new System.Drawing.Size(598, 75);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "RSBot is completely free and open source.\r\nWe need your support to continue development.\r\nEven a small donation makes a big difference!";
            lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.ApplyGradient = true;
            lblTitle.AutoSize = true;
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            lblTitle.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.FromArgb(220, 53, 69),
    System.Drawing.Color.FromArgb(253, 126, 20)
    };
            lblTitle.GradientAnimation = true;
            lblTitle.Location = new System.Drawing.Point(156, 174);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(359, 41);
            lblTitle.TabIndex = 1;
            lblTitle.Text = " We Need Your Support!";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = Properties.Resources.app;
            pictureBox1.Location = new System.Drawing.Point(271, 24);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(120, 120);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelOr
            // 
            labelOr.ApplyGradient = true;
            labelOr.AutoSize = true;
            labelOr.BackColor = System.Drawing.Color.Transparent;
            labelOr.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelOr.ForeColor = System.Drawing.Color.Gray;
            labelOr.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.FromArgb(128, 64, 64)
    };
            labelOr.GradientAnimation = true;
            labelOr.Location = new System.Drawing.Point(279, 411);
            labelOr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelOr.Name = "labelOr";
            labelOr.Size = new System.Drawing.Size(61, 41);
            labelOr.TabIndex = 1;
            labelOr.Text = "OR";
            labelOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separator1
            // 
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(106, 429);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(150, 8);
            separator1.TabIndex = 3;
            // 
            // separator2
            // 
            separator2.IsVertical = false;
            separator2.Location = new System.Drawing.Point(379, 429);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(150, 8);
            separator2.TabIndex = 3;
            // 
            // pictureBoxMaxicardImage
            // 
            pictureBoxMaxicardImage.Image = Properties.Resources.maxicard_banner;
            pictureBoxMaxicardImage.Location = new System.Drawing.Point(65, 465);
            pictureBoxMaxicardImage.Name = "pictureBoxMaxicardImage";
            pictureBoxMaxicardImage.Size = new System.Drawing.Size(525, 75);
            pictureBoxMaxicardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBoxMaxicardImage.TabIndex = 4;
            pictureBoxMaxicardImage.TabStop = false;
            pictureBoxMaxicardImage.Click += pictureBoxMaxicardImage_Click;
            // 
            // buttonClose
            // 
            buttonClose.Color = System.Drawing.Color.Maroon;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(624, 12);
            buttonClose.Name = "buttonClose";
            buttonClose.Radius = 6;
            buttonClose.ShadowDepth = 4F;
            buttonClose.Size = new System.Drawing.Size(28, 28);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "X";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // DonationReminderDialog
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            ClientSize = new System.Drawing.Size(664, 564);
            Controls.Add(buttonClose);
            Controls.Add(pictureBoxMaxicardImage);
            Controls.Add(separator2);
            Controls.Add(separator1);
            Controls.Add(btnBuyMeCoffee);
            Controls.Add(btnGitHubSponsors);
            Controls.Add(btnPatreon);
            Controls.Add(lblMessage);
            Controls.Add(labelOr);
            Controls.Add(lblTitle);
            Controls.Add(pictureBox1);
            DwmMargin = -1;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Location = new System.Drawing.Point(0, 0);
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(670, 570);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(670, 570);
            Name = "DonationReminderDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Load += DonationReminderDialog_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMaxicardImage).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private SDUI.Controls.Label lblTitle;
        private SDUI.Controls.Label lblMessage;
        private SDUI.Controls.Button btnBuyMeCoffee;
        private SDUI.Controls.Button btnGitHubSponsors;
        private SDUI.Controls.Button btnPatreon;
        private SDUI.Controls.Label labelOr;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.Separator separator2;
        private System.Windows.Forms.PictureBox pictureBoxMaxicardImage;
        private SDUI.Controls.Button buttonClose;
    }
}
