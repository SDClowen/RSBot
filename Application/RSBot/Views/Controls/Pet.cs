using RSBot.Core;
using RSBot.Core.Event;
using SDUI.Controls;
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
            EventManager.SubscribeEvent("OnAgentServerDisconnected", OnTerminateAttackPet);
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
            lblPetName.Text = LanguageManager.GetLang("LabelPetName");
            progressHP.Value = 0;
            progressEXP.Value = 0;
            progressHGP.Value = 0;
            progressHP.Maximum = 0;
            progressEXP.Maximum = 0;
            progressHGP.Maximum = 0;
        }

        /// <summary>
        /// Handels the name change event of the pet
        /// </summary>
        private void OnAttackPetNameChange()
        {
            if (Game.Player.AttackPet == null) 
                return;

            lblPetName.Text = Game.Player.AttackPet.Name + @" (lv." + Game.Player.AttackPet.Level + @")";
        }

        /// <summary>
        /// Handels the pet level up event
        /// </summary>
        private void OnPetLevelUp()
        {
            if (Game.Player.AttackPet == null) 
                return;

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
            if (Game.Player.AttackPet == null) 
                return;

            progressHP.Value = Game.Player.AttackPet.Health;
            progressHP.Maximum = Game.Player.AttackPet.MaxHealth;
        }

        /// <summary>
        /// Handles the pet experience update event
        /// </summary>
        private void OnPetExpSpUpdate()
        {
            if (Game.Player.AttackPet == null) 
                return;

            progressEXP.Value = Game.Player.AttackPet.Experience;
            progressEXP.Maximum = Game.Player.AttackPet.MaxExperience;
        }

        /// <summary>
        /// Handels the hunger update event
        /// </summary>
        private void OnAttackPetHungerUpdate()
        {
            if (Game.Player.AttackPet == null)
                return;

            progressHGP.Value = Game.Player.AttackPet.CurrentHungerPoints;
            progressHGP.Maximum = Game.Player.AttackPet.MaxHungerPoints;
        }

        /// <summary>
        /// Handles the spawn event for an attack pet
        /// </summary>
        private void OnSummonAttackPet()
        {
            if (Game.Player.AttackPet == null) 
                return;

            OnPetLevelUp();
        }
    }
}