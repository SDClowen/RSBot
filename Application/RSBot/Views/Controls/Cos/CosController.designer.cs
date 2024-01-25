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
            separator = new SDUI.Controls.Separator();
            panel = new System.Windows.Forms.Panel();
            topPanel = new System.Windows.Forms.Panel();
            panelTopCenter = new System.Windows.Forms.Panel();
            panelTopRight = new System.Windows.Forms.Panel();
            buttonNext = new SDUI.Controls.Button();
            panelTopLeft = new System.Windows.Forms.Panel();
            buttonPrev = new SDUI.Controls.Button();
            separator1 = new SDUI.Controls.Separator();
            topPanel.SuspendLayout();
            panelTopRight.SuspendLayout();
            panelTopLeft.SuspendLayout();
            SuspendLayout();
            // 
            // separator
            // 
            separator.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator.IsVertical = false;
            separator.Location = new System.Drawing.Point(3, 95);
            separator.Name = "separator";
            separator.Size = new System.Drawing.Size(242, 4);
            separator.TabIndex = 2;
            // 
            // panel
            // 
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Location = new System.Drawing.Point(3, 63);
            panel.Name = "panel";
            panel.Size = new System.Drawing.Size(242, 32);
            panel.TabIndex = 3;
            // 
            // topPanel
            // 
            topPanel.BackColor = System.Drawing.Color.Transparent;
            topPanel.Controls.Add(panelTopCenter);
            topPanel.Controls.Add(panelTopRight);
            topPanel.Controls.Add(panelTopLeft);
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Location = new System.Drawing.Point(3, 3);
            topPanel.Name = "topPanel";
            topPanel.Size = new System.Drawing.Size(242, 56);
            topPanel.TabIndex = 4;
            // 
            // panelTopCenter
            // 
            panelTopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTopCenter.Location = new System.Drawing.Point(23, 0);
            panelTopCenter.Name = "panelTopCenter";
            panelTopCenter.Size = new System.Drawing.Size(196, 56);
            panelTopCenter.TabIndex = 6;
            // 
            // panelTopRight
            // 
            panelTopRight.BackColor = System.Drawing.Color.Transparent;
            panelTopRight.Controls.Add(buttonNext);
            panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelTopRight.Location = new System.Drawing.Point(219, 0);
            panelTopRight.Name = "panelTopRight";
            panelTopRight.Size = new System.Drawing.Size(23, 56);
            panelTopRight.TabIndex = 5;
            // 
            // buttonNext
            // 
            buttonNext.Color = System.Drawing.Color.Transparent;
            buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonNext.Font = new System.Drawing.Font("Marlett", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonNext.Location = new System.Drawing.Point(0, 0);
            buttonNext.Name = "buttonNext";
            buttonNext.Radius = 4;
            buttonNext.ShadowDepth = 4F;
            buttonNext.Size = new System.Drawing.Size(23, 56);
            buttonNext.TabIndex = 1;
            buttonNext.Text = "4";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Visible = false;
            buttonNext.Click += buttonNext_Click;
            // 
            // panelTopLeft
            // 
            panelTopLeft.BackColor = System.Drawing.Color.Transparent;
            panelTopLeft.Controls.Add(buttonPrev);
            panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelTopLeft.Location = new System.Drawing.Point(0, 0);
            panelTopLeft.Name = "panelTopLeft";
            panelTopLeft.Size = new System.Drawing.Size(23, 56);
            panelTopLeft.TabIndex = 4;
            // 
            // buttonPrev
            // 
            buttonPrev.Color = System.Drawing.Color.Transparent;
            buttonPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonPrev.Font = new System.Drawing.Font("Marlett", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonPrev.Location = new System.Drawing.Point(0, 0);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Radius = 4;
            buttonPrev.ShadowDepth = 4F;
            buttonPrev.Size = new System.Drawing.Size(23, 56);
            buttonPrev.TabIndex = 2;
            buttonPrev.Text = "3";
            buttonPrev.UseVisualStyleBackColor = true;
            buttonPrev.Visible = false;
            buttonPrev.Click += buttonPrev_Click;
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Top;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(3, 59);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(242, 4);
            separator1.TabIndex = 5;
            // 
            // CosController
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(panel);
            Controls.Add(separator1);
            Controls.Add(topPanel);
            Controls.Add(separator);
            Name = "CosController";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(248, 102);
            topPanel.ResumeLayout(false);
            panelTopRight.ResumeLayout(false);
            panelTopLeft.ResumeLayout(false);
            ResumeLayout(false);
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
