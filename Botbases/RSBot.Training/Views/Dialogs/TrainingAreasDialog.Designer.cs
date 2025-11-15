namespace RSBot.Training.Views.Dialogs
{
    partial class TrainingAreasDialog
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
            this.contextMenuStrip = new SDUI.Controls.ContextMenuStrip();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new SDUI.Controls.ListView();
            this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRegion = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderX = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderY = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderR = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderS = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new SDUI.Controls.Panel();
            this.labelPos = new SDUI.Controls.Label();
            this.buttonCancel = new SDUI.Controls.Button();
            this.buttonAccept = new SDUI.Controls.Button();
            this.removeSelectedAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.removeSelectedAreaToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(189, 70);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderRegion,
            this.columnHeaderX,
            this.columnHeaderY,
            this.columnHeaderR,
            this.columnHeaderS});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(1, 1);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(613, 277);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 170;
            // 
            // columnHeaderRegion
            // 
            this.columnHeaderRegion.Text = "Region";
            this.columnHeaderRegion.Width = 150;
            // 
            // columnHeaderX
            // 
            this.columnHeaderX.Text = "X";
            // 
            // columnHeaderY
            // 
            this.columnHeaderY.Text = "Y";
            // 
            // columnHeaderR
            // 
            this.columnHeaderR.Text = "Radius";
            // 
            // columnHeaderS
            // 
            this.columnHeaderS.Text = "Selected";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel1.BorderColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelPos);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonAccept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 278);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.ShadowDepth = 0F;
            this.panel1.Size = new System.Drawing.Size(613, 39);
            this.panel1.TabIndex = 2;
            // 
            // labelPos
            // 
            this.labelPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPos.Location = new System.Drawing.Point(203, 1);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(234, 36);
            this.labelPos.TabIndex = 1;
            this.labelPos.Text = "Experimental Window\r\nRight Click to create a new training area";
            this.labelPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Color = System.Drawing.Color.Transparent;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(526, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Radius = 6;
            this.buttonCancel.ShadowDepth = 4F;
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Color = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(155)))), ((int)(((byte)(90)))));
            this.buttonAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAccept.ForeColor = System.Drawing.Color.White;
            this.buttonAccept.Location = new System.Drawing.Point(12, 8);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Radius = 6;
            this.buttonAccept.ShadowDepth = 4F;
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // removeSelectedAreaToolStripMenuItem
            // 
            this.removeSelectedAreaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.removeSelectedAreaToolStripMenuItem.Name = "removeSelectedAreaToolStripMenuItem";
            this.removeSelectedAreaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.removeSelectedAreaToolStripMenuItem.Text = "Remove selected area";
            this.removeSelectedAreaToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedAreaToolStripMenuItem_Click);
            // 
            // TrainingAreasDialog
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(615, 318);
            this.ControlBox = false;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainingAreasDialog";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Experimental] Training Areas - Right click for create";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainingAreas_FormClosing);
            this.Load += new System.EventHandler(this.TrainingAreas_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SDUI.Controls.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private SDUI.Controls.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderX;
        private System.Windows.Forms.ColumnHeader columnHeaderY;
        private System.Windows.Forms.ColumnHeader columnHeaderR;
        private System.Windows.Forms.ColumnHeader columnHeaderS;
        private SDUI.Controls.Panel panel1;
        private SDUI.Controls.Button buttonCancel;
        private SDUI.Controls.Button buttonAccept;
        private System.Windows.Forms.ColumnHeader columnHeaderRegion;
        private SDUI.Controls.Label labelPos;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedAreaToolStripMenuItem;
    }
}