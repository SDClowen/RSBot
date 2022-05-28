namespace RSBot.Views.Controls.Cos
{
    partial class CosController
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
            this.separator = new SDUI.Controls.Separator();
            this.panel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.panelTopCenter = new System.Windows.Forms.Panel();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.buttonNext = new SDUI.Controls.Button();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.buttonPrev = new SDUI.Controls.Button();
            this.separator1 = new SDUI.Controls.Separator();
            this.topPanel.SuspendLayout();
            this.panelTopRight.SuspendLayout();
            this.panelTopLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // separator
            // 
            this.separator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator.IsVertical = false;
            this.separator.Location = new System.Drawing.Point(3, 95);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(242, 4);
            this.separator.TabIndex = 2;
            this.separator.Text = "separator1";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(3, 63);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(242, 32);
            this.panel.TabIndex = 3;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.panelTopCenter);
            this.topPanel.Controls.Add(this.panelTopRight);
            this.topPanel.Controls.Add(this.panelTopLeft);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(242, 56);
            this.topPanel.TabIndex = 4;
            // 
            // panelTopCenter
            // 
            this.panelTopCenter.BackColor = System.Drawing.Color.Transparent;
            this.panelTopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopCenter.Location = new System.Drawing.Point(23, 0);
            this.panelTopCenter.Name = "panelTopCenter";
            this.panelTopCenter.Size = new System.Drawing.Size(196, 56);
            this.panelTopCenter.TabIndex = 6;
            // 
            // panelTopRight
            // 
            this.panelTopRight.BackColor = System.Drawing.Color.Transparent;
            this.panelTopRight.Controls.Add(this.buttonNext);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopRight.Location = new System.Drawing.Point(219, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(23, 56);
            this.panelTopRight.TabIndex = 5;
            // 
            // buttonNext
            // 
            this.buttonNext.Color = System.Drawing.Color.Transparent;
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNext.Font = new System.Drawing.Font("Marlett", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonNext.Location = new System.Drawing.Point(0, 0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Radius = 4;
            this.buttonNext.Size = new System.Drawing.Size(23, 56);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "4";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Visible = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelTopLeft.Controls.Add(this.buttonPrev);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(23, 56);
            this.panelTopLeft.TabIndex = 4;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Color = System.Drawing.Color.Transparent;
            this.buttonPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrev.Font = new System.Drawing.Font("Marlett", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonPrev.Location = new System.Drawing.Point(0, 0);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Radius = 4;
            this.buttonPrev.Size = new System.Drawing.Size(23, 56);
            this.buttonPrev.TabIndex = 2;
            this.buttonPrev.Text = "3";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Visible = false;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(3, 59);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(242, 4);
            this.separator1.TabIndex = 5;
            this.separator1.Text = "separator1";
            // 
            // CosController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.separator);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CosController";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(248, 102);
            this.topPanel.ResumeLayout(false);
            this.panelTopRight.ResumeLayout(false);
            this.panelTopLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SDUI.Controls.Separator separator;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel panelTopCenter;
        private System.Windows.Forms.Panel panelTopRight;
        private SDUI.Controls.Button buttonNext;
        private System.Windows.Forms.Panel panelTopLeft;
        private SDUI.Controls.Button buttonPrev;
        private SDUI.Controls.Separator separator1;
    }
}
