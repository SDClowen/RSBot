namespace RSBot.Views
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            pictureBox = new System.Windows.Forms.PictureBox();
            referenceDataLoader = new System.ComponentModel.BackgroundWorker();
            logoLabel = new System.Windows.Forms.Label();
            labelVersion = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lblLoading = new System.Windows.Forms.Label();
            progressLoading = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            pictureBox.Image = Properties.Resources.app;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(533, 91);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // referenceDataLoader
            // 
            referenceDataLoader.WorkerReportsProgress = true;
            referenceDataLoader.DoWork += referenceDataLoader_DoWork;
            referenceDataLoader.ProgressChanged += referenceDataLoader_ProgressChanged;
            // 
            // logoLabel
            // 
            logoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            logoLabel.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
            logoLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            logoLabel.Location = new System.Drawing.Point(0, 91);
            logoLabel.Name = "logoLabel";
            logoLabel.Size = new System.Drawing.Size(533, 100);
            logoLabel.TabIndex = 3;
            logoLabel.Text = "RSBOT";
            logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelVersion.AutoSize = true;
            labelVersion.BackColor = System.Drawing.Color.Transparent;
            labelVersion.Enabled = false;
            labelVersion.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            labelVersion.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelVersion.Location = new System.Drawing.Point(401, 137);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new System.Drawing.Size(53, 30);
            labelVersion.TabIndex = 4;
            labelVersion.Text = "v1.0.0";
            labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            labelVersion.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.SystemColors.Control;
            label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            label2.Enabled = false;
            label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Location = new System.Drawing.Point(0, 223);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(533, 23);
            label2.TabIndex = 5;
            label2.Text = "Free powerful bot for Silkroad Online servers";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = System.Drawing.SystemColors.Control;
            label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            label3.Enabled = false;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Location = new System.Drawing.Point(0, 246);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(533, 26);
            label3.TabIndex = 5;
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoading
            // 
            lblLoading.BackColor = System.Drawing.SystemColors.Control;
            lblLoading.Dock = System.Windows.Forms.DockStyle.Top;
            lblLoading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblLoading.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblLoading.Location = new System.Drawing.Point(0, 191);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new System.Drawing.Size(533, 21);
            lblLoading.TabIndex = 8;
            lblLoading.Text = "Loading";
            lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressLoading
            // 
            progressLoading.BackColor = System.Drawing.SystemColors.Control;
            progressLoading.Dock = System.Windows.Forms.DockStyle.Bottom;
            progressLoading.Location = new System.Drawing.Point(0, 272);
            progressLoading.Name = "progressLoading";
            progressLoading.Size = new System.Drawing.Size(533, 18);
            progressLoading.TabIndex = 7;
            progressLoading.Text = "0 / 100";
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.SystemColors.Control;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ClientSize = new System.Drawing.Size(533, 290);
            ControlBox = false;
            Controls.Add(lblLoading);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(progressLoading);
            Controls.Add(labelVersion);
            Controls.Add(logoLabel);
            Controls.Add(pictureBox);
            Cursor = System.Windows.Forms.Cursors.AppStarting;
            Font = new System.Drawing.Font("Segoe UI", 12F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "SplashScreen";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Tag = "";
            Load += SplashScreen_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.ComponentModel.BackgroundWorker referenceDataLoader;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.ProgressBar progressLoading;
    }
}