using System.Linq;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core;
using RSBot.Core.Plugins;
using System.Windows.Forms;
using RSBot.Trade.Components.Scripting;

namespace RSBot.Trade
{
    public class TradeBotbase : IBotbase
    {
        public string Name => "RSBot.Trade";

        public string DisplayName => "Trade";

        public string TabText => DisplayName;

        public Area Area => new()
        {
            Name = "Player",
            Position = Game.Player.Position,
            Radius = 50
        };

        /// <summary>
        ///     Ticks this instance. It's the botbase main-loop
        /// </summary>
        public void Tick()
        {
  
        }

        /// <summary>
        ///     Gets the view.
        /// </summary>
        /// <returns></returns>
        public Control View => Views.View.Main;

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Log.Debug("[Trade] Botbase initialized!");

            ScriptManager.CommandHandlers.Add(new BuyGoodsScriptCommand());
        }

        /// <summary>
        ///     Starts this instance.
        /// </summary>
        public void Start()
        {
            if (Game.Player == null)
                return;

            if (Game.Player.JobInformation is not { Type: JobType.Trade })
            {
                MessageBox.Show("The active character is not a trader! Make sure that you have the trader job and suite.", "Not a trader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Kernel.Bot.Stop();

                return;
            }

            if (Game.Player.Inventory.GetEquippedPartItems().FirstOrDefault(i => i.Record.IsJobOutfit) == null)
            {
                MessageBox.Show("The active character is does not wear a trader suite! Make sure that you have the trader job and suite.", "Not wearing job equipment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Kernel.Bot.Stop();

                return;
            }
            

        }

        /// <summary>
        ///     Stops this instance.
        /// </summary>
        public void Stop()
        {
        }

        public void Register()
        {
            Log.Debug("[Trade] Botbase registered to the kernel!");
        }

        /// <summary>
        ///     Translate the botbase plugin
        /// </summary>
        public void Translate()
        {
            LanguageManager.Translate(View, Kernel.Language);
        }
    }
}