using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects.Spawn;
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
            EventManager.SubscribeEvent("OnSelectEntity", new Action<SpawnedBionic>(OnSelectEntity));
            EventManager.SubscribeEvent("OnDeselectEntity", OnDeselectEntity);
            EventManager.SubscribeEvent("OnUpdateSelectedEntityHP", new Action<SpawnedBionic>(OnUpdateSelectedEntityHP));
            EventManager.SubscribeEvent("OnKillSelectedEnemy", OnKillSelectedEnemy);
            EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        }

        /// <summary>
        /// Fired when an entity was selected
        /// </summary>
        private void OnSelectEntity(SpawnedBionic entity)
        {
            if (entity is SpawnedPlayer player)
                lblEntityName.Text = player.Name;
            else
                lblEntityName.Text = entity.Record.GetRealName();

            var hasHealth = false;
            var healthPercent = 0.0;
            lblType.Text = string.Empty;

            if (entity is SpawnedMonster monster)
            {
                hasHealth = monster.HasHealth;
                healthPercent = monster.Health / monster.MaxHealth * 100.0;
                lblType.Text = monster.Rarity.GetName();
            }

            if (double.IsInfinity(healthPercent))
                return;

            progressHP.Position = hasHealth ? Convert.ToInt32(Math.Round(healthPercent, 0)) : 100;

            progressHP.Text = progressHP.Position + @"%";
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
        private void OnUpdateSelectedEntityHP(SpawnedBionic entity)
        {
            if (!entity.HasHealth)
            {
                progressHP.Position = 100;
                return;
            }

            if (entity is SpawnedMonster monster)
            {
                var healthPercent = entity.Health / monster.MaxHealth * 100.0;

                if (double.IsInfinity(healthPercent))
                    return;

                progressHP.Position = Convert.ToInt32(Math.Round(healthPercent, 0));
                progressHP.Text = progressHP.Position + @"%";
            }
        }

        /// <summary>
        /// Fired when the selected entity was killed
        /// </summary>
        private void OnKillSelectedEnemy()
        {
            lblEntityName.Text = @"No entity selected";
            progressHP.Position = 0;
            progressHP.Text = progressHP.Position + @"%";
            lblType.Text = "";
        }

        /// <summary>
        /// Reset UI after character disconnect
        /// </summary>
        private void OnAgentServerDisconnected()
        {
            OnKillSelectedEnemy();
        }
    }
}