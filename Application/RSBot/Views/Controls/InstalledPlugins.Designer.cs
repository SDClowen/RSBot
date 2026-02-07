namespace RSBot.Views.Controls
{
    partial class InstalledPlugins
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
            panelLocalTop = new SDUI.Controls.Panel();
            btnLoadPlugin = new SDUI.Controls.Button();
            btnRefreshLocal = new SDUI.Controls.Button();
            lblLocalStatus = new SDUI.Controls.Label();
            flowPanelLocal = new SDUI.Controls.FlowLayoutPanel();
            panelLocalTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelLocalTop
            // 
            panelLocalTop.BackColor = System.Drawing.Color.Transparent;
            panelLocalTop.Border = new System.Windows.Forms.Padding(0, 0, 0, 1);
            panelLocalTop.BorderColor = System.Drawing.Color.Transparent;
            panelLocalTop.Controls.Add(btnLoadPlugin);
            panelLocalTop.Controls.Add(btnRefreshLocal);
            panelLocalTop.Controls.Add(lblLocalStatus);
            panelLocalTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelLocalTop.Location = new System.Drawing.Point(0, 0);
            panelLocalTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelLocalTop.Name = "panelLocalTop";
            panelLocalTop.Radius = 0;
            panelLocalTop.ShadowDepth = 0F;
            panelLocalTop.Size = new System.Drawing.Size(1057, 47);
            panelLocalTop.TabIndex = 1;
            // 
            // btnLoadPlugin
            // 
            btnLoadPlugin.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            btnLoadPlugin.Color = System.Drawing.Color.FromArgb(0, 123, 255);
            btnLoadPlugin.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLoadPlugin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            btnLoadPlugin.ForeColor = System.Drawing.Color.White;
            btnLoadPlugin.Location = new System.Drawing.Point(11, 8);
            btnLoadPlugin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnLoadPlugin.Name = "btnLoadPlugin";
            btnLoadPlugin.Radius = 8;
            btnLoadPlugin.ShadowDepth = 3F;
            btnLoadPlugin.Size = new System.Drawing.Size(171, 32);
            btnLoadPlugin.TabIndex = 0;
            btnLoadPlugin.Text = "Load from File";
            btnLoadPlugin.UseVisualStyleBackColor = false;
            btnLoadPlugin.Click += btnLoadPlugin_Click;
            // 
            // btnRefreshLocal
            // 
            btnRefreshLocal.Color = System.Drawing.Color.Transparent;
            btnRefreshLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefreshLocal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            btnRefreshLocal.Location = new System.Drawing.Point(194, 8);
            btnRefreshLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRefreshLocal.Name = "btnRefreshLocal";
            btnRefreshLocal.Radius = 8;
            btnRefreshLocal.ShadowDepth = 2F;
            btnRefreshLocal.Size = new System.Drawing.Size(137, 32);
            btnRefreshLocal.TabIndex = 1;
            btnRefreshLocal.Text = "Refresh";
            btnRefreshLocal.UseVisualStyleBackColor = true;
            btnRefreshLocal.Click += btnRefreshLocal_Click;
            // 
            // lblLocalStatus
            // 
            lblLocalStatus.ApplyGradient = false;
            lblLocalStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblLocalStatus.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblLocalStatus.GradientAnimation = false;
            lblLocalStatus.Location = new System.Drawing.Point(337, 13);
            lblLocalStatus.Name = "lblLocalStatus";
            lblLocalStatus.Size = new System.Drawing.Size(367, 27);
            lblLocalStatus.TabIndex = 2;
            lblLocalStatus.Text = "Loading plugins...";
            // 
            // flowPanelLocal
            // 
            flowPanelLocal.AutoScroll = true;
            flowPanelLocal.BackColor = System.Drawing.Color.Transparent;
            flowPanelLocal.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            flowPanelLocal.BorderColor = System.Drawing.Color.Transparent;
            flowPanelLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            flowPanelLocal.Location = new System.Drawing.Point(0, 47);
            flowPanelLocal.Margin = new System.Windows.Forms.Padding(0);
            flowPanelLocal.Name = "flowPanelLocal";
            flowPanelLocal.Radius = 0;
            flowPanelLocal.ShadowDepth = 0F;
            flowPanelLocal.Size = new System.Drawing.Size(1057, 658);
            flowPanelLocal.TabIndex = 2;
            // 
            // InstalledPlugins
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(flowPanelLocal);
            Controls.Add(panelLocalTop);
            Name = "InstalledPlugins";
            Size = new System.Drawing.Size(1057, 705);
            panelLocalTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SDUI.Controls.Panel panelLocalTop;
        private SDUI.Controls.Button btnLoadPlugin;
        private SDUI.Controls.Button btnRefreshLocal;
        private SDUI.Controls.Label lblLocalStatus;
        private SDUI.Controls.FlowLayoutPanel flowPanelLocal;
    }
}
