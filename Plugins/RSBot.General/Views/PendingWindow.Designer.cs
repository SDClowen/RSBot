namespace RSBot.General.Views
{
    partial class PendingWindow
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingWindow));
            labelServerName = new System.Windows.Forms.Label();
            labelNumberOfPeopleWaiting = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            labelPending = new System.Windows.Forms.Label();
            labelAvgWaitingTime = new System.Windows.Forms.Label();
            labelMyWaitingTime = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            buttonCancel = new System.Windows.Forms.Button();
            buttonHide = new System.Windows.Forms.Button();
            notifyIcon = new System.Windows.Forms.NotifyIcon(components);
            SuspendLayout();
            // 
            // labelServerName
            // 
            labelServerName.AutoSize = true;
            labelServerName.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            labelServerName.Location = new System.Drawing.Point(72, 13);
            labelServerName.Name = "labelServerName";
            labelServerName.Size = new System.Drawing.Size(365, 25);
            labelServerName.TabIndex = 0;
            labelServerName.Text = "{SERVER} is pending for server connection";
            // 
            // labelNumberOfPeopleWaiting
            // 
            labelNumberOfPeopleWaiting.AutoSize = true;
            labelNumberOfPeopleWaiting.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            labelNumberOfPeopleWaiting.Location = new System.Drawing.Point(90, 81);
            labelNumberOfPeopleWaiting.Name = "labelNumberOfPeopleWaiting";
            labelNumberOfPeopleWaiting.Size = new System.Drawing.Size(214, 23);
            labelNumberOfPeopleWaiting.TabIndex = 0;
            labelNumberOfPeopleWaiting.Text = "Number of people waiting:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            label1.Location = new System.Drawing.Point(39, 149);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(180, 23);
            label1.TabIndex = 0;
            label1.Text = "Average waiting time: ";
            // 
            // labelPending
            // 
            labelPending.AutoSize = true;
            labelPending.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            labelPending.Location = new System.Drawing.Point(296, 81);
            labelPending.Name = "labelPending";
            labelPending.Size = new System.Drawing.Size(0, 23);
            labelPending.TabIndex = 0;
            // 
            // labelAvgWaitingTime
            // 
            labelAvgWaitingTime.AutoSize = true;
            labelAvgWaitingTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            labelAvgWaitingTime.Location = new System.Drawing.Point(222, 149);
            labelAvgWaitingTime.Name = "labelAvgWaitingTime";
            labelAvgWaitingTime.Size = new System.Drawing.Size(19, 23);
            labelAvgWaitingTime.TabIndex = 0;
            labelAvgWaitingTime.Text = "0";
            // 
            // labelMyWaitingTime
            // 
            labelMyWaitingTime.AutoSize = true;
            labelMyWaitingTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            labelMyWaitingTime.Location = new System.Drawing.Point(222, 196);
            labelMyWaitingTime.Name = "labelMyWaitingTime";
            labelMyWaitingTime.Size = new System.Drawing.Size(19, 23);
            labelMyWaitingTime.TabIndex = 0;
            labelMyWaitingTime.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            label5.Location = new System.Drawing.Point(73, 196);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(136, 23);
            label5.TabIndex = 0;
            label5.Text = "My waiting time:";
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            buttonCancel.Location = new System.Drawing.Point(174, 276);
            buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(218, 35);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel the waiting";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonHide
            // 
            buttonHide.AutoSize = true;
            buttonHide.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            buttonHide.Location = new System.Drawing.Point(80, 276);
            buttonHide.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonHide.Name = "buttonHide";
            buttonHide.Size = new System.Drawing.Size(82, 35);
            buttonHide.TabIndex = 2;
            buttonHide.Text = "Hide";
            buttonHide.UseVisualStyleBackColor = true;
            buttonHide.Click += buttonHide_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "RSBot";
            notifyIcon.BalloonTipTitle = "RSBot";
            notifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "RSBot";
            // 
            // PendingWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(458, 320);
            Controls.Add(buttonHide);
            Controls.Add(buttonCancel);
            Controls.Add(label5);
            Controls.Add(labelMyWaitingTime);
            Controls.Add(label1);
            Controls.Add(labelAvgWaitingTime);
            Controls.Add(labelPending);
            Controls.Add(labelNumberOfPeopleWaiting);
            Controls.Add(labelServerName);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(458, 320);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(458, 320);
            Name = "PendingWindow";
            Opacity = 0.95D;
            Padding = new System.Windows.Forms.Padding(1);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelServerName;
        private System.Windows.Forms.Label labelNumberOfPeopleWaiting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPending;
        private System.Windows.Forms.Label labelAvgWaitingTime;
        private System.Windows.Forms.Label labelMyWaitingTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}