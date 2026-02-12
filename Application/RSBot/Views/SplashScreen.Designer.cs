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
            logoLabel = new SDUI.Controls.Label();
            labelVersion = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            label3 = new SDUI.Controls.Label();
            lblLoading = new SDUI.Controls.Label();
            progressLoading = new SDUI.Controls.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackColor = System.Drawing.Color.Transparent;
            pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            pictureBox.Image = Properties.Resources.app;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(521, 91);
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
            logoLabel.ApplyGradient = true;
            logoLabel.BackColor = System.Drawing.Color.Transparent;
            logoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            logoLabel.Font = new System.Drawing.Font("Segoe UI Black", 65.25F, System.Drawing.FontStyle.Bold);
            logoLabel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            logoLabel.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.DodgerBlue,
    System.Drawing.Color.LightBlue
    };
            logoLabel.GradientAnimation = true;
            logoLabel.Location = new System.Drawing.Point(0, 91);
            logoLabel.Name = "logoLabel";
            logoLabel.Size = new System.Drawing.Size(521, 100);
            logoLabel.TabIndex = 3;
            logoLabel.Text = "RSBOT";
            logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            labelVersion.ApplyGradient = true;
            labelVersion.BackColor = System.Drawing.Color.Transparent;
            labelVersion.Enabled = false;
            labelVersion.Font = new System.Drawing.Font("Segoe UI", 12F);
            labelVersion.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelVersion.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Aqua,
    System.Drawing.Color.RoyalBlue
    };
            labelVersion.GradientAnimation = false;
            labelVersion.Location = new System.Drawing.Point(442, 125);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new System.Drawing.Size(67, 28);
            labelVersion.TabIndex = 4;
            labelVersion.Text = "v1.0.0";
            labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            label2.Enabled = false;
            label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.RosyBrown,
    System.Drawing.Color.FromArgb(74, 74, 74)
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(0, 218);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(521, 32);
            label2.TabIndex = 5;
            label2.Text = "Free powerful bot for Silkroad Online servers";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            label3.Enabled = false;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(0, 250);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(521, 26);
            label3.TabIndex = 5;
            label3.Text = "Created with contributions from the community";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoading
            // 
            lblLoading.ApplyGradient = false;
            lblLoading.BackColor = System.Drawing.Color.Transparent;
            lblLoading.Dock = System.Windows.Forms.DockStyle.Top;
            lblLoading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblLoading.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblLoading.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblLoading.GradientAnimation = false;
            lblLoading.Location = new System.Drawing.Point(0, 191);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new System.Drawing.Size(521, 21);
            lblLoading.TabIndex = 6;
            lblLoading.Text = "Loading";
            lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressLoading
            // 
            progressLoading.BackColor = System.Drawing.Color.Transparent;
            progressLoading.DrawHatch = true;
            progressLoading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            progressLoading.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.DodgerBlue,
    System.Drawing.Color.SlateBlue
    };
            progressLoading.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            progressLoading.Location = new System.Drawing.Point(0, 40);
            progressLoading.Maximum = 100L;
            progressLoading.MaxPercentShowValue = 100F;
            progressLoading.Name = "progressLoading";
            progressLoading.PercentIndices = 0;
            progressLoading.Radius = 4;
            progressLoading.ShowAsPercent = true;
            progressLoading.ShowValue = true;
            progressLoading.Size = new System.Drawing.Size(533, 290);
            progressLoading.TabIndex = 7;
            progressLoading.Text = "0,0%";
            progressLoading.Value = 0L;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ClientSize = new System.Drawing.Size(521, 276);
            ControlBox = false;
            Controls.Add(labelVersion);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(lblLoading);
            Controls.Add(logoLabel);
            Controls.Add(pictureBox);
            Controls.Add(progressLoading);
            Cursor = System.Windows.Forms.Cursors.AppStarting;
            Font = new System.Drawing.Font("Segoe UI", 12F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(527, 282);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(527, 282);
            Name = "SplashScreen";
            ShowIcon = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Tag = "";
            Load += SplashScreen_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.ComponentModel.BackgroundWorker referenceDataLoader;
        private SDUI.Controls.Label logoLabel;
        private SDUI.Controls.Label labelVersion;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.Label lblLoading;
        private SDUI.Controls.ProgressBar progressLoading;
    }
}
