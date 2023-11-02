using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Label = SDUI.Controls.Label;
using ProgressBar = SDUI.Controls.ProgressBar;

namespace RSBot.Views.Controls;

[ToolboxItem(false)]
public class CosControlBase : UserControl
{
    private Label label1;
    protected Label labelLevel;
    protected Label lblPetName;
    private Panel panel1;
    protected ProgressBar progressHP;

    public CosControlBase()
    {
        SetStyle(ControlStyles.Opaque, true);
        MiniCosControl = new MiniCosControl();
        MiniCosControl.Dock = DockStyle.Left;
        InitializeComponent();
    }

    public MiniCosControl MiniCosControl { get; }

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
        label1 = new Label();
        lblPetName = new Label();
        progressHP = new ProgressBar();
        panel1 = new Panel();
        labelLevel = new Label();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.ApplyGradient = false;
        label1.AutoSize = true;
        label1.ForeColor = Color.FromArgb(0, 0, 0);
        label1.Gradient = new[] { Color.Gray, Color.Black };
        label1.Location = new Point(14, 44);
        label1.Name = "label1";
        label1.Size = new Size(26, 15);
        label1.TabIndex = 20;
        label1.Text = "HP:";
        // 
        // lblPetName
        // 
        lblPetName.ApplyGradient = false;
        lblPetName.AutoSize = true;
        lblPetName.Dock = DockStyle.Left;
        lblPetName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblPetName.ForeColor = Color.FromArgb(0, 0, 0);
        lblPetName.Gradient = new[] { Color.Gray, Color.Black };
        lblPetName.Location = new Point(0, 0);
        lblPetName.Name = "lblPetName";
        lblPetName.Size = new Size(81, 15);
        lblPetName.TabIndex = 19;
        lblPetName.Text = "No pet found";
        // 
        // progressHP
        // 
        progressHP.BackColor = Color.Transparent;
        progressHP.DrawHatch = false;
        progressHP.ForeColor = Color.Firebrick;
        progressHP.Gradient = new[] { Color.Maroon, Color.Red };
        progressHP.HatchType = HatchStyle.Percent10;
        progressHP.Location = new Point(48, 45);
        progressHP.Maximum = 100L;
        progressHP.MaxPercentShowValue = 100F;
        progressHP.Name = "progressHP";
        progressHP.PercentIndices = 2;
        progressHP.Radius = 1;
        progressHP.ShowAsPercent = false;
        progressHP.ShowValue = true;
        progressHP.Size = new Size(180, 16);
        progressHP.TabIndex = 18;
        progressHP.Text = "0 / 100";
        progressHP.Value = 0L;
        // 
        // panel1
        // 
        panel1.Controls.Add(labelLevel);
        panel1.Controls.Add(lblPetName);
        panel1.Location = new Point(48, 18);
        panel1.Name = "panel1";
        panel1.Size = new Size(180, 21);
        panel1.TabIndex = 21;
        // 
        // labelLevel
        // 
        labelLevel.ApplyGradient = false;
        labelLevel.AutoSize = true;
        labelLevel.Dock = DockStyle.Left;
        labelLevel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        labelLevel.ForeColor = Color.FromArgb(0, 0, 0);
        labelLevel.Gradient = new[] { Color.Gray, Color.Black };
        labelLevel.Location = new Point(81, 0);
        labelLevel.Name = "labelLevel";
        labelLevel.Size = new Size(0, 15);
        labelLevel.TabIndex = 20;
        // 
        // CosControlBase
        // 
        Controls.Add(panel1);
        Controls.Add(label1);
        Controls.Add(progressHP);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        Name = "CosControlBase";
        Size = new Size(243, 79);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}