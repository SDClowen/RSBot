namespace RSBot.Views.Controls
{
    partial class Pet
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
            this.lblPetName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressEXP = new SDUI.Controls.ProgressBar();
            this.progressHGP = new SDUI.Controls.ProgressBar();
            this.progressHP = new SDUI.Controls.ProgressBar();
            this.SuspendLayout();
            // 
            // lblPetName
            // 
            this.lblPetName.AutoSize = true;
            this.lblPetName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetName.Location = new System.Drawing.Point(48, 11);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(81, 15);
            this.lblPetName.TabIndex = 13;
            this.lblPetName.Text = "No pet found";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "HP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "HGP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "EXP:";
            // 
            // progressEXP
            // 
            this.progressEXP.BackColor = System.Drawing.Color.Transparent;
            this.progressEXP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressEXP.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))),
        System.Drawing.Color.Green};
            this.progressEXP.Location = new System.Drawing.Point(51, 76);
            this.progressEXP.Maximum = ((long)(100));
            this.progressEXP.Name = "progressEXP";
            this.progressEXP.PercentIndices = 2;
            this.progressEXP.ShowAsPercent = true;
            this.progressEXP.ShowValue = true;
            this.progressEXP.Size = new System.Drawing.Size(180, 19);
            this.progressEXP.TabIndex = 12;
            this.progressEXP.Text = "50%";
            this.progressEXP.Value = ((long)(50));
            // 
            // progressHGP
            // 
            this.progressHGP.BackColor = System.Drawing.Color.Transparent;
            this.progressHGP.ForeColor = System.Drawing.Color.Yellow;
            this.progressHGP.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))))};
            this.progressHGP.Location = new System.Drawing.Point(51, 55);
            this.progressHGP.Maximum = ((long)(100));
            this.progressHGP.Name = "progressHGP";
            this.progressHGP.PercentIndices = 2;
            this.progressHGP.ShowAsPercent = true;
            this.progressHGP.ShowValue = true;
            this.progressHGP.Size = new System.Drawing.Size(180, 19);
            this.progressHGP.TabIndex = 11;
            this.progressHGP.Text = "50%";
            this.progressHGP.Value = ((long)(50));
            // 
            // progressHP
            // 
            this.progressHP.BackColor = System.Drawing.Color.Transparent;
            this.progressHP.ForeColor = System.Drawing.Color.Firebrick;
            this.progressHP.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.DarkRed};
            this.progressHP.Location = new System.Drawing.Point(51, 34);
            this.progressHP.Maximum = ((long)(100));
            this.progressHP.Name = "progressHP";
            this.progressHP.PercentIndices = 2;
            this.progressHP.ShowAsPercent = false;
            this.progressHP.ShowValue = true;
            this.progressHP.Size = new System.Drawing.Size(180, 19);
            this.progressHP.TabIndex = 10;
            this.progressHP.Text = "50 / 100";
            this.progressHP.Value = ((long)(50));
            // 
            // Pet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPetName);
            this.Controls.Add(this.progressEXP);
            this.Controls.Add(this.progressHGP);
            this.Controls.Add(this.progressHP);
            this.Name = "Pet";
            this.Size = new System.Drawing.Size(250, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SDUI.Controls.ProgressBar progressEXP;
        private SDUI.Controls.ProgressBar progressHGP;
        private SDUI.Controls.ProgressBar progressHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPetName;
    }
}
