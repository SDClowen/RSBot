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
            this.rtbUpdateInfo = new System.Windows.Forms.RichTextBox();
            this.lblInfo = new SDUI.Controls.Label();
            this.cbChangeLog = new SDUI.Controls.CheckBox();
            this.label2 = new SDUI.Controls.Label();
            this.btnDownload = new SDUI.Controls.Button();
            this.btnSkip = new SDUI.Controls.Button();
            this.centerPanel = new SDUI.Controls.Panel();
            this.downloadProgress = new SDUI.Controls.ProgressBar();
            this.lblDownloadInfo = new SDUI.Controls.Label();
            this.centerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbUpdateInfo
            // 
            this.rtbUpdateInfo.BackColor = System.Drawing.Color.White;
            this.rtbUpdateInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbUpdateInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbUpdateInfo.Location = new System.Drawing.Point(0, 38);
            this.rtbUpdateInfo.Name = "rtbUpdateInfo";
            this.rtbUpdateInfo.ReadOnly = true;
            this.rtbUpdateInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbUpdateInfo.ShortcutsEnabled = false;
            this.rtbUpdateInfo.Size = new System.Drawing.Size(430, 267);
            this.rtbUpdateInfo.TabIndex = 0;
            this.rtbUpdateInfo.Text = "";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblInfo.Location = new System.Drawing.Point(8, 8);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(404, 21);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "A new update is available, would you like to update now?";
            // 
            // cbChangeLog
            // 
            this.cbChangeLog.AutoSize = true;
            this.cbChangeLog.Location = new System.Drawing.Point(154, 8);
            this.cbChangeLog.Name = "cbChangeLog";
            this.cbChangeLog.Size = new System.Drawing.Size(90, 19);
            this.cbChangeLog.TabIndex = 2;
            this.cbChangeLog.Text = "Change Log";
            this.cbChangeLog.CheckedChanged += new System.EventHandler(this.cbChangeLog_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(0, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(430, 2);
            this.label2.TabIndex = 3;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDownload.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDownload.Location = new System.Drawing.Point(332, 5);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(85, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Update";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSkip.Location = new System.Drawing.Point(5, 5);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 4;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            // 
            // centerPanel
            // 
            this.centerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.centerPanel.Controls.Add(this.rtbUpdateInfo);
            this.centerPanel.Controls.Add(this.btnSkip);
            this.centerPanel.Controls.Add(this.btnDownload);
            this.centerPanel.Controls.Add(this.cbChangeLog);
            this.centerPanel.Controls.Add(this.label2);
            this.centerPanel.Location = new System.Drawing.Point(7, 39);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(430, 305);
            this.centerPanel.TabIndex = 5;
            // 
            // downloadProgress
            // 
            this.downloadProgress.Location = new System.Drawing.Point(20, 10);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(400, 23);
            this.downloadProgress.TabIndex = 5;
            this.downloadProgress.Visible = false;
            // 
            // lblDownloadInfo
            // 
            this.lblDownloadInfo.AutoSize = true;
            this.lblDownloadInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDownloadInfo.Location = new System.Drawing.Point(288, 14);
            this.lblDownloadInfo.Name = "lblDownloadInfo";
            this.lblDownloadInfo.Size = new System.Drawing.Size(0, 15);
            this.lblDownloadInfo.TabIndex = 6;
            // 
            // Updater
            // 
            this.AcceptButton = this.btnDownload;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnSkip;
            this.ClientSize = new System.Drawing.Size(445, 72);
            this.ControlBox = false;
            this.Controls.Add(this.downloadProgress);
            this.Controls.Add(this.lblDownloadInfo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.centerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(451, 351);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(451, 78);
            this.Name = "Updater";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.centerPanel.ResumeLayout(false);
            this.centerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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

