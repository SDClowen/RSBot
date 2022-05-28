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
            this.label2 = new SDUI.Controls.Label();
            this.label3 = new SDUI.Controls.Label();
            this.progressEXP = new SDUI.Controls.ProgressBar();
            this.progressHGP = new SDUI.Controls.ProgressBar();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "HGP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(9, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "EXP:";
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
            this.progressEXP.Location = new System.Drawing.Point(48, 87);
            this.progressEXP.Maximum = ((long)(100));
            this.progressEXP.Name = "progressEXP";
            this.progressEXP.PercentIndices = 2;
            this.progressEXP.Radius = 0;
            this.progressEXP.ShowAsPercent = true;
            this.progressEXP.ShowValue = true;
            this.progressEXP.Size = new System.Drawing.Size(180, 16);
            this.progressEXP.TabIndex = 12;
            this.progressEXP.Text = "0%";
            this.progressEXP.Value = ((long)(0));
            // 
            // progressHGP
            // 
            this.progressHGP.BackColor = System.Drawing.Color.Transparent;
            this.progressHGP.DrawHatch = false;
            this.progressHGP.ForeColor = System.Drawing.Color.Yellow;
            this.progressHGP.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Gold,
        System.Drawing.Color.Yellow};
            this.progressHGP.HatchType = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.progressHGP.Location = new System.Drawing.Point(48, 66);
            this.progressHGP.Maximum = ((long)(100));
            this.progressHGP.Name = "progressHGP";
            this.progressHGP.PercentIndices = 2;
            this.progressHGP.Radius = 0;
            this.progressHGP.ShowAsPercent = true;
            this.progressHGP.ShowValue = true;
            this.progressHGP.Size = new System.Drawing.Size(180, 16);
            this.progressHGP.TabIndex = 11;
            this.progressHGP.Text = "0%";
            this.progressHGP.Value = ((long)(0));
            // 
            // Growth
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressEXP);
            this.Controls.Add(this.progressHGP);
            this.MaximumSize = new System.Drawing.Size(242, 110);
            this.MinimumSize = new System.Drawing.Size(242, 110);
            this.Name = "Growth";
            this.Size = new System.Drawing.Size(242, 110);
            this.Controls.SetChildIndex(this.progressHGP, 0);
            this.Controls.SetChildIndex(this.progressEXP, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.progressHP, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SDUI.Controls.ProgressBar progressEXP;
        private SDUI.Controls.ProgressBar progressHGP;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.Label label3;
    }
}
