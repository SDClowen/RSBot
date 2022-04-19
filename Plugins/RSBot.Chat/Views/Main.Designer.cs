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
            this.tabMain = new SDUI.Controls.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.txtSendAll = new SDUI.Controls.TextBox();
            this.txtAll = new System.Windows.Forms.RichTextBox();
            this.tabPrivate = new System.Windows.Forms.TabPage();
            this.txtRecievePrivate = new SDUI.Controls.TextBox();
            this.txtSendPrivate = new SDUI.Controls.TextBox();
            this.txtPrivate = new System.Windows.Forms.RichTextBox();
            this.tabParty = new System.Windows.Forms.TabPage();
            this.txtSendParty = new SDUI.Controls.TextBox();
            this.txtParty = new System.Windows.Forms.RichTextBox();
            this.tabGuild = new System.Windows.Forms.TabPage();
            this.txtSendGuild = new SDUI.Controls.TextBox();
            this.txtGuild = new System.Windows.Forms.RichTextBox();
            this.tabUnion = new System.Windows.Forms.TabPage();
            this.txtSendUnion = new SDUI.Controls.TextBox();
            this.txtUnion = new System.Windows.Forms.RichTextBox();
            this.tabAcademy = new System.Windows.Forms.TabPage();
            this.txtSendAcademy = new SDUI.Controls.TextBox();
            this.txtAcademy = new System.Windows.Forms.RichTextBox();
            this.tabGlobal = new System.Windows.Forms.TabPage();
            this.txtGlobal = new System.Windows.Forms.RichTextBox();
            this.tabStall = new System.Windows.Forms.TabPage();
            this.txtStall = new System.Windows.Forms.RichTextBox();
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
            this.tabStall.SuspendLayout();
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
            this.tabMain.Controls.Add(this.tabStall);
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
            this.tabAll.BackColor = System.Drawing.Color.White;
            this.tabAll.Controls.Add(this.txtSendAll);
            this.tabAll.Controls.Add(this.txtAll);
            this.tabAll.Location = new System.Drawing.Point(4, 25);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(734, 436);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            // 
            // txtSendAll
            // 
            this.txtSendAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendAll.Location = new System.Drawing.Point(2, 413);
            this.txtSendAll.MaxLength = 32767;
            this.txtSendAll.MultiLine = false;
            this.txtSendAll.Name = "txtSendAll";
            this.txtSendAll.Size = new System.Drawing.Size(728, 18);
            this.txtSendAll.TabIndex = 3;
            this.txtSendAll.Tag = "1";
            this.txtSendAll.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendAll.UseSystemPasswordChar = false;
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
            this.tabPrivate.BackColor = System.Drawing.Color.White;
            this.tabPrivate.Controls.Add(this.txtRecievePrivate);
            this.tabPrivate.Controls.Add(this.txtSendPrivate);
            this.tabPrivate.Controls.Add(this.txtPrivate);
            this.tabPrivate.Location = new System.Drawing.Point(4, 25);
            this.tabPrivate.Name = "tabPrivate";
            this.tabPrivate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrivate.Size = new System.Drawing.Size(734, 436);
            this.tabPrivate.TabIndex = 1;
            this.tabPrivate.Text = "Private";
            // 
            // txtRecievePrivate
            // 
            this.txtRecievePrivate.Location = new System.Drawing.Point(2, 413);
            this.txtRecievePrivate.MaxLength = 32767;
            this.txtRecievePrivate.MultiLine = false;
            this.txtRecievePrivate.Name = "txtRecievePrivate";
            this.txtRecievePrivate.Size = new System.Drawing.Size(155, 20);
            this.txtRecievePrivate.TabIndex = 4;
            this.txtRecievePrivate.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRecievePrivate.UseSystemPasswordChar = false;
            // 
            // txtSendPrivate
            // 
            this.txtSendPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendPrivate.Location = new System.Drawing.Point(164, 413);
            this.txtSendPrivate.MaxLength = 32767;
            this.txtSendPrivate.MultiLine = false;
            this.txtSendPrivate.Name = "txtSendPrivate";
            this.txtSendPrivate.Size = new System.Drawing.Size(566, 20);
            this.txtSendPrivate.TabIndex = 5;
            this.txtSendPrivate.Tag = "2";
            this.txtSendPrivate.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendPrivate.UseSystemPasswordChar = false;
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
            this.tabParty.BackColor = System.Drawing.Color.White;
            this.tabParty.Controls.Add(this.txtSendParty);
            this.tabParty.Controls.Add(this.txtParty);
            this.tabParty.Location = new System.Drawing.Point(4, 25);
            this.tabParty.Name = "tabParty";
            this.tabParty.Padding = new System.Windows.Forms.Padding(3);
            this.tabParty.Size = new System.Drawing.Size(734, 436);
            this.tabParty.TabIndex = 2;
            this.tabParty.Text = "Party";
            // 
            // txtSendParty
            // 
            this.txtSendParty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendParty.Location = new System.Drawing.Point(2, 413);
            this.txtSendParty.MaxLength = 32767;
            this.txtSendParty.MultiLine = false;
            this.txtSendParty.Name = "txtSendParty";
            this.txtSendParty.Size = new System.Drawing.Size(728, 20);
            this.txtSendParty.TabIndex = 3;
            this.txtSendParty.Tag = "4";
            this.txtSendParty.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendParty.UseSystemPasswordChar = false;
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
            this.tabGuild.BackColor = System.Drawing.Color.White;
            this.tabGuild.Controls.Add(this.txtSendGuild);
            this.tabGuild.Controls.Add(this.txtGuild);
            this.tabGuild.Location = new System.Drawing.Point(4, 25);
            this.tabGuild.Name = "tabGuild";
            this.tabGuild.Padding = new System.Windows.Forms.Padding(3);
            this.tabGuild.Size = new System.Drawing.Size(734, 436);
            this.tabGuild.TabIndex = 3;
            this.tabGuild.Text = "Guild";
            // 
            // txtSendGuild
            // 
            this.txtSendGuild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendGuild.Location = new System.Drawing.Point(2, 413);
            this.txtSendGuild.MaxLength = 32767;
            this.txtSendGuild.MultiLine = false;
            this.txtSendGuild.Name = "txtSendGuild";
            this.txtSendGuild.Size = new System.Drawing.Size(725, 20);
            this.txtSendGuild.TabIndex = 3;
            this.txtSendGuild.Tag = "5";
            this.txtSendGuild.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendGuild.UseSystemPasswordChar = false;
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
            this.tabUnion.BackColor = System.Drawing.Color.White;
            this.tabUnion.Controls.Add(this.txtSendUnion);
            this.tabUnion.Controls.Add(this.txtUnion);
            this.tabUnion.Location = new System.Drawing.Point(4, 25);
            this.tabUnion.Name = "tabUnion";
            this.tabUnion.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnion.Size = new System.Drawing.Size(734, 436);
            this.tabUnion.TabIndex = 6;
            this.tabUnion.Text = "Union";
            // 
            // txtSendUnion
            // 
            this.txtSendUnion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendUnion.Location = new System.Drawing.Point(2, 413);
            this.txtSendUnion.MaxLength = 32767;
            this.txtSendUnion.MultiLine = false;
            this.txtSendUnion.Name = "txtSendUnion";
            this.txtSendUnion.Size = new System.Drawing.Size(728, 20);
            this.txtSendUnion.TabIndex = 5;
            this.txtSendUnion.Tag = "11";
            this.txtSendUnion.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendUnion.UseSystemPasswordChar = false;
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
            this.tabAcademy.BackColor = System.Drawing.Color.White;
            this.tabAcademy.Controls.Add(this.txtSendAcademy);
            this.tabAcademy.Controls.Add(this.txtAcademy);
            this.tabAcademy.Location = new System.Drawing.Point(4, 25);
            this.tabAcademy.Name = "tabAcademy";
            this.tabAcademy.Padding = new System.Windows.Forms.Padding(3);
            this.tabAcademy.Size = new System.Drawing.Size(734, 436);
            this.tabAcademy.TabIndex = 4;
            this.tabAcademy.Text = "Academy";
            // 
            // txtSendAcademy
            // 
            this.txtSendAcademy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendAcademy.Location = new System.Drawing.Point(2, 413);
            this.txtSendAcademy.MaxLength = 32767;
            this.txtSendAcademy.MultiLine = false;
            this.txtSendAcademy.Name = "txtSendAcademy";
            this.txtSendAcademy.Size = new System.Drawing.Size(728, 20);
            this.txtSendAcademy.TabIndex = 3;
            this.txtSendAcademy.Tag = "16";
            this.txtSendAcademy.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendAcademy.UseSystemPasswordChar = false;
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
            this.tabGlobal.BackColor = System.Drawing.Color.White;
            this.tabGlobal.Controls.Add(this.txtGlobal);
            this.tabGlobal.Location = new System.Drawing.Point(4, 25);
            this.tabGlobal.Name = "tabGlobal";
            this.tabGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlobal.Size = new System.Drawing.Size(734, 436);
            this.tabGlobal.TabIndex = 5;
            this.tabGlobal.Text = "Global / Notice";
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
            // tabStall
            // 
            this.tabStall.BackColor = System.Drawing.Color.White;
            this.tabStall.Controls.Add(this.txtStall);
            this.tabStall.Location = new System.Drawing.Point(4, 25);
            this.tabStall.Name = "tabStall";
            this.tabStall.Padding = new System.Windows.Forms.Padding(3);
            this.tabStall.Size = new System.Drawing.Size(734, 436);
            this.tabStall.TabIndex = 5;
            this.tabStall.Text = "Stall";
            // 
            // txtStall
            // 
            this.txtStall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStall.BackColor = System.Drawing.Color.White;
            this.txtStall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStall.Location = new System.Drawing.Point(2, 2);
            this.txtStall.Name = "txtStall";
            this.txtStall.ReadOnly = true;
            this.txtStall.Size = new System.Drawing.Size(728, 434);
            this.txtStall.TabIndex = 2;
            this.txtStall.Text = "";
            // 
            // tabUnique
            // 
            this.tabUnique.BackColor = System.Drawing.Color.White;
            this.tabUnique.Controls.Add(this.UniqueText);
            this.tabUnique.Location = new System.Drawing.Point(4, 25);
            this.tabUnique.Name = "tabUnique";
            this.tabUnique.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnique.Size = new System.Drawing.Size(734, 436);
            this.tabUnique.TabIndex = 7;
            this.tabUnique.Text = "Unique";
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
            this.Controls.Add(this.tabMain);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(754, 477);
            this.tabMain.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabPrivate.ResumeLayout(false);
            this.tabParty.ResumeLayout(false);
            this.tabGuild.ResumeLayout(false);
            this.tabUnion.ResumeLayout(false);
            this.tabAcademy.ResumeLayout(false);
            this.tabGlobal.ResumeLayout(false);
            this.tabStall.ResumeLayout(false);
            this.tabUnique.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SDUI.Controls.TabControl tabMain;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabPrivate;
        private System.Windows.Forms.TabPage tabParty;
        private System.Windows.Forms.TabPage tabGuild;
        private System.Windows.Forms.TabPage tabAcademy;
        private System.Windows.Forms.TabPage tabGlobal;
        private System.Windows.Forms.TabPage tabStall;
        private SDUI.Controls.TextBox txtSendPrivate;
        private System.Windows.Forms.RichTextBox txtPrivate;
        private SDUI.Controls.TextBox txtSendAll;
        private System.Windows.Forms.RichTextBox txtAll;
        private SDUI.Controls.TextBox txtSendParty;
        private System.Windows.Forms.RichTextBox txtParty;
        private SDUI.Controls.TextBox txtSendGuild;
        private System.Windows.Forms.RichTextBox txtGuild;
        private SDUI.Controls.TextBox txtSendAcademy;
        private System.Windows.Forms.RichTextBox txtAcademy;
        private System.Windows.Forms.RichTextBox txtGlobal;
        private System.Windows.Forms.RichTextBox txtStall;
        private SDUI.Controls.TextBox txtRecievePrivate;
        private System.Windows.Forms.TabPage tabUnion;
        private SDUI.Controls.TextBox txtSendUnion;
        private System.Windows.Forms.RichTextBox txtUnion;
        private System.Windows.Forms.TabPage tabUnique;
        internal System.Windows.Forms.RichTextBox UniqueText;
    }
}
