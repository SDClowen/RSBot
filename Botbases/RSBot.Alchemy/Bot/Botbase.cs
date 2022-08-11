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
        /// The enhancement manager used to increase item OptLevel
        /// </summary>
        public IAlchemyEngine EnhancerEngine { get; private set; }

        /// <summary>
        /// Gets or sets the attribute granter.
        /// </summary>
        /// <value>
        /// The attribute granter.
        /// </value>
        public IAlchemyEngine AttributeEngine { get; set; }

        /// <summary>
        /// The magic option manager used to fuse magic stones
        /// </summary>
        public IAlchemyEngine MagicEngine { get; set; }

        /// <summary>
        /// The configuration for the Enhancer
        /// </summary>
        public EnhancerEngineConfig EnhancerEngineConfig { get; set; }

        /// <summary>
        /// The configuration for the magic option granter
        /// </summary>
        public MagicEngineConfig MagicEngineConfig { get; set; }

        /// <summary>
        /// Gets or sets the attributes configuration.
        /// </summary>
        /// <value>
        /// The attributes configuration.
        /// </value>
        public AttributesEngineConfig AttributesEngineConfig { get; set; }

        #endregion Properties

        #region Constructor

        public Botbase()
        {
            EnhancerEngine = new EnhancerEngine();
            MagicEngine = new MagicEngine();
            AttributeEngine = new AttributeEngine();
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
                if (EnhancerEngineConfig == null)
                {
                    Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                EnhancerEngine?.Start();
            }

            if (Engine == Engine.Magic)
            {
                if (MagicEngineConfig == null)
                {
                    Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                MagicEngine?.Start();
            }

            if (Engine == Engine.Attribute)
            {
                if (AttributesEngineConfig == null)
                {
                    Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                AttributeEngine?.Start();
            }
        }

        /// <summary>
        /// Stops the botbase and all managers
        /// </summary>
        public void Stop()
        {
            if (Engine == Engine.Enhancement)
                EnhancerEngine?.Stop();

            if (Engine == Engine.Magic)
                MagicEngine?.Stop();

            if (Engine == Engine.Attribute)
                AttributeEngine?.Stop();
        }

        /// <summary>
        /// Sends the run command to the current manager
        /// </summary>
        public void Tick()
        {
            switch (Engine)

            {
                case Engine.Enhancement:
                    if (EnhancerEngineConfig == null || EnhancerEngine == null)
                    {
                        Log.Warn("[Alchemy] Configuration issue detected!");

                        Kernel.Bot.Stop();

                        return;
                    }

                    EnhancerEngine.Run(EnhancerEngineConfig);

                    break;

                case Engine.Magic:
                    if (MagicEngine == null || MagicEngineConfig == null)
                    {
                        Log.Warn("[Alchemy] Configuration issue detected!");

                        Kernel.Bot.Stop();

                        return;
                    }

                    MagicEngine.Run(MagicEngineConfig);

                    break;

                case Engine.Attribute:
                    if (AttributeEngine == null || AttributesEngineConfig == null)
                    {
                        Log.Warn("[Alchemy] Configuration issue detected!");

                        Kernel.Bot.Stop();

                        return;
                    }

                    AttributeEngine.Run(AttributesEngineConfig);

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