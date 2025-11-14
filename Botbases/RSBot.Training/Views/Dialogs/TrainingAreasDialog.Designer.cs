namespace RSBot.Default.Views.Dialogs
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
            contextMenuStrip = new SDUI.Controls.ContextMenuStrip();
            createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeSelectedAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            listView = new SDUI.Controls.ListView();
            columnHeaderId = new System.Windows.Forms.ColumnHeader();
            columnHeaderName = new System.Windows.Forms.ColumnHeader();
            columnHeaderRegion = new System.Windows.Forms.ColumnHeader();
            columnHeaderX = new System.Windows.Forms.ColumnHeader();
            columnHeaderY = new System.Windows.Forms.ColumnHeader();
            columnHeaderR = new System.Windows.Forms.ColumnHeader();
            columnHeaderS = new System.Windows.Forms.ColumnHeader();
            panel1 = new SDUI.Controls.Panel();
            labelPos = new SDUI.Controls.Label();
            buttonCancel = new SDUI.Controls.Button();
            buttonAccept = new SDUI.Controls.Button();
            contextMenuStrip.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { createToolStripMenuItem, removeSelectedAreaToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(189, 48);
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            createToolStripMenuItem.Text = "Create";
            createToolStripMenuItem.Click += createToolStripMenuItem_Click;
            // 
            // removeSelectedAreaToolStripMenuItem
            // 
            removeSelectedAreaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            removeSelectedAreaToolStripMenuItem.Name = "removeSelectedAreaToolStripMenuItem";
            removeSelectedAreaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            removeSelectedAreaToolStripMenuItem.Text = "Remove selected area";
            removeSelectedAreaToolStripMenuItem.Click += removeSelectedAreaToolStripMenuItem_Click;
            // 
            // listView
            // 
            listView.BackColor = System.Drawing.Color.White;
            listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeaderId, columnHeaderName, columnHeaderRegion, columnHeaderX, columnHeaderY, columnHeaderR, columnHeaderS });
            listView.ContextMenuStrip = contextMenuStrip;
            listView.Dock = System.Windows.Forms.DockStyle.Fill;
            listView.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            listView.FullRowSelect = true;
            listView.Location = new System.Drawing.Point(1, 1);
            listView.Name = "listView";
            listView.Size = new System.Drawing.Size(607, 271);
            listView.TabIndex = 1;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            columnHeaderId.Text = "Id";
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 170;
            // 
            // columnHeaderRegion
            // 
            columnHeaderRegion.Text = "Region";
            columnHeaderRegion.Width = 150;
            // 
            // columnHeaderX
            // 
            columnHeaderX.Text = "X";
            // 
            // columnHeaderY
            // 
            columnHeaderY.Text = "Y";
            // 
            // columnHeaderR
            // 
            columnHeaderR.Text = "Radius";
            // 
            // columnHeaderS
            // 
            columnHeaderS.Text = "Selected";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Border = new System.Windows.Forms.Padding(0, 1, 0, 0);
            panel1.BorderColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(labelPos);
            panel1.Controls.Add(buttonCancel);
            panel1.Controls.Add(buttonAccept);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(1, 272);
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.ShadowDepth = 0F;
            panel1.Size = new System.Drawing.Size(607, 39);
            panel1.TabIndex = 2;
            // 
            // labelPos
            // 
            labelPos.ApplyGradient = false;
            labelPos.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            labelPos.Gradient = new System.Drawing.Color[]
    {
    System.Drawing.Color.Gray,
    System.Drawing.Color.Black
    };
            labelPos.GradientAnimation = false;
            labelPos.Location = new System.Drawing.Point(203, 1);
            labelPos.Name = "labelPos";
            labelPos.Size = new System.Drawing.Size(234, 36);
            labelPos.TabIndex = 1;
            labelPos.Text = "Experimental Window\r\nRight Click to create a new training area";
            labelPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonCancel.Color = System.Drawing.Color.Transparent;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(520, 8);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Radius = 6;
            buttonCancel.ShadowDepth = 4F;
            buttonCancel.Size = new System.Drawing.Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            buttonAccept.Color = System.Drawing.Color.FromArgb(56, 155, 90);
            buttonAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonAccept.ForeColor = System.Drawing.Color.White;
            buttonAccept.Location = new System.Drawing.Point(12, 8);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Radius = 6;
            buttonAccept.ShadowDepth = 4F;
            buttonAccept.Size = new System.Drawing.Size(75, 23);
            buttonAccept.TabIndex = 0;
            buttonAccept.Text = "Accept";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // TrainingAreasDialog
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new System.Drawing.Size(609, 312);
            ControlBox = false;
            Controls.Add(listView);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Location = new System.Drawing.Point(0, 0);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TrainingAreasDialog";
            Padding = new System.Windows.Forms.Padding(1);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "[Experimental] Training Areas - Right click for create";
            FormClosing += TrainingAreas_FormClosing;
            Load += TrainingAreas_Load;
            contextMenuStrip.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);

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