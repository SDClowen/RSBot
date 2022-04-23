using RSBot.Core;
using RSBot.Core.Event;
using SDUI;
using SDUI.Controls;
using System;
using System.Linq;

namespace RSBot.Views.Controls
{
    public partial class Pet : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pet"/> class.
        /// </summary>
        public Pet()
        {
            InitializeComponent();
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnSummonAttackPet", OnSummonAttackPet);
            EventManager.SubscribeEvent("OnTerminateAttackPet", OnTerminateAttackPet);
            EventManager.SubscribeEvent("OnPetLevelUp", OnPetLevelUp);
            EventManager.SubscribeEvent("OnPetExperienceUpdate", OnPetExpSpUpdate);
            EventManager.SubscribeEvent("OnAttackPetHungerUpdate", OnAttackPetHungerUpdate);
            EventManager.SubscribeEvent("OnAttackPetNameChange", OnAttackPetNameChange);
            EventManager.SubscribeEvent("OnUpdatePetHPMP", OnPetHealthUpdate);
            EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
            EventManager.SubscribeEvent("OnInitialized", OnInitialized);
        }

        private void OnInitialized()
        {
            lblPetName.Text = LanguageManager.GetLang("LabelPetName");
        }

        /// <summary>
        /// Handels the termination event
        /// </summary>
        private void OnTerminateAttackPet()
        {
            lblPetName.Text = @"No pet found";
            progressHP.Value = 0;
            progressEXP.Value = 0;
            progressHGP.Value = 0;
            progressHP.Text = @"0%";
            progressEXP.Text = @"0%";
            progressHGP.Text = @"0%";
        }

        /// <summary>
        /// Handels the name change event of the pet
        /// </summary>
        private void OnAttackPetNameChange()
        {
            if (Game.Player.AttackPet == null) return;

            lblPetName.Text = Game.Player.AttackPet.Name + @" (lv." + Game.Player.AttackPet.Level + @")";
        }

        /// <summary>
        /// Handels the pet level up event
        /// </summary>
        private void OnPetLevelUp()
        {
            if (Game.Player.AttackPet == null) return;

            OnAttackPetNameChange();
            OnPetHealthUpdate();
            OnAttackPetHungerUpdate();
            OnPetExpSpUpdate();
        }

        /// <summary>
        /// Handles the update pet hp or mp
        /// </summary>
        private void OnPetHealthUpdate()
        {
            if (Game.Player.AttackPet == null) return;

            var hpPercent = (Game.Player.AttackPet.Health * 100) / Game.Player.AttackPet.MaxHealth;
            if(hpPercent > 100)
                hpPercent = 100;

            progressHP.Value = Convert.ToInt32(hpPercent);
            progressHP.Text = hpPercent + @"%";
        }

        /// <summary>
        /// Handles the pet experience update event
        /// </summary>
        private void OnPetExpSpUpdate()
        {
            if (Game.Player.AttackPet == null) 
                return;

            var expPercent = (Game.Player.AttackPet.Experience * 100) / Game.Player.AttackPet.MaxExperience;
            if(expPercent > 100)
                expPercent = 100;

            progressEXP.Value = Convert.ToInt32(expPercent);
            progressEXP.Text = expPercent + @"%";
        }

        /// <summary>
        /// Handels the hunger update event
        /// </summary>
        private void OnAttackPetHungerUpdate()
        {
            if (Game.Player.AttackPet == null)
                return;

            var hgpPercent = (Game.Player.AttackPet.CurrentHungerPoints * 100) / Game.Player.AttackPet.MaxHungerPoints;
            if(hgpPercent > 100)
                hgpPercent = 100;

            progressHGP.Value = Convert.ToInt32(hgpPercent);
            progressHGP.Text = hgpPercent + @"%";
        }

        /// <summary>
        /// Handles the spawn event for an attack pet
        /// </summary>
        private void OnSummonAttackPet()
        {
            if (Game.Player.AttackPet == null) return;

            OnPetLevelUp();
        }

        /// <summary>
        /// Reset UI after character disconnect
        /// </summary>
        private void OnAgentServerDisconnected()
        {
            lblPetName.Text = "No pet found";
            foreach (var item in Controls.OfType<ProgressBar>())
            {
                item.Value = 0;
                item.Text = "0%";
            }
        }
    }
}