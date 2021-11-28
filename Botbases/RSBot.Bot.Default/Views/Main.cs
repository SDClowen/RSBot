using RSBot.Core;
using RSBot.Core.Event;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RSBot.Bot.Default.Views
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

            lvAvoidance.Items[0].Name = "General";
            lvAvoidance.Items[1].Name = "Champion";
            lvAvoidance.Items[2].Name = "Giant";
            lvAvoidance.Items[3].Name = "General_Party";
            lvAvoidance.Items[4].Name = "Champion_Party";
            lvAvoidance.Items[5].Name = "Giant_Party";
            lvAvoidance.Items[6].Name = "Unique";
            lvAvoidance.Items[7].Name = "Strong";
            lvAvoidance.Items[8].Name = "Elite";
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        }

        /// <summary>
        /// Determines whether the specified value is numeric.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is numeric; otherwise, <c>false</c>.
        /// </returns>
        private bool isNumeric(string value)
        {
            try
            {
                Convert.ToDouble(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Saves the avoidance.
        /// </summary>
        private void SaveAvoidance()
        {
            var avoid = new List<string>();
            var prefer = new List<string>();
            var none = new List<string>();
            foreach (ListViewItem item in lvAvoidance.Items)
            {
                if (item.Group == lvAvoidance.Groups["grpAvoid"])
                    avoid.Add(item.Name);
                else if (item.Group == lvAvoidance.Groups["grpPrefer"])
                    prefer.Add(item.Name);
                else
                    none.Add(item.Name);
            }

            PlayerConfig.SetArray("RSBot.Avoidance.Avoid", avoid);
            PlayerConfig.SetArray("RSBot.Avoidance.Prefer", prefer);
            PlayerConfig.SetArray("RSBot.Avoidance.None", none);
        }

        /// <summary>
        /// Loads the avoidance.
        /// </summary>
        private void LoadAvoidance()
        {
            var avoid = PlayerConfig.GetArray<string>("RSBot.Avoidance.Avoid");
            var prefer = PlayerConfig.GetArray<string>("RSBot.Avoidance.Prefer");
            var none = PlayerConfig.GetArray<string>("RSBot.Avoidance.None");

            foreach (var item in avoid)
                lvAvoidance.Items[item].Group = lvAvoidance.Groups["grpAvoid"];

            foreach (var item in prefer)
                lvAvoidance.Items[item].Group = lvAvoidance.Groups["grpPrefer"];

            foreach (var item in none)
                lvAvoidance.Items[item].Group = lvAvoidance.Groups["grpNone"];
        }

        /// <summary>
        /// Handles the Click event of the btnGetCurrent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGetCurrent_Click(object sender, EventArgs e)
        {
            txtXCoord.Text = Convert.ToInt32(Game.Player.Tracker.Position.XCoordinate).ToString();
            txtYCoord.Text = Convert.ToInt32(Game.Player.Tracker.Position.YCoordinate).ToString();
            PlayerConfig.Set("RSBot.Area.XSec", Game.Player.Tracker.Position.XSector);
            PlayerConfig.Set("RSBot.Area.YSec", Game.Player.Tracker.Position.YSector);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtXCoord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtXCoord_TextChanged(object sender, EventArgs e)
        {
            if (isNumeric(txtXCoord.Text))
                PlayerConfig.Set("RSBot.Area.X", txtXCoord.Text);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtYCoord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtYCoord_TextChanged(object sender, EventArgs e)
        {
            if (isNumeric(txtYCoord.Text))
                PlayerConfig.Set("RSBot.Area.Y", txtYCoord.Text);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtRadius control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtRadius_TextChanged(object sender, EventArgs e)
        {
            if (isNumeric(txtRadius.Text))
                PlayerConfig.Set("RSBot.Area.Radius", txtRadius.Text);
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
            PlayerConfig.Set("RSBot.Walkback.Script", txtWalkscript.Text);
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
            if (lvAvoidance.SelectedItems.Count <= 0) return;
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
            PlayerConfig.Set("RSBot.Berzerk.MonsterAmount", checkBerzerkWhenFull.Checked);
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
            txtXCoord.Text = PlayerConfig.Get<string>("RSBot.Area.X", "0");
            txtYCoord.Text = PlayerConfig.Get<string>("RSBot.Area.Y", "0");
            txtRadius.Text = PlayerConfig.Get<string>("RSBot.Area.Radius", "50");
            radioCenter.Checked = PlayerConfig.Get("RSBot.Area.GoToCenter", true);
            radioWalkAround.Checked = PlayerConfig.Get<bool>("RSBot.Area.WalkAround");

            //Walkback
            txtWalkscript.Text = PlayerConfig.Get<string>("RSBot.Walkback.Script");
            checkUseMount.Checked = PlayerConfig.Get<bool>("RSBot.Walkback.UseMount");
            checkCastBuffs.Checked = PlayerConfig.Get<bool>("RSBot.Walkback.CastBuffs", true);
            checkUseSpeedDrug.Checked = PlayerConfig.Get<bool>("RSBot.Walkback.UseSpeedDrug");

            //BerzerkBundle
            checkBerzerkWhenFull.Checked = PlayerConfig.Get<bool>("RSBot.Berzerk.WhenFull");
            checkBerzerkAvoidance.Checked = PlayerConfig.Get<bool>("RSBot.Berzerk.MonsterAvoidance");
            checkBerzerkMonsterAmount.Checked = PlayerConfig.Get<bool>("RSBot.Berzerk.MonsterAmount");
            numBerzerkMonsterAmount.Value = PlayerConfig.Get<int>("RSBot.Berzerk.MonsterAmountNumber", 3);

            //Avoidance
            LoadAvoidance();
        }
    }
}