namespace RSBot.Map.Views.Dialog
{
    partial class EntityDetailsDialog
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
            this.propEntity = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // propEntity
            // 
            this.propEntity.BackColor = System.Drawing.SystemColors.Control;
            this.propEntity.CategoryForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.propEntity.CategorySplitterColor = System.Drawing.SystemColors.ControlDark;
            this.propEntity.CommandsBackColor = System.Drawing.SystemColors.ControlDark;
            this.propEntity.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.propEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propEntity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.propEntity.HelpBackColor = System.Drawing.SystemColors.ControlDark;
            this.propEntity.HelpVisible = false;
            this.propEntity.LineColor = System.Drawing.SystemColors.WindowFrame;
            this.propEntity.Location = new System.Drawing.Point(0, 0);
            this.propEntity.Margin = new System.Windows.Forms.Padding(1);
            this.propEntity.Name = "propEntity";
            this.propEntity.SelectedItemWithFocusBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.propEntity.SelectedItemWithFocusForeColor = System.Drawing.SystemColors.GrayText;
            this.propEntity.Size = new System.Drawing.Size(458, 450);
            this.propEntity.TabIndex = 1;
            this.propEntity.ViewBackColor = System.Drawing.SystemColors.InfoText;
            this.propEntity.ViewForeColor = System.Drawing.SystemColors.HighlightText;
            // 
            // EntityDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 450);
            this.Controls.Add(this.propEntity);
            this.MaximizeBox = false;
            this.Name = "EntityDetailsDialog";
            this.ShowIcon = false;
            this.Text = "Entity details";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propEntity;
    }
}