﻿using RSBot.Core;
using RSBot.Core.Event;
using System;
using System.Windows.Forms;

namespace RSBot.Views.Controls
{
    public partial class Character : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        public Character()
        {
            InitializeComponent();

            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
            EventManager.SubscribeEvent("OnLoadCharacterStats", OnLoadCharacterStats);
            EventManager.SubscribeEvent("OnLevelUp", OnLevelUp);
            EventManager.SubscribeEvent("OnExpSpUpdate", OnExpUpdate);
            EventManager.SubscribeEvent("OnUpdateHPMP", OnHPMPUpdate);
            EventManager.SubscribeEvent("OnUpdateGold", OnUpdateGold);
            EventManager.SubscribeEvent("OnUpdateSP", OnUpdateSP);
            EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        }

        private void OnUpdateSP()
        {
            lblSP.Text = Game.Player.SkillPoints.ToString("#,#0");
        }

        private void OnUpdateGold()
        {
            lblGold.Text = Game.Player.Gold.ToString("#,#0");
        }

        /// <summary>
        /// On Hp/MP update
        /// </summary>
        private void OnHPMPUpdate()
        {
            progressHP.Position = (int)Game.Player.Health;
            progressMP.Position = (int)Game.Player.Mana;

            progressHP.Text = Game.Player.Health + @"/" + Game.Player.MaximumHealth;
            progressMP.Text = Game.Player.Mana + @"/" + Game.Player.MaximumMana;
        }

        /// <summary>
        /// On Exp update
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnExpUpdate()
        {
            var percentageExp = ((double)Game.Player.Experience / (double)Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C) * 100;
            progressEXP.Position = Convert.ToInt32(percentageExp);
            progressEXP.Text = Math.Round(percentageExp, 2) + @"%";
        }

        /// <summary>
        /// s the on load character stats.
        /// </summary>
        private void OnLoadCharacterStats()
        {
            lblInt.Text = Game.Player.Intelligence.ToString();
            lblStr.Text = Game.Player.Strength.ToString();

            progressHP.PositionMax = (int)Game.Player.MaximumHealth;
            progressMP.PositionMax = (int)Game.Player.MaximumMana;

            progressHP.Position = (int)Game.Player.Health;
            progressMP.Position = (int)Game.Player.Mana;

            progressEXP.PositionMax = 100;

            progressHP.Text = Game.Player.Health + @"/" + Game.Player.MaximumHealth;
            progressMP.Text = Game.Player.Mana + @"/" + Game.Player.MaximumMana;
        }

        /// <summary>
        /// s the on level up.
        /// </summary>
        private void OnLevelUp()
        {
            lblLevel.Text = Game.Player.Level.ToString();
        }

        /// <summary>
        /// s the on load character.
        /// </summary>
        private void OnLoadCharacter()
        {
            lblPlayerName.Text = Game.Player.Name;
            lblLevel.Text = Game.Player.Level.ToString();

            OnHPMPUpdate();
            OnExpUpdate();
            OnUpdateSP();
            OnUpdateGold();
        }

        /// <summary>
        /// Reset UI after character disconnect
        /// </summary>
        private void OnAgentServerDisconnected()
        {
            lblPlayerName.Text = "Not in game";
            lblLevel.Text = "0";
            lblStr.Text = "0";
            lblInt.Text = "0";
            lblGold.Text = "0";
            lblSP.Text = "0";
            progressHP.Position = 0;
            progressHP.Text = "0 / 0";
            progressMP.Position = 0;
            progressMP.Text = "0 / 0";
            progressEXP.Position = 0;
            progressEXP.Text = "%0";
        }
    }
}