namespace RSBot.Views.Controls
{
    partial class MiniCosControl
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
            this.Hp = new SDUI.Controls.ProgressBar();
            this.Hgp = new SDUI.Controls.ProgressBar();
            this.Satiety = new SDUI.Controls.ProgressBar();
            this.Icon = new System.Windows.Forms.Panel();
            this.Level = new System.Windows.Forms.Label();
            this.panel = new SDUI.Controls.Panel();
            this.Icon.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Hp
            // 
            this.Hp.BackColor = System.Drawing.Color.Transparent;
            this.Hp.Dock = System.Windows.Forms.DockStyle.Top;
            this.Hp.DrawHatch = false;
            this.Hp.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Maroon,
        System.Drawing.Color.Red};
            this.Hp.HatchType = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.Hp.Location = new System.Drawing.Point(3, 41);
            this.Hp.Maximum = ((long)(100));
            this.Hp.Name = "Hp";
            this.Hp.PercentIndices = 2;
            this.Hp.Radius = 0;
            this.Hp.ShowAsPercent = false;
            this.Hp.ShowValue = false;
            this.Hp.Size = new System.Drawing.Size(34, 5);
            this.Hp.TabIndex = 1;
            this.Hp.Value = ((long)(55));
            this.Hp.Click += new System.EventHandler(this.OnClick_Redirector);
            // 
            // Hgp
            // 
            this.Hgp.BackColor = System.Drawing.Color.Transparent;
            this.Hgp.Dock = System.Windows.Forms.DockStyle.Top;
            this.Hgp.DrawHatch = false;
            this.Hgp.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Gold,
        System.Drawing.Color.Yellow};
            this.Hgp.HatchType = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.Hgp.Location = new System.Drawing.Point(3, 46);
            this.Hgp.Maximum = ((long)(100));
            this.Hgp.Name = "Hgp";
            this.Hgp.PercentIndices = 2;
            this.Hgp.Radius = 0;
            this.Hgp.ShowAsPercent = false;
            this.Hgp.ShowValue = false;
            this.Hgp.Size = new System.Drawing.Size(34, 5);
            this.Hgp.TabIndex = 2;
            this.Hgp.Value = ((long)(55));
            this.Hgp.Click += new System.EventHandler(this.OnClick_Redirector);
            // 
            // Satiety
            // 
            this.Satiety.BackColor = System.Drawing.Color.Transparent;
            this.Satiety.Dock = System.Windows.Forms.DockStyle.Top;
            this.Satiety.DrawHatch = false;
            this.Satiety.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Turquoise,
        System.Drawing.Color.DodgerBlue};
            this.Satiety.HatchType = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.Satiety.Location = new System.Drawing.Point(3, 51);
            this.Satiety.Maximum = ((long)(100));
            this.Satiety.Name = "Satiety";
            this.Satiety.PercentIndices = 2;
            this.Satiety.Radius = 0;
            this.Satiety.ShowAsPercent = false;
            this.Satiety.ShowValue = false;
            this.Satiety.Size = new System.Drawing.Size(34, 5);
            this.Satiety.TabIndex = 3;
            this.Satiety.Value = ((long)(55));
            this.Satiety.Click += new System.EventHandler(this.OnClick_Redirector);
            // 
            // Icon
            // 
            this.Icon.BackgroundImage = global::RSBot.Properties.Resources.shark;
            this.Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Icon.Controls.Add(this.Level);
            this.Icon.Dock = System.Windows.Forms.DockStyle.Top;
            this.Icon.Location = new System.Drawing.Point(3, 3);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(34, 38);
            this.Icon.TabIndex = 4;
            this.Icon.Click += new System.EventHandler(this.OnClick_Redirector);
            // 
            // Level
            // 
            this.Level.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Level.AutoSize = true;
            this.Level.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Level.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.ForeColor = System.Drawing.Color.White;
            this.Level.Location = new System.Drawing.Point(0, 23);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(26, 12);
            this.Level.TabIndex = 0;
            this.Level.Text = "lv 52";
            this.Level.Click += new System.EventHandler(this.OnClick_Redirector);
            // 
            // panel
            // 
            this.panel.Border = new System.Windows.Forms.Padding(1);
            this.panel.BorderColor = System.Drawing.Color.Red;
            this.panel.Controls.Add(this.Satiety);
            this.panel.Controls.Add(this.Hgp);
            this.panel.Controls.Add(this.Hp);
            this.panel.Controls.Add(this.Icon);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(1, 1);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(3);
            this.panel.Radius = 8;
            this.panel.Size = new System.Drawing.Size(40, 60);
            this.panel.TabIndex = 1;
            this.panel.Click += new System.EventHandler(this.OnClick_Redirector);
            // 
            // MiniCosControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MiniCosControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(42, 62);
            this.Icon.ResumeLayout(false);
            this.Icon.PerformLayout();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public SDUI.Controls.ProgressBar Hp;
        public SDUI.Controls.ProgressBar Satiety;
        public SDUI.Controls.ProgressBar Hgp;
        public System.Windows.Forms.Label Level;
        private SDUI.Controls.Panel panel;
        public System.Windows.Forms.Panel Icon;
    }
}
