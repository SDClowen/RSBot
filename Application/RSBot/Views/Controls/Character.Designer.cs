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
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lblLevel = new System.Windows.Forms.Label();
            lblGold = new System.Windows.Forms.Label();
            lblSP = new System.Windows.Forms.Label();
            lblPlayerName = new System.Windows.Forms.Label();
            lblStr = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            lblInt = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            progressEXP = new System.Windows.Forms.ProgressBar();
            progressMP = new System.Windows.Forms.ProgressBar();
            progressHP = new System.Windows.Forms.ProgressBar();
            separator1 = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(665, 20);
            label3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 21);
            label3.TabIndex = 4;
            label3.Text = "Gold:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(682, 48);
            label4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 21);
            label4.TabIndex = 5;
            label4.Text = "SP:";
            // 
            // lblLevel
            // 
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
            lblGold.AutoSize = true;
            lblGold.Location = new System.Drawing.Point(722, 21);
            lblGold.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            lblGold.Name = "lblGold";
            lblGold.Size = new System.Drawing.Size(17, 20);
            lblGold.TabIndex = 7;
            lblGold.Text = "0";
            // 
            // lblSP
            // 
            lblSP.AutoSize = true;
            lblSP.Location = new System.Drawing.Point(722, 48);
            lblSP.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            lblSP.Name = "lblSP";
            lblSP.Size = new System.Drawing.Size(17, 20);
            lblSP.TabIndex = 8;
            lblSP.Text = "0";
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            lblPlayerName.Location = new System.Drawing.Point(9, 5);
            lblPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new System.Drawing.Size(100, 21);
            lblPlayerName.TabIndex = 9;
            lblPlayerName.Text = "Not in game";
            // 
            // lblStr
            // 
            lblStr.AutoSize = true;
            lblStr.Location = new System.Drawing.Point(589, 20);
            lblStr.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            lblStr.Name = "lblStr";
            lblStr.Size = new System.Drawing.Size(17, 20);
            lblStr.TabIndex = 11;
            lblStr.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label9.Location = new System.Drawing.Point(539, 20);
            label9.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(42, 21);
            label9.TabIndex = 10;
            label9.Text = "STR:";
            // 
            // lblInt
            // 
            lblInt.AutoSize = true;
            lblInt.Location = new System.Drawing.Point(589, 49);
            lblInt.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            lblInt.Name = "lblInt";
            lblInt.Size = new System.Drawing.Size(17, 20);
            lblInt.TabIndex = 13;
            lblInt.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            label11.Location = new System.Drawing.Point(541, 48);
            label11.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(40, 21);
            label11.TabIndex = 12;
            label11.Text = "INT:";
            // 
            // progressEXP
            // 
            progressEXP.Location = new System.Drawing.Point(12, 61);
            progressEXP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressEXP.Maximum = 1;
            progressEXP.Name = "progressEXP";
            progressEXP.Size = new System.Drawing.Size(504, 25);
            progressEXP.TabIndex = 2;
            progressEXP.Text = "0.00%";
            // 
            // progressMP
            // 
            progressMP.Location = new System.Drawing.Point(268, 32);
            progressMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressMP.Maximum = 1;
            progressMP.Name = "progressMP";
            progressMP.Size = new System.Drawing.Size(248, 25);
            progressMP.TabIndex = 1;
            progressMP.Text = "0 / 1";
            // 
            // progressHP
            // 
            progressHP.Location = new System.Drawing.Point(12, 32);
            progressHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            progressHP.Maximum = 1;
            progressHP.Name = "progressHP";
            progressHP.Size = new System.Drawing.Size(248, 25);
            progressHP.TabIndex = 0;
            progressHP.Text = "0 / 1";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
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

        private System.Windows.Forms.ProgressBar progressHP;
        private System.Windows.Forms.ProgressBar progressMP;
        private System.Windows.Forms.ProgressBar progressEXP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblStr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblInt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel separator1;
    }
}
