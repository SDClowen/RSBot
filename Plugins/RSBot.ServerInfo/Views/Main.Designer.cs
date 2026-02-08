namespace RSBot.ServerInfo.Views;

partial class Main
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

    private void InitializeComponent()
    {
        lvServerInfo = new SDUI.Controls.ListView();
        colServer = new System.Windows.Forms.ColumnHeader();
        colCapacity = new System.Windows.Forms.ColumnHeader();
        SuspendLayout();
        // 
        // lvServerInfo
        // 
        lvServerInfo.BackColor = System.Drawing.Color.White;
        lvServerInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colServer, colCapacity });
        lvServerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
        lvServerInfo.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
        lvServerInfo.FullRowSelect = true;
        lvServerInfo.Location = new System.Drawing.Point(0, 0);
        lvServerInfo.Name = "lvServerInfo";
        lvServerInfo.Size = new System.Drawing.Size(328, 314);
        lvServerInfo.TabIndex = 1;
        lvServerInfo.UseCompatibleStateImageBehavior = false;
        lvServerInfo.View = System.Windows.Forms.View.Details;
        // 
        // colServer
        // 
        colServer.Text = "Server";
        colServer.Width = 150;
        // 
        // colCapacity
        // 
        colCapacity.Text = "Capacity";
        colCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        colCapacity.Width = 100;
        // 
        // Main
        // 
        Controls.Add(lvServerInfo);
        Name = "Main";
        Size = new System.Drawing.Size(328, 314);
        ResumeLayout(false);

    }

    private SDUI.Controls.ListView lvServerInfo;
    private System.Windows.Forms.ColumnHeader colServer;
    private System.Windows.Forms.ColumnHeader colCapacity;
}
    
