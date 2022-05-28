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
            this.label3 = new SDUI.Controls.Label();
            this.label2 = new SDUI.Controls.Label();
            this.progressEXP = new SDUI.Controls.ProgressBar();
            this.progressSatiety = new SDUI.Controls.ProgressBar();
            this.progressBarStoredSp = new SDUI.Controls.ProgressBar();
            this.label4 = new SDUI.Controls.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "EXP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(-1, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Satie..:";
            // 
            // progressEXP
            // 
            this.progressEXP.BackColor = System.Drawing.Color.Transparent;
            this.progressEXP.DrawHatch = false;
            this.progressEXP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressEXP.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.DarkGreen,
        System.Drawing.Color.Lime};
            this.progressEXP.HatchType = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.progressEXP.Location = new System.Drawing.Point(48, 88);
            this.progressEXP.Maximum = ((long)(100));
            this.progressEXP.Name = "progressEXP";
            this.progressEXP.PercentIndices = 2;
            this.progressEXP.Radius = 0;
            this.progressEXP.ShowAsPercent = true;
            this.progressEXP.ShowValue = true;
            this.progressEXP.Size = new System.Drawing.Size(180, 16);
            this.progressEXP.TabIndex = 19;
            this.progressEXP.Text = "0%";
            this.progressEXP.Value = ((long)(0));
            // 
            // progressSatiety
            // 
            this.progressSatiety.BackColor = System.Drawing.Color.Transparent;
            this.progressSatiety.DrawHatch = false;
            this.progressSatiety.ForeColor = System.Drawing.Color.Yellow;
            this.progressSatiety.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Turquoise,
        System.Drawing.Color.DodgerBlue};
            this.progressSatiety.HatchType = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.progressSatiety.Location = new System.Drawing.Point(48, 66);
            this.progressSatiety.Maximum = ((long)(100));
            this.progressSatiety.Name = "progressSatiety";
            this.progressSatiety.PercentIndices = 2;
            this.progressSatiety.Radius = 0;
            this.progressSatiety.ShowAsPercent = false;
            this.progressSatiety.ShowValue = true;
            this.progressSatiety.Size = new System.Drawing.Size(180, 16);
            this.progressSatiety.TabIndex = 18;
            this.progressSatiety.Text = "0 / 100";
            this.progressSatiety.Value = ((long)(0));
            // 
            // progressBarStoredSp
            // 
            this.progressBarStoredSp.BackColor = System.Drawing.Color.Transparent;
            this.progressBarStoredSp.DrawHatch = false;
            this.progressBarStoredSp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBarStoredSp.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Navy,
        System.Drawing.Color.RoyalBlue};
            this.progressBarStoredSp.HatchType = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.progressBarStoredSp.Location = new System.Drawing.Point(48, 110);
            this.progressBarStoredSp.Maximum = ((long)(100));
            this.progressBarStoredSp.Name = "progressBarStoredSp";
            this.progressBarStoredSp.PercentIndices = 2;
            this.progressBarStoredSp.Radius = 0;
            this.progressBarStoredSp.ShowAsPercent = false;
            this.progressBarStoredSp.ShowValue = true;
            this.progressBarStoredSp.Size = new System.Drawing.Size(180, 16);
            this.progressBarStoredSp.TabIndex = 19;
            this.progressBarStoredSp.Text = "0 / 100";
            this.progressBarStoredSp.Value = ((long)(0));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(17, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Sp:";
            // 
            // Fellow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBarStoredSp);
            this.Controls.Add(this.progressEXP);
            this.Controls.Add(this.progressSatiety);
            this.MaximumSize = new System.Drawing.Size(242, 135);
            this.MinimumSize = new System.Drawing.Size(242, 135);
            this.Name = "Fellow";
            this.Size = new System.Drawing.Size(242, 135);
            this.Controls.SetChildIndex(this.progressSatiety, 0);
            this.Controls.SetChildIndex(this.progressEXP, 0);
            this.Controls.SetChildIndex(this.progressBarStoredSp, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.progressHP, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDUI.Controls.Label label3;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.ProgressBar progressEXP;
        private SDUI.Controls.ProgressBar progressSatiety;
        private SDUI.Controls.ProgressBar progressBarStoredSp;
        private SDUI.Controls.Label label4;
    }
}
