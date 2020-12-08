namespace RSBot.Shopping.Views
{
    partial class AmountDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new Theme.Material.Button();
            this.btnCancel = new Theme.Material.Button();
            this.numValue = new System.Windows.Forms.NumericUpDown();
            this.lblItemName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the amount the bot should buy \r\nfor the specified item:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 32);
            this.panel1.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Depth = 0;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Icon = null;
            this.btnOK.Location = new System.Drawing.Point(154, 4);
            this.btnOK.MouseState = Theme.IMatMouseState.HOVER;
            this.btnOK.Name = "btnOK";
            this.btnOK.Primary = true;
            this.btnOK.Raised = true;
            this.btnOK.SingleColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(235, 4);
            this.btnCancel.MouseState = Theme.IMatMouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = false;
            this.btnCancel.Raised = false;
            this.btnCancel.SingleColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // numValue
            // 
            this.numValue.Location = new System.Drawing.Point(15, 72);
            this.numValue.Maximum = new decimal(new int[] {
            32765,
            0,
            0,
            0});
            this.numValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(156, 23);
            this.numValue.TabIndex = 0;
            this.numValue.ThousandsSeparator = true;
            this.numValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numValue_KeyUp);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(12, 9);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(143, 15);
            this.lblItemName.TabIndex = 6;
            this.lblItemName.Text = "HP Recovery Potion (XL)";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 2);
            this.label2.TabIndex = 7;
            // 
            // AmountDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 142);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.numValue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AmountDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Amount";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Theme.Material.Button btnOK;
        private Theme.Material.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numValue;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label label2;
    }
}