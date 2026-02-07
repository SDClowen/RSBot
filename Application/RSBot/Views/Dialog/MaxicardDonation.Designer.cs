namespace RSBot.Views.Dialog
{
    partial class MaxicardDonation
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
            label1 = new SDUI.Controls.Label();
            textBoxCode = new SDUI.Controls.TextBox();
            label2 = new SDUI.Controls.Label();
            textBoxPassword = new SDUI.Controls.TextBox();
            buttonUse = new SDUI.Controls.Button();
            buttonCancel = new SDUI.Controls.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label1.GradientAnimation = false;
            label1.Location = new System.Drawing.Point(25, 107);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(162, 23);
            label1.TabIndex = 0;
            label1.Text = "Epin Code";
            // 
            // textBoxCode
            // 
            textBoxCode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            textBoxCode.Location = new System.Drawing.Point(25, 134);
            textBoxCode.MaxLength = 32767;
            textBoxCode.MultiLine = false;
            textBoxCode.Name = "textBoxCode";
            textBoxCode.PassFocusShow = false;
            textBoxCode.Radius = 2;
            textBoxCode.Size = new System.Drawing.Size(352, 28);
            textBoxCode.TabIndex = 1;
            textBoxCode.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxCode.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            label2.ApplyGradient = false;
            label2.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            label2.GradientAnimation = false;
            label2.Location = new System.Drawing.Point(25, 197);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(162, 23);
            label2.TabIndex = 0;
            label2.Text = "EPIN Password";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            textBoxPassword.Location = new System.Drawing.Point(25, 224);
            textBoxPassword.MaxLength = 32767;
            textBoxPassword.MultiLine = false;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PassFocusShow = false;
            textBoxPassword.Radius = 2;
            textBoxPassword.Size = new System.Drawing.Size(352, 28);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxPassword.UseSystemPasswordChar = false;
            // 
            // buttonUse
            // 
            buttonUse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonUse.BackColor = System.Drawing.Color.DodgerBlue;
            buttonUse.Color = System.Drawing.Color.RoyalBlue;
            buttonUse.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonUse.ForeColor = System.Drawing.Color.White;
            buttonUse.Location = new System.Drawing.Point(25, 278);
            buttonUse.Name = "buttonUse";
            buttonUse.Radius = 12;
            buttonUse.ShadowDepth = 4F;
            buttonUse.Size = new System.Drawing.Size(129, 49);
            buttonUse.TabIndex = 2;
            buttonUse.Text = "Use";
            buttonUse.UseVisualStyleBackColor = false;
            buttonUse.Click += buttonUse_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonCancel.Color = System.Drawing.Color.Crimson;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            buttonCancel.ForeColor = System.Drawing.Color.White;
            buttonCancel.Location = new System.Drawing.Point(248, 278);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Radius = 12;
            buttonCancel.ShadowDepth = 4F;
            buttonCancel.Size = new System.Drawing.Size(129, 49);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            pictureBox1.Image = Properties.Resources.maxicard_banner;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(406, 75);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // MaxicardDonation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(406, 351);
            Controls.Add(pictureBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonUse);
            Controls.Add(textBoxPassword);
            Controls.Add(label2);
            Controls.Add(textBoxCode);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 10F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Empty,
    System.Drawing.Color.Empty
    };
            Hatch = System.Drawing.Drawing2D.HatchStyle.DottedGrid;
            Location = new System.Drawing.Point(0, 0);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(406, 351);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(406, 351);
            Name = "MaxicardDonation";
            Padding = new System.Windows.Forms.Padding(0);
            ShowIcon = false;
            ShowInTaskbar = false;
            ShowTitle = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Maxicard Donation";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SDUI.Controls.Label label1;
        private SDUI.Controls.TextBox textBoxCode;
        private SDUI.Controls.Label label2;
        private SDUI.Controls.TextBox textBoxPassword;
        private SDUI.Controls.Button buttonUse;
        private SDUI.Controls.Button buttonCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
