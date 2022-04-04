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
            this.components = new System.ComponentModel.Container();
            this.labelServerName = new System.Windows.Forms.Label();
            this.labelNumberOfPeopleWaiting = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPending = new System.Windows.Forms.Label();
            this.labelAvgWaitingTime = new System.Windows.Forms.Label();
            this.labelMyWaitingTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelServerName
            // 
            this.labelServerName.AutoSize = true;
            this.labelServerName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerName.Location = new System.Drawing.Point(62, 9);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(286, 20);
            this.labelServerName.TabIndex = 0;
            this.labelServerName.Text = "{SERVER} is pending for server connection";
            // 
            // labelNumberOfPeopleWaiting
            // 
            this.labelNumberOfPeopleWaiting.AutoSize = true;
            this.labelNumberOfPeopleWaiting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfPeopleWaiting.Location = new System.Drawing.Point(78, 60);
            this.labelNumberOfPeopleWaiting.Name = "labelNumberOfPeopleWaiting";
            this.labelNumberOfPeopleWaiting.Size = new System.Drawing.Size(165, 17);
            this.labelNumberOfPeopleWaiting.TabIndex = 0;
            this.labelNumberOfPeopleWaiting.Text = "Number of people waiting:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Average waiting time: ";
            // 
            // labelPending
            // 
            this.labelPending.AutoSize = true;
            this.labelPending.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPending.Location = new System.Drawing.Point(258, 60);
            this.labelPending.Name = "labelPending";
            this.labelPending.Size = new System.Drawing.Size(0, 17);
            this.labelPending.TabIndex = 0;
            // 
            // labelAvgWaitingTime
            // 
            this.labelAvgWaitingTime.AutoSize = true;
            this.labelAvgWaitingTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvgWaitingTime.Location = new System.Drawing.Point(193, 111);
            this.labelAvgWaitingTime.Name = "labelAvgWaitingTime";
            this.labelAvgWaitingTime.Size = new System.Drawing.Size(0, 17);
            this.labelAvgWaitingTime.TabIndex = 0;
            // 
            // labelMyWaitingTime
            // 
            this.labelMyWaitingTime.AutoSize = true;
            this.labelMyWaitingTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMyWaitingTime.Location = new System.Drawing.Point(193, 146);
            this.labelMyWaitingTime.Name = "labelMyWaitingTime";
            this.labelMyWaitingTime.Size = new System.Drawing.Size(0, 17);
            this.labelMyWaitingTime.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "My waiting time:";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(106, 205);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(191, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel the waiting";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // PendingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 240);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelMyWaitingTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAvgWaitingTime);
            this.Controls.Add(this.labelPending);
            this.Controls.Add(this.labelNumberOfPeopleWaiting);
            this.Controls.Add(this.labelServerName);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(401, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(401, 240);
            this.Name = "PendingWindow";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Timer timer;
    }
}