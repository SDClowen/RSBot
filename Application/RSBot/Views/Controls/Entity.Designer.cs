﻿namespace RSBot.Views.Controls
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
            this.label1 = new SDUI.Controls.Label();
            this.lblEntityName = new SDUI.Controls.Label();
            this.lblType = new SDUI.Controls.Label();
            this.progressHP = new SDUI.Controls.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "HP:";
            // 
            // lblEntityName
            // 
            this.lblEntityName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntityName.Location = new System.Drawing.Point(49, 12);
            this.lblEntityName.Name = "lblEntityName";
            this.lblEntityName.Size = new System.Drawing.Size(109, 15);
            this.lblEntityName.TabIndex = 16;
            this.lblEntityName.Text = "No entity selected";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(49, 57);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 13);
            this.lblType.TabIndex = 18;
            // 
            // progressHP
            // 
            this.progressHP.BackColor = System.Drawing.Color.Transparent;
            this.progressHP.ForeColor = System.Drawing.Color.Firebrick;
            this.progressHP.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Maroon,
        System.Drawing.Color.Red};
            this.progressHP.Location = new System.Drawing.Point(52, 38);
            this.progressHP.Maximum = ((long)(100));
            this.progressHP.Name = "progressHP";
            this.progressHP.PercentIndices = 2;
            this.progressHP.ShowAsPercent = false;
            this.progressHP.ShowValue = true;
            this.progressHP.Size = new System.Drawing.Size(180, 16);
            this.progressHP.TabIndex = 15;
            this.progressHP.Text = "50 / 100";
            this.progressHP.Value = ((long)(50));
            // 
            // Entity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEntityName);
            this.Controls.Add(this.progressHP);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Entity";
            this.Size = new System.Drawing.Size(250, 75);
            this.ResumeLayout(false);

        }

        #endregion

        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label lblEntityName;
        private SDUI.Controls.ProgressBar progressHP;
        private SDUI.Controls.Label lblType;
    }
}
