using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Default.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            SubscribeEvents();

            lvAvoidance.Items[0].Tag = MonsterRarity.General;
            lvAvoidance.Items[1].Tag = MonsterRarity.Champion;
            lvAvoidance.Items[2].Tag = MonsterRarity.Giant;
            lvAvoidance.Items[3].Tag = MonsterRarity.GeneralParty;
            lvAvoidance.Items[4].Tag = MonsterRarity.ChampionParty;
            lvAvoidance.Items[5].Tag = MonsterRarity.GiantParty;
            lvAvoidance.Items[6].Tag = MonsterRarity.Unique | MonsterRarity.Unique2;
            lvAvoidance.Items[7].Tag = MonsterRarity.EliteStrong;
            lvAvoidance.Items[8].Tag = MonsterRarity.Elite;
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
            EventManager.SubscribeEvent("OnSetTrainingArea", OnSetTrainingArea);
        }

        /// <summary>
        /// Called when the training area has been set to a certain location. Will append a new script command "area" and update the UI.
        /// </summary>
        private void OnSetTrainingArea()
        {
            var xPos = PlayerConfig.Get<float>("RSBot.Area.X");
            var yPos = PlayerConfig.Get<float>("RSBot.Area.Y");
            var radius = PlayerConfig.Get<int>("RSBot.Area.Radius");

            txtRadius.Text = radius.ToString();
            txtXCoord.Text = xPos.ToString();
            txtYCoord.Text = yPos.ToString();

            EventManager.FireEvent("AppendScriptCommand", $"area {xPos} {yPos} {radius}");
        }

        /// <summary>
        /// Saves the avoidance.
        /// </summary>
        private void SaveAvoidance()
        {
            var avoid = new List<MonsterRarity>();
            var prefer = new List<MonsterRarity>();
            foreach (ListViewItem item in lvAvoidance.Items)
            {
                if (item.Group == lvAvoidance.Groups["grpAvoid"])
                    avoid.Add((MonsterRarity)item.Tag);
                else if (item.Group == lvAvoidance.Groups["grpPrefer"])
                    prefer.Add((MonsterRarity)item.Tag);
            }

            PlayerConfig.SetArray("RSBot.Avoidance.Avoid", avoid);
            PlayerConfig.SetArray("RSBot.Avoidance.Prefer", prefer);
        }

        /// <summary>
        /// Loads the avoidance.
        /// </summary>
        private void LoadAvoidance()
        {
            var avoid = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Avoid")
                .ToDictionary(p => "Avoid", p => p);
            var prefer = PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Prefer")
                .ToDictionary(p => "Prefer", p => p);
            
            foreach (var item in avoid.Union(prefer))
            {
                var listViewItem = lvAvoidance.Items.Cast<ListViewItem>()
                    .FirstOrDefault(p => ((MonsterRarity)p.Tag & item.Value) == item.Value);
                if (listViewItem == null)
                    continue;

                listViewItem.Group = lvAvoidance.Groups[$"grp{item.Key}"];
            }
        }

        /// <summary>
        /// Handles the Click event of the btnGetCurrent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGetCurrent_Click(object sender, EventArgs e)
        {
            txtXCoord.Text = Convert.ToInt32(Game.Player.Movement.Source.XCoordinate).ToString();
            txtYCoord.Text = Convert.ToInt32(Game.Player.Movement.Source.YCoordinate).ToString();

            EventManager.FireEvent("OnSetTrainingArea");
        }

        /// <summary>
        /// Handles the TextChanged event of the txtXCoord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtXCoord_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(txtXCoord.Text, out var result))
                return;

            PlayerConfig.Set("RSBot.Area.X", result);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtYCoord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtYCoord_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(txtYCoord.Text, out var result))
                return;

            PlayerConfig.Set("RSBot.Area.Y", result);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtRadius control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtRadius_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRadius.Text, out var result))
                return;

            PlayerConfig.Set("RSBot.Area.Radius", result);
        }

        /// <summary>
        /// Handles the Click event of the btnBrowse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var diag = new OpenFileDialog
            {
                Filter = @"RSBot Bot script|*.rbs",
                Title = @"Browse for a walkback script"
            };

            if (diag.ShowDialog() != DialogResult.OK) return;

            txtWalkscript.Text = diag.FileName;
            PlayerConfig.Set("RSBot.Walkback.File", txtWalkscript.Text);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioCenter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioCenter_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Area.GoToCenter", radioCenter.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioWalkAround control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioWalkAround_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Area.WalkAround", radioWalkAround.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkUseMount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkUseMount_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Walkback.UseMount", checkUseMount.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBoxUseReverse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxUseReverse_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Walkback.UseReverse", checkBoxUseReverse.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkCastBuffs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkCastBuffs_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Walkback.CastBuffs", checkCastBuffs.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkUseSpeedDrug control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkUseSpeedDrug_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Walkback.UseSpeedDrug", checkUseSpeedDrug.Checked);
        }

        /// <summary>
        /// Handles the Click event of the btnAvoid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnAvoid_Click(object sender, EventArgs e)
        {
            if (lvAvoidance.SelectedItems.Count <= 0) 
                return;

            foreach (ListViewItem item in lvAvoidance.SelectedItems)
                item.Group = lvAvoidance.Groups["grpAvoid"];

            SaveAvoidance();
        }

        /// <summary>
        /// Handles the Click event of the btnPrefer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPrefer_Click(object sender, EventArgs e)
        {
            if (lvAvoidance.SelectedItems.Count <= 0) return;
            foreach (ListViewItem item in lvAvoidance.SelectedItems)
                item.Group = lvAvoidance.Groups["grpPrefer"];

            SaveAvoidance();
        }

        /// <summary>
        /// Handles the Click event of the btnNoCustomBehavior control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNoCustomBehavior_Click(object sender, EventArgs e)
        {
            if (lvAvoidance.SelectedItems.Count <= 0) return;
            foreach (ListViewItem item in lvAvoidance.SelectedItems)
                item.Group = lvAvoidance.Groups["grpNone"];

            SaveAvoidance();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBerzerkWhenFull control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBerzerkWhenFull_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Berzerk.WhenFull", checkBerzerkWhenFull.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBerzerkMonsterAmount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBerzerkMonsterAmount_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Berzerk.MonsterAmount", checkBerzerkMonsterAmount.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBerzerkAvoidance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBerzerkAvoidance_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Berzerk.MonsterAvoidance", checkBerzerkAvoidance.Checked);
        }

        /// <summary>
        /// Handles the ValueChanged event of the numBerzerkMonsterAmount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numBerzerkMonsterAmount_ValueChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Berzerk.MonsterAmountNumber", numBerzerkMonsterAmount.Value);
        }

        /// <summary>
        /// </summary>
        private void OnLoadCharacter()
        {
            //Training Area
            txtXCoord.Text = PlayerConfig.Get("RSBot.Area.X", "0");
            txtYCoord.Text = PlayerConfig.Get("RSBot.Area.Y", "0");
            txtRadius.Text = PlayerConfig.Get("RSBot.Area.Radius", "50");
            radioCenter.Checked = PlayerConfig.Get("RSBot.Area.GoToCenter", true);
            radioWalkAround.Checked = PlayerConfig.Get<bool>("RSBot.Area.WalkAround");

            //Walkback
            txtWalkscript.Text = PlayerConfig.Get<string>("RSBot.Walkback.File");
            checkUseMount.Checked = PlayerConfig.Get<bool>("RSBot.Walkback.UseMount");
            checkCastBuffs.Checked = PlayerConfig.Get("RSBot.Walkback.CastBuffs", true);
            checkUseSpeedDrug.Checked = PlayerConfig.Get<bool>("RSBot.Walkback.UseSpeedDrug");
            checkBoxUseReverse.Checked = PlayerConfig.Get<bool>("RSBot.Walkback.UseReverse");

            //BerzerkBundle
            checkBerzerkWhenFull.Checked = PlayerConfig.Get<bool>("RSBot.Berzerk.WhenFull");
            checkBerzerkAvoidance.Checked = PlayerConfig.Get<bool>("RSBot.Berzerk.MonsterAvoidance");
            checkBerzerkMonsterAmount.Checked = PlayerConfig.Get<bool>("RSBot.Berzerk.MonsterAmount");
            numBerzerkMonsterAmount.Value = PlayerConfig.Get("RSBot.Berzerk.MonsterAmountNumber", 3);

            //Avoidance
            LoadAvoidance();
        }
    }
}