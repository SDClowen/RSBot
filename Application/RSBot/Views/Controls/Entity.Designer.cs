namespace RSBot.Views.Controls
{
    partial class Entity
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
            lblType = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblEntityName = new System.Windows.Forms.Label();
            progressHP = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // lblType
            // 
            
            
            lblType.Dock = System.Windows.Forms.DockStyle.Bottom;
            
                        
            lblType.Location = new System.Drawing.Point(0, 64);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(250, 19);
            lblType.TabIndex = 18;
            lblType.Text = "<none>";
            lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            
            label1.AutoSize = true;
            
                        
            label1.Location = new System.Drawing.Point(20, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(26, 15);
            label1.TabIndex = 17;
            label1.Text = "HP:";
            // 
            // lblEntityName
            // 
            
            lblEntityName.AutoSize = true;
            
                        
            lblEntityName.Location = new System.Drawing.Point(49, 12);
            lblEntityName.Name = "lblEntityName";
            lblEntityName.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            lblEntityName.Size = new System.Drawing.Size(108, 15);
            lblEntityName.TabIndex = 16;
            lblEntityName.Text = "No entity selected";
            // 
            // progressHP
            // 
            
            
            
                        
            progressHP.Location = new System.Drawing.Point(52, 38);
            progressHP.Maximum = 100;
            
            progressHP.Name = "progressHP";
            
            
            
            
            progressHP.Size = new System.Drawing.Size(180, 20);
            progressHP.TabIndex = 15;
            progressHP.Text = "0,00%";
            progressHP.Value = 0;
            // 
            // Entity
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(lblType);
            Controls.Add(label1);
            Controls.Add(lblEntityName);
            Controls.Add(progressHP);
            MinimumSize = new System.Drawing.Size(250, 76);
            Name = "Entity";
            Size = new System.Drawing.Size(250, 83);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEntityName;
        private System.Windows.Forms.ProgressBar progressHP;
        private System.Windows.Forms.Label lblType;
    }
}
