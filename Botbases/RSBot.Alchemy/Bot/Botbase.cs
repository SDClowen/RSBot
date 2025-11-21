using RSBot.Alchemy.Bundle;
using RSBot.Alchemy.Bundle.Attribute;
using RSBot.Alchemy.Bundle.Enhance;
using RSBot.Alchemy.Bundle.Magic;
using RSBot.Core;

namespace RSBot.Alchemy.Bot;

internal class Botbase
{
    #region Constructor

    public Botbase()
    {
        EnhanceBundle = new EnhanceBundle();
        MagicBundle = new MagicBundle();
        AttributeBundle = new AttributeBundle();
    }

    #endregion Constructor

    #region Properties

    /// <summary>
    ///     The selected botbase engine
    /// </summary>
    public AlchemyEngine AlchemyEngine { get; set; }

    /// <summary>
    ///     The enhancement manager used to increase item OptLevel
    /// </summary>
    public IAlchemyBundle EnhanceBundle { get; }

    /// <summary>
    ///     Gets or sets the attribute granter.
    /// </summary>
    /// <value>
    ///     The attribute granter.
    /// </value>
    public IAlchemyBundle AttributeBundle { get; set; }

    /// <summary>
    ///     The magic option manager used to fuse magic stones
    /// </summary>
    public IAlchemyBundle MagicBundle { get; set; }

    /// <summary>
    ///     The configuration for the Enhancer
    /// </summary>
    public EnhanceBundleConfig EnhanceBundleConfig { get; set; }

    /// <summary>
    ///     The configuration for the magic option granter
    /// </summary>
    public MagicBundleConfig MagicBundleConfig { get; set; }

    /// <summary>
    ///     Gets or sets the attributes configuration.
    /// </summary>
    /// <value>
    ///     The attributes configuration.
    /// </value>
    public AttributeBundleConfig AttributeBundleConfig { get; set; }

    #endregion Properties

    #region Methods

    /// <summary>
    ///     Starts the botbase
    /// </summary>
    public void Start()
    {
        if (AlchemyEngine == AlchemyEngine.Enhance)
        {
            if (EnhanceBundleConfig == null)
            {
                Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                Kernel.Bot.Stop();

                return;
            }

            EnhanceBundle?.Start();
        }

        if (AlchemyEngine == AlchemyEngine.Magic)
        {
            if (MagicBundleConfig == null)
            {
                Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                Kernel.Bot.Stop();

                return;
            }

            MagicBundle?.Start();
        }

        if (AlchemyEngine == AlchemyEngine.Attribute)
        {
            if (AttributeBundleConfig == null)
            {
                Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                Kernel.Bot.Stop();

                return;
            }

            AttributeBundle?.Start();
        }
    }

    /// <summary>
    ///     Stops the botbase and all managers
    /// </summary>
    public void Stop()
    {
        if (AlchemyEngine == AlchemyEngine.Enhance)
            EnhanceBundle?.Stop();

        if (AlchemyEngine == AlchemyEngine.Magic)
            MagicBundle?.Stop();

        if (AlchemyEngine == AlchemyEngine.Attribute)
            AttributeBundle?.Stop();
    }

    /// <summary>
    ///     Sends the run command to the current manager
    /// </summary>
    public void Tick()
    {
        switch (AlchemyEngine)
        {
            case AlchemyEngine.Enhance:
                if (EnhanceBundleConfig == null || EnhanceBundle == null)
                {
                    Log.Warn("[Alchemy] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                EnhanceBundle.Run(EnhanceBundleConfig);

                break;

            case AlchemyEngine.Magic:
                if (MagicBundle == null || MagicBundleConfig == null)
                {
                    Log.Warn("[Alchemy] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                MagicBundle.Run(MagicBundleConfig);

                break;

            case AlchemyEngine.Attribute:
                if (AttributeBundle == null || AttributeBundleConfig == null)
                {
                    Log.Warn("[Alchemy] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                AttributeBundle.Run(AttributeBundleConfig);

                break;
        }
    }

    #endregion Methods
}

internal enum AlchemyEngine
{
    Enhance,
    Magic,
    Attribute,
}
