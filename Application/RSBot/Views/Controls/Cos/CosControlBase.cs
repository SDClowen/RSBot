using System.ComponentModel;
using System.Windows.Forms;

namespace RSBot.Views.Controls
{
    [ToolboxItem(false)]
    public partial class CosControlBase : UserControl
    {

        private SDUI.Controls.Label label1;
        protected SDUI.Controls.Label lblPetName;
        private Panel panel1;
        protected SDUI.Controls.Label labelLevel;
        protected SDUI.Controls.ProgressBar progressHP;

        public MiniCosControl MiniCosControl { get; private set; }

        public CosControlBase()
        {
            MiniCosControl = new MiniCosControl();
            MiniCosControl.Dock = DockStyle.Left;
            InitializeComponent();
        }

        public virtual void Initialize()
        {

        }

        public virtual void Reset()
        {
            progressHP.Value = 0;
            MiniCosControl.Hp.Value = 0;

            progressHP.Maximum = 0;
            MiniCosControl.Hp.Maximum = 0;
        }

        private void InitializeComponent()
        {
            this.label1 = new SDUI.Controls.Label();
            this.lblPetName = new SDUI.Controls.Label();
            this.progressHP = new SDUI.Controls.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelLevel = new SDUI.Controls.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "HP:";
            // 
            // lblPetName
            // 
            this.lblPetName.AutoSize = true;
            this.lblPetName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPetName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPetName.Location = new System.Drawing.Point(0, 0);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(81, 15);
            this.lblPetName.TabIndex = 19;
            this.lblPetName.Text = "No pet found";
            // 
            // progressHP
            // 
            this.progressHP.BackColor = System.Drawing.Color.Transparent;
            this.progressHP.DrawHatch = false;
            this.progressHP.ForeColor = System.Drawing.Color.Firebrick;
            this.progressHP.Gradient = new System.Drawing.Color[] {
        System.Drawing.Color.Maroon,
        System.Drawing.Color.Red};
            this.progressHP.HatchType = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.progressHP.Location = new System.Drawing.Point(48, 45);
            this.progressHP.Maximum = ((long)(100));
            this.progressHP.Name = "progressHP";
            this.progressHP.PercentIndices = 2;
            this.progressHP.Radius = 0;
            this.progressHP.ShowAsPercent = false;
            this.progressHP.ShowValue = true;
            this.progressHP.Size = new System.Drawing.Size(180, 16);
            this.progressHP.TabIndex = 18;
            this.progressHP.Text = "0 / 100";
            this.progressHP.Value = ((long)(0));
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelLevel);
            this.panel1.Controls.Add(this.lblPetName);
            this.panel1.Location = new System.Drawing.Point(48, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 21);
            this.panel1.TabIndex = 21;
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelLevel.Location = new System.Drawing.Point(81, 0);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(0, 15);
            this.labelLevel.TabIndex = 20;
            // 
            // CosControlBase
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressHP);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CosControlBase";
            this.Size = new System.Drawing.Size(243, 79);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
