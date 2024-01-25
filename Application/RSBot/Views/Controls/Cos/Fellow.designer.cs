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
            label3 = new SDUI.Controls.Label();
            label2 = new SDUI.Controls.Label();
            progressEXP = new SDUI.Controls.ProgressBar();
            progressSatiety = new SDUI.Controls.ProgressBar();
            progressBarStoredSp = new SDUI.Controls.ProgressBar();
            label4 = new SDUI.Controls.Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(10, 88);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 15);
            label3.TabIndex = 23;
            label3.Text = "EXP:";
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(-1, 66);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 15);
            label2.TabIndex = 22;
            label2.Text = "Satie..:";
            // 
            // progressEXP
            // 
            progressEXP.BackColor = System.Drawing.Color.Transparent;
            progressEXP.DrawHatch = false;
            progressEXP.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            progressEXP.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.DarkGreen,
    System.Drawing.Color.Lime
    };
            progressEXP.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            progressEXP.Location = new System.Drawing.Point(48, 88);
            progressEXP.Maximum = 100L;
            progressEXP.MaxPercentShowValue = 99.99F;
            progressEXP.Name = "progressEXP";
            progressEXP.PercentIndices = 2;
            progressEXP.Radius = 1;
            progressEXP.ShowAsPercent = true;
            progressEXP.ShowValue = true;
            progressEXP.Size = new System.Drawing.Size(180, 16);
            progressEXP.TabIndex = 19;
            progressEXP.Text = "0.00%";
            progressEXP.Value = 0L;
            // 
            // progressSatiety
            // 
            progressSatiety.BackColor = System.Drawing.Color.Transparent;
            progressSatiety.DrawHatch = false;
            progressSatiety.ForeColor = System.Drawing.Color.Yellow;
            progressSatiety.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Turquoise,
    System.Drawing.Color.DodgerBlue
    };
            progressSatiety.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            progressSatiety.Location = new System.Drawing.Point(48, 66);
            progressSatiety.Maximum = 100L;
            progressSatiety.MaxPercentShowValue = 100F;
            progressSatiety.Name = "progressSatiety";
            progressSatiety.PercentIndices = 2;
            progressSatiety.Radius = 1;
            progressSatiety.ShowAsPercent = false;
            progressSatiety.ShowValue = true;
            progressSatiety.Size = new System.Drawing.Size(180, 16);
            progressSatiety.TabIndex = 18;
            progressSatiety.Text = "0 / 100";
            progressSatiety.Value = 0L;
            // 
            // progressBarStoredSp
            // 
            progressBarStoredSp.BackColor = System.Drawing.Color.Transparent;
            progressBarStoredSp.DrawHatch = false;
            progressBarStoredSp.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            progressBarStoredSp.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Navy,
    System.Drawing.Color.RoyalBlue
    };
            progressBarStoredSp.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            progressBarStoredSp.Location = new System.Drawing.Point(48, 110);
            progressBarStoredSp.Maximum = 100L;
            progressBarStoredSp.MaxPercentShowValue = 100F;
            progressBarStoredSp.Name = "progressBarStoredSp";
            progressBarStoredSp.PercentIndices = 2;
            progressBarStoredSp.Radius = 1;
            progressBarStoredSp.ShowAsPercent = false;
            progressBarStoredSp.ShowValue = true;
            progressBarStoredSp.Size = new System.Drawing.Size(180, 16);
            progressBarStoredSp.TabIndex = 19;
            progressBarStoredSp.Text = "0 / 100";
            progressBarStoredSp.Value = 0L;
            // 
            // label4
            // 
            label4.ApplyGradient = false;
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label4.GradientAnimation = false;
            label4.Location = new System.Drawing.Point(17, 110);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(23, 15);
            label4.TabIndex = 23;
            label4.Text = "Sp:";
            // 
            // Fellow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(progressBarStoredSp);
            Controls.Add(progressEXP);
            Controls.Add(progressSatiety);
            MaximumSize = new System.Drawing.Size(242, 135);
            MinimumSize = new System.Drawing.Size(242, 135);
            Name = "Fellow";
            Size = new System.Drawing.Size(242, 135);
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

        private SDUI.Controls.Label label3;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.ProgressBar progressEXP;
        private SDUI.Controls.ProgressBar progressSatiety;
        private SDUI.Controls.ProgressBar progressBarStoredSp;
        private SDUI.Controls.Label label4;
    }
}
