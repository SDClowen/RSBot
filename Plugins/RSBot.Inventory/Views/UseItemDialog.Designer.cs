
namespace RSBot.Inventory.Views
{
    partial class UseItemDialog
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
            this.buttonOk = new RSBot.Theme.Material.Button();
            this.buttonCancel = new RSBot.Theme.Material.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Depth = 0;
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Icon = null;
            this.buttonOk.Location = new System.Drawing.Point(28, 72);
            this.buttonOk.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Primary = true;
            this.buttonOk.Raised = true;
            this.buttonOk.SingleColor = System.Drawing.Color.Empty;
            this.buttonOk.Size = new System.Drawing.Size(215, 42);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Use Directly";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Depth = 0;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Icon = null;
            this.buttonCancel.Location = new System.Drawing.Point(28, 193);
            this.buttonCancel.MouseState = RSBot.Theme.IMatMouseState.HOVER;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Primary = false;
            this.buttonCancel.Raised = false;
            this.buttonCancel.SingleColor = System.Drawing.Color.Empty;
            this.buttonCancel.Size = new System.Drawing.Size(215, 42);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Use with conditions";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "If you want to use the item directly,\r\n just click the button";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Öğeyi kendi belirlediğiniz karara göre\r\n kullandırabilirsiniz. Bir şart penceresi" +
    " açılacak \r\nve oradan istediğiniz şartları ayarlayabilirsiniz";
            // 
            // UseItemDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(271, 247);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(287, 263);
            this.MinimizeBox = false;
            this.Name = "UseItemDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Theme.Material.Button buttonOk;
        private Theme.Material.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}