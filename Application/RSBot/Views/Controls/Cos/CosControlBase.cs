using System.ComponentModel;
using System.Windows.Forms;

namespace RSBot.Views.Controls;

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
        SetStyle(ControlStyles.Opaque, true);
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
        label1 = new SDUI.Controls.Label();
        lblPetName = new SDUI.Controls.Label();
        progressHP = new SDUI.Controls.ProgressBar();
        panel1 = new Panel();
        labelLevel = new SDUI.Controls.Label();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.ApplyGradient = false;
        label1.AutoSize = true;
        label1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
        label1.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
        label1.Location = new System.Drawing.Point(14, 44);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(26, 15);
        label1.TabIndex = 20;
        label1.Text = "HP:";
        // 
        // lblPetName
        // 
        lblPetName.ApplyGradient = false;
        lblPetName.AutoSize = true;
        lblPetName.Dock = DockStyle.Left;
        lblPetName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        lblPetName.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
        lblPetName.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
        lblPetName.Location = new System.Drawing.Point(0, 0);
        lblPetName.Name = "lblPetName";
        lblPetName.Size = new System.Drawing.Size(81, 15);
        lblPetName.TabIndex = 19;
        lblPetName.Text = "No pet found";
        // 
        // progressHP
        // 
        progressHP.BackColor = System.Drawing.Color.Transparent;
        progressHP.DrawHatch = false;
        progressHP.ForeColor = System.Drawing.Color.Firebrick;
        progressHP.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Maroon, System.Drawing.Color.Red });
        progressHP.HatchType = System.Drawing.Drawing2D.HatchStyle.Percent10;
        progressHP.Location = new System.Drawing.Point(48, 45);
        progressHP.Maximum = 100L;
        progressHP.MaxPercentShowValue = 100F;
        progressHP.Name = "progressHP";
        progressHP.PercentIndices = 2;
        progressHP.Radius = 1;
        progressHP.ShowAsPercent = false;
        progressHP.ShowValue = true;
        progressHP.Size = new System.Drawing.Size(180, 16);
        progressHP.TabIndex = 18;
        progressHP.Text = "0 / 100";
        progressHP.Value = 0L;
        // 
        // panel1
        // 
        panel1.Controls.Add(labelLevel);
        panel1.Controls.Add(lblPetName);
        panel1.Location = new System.Drawing.Point(48, 18);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(180, 21);
        panel1.TabIndex = 21;
        // 
        // labelLevel
        // 
        labelLevel.ApplyGradient = false;
        labelLevel.AutoSize = true;
        labelLevel.Dock = DockStyle.Left;
        labelLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        labelLevel.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
        labelLevel.Gradient = (new System.Drawing.Color[] { System.Drawing.Color.Gray, System.Drawing.Color.Black });
        labelLevel.Location = new System.Drawing.Point(81, 0);
        labelLevel.Name = "labelLevel";
        labelLevel.Size = new System.Drawing.Size(0, 15);
        labelLevel.TabIndex = 20;
        // 
        // CosControlBase
        // 
        Controls.Add(panel1);
        Controls.Add(label1);
        Controls.Add(progressHP);
        Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        Name = "CosControlBase";
        Size = new System.Drawing.Size(243, 79);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}