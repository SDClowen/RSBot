using System.Drawing;
using System.Windows.Forms;


using ComboBox = SDUI.Controls.ComboBox;
using GroupBox = SDUI.Controls.GroupBox;
using Label = SDUI.Controls.Label;
using ListView = SDUI.Controls.ListView;
using TabControl = SDUI.Controls.TabControl;
using Panel = SDUI.Controls.Panel;
using RadioButton = SDUI.Controls.Radio;

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
            this.groupItem = new SDUI.Controls.GroupBox();
            this.lblOptLevel = new SDUI.Controls.Label();
            this.tabControlItemInfo = new SDUI.Controls.TabControl();
            this.tabMagicOptions = new System.Windows.Forms.TabPage();
            this.listMagicOptions = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listAttributes = new System.Windows.Forms.ListBox();
            this.comboItem = new SDUI.Controls.ComboBox();
            this.lblOptLevelText = new SDUI.Controls.Label();
            this.lblItemSelection = new SDUI.Controls.Label();
            this.lblDegree = new SDUI.Controls.Label();
            this.lblDegreeText = new SDUI.Controls.Label();
            this.linkRefreshItemList = new SDUI.Controls.Label();
            this.lvLog = new SDUI.Controls.ListView();
            this.colItem = new System.Windows.Forms.ColumnHeader();
            this.colResult = new System.Windows.Forms.ColumnHeader();
            this.panelSettingsGroup = new SDUI.Controls.Panel();
            this.panelSettings = new SDUI.Controls.Panel();
            this.panel2 = new SDUI.Controls.Panel();
            this.radioAttributes = new SDUI.Controls.Radio();
            this.radioMagicOptions = new SDUI.Controls.Radio();
            this.radioEnhance = new SDUI.Controls.Radio();
            this.groupItem.SuspendLayout();
            this.tabControlItemInfo.SuspendLayout();
            this.tabMagicOptions.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelSettingsGroup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupItem
            // 
            this.groupItem.BackColor = System.Drawing.Color.Transparent;
            this.groupItem.Controls.Add(this.lblOptLevel);
            this.groupItem.Controls.Add(this.tabControlItemInfo);
            this.groupItem.Controls.Add(this.comboItem);
            this.groupItem.Controls.Add(this.lblOptLevelText);
            this.groupItem.Controls.Add(this.lblItemSelection);
            this.groupItem.Controls.Add(this.lblDegree);
            this.groupItem.Controls.Add(this.lblDegreeText);
            this.groupItem.Controls.Add(this.linkRefreshItemList);
            this.groupItem.Location = new System.Drawing.Point(16, 14);
            this.groupItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupItem.Name = "groupItem";
            this.groupItem.Padding = new System.Windows.Forms.Padding(4, 12, 4, 3);
            this.groupItem.Radius = 2;
            this.groupItem.Size = new System.Drawing.Size(322, 315);
            this.groupItem.TabIndex = 0;
            this.groupItem.TabStop = false;
            this.groupItem.Text = "Item";
            // 
            // lblOptLevel
            // 
            this.lblOptLevel.AutoSize = true;
            this.lblOptLevel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOptLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOptLevel.Location = new System.Drawing.Point(118, 102);
            this.lblOptLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptLevel.Name = "lblOptLevel";
            this.lblOptLevel.Size = new System.Drawing.Size(108, 13);
            this.lblOptLevel.TabIndex = 1;
            this.lblOptLevel.Text = "<no item selected>";
            // 
            // tabControlItemInfo
            // 
            this.tabControlItemInfo.Border = new System.Windows.Forms.Padding(1);
            this.tabControlItemInfo.Controls.Add(this.tabMagicOptions);
            this.tabControlItemInfo.Controls.Add(this.tabPage2);
            this.tabControlItemInfo.HideTabArea = false;
            this.tabControlItemInfo.Location = new System.Drawing.Point(9, 146);
            this.tabControlItemInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControlItemInfo.Name = "tabControlItemInfo";
            this.tabControlItemInfo.SelectedIndex = 0;
            this.tabControlItemInfo.Size = new System.Drawing.Size(304, 162);
            this.tabControlItemInfo.TabIndex = 5;
            // 
            // tabMagicOptions
            // 
            this.tabMagicOptions.BackColor = System.Drawing.Color.White;
            this.tabMagicOptions.Controls.Add(this.listMagicOptions);
            this.tabMagicOptions.Location = new System.Drawing.Point(4, 24);
            this.tabMagicOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabMagicOptions.Name = "tabMagicOptions";
            this.tabMagicOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabMagicOptions.Size = new System.Drawing.Size(296, 134);
            this.tabMagicOptions.TabIndex = 0;
            this.tabMagicOptions.Text = "Magic options";
            // 
            // listMagicOptions
            // 
            this.listMagicOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listMagicOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMagicOptions.ItemHeight = 15;
            this.listMagicOptions.Location = new System.Drawing.Point(4, 3);
            this.listMagicOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listMagicOptions.Name = "listMagicOptions";
            this.listMagicOptions.Size = new System.Drawing.Size(288, 128);
            this.listMagicOptions.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.listAttributes);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(296, 134);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attributes";
            // 
            // listAttributes
            // 
            this.listAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAttributes.ItemHeight = 15;
            this.listAttributes.Location = new System.Drawing.Point(4, 3);
            this.listAttributes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listAttributes.Name = "listAttributes";
            this.listAttributes.Size = new System.Drawing.Size(288, 128);
            this.listAttributes.TabIndex = 3;
            // 
            // comboItem
            // 
            this.comboItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboItem.DropDownHeight = 100;
            this.comboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItem.FormattingEnabled = true;
            this.comboItem.IntegralHeight = false;
            this.comboItem.ItemHeight = 17;
            this.comboItem.Location = new System.Drawing.Point(21, 47);
            this.comboItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(255, 23);
            this.comboItem.TabIndex = 4;
            this.comboItem.SelectedIndexChanged += new System.EventHandler(this.comboItem_SelectedIndexChanged);
            // 
            // lblOptLevelText
            // 
            this.lblOptLevelText.AutoSize = true;
            this.lblOptLevelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOptLevelText.Location = new System.Drawing.Point(18, 102);
            this.lblOptLevelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptLevelText.Name = "lblOptLevelText";
            this.lblOptLevelText.Size = new System.Drawing.Size(83, 15);
            this.lblOptLevelText.TabIndex = 0;
            this.lblOptLevelText.Text = "&Enhancement:";
            // 
            // lblItemSelection
            // 
            this.lblItemSelection.AutoSize = true;
            this.lblItemSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblItemSelection.Location = new System.Drawing.Point(18, 29);
            this.lblItemSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemSelection.Name = "lblItemSelection";
            this.lblItemSelection.Size = new System.Drawing.Size(34, 15);
            this.lblItemSelection.TabIndex = 3;
            this.lblItemSelection.Text = "Item:";
            // 
            // lblDegree
            // 
            this.lblDegree.AutoSize = true;
            this.lblDegree.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDegree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDegree.Location = new System.Drawing.Point(118, 75);
            this.lblDegree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(108, 13);
            this.lblDegree.TabIndex = 1;
            this.lblDegree.Text = "<no item selected>";
            // 
            // lblDegreeText
            // 
            this.lblDegreeText.AutoSize = true;
            this.lblDegreeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDegreeText.Location = new System.Drawing.Point(18, 75);
            this.lblDegreeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDegreeText.Name = "lblDegreeText";
            this.lblDegreeText.Size = new System.Drawing.Size(47, 15);
            this.lblDegreeText.TabIndex = 0;
            this.lblDegreeText.Text = "&Degree:";
            // 
            // linkRefreshItemList
            // 
            this.linkRefreshItemList.AutoSize = true;
            this.linkRefreshItemList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkRefreshItemList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkRefreshItemList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.linkRefreshItemList.Location = new System.Drawing.Point(272, 39);
            this.linkRefreshItemList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkRefreshItemList.Name = "linkRefreshItemList";
            this.linkRefreshItemList.Size = new System.Drawing.Size(34, 30);
            this.linkRefreshItemList.TabIndex = 5;
            this.linkRefreshItemList.Text = "🗘";
            this.linkRefreshItemList.Click += new System.EventHandler(this.linkRefreshItemList_Click);
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItem,
            this.colResult});
            this.lvLog.FullRowSelect = true;
            this.lvLog.Location = new System.Drawing.Point(16, 335);
            this.lvLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(759, 153);
            this.lvLog.TabIndex = 1;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // colItem
            // 
            this.colItem.Text = "Item";
            this.colItem.Width = 228;
            // 
            // colResult
            // 
            this.colResult.Text = "Message";
            this.colResult.Width = 500;
            // 
            // panelSettingsGroup
            // 
            this.panelSettingsGroup.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panelSettingsGroup.BorderColor = System.Drawing.Color.Transparent;
            this.panelSettingsGroup.Controls.Add(this.panelSettings);
            this.panelSettingsGroup.Controls.Add(this.panel2);
            this.panelSettingsGroup.Location = new System.Drawing.Point(351, 14);
            this.panelSettingsGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelSettingsGroup.Name = "panelSettingsGroup";
            this.panelSettingsGroup.Radius = 1;
            this.panelSettingsGroup.Size = new System.Drawing.Size(424, 315);
            this.panelSettingsGroup.TabIndex = 7;
            // 
            // panelSettings
            // 
            this.panelSettings.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panelSettings.BorderColor = System.Drawing.Color.Transparent;
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 44);
            this.panelSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Radius = 1;
            this.panelSettings.Size = new System.Drawing.Size(424, 271);
            this.panelSettings.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Border = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panel2.BorderColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.radioAttributes);
            this.panel2.Controls.Add(this.radioMagicOptions);
            this.panel2.Controls.Add(this.radioEnhance);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Radius = 1;
            this.panel2.Size = new System.Drawing.Size(424, 44);
            this.panel2.TabIndex = 0;
            // 
            // radioAttributes
            // 
            this.radioAttributes.AutoSize = true;
            this.radioAttributes.Checked = false;
            this.radioAttributes.Location = new System.Drawing.Point(237, 13);
            this.radioAttributes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radioAttributes.Name = "radioAttributes";
            this.radioAttributes.Size = new System.Drawing.Size(84, 15);
            this.radioAttributes.TabIndex = 2;
            this.radioAttributes.Text = "Attributes";
            this.radioAttributes.CheckedChanged += new System.EventHandler(this.radioEngine_CheckedChanged);
            // 
            // radioMagicOptions
            // 
            this.radioMagicOptions.AutoSize = true;
            this.radioMagicOptions.Checked = false;
            this.radioMagicOptions.Location = new System.Drawing.Point(127, 13);
            this.radioMagicOptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radioMagicOptions.Name = "radioMagicOptions";
            this.radioMagicOptions.Size = new System.Drawing.Size(102, 15);
            this.radioMagicOptions.TabIndex = 1;
            this.radioMagicOptions.Text = "Mag. options";
            this.radioMagicOptions.CheckedChanged += new System.EventHandler(this.radioEngine_CheckedChanged);
            // 
            // radioEnhance
            // 
            this.radioEnhance.AutoSize = true;
            this.radioEnhance.Checked = true;
            this.radioEnhance.Location = new System.Drawing.Point(12, 13);
            this.radioEnhance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radioEnhance.Name = "radioEnhance";
            this.radioEnhance.Size = new System.Drawing.Size(96, 15);
            this.radioEnhance.TabIndex = 0;
            this.radioEnhance.Text = "Enhance (+)";
            this.radioEnhance.CheckedChanged += new System.EventHandler(this.radioEngine_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSettingsGroup);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.groupItem);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(791, 503);
            this.groupItem.ResumeLayout(false);
            this.groupItem.PerformLayout();
            this.tabControlItemInfo.ResumeLayout(false);
            this.tabMagicOptions.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panelSettingsGroup.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

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
        private TabPage tabPage2;
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
