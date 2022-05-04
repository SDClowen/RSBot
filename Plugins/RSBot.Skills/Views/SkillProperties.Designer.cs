﻿namespace RSBot.Skills.Views
{
    partial class SkillProperties
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
            this.propItem = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // propItem
            // 
            this.propItem.BackColor = System.Drawing.SystemColors.Control;
            this.propItem.CategoryForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.propItem.CategorySplitterColor = System.Drawing.SystemColors.ControlDark;
            this.propItem.CommandsBackColor = System.Drawing.SystemColors.ControlDark;
            this.propItem.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.propItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propItem.HelpBackColor = System.Drawing.SystemColors.ControlDark;
            this.propItem.HelpVisible = false;
            this.propItem.LineColor = System.Drawing.SystemColors.WindowFrame;
            this.propItem.Location = new System.Drawing.Point(0, 0);
            this.propItem.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.propItem.Name = "propItem";
            this.propItem.SelectedItemWithFocusBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.propItem.SelectedItemWithFocusForeColor = System.Drawing.SystemColors.GrayText;
            this.propItem.Size = new System.Drawing.Size(662, 650);
            this.propItem.TabIndex = 0;
            this.propItem.ViewBackColor = System.Drawing.SystemColors.InfoText;
            this.propItem.ViewForeColor = System.Drawing.SystemColors.HighlightText;
            // 
            // SkillProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(662, 650);
            this.Controls.Add(this.propItem);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "SkillProperties";
            this.Text = "SkillProperties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propItem;
    }
}