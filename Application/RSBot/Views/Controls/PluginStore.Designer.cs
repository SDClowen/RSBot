namespace RSBot.Views.Controls
{
    partial class PluginStore
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelWebTop = new SDUI.Controls.Panel();
            progressBarDownload = new System.Windows.Forms.ProgressBar();
            txtSearch = new SDUI.Controls.TextBox();
            btnSearch = new SDUI.Controls.Button();
            btnRefreshWeb = new SDUI.Controls.Button();
            labelStatus = new SDUI.Controls.Label();
            flowPanelWeb = new System.Windows.Forms.Panel();
            panelWebTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelWebTop
            // 
            panelWebTop.BackColor = System.Drawing.Color.Transparent;
            panelWebTop.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            panelWebTop.BorderColor = System.Drawing.Color.Transparent;
            panelWebTop.Controls.Add(progressBarDownload);
            panelWebTop.Controls.Add(txtSearch);
            panelWebTop.Controls.Add(btnSearch);
            panelWebTop.Controls.Add(btnRefreshWeb);
            panelWebTop.Controls.Add(labelStatus);
            panelWebTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelWebTop.Location = new System.Drawing.Point(0, 0);
            panelWebTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelWebTop.Name = "panelWebTop";
            panelWebTop.Radius = 0;
            panelWebTop.ShadowDepth = 0F;
            panelWebTop.Size = new System.Drawing.Size(993, 57);
            panelWebTop.TabIndex = 1;
            // 
            // progressBarDownload
            // 
            progressBarDownload.Dock = System.Windows.Forms.DockStyle.Bottom;
            progressBarDownload.Location = new System.Drawing.Point(0, 47);
            progressBarDownload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            progressBarDownload.Name = "progressBarDownload";
            progressBarDownload.Size = new System.Drawing.Size(993, 10);
            progressBarDownload.TabIndex = 6;
            progressBarDownload.Visible = false;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = System.Drawing.Color.Transparent;
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            txtSearch.Location = new System.Drawing.Point(11, 13);
            txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSearch.MaxLength = 32767;
            txtSearch.MultiLine = false;
            txtSearch.Name = "txtSearch";
            txtSearch.PassFocusShow = false;
            txtSearch.Radius = 2;
            txtSearch.Size = new System.Drawing.Size(343, 28);
            txtSearch.TabIndex = 0;
            txtSearch.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtSearch.UseSystemPasswordChar = false;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnSearch.Color = System.Drawing.Color.FromArgb(40, 167, 69);
            btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(366, 11);
            btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Radius = 8;
            btnSearch.ShadowDepth = 3F;
            btnSearch.Size = new System.Drawing.Size(114, 32);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // 
            // btnRefreshWeb
            // 
            btnRefreshWeb.Color = System.Drawing.Color.Transparent;
            btnRefreshWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefreshWeb.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            btnRefreshWeb.Location = new System.Drawing.Point(491, 11);
            btnRefreshWeb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRefreshWeb.Name = "btnRefreshWeb";
            btnRefreshWeb.Radius = 8;
            btnRefreshWeb.ShadowDepth = 2F;
            btnRefreshWeb.Size = new System.Drawing.Size(137, 32);
            btnRefreshWeb.TabIndex = 2;
            btnRefreshWeb.Text = "Refresh";
            btnRefreshWeb.UseVisualStyleBackColor = true;
            btnRefreshWeb.Click += BtnRefreshWeb_Click;
            // 
            // labelStatus
            // 
            labelStatus.ApplyGradient = false;
            labelStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelStatus.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelStatus.GradientAnimation = false;
            labelStatus.Location = new System.Drawing.Point(634, 14);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(496, 27);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "Ready to load plugins from repository...";
            // 
            // flowPanelWeb
            // 
            flowPanelWeb.AutoScroll = true;
            flowPanelWeb.BackColor = System.Drawing.Color.Transparent;
            flowPanelWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            flowPanelWeb.Location = new System.Drawing.Point(0, 57);
            flowPanelWeb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            flowPanelWeb.Name = "flowPanelWeb";
            flowPanelWeb.Padding = new System.Windows.Forms.Padding(10);
            flowPanelWeb.Size = new System.Drawing.Size(993, 545);
            flowPanelWeb.TabIndex = 2;
            // 
            // PluginStore
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(flowPanelWeb);
            Controls.Add(panelWebTop);
            Name = "PluginStore";
            Size = new System.Drawing.Size(993, 602);
            panelWebTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SDUI.Controls.Panel panelWebTop;
        private SDUI.Controls.TextBox txtSearch;
        private SDUI.Controls.Button btnSearch;
        private SDUI.Controls.Button btnRefreshWeb;
        private SDUI.Controls.Label labelStatus;
        private System.Windows.Forms.Panel flowPanelWeb;
        private System.Windows.Forms.ProgressBar progressBarDownload;
    }
}
