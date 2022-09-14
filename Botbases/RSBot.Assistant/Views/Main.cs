using RSBot.Core;
using RSBot.Core.Event;
using System.Windows.Forms;

namespace RSBot.Assistant.Views
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
        }

        #region Core events

        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        }

        private void OnLoadCharacter()
        {
            checkAttack.Checked = PlayerConfig.Get("RSBot.Assistant.AutoAttack", false);
            checkBuff.Checked = PlayerConfig.Get("RSBot.Assistant.AutoBuff", false);
        }

        #endregion Core events

        #region Form events

        /// <summary>Handles the CheckedChanged event of the config control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void config_CheckedChanged(object sender, System.EventArgs e)
        {
            PlayerConfig.Set("RSBot.Assistant.AutoAttack", checkAttack.Checked);
            PlayerConfig.Set("RSBot.Assistant.AutoBuff", checkBuff.Checked);
        }

        #endregion Form events
    }
}