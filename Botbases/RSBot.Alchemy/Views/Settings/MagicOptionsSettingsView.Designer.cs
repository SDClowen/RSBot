using SDUI.Controls;

namespace RSBot.Alchemy.Views.Settings
{
    partial class MagicOptionsSettingsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvMagicOptions = new SDUI.Controls.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvMagicOptions
            // 
            this.lvMagicOptions.BackColor = System.Drawing.SystemColors.Window;
            this.lvMagicOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvMagicOptions.CheckBoxes = true;
            this.lvMagicOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvMagicOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMagicOptions.ForeColor = System.Drawing.Color.Black;
            this.lvMagicOptions.FullRowSelect = true;
            this.lvMagicOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMagicOptions.Location = new System.Drawing.Point(0, 0);
            this.lvMagicOptions.Name = "lvMagicOptions";
            this.lvMagicOptions.Size = new System.Drawing.Size(434, 267);
            this.lvMagicOptions.TabIndex = 0;
            this.lvMagicOptions.UseCompatibleStateImageBehavior = false;
            this.lvMagicOptions.View = System.Windows.Forms.View.Details;
            this.lvMagicOptions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvMagicOptions_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Option";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Current";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Max";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Num. Stones";
            this.columnHeader4.Width = 80;
            // 
            // MagicOptionsSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvMagicOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MagicOptionsSettingsView";
            this.Size = new System.Drawing.Size(434, 267);
            this.ResumeLayout(false);

        }

        #endregion

        private SDUI.Controls.ListView lvMagicOptions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
