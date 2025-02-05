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
            tabMain = new System.Windows.Forms.TabControl();
            tabAll = new System.Windows.Forms.TabPage();
            txtAll = new System.Windows.Forms.RichTextBox();
            separator6 = new System.Windows.Forms.Panel();
            txtSendAll = new System.Windows.Forms.TextBox();
            tabPrivate = new System.Windows.Forms.TabPage();
            txtPrivate = new System.Windows.Forms.RichTextBox();
            panel1 = new System.Windows.Forms.Panel();
            textBoxPrivateMsg = new System.Windows.Forms.TextBox();
            txtRecievePrivate = new System.Windows.Forms.TextBox();
            tabParty = new System.Windows.Forms.TabPage();
            txtParty = new System.Windows.Forms.RichTextBox();
            separator4 = new System.Windows.Forms.Panel();
            txtSendParty = new System.Windows.Forms.TextBox();
            tabGuild = new System.Windows.Forms.TabPage();
            txtGuild = new System.Windows.Forms.RichTextBox();
            separator3 = new System.Windows.Forms.Panel();
            txtSendGuild = new System.Windows.Forms.TextBox();
            tabUnion = new System.Windows.Forms.TabPage();
            txtUnion = new System.Windows.Forms.RichTextBox();
            separator2 = new System.Windows.Forms.Panel();
            txtSendUnion = new System.Windows.Forms.TextBox();
            tabAcademy = new System.Windows.Forms.TabPage();
            txtAcademy = new System.Windows.Forms.RichTextBox();
            separator1 = new System.Windows.Forms.Panel();
            txtSendAcademy = new System.Windows.Forms.TextBox();
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
            tabMain.ItemSize = new System.Drawing.Size(80, 24);
            tabMain.Location = new System.Drawing.Point(0, 0);
            tabMain.Margin = new System.Windows.Forms.Padding(4);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new System.Drawing.Size(942, 596);
            tabMain.TabIndex = 0;
            // 
            // tabAll
            // 
            tabAll.Controls.Add(txtAll);
            tabAll.Controls.Add(separator6);
            tabAll.Controls.Add(txtSendAll);
            tabAll.Location = new System.Drawing.Point(4, 28);
            tabAll.Margin = new System.Windows.Forms.Padding(4);
            tabAll.Name = "tabAll";
            tabAll.Padding = new System.Windows.Forms.Padding(4);
            tabAll.Size = new System.Drawing.Size(934, 564);
            tabAll.TabIndex = 0;
            tabAll.Text = "All";
            // 
            // txtAll
            // 
            txtAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtAll.Dock = System.Windows.Forms.DockStyle.Fill;
            txtAll.Location = new System.Drawing.Point(4, 4);
            txtAll.Margin = new System.Windows.Forms.Padding(4);
            txtAll.Name = "txtAll";
            txtAll.ReadOnly = true;
            txtAll.Size = new System.Drawing.Size(926, 517);
            txtAll.TabIndex = 2;
            txtAll.Text = "";
            // 
            // separator6
            // 
            separator6.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator6.Location = new System.Drawing.Point(4, 521);
            separator6.Margin = new System.Windows.Forms.Padding(4);
            separator6.Name = "separator6";
            separator6.Size = new System.Drawing.Size(926, 12);
            separator6.TabIndex = 4;
            separator6.Text = "separator6";
            // 
            // txtSendAll
            // 
            txtSendAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendAll.Location = new System.Drawing.Point(4, 533);
            txtSendAll.Margin = new System.Windows.Forms.Padding(4);
            txtSendAll.Name = "txtSendAll";
            txtSendAll.Size = new System.Drawing.Size(926, 27);
            txtSendAll.TabIndex = 3;
            txtSendAll.Tag = "1";
            txtSendAll.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabPrivate
            // 
            tabPrivate.Controls.Add(txtPrivate);
            tabPrivate.Controls.Add(panel1);
            tabPrivate.Location = new System.Drawing.Point(4, 28);
            tabPrivate.Margin = new System.Windows.Forms.Padding(4);
            tabPrivate.Name = "tabPrivate";
            tabPrivate.Padding = new System.Windows.Forms.Padding(4);
            tabPrivate.Size = new System.Drawing.Size(934, 564);
            tabPrivate.TabIndex = 1;
            tabPrivate.Text = "Private";
            // 
            // txtPrivate
            // 
            txtPrivate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtPrivate.Dock = System.Windows.Forms.DockStyle.Fill;
            txtPrivate.Location = new System.Drawing.Point(4, 4);
            txtPrivate.Margin = new System.Windows.Forms.Padding(4);
            txtPrivate.Name = "txtPrivate";
            txtPrivate.Size = new System.Drawing.Size(926, 509);
            txtPrivate.TabIndex = 7;
            txtPrivate.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxPrivateMsg);
            panel1.Controls.Add(txtRecievePrivate);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(4, 513);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(926, 47);
            panel1.TabIndex = 8;
            // 
            // textBoxPrivateMsg
            // 
            textBoxPrivateMsg.Location = new System.Drawing.Point(205, 8);
            textBoxPrivateMsg.Margin = new System.Windows.Forms.Padding(4);
            textBoxPrivateMsg.Name = "textBoxPrivateMsg";
            textBoxPrivateMsg.Size = new System.Drawing.Size(715, 27);
            textBoxPrivateMsg.TabIndex = 4;
            textBoxPrivateMsg.Tag = "2";
            textBoxPrivateMsg.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // txtRecievePrivate
            // 
            txtRecievePrivate.Location = new System.Drawing.Point(4, 8);
            txtRecievePrivate.Margin = new System.Windows.Forms.Padding(4);
            txtRecievePrivate.Name = "txtRecievePrivate";
            txtRecievePrivate.Size = new System.Drawing.Size(193, 27);
            txtRecievePrivate.TabIndex = 4;
            // 
            // tabParty
            // 
            tabParty.Controls.Add(txtParty);
            tabParty.Controls.Add(separator4);
            tabParty.Controls.Add(txtSendParty);
            tabParty.Location = new System.Drawing.Point(4, 28);
            tabParty.Margin = new System.Windows.Forms.Padding(4);
            tabParty.Name = "tabParty";
            tabParty.Padding = new System.Windows.Forms.Padding(4);
            tabParty.Size = new System.Drawing.Size(934, 564);
            tabParty.TabIndex = 2;
            tabParty.Text = "Party";
            // 
            // txtParty
            // 
            txtParty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtParty.Dock = System.Windows.Forms.DockStyle.Fill;
            txtParty.Location = new System.Drawing.Point(4, 4);
            txtParty.Margin = new System.Windows.Forms.Padding(4);
            txtParty.Name = "txtParty";
            txtParty.ReadOnly = true;
            txtParty.Size = new System.Drawing.Size(926, 517);
            txtParty.TabIndex = 2;
            txtParty.Text = "";
            // 
            // separator4
            // 
            separator4.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator4.Location = new System.Drawing.Point(4, 521);
            separator4.Margin = new System.Windows.Forms.Padding(4);
            separator4.Name = "separator4";
            separator4.Size = new System.Drawing.Size(926, 12);
            separator4.TabIndex = 4;
            separator4.Text = "separator4";
            // 
            // txtSendParty
            // 
            txtSendParty.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendParty.Location = new System.Drawing.Point(4, 533);
            txtSendParty.Margin = new System.Windows.Forms.Padding(4);
            txtSendParty.Name = "txtSendParty";
            txtSendParty.Size = new System.Drawing.Size(926, 27);
            txtSendParty.TabIndex = 3;
            txtSendParty.Tag = "4";
            txtSendParty.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabGuild
            // 
            tabGuild.Controls.Add(txtGuild);
            tabGuild.Controls.Add(separator3);
            tabGuild.Controls.Add(txtSendGuild);
            tabGuild.Location = new System.Drawing.Point(4, 28);
            tabGuild.Margin = new System.Windows.Forms.Padding(4);
            tabGuild.Name = "tabGuild";
            tabGuild.Padding = new System.Windows.Forms.Padding(4);
            tabGuild.Size = new System.Drawing.Size(934, 564);
            tabGuild.TabIndex = 3;
            tabGuild.Text = "Guild";
            // 
            // txtGuild
            // 
            txtGuild.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtGuild.Dock = System.Windows.Forms.DockStyle.Fill;
            txtGuild.Location = new System.Drawing.Point(4, 4);
            txtGuild.Margin = new System.Windows.Forms.Padding(4);
            txtGuild.Name = "txtGuild";
            txtGuild.ReadOnly = true;
            txtGuild.Size = new System.Drawing.Size(926, 517);
            txtGuild.TabIndex = 2;
            txtGuild.Text = "";
            // 
            // separator3
            // 
            separator3.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator3.Location = new System.Drawing.Point(4, 521);
            separator3.Margin = new System.Windows.Forms.Padding(4);
            separator3.Name = "separator3";
            separator3.Size = new System.Drawing.Size(926, 12);
            separator3.TabIndex = 4;
            separator3.Text = "separator3";
            // 
            // txtSendGuild
            // 
            txtSendGuild.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendGuild.Location = new System.Drawing.Point(4, 533);
            txtSendGuild.Margin = new System.Windows.Forms.Padding(4);
            txtSendGuild.Name = "txtSendGuild";
            txtSendGuild.Size = new System.Drawing.Size(926, 27);
            txtSendGuild.TabIndex = 3;
            txtSendGuild.Tag = "5";
            txtSendGuild.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabUnion
            // 
            tabUnion.Controls.Add(txtUnion);
            tabUnion.Controls.Add(separator2);
            tabUnion.Controls.Add(txtSendUnion);
            tabUnion.Location = new System.Drawing.Point(4, 28);
            tabUnion.Margin = new System.Windows.Forms.Padding(4);
            tabUnion.Name = "tabUnion";
            tabUnion.Padding = new System.Windows.Forms.Padding(4);
            tabUnion.Size = new System.Drawing.Size(934, 564);
            tabUnion.TabIndex = 6;
            tabUnion.Text = "Union";
            // 
            // txtUnion
            // 
            txtUnion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtUnion.Dock = System.Windows.Forms.DockStyle.Fill;
            txtUnion.Location = new System.Drawing.Point(4, 4);
            txtUnion.Margin = new System.Windows.Forms.Padding(4);
            txtUnion.Name = "txtUnion";
            txtUnion.ReadOnly = true;
            txtUnion.Size = new System.Drawing.Size(926, 517);
            txtUnion.TabIndex = 4;
            txtUnion.Text = "";
            // 
            // separator2
            // 
            separator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator2.Location = new System.Drawing.Point(4, 521);
            separator2.Margin = new System.Windows.Forms.Padding(4);
            separator2.Name = "separator2";
            separator2.Size = new System.Drawing.Size(926, 12);
            separator2.TabIndex = 6;
            separator2.Text = "separator2";
            // 
            // txtSendUnion
            // 
            txtSendUnion.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendUnion.Location = new System.Drawing.Point(4, 533);
            txtSendUnion.Margin = new System.Windows.Forms.Padding(4);
            txtSendUnion.Name = "txtSendUnion";
            txtSendUnion.Size = new System.Drawing.Size(926, 27);
            txtSendUnion.TabIndex = 5;
            txtSendUnion.Tag = "11";
            txtSendUnion.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabAcademy
            // 
            tabAcademy.Controls.Add(txtAcademy);
            tabAcademy.Controls.Add(separator1);
            tabAcademy.Controls.Add(txtSendAcademy);
            tabAcademy.Location = new System.Drawing.Point(4, 28);
            tabAcademy.Margin = new System.Windows.Forms.Padding(4);
            tabAcademy.Name = "tabAcademy";
            tabAcademy.Padding = new System.Windows.Forms.Padding(4);
            tabAcademy.Size = new System.Drawing.Size(934, 564);
            tabAcademy.TabIndex = 4;
            tabAcademy.Text = "Academy";
            // 
            // txtAcademy
            // 
            txtAcademy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtAcademy.Dock = System.Windows.Forms.DockStyle.Fill;
            txtAcademy.Location = new System.Drawing.Point(4, 4);
            txtAcademy.Margin = new System.Windows.Forms.Padding(4);
            txtAcademy.Name = "txtAcademy";
            txtAcademy.ReadOnly = true;
            txtAcademy.Size = new System.Drawing.Size(926, 517);
            txtAcademy.TabIndex = 2;
            txtAcademy.Text = "";
            // 
            // separator1
            // 
            separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            separator1.Location = new System.Drawing.Point(4, 521);
            separator1.Margin = new System.Windows.Forms.Padding(4);
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(926, 12);
            separator1.TabIndex = 4;
            separator1.Text = "separator1";
            // 
            // txtSendAcademy
            // 
            txtSendAcademy.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtSendAcademy.Location = new System.Drawing.Point(4, 533);
            txtSendAcademy.Margin = new System.Windows.Forms.Padding(4);
            txtSendAcademy.Name = "txtSendAcademy";
            txtSendAcademy.Size = new System.Drawing.Size(926, 27);
            txtSendAcademy.TabIndex = 3;
            txtSendAcademy.Tag = "16";
            txtSendAcademy.PreviewKeyDown += MessagePreviewKeyDown;
            // 
            // tabGlobal
            // 
            tabGlobal.Controls.Add(txtGlobal);
            tabGlobal.Location = new System.Drawing.Point(4, 28);
            tabGlobal.Margin = new System.Windows.Forms.Padding(4);
            tabGlobal.Name = "tabGlobal";
            tabGlobal.Padding = new System.Windows.Forms.Padding(4);
            tabGlobal.Size = new System.Drawing.Size(934, 564);
            tabGlobal.TabIndex = 5;
            tabGlobal.Text = "Global / Notice";
            // 
            // txtGlobal
            // 
            txtGlobal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            txtGlobal.Location = new System.Drawing.Point(4, 4);
            txtGlobal.Margin = new System.Windows.Forms.Padding(4);
            txtGlobal.Name = "txtGlobal";
            txtGlobal.ReadOnly = true;
            txtGlobal.Size = new System.Drawing.Size(926, 556);
            txtGlobal.TabIndex = 2;
            txtGlobal.Text = "";
            // 
            // tabStall
            // 
            tabStall.Controls.Add(txtStall);
            tabStall.Location = new System.Drawing.Point(4, 28);
            tabStall.Margin = new System.Windows.Forms.Padding(4);
            tabStall.Name = "tabStall";
            tabStall.Padding = new System.Windows.Forms.Padding(4);
            tabStall.Size = new System.Drawing.Size(934, 564);
            tabStall.TabIndex = 5;
            tabStall.Text = "Stall";
            // 
            // txtStall
            // 
            txtStall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtStall.Dock = System.Windows.Forms.DockStyle.Fill;
            txtStall.Location = new System.Drawing.Point(4, 4);
            txtStall.Margin = new System.Windows.Forms.Padding(4);
            txtStall.Name = "txtStall";
            txtStall.ReadOnly = true;
            txtStall.Size = new System.Drawing.Size(926, 556);
            txtStall.TabIndex = 2;
            txtStall.Text = "";
            // 
            // tabUnique
            // 
            tabUnique.Controls.Add(UniqueText);
            tabUnique.Location = new System.Drawing.Point(4, 28);
            tabUnique.Margin = new System.Windows.Forms.Padding(4);
            tabUnique.Name = "tabUnique";
            tabUnique.Padding = new System.Windows.Forms.Padding(4);
            tabUnique.Size = new System.Drawing.Size(934, 564);
            tabUnique.TabIndex = 7;
            tabUnique.Text = "Unique";
            // 
            // UniqueText
            // 
            UniqueText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            UniqueText.Dock = System.Windows.Forms.DockStyle.Fill;
            UniqueText.Location = new System.Drawing.Point(4, 4);
            UniqueText.Margin = new System.Windows.Forms.Padding(4);
            UniqueText.Name = "UniqueText";
            UniqueText.ReadOnly = true;
            UniqueText.Size = new System.Drawing.Size(926, 556);
            UniqueText.TabIndex = 3;
            UniqueText.Text = "";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tabMain);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Main";
            Size = new System.Drawing.Size(942, 596);
            tabMain.ResumeLayout(false);
            tabAll.ResumeLayout(false);
            tabAll.PerformLayout();
            tabPrivate.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabParty.ResumeLayout(false);
            tabParty.PerformLayout();
            tabGuild.ResumeLayout(false);
            tabGuild.PerformLayout();
            tabUnion.ResumeLayout(false);
            tabUnion.PerformLayout();
            tabAcademy.ResumeLayout(false);
            tabAcademy.PerformLayout();
            tabGlobal.ResumeLayout(false);
            tabStall.ResumeLayout(false);
            tabUnique.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabPrivate;
        private System.Windows.Forms.TabPage tabParty;
        private System.Windows.Forms.TabPage tabGuild;
        private System.Windows.Forms.TabPage tabAcademy;
        private System.Windows.Forms.TabPage tabGlobal;
        private System.Windows.Forms.TabPage tabStall;
        private System.Windows.Forms.TextBox txtSendAll;
        private System.Windows.Forms.RichTextBox txtAll;
        private System.Windows.Forms.TextBox txtSendParty;
        private System.Windows.Forms.RichTextBox txtParty;
        private System.Windows.Forms.TextBox txtSendGuild;
        private System.Windows.Forms.RichTextBox txtGuild;
        private System.Windows.Forms.TextBox txtSendAcademy;
        private System.Windows.Forms.RichTextBox txtAcademy;
        private System.Windows.Forms.RichTextBox txtGlobal;
        private System.Windows.Forms.RichTextBox txtStall;
        private System.Windows.Forms.TextBox txtRecievePrivate;
        private System.Windows.Forms.TabPage tabUnion;
        private System.Windows.Forms.TextBox txtSendUnion;
        private System.Windows.Forms.RichTextBox txtUnion;
        private System.Windows.Forms.TabPage tabUnique;
        internal System.Windows.Forms.RichTextBox UniqueText;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.Panel separator3;
        private System.Windows.Forms.Panel separator4;
        private System.Windows.Forms.Panel separator6;
        private System.Windows.Forms.RichTextBox txtPrivate;
        private System.Windows.Forms.TextBox textBoxPrivateMsg;
        private System.Windows.Forms.Panel panel1;
    }
}
