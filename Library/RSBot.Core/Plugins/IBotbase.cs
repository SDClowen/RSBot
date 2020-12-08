using System.Windows.Forms;

namespace RSBot.Core.Plugins
{
    public interface IBotbase
    {
        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        BotbaseInfo Info { get; }

        /// <summary>
        /// Ticks this instance.
        /// </summary>
        void Tick();

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns></returns>
        Control GetView();

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();
    }
}