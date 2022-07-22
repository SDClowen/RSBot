using RSBot.Core;

namespace RSBot.Alchemy.Bot
{
    internal class Botbase
    {
        #region Properties

        /// <summary>
        /// The selected botbase engine
        /// </summary>
        public Engine Engine { get; set; }

        /// <summary>
        /// The configuration for the Enhancer
        /// </summary>
        public EnhancementConfig EnhancementConfig { get; set; }

        /// <summary>
        /// The enhancement manager used to increase item OptLevel
        /// </summary>
        public Enhancer Enhancer { get; private set; }

        /// <summary>
        /// The magic option manager used to fuse magic stones
        /// </summary>
        public MagicOptionGranter MagicOptionGranter { get; set; }

        /// <summary>
        /// The configuration for the magic option granter
        /// </summary>
        public MagicOptionsConfig MagicOptionsConfig { get; set; }

        #endregion Properties

        #region Constructor

        public Botbase()
        {
            Enhancer = new Enhancer();
            MagicOptionGranter = new MagicOptionGranter();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Starts the botbase
        /// </summary>
        public void Start()
        {
            if (Engine == Engine.Enhancement)
            {
                if (EnhancementConfig == null)
                {
                    Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                Enhancer?.Start();
            }

            if (Engine == Engine.Magic)
            {
                if (MagicOptionsConfig == null)
                {
                    Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                MagicOptionGranter?.Start();
            }
        }

        /// <summary>
        /// Stops the botbase and all managers
        /// </summary>
        public void Stop()
        {
            if (Engine == Engine.Enhancement)
                Enhancer?.Stop();

            if (Engine == Engine.Magic)
                MagicOptionGranter?.Stop();
        }

        /// <summary>
        /// Sends the run command to the current manager
        /// </summary>
        public void Tick()
        {
            switch (Engine)

            {
                case Engine.Enhancement:
                    if (EnhancementConfig == null || Enhancer == null)
                    {
                        Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                        Kernel.Bot.Stop();
                    }

                    Enhancer?.Run(EnhancementConfig);

                    break;

                case Engine.Magic:
                    if (MagicOptionGranter == null || MagicOptionsConfig == null)
                    {
                        Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                        Kernel.Bot.Stop();
                    }

                    MagicOptionGranter?.Run(MagicOptionsConfig);

                    break;
            }
        }

        #endregion Methods
    }

    internal enum Engine
    {
        Enhancement,
        Magic,
        Attribute
    }
}