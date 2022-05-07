
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
            this.buttonOk = new SDUI.Controls.Button();
            this.buttonCancel = new SDUI.Controls.Button();
            this.label1 = new SDUI.Controls.Label();
            this.label2 = new SDUI.Controls.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Color = System.Drawing.Color.Transparent;
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(28, 72);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Radius = 2;
            this.buttonOk.Size = new System.Drawing.Size(215, 42);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Use Directly";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Color = System.Drawing.Color.Transparent;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(28, 193);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Radius = 2;
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
            this.ClientSize = new System.Drawing.Size(267, 243);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(287, 263);
            this.MinimizeBox = false;
            this.Name = "UseItemDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDUI.Controls.Button buttonOk;
        private SDUI.Controls.Button buttonCancel;
        private SDUI.Controls.Label label1;
        private SDUI.Controls.Label label2;
    }
}