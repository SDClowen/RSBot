using RSBot.Core;
using RSBot.Core.Event;
using System.ComponentModel;

namespace RSBot.Views.Controls.Cos
{
    [ToolboxItem(false)]
    public partial class Fellow : CosControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fellow"/> class.
        /// </summary>
        public Fellow()
        {
            InitializeComponent();
            SubscribeEvents();

            MiniCosControl.Hgp.Visible = false;
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnFellowLevelUp", OnFellowLevelUp);
            EventManager.SubscribeEvent("OnFellowExperienceUpdate", OnFellowExperienceUpdate);
            EventManager.SubscribeEvent("OnFellowSatietyUpdate", OnFellowSatietyUpdate);
            EventManager.SubscribeEvent("OnFellowNameChange", OnFellowNameChange);
            EventManager.SubscribeEvent("OnFellowHealthUpdate", OnFellowHealthUpdate);
        }

        /// <summary>
        /// Handels the name change event of the pet
        /// </summary>
        private void OnFellowNameChange()
        {
            if (Game.Player.Fellow == null)
                return;

            var name = Game.Player.Fellow.Name;
            if (string.IsNullOrWhiteSpace(name))
                name = LanguageManager.GetLang("LabelPetName");

            lblPetName.Text = name;
            labelLevel.Text = "lv." + Game.Player.Fellow.Level;
        }

        /// <summary>
        /// Handels the pet level up event
        /// </summary>
        private void OnFellowLevelUp()
        {
            if (Game.Player.Fellow == null)
                return;

            MiniCosControl.Level.Text = "Lv." + Game.Player.Fellow.Level;
            progressBarStoredSp.Value = 0;
            progressBarStoredSp.Maximum = Game.Player.Fellow.MaxStoredSp;

            OnFellowNameChange();
            OnFellowHealthUpdate();
            OnFellowSatietyUpdate();
            OnFellowExperienceUpdate();
        }

        /// <summary>
        /// Handles the update pet hp or mp
        /// </summary>
        private void OnFellowHealthUpdate()
        {
            if (Game.Player.Fellow == null)
                return;

            progressHP.Value = Game.Player.Fellow.Health;
            progressHP.Maximum = Game.Player.Fellow.MaxHealth;

            MiniCosControl.Hp.Value = Game.Player.Fellow.Health;
            MiniCosControl.Hp.Maximum = Game.Player.Fellow.MaxHealth;
        }

        /// <summary>
        /// Handles the pet experience update event
        /// </summary>
        private void OnFellowExperienceUpdate()
        {
            if (Game.Player.Fellow == null)
                return;

            progressEXP.Value = Game.Player.Fellow.Experience;
            progressEXP.Maximum = Game.Player.Fellow.MaxExperience;
        }

        /// <summary>
        /// Handels the hunger update event
        /// </summary>
        private void OnFellowSatietyUpdate()
        {
            if (Game.Player.Fellow == null)
                return;

            progressSatiety.Value = Game.Player.Fellow.Satiety;
            progressSatiety.Maximum = 36000;

            MiniCosControl.Satiety.Value = Game.Player.Fellow.Satiety;
            MiniCosControl.Satiety.Maximum = 36000;
        }

        public override void Initialize()
        {
            OnFellowLevelUp();

            var icon = Game.Player.Fellow.Record?.GetIcon();
            if (icon != null)
                MiniCosControl.Icon.BackgroundImage = icon;
        }

        public override void Reset()
        {
            base.Reset();

            lblPetName.Text = LanguageManager.GetLang("LabelPetName");

            progressEXP.Value = 0;
            progressSatiety.Value = 0;

            progressEXP.Maximum = 0;
            progressSatiety.Maximum = 36000;

            MiniCosControl.Satiety.Value = 0;
            MiniCosControl.Satiety.Maximum = 0;
        }
    }
}