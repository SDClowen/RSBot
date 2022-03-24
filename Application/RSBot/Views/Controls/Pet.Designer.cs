﻿namespace RSBot.Views.Controls
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
            this.label4 = new System.Windows.Forms.Label();
            this.progressHP = new Framework.Controls.XpProgressBar();
            this.progressHGP = new Framework.Controls.XpProgressBar();
            this.progressEXP = new Framework.Controls.XpProgressBar();
            this.SuspendLayout();
            // 
            // lblPetName
            // 
            this.lblPetName.AutoSize = true;
            this.lblPetName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetName.Location = new System.Drawing.Point(65, 14);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(79, 15);
            this.lblPetName.TabIndex = 13;
            this.lblPetName.Text = "no pet found";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "HP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "HGP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "EXP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Pet Level:";
            // 
            // progressHP
            // 
            this.progressHP.ColorBackGround = System.Drawing.Color.Gainsboro;
            this.progressHP.ColorBarBorder = System.Drawing.Color.DarkRed;
            this.progressHP.ColorBarCenter = System.Drawing.Color.Red;
            this.progressHP.ColorText = System.Drawing.Color.Yellow;
            this.progressHP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressHP.Location = new System.Drawing.Point(51, 34);
            this.progressHP.Name = "progressHP";
            this.progressHP.Position = 0;
            this.progressHP.PositionMax = 100;
            this.progressHP.PositionMin = 0;
            this.progressHP.Size = new System.Drawing.Size(180, 19);
            this.progressHP.SteepDistance = ((byte)(0));
            this.progressHP.TabIndex = 18;
            // 
            // progressHGP
            // 
            this.progressHGP.ColorBackGround = System.Drawing.Color.Gainsboro;
            this.progressHGP.ColorBarBorder = System.Drawing.Color.DarkKhaki;
            this.progressHGP.ColorBarCenter = System.Drawing.Color.Yellow;
            this.progressHGP.ColorText = System.Drawing.Color.Goldenrod;
            this.progressHGP.Location = new System.Drawing.Point(51, 55);
            this.progressHGP.Name = "progressHGP";
            this.progressHGP.Position = 0;
            this.progressHGP.PositionMax = 100;
            this.progressHGP.PositionMin = 0;
            this.progressHGP.Size = new System.Drawing.Size(180, 19);
            this.progressHGP.SteepDistance = ((byte)(0));
            this.progressHGP.TabIndex = 20;
            // 
            // progressEXP
            // 
            this.progressEXP.ColorBackGround = System.Drawing.Color.Gainsboro;
            this.progressEXP.ColorBarBorder = System.Drawing.Color.Green;
            this.progressEXP.ColorBarCenter = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressEXP.ColorText = System.Drawing.Color.Yellow;
            this.progressEXP.Location = new System.Drawing.Point(51, 76);
            this.progressEXP.Name = "progressEXP";
            this.progressEXP.Position = 0;
            this.progressEXP.PositionMax = 100;
            this.progressEXP.PositionMin = 0;
            this.progressEXP.Size = new System.Drawing.Size(180, 19);
            this.progressEXP.SteepDistance = ((byte)(0));
            this.progressEXP.TabIndex = 21;
            // 
            // Pet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.progressEXP);
            this.Controls.Add(this.progressHGP);
            this.Controls.Add(this.progressHP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPetName);
            this.Name = "Pet";
            this.Size = new System.Drawing.Size(250, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Framework.Controls.XpProgressBar progressHP;
        private Framework.Controls.XpProgressBar progressHGP;
        private Framework.Controls.XpProgressBar progressEXP;
    }
}
