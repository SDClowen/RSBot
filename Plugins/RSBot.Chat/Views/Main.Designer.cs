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
            this.separator6 = new SDUI.Controls.Separator();
            this.txtSendAll = new SDUI.Controls.TextBox();
            this.txtAll = new System.Windows.Forms.RichTextBox();
            this.tabPrivate = new System.Windows.Forms.TabPage();
            this.separator5 = new SDUI.Controls.Separator();
            this.txtPrivate = new System.Windows.Forms.RichTextBox();
            this.textBoxPrivateMsg = new SDUI.Controls.TextBox();
            this.txtRecievePrivate = new SDUI.Controls.TextBox();
            this.tabParty = new System.Windows.Forms.TabPage();
            this.separator4 = new SDUI.Controls.Separator();
            this.txtSendParty = new SDUI.Controls.TextBox();
            this.txtParty = new System.Windows.Forms.RichTextBox();
            this.tabGuild = new System.Windows.Forms.TabPage();
            this.separator3 = new SDUI.Controls.Separator();
            this.txtSendGuild = new SDUI.Controls.TextBox();
            this.txtGuild = new System.Windows.Forms.RichTextBox();
            this.tabUnion = new System.Windows.Forms.TabPage();
            this.separator2 = new SDUI.Controls.Separator();
            this.txtSendUnion = new SDUI.Controls.TextBox();
            this.txtUnion = new System.Windows.Forms.RichTextBox();
            this.tabAcademy = new System.Windows.Forms.TabPage();
            this.separator1 = new SDUI.Controls.Separator();
            this.txtSendAcademy = new SDUI.Controls.TextBox();
            this.txtAcademy = new System.Windows.Forms.RichTextBox();
            this.tabGlobal = new System.Windows.Forms.TabPage();
            this.txtGlobal = new System.Windows.Forms.RichTextBox();
            this.tabStall = new System.Windows.Forms.TabPage();
            this.txtStall = new System.Windows.Forms.RichTextBox();
            this.tabUnique = new System.Windows.Forms.TabPage();
            this.UniqueText = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Border = new System.Windows.Forms.Padding(1);
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
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(754, 477);
            this.tabMain.TabIndex = 0;
            // 
            // tabAll
            // 
            this.tabAll.BackColor = System.Drawing.Color.White;
            this.tabAll.Controls.Add(this.txtAll);
            this.tabAll.Controls.Add(this.separator6);
            this.tabAll.Controls.Add(this.txtSendAll);
            this.tabAll.Location = new System.Drawing.Point(4, 25);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(746, 448);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            // 
            // separator6
            // 
            this.separator6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator6.IsVertical = false;
            this.separator6.Location = new System.Drawing.Point(3, 414);
            this.separator6.Name = "separator6";
            this.separator6.Size = new System.Drawing.Size(740, 10);
            this.separator6.TabIndex = 4;
            this.separator6.Text = "separator6";
            // 
            // txtSendAll
            // 
            this.txtSendAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSendAll.Location = new System.Drawing.Point(3, 424);
            this.txtSendAll.MaxLength = 32767;
            this.txtSendAll.MultiLine = false;
            this.txtSendAll.Name = "txtSendAll";
            this.txtSendAll.Size = new System.Drawing.Size(740, 21);
            this.txtSendAll.TabIndex = 3;
            this.txtSendAll.Tag = "1";
            this.txtSendAll.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendAll.UseSystemPasswordChar = false;
            this.txtSendAll.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtAll
            // 
            this.txtAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAll.Location = new System.Drawing.Point(3, 3);
            this.txtAll.Name = "txtAll";
            this.txtAll.ReadOnly = true;
            this.txtAll.Size = new System.Drawing.Size(740, 411);
            this.txtAll.TabIndex = 2;
            this.txtAll.Text = "";
            // 
            // tabPrivate
            // 
            this.tabPrivate.BackColor = System.Drawing.Color.White;
            this.tabPrivate.Controls.Add(this.txtPrivate);
            this.tabPrivate.Controls.Add(this.separator5);
            this.tabPrivate.Controls.Add(this.panel1);
            this.tabPrivate.Location = new System.Drawing.Point(4, 25);
            this.tabPrivate.Name = "tabPrivate";
            this.tabPrivate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrivate.Size = new System.Drawing.Size(746, 448);
            this.tabPrivate.TabIndex = 1;
            this.tabPrivate.Text = "Private";
            // 
            // separator5
            // 
            this.separator5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator5.IsVertical = false;
            this.separator5.Location = new System.Drawing.Point(3, 405);
            this.separator5.Name = "separator5";
            this.separator5.Size = new System.Drawing.Size(740, 10);
            this.separator5.TabIndex = 6;
            this.separator5.Text = "separator5";
            // 
            // txtPrivate
            // 
            this.txtPrivate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrivate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrivate.Location = new System.Drawing.Point(3, 3);
            this.txtPrivate.Name = "txtPrivate";
            this.txtPrivate.Size = new System.Drawing.Size(740, 402);
            this.txtPrivate.TabIndex = 7;
            this.txtPrivate.Text = "";
            // 
            // textBoxPrivateMsg
            // 
            this.textBoxPrivateMsg.Location = new System.Drawing.Point(164, 3);
            this.textBoxPrivateMsg.MaxLength = 32767;
            this.textBoxPrivateMsg.MultiLine = false;
            this.textBoxPrivateMsg.Name = "textBoxPrivateMsg";
            this.textBoxPrivateMsg.Size = new System.Drawing.Size(573, 21);
            this.textBoxPrivateMsg.TabIndex = 4;
            this.textBoxPrivateMsg.Tag = "2";
            this.textBoxPrivateMsg.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPrivateMsg.UseSystemPasswordChar = false;
            this.textBoxPrivateMsg.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtRecievePrivate
            // 
            this.txtRecievePrivate.Location = new System.Drawing.Point(3, 3);
            this.txtRecievePrivate.MaxLength = 32767;
            this.txtRecievePrivate.MultiLine = false;
            this.txtRecievePrivate.Name = "txtRecievePrivate";
            this.txtRecievePrivate.Size = new System.Drawing.Size(155, 21);
            this.txtRecievePrivate.TabIndex = 4;
            this.txtRecievePrivate.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRecievePrivate.UseSystemPasswordChar = false;
            // 
            // tabParty
            // 
            this.tabParty.BackColor = System.Drawing.Color.White;
            this.tabParty.Controls.Add(this.txtParty);
            this.tabParty.Controls.Add(this.separator4);
            this.tabParty.Controls.Add(this.txtSendParty);
            this.tabParty.Location = new System.Drawing.Point(4, 25);
            this.tabParty.Name = "tabParty";
            this.tabParty.Padding = new System.Windows.Forms.Padding(3);
            this.tabParty.Size = new System.Drawing.Size(746, 448);
            this.tabParty.TabIndex = 2;
            this.tabParty.Text = "Party";
            // 
            // separator4
            // 
            this.separator4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator4.IsVertical = false;
            this.separator4.Location = new System.Drawing.Point(3, 414);
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(740, 10);
            this.separator4.TabIndex = 4;
            this.separator4.Text = "separator4";
            // 
            // txtSendParty
            // 
            this.txtSendParty.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSendParty.Location = new System.Drawing.Point(3, 424);
            this.txtSendParty.MaxLength = 32767;
            this.txtSendParty.MultiLine = false;
            this.txtSendParty.Name = "txtSendParty";
            this.txtSendParty.Size = new System.Drawing.Size(740, 21);
            this.txtSendParty.TabIndex = 3;
            this.txtSendParty.Tag = "4";
            this.txtSendParty.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendParty.UseSystemPasswordChar = false;
            this.txtSendParty.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtParty
            // 
            this.txtParty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtParty.Location = new System.Drawing.Point(3, 3);
            this.txtParty.Name = "txtParty";
            this.txtParty.ReadOnly = true;
            this.txtParty.Size = new System.Drawing.Size(740, 411);
            this.txtParty.TabIndex = 2;
            this.txtParty.Text = "";
            // 
            // tabGuild
            // 
            this.tabGuild.BackColor = System.Drawing.Color.White;
            this.tabGuild.Controls.Add(this.txtGuild);
            this.tabGuild.Controls.Add(this.separator3);
            this.tabGuild.Controls.Add(this.txtSendGuild);
            this.tabGuild.Location = new System.Drawing.Point(4, 25);
            this.tabGuild.Name = "tabGuild";
            this.tabGuild.Padding = new System.Windows.Forms.Padding(3);
            this.tabGuild.Size = new System.Drawing.Size(746, 448);
            this.tabGuild.TabIndex = 3;
            this.tabGuild.Text = "Guild";
            // 
            // separator3
            // 
            this.separator3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator3.IsVertical = false;
            this.separator3.Location = new System.Drawing.Point(3, 414);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(740, 10);
            this.separator3.TabIndex = 4;
            this.separator3.Text = "separator3";
            // 
            // txtSendGuild
            // 
            this.txtSendGuild.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSendGuild.Location = new System.Drawing.Point(3, 424);
            this.txtSendGuild.MaxLength = 32767;
            this.txtSendGuild.MultiLine = false;
            this.txtSendGuild.Name = "txtSendGuild";
            this.txtSendGuild.Size = new System.Drawing.Size(740, 21);
            this.txtSendGuild.TabIndex = 3;
            this.txtSendGuild.Tag = "5";
            this.txtSendGuild.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendGuild.UseSystemPasswordChar = false;
            this.txtSendGuild.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtGuild
            // 
            this.txtGuild.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGuild.Location = new System.Drawing.Point(3, 3);
            this.txtGuild.Name = "txtGuild";
            this.txtGuild.ReadOnly = true;
            this.txtGuild.Size = new System.Drawing.Size(740, 411);
            this.txtGuild.TabIndex = 2;
            this.txtGuild.Text = "";
            // 
            // tabUnion
            // 
            this.tabUnion.BackColor = System.Drawing.Color.White;
            this.tabUnion.Controls.Add(this.txtUnion);
            this.tabUnion.Controls.Add(this.separator2);
            this.tabUnion.Controls.Add(this.txtSendUnion);
            this.tabUnion.Location = new System.Drawing.Point(4, 25);
            this.tabUnion.Name = "tabUnion";
            this.tabUnion.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnion.Size = new System.Drawing.Size(746, 448);
            this.tabUnion.TabIndex = 6;
            this.tabUnion.Text = "Union";
            // 
            // separator2
            // 
            this.separator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator2.IsVertical = false;
            this.separator2.Location = new System.Drawing.Point(3, 414);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(740, 10);
            this.separator2.TabIndex = 6;
            this.separator2.Text = "separator2";
            // 
            // txtSendUnion
            // 
            this.txtSendUnion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSendUnion.Location = new System.Drawing.Point(3, 424);
            this.txtSendUnion.MaxLength = 32767;
            this.txtSendUnion.MultiLine = false;
            this.txtSendUnion.Name = "txtSendUnion";
            this.txtSendUnion.Size = new System.Drawing.Size(740, 21);
            this.txtSendUnion.TabIndex = 5;
            this.txtSendUnion.Tag = "11";
            this.txtSendUnion.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendUnion.UseSystemPasswordChar = false;
            this.txtSendUnion.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtUnion
            // 
            this.txtUnion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnion.Location = new System.Drawing.Point(3, 3);
            this.txtUnion.Name = "txtUnion";
            this.txtUnion.ReadOnly = true;
            this.txtUnion.Size = new System.Drawing.Size(740, 411);
            this.txtUnion.TabIndex = 4;
            this.txtUnion.Text = "";
            // 
            // tabAcademy
            // 
            this.tabAcademy.BackColor = System.Drawing.Color.White;
            this.tabAcademy.Controls.Add(this.txtAcademy);
            this.tabAcademy.Controls.Add(this.separator1);
            this.tabAcademy.Controls.Add(this.txtSendAcademy);
            this.tabAcademy.Location = new System.Drawing.Point(4, 25);
            this.tabAcademy.Name = "tabAcademy";
            this.tabAcademy.Padding = new System.Windows.Forms.Padding(3);
            this.tabAcademy.Size = new System.Drawing.Size(746, 448);
            this.tabAcademy.TabIndex = 4;
            this.tabAcademy.Text = "Academy";
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separator1.IsVertical = false;
            this.separator1.Location = new System.Drawing.Point(3, 414);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(740, 10);
            this.separator1.TabIndex = 4;
            this.separator1.Text = "separator1";
            // 
            // txtSendAcademy
            // 
            this.txtSendAcademy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSendAcademy.Location = new System.Drawing.Point(3, 424);
            this.txtSendAcademy.MaxLength = 32767;
            this.txtSendAcademy.MultiLine = false;
            this.txtSendAcademy.Name = "txtSendAcademy";
            this.txtSendAcademy.Size = new System.Drawing.Size(740, 21);
            this.txtSendAcademy.TabIndex = 3;
            this.txtSendAcademy.Tag = "16";
            this.txtSendAcademy.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSendAcademy.UseSystemPasswordChar = false;
            this.txtSendAcademy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MessagePreviewKeyDown);
            // 
            // txtAcademy
            // 
            this.txtAcademy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAcademy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAcademy.Location = new System.Drawing.Point(3, 3);
            this.txtAcademy.Name = "txtAcademy";
            this.txtAcademy.ReadOnly = true;
            this.txtAcademy.Size = new System.Drawing.Size(740, 411);
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
            this.tabGlobal.Size = new System.Drawing.Size(746, 448);
            this.tabGlobal.TabIndex = 5;
            this.tabGlobal.Text = "Global / Notice";
            // 
            // txtGlobal
            // 
            this.txtGlobal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGlobal.Location = new System.Drawing.Point(3, 3);
            this.txtGlobal.Name = "txtGlobal";
            this.txtGlobal.ReadOnly = true;
            this.txtGlobal.Size = new System.Drawing.Size(740, 442);
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
            this.tabStall.Size = new System.Drawing.Size(746, 448);
            this.tabStall.TabIndex = 5;
            this.tabStall.Text = "Stall";
            // 
            // txtStall
            // 
            this.txtStall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStall.Location = new System.Drawing.Point(3, 3);
            this.txtStall.Name = "txtStall";
            this.txtStall.ReadOnly = true;
            this.txtStall.Size = new System.Drawing.Size(740, 442);
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
            this.tabUnique.Size = new System.Drawing.Size(746, 448);
            this.tabUnique.TabIndex = 7;
            this.tabUnique.Text = "Unique";
            // 
            // UniqueText
            // 
            this.UniqueText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UniqueText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UniqueText.Location = new System.Drawing.Point(3, 3);
            this.UniqueText.Name = "UniqueText";
            this.UniqueText.ReadOnly = true;
            this.UniqueText.Size = new System.Drawing.Size(740, 442);
            this.UniqueText.TabIndex = 3;
            this.UniqueText.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.textBoxPrivateMsg);
            this.panel1.Controls.Add(this.txtRecievePrivate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 30);
            this.panel1.TabIndex = 8;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
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
            this.panel1.ResumeLayout(false);
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
        private SDUI.Controls.Separator separator1;
        private SDUI.Controls.Separator separator2;
        private SDUI.Controls.Separator separator3;
        private SDUI.Controls.Separator separator4;
        private SDUI.Controls.Separator separator5;
        private SDUI.Controls.Separator separator6;
        private System.Windows.Forms.RichTextBox txtPrivate;
        private SDUI.Controls.TextBox textBoxPrivateMsg;
        private System.Windows.Forms.Panel panel1;
    }
}
