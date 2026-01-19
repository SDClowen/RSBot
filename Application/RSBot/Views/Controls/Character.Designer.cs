namespace RSBot.Views.Controls
{


    partial class Character
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
            label3 = new SDUI.Controls.Label();
            label4 = new SDUI.Controls.Label();
            lblLevel = new SDUI.Controls.Label();
            lblGold = new SDUI.Controls.Label();
            lblSP = new SDUI.Controls.Label();
            lblPlayerName = new SDUI.Controls.Label();
            lblStr = new SDUI.Controls.Label();
            label9 = new SDUI.Controls.Label();
            lblInt = new SDUI.Controls.Label();
            label11 = new SDUI.Controls.Label();
            progressEXP = new SDUI.Controls.ProgressBar();
            progressMP = new SDUI.Controls.ProgressBar();
            progressHP = new SDUI.Controls.ProgressBar();
            separator1 = new SDUI.Controls.Separator();
            SuspendLayout();
            // 
            // label3
            // 
            label3.ApplyGradient = false;
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label3.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label3.GradientAnimation = false;
            label3.Location = new System.Drawing.Point(669, 32);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 21);
            label3.TabIndex = 4;
            label3.Text = "Gold:";
            // 
            // label4
            // 
            label4.ApplyGradient = false;
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label4.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label4.GradientAnimation = false;
            label4.Location = new System.Drawing.Point(684, 60);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 21);
            label4.TabIndex = 5;
            label4.Text = "SP:";
            // 
            // lblLevel
            // 
            lblLevel.ApplyGradient = false;
            lblLevel.BackColor = System.Drawing.Color.Transparent;
            lblLevel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblLevel.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblLevel.GradientAnimation = false;
            lblLevel.Location = new System.Drawing.Point(434, 5);
            lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new System.Drawing.Size(81, 19);
            lblLevel.TabIndex = 6;
            lblLevel.Text = "0";
            lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGold
            // 
            lblGold.ApplyGradient = false;
            lblGold.AutoSize = true;
            lblGold.BackColor = System.Drawing.Color.Transparent;
            lblGold.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblGold.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblGold.GradientAnimation = false;
            lblGold.Location = new System.Drawing.Point(721, 34);
            lblGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGold.Name = "lblGold";
            lblGold.Size = new System.Drawing.Size(17, 20);
            lblGold.TabIndex = 7;
            lblGold.Text = "0";
            // 
            // lblSP
            // 
            lblSP.ApplyGradient = false;
            lblSP.AutoSize = true;
            lblSP.BackColor = System.Drawing.Color.Transparent;
            lblSP.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblSP.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblSP.GradientAnimation = false;
            lblSP.Location = new System.Drawing.Point(721, 61);
            lblSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSP.Name = "lblSP";
            lblSP.Size = new System.Drawing.Size(17, 20);
            lblSP.TabIndex = 8;
            lblSP.Text = "0";
            // 
            // lblPlayerName
            // 
            lblPlayerName.ApplyGradient = false;
            lblPlayerName.AutoSize = true;
            lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            lblPlayerName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            lblPlayerName.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblPlayerName.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblPlayerName.GradientAnimation = false;
            lblPlayerName.Location = new System.Drawing.Point(9, 5);
            lblPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new System.Drawing.Size(100, 21);
            lblPlayerName.TabIndex = 9;
            lblPlayerName.Text = "Not in game";
            // 
            // lblStr
            // 
            lblStr.ApplyGradient = false;
            lblStr.AutoSize = true;
            lblStr.BackColor = System.Drawing.Color.Transparent;
            lblStr.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblStr.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblStr.GradientAnimation = false;
            lblStr.Location = new System.Drawing.Point(585, 31);
            lblStr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStr.Name = "lblStr";
            lblStr.Size = new System.Drawing.Size(17, 20);
            lblStr.TabIndex = 11;
            lblStr.Text = "0";
            // 
            // label9
            // 
            label9.ApplyGradient = false;
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label9.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label9.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label9.GradientAnimation = false;
            label9.Location = new System.Drawing.Point(538, 30);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(42, 21);
            label9.TabIndex = 10;
            label9.Text = "STR:";
            // 
            // lblInt
            // 
            lblInt.ApplyGradient = false;
            lblInt.AutoSize = true;
            lblInt.BackColor = System.Drawing.Color.Transparent;
            lblInt.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblInt.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblInt.GradientAnimation = false;
            lblInt.Location = new System.Drawing.Point(585, 60);
            lblInt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblInt.Name = "lblInt";
            lblInt.Size = new System.Drawing.Size(17, 20);
            lblInt.TabIndex = 13;
            lblInt.Text = "0";
            // 
            // label11
            // 
            label11.ApplyGradient = false;
            label11.AutoSize = true;
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label11.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label11.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label11.GradientAnimation = false;
            label11.Location = new System.Drawing.Point(540, 60);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(40, 21);
            label11.TabIndex = 12;
            label11.Text = "INT:";
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
            progressEXP.Location = new System.Drawing.Point(12, 61);
            progressEXP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressEXP.Maximum = 1L;
            progressEXP.MaxPercentShowValue = 99.99F;
            progressEXP.Name = "progressEXP";
            progressEXP.PercentIndices = 2;
            progressEXP.Radius = 6;
            progressEXP.ShowAsPercent = true;
            progressEXP.ShowValue = true;
            progressEXP.Size = new System.Drawing.Size(504, 25);
            progressEXP.TabIndex = 2;
            progressEXP.Text = "0,00%";
            progressEXP.Value = 0L;
            // 
            // progressMP
            // 
            progressMP.BackColor = System.Drawing.Color.Transparent;
            progressMP.DrawHatch = false;
            progressMP.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.MidnightBlue,
    System.Drawing.Color.RoyalBlue
    };
            progressMP.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            progressMP.Location = new System.Drawing.Point(268, 32);
            progressMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressMP.Maximum = 1L;
            progressMP.MaxPercentShowValue = 100F;
            progressMP.Name = "progressMP";
            progressMP.PercentIndices = 2;
            progressMP.Radius = 6;
            progressMP.ShowAsPercent = false;
            progressMP.ShowValue = true;
            progressMP.Size = new System.Drawing.Size(248, 25);
            progressMP.TabIndex = 1;
            progressMP.Text = "0 / 1";
            progressMP.Value = 0L;
            // 
            // progressHP
            // 
            progressHP.BackColor = System.Drawing.Color.Transparent;
            progressHP.DrawHatch = false;
            progressHP.ForeColor = System.Drawing.Color.Firebrick;
            progressHP.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Maroon,
    System.Drawing.Color.Red
    };
            progressHP.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
            progressHP.Location = new System.Drawing.Point(12, 32);
            progressHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressHP.Maximum = 1L;
            progressHP.MaxPercentShowValue = 100F;
            progressHP.Name = "progressHP";
            progressHP.PercentIndices = 2;
            progressHP.Radius = 6;
            progressHP.ShowAsPercent = false;
            progressHP.ShowValue = true;
            progressHP.Size = new System.Drawing.Size(248, 25);
            progressHP.TabIndex = 0;
            progressHP.Text = "0 / 1";
            progressHP.Value = 0L;
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(0, 92);
            separator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(869, 2);
            separator1.TabIndex = 14;
            separator1.Visible = false;
            // 
            // Character
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(separator1);
            Controls.Add(lblInt);
            Controls.Add(label11);
            Controls.Add(lblStr);
            Controls.Add(label9);
            Controls.Add(lblPlayerName);
            Controls.Add(lblSP);
            Controls.Add(lblGold);
            Controls.Add(lblLevel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(progressEXP);
            Controls.Add(progressMP);
            Controls.Add(progressHP);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "Character";
            Size = new System.Drawing.Size(869, 94);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SDUI.Controls.ProgressBar progressHP;
        private SDUI.Controls.ProgressBar progressMP;
        private SDUI.Controls.ProgressBar progressEXP;
        private SDUI.Controls.Label label3;
        private SDUI.Controls.Label label4;
        private SDUI.Controls.Label lblLevel;
        private SDUI.Controls.Label lblGold;
        private SDUI.Controls.Label lblSP;
        private SDUI.Controls.Label lblPlayerName;
        private SDUI.Controls.Label lblStr;
        private SDUI.Controls.Label label9;
        private SDUI.Controls.Label lblInt;
        private SDUI.Controls.Label label11;
        private SDUI.Controls.Separator separator1;
    }
}
