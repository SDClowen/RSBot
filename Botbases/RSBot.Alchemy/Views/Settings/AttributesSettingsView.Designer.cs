namespace RSBot.Alchemy.Views.Settings
{
    partial class AttributesSettingsView
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
            this.panelAttributes = new SDUI.Controls.Panel();
            this.SuspendLayout();
            // 
            // panelAttributes
            // 
            this.panelAttributes.AutoScroll = true;
            this.panelAttributes.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panelAttributes.BorderColor = System.Drawing.Color.Transparent;
            this.panelAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttributes.Location = new System.Drawing.Point(0, 0);
            this.panelAttributes.Name = "panelAttributes";
            this.panelAttributes.Radius = 1;
            this.panelAttributes.Size = new System.Drawing.Size(438, 306);
            this.panelAttributes.TabIndex = 1;
            // 
            // AttributesSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAttributes);
            this.Name = "AttributesSettingsView";
            this.Size = new System.Drawing.Size(438, 306);
            this.ResumeLayout(false);

        }

        #endregion
        private SDUI.Controls.Panel panelAttributes;
    }
}
