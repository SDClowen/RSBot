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
            tabMain = new SDUI.Controls.TabControl();
            tabAll = new System.Windows.Forms.TabPage();
            txtAll = new System.Windows.Forms.RichTextBox();
            separator6 = new SDUI.Controls.Separator();
            txtSendAll = new SDUI.Controls.TextBox();
            tabPrivate = new System.Windows.Forms.TabPage();
            txtPrivate = new System.Windows.Forms.RichTextBox();
            separator5 = new SDUI.Controls.Separator();
            panel1 = new System.Windows.Forms.Panel();
            textBoxPrivateMsg = new SDUI.Controls.TextBox();
            txtRecievePrivate = new SDUI.Controls.TextBox();
            tabParty = new System.Windows.Forms.TabPage();
            txtParty = new System.Windows.Forms.RichTextBox();
            separator4 = new SDUI.Controls.Separator();
            txtSendParty = new SDUI.Controls.TextBox();
            tabGuild = new System.Windows.Forms.TabPage();
            txtGuild = new System.Windows.Forms.RichTextBox();
            separator3 = new SDUI.Controls.Separator();
            txtSendGuild = new SDUI.Controls.TextBox();
            tabUnion = new System.Windows.Forms.TabPage();
            txtUnion = new System.Windows.Forms.RichTextBox();
            separator2 = new SDUI.Controls.Separator();
            txtSendUnion = new SDUI.Controls.TextBox();
            tabAcademy = new System.Windows.Forms.TabPage();
            txtAcademy = new System.Windows.Forms.RichTextBox();
            separator1 = new SDUI.Controls.Separator();
            txtSendAcademy = new SDUI.Controls.TextBox();
            tabGlobal = new System.Windows.Forms.TabPage();
            txtGlobal = new System.Windows.Forms.RichTextBox();
            tabStall = new System.Windows.Forms.TabPage();
            txtStall = new System.Windows.Forms.RichTextBox();
            tabUnique = new System.Windows.Forms.TabPage();
            UniqueText = new System.Windows.Forms.RichTextBox();
            tabMain.SuspendLayout();
            tabAll.SuspendLayout();
            tabPrivate.SuspendLayout();
            panel1.SuspendLayout();
            tabParty.SuspendLayout();
            tabGuild.SuspendLayout();
            tabUnion.SuspendLayout();
            tabAcademy.SuspendLayout();
            tabGlobal.SuspendLayout();
            tabStall.SuspendLayout();
            tabUnique.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Border = new System.Windows.Forms.Padding(1);
            tabMain.Controls.Add(tabAll);
            tabMain.Controls.Add(tabPrivate);
            tabMain.Controls.Add(tabParty);
            tabMain.Controls.Add(tabGuild);
            tabMain.Controls.Add(tabUnion);
            tabMain.Controls.Add(tabAcademy);
            tabMain.Controls.Add(tabGlobal);
            tabMain.Controls.Add(tabStall);
            tabMain.Controls.Add(tabUnique);
            tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabMain.HideTabArea = false;
            tabMain.Location = new System.Drawing.Point(0, 0);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new System.Drawing.Size(754, 477);
            tabMain.TabIndex = 0;
            // 
            // tabAll
            // 
            tabAll.BackColor = System.Drawing.Color.White;
            tabAll.Controls.Add(txtAll);
            tabAll.Controls.Add(separator6);
            tabAll.Controls.Add(txtSendAll);
            tabAll.Location = new System.Drawing.Point(4, 24);
            tabAll.Name = "tabAll";
            tabAll.Padding = new System.Windows.Forms.Padding(3);
            tabAll.Size = new System.Drawing.Size(746, 449);
            tabAll.TabIndex = 0;
            tabAll.Text = "All";
            // 
            // txtAll
            // 
            txtAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtAll.Dock = System.Windows.Forms.DockStyle.Fill;
            txtAll.Location = new System.Drawing.Point(3, 3);
            txtAll.Name = "txtAll";
            txtAll.ReadOnly = true;
            txtAll.Size = new System.Drawing.Size(740, 412);
            txtAll.TabIndex = 2;
            txtAll.Text = "";
            // 
            // separator6
            // 
            separator6.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator6.IsVertical = false;
            separator6.Location = new System.Drawing.Point(3, 415);
            separator6.Name = "separator6";
            separator6.Size = new System.Drawing.Size(740, 10);
            separator6.TabIndex = 4;
            separator6.Text = "separator6";
            // 
            // txtSendAll
            // 
            txtSendAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendAll.Location = new System.Drawing.Point(3, 425);
            txtSendAll.MaxLength = 32767;
            txtSendAll.MultiLine = false;
            txtSendAll.Name = "txtSendAll";
            txtSendAll.Radius = 2;
            txtSendAll.Size = new System.Drawing.Size(740, 21);
            txtSendAll.TabIndex = 3;
            txtSendAll.Tag = "1";
            txtSendAll.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtSendAll.UseSystemPasswordChar = false;
            txtSendAll.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabPrivate
            // 
            tabPrivate.BackColor = System.Drawing.Color.White;
            tabPrivate.Controls.Add(txtPrivate);
            tabPrivate.Controls.Add(separator5);
            tabPrivate.Controls.Add(panel1);
            tabPrivate.Location = new System.Drawing.Point(4, 24);
            tabPrivate.Name = "tabPrivate";
            tabPrivate.Padding = new System.Windows.Forms.Padding(3);
            tabPrivate.Size = new System.Drawing.Size(746, 449);
            tabPrivate.TabIndex = 1;
            tabPrivate.Text = "Private";
            // 
            // txtPrivate
            // 
            txtPrivate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtPrivate.Dock = System.Windows.Forms.DockStyle.Fill;
            txtPrivate.Location = new System.Drawing.Point(3, 3);
            txtPrivate.Name = "txtPrivate";
            txtPrivate.Size = new System.Drawing.Size(740, 403);
            txtPrivate.TabIndex = 7;
            txtPrivate.Text = "";
            // 
            // separator5
            // 
            separator5.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator5.IsVertical = false;
            separator5.Location = new System.Drawing.Point(3, 406);
            separator5.Name = "separator5";
            separator5.Size = new System.Drawing.Size(740, 10);
            separator5.TabIndex = 6;
            separator5.Text = "separator5";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(textBoxPrivateMsg);
            panel1.Controls.Add(txtRecievePrivate);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(3, 416);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(740, 30);
            panel1.TabIndex = 8;
            // 
            // textBoxPrivateMsg
            // 
            textBoxPrivateMsg.Location = new System.Drawing.Point(164, 3);
            textBoxPrivateMsg.MaxLength = 32767;
            textBoxPrivateMsg.MultiLine = false;
            textBoxPrivateMsg.Name = "textBoxPrivateMsg";
            textBoxPrivateMsg.Radius = 2;
            textBoxPrivateMsg.Size = new System.Drawing.Size(573, 21);
            textBoxPrivateMsg.TabIndex = 4;
            textBoxPrivateMsg.Tag = "2";
            textBoxPrivateMsg.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxPrivateMsg.UseSystemPasswordChar = false;
            textBoxPrivateMsg.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // txtRecievePrivate
            // 
            txtRecievePrivate.Location = new System.Drawing.Point(3, 3);
            txtRecievePrivate.MaxLength = 32767;
            txtRecievePrivate.MultiLine = false;
            txtRecievePrivate.Name = "txtRecievePrivate";
            txtRecievePrivate.Radius = 2;
            txtRecievePrivate.Size = new System.Drawing.Size(155, 21);
            txtRecievePrivate.TabIndex = 4;
            txtRecievePrivate.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtRecievePrivate.UseSystemPasswordChar = false;
            // 
            // tabParty
            // 
            tabParty.BackColor = System.Drawing.Color.White;
            tabParty.Controls.Add(txtParty);
            tabParty.Controls.Add(separator4);
            tabParty.Controls.Add(txtSendParty);
            tabParty.Location = new System.Drawing.Point(4, 24);
            tabParty.Name = "tabParty";
            tabParty.Padding = new System.Windows.Forms.Padding(3);
            tabParty.Size = new System.Drawing.Size(746, 449);
            tabParty.TabIndex = 2;
            tabParty.Text = "Party";
            // 
            // txtParty
            // 
            txtParty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtParty.Dock = System.Windows.Forms.DockStyle.Fill;
            txtParty.Location = new System.Drawing.Point(3, 3);
            txtParty.Name = "txtParty";
            txtParty.ReadOnly = true;
            txtParty.Size = new System.Drawing.Size(740, 412);
            txtParty.TabIndex = 2;
            txtParty.Text = "";
            // 
            // separator4
            // 
            separator4.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator4.IsVertical = false;
            separator4.Location = new System.Drawing.Point(3, 415);
            separator4.Name = "separator4";
            separator4.Size = new System.Drawing.Size(740, 10);
            separator4.TabIndex = 4;
            separator4.Text = "separator4";
            // 
            // txtSendParty
            // 
            txtSendParty.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendParty.Location = new System.Drawing.Point(3, 425);
            txtSendParty.MaxLength = 32767;
            txtSendParty.MultiLine = false;
            txtSendParty.Name = "txtSendParty";
            txtSendParty.Radius = 2;
            txtSendParty.Size = new System.Drawing.Size(740, 21);
            txtSendParty.TabIndex = 3;
            txtSendParty.Tag = "4";
            txtSendParty.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtSendParty.UseSystemPasswordChar = false;
            txtSendParty.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabGuild
            // 
            tabGuild.BackColor = System.Drawing.Color.White;
            tabGuild.Controls.Add(txtGuild);
            tabGuild.Controls.Add(separator3);
            tabGuild.Controls.Add(txtSendGuild);
            tabGuild.Location = new System.Drawing.Point(4, 24);
            tabGuild.Name = "tabGuild";
            tabGuild.Padding = new System.Windows.Forms.Padding(3);
            tabGuild.Size = new System.Drawing.Size(746, 449);
            tabGuild.TabIndex = 3;
            tabGuild.Text = "Guild";
            // 
            // txtGuild
            // 
            txtGuild.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtGuild.Dock = System.Windows.Forms.DockStyle.Fill;
            txtGuild.Location = new System.Drawing.Point(3, 3);
            txtGuild.Name = "txtGuild";
            txtGuild.ReadOnly = true;
            txtGuild.Size = new System.Drawing.Size(740, 412);
            txtGuild.TabIndex = 2;
            txtGuild.Text = "";
            // 
            // separator3
            // 
            separator3.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator3.IsVertical = false;
            separator3.Location = new System.Drawing.Point(3, 415);
            separator3.Name = "separator3";
            separator3.Size = new System.Drawing.Size(740, 10);
            separator3.TabIndex = 4;
            separator3.Text = "separator3";
            // 
            // txtSendGuild
            // 
            txtSendGuild.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendGuild.Location = new System.Drawing.Point(3, 425);
            txtSendGuild.MaxLength = 32767;
            txtSendGuild.MultiLine = false;
            txtSendGuild.Name = "txtSendGuild";
            txtSendGuild.Radius = 2;
            txtSendGuild.Size = new System.Drawing.Size(740, 21);
            txtSendGuild.TabIndex = 3;
            txtSendGuild.Tag = "5";
            txtSendGuild.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtSendGuild.UseSystemPasswordChar = false;
            txtSendGuild.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabUnion
            // 
            tabUnion.BackColor = System.Drawing.Color.White;
            tabUnion.Controls.Add(txtUnion);
            tabUnion.Controls.Add(separator2);
            tabUnion.Controls.Add(txtSendUnion);
            tabUnion.Location = new System.Drawing.Point(4, 24);
            tabUnion.Name = "tabUnion";
            tabUnion.Padding = new System.Windows.Forms.Padding(3);
            tabUnion.Size = new System.Drawing.Size(746, 449);
            tabUnion.TabIndex = 6;
            tabUnion.Text = "Union";
            // 
            // txtUnion
            // 
            txtUnion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtUnion.Dock = System.Windows.Forms.DockStyle.Fill;
            txtUnion.Location = new System.Drawing.Point(3, 3);
            txtUnion.Name = "txtUnion";
            txtUnion.ReadOnly = true;
            txtUnion.Size = new System.Drawing.Size(740, 412);
            txtUnion.TabIndex = 4;
            txtUnion.Text = "";
            // 
            // separator2
            // 
            separator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator2.IsVertical = false;
            separator2.Location = new System.Drawing.Point(3, 415);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(740, 10);
            separator2.TabIndex = 6;
            separator2.Text = "separator2";
            // 
            // txtSendUnion
            // 
            txtSendUnion.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendUnion.Location = new System.Drawing.Point(3, 425);
            txtSendUnion.MaxLength = 32767;
            txtSendUnion.MultiLine = false;
            txtSendUnion.Name = "txtSendUnion";
            txtSendUnion.Radius = 2;
            txtSendUnion.Size = new System.Drawing.Size(740, 21);
            txtSendUnion.TabIndex = 5;
            txtSendUnion.Tag = "11";
            txtSendUnion.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtSendUnion.UseSystemPasswordChar = false;
            txtSendUnion.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabAcademy
            // 
            tabAcademy.BackColor = System.Drawing.Color.White;
            tabAcademy.Controls.Add(txtAcademy);
            tabAcademy.Controls.Add(separator1);
            tabAcademy.Controls.Add(txtSendAcademy);
            tabAcademy.Location = new System.Drawing.Point(4, 25);
            tabAcademy.Name = "tabAcademy";
            tabAcademy.Padding = new System.Windows.Forms.Padding(3);
            tabAcademy.Size = new System.Drawing.Size(746, 448);
            tabAcademy.TabIndex = 4;
            tabAcademy.Text = "Academy";
            // 
            // txtAcademy
            // 
            txtAcademy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtAcademy.Dock = System.Windows.Forms.DockStyle.Fill;
            txtAcademy.Location = new System.Drawing.Point(3, 3);
            txtAcademy.Name = "txtAcademy";
            txtAcademy.ReadOnly = true;
            txtAcademy.Size = new System.Drawing.Size(740, 411);
            txtAcademy.TabIndex = 2;
            txtAcademy.Text = "";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator1.IsVertical = false;
            separator1.Location = new System.Drawing.Point(3, 414);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(740, 10);
            separator1.TabIndex = 4;
            separator1.Text = "separator1";
            // 
            // txtSendAcademy
            // 
            txtSendAcademy.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendAcademy.Location = new System.Drawing.Point(3, 424);
            txtSendAcademy.MaxLength = 32767;
            txtSendAcademy.MultiLine = false;
            txtSendAcademy.Name = "txtSendAcademy";
            txtSendAcademy.Radius = 2;
            txtSendAcademy.Size = new System.Drawing.Size(740, 21);
            txtSendAcademy.TabIndex = 3;
            txtSendAcademy.Tag = "16";
            txtSendAcademy.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            txtSendAcademy.UseSystemPasswordChar = false;
            txtSendAcademy.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabGlobal
            // 
            tabGlobal.BackColor = System.Drawing.Color.White;
            tabGlobal.Controls.Add(txtGlobal);
            tabGlobal.Location = new System.Drawing.Point(4, 25);
            tabGlobal.Name = "tabGlobal";
            tabGlobal.Padding = new System.Windows.Forms.Padding(3);
            tabGlobal.Size = new System.Drawing.Size(746, 448);
            tabGlobal.TabIndex = 5;
            tabGlobal.Text = "Global / Notice";
            // 
            // txtGlobal
            // 
            txtGlobal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            txtGlobal.Location = new System.Drawing.Point(3, 3);
            txtGlobal.Name = "txtGlobal";
            txtGlobal.ReadOnly = true;
            txtGlobal.Size = new System.Drawing.Size(740, 442);
            txtGlobal.TabIndex = 2;
            txtGlobal.Text = "";
            // 
            // tabStall
            // 
            tabStall.BackColor = System.Drawing.Color.White;
            tabStall.Controls.Add(txtStall);
            tabStall.Location = new System.Drawing.Point(4, 24);
            tabStall.Name = "tabStall";
            tabStall.Padding = new System.Windows.Forms.Padding(3);
            tabStall.Size = new System.Drawing.Size(746, 449);
            tabStall.TabIndex = 5;
            tabStall.Text = "Stall";
            // 
            // txtStall
            // 
            txtStall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtStall.Dock = System.Windows.Forms.DockStyle.Fill;
            txtStall.Location = new System.Drawing.Point(3, 3);
            txtStall.Name = "txtStall";
            txtStall.ReadOnly = true;
            txtStall.Size = new System.Drawing.Size(740, 443);
            txtStall.TabIndex = 2;
            txtStall.Text = "";
            // 
            // tabUnique
            // 
            tabUnique.BackColor = System.Drawing.Color.White;
            tabUnique.Controls.Add(UniqueText);
            tabUnique.Location = new System.Drawing.Point(4, 24);
            tabUnique.Name = "tabUnique";
            tabUnique.Padding = new System.Windows.Forms.Padding(3);
            tabUnique.Size = new System.Drawing.Size(746, 449);
            tabUnique.TabIndex = 7;
            tabUnique.Text = "Unique";
            // 
            // UniqueText
            // 
            UniqueText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            UniqueText.Dock = System.Windows.Forms.DockStyle.Fill;
            UniqueText.Location = new System.Drawing.Point(3, 3);
            UniqueText.Name = "UniqueText";
            UniqueText.ReadOnly = true;
            UniqueText.Size = new System.Drawing.Size(740, 443);
            UniqueText.TabIndex = 3;
            UniqueText.Text = "";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tabMain);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "Main";
            Size = new System.Drawing.Size(754, 477);
            tabMain.ResumeLayout(false);
            tabAll.ResumeLayout(false);
            tabPrivate.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tabParty.ResumeLayout(false);
            tabGuild.ResumeLayout(false);
            tabUnion.ResumeLayout(false);
            tabAcademy.ResumeLayout(false);
            tabGlobal.ResumeLayout(false);
            tabStall.ResumeLayout(false);
            tabUnique.ResumeLayout(false);
            ResumeLayout(false);
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
