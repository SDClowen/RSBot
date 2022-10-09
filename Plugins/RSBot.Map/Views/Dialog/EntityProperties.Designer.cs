namespace RSBot.Map.Views.Dialog
{
    partial class EntityProperties
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
            this.propEntity.Size = new System.Drawing.Size(439, 577);
            this.propEntity.TabIndex = 0;
            this.propEntity.ViewBackColor = System.Drawing.SystemColors.InfoText;
            this.propEntity.ViewForeColor = System.Drawing.SystemColors.HighlightText;
            // 
            // EntityProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(439, 577);
            this.Controls.Add(this.propEntity);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "EntityProperties";
            this.ShowIcon = false;
            this.Text = "Entity Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propEntity;
    }
}