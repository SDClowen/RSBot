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
            radioAttributes = new SDUI.Controls.Radio();
            radioMagicOptions = new SDUI.Controls.Radio();
            radioEnhance = new SDUI.Controls.Radio();
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
            groupItem.BackColor = Color.Transparent;
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
            groupItem.Radius = 10;
            groupItem.ShadowDepth = 4;
            groupItem.Size = new Size(322, 331);
            groupItem.TabIndex = 0;
            groupItem.TabStop = false;
            groupItem.Text = "Item";
            // 
            // lblOptLevel
            // 
            lblOptLevel.ApplyGradient = false;
            lblOptLevel.AutoSize = true;
            lblOptLevel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblOptLevel.ForeColor = Color.FromArgb(0, 0, 0);
            lblOptLevel.Gradient = new Color[]
    {
    Color.Gray,
    Color.Black
    };
            lblOptLevel.GradientAnimation = false;
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
            tabControlItemInfo.Radius = new Padding(4);
            tabControlItemInfo.SelectedIndex = 0;
            tabControlItemInfo.Size = new Size(304, 179);
            tabControlItemInfo.TabIndex = 5;
            // 
            // tabMagicOptions
            // 
            tabMagicOptions.BackColor = Color.White;
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
            tabPageAttributes.BackColor = Color.White;
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
            comboItem.DrawMode = DrawMode.OwnerDrawFixed;
            comboItem.DropDownHeight = 100;
            comboItem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboItem.FormattingEnabled = true;
            comboItem.IntegralHeight = false;
            comboItem.ItemHeight = 17;
            comboItem.Location = new Point(21, 47);
            comboItem.Margin = new Padding(4, 3, 4, 3);
            comboItem.Name = "comboItem";
            comboItem.Radius = 5;
            comboItem.ShadowDepth = 4F;
            comboItem.Size = new Size(255, 23);
            comboItem.TabIndex = 4;
            comboItem.SelectedIndexChanged += comboItem_SelectedIndexChanged;
            // 
            // lblOptLevelText
            // 
            lblOptLevelText.ApplyGradient = false;
            lblOptLevelText.AutoSize = true;
            lblOptLevelText.ForeColor = Color.FromArgb(0, 0, 0);
            lblOptLevelText.Gradient = new Color[]
    {
    Color.Gray,
    Color.Black
    };
            lblOptLevelText.GradientAnimation = false;
            lblOptLevelText.Location = new Point(18, 102);
            lblOptLevelText.Margin = new Padding(4, 0, 4, 0);
            lblOptLevelText.Name = "lblOptLevelText";
            lblOptLevelText.Size = new Size(83, 15);
            lblOptLevelText.TabIndex = 0;
            lblOptLevelText.Text = "&Enhancement:";
            // 
            // lblItemSelection
            // 
            lblItemSelection.ApplyGradient = false;
            lblItemSelection.AutoSize = true;
            lblItemSelection.ForeColor = Color.FromArgb(0, 0, 0);
            lblItemSelection.Gradient = new Color[]
    {
    Color.Gray,
    Color.Black
    };
            lblItemSelection.GradientAnimation = false;
            lblItemSelection.Location = new Point(18, 29);
            lblItemSelection.Margin = new Padding(4, 0, 4, 0);
            lblItemSelection.Name = "lblItemSelection";
            lblItemSelection.Size = new Size(34, 15);
            lblItemSelection.TabIndex = 3;
            lblItemSelection.Text = "Item:";
            // 
            // lblDegree
            // 
            lblDegree.ApplyGradient = false;
            lblDegree.AutoSize = true;
            lblDegree.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblDegree.ForeColor = Color.FromArgb(0, 0, 0);
            lblDegree.Gradient = new Color[]
    {
    Color.Gray,
    Color.Black
    };
            lblDegree.GradientAnimation = false;
            lblDegree.Location = new Point(118, 75);
            lblDegree.Margin = new Padding(4, 0, 4, 0);
            lblDegree.Name = "lblDegree";
            lblDegree.Size = new Size(108, 13);
            lblDegree.TabIndex = 1;
            lblDegree.Text = "<no item selected>";
            // 
            // lblDegreeText
            // 
            lblDegreeText.ApplyGradient = false;
            lblDegreeText.AutoSize = true;
            lblDegreeText.ForeColor = Color.FromArgb(0, 0, 0);
            lblDegreeText.Gradient = new Color[]
    {
    Color.Gray,
    Color.Black
    };
            lblDegreeText.GradientAnimation = false;
            lblDegreeText.Location = new Point(18, 75);
            lblDegreeText.Margin = new Padding(4, 0, 4, 0);
            lblDegreeText.Name = "lblDegreeText";
            lblDegreeText.Size = new Size(47, 15);
            lblDegreeText.TabIndex = 0;
            lblDegreeText.Text = "&Degree:";
            // 
            // linkRefreshItemList
            // 
            linkRefreshItemList.ApplyGradient = false;
            linkRefreshItemList.AutoSize = true;
            linkRefreshItemList.Cursor = Cursors.Hand;
            linkRefreshItemList.Font = new Font("Segoe UI", 15.75F);
            linkRefreshItemList.ForeColor = Color.FromArgb(0, 0, 0);
            linkRefreshItemList.Gradient = new Color[]
    {
    Color.Gray,
    Color.Black
    };
            linkRefreshItemList.GradientAnimation = false;
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
            lvLog.BackColor = Color.White;
            lvLog.Columns.AddRange(new ColumnHeader[] { colItem, colResult });
            lvLog.ForeColor = Color.FromArgb(0, 0, 0);
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
            panelSettingsGroup.BackColor = Color.Transparent;
            panelSettingsGroup.Border = new Padding(0, 0, 0, 0);
            panelSettingsGroup.BorderColor = Color.Transparent;
            panelSettingsGroup.Controls.Add(panelSettings);
            panelSettingsGroup.Controls.Add(panel2);
            panelSettingsGroup.Location = new Point(351, 14);
            panelSettingsGroup.Margin = new Padding(4, 3, 4, 3);
            panelSettingsGroup.Name = "panelSettingsGroup";
            panelSettingsGroup.Radius = 1;
            panelSettingsGroup.ShadowDepth = 4F;
            panelSettingsGroup.Size = new Size(424, 331);
            panelSettingsGroup.TabIndex = 7;
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.Transparent;
            panelSettings.Border = new Padding(0, 0, 0, 0);
            panelSettings.BorderColor = Color.Transparent;
            panelSettings.Dock = DockStyle.Fill;
            panelSettings.Location = new Point(0, 38);
            panelSettings.Margin = new Padding(0);
            panelSettings.Name = "panelSettings";
            panelSettings.Radius = 0;
            panelSettings.ShadowDepth = 4F;
            panelSettings.Size = new Size(424, 293);
            panelSettings.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Border = new Padding(0, 0, 0, 0);
            panel2.BorderColor = Color.Transparent;
            panel2.Controls.Add(radioAttributes);
            panel2.Controls.Add(radioMagicOptions);
            panel2.Controls.Add(radioEnhance);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Radius = 1;
            panel2.ShadowDepth = 4F;
            panel2.Size = new Size(424, 38);
            panel2.TabIndex = 0;
            // 
            // radioAttributes
            // 
            radioAttributes.AutoSize = true;
            radioAttributes.Location = new Point(235, 8);
            radioAttributes.Margin = new Padding(0);
            radioAttributes.Name = "radioAttributes";
            radioAttributes.Ripple = true;
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
            radioMagicOptions.Ripple = true;
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
            radioEnhance.Ripple = true;
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
            Font = new Font("Segoe UI", 9F);
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
