using System.Linq;
using System.Threading.Tasks;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core;
using RSBot.Core.Plugins;
using System.Windows.Forms;
using RSBot.Core.Network;
using RSBot.Trade.Bundle;
using RSBot.Trade.Components.Scripting;
using RSBot.Trade.Network.Hooks;

namespace RSBot.Trade
{
    public class TradeBotbase : IBotbase
    {
        public string Name => "RSBot.Trade";

        public string DisplayName => "Trade";

        public string TabText => DisplayName;

        public static bool IsActive => Kernel.Bot?.Botbase.Name == "RSBot.Trade" && Kernel.Bot.Running;

        public Area Area => new();

        /// <summary>
        ///     Ticks this instance. It's the botbase main-loop
        /// </summary>
        public void Tick()
        {
            if (!Game.Ready || Game.Player == null || ShoppingManager.Running) 
                return;

            Task.Run(Bundles.Tick);

            Views.View.Main.RefreshStatistics();
        }

        /// <summary>
        ///     Gets the view.
        /// </summary>
        /// <returns></returns>
        public Control View => Views.View.Main;

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



            Bundles.Start();
        }

        /// <summary>
        ///     Stops this instance.
        /// </summary>
        public void Stop()
        {
            Bundles.Stop();
        }

        /// <summary>
        /// Triggered after the botbase was registered to the kernel.
        /// </summary>

        public void Register()
        {
            Log.Debug("[Trade] Botbase registered to the kernel!");

            ScriptManager.CommandHandlers.Add(new BuyGoodsScriptCommand());
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