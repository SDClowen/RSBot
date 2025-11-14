namespace RSBot.Alchemy.Views.Settings
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
            components = new System.ComponentModel.Container();
            comboMaxValue = new SDUI.Controls.ComboBox();
            lblItemAmount = new SDUI.Controls.Label();
            separator1 = new SDUI.Controls.Separator();
            checkSelected = new SDUI.Controls.CheckBox();
            tipStone = new System.Windows.Forms.ToolTip(components);
            lblFinished = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // comboMaxValue
            // 
            comboMaxValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboMaxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboMaxValue.FormattingEnabled = true;
            comboMaxValue.Items.AddRange(new object[] { "22%", "41%", "61%", "80%", "100%" });
            comboMaxValue.Location = new System.Drawing.Point(197, 5);
            comboMaxValue.Name = "comboMaxValue";
            comboMaxValue.Radius = 5;
            comboMaxValue.ShadowDepth = 4F;
            comboMaxValue.Size = new System.Drawing.Size(121, 24);
            comboMaxValue.TabIndex = 1;
            // 
            // lblItemAmount
            // 
            lblItemAmount.ApplyGradient = false;
            lblItemAmount.AutoSize = true;
            lblItemAmount.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            lblItemAmount.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            lblItemAmount.GradientAnimation = false;
            lblItemAmount.Location = new System.Drawing.Point(324, 8);
            lblItemAmount.Name = "lblItemAmount";
            lblItemAmount.Size = new System.Drawing.Size(18, 15);
            lblItemAmount.TabIndex = 2;
            lblItemAmount.Text = "x0";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(0, 32);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(438, 10);
            separator1.TabIndex = 3;
            // 
            // checkSelected
            // 
            checkSelected.AutoSize = true;
            checkSelected.BackColor = System.Drawing.Color.Transparent;
            checkSelected.Depth = 0;
            checkSelected.Font = new System.Drawing.Font("Segoe UI", 9F);
            checkSelected.Location = new System.Drawing.Point(18, 8);
            checkSelected.Margin = new System.Windows.Forms.Padding(0);
            checkSelected.MouseLocation = new System.Drawing.Point(-1, -1);
            checkSelected.Name = "checkSelected";
            checkSelected.Ripple = true;
            checkSelected.Size = new System.Drawing.Size(106, 30);
            checkSelected.TabIndex = 4;
            checkSelected.Text = "Phy. reinforce";
            checkSelected.UseVisualStyleBackColor = false;
            // 
            // tipStone
            // 
            tipStone.AutomaticDelay = 0;
            tipStone.IsBalloon = true;
            // 
            // lblFinished
            // 
            lblFinished.AutoSize = true;
            lblFinished.BackColor = System.Drawing.Color.Transparent;
            lblFinished.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            lblFinished.ForeColor = System.Drawing.Color.Green;
            lblFinished.Location = new System.Drawing.Point(378, 4);
            lblFinished.Name = "lblFinished";
            lblFinished.Size = new System.Drawing.Size(27, 25);
            lblFinished.TabIndex = 5;
            lblFinished.Text = "✓";
            // 
            // AttributeInfoPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lblFinished);
            Controls.Add(separator1);
            Controls.Add(lblItemAmount);
            Controls.Add(comboMaxValue);
            Controls.Add(checkSelected);
            Name = "AttributeInfoPanel";
            Size = new System.Drawing.Size(438, 42);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private SDUI.Controls.ComboBox comboMaxValue;
        private SDUI.Controls.Label lblItemAmount;
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.CheckBox checkSelected;
        private System.Windows.Forms.ToolTip tipStone;
        private System.Windows.Forms.Label lblFinished;
    }
}
