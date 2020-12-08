using RSBot.Core;
using RSBot.Core.Event;
using System;
using System.Windows.Forms;

namespace RSBot.Views.Controls
{
    public partial class Pet : UserControl
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
        }

        /// <summary>
        /// Handels the termination event
        /// </summary>
        private void OnTerminateAttackPet()
        {
            lblPetName.Text = @"No pet found";
            progressHP.Position = 0;
            progressEXP.Position = 0;
            progressHGP.Position = 0;
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

            var hpPercent = Math.Round((double)Game.Player.AttackPet.Health / (double)Game.Player.AttackPet.MaxHealth * 100, 0);
            progressHP.Position = Convert.ToInt32(hpPercent);
            progressHP.Text = hpPercent + @"%";
        }

        /// <summary>
        /// Handles the pet experience update event
        /// </summary>
        private void OnPetExpSpUpdate()
        {
            if (Game.Player.AttackPet == null) return;
            var expPercent = Math.Round((double)Game.Player.AttackPet.Experience / (double)Game.Player.AttackPet.MaxExperience * 100, 0);
            progressEXP.Position = Convert.ToInt32(expPercent);
            progressEXP.Text = expPercent + @"%";
        }

        /// <summary>
        /// Handels the hunger update event
        /// </summary>
        private void OnAttackPetHungerUpdate()
        {
            if (Game.Player.AttackPet == null) return;
            var hgpPercent = Math.Round((double)Game.Player.AttackPet.CurrentHungerPoints / (double)Game.Player.AttackPet.MaxHungerPoints * 100, 0);
            progressHGP.Position = Convert.ToInt32(hgpPercent);
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
    }
}