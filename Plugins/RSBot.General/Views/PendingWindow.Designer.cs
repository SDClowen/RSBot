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
            labelServerName = new SDUI.Controls.Label();
            labelNumberOfPeopleWaiting = new SDUI.Controls.Label();
            label1 = new SDUI.Controls.Label();
            labelPending = new SDUI.Controls.Label();
            labelAvgWaitingTime = new SDUI.Controls.Label();
            labelMyWaitingTime = new SDUI.Controls.Label();
            label5 = new SDUI.Controls.Label();
            buttonCancel = new SDUI.Controls.Button();
            buttonHide = new SDUI.Controls.Button();
            notifyIcon = new System.Windows.Forms.NotifyIcon(components);
            SuspendLayout();
            // 
            // labelServerName
            // 
            labelServerName.ApplyGradient = false;
            labelServerName.AutoSize = true;
            labelServerName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelServerName.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelServerName.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            labelServerName.Location = new System.Drawing.Point(63, 10);
            labelServerName.Name = "labelServerName";
            labelServerName.Size = new System.Drawing.Size(286, 20);
            labelServerName.TabIndex = 0;
            labelServerName.Text = "{SERVER} is pending for server connection";
            // 
            // labelNumberOfPeopleWaiting
            // 
            labelNumberOfPeopleWaiting.ApplyGradient = false;
            labelNumberOfPeopleWaiting.AutoSize = true;
            labelNumberOfPeopleWaiting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelNumberOfPeopleWaiting.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelNumberOfPeopleWaiting.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            labelNumberOfPeopleWaiting.Location = new System.Drawing.Point(79, 61);
            labelNumberOfPeopleWaiting.Name = "labelNumberOfPeopleWaiting";
            labelNumberOfPeopleWaiting.Size = new System.Drawing.Size(165, 17);
            labelNumberOfPeopleWaiting.TabIndex = 0;
            labelNumberOfPeopleWaiting.Text = "Number of people waiting:";
            // 
            // label1
            // 
            label1.ApplyGradient = false;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label1.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label1.Location = new System.Drawing.Point(34, 112);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(137, 17);
            label1.TabIndex = 0;
            label1.Text = "Average waiting time: ";
            // 
            // labelPending
            // 
            labelPending.ApplyGradient = false;
            labelPending.AutoSize = true;
            labelPending.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPending.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            labelPending.Location = new System.Drawing.Point(259, 61);
            labelPending.Name = "labelPending";
            labelPending.Size = new System.Drawing.Size(0, 17);
            labelPending.TabIndex = 0;
            // 
            // labelAvgWaitingTime
            // 
            labelAvgWaitingTime.ApplyGradient = false;
            labelAvgWaitingTime.AutoSize = true;
            labelAvgWaitingTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelAvgWaitingTime.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelAvgWaitingTime.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            labelAvgWaitingTime.Location = new System.Drawing.Point(194, 112);
            labelAvgWaitingTime.Name = "labelAvgWaitingTime";
            labelAvgWaitingTime.Size = new System.Drawing.Size(15, 17);
            labelAvgWaitingTime.TabIndex = 0;
            labelAvgWaitingTime.Text = "0";
            // 
            // labelMyWaitingTime
            // 
            labelMyWaitingTime.ApplyGradient = false;
            labelMyWaitingTime.AutoSize = true;
            labelMyWaitingTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelMyWaitingTime.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelMyWaitingTime.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            labelMyWaitingTime.Location = new System.Drawing.Point(194, 147);
            labelMyWaitingTime.Name = "labelMyWaitingTime";
            labelMyWaitingTime.Size = new System.Drawing.Size(15, 17);
            labelMyWaitingTime.TabIndex = 0;
            labelMyWaitingTime.Text = "0";
            // 
            // label5
            // 
            label5.ApplyGradient = false;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            label5.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
            label5.Location = new System.Drawing.Point(64, 147);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(103, 17);
            label5.TabIndex = 0;
            label5.Text = "My waiting time:";
            // 
            // buttonCancel
            // 
            buttonCancel.Color = System.Drawing.Color.Transparent;
            buttonCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonCancel.Location = new System.Drawing.Point(152, 207);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Radius = 6;
            buttonCancel.ShadowDepth = 4F;
            buttonCancel.Size = new System.Drawing.Size(191, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel the waiting";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonHide
            // 
            buttonHide.Color = System.Drawing.Color.Transparent;
            buttonHide.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonHide.Location = new System.Drawing.Point(70, 207);
            buttonHide.Name = "buttonHide";
            buttonHide.Radius = 6;
            buttonHide.ShadowDepth = 4F;
            buttonHide.Size = new System.Drawing.Size(72, 23);
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
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(401, 240);
            Controls.Add(buttonHide);
            Controls.Add(buttonCancel);
            Controls.Add(label5);
            Controls.Add(labelMyWaitingTime);
            Controls.Add(label1);
            Controls.Add(labelAvgWaitingTime);
            Controls.Add(labelPending);
            Controls.Add(labelNumberOfPeopleWaiting);
            Controls.Add(labelServerName);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(401, 240);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(401, 240);
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

        private SDUI.Controls.Label labelServerName;
        private SDUI.Controls.Label labelNumberOfPeopleWaiting;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label labelPending;
        private SDUI.Controls.Label labelAvgWaitingTime;
        private SDUI.Controls.Label labelMyWaitingTime;
        private SDUI.Controls.Label label5;
        private SDUI.Controls.Button buttonCancel;
        private SDUI.Controls.Button buttonHide;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}