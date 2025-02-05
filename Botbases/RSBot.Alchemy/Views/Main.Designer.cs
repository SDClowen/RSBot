using System.Drawing;
using System.Windows.Forms;


using ComboBox = System.Windows.Forms.ComboBox;
using GroupBox = System.Windows.Forms.GroupBox;
using Label = System.Windows.Forms.Label;
using ListView = System.Windows.Forms.ListView;
using TabControl = System.Windows.Forms.TabControl;
using Panel = System.Windows.Forms.Panel;
using RadioButton = System.Windows.Forms.RadioButton;

namespace RSBot.Alchemy.Views
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupItem = new GroupBox();
            lblOptLevel = new Label();
            tabControlItemInfo = new TabControl();
            tabMagicOptions = new TabPage();
            listMagicOptions = new ListBox();
            tabPageAttributes = new TabPage();
            listAttributes = new ListBox();
            comboItem = new ComboBox();
            lblOptLevelText = new Label();
            lblItemSelection = new Label();
            lblDegree = new Label();
            lblDegreeText = new Label();
            linkRefreshItemList = new Label();
            lvLog = new ListView();
            colItem = new ColumnHeader();
            colResult = new ColumnHeader();
            panelSettingsGroup = new Panel();
            panelSettings = new Panel();
            panel2 = new Panel();
            radioAttributes = new RadioButton();
            radioMagicOptions = new RadioButton();
            radioEnhance = new RadioButton();
            groupItem.SuspendLayout();
            tabControlItemInfo.SuspendLayout();
            tabMagicOptions.SuspendLayout();
            tabPageAttributes.SuspendLayout();
            panelSettingsGroup.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // groupItem
            // 
            
            groupItem.Controls.Add(lblOptLevel);
            groupItem.Controls.Add(tabControlItemInfo);
            groupItem.Controls.Add(comboItem);
            groupItem.Controls.Add(lblOptLevelText);
            groupItem.Controls.Add(lblItemSelection);
            groupItem.Controls.Add(lblDegree);
            groupItem.Controls.Add(lblDegreeText);
            groupItem.Controls.Add(linkRefreshItemList);
            groupItem.Location = new Point(16, 14);
            groupItem.Margin = new Padding(4, 3, 4, 3);
            groupItem.Name = "groupItem";
            groupItem.Padding = new Padding(4, 12, 4, 3);
            
            
            groupItem.Size = new Size(322, 331);
            groupItem.TabIndex = 0;
            groupItem.TabStop = false;
            groupItem.Text = "Item";
            // 
            // lblOptLevel
            // 
            
            lblOptLevel.AutoSize = true;
            lblOptLevel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            
            
            lblOptLevel.Location = new Point(118, 102);
            lblOptLevel.Margin = new Padding(4, 0, 4, 0);
            lblOptLevel.Name = "lblOptLevel";
            lblOptLevel.Size = new Size(108, 13);
            lblOptLevel.TabIndex = 1;
            lblOptLevel.Text = "<no item selected>";
            // 
            // tabControlItemInfo
            // 
            tabControlItemInfo.Controls.Add(tabMagicOptions);
            tabControlItemInfo.Controls.Add(tabPageAttributes);
            tabControlItemInfo.ItemSize = new Size(80, 24);
            tabControlItemInfo.Location = new Point(9, 146);
            tabControlItemInfo.Margin = new Padding(4, 3, 4, 3);
            tabControlItemInfo.Name = "tabControlItemInfo";
            tabControlItemInfo.SelectedIndex = 0;
            tabControlItemInfo.Size = new Size(304, 179);
            tabControlItemInfo.TabIndex = 5;
            // 
            // tabMagicOptions
            // 
            
            tabMagicOptions.Controls.Add(listMagicOptions);
            tabMagicOptions.Location = new Point(4, 28);
            tabMagicOptions.Margin = new Padding(4, 3, 4, 3);
            tabMagicOptions.Name = "tabMagicOptions";
            tabMagicOptions.Padding = new Padding(4, 3, 4, 3);
            tabMagicOptions.Size = new Size(296, 147);
            tabMagicOptions.TabIndex = 0;
            tabMagicOptions.Text = "Blues";
            // 
            // listMagicOptions
            // 
            listMagicOptions.BorderStyle = BorderStyle.None;
            listMagicOptions.Dock = DockStyle.Fill;
            listMagicOptions.ItemHeight = 15;
            listMagicOptions.Location = new Point(4, 3);
            listMagicOptions.Margin = new Padding(4, 3, 4, 3);
            listMagicOptions.Name = "listMagicOptions";
            listMagicOptions.Size = new Size(288, 141);
            listMagicOptions.TabIndex = 2;
            // 
            // tabPageAttributes
            // 
            
            tabPageAttributes.Controls.Add(listAttributes);
            tabPageAttributes.Location = new Point(4, 28);
            tabPageAttributes.Margin = new Padding(4, 3, 4, 3);
            tabPageAttributes.Name = "tabPageAttributes";
            tabPageAttributes.Padding = new Padding(4, 3, 4, 3);
            tabPageAttributes.Size = new Size(296, 147);
            tabPageAttributes.TabIndex = 1;
            tabPageAttributes.Text = "Stats";
            // 
            // listAttributes
            // 
            listAttributes.BorderStyle = BorderStyle.None;
            listAttributes.Dock = DockStyle.Fill;
            listAttributes.ItemHeight = 15;
            listAttributes.Location = new Point(4, 3);
            listAttributes.Margin = new Padding(4, 3, 4, 3);
            listAttributes.Name = "listAttributes";
            listAttributes.Size = new Size(288, 141);
            listAttributes.TabIndex = 3;
            // 
            // comboItem
            // 
            comboItem.DrawMode = DrawMode.Normal;
            comboItem.DropDownHeight = 100;
            comboItem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboItem.FormattingEnabled = true;
            comboItem.IntegralHeight = false;
            comboItem.ItemHeight = 17;
            comboItem.Location = new Point(21, 47);
            comboItem.Margin = new Padding(4, 3, 4, 3);
            comboItem.Name = "comboItem";
            
            
            comboItem.Size = new Size(255, 23);
            comboItem.TabIndex = 4;
            comboItem.SelectedIndexChanged += comboItem_SelectedIndexChanged;
            // 
            // lblOptLevelText
            // 
            
            lblOptLevelText.AutoSize = true;
            
            
            lblOptLevelText.Location = new Point(18, 102);
            lblOptLevelText.Margin = new Padding(4, 0, 4, 0);
            lblOptLevelText.Name = "lblOptLevelText";
            lblOptLevelText.Size = new Size(83, 15);
            lblOptLevelText.TabIndex = 0;
            lblOptLevelText.Text = "&Enhancement:";
            // 
            // lblItemSelection
            // 
            
            lblItemSelection.AutoSize = true;
            
            
            lblItemSelection.Location = new Point(18, 29);
            lblItemSelection.Margin = new Padding(4, 0, 4, 0);
            lblItemSelection.Name = "lblItemSelection";
            lblItemSelection.Size = new Size(34, 15);
            lblItemSelection.TabIndex = 3;
            lblItemSelection.Text = "Item:";
            // 
            // lblDegree
            // 
            
            lblDegree.AutoSize = true;
            lblDegree.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            
            
            lblDegree.Location = new Point(118, 75);
            lblDegree.Margin = new Padding(4, 0, 4, 0);
            lblDegree.Name = "lblDegree";
            lblDegree.Size = new Size(108, 13);
            lblDegree.TabIndex = 1;
            lblDegree.Text = "<no item selected>";
            // 
            // lblDegreeText
            // 
            
            lblDegreeText.AutoSize = true;
            
            
            lblDegreeText.Location = new Point(18, 75);
            lblDegreeText.Margin = new Padding(4, 0, 4, 0);
            lblDegreeText.Name = "lblDegreeText";
            lblDegreeText.Size = new Size(47, 15);
            lblDegreeText.TabIndex = 0;
            lblDegreeText.Text = "&Degree:";
            // 
            // linkRefreshItemList
            // 
            
            linkRefreshItemList.AutoSize = true;
            linkRefreshItemList.Cursor = Cursors.Hand;
            linkRefreshItemList.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            
            
            linkRefreshItemList.Location = new Point(272, 39);
            linkRefreshItemList.Margin = new Padding(4, 0, 4, 0);
            linkRefreshItemList.Name = "linkRefreshItemList";
            linkRefreshItemList.Size = new Size(34, 30);
            linkRefreshItemList.TabIndex = 5;
            linkRefreshItemList.Text = "🗘";
            linkRefreshItemList.Click += linkRefreshItemList_Click;
            // 
            // lvLog
            // 
            
            lvLog.Columns.AddRange(new ColumnHeader[] { colItem, colResult });
            
            lvLog.FullRowSelect = true;
            lvLog.Location = new Point(16, 351);
            lvLog.Margin = new Padding(4, 3, 4, 3);
            lvLog.Name = "lvLog";
            lvLog.Size = new Size(759, 137);
            lvLog.TabIndex = 1;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = View.Details;
            // 
            // colItem
            // 
            colItem.Text = "Item";
            colItem.Width = 228;
            // 
            // colResult
            // 
            colResult.Text = "Message";
            colResult.Width = 500;
            // 
            // panelSettingsGroup
            // 
            
            
            
            panelSettingsGroup.Controls.Add(panelSettings);
            panelSettingsGroup.Controls.Add(panel2);
            panelSettingsGroup.Location = new Point(351, 14);
            panelSettingsGroup.Margin = new Padding(4, 3, 4, 3);
            panelSettingsGroup.Name = "panelSettingsGroup";
            
            
            panelSettingsGroup.Size = new Size(424, 331);
            panelSettingsGroup.TabIndex = 7;
            // 
            // panelSettings
            // 
            
            
            
            panelSettings.Dock = DockStyle.Fill;
            panelSettings.Location = new Point(0, 38);
            panelSettings.Margin = new Padding(0);
            panelSettings.Name = "panelSettings";
            
            
            panelSettings.Size = new Size(424, 293);
            panelSettings.TabIndex = 1;
            // 
            // panel2
            // 
            
            
            
            panel2.Controls.Add(radioAttributes);
            panel2.Controls.Add(radioMagicOptions);
            panel2.Controls.Add(radioEnhance);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            
            
            panel2.Size = new Size(424, 38);
            panel2.TabIndex = 0;
            // 
            // radioAttributes
            // 
            radioAttributes.AutoSize = true;
            radioAttributes.Location = new Point(235, 8);
            radioAttributes.Margin = new Padding(0);
            radioAttributes.Name = "radioAttributes";
            
            radioAttributes.Size = new Size(57, 30);
            radioAttributes.TabIndex = 2;
            radioAttributes.Text = "Stats";
            radioAttributes.CheckedChanged += radioEngine_CheckedChanged;
            // 
            // radioMagicOptions
            // 
            radioMagicOptions.AutoSize = true;
            radioMagicOptions.Location = new Point(135, 8);
            radioMagicOptions.Margin = new Padding(0);
            radioMagicOptions.Name = "radioMagicOptions";
            
            radioMagicOptions.Size = new Size(59, 30);
            radioMagicOptions.TabIndex = 1;
            radioMagicOptions.Text = "Blues";
            radioMagicOptions.CheckedChanged += radioEngine_CheckedChanged;
            // 
            // radioEnhance
            // 
            radioEnhance.AutoSize = true;
            radioEnhance.Checked = true;
            radioEnhance.Location = new Point(10, 8);
            radioEnhance.Margin = new Padding(0);
            radioEnhance.Name = "radioEnhance";
            
            radioEnhance.Size = new Size(96, 30);
            radioEnhance.TabIndex = 0;
            radioEnhance.TabStop = true;
            radioEnhance.Text = "Enhance (+)";
            radioEnhance.CheckedChanged += radioEngine_CheckedChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelSettingsGroup);
            Controls.Add(lvLog);
            Controls.Add(groupItem);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main";
            Size = new Size(791, 503);
            groupItem.ResumeLayout(false);
            groupItem.PerformLayout();
            tabControlItemInfo.ResumeLayout(false);
            tabMagicOptions.ResumeLayout(false);
            tabPageAttributes.ResumeLayout(false);
            panelSettingsGroup.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupItem;
        private Label linkRefreshItemList;
        private ComboBox comboItem;
        private ListView lvLog;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.ColumnHeader colResult;
        private Label lblOptLevelText;
        private Label lblDegree;
        private Label lblDegreeText;
        private Label lblOptLevel;
        private ListBox listMagicOptions;
        private TabControl tabControlItemInfo;
        private TabPage tabPageAttributes;
        private TabPage tabMagicOptions;
        private Label lblItemSelection;
        private ListBox listAttributes;
        private Panel panelSettingsGroup;
        private Panel panel2;
        private RadioButton radioEnhance;
        private RadioButton radioMagicOptions;
        private Panel panelSettings;
        private RadioButton radioAttributes;
    }
}
