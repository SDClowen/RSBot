namespace RSBot.Quest.Views.Sidebar
{
    partial class QuestSidebarElement
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override bool DoubleBuffered { get; set; } = true;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new SDUI.Controls.Label();
            pQuests = new SDUI.Controls.Panel();
            separator1 = new SDUI.Controls.Separator();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.ApplyGradient = false;
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblTitle.Gradient = new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black };
            lblTitle.GradientAnimation = false;
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(250, 30);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Questlog";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pQuests
            // 
            pQuests.AutoScroll = true;
            pQuests.BackColor = System.Drawing.Color.Transparent;
            pQuests.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            pQuests.BorderColor = System.Drawing.Color.Transparent;
            pQuests.Dock = System.Windows.Forms.DockStyle.Fill;
            pQuests.Location = new System.Drawing.Point(0, 36);
            pQuests.Name = "pQuests";
            pQuests.Radius = 0;
            pQuests.ShadowDepth = 0F;
            pQuests.Size = new System.Drawing.Size(250, 265);
            pQuests.TabIndex = 3;
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Top;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(0, 30);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(250, 6);
            separator1.TabIndex = 4;
            separator1.Text = "separator1";
            // 
            // QuestSidebarElement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pQuests);
            Controls.Add(separator1);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            Name = "QuestSidebarElement";
            Size = new System.Drawing.Size(250, 301);
            ResumeLayout(false);
        }

        #endregion
        private SDUI.Controls.Label lblTitle;
        private SDUI.Controls.Panel pQuests;
        private SDUI.Controls.Separator separator1;
    }
}
