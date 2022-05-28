using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects.Spawn;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RSBot.Views.Controls
{
    [ToolboxItem(false)]
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
            EventManager.SubscribeEvent("OnInitialized", OnInitialized);
        }

        private void OnInitialized()
        {
            lblEntityName.Text = LanguageManager.GetLang("LabelEntityName");
        }

        /// <summary>
        /// Fired when an entity was selected
        /// </summary>
        private void OnSelectEntity(SpawnedBionic entity)
        {
            lblType.Text = string.Empty;
            if (entity is SpawnedPlayer player)
                lblEntityName.Text = player.Name;
            else
                lblEntityName.Text = entity.Record.GetRealName();

            if (entity is SpawnedMonster monster)
            {
                progressHP.Value = monster.Health;
                progressHP.Maximum = monster.MaxHealth;

                lblType.Text = monster.Rarity.GetName();
            }
            else
            {
                progressHP.Value = 100;
                progressHP.Maximum = 100;
            }
        }

        /// <summary>
        /// Core_s the on update selected entity hp.
        /// </summary>
        private void OnUpdateSelectedEntityHP(SpawnedBionic entity)
        {
            if (!entity.HasHealth)
            {
                progressHP.Value = 100;
                progressHP.Maximum = 100;
                return;
            }

            if (entity is SpawnedMonster monster)
            {
                progressHP.Value = monster.Health;
                progressHP.Maximum = monster.MaxHealth;
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
            lblEntityName.Text = LanguageManager.GetLang("LabelEntityName");
            progressHP.Value = 0;
            progressHP.Maximum = 100;
            lblType.Text = "";
        }
    }
}