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
            this.label1 = new System.Windows.Forms.Label();
            this.lblEntityName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.progressHP = new Theme.Controls.XpProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "HP:";
            // 
            // lblEntityName
            // 
            this.lblEntityName.AutoSize = true;
            this.lblEntityName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntityName.Location = new System.Drawing.Point(49, 12);
            this.lblEntityName.Name = "lblEntityName";
            this.lblEntityName.Size = new System.Drawing.Size(109, 15);
            this.lblEntityName.TabIndex = 16;
            this.lblEntityName.Text = "No entity selected";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(49, 57);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 13);
            this.lblType.TabIndex = 18;
            // 
            // progressHP
            // 
            this.progressHP.ColorBackGround = System.Drawing.Color.Gainsboro;
            this.progressHP.ColorBarBorder = System.Drawing.Color.DarkRed;
            this.progressHP.ColorBarCenter = System.Drawing.Color.Red;
            this.progressHP.ColorText = System.Drawing.Color.White;
            this.progressHP.Location = new System.Drawing.Point(52, 35);
            this.progressHP.Name = "progressHP";
            this.progressHP.Position = 0;
            this.progressHP.PositionMax = 100;
            this.progressHP.PositionMin = 0;
            this.progressHP.Size = new System.Drawing.Size(180, 19);
            this.progressHP.SteepDistance = ((byte)(0));
            this.progressHP.TabIndex = 15;
            this.progressHP.Text = "0%";
            // 
            // Entity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEntityName);
            this.Controls.Add(this.progressHP);
            this.Name = "Entity";
            this.Size = new System.Drawing.Size(250, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEntityName;
        private Theme.Controls.XpProgressBar progressHP;
        private System.Windows.Forms.Label lblType;
    }
}
