namespace RSBot.Chat.Views
{
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.txtSendAll = new System.Windows.Forms.TextBox();
            this.txtAll = new System.Windows.Forms.RichTextBox();
            this.tabPrivate = new System.Windows.Forms.TabPage();
            this.txtRecievePrivate = new System.Windows.Forms.TextBox();
            this.txtSendPrivate = new System.Windows.Forms.TextBox();
            this.txtPrivate = new System.Windows.Forms.RichTextBox();
            this.tabParty = new System.Windows.Forms.TabPage();
            this.txtSendParty = new System.Windows.Forms.TextBox();
            this.txtParty = new System.Windows.Forms.RichTextBox();
            this.tabGuild = new System.Windows.Forms.TabPage();
            this.txtSendGuild = new System.Windows.Forms.TextBox();
            this.txtGuild = new System.Windows.Forms.RichTextBox();
            this.tabUnion = new System.Windows.Forms.TabPage();
            this.txtSendUnion = new System.Windows.Forms.TextBox();
            this.txtUnion = new System.Windows.Forms.RichTextBox();
            this.tabAcademy = new System.Windows.Forms.TabPage();
            this.txtSendAcademy = new System.Windows.Forms.TextBox();
            this.txtAcademy = new System.Windows.Forms.RichTextBox();
            this.tabGlobal = new System.Windows.Forms.TabPage();
            this.txtGlobal = new System.Windows.Forms.RichTextBox();
            this.tabUnique = new System.Windows.Forms.TabPage();
            this.UniqueText = new System.Windows.Forms.RichTextBox();
            this.tabMain.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.tabPrivate.SuspendLayout();
            this.tabParty.SuspendLayout();
            this.tabGuild.SuspendLayout();
            this.tabUnion.SuspendLayout();
            this.tabAcademy.SuspendLayout();
            this.tabGlobal.SuspendLayout();
            this.tabUnique.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabAll);
            this.tabMain.Controls.Add(this.tabPrivate);
            this.tabMain.Controls.Add(this.tabParty);
            this.tabMain.Controls.Add(this.tabGuild);
            this.tabMain.Controls.Add(this.tabUnion);
            this.tabMain.Controls.Add(this.tabAcademy);
            this.tabMain.Controls.Add(this.tabGlobal);
            this.tabMain.Controls.Add(this.tabUnique);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(6, 6);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(742, 465);
            this.tabMain.TabIndex = 0;
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.txtSendAll);
            this.tabAll.Controls.Add(this.txtAll);
            this.tabAll.Location = new System.Drawing.Point(4, 22);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(734, 439);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // txtSendAll
            // 
            this.txtSendAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendAll.Location = new System.Drawing.Point(2, 413);
            this.txtSendAll.Name = "txtSendAll";
            this.txtSendAll.Size = new System.Drawing.Size(728, 20);
            this.txtSendAll.TabIndex = 3;
            this.txtSendAll.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtAll
            // 
            this.txtAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAll.BackColor = System.Drawing.Color.White;
            this.txtAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAll.Location = new System.Drawing.Point(2, 2);
            this.txtAll.Name = "txtAll";
            this.txtAll.ReadOnly = true;
            this.txtAll.Size = new System.Drawing.Size(728, 406);
            this.txtAll.TabIndex = 2;
            this.txtAll.Text = "";
            // 
            // tabPrivate
            // 
            this.tabPrivate.Controls.Add(this.txtRecievePrivate);
            this.tabPrivate.Controls.Add(this.txtSendPrivate);
            this.tabPrivate.Controls.Add(this.txtPrivate);
            this.tabPrivate.Location = new System.Drawing.Point(4, 22);
            this.tabPrivate.Name = "tabPrivate";
            this.tabPrivate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrivate.Size = new System.Drawing.Size(734, 439);
            this.tabPrivate.TabIndex = 1;
            this.tabPrivate.Text = "Private";
            this.tabPrivate.UseVisualStyleBackColor = true;
            // 
            // txtRecievePrivate
            // 
            this.txtRecievePrivate.Location = new System.Drawing.Point(2, 413);
            this.txtRecievePrivate.Name = "txtRecievePrivate";
            this.txtRecievePrivate.Size = new System.Drawing.Size(155, 20);
            this.txtRecievePrivate.TabIndex = 4;
            // 
            // txtSendPrivate
            // 
            this.txtSendPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendPrivate.Location = new System.Drawing.Point(164, 413);
            this.txtSendPrivate.Name = "txtSendPrivate";
            this.txtSendPrivate.Size = new System.Drawing.Size(566, 20);
            this.txtSendPrivate.TabIndex = 3;
            this.txtSendPrivate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtPrivate
            // 
            this.txtPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivate.BackColor = System.Drawing.Color.White;
            this.txtPrivate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrivate.Location = new System.Drawing.Point(2, 2);
            this.txtPrivate.Name = "txtPrivate";
            this.txtPrivate.ReadOnly = true;
            this.txtPrivate.Size = new System.Drawing.Size(728, 406);
            this.txtPrivate.TabIndex = 2;
            this.txtPrivate.Text = "";
            // 
            // tabParty
            // 
            this.tabParty.Controls.Add(this.txtSendParty);
            this.tabParty.Controls.Add(this.txtParty);
            this.tabParty.Location = new System.Drawing.Point(4, 22);
            this.tabParty.Name = "tabParty";
            this.tabParty.Padding = new System.Windows.Forms.Padding(3);
            this.tabParty.Size = new System.Drawing.Size(734, 439);
            this.tabParty.TabIndex = 2;
            this.tabParty.Text = "Party";
            this.tabParty.UseVisualStyleBackColor = true;
            // 
            // txtSendParty
            // 
            this.txtSendParty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendParty.Location = new System.Drawing.Point(2, 413);
            this.txtSendParty.Name = "txtSendParty";
            this.txtSendParty.Size = new System.Drawing.Size(728, 20);
            this.txtSendParty.TabIndex = 3;
            this.txtSendParty.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtParty
            // 
            this.txtParty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParty.BackColor = System.Drawing.Color.White;
            this.txtParty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParty.Location = new System.Drawing.Point(2, 2);
            this.txtParty.Name = "txtParty";
            this.txtParty.ReadOnly = true;
            this.txtParty.Size = new System.Drawing.Size(728, 406);
            this.txtParty.TabIndex = 2;
            this.txtParty.Text = "";
            // 
            // tabGuild
            // 
            this.tabGuild.Controls.Add(this.txtSendGuild);
            this.tabGuild.Controls.Add(this.txtGuild);
            this.tabGuild.Location = new System.Drawing.Point(4, 22);
            this.tabGuild.Name = "tabGuild";
            this.tabGuild.Padding = new System.Windows.Forms.Padding(3);
            this.tabGuild.Size = new System.Drawing.Size(734, 439);
            this.tabGuild.TabIndex = 3;
            this.tabGuild.Text = "Guild";
            this.tabGuild.UseVisualStyleBackColor = true;
            // 
            // txtSendGuild
            // 
            this.txtSendGuild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendGuild.Location = new System.Drawing.Point(2, 413);
            this.txtSendGuild.Name = "txtSendGuild";
            this.txtSendGuild.Size = new System.Drawing.Size(725, 20);
            this.txtSendGuild.TabIndex = 3;
            this.txtSendGuild.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtGuild
            // 
            this.txtGuild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGuild.BackColor = System.Drawing.Color.White;
            this.txtGuild.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGuild.Location = new System.Drawing.Point(2, 2);
            this.txtGuild.Name = "txtGuild";
            this.txtGuild.ReadOnly = true;
            this.txtGuild.Size = new System.Drawing.Size(728, 406);
            this.txtGuild.TabIndex = 2;
            this.txtGuild.Text = "";
            // 
            // tabUnion
            // 
            this.tabUnion.Controls.Add(this.txtSendUnion);
            this.tabUnion.Controls.Add(this.txtUnion);
            this.tabUnion.Location = new System.Drawing.Point(4, 22);
            this.tabUnion.Name = "tabUnion";
            this.tabUnion.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnion.Size = new System.Drawing.Size(734, 439);
            this.tabUnion.TabIndex = 6;
            this.tabUnion.Text = "Union";
            this.tabUnion.UseVisualStyleBackColor = true;
            // 
            // txtSendUnion
            // 
            this.txtSendUnion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendUnion.Location = new System.Drawing.Point(2, 413);
            this.txtSendUnion.Name = "txtSendUnion";
            this.txtSendUnion.Size = new System.Drawing.Size(728, 20);
            this.txtSendUnion.TabIndex = 5;
            this.txtSendUnion.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtUnion
            // 
            this.txtUnion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnion.BackColor = System.Drawing.Color.White;
            this.txtUnion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnion.Location = new System.Drawing.Point(2, 2);
            this.txtUnion.Name = "txtUnion";
            this.txtUnion.ReadOnly = true;
            this.txtUnion.Size = new System.Drawing.Size(728, 406);
            this.txtUnion.TabIndex = 4;
            this.txtUnion.Text = "";
            // 
            // tabAcademy
            // 
            this.tabAcademy.Controls.Add(this.txtSendAcademy);
            this.tabAcademy.Controls.Add(this.txtAcademy);
            this.tabAcademy.Location = new System.Drawing.Point(4, 22);
            this.tabAcademy.Name = "tabAcademy";
            this.tabAcademy.Padding = new System.Windows.Forms.Padding(3);
            this.tabAcademy.Size = new System.Drawing.Size(734, 439);
            this.tabAcademy.TabIndex = 4;
            this.tabAcademy.Text = "Academy";
            this.tabAcademy.UseVisualStyleBackColor = true;
            // 
            // txtSendAcademy
            // 
            this.txtSendAcademy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendAcademy.Location = new System.Drawing.Point(2, 413);
            this.txtSendAcademy.Name = "txtSendAcademy";
            this.txtSendAcademy.Size = new System.Drawing.Size(728, 20);
            this.txtSendAcademy.TabIndex = 3;
            this.txtSendAcademy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtAcademy
            // 
            this.txtAcademy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcademy.BackColor = System.Drawing.Color.White;
            this.txtAcademy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAcademy.Location = new System.Drawing.Point(2, 2);
            this.txtAcademy.Name = "txtAcademy";
            this.txtAcademy.ReadOnly = true;
            this.txtAcademy.Size = new System.Drawing.Size(728, 406);
            this.txtAcademy.TabIndex = 2;
            this.txtAcademy.Text = "";
            // 
            // tabGlobal
            // 
            this.tabGlobal.Controls.Add(this.txtGlobal);
            this.tabGlobal.Location = new System.Drawing.Point(4, 22);
            this.tabGlobal.Name = "tabGlobal";
            this.tabGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlobal.Size = new System.Drawing.Size(734, 439);
            this.tabGlobal.TabIndex = 5;
            this.tabGlobal.Text = "Global / Notice";
            this.tabGlobal.UseVisualStyleBackColor = true;
            // 
            // txtGlobal
            // 
            this.txtGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGlobal.BackColor = System.Drawing.Color.White;
            this.txtGlobal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGlobal.Location = new System.Drawing.Point(2, 2);
            this.txtGlobal.Name = "txtGlobal";
            this.txtGlobal.ReadOnly = true;
            this.txtGlobal.Size = new System.Drawing.Size(728, 434);
            this.txtGlobal.TabIndex = 2;
            this.txtGlobal.Text = "";
            // 
            // tabUnique
            // 
            this.tabUnique.Controls.Add(this.UniqueText);
            this.tabUnique.Location = new System.Drawing.Point(4, 22);
            this.tabUnique.Name = "tabUnique";
            this.tabUnique.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnique.Size = new System.Drawing.Size(734, 439);
            this.tabUnique.TabIndex = 7;
            this.tabUnique.Text = "Unique";
            this.tabUnique.UseVisualStyleBackColor = true;
            // 
            // UniqueText
            // 
            this.UniqueText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UniqueText.BackColor = System.Drawing.Color.White;
            this.UniqueText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UniqueText.Location = new System.Drawing.Point(2, 2);
            this.UniqueText.Name = "UniqueText";
            this.UniqueText.ReadOnly = true;
            this.UniqueText.Size = new System.Drawing.Size(728, 434);
            this.UniqueText.TabIndex = 3;
            this.UniqueText.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.tabMain);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(754, 477);
            this.tabMain.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabAll.PerformLayout();
            this.tabPrivate.ResumeLayout(false);
            this.tabPrivate.PerformLayout();
            this.tabParty.ResumeLayout(false);
            this.tabParty.PerformLayout();
            this.tabGuild.ResumeLayout(false);
            this.tabGuild.PerformLayout();
            this.tabUnion.ResumeLayout(false);
            this.tabUnion.PerformLayout();
            this.tabAcademy.ResumeLayout(false);
            this.tabAcademy.PerformLayout();
            this.tabGlobal.ResumeLayout(false);
            this.tabUnique.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabPrivate;
        private System.Windows.Forms.TabPage tabParty;
        private System.Windows.Forms.TabPage tabGuild;
        private System.Windows.Forms.TabPage tabAcademy;
        private System.Windows.Forms.TabPage tabGlobal;
        private System.Windows.Forms.TextBox txtSendPrivate;
        private System.Windows.Forms.RichTextBox txtPrivate;
        private System.Windows.Forms.TextBox txtSendAll;
        private System.Windows.Forms.RichTextBox txtAll;
        private System.Windows.Forms.TextBox txtSendParty;
        private System.Windows.Forms.RichTextBox txtParty;
        private System.Windows.Forms.TextBox txtSendGuild;
        private System.Windows.Forms.RichTextBox txtGuild;
        private System.Windows.Forms.TextBox txtSendAcademy;
        private System.Windows.Forms.RichTextBox txtAcademy;
        private System.Windows.Forms.RichTextBox txtGlobal;
        private System.Windows.Forms.TextBox txtRecievePrivate;
        private System.Windows.Forms.TabPage tabUnion;
        private System.Windows.Forms.TextBox txtSendUnion;
        private System.Windows.Forms.RichTextBox txtUnion;
        private System.Windows.Forms.TabPage tabUnique;
        internal System.Windows.Forms.RichTextBox UniqueText;
    }
}
