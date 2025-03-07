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
            Hp = new System.Windows.Forms.ProgressBar();
            Hgp = new System.Windows.Forms.ProgressBar();
            Satiety = new System.Windows.Forms.ProgressBar();
            Icon = new System.Windows.Forms.Panel();
            Level = new System.Windows.Forms.Label();
            panel = new System.Windows.Forms.Panel();
            Icon.SuspendLayout();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // Hp
            // 
            
            Hp.Dock = System.Windows.Forms.DockStyle.Top;
            
                        
            Hp.Location = new System.Drawing.Point(3, 41);
            Hp.Maximum = 100;
            
            Hp.Name = "Hp";
            
            
            
            
            Hp.Size = new System.Drawing.Size(34, 5);
            Hp.TabIndex = 1;
            Hp.Value = 55;
            Hp.Click += OnClick_Redirector;
            // 
            // Hgp
            // 
            
            Hgp.Dock = System.Windows.Forms.DockStyle.Top;
            
                        
            Hgp.Location = new System.Drawing.Point(3, 46);
            Hgp.Maximum = 100;
            
            Hgp.Name = "Hgp";
            
            
            
            
            Hgp.Size = new System.Drawing.Size(34, 5);
            Hgp.TabIndex = 2;
            Hgp.Value = 55;
            Hgp.Click += OnClick_Redirector;
            // 
            // Satiety
            // 
            
            Satiety.Dock = System.Windows.Forms.DockStyle.Top;
            
                        
            Satiety.Location = new System.Drawing.Point(3, 51);
            Satiety.Maximum = 100;
            
            Satiety.Name = "Satiety";
            
            
            
            
            Satiety.Size = new System.Drawing.Size(34, 5);
            Satiety.TabIndex = 3;
            Satiety.Value = 55;
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
            
            Level.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            
            Level.Location = new System.Drawing.Point(0, 23);
            Level.Name = "Level";
            Level.Size = new System.Drawing.Size(26, 12);
            Level.TabIndex = 0;
            Level.Text = "lv 52";
            Level.Click += OnClick_Redirector;
            // 
            // panel
            // 
            
            
            
            panel.Controls.Add(Satiety);
            panel.Controls.Add(Hgp);
            panel.Controls.Add(Hp);
            panel.Controls.Add(Icon);
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Location = new System.Drawing.Point(1, 1);
            panel.Name = "panel";
            panel.Padding = new System.Windows.Forms.Padding(3);
            
            
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
        public System.Windows.Forms.ProgressBar Hp;
        public System.Windows.Forms.ProgressBar Satiety;
        public System.Windows.Forms.ProgressBar Hgp;
        public System.Windows.Forms.Label Level;
        private System.Windows.Forms.Panel panel;
        public System.Windows.Forms.Panel Icon;
    }
}
