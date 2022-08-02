﻿namespace RSBot.Alchemy.Views.Settings
{
    partial class AttributeInfoPanel
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
            this.comboMaxValue = new SDUI.Controls.ComboBox();
            this.lblItemAmount = new SDUI.Controls.Label();
            this.separator1 = new SDUI.Controls.Separator();
            this.checkSelected = new SDUI.Controls.CheckBox();
            this.SuspendLayout();
            // 
            // comboMaxValue
            // 
            this.comboMaxValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboMaxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMaxValue.FormattingEnabled = true;
            this.comboMaxValue.Items.AddRange(new object[] {
            "22%",
            "41%",
            "61%",
            "80%",
            "100%"});
            this.comboMaxValue.Location = new System.Drawing.Point(197, 5);
            this.comboMaxValue.Name = "comboMaxValue";
            this.comboMaxValue.Size = new System.Drawing.Size(121, 24);
            this.comboMaxValue.TabIndex = 1;
            // 
            // lblItemAmount
            // 
            this.lblItemAmount.AutoSize = true;
            this.lblItemAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItemAmount.Location = new System.Drawing.Point(324, 8);
            this.lblItemAmount.Name = "lblItemAmount";
            this.lblItemAmount.Size = new System.Drawing.Size(19, 15);
            this.lblItemAmount.TabIndex = 2;
            this.lblItemAmount.Text = "x0";
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(0, 33);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(391, 10);
            this.separator1.TabIndex = 3;
            this.separator1.Text = "separator1";
            // 
            // checkSelected
            // 
            this.checkSelected.AutoSize = true;
            this.checkSelected.BackColor = System.Drawing.Color.Transparent;
            this.checkSelected.Checked = false;
            this.checkSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkSelected.Location = new System.Drawing.Point(18, 8);
            this.checkSelected.Name = "checkSelected";
            this.checkSelected.Size = new System.Drawing.Size(96, 15);
            this.checkSelected.TabIndex = 4;
            this.checkSelected.Text = "Phy. reinforce";
            // 
            // AttributeInfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.lblItemAmount);
            this.Controls.Add(this.comboMaxValue);
            this.Controls.Add(this.checkSelected);
            this.Name = "AttributeInfoPanel";
            this.Size = new System.Drawing.Size(391, 43);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SDUI.Controls.ComboBox comboMaxValue;
        private SDUI.Controls.Label lblItemAmount;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.CheckBox checkSelected;
    }
}
