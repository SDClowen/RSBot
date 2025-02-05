namespace RSBot.Views.Controls.Cos
{
    partial class Fellow
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
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            progressEXP = new System.Windows.Forms.ProgressBar();
            progressSatiety = new System.Windows.Forms.ProgressBar();
            progressBarStoredSp = new System.Windows.Forms.ProgressBar();
            label4 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // labelLevel
            // 
            labelLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            
            // 
            lblPetName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // progressHP
            // 
            progressHP.Location = new System.Drawing.Point(60, 56);
            progressHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressHP.Size = new System.Drawing.Size(225, 20);
            // 
            // label3
            // 
            
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Location = new System.Drawing.Point(12, 110);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(37, 20);
            label3.TabIndex = 23;
            label3.Text = "EXP:";
            // 
            // label2
            
            label2.AutoSize = true;
            
            label2.Location = new System.Drawing.Point(-1, 82);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 20);
            label2.TabIndex = 22;
            label2.Text = "Satie..:";
            // 
            // progressEXP
            // 
            progressEXP.BackColor = System.Drawing.SystemColors.Control;
            progressEXP.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            progressEXP.Location = new System.Drawing.Point(60, 110);
            progressEXP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressEXP.Name = "progressEXP";
            progressEXP.Size = new System.Drawing.Size(225, 20);
            progressEXP.TabIndex = 19;
            
            // 
            
            // 
            progressSatiety.BackColor = System.Drawing.SystemColors.Control;
            progressSatiety.ForeColor = System.Drawing.Color.Yellow;
            progressSatiety.Location = new System.Drawing.Point(60, 82);
            progressSatiety.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressSatiety.Name = "progressSatiety";
            progressSatiety.Size = new System.Drawing.Size(225, 20);
            progressSatiety.TabIndex = 18;
            progressSatiety.Text = "0 / 100";
            // 
            // progressBarStoredSp
            // 
            progressBarStoredSp.BackColor = System.Drawing.SystemColors.Control;
            progressBarStoredSp.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            progressBarStoredSp.Location = new System.Drawing.Point(60, 138);
            progressBarStoredSp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            
            progressBarStoredSp.Size = new System.Drawing.Size(225, 20);
            
            progressBarStoredSp.Text = "0 / 100";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Location = new System.Drawing.Point(21, 138);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(29, 20);
            label4.TabIndex = 23;
            label4.Text = "Sp:";
            // 
            // Fellow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(label4);
            
            Controls.Add(label2);
            Controls.Add(progressBarStoredSp);
            Controls.Add(progressEXP);
            Controls.Add(progressSatiety);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MaximumSize = new System.Drawing.Size(302, 169);
            MinimumSize = new System.Drawing.Size(302, 169);
            Name = "Fellow";
            Size = new System.Drawing.Size(302, 169);
            Controls.SetChildIndex(progressSatiety, 0);
            Controls.SetChildIndex(progressEXP, 0);
            Controls.SetChildIndex(progressBarStoredSp, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(progressHP, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressEXP;
        private System.Windows.Forms.ProgressBar progressSatiety;
        private System.Windows.Forms.ProgressBar progressBarStoredSp;
        private System.Windows.Forms.Label label4;
    }
}
