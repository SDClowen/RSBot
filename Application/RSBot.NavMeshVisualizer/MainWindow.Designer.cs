namespace RSBot.NavMeshVisualizer;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        navMeshRenderer2 = new NavMeshRenderer();
        this.SuspendLayout();
        // 
        // navMeshRenderer2
        // 
        navMeshRenderer2.BackColor = Color.CornflowerBlue;
        navMeshRenderer2.Location = new Point(468, 12);
        navMeshRenderer2.Name = "navMeshRenderer2";
        navMeshRenderer2.Size = new Size(768, 768);
        navMeshRenderer2.TabIndex = 1;
        // 
        // MainWindow
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1326, 798);
        this.Controls.Add(navMeshRenderer2);
        this.Name = "MainWindow";
        this.Text = "Form1";
        this.ResumeLayout(false);
    }

    #endregion
    private NavMeshRenderer navMeshRenderer2;
}
