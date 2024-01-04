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
            Hp = new SDUI.Controls.ProgressBar();
            Hgp = new SDUI.Controls.ProgressBar();
            Satiety = new SDUI.Controls.ProgressBar();
            Icon = new System.Windows.Forms.Panel();
            Level = new System.Windows.Forms.Label();
            panel = new SDUI.Controls.Panel();
            Icon.SuspendLayout();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // Hp
            // 
            Hp.BackColor = System.Drawing.Color.Transparent;
            Hp.Dock = System.Windows.Forms.DockStyle.Top;
            Hp.DrawHatch = false;
            Hp.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Maroon,
    System.Drawing.Color.Red
    };
            Hp.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            Hp.Location = new System.Drawing.Point(3, 41);
            Hp.Maximum = 100L;
            Hp.MaxPercentShowValue = 100F;
            Hp.Name = "Hp";
            Hp.PercentIndices = 2;
            Hp.Radius = 1;
            Hp.ShowAsPercent = false;
            Hp.ShowValue = false;
            Hp.Size = new System.Drawing.Size(34, 5);
            Hp.TabIndex = 1;
            Hp.Value = 55L;
            Hp.Click += OnClick_Redirector;
            // 
            // Hgp
            // 
            Hgp.BackColor = System.Drawing.Color.Transparent;
            Hgp.Dock = System.Windows.Forms.DockStyle.Top;
            Hgp.DrawHatch = false;
            Hgp.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gold,
    System.Drawing.Color.Yellow
    };
            Hgp.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            Hgp.Location = new System.Drawing.Point(3, 46);
            Hgp.Maximum = 100L;
            Hgp.MaxPercentShowValue = 100F;
            Hgp.Name = "Hgp";
            Hgp.PercentIndices = 2;
            Hgp.Radius = 1;
            Hgp.ShowAsPercent = false;
            Hgp.ShowValue = false;
            Hgp.Size = new System.Drawing.Size(34, 5);
            Hgp.TabIndex = 2;
            Hgp.Value = 55L;
            Hgp.Click += OnClick_Redirector;
            // 
            // Satiety
            // 
            Satiety.BackColor = System.Drawing.Color.Transparent;
            Satiety.Dock = System.Windows.Forms.DockStyle.Top;
            Satiety.DrawHatch = false;
            Satiety.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Turquoise,
    System.Drawing.Color.DodgerBlue
    };
            Satiety.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            Satiety.Location = new System.Drawing.Point(3, 51);
            Satiety.Maximum = 100L;
            Satiety.MaxPercentShowValue = 100F;
            Satiety.Name = "Satiety";
            Satiety.PercentIndices = 2;
            Satiety.Radius = 1;
            Satiety.ShowAsPercent = false;
            Satiety.ShowValue = false;
            Satiety.Size = new System.Drawing.Size(34, 5);
            Satiety.TabIndex = 3;
            Satiety.Value = 55L;
            Satiety.Click += OnClick_Redirector;
            // 
            // Icon
            // 
            Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            Icon.Controls.Add(Level);
            Icon.Dock = System.Windows.Forms.DockStyle.Top;
            Icon.Location = new System.Drawing.Point(3, 3);
            Icon.Name = "Icon";
            Icon.Size = new System.Drawing.Size(34, 38);
            Icon.TabIndex = 4;
            Icon.Click += OnClick_Redirector;
            // 
            // Level
            // 
            Level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Level.AutoSize = true;
            Level.BackColor = System.Drawing.Color.FromArgb(150, 0, 0, 0);
            Level.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Level.ForeColor = System.Drawing.Color.White;
            Level.Location = new System.Drawing.Point(0, 23);
            Level.Name = "Level";
            Level.Size = new System.Drawing.Size(26, 12);
            Level.TabIndex = 0;
            Level.Text = "lv 52";
            Level.Click += OnClick_Redirector;
            // 
            // panel
            // 
            panel.BackColor = System.Drawing.Color.Transparent;
            panel.Border = new System.Windows.Forms.Padding(1);
            panel.BorderColor = System.Drawing.Color.Red;
            panel.Controls.Add(Satiety);
            panel.Controls.Add(Hgp);
            panel.Controls.Add(Hp);
            panel.Controls.Add(Icon);
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Location = new System.Drawing.Point(1, 1);
            panel.Name = "panel";
            panel.Padding = new System.Windows.Forms.Padding(3);
            panel.Radius = 8;
            panel.ShadowDepth = 4F;
            panel.Size = new System.Drawing.Size(40, 60);
            panel.TabIndex = 1;
            panel.Click += OnClick_Redirector;
            // 
            // MiniCosControl
            // 
            Controls.Add(panel);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "MiniCosControl";
            Padding = new System.Windows.Forms.Padding(1);
            Size = new System.Drawing.Size(42, 62);
            Icon.ResumeLayout(false);
            Icon.PerformLayout();
            panel.ResumeLayout(false);
            ResumeLayout(false);
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
