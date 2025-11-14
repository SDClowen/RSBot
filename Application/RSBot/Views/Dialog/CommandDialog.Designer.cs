namespace RSBot.Views.Dialog
{
    partial class CommandDialog
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
            panel1 = new SDUI.Controls.Panel();
            btnAdd = new SDUI.Controls.Button();
            btnCancel = new SDUI.Controls.Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(btnCancel);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 2);
            panel1.Name = "panel1";
            panel1.Radius = 1;
            panel1.ShadowDepth = 4F;
            panel1.Size = new System.Drawing.Size(252, 44);
            panel1.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Color = System.Drawing.Color.Transparent;
            btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAdd.Location = new System.Drawing.Point(90, 9);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 2;
            btnAdd.ShadowDepth = 4F;
            btnAdd.Size = new System.Drawing.Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Color = System.Drawing.Color.Transparent;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(171, 9);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 2;
            btnCancel.ShadowDepth = 4F;
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // CommandDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(252, 46);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Segoe UI", 8.25F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Location = new System.Drawing.Point(0, 0);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CommandDialog";
            ShowIcon = false;
            Text = "CommandDialog";
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Button btnAdd;
        private SDUI.Controls.Button btnCancel;
    }
}