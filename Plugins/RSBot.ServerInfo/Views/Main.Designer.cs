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
            this.lvServerInfo = new SDUI.Controls.ListView();
            this.colServer = new System.Windows.Forms.ColumnHeader();
            this.colCapacity = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvServerInfo
            // 
            this.lvServerInfo.BackColor = System.Drawing.Color.White;
            this.lvServerInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colServer,
            this.colCapacity});
            this.lvServerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lvServerInfo.FullRowSelect = true;
            this.lvServerInfo.Location = new System.Drawing.Point(35, 28);
            this.lvServerInfo.Name = "lvServerInfo";
            this.lvServerInfo.Size = new System.Drawing.Size(257, 245);
            this.lvServerInfo.TabIndex = 1;
            this.lvServerInfo.UseCompatibleStateImageBehavior = false;
            this.lvServerInfo.View = System.Windows.Forms.View.Details;
            // 
            // colServer
            // 
            this.colServer.Text = "Server";
            this.colServer.Width = 150;
            // 
            // colCapacity
            // 
            this.colCapacity.Text = "Capacity";
            this.colCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCapacity.Width = 100;
            // 
            // Main
            // 
            this.Controls.Add(this.lvServerInfo);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(328, 314);
            this.ResumeLayout(false);

    }

    private SDUI.Controls.ListView lvServerInfo;
    private System.Windows.Forms.ColumnHeader colServer;
    private System.Windows.Forms.ColumnHeader colCapacity;
}
    
