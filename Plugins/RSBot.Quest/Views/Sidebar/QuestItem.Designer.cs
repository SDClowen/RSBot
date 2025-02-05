namespace RSBot.Quest.Views.Sidebar
{
    partial class QuestItem
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            panel1 = new System.Windows.Forms.Panel();
            btnRemove = new System.Windows.Forms.Button();
            lblObjective = new System.Windows.Forms.Label();
            lblQuestName = new System.Windows.Forms.Label();
            toolTipHide = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRemove);
            panel1.Controls.Add(lblObjective);
            panel1.Controls.Add(lblQuestName);
            panel1.Location = new System.Drawing.Point(5, 5);
            panel1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(299, 70);
            panel1.TabIndex = 0;
            // 
            // btnRemove
            // 
            btnRemove.AutoSize = true;
            btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnRemove.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            btnRemove.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            btnRemove.Location = new System.Drawing.Point(268, 4);
            btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(30, 29);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "✕";
            toolTipHide.SetToolTip(btnRemove, "Unwatch this quest");
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // lblObjective
            // 
            lblObjective.Dock = System.Windows.Forms.DockStyle.Fill;
            lblObjective.Location = new System.Drawing.Point(0, 32);
            lblObjective.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblObjective.Name = "lblObjective";
            lblObjective.Padding = new System.Windows.Forms.Padding(8, 2, 5, 5);
            lblObjective.RightToLeft = System.Windows.Forms.RightToLeft.No;
            lblObjective.Size = new System.Drawing.Size(299, 38);
            lblObjective.TabIndex = 1;
            lblObjective.Text = "Objective 1 with a very long title";
            // 
            // lblQuestName
            // 
            lblQuestName.Dock = System.Windows.Forms.DockStyle.Top;
            lblQuestName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            lblQuestName.Location = new System.Drawing.Point(0, 0);
            lblQuestName.Margin = new System.Windows.Forms.Padding(0);
            lblQuestName.Name = "lblQuestName";
            lblQuestName.Padding = new System.Windows.Forms.Padding(8, 10, 5, 5);
            lblQuestName.Size = new System.Drawing.Size(299, 32);
            lblQuestName.TabIndex = 0;
            lblQuestName.Text = "QuestLog A";
            // 
            // QuestItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "QuestItem";
            Size = new System.Drawing.Size(310, 81);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblObjective;
        private System.Windows.Forms.Label lblQuestName;
        private System.Windows.Forms.ToolTip toolTipHide;
        private System.Windows.Forms.Button btnRemove;
    }
}
