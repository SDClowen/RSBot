using System.Windows.Forms;
using SDUI.Controls;

namespace RSBot.Views
{
    partial class PluginManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            windowPageControl = new WindowPageControl();
            SuspendLayout();
            // 
            // windowPageControl
            // 
            windowPageControl.BackColor = System.Drawing.Color.FromArgb(64, 64, 64, 100);
            windowPageControl.Dock = DockStyle.Fill;
            windowPageControl.Location = new System.Drawing.Point(0, 38);
            windowPageControl.Name = "windowPageControl";
            windowPageControl.SelectedIndex = -1;
            windowPageControl.Size = new System.Drawing.Size(1012, 718);
            windowPageControl.TabIndex = 2;
            windowPageControl.SelectedIndexChanged += windowPageControl_SelectedIndexChanged;
            // 
            // PluginManager
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            ClientSize = new System.Drawing.Size(1012, 756);
            ControlBox = false;
            Controls.Add(windowPageControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.DodgerBlue,
    System.Drawing.Color.RoyalBlue
    };
            Hatch = System.Drawing.Drawing2D.HatchStyle.Percent20;
            Location = new System.Drawing.Point(0, 0);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PluginManager";
            Padding = new Padding(0, 38, 0, 0);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            TitleHeight = 31F;
            TitleTabDesingMode = TabDesingMode.Chromed;
            WindowPageControl = windowPageControl;
            ResumeLayout(false);
        }
        private WindowPageControl windowPageControl;
    }
}
