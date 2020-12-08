using RSBot.Core.Event;
using RSBot.Core.Extensions;
using System;
using System.Windows.Forms;
using Game = RSBot.Core.Game;

namespace RSBot.Views.Controls
{
    public partial class Entity : UserControl
    {
        public Entity()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnSelectEntity", OnSelectEntity);
            EventManager.SubscribeEvent("OnDeselectEntity", OnDeselectEntity);
            EventManager.SubscribeEvent("OnUpdateSelectedEntityHP", OnUpdateSelectedEntityHP);
            EventManager.SubscribeEvent("OnSelectedEntityKilled", OnSelectedEntityKilled);
        }

        /// <summary>
        /// Fired when an entity was selected
        /// </summary>
        private void OnSelectEntity()
        {
            var selectedEntity = Game.SelectedEntity;

            if (selectedEntity == null || selectedEntity.IsPortal || selectedEntity.Bionic == null) return;

            lblEntityName.Text = selectedEntity.Player != null ? selectedEntity.Player.Name : selectedEntity.Bionic.Record.GetRealName();

            var healthPercent = (double)selectedEntity.Health / (double)selectedEntity.MaxHealth *
                                100;

            if (double.IsInfinity(healthPercent))
                return;

            progressHP.Position = selectedEntity.HasHealth
                ? Convert.ToInt32(Math.Round(healthPercent, 0))
                : 100;

            progressHP.Text = progressHP.Position + @"%";

            lblType.Text = selectedEntity.Monster != null ? selectedEntity.Monster.Rarity.Getname() : "";
        }

        /// <summary>
        /// Fired when an entity was deselected
        /// </summary>
        private void OnDeselectEntity()
        {
            lblEntityName.Text = @"No entity selected";
            progressHP.Position = 0;
            progressHP.Text = progressHP.Position + @"%";
            lblType.Text = "";
        }

        /// <summary>
        /// Core_s the on update selected entity hp.
        /// </summary>
        private void OnUpdateSelectedEntityHP()
        {
            var selectedEntity = Game.SelectedEntity;

            if (selectedEntity == null) return;
            if (selectedEntity.Bionic == null)
            {
                lblEntityName.Text = @"No entity selected";
                progressHP.Position = 0;
                progressHP.Text = progressHP.Position + @"%";
                lblType.Text = "";
                return;
            }

            if (!selectedEntity.HasHealth)
            {
                progressHP.Position = 100;
                return;
            }

            var healthPercent = (double)selectedEntity.Health / (double)selectedEntity.MaxHealth * 100;

            if (double.IsInfinity(healthPercent))
                return;

            progressHP.Position = Convert.ToInt32(Math.Round(healthPercent, 0));

            progressHP.Text = progressHP.Position + @"%";
        }

        /// <summary>
        /// Fired when the selected entity was killed
        /// </summary>
        private void OnSelectedEntityKilled()
        {
            lblEntityName.Text = @"No entity selected";
            progressHP.Position = 0;
            progressHP.Text = progressHP.Position + @"%";
            lblType.Text = "";
        }
    }
}