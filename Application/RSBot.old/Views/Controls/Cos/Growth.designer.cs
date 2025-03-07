namespace RSBot.Views.Controls.Cos
{
    partial class Growth
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
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            progressEXP = new System.Windows.Forms.ProgressBar();
            progressHGP = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 20);
            label2.TabIndex = 15;
            label2.Text = "HGP:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Location = new System.Drawing.Point(9, 86);
            label3.Name = "label3";
            
            label3.TabIndex = 16;
            label3.Text = "EXP:";
            // 
            // progressEXP
            // 
            progressEXP.BackColor = System.Drawing.SystemColors.Control;
            progressEXP.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            progressEXP.Location = new System.Drawing.Point(48, 87);
            progressEXP.Name = "progressEXP";
            
            progressEXP.TabIndex = 12;
            
            // 
            // progressHGP
            // 
            progressHGP.BackColor = System.Drawing.SystemColors.Control;
            progressHGP.ForeColor = System.Drawing.Color.Yellow;
            progressHGP.Location = new System.Drawing.Point(48, 66);
            progressHGP.Name = "progressHGP";
            progressHGP.Size = new System.Drawing.Size(180, 16);
            progressHGP.TabIndex = 11;
            progressHGP.Text = "0.00%";
            // 
            // Growth
            // 
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(progressEXP);
            
            MaximumSize = new System.Drawing.Size(242, 110);
            
            Name = "Growth";
            Size = new System.Drawing.Size(242, 110);
            Controls.SetChildIndex(progressHGP, 0);
            Controls.SetChildIndex(progressEXP, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(progressHP, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ProgressBar progressEXP;
        private System.Windows.Forms.ProgressBar progressHGP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
