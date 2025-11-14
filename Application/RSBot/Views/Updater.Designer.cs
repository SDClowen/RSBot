namespace RSBot.Views
{
    partial class Updater
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
            rtbUpdateInfo = new System.Windows.Forms.RichTextBox();
            lblInfo = new SDUI.Controls.Label();
            cbChangeLog = new SDUI.Controls.CheckBox();
            label2 = new SDUI.Controls.Label();
            btnDownload = new SDUI.Controls.Button();
            btnSkip = new SDUI.Controls.Button();
            centerPanel = new SDUI.Controls.Panel();
            downloadProgress = new SDUI.Controls.ProgressBar();
            lblDownloadInfo = new SDUI.Controls.Label();
            centerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rtbUpdateInfo
            // 
            rtbUpdateInfo.BackColor = System.Drawing.Color.White;
            rtbUpdateInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rtbUpdateInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            rtbUpdateInfo.Location = new System.Drawing.Point(0, 38);
            rtbUpdateInfo.Name = "rtbUpdateInfo";
            rtbUpdateInfo.ReadOnly = true;
            rtbUpdateInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            rtbUpdateInfo.ShortcutsEnabled = false;
            rtbUpdateInfo.Size = new System.Drawing.Size(430, 267);
            rtbUpdateInfo.TabIndex = 0;
            rtbUpdateInfo.Text = "";
            // 
            // lblInfo
            // 
            lblInfo.ApplyGradient = false;
            lblInfo.AutoSize = true;
            lblInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            lblInfo.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblInfo.GradientAnimation = false;
            lblInfo.Location = new System.Drawing.Point(8, 8);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new System.Drawing.Size(404, 21);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "A new update is available, would you like to update now?";
            // 
            // cbChangeLog
            // 
            cbChangeLog.AutoSize = true;
            cbChangeLog.Depth = 0;
            cbChangeLog.Location = new System.Drawing.Point(154, 8);
            cbChangeLog.Margin = new System.Windows.Forms.Padding(0);
            cbChangeLog.MouseLocation = new System.Drawing.Point(-1, -1);
            cbChangeLog.Name = "cbChangeLog";
            cbChangeLog.Ripple = true;
            cbChangeLog.Size = new System.Drawing.Size(97, 30);
            cbChangeLog.TabIndex = 2;
            cbChangeLog.Text = "Change Log";
            cbChangeLog.CheckedChanged += cbChangeLog_CheckedChanged;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.ApplyGradient = false;
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(0, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(430, 2);
            label2.TabIndex = 3;
            // 
            // btnDownload
            // 
            btnDownload.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnDownload.Color = System.Drawing.Color.Transparent;
            btnDownload.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnDownload.Location = new System.Drawing.Point(332, 5);
            btnDownload.Name = "btnDownload";
            btnDownload.Radius = 6;
            btnDownload.ShadowDepth = 4F;
            btnDownload.Size = new System.Drawing.Size(85, 23);
            btnDownload.TabIndex = 4;
            btnDownload.Text = "Update";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnSkip
            // 
            btnSkip.Color = System.Drawing.Color.Transparent;
            btnSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnSkip.Location = new System.Drawing.Point(5, 5);
            btnSkip.Name = "btnSkip";
            btnSkip.Radius = 6;
            btnSkip.ShadowDepth = 4F;
            btnSkip.Size = new System.Drawing.Size(75, 23);
            btnSkip.TabIndex = 4;
            btnSkip.Text = "Skip";
            btnSkip.UseVisualStyleBackColor = true;
            // 
            // centerPanel
            // 
            centerPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            centerPanel.BackColor = System.Drawing.Color.Transparent;
            centerPanel.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            centerPanel.BorderColor = System.Drawing.Color.Transparent;
            centerPanel.Controls.Add(rtbUpdateInfo);
            centerPanel.Controls.Add(btnSkip);
            centerPanel.Controls.Add(btnDownload);
            centerPanel.Controls.Add(cbChangeLog);
            centerPanel.Controls.Add(label2);
            centerPanel.Location = new System.Drawing.Point(7, 39);
            centerPanel.Name = "centerPanel";
            centerPanel.Radius = 10;
            centerPanel.ShadowDepth = 4F;
            centerPanel.Size = new System.Drawing.Size(430, 305);
            centerPanel.TabIndex = 5;
            // 
            // downloadProgress
            // 
            downloadProgress.BackColor = System.Drawing.Color.Transparent;
            downloadProgress.DrawHatch = false;
            downloadProgress.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Empty,
    System.Drawing.Color.Empty
    };
            downloadProgress.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            downloadProgress.Location = new System.Drawing.Point(20, 10);
            downloadProgress.Maximum = 100L;
            downloadProgress.MaxPercentShowValue = 100F;
            downloadProgress.Name = "downloadProgress";
            downloadProgress.PercentIndices = 2;
            downloadProgress.Radius = 4;
            downloadProgress.ShowAsPercent = false;
            downloadProgress.ShowValue = false;
            downloadProgress.Size = new System.Drawing.Size(400, 23);
            downloadProgress.TabIndex = 5;
            downloadProgress.Value = 0L;
            downloadProgress.Visible = false;
            // 
            // lblDownloadInfo
            // 
            lblDownloadInfo.ApplyGradient = false;
            lblDownloadInfo.AutoSize = true;
            lblDownloadInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 162);
            lblDownloadInfo.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblDownloadInfo.GradientAnimation = false;
            lblDownloadInfo.Location = new System.Drawing.Point(288, 14);
            lblDownloadInfo.Name = "lblDownloadInfo";
            lblDownloadInfo.Size = new System.Drawing.Size(0, 15);
            lblDownloadInfo.TabIndex = 6;
            // 
            // Updater
            // 
            AcceptButton = btnDownload;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            CancelButton = btnSkip;
            ClientSize = new System.Drawing.Size(445, 72);
            ControlBox = false;
            Controls.Add(downloadProgress);
            Controls.Add(lblDownloadInfo);
            Controls.Add(lblInfo);
            Controls.Add(centerPanel);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(451, 351);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(451, 78);
            Name = "Updater";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            centerPanel.ResumeLayout(false);
            centerPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbUpdateInfo;
        private SDUI.Controls.Label lblInfo;
        private SDUI.Controls.CheckBox cbChangeLog;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Button btnDownload;
        private SDUI.Controls.Button btnSkip;
        private SDUI.Controls.Panel centerPanel;
        private SDUI.Controls.ProgressBar downloadProgress;
        private SDUI.Controls.Label lblDownloadInfo;
    }
}

