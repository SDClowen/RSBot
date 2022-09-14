using RSBot.Core;
using RSBot.Core.Plugins;
using System.Windows.Forms;
using RSBot.Assistance;
using RSBot.Assistant.Views;
using RSBot.Core.Objects.Spawn;
using RSBot.Training.Bundle;

namespace RSBot.Assistant
{
    public class Bootstrap : IBotbase
    {
        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public BotbaseInfo Info => new()
        {
            Name = "RSBot.Assistant",
            DisplayName = "Assistant",
            TabText = "Assistant"
        };

        /// <summary>
        /// Ticks this instance. It's the botbase main-loop
        /// </summary>
        public void Tick()
        {
            if (PlayerConfig.Get("RSBot.Assistant.AutoAttack", false))
                Bundles.Attack.Invoke();
            
            if (PlayerConfig.Get("RSBot.Assistant.AutoAttack", false)) 
                Bundles.Buff.Invoke();

            if (PlayerConfig.Get("RSBot.Assistant.AutoPickup", false))
                Bundles.Loot.Invoke();
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns></returns>
        public Control GetView()
        {
            return Globals.View ?? (Globals.View = new Main());
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Initialize()
        {
            Log.Notify("[Assistant] Bot base initialized!");
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            Bundles.Reload();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
        }

        /// <summary>
        /// Translate the botbase plugin
        /// </summary>
        /// <param name="language">The language</param>
        public void Translate()
        {
            LanguageManager.Translate(GetView(), Kernel.Language);
        }
    }
}