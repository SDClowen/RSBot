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
            label2 = new SDUI.Controls.Label();
            label3 = new SDUI.Controls.Label();
            progressEXP = new SDUI.Controls.ProgressBar();
            progressHGP = new SDUI.Controls.ProgressBar();
            SuspendLayout();
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
            label2.Location = new System.Drawing.Point(6, 65);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 15;
            label2.Text = "HGP:";
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
            label3.Location = new System.Drawing.Point(9, 86);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 15);
            label3.TabIndex = 16;
            label3.Text = "EXP:";
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
            progressEXP.Location = new System.Drawing.Point(48, 87);
            progressEXP.Maximum = 100L;
            progressEXP.MaxPercentShowValue = 99.99F;
            progressEXP.Name = "progressEXP";
            progressEXP.PercentIndices = 2;
            progressEXP.Radius = 1;
            progressEXP.ShowAsPercent = true;
            progressEXP.ShowValue = true;
            progressEXP.Size = new System.Drawing.Size(180, 16);
            progressEXP.TabIndex = 12;
            progressEXP.Text = "0.00%";
            progressEXP.Value = 0L;
            // 
            // progressHGP
            // 
            progressHGP.BackColor = System.Drawing.Color.Transparent;
            progressHGP.DrawHatch = false;
            progressHGP.ForeColor = System.Drawing.Color.Yellow;
            progressHGP.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gold,
    System.Drawing.Color.Yellow
    };
            progressHGP.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            progressHGP.Location = new System.Drawing.Point(48, 66);
            progressHGP.Maximum = 100L;
            progressHGP.MaxPercentShowValue = 100F;
            progressHGP.Name = "progressHGP";
            progressHGP.PercentIndices = 2;
            progressHGP.Radius = 1;
            progressHGP.ShowAsPercent = true;
            progressHGP.ShowValue = true;
            progressHGP.Size = new System.Drawing.Size(180, 16);
            progressHGP.TabIndex = 11;
            progressHGP.Text = "0.00%";
            progressHGP.Value = 0L;
            // 
            // Growth
            // 
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(progressEXP);
            Controls.Add(progressHGP);
            MaximumSize = new System.Drawing.Size(242, 110);
            MinimumSize = new System.Drawing.Size(242, 110);
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
        private SDUI.Controls.ProgressBar progressEXP;
        private SDUI.Controls.ProgressBar progressHGP;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label label3;
    }
}
