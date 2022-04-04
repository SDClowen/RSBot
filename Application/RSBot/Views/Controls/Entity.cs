using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects.Spawn;
using System.Windows.Forms;
using System;

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

            var percent = 100;
            lblType.Text = string.Empty;

            if (entity is SpawnedPlayer player)
                lblEntityName.Text = player.Name;
            else
                lblEntityName.Text = entity.Record.GetRealName();

            if (entity is SpawnedMonster monster)
            {
                percent = (monster.Health * 100) / monster.MaxHealth;
                lblType.Text = monster.Rarity.GetName();
            }

            if (percent > 100)
                percent = 100;

            progressHP.Value = percent;
            progressHP.Text = percent + "%";
        }

        /// <summary>
        /// Core_s the on update selected entity hp.
        /// </summary>
        private void OnUpdateSelectedEntityHP(SpawnedBionic entity)
        {
            if (!entity.HasHealth)
            {
                progressHP.Value = 100;
                return;
            }

            if (entity is SpawnedMonster monster)
            {
                var percent = (monster.Health * 100) / monster.MaxHealth;
                if (percent > 100)
                    percent = 100;

                progressHP.Value = percent;
                progressHP.Text = percent + "%";
            }
        }

        /// <summary>
        /// Fired when an entity was deselected
        /// </summary>
        private void OnDeselectEntity()
        {
            Clear();
        }

        /// <summary>
        /// Fired when the selected entity was killed
        /// </summary>
        private void OnKillSelectedEnemy()
        {
            Clear();
        }

        /// <summary>
        /// Reset UI after character disconnect
        /// </summary>
        private void OnAgentServerDisconnected()
        {
            Clear();
        }

        /// <summary>
        /// Clear the control
        /// </summary>
        private void Clear()
        {
            lblEntityName.Text = "No entity selected";
            progressHP.Value = 0;
            progressHP.Text ="0%";
            lblType.Text = "";
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);

            progressHP.BackColor = ColorScheme.BackColor;
        }
    }
}