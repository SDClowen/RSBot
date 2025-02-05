namespace System.Windows.Forms;

partial class InputDialog
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblMessage = new Label();
        txtValue = new TextBox();
        btnOK = new Button();
        btnCancel = new Button();
        comboBox = new ComboBox();
        numValue = new NumericUpDown();
        panel1 = new Panel();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        
        lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        
                    
        lblTitle.Location = new System.Drawing.Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(324, 20);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "Input";
        // 
        // lblMessage
        // 
        
        lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
        lblMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        
                    
        lblMessage.Location = new System.Drawing.Point(0, 20);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new System.Drawing.Size(324, 46);
        lblMessage.TabIndex = 2;
        lblMessage.Text = "Please enter a value";
        // 
        // txtValue
        // 
        txtValue.Location = new System.Drawing.Point(11, 83);
        txtValue.MaxLength = 32767;
        txtValue.Multiline = false;
        txtValue.Name = "txtValue";
        
        
        txtValue.Size = new System.Drawing.Size(299, 25);
        txtValue.TabIndex = 0;
        
        txtValue.UseSystemPasswordChar = false;
        txtValue.PreviewKeyDown += txtValue_PreviewKeyDown;
        // 
        // btnOK
        // 
        
        btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        
        btnOK.Location = new System.Drawing.Point(11, 6);
        btnOK.Name = "btnOK";
        
        
        btnOK.Size = new System.Drawing.Size(106, 29);
        btnOK.TabIndex = 0;
        btnOK.Text = "OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        // 
        // btnCancel
        // 
        
        btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        
        btnCancel.Location = new System.Drawing.Point(223, 6);
        btnCancel.Name = "btnCancel";
        
        
        btnCancel.Size = new System.Drawing.Size(91, 29);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // comboBox
        // 
        comboBox.DrawMode = System.Windows.Forms.DrawMode.Normal;
        comboBox.DropDownHeight = 100;
        comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBox.FormattingEnabled = true;
        comboBox.IntegralHeight = false;
        comboBox.ItemHeight = 23;
        comboBox.Location = new System.Drawing.Point(12, 80);
        comboBox.Name = "comboBox";
        
        
        comboBox.Size = new System.Drawing.Size(277, 29);
        comboBox.TabIndex = 4;
        comboBox.Visible = false;
        // 
        // numValue
        // 
        
        numValue.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        
        numValue.Location = new System.Drawing.Point(12, 77);
        numValue.Maximum = new decimal(new int[] { 32765, 0, 0, 0 });
        numValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numValue.MinimumSize = new System.Drawing.Size(80, 25);
        numValue.Name = "numValue";
        numValue.Size = new System.Drawing.Size(156, 34);
        numValue.TabIndex = 5;
        numValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numValue.KeyUp += numValue_KeyUp;
        // 
        // panel1
        // 
        
        
        
        panel1.Controls.Add(btnOK);
        panel1.Controls.Add(btnCancel);
        panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        panel1.Location = new System.Drawing.Point(0, 125);
        panel1.Name = "panel1";
        
        
        panel1.Size = new System.Drawing.Size(324, 39);
        panel1.TabIndex = 6;
        // 
        // InputDialog
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        ClientSize = new System.Drawing.Size(324, 164);
        ControlBox = false;
        Controls.Add(panel1);
        Controls.Add(numValue);
        Controls.Add(comboBox);
        Controls.Add(txtValue);
        Controls.Add(lblMessage);
        Controls.Add(lblTitle);
        ForeColor = System.Drawing.Color.Black;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "InputDialog";
        ShowIcon = false;
        ShowInTaskbar = false;
        SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        FormClosing += InputDialog_FormClosing;
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblMessage;
    private TextBox txtValue;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private ComboBox comboBox;
    private Panel panel1;
    private NumericUpDown numValue;
}
