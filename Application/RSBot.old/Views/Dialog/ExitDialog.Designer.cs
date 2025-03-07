namespace RSBot.Views
{
    partial class ExitDialog
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
            labelInfo = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            btnNo = new System.Windows.Forms.Button();
            btnYes = new System.Windows.Forms.Button();
            checkDontAskAgain = new System.Windows.Forms.CheckBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelInfo
            // 
            
            labelInfo.AutoSize = true;
            
                        
            labelInfo.Location = new System.Drawing.Point(160, 26);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new System.Drawing.Size(265, 45);
            labelInfo.TabIndex = 0;
            labelInfo.Text = "Are you sure that you want to exit RSBot?\r\nThis will disconnect you from the Silkroad Server!\r\n\r\n";
            // 
            // panel1
            // 
            
            
            panel1.Controls.Add(btnNo);
            panel1.Controls.Add(btnYes);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 129);
            panel1.Name = "panel1";
            
            
            panel1.Size = new System.Drawing.Size(441, 49);
            panel1.TabIndex = 1;
            // 
            // btnNo
            // 
            
            btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            btnNo.Location = new System.Drawing.Point(349, 14);
            btnNo.Name = "btnNo";
            
            
            btnNo.Size = new System.Drawing.Size(75, 23);
            btnNo.TabIndex = 1;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            btnYes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            
            btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            btnYes.Location = new System.Drawing.Point(268, 14);
            btnYes.Name = "btnYes";
            
            
            btnYes.Size = new System.Drawing.Size(75, 23);
            btnYes.TabIndex = 0;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = true;
            // 
            // checkDontAskAgain
            // 
            checkDontAskAgain.AutoSize = true;
            
            checkDontAskAgain.Location = new System.Drawing.Point(9, 139);
            checkDontAskAgain.Margin = new System.Windows.Forms.Padding(0);
            
            checkDontAskAgain.Name = "checkDontAskAgain";
            
            checkDontAskAgain.Size = new System.Drawing.Size(114, 30);
            checkDontAskAgain.TabIndex = 2;
            checkDontAskAgain.Text = "Don't ask again";
            checkDontAskAgain.UseVisualStyleBackColor = false;
            checkDontAskAgain.CheckedChanged += checkDontAskAgain_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.app;
            pictureBox1.Location = new System.Drawing.Point(15, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(111, 110);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // ExitDialog
            // 
            AcceptButton = btnYes;
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CancelButton = btnNo;
            ClientSize = new System.Drawing.Size(441, 178);
            Controls.Add(labelInfo);
            Controls.Add(checkDontAskAgain);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            ForeColor = System.Drawing.Color.Black;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExitDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Load += ExitDialog_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.CheckBox checkDontAskAgain;
    }
}