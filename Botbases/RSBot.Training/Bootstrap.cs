using System;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Plugins;
using RSBot.Training.Bot;
using RSBot.Training.Bundle;
using RSBot.Training.Components;
using RSBot.Training.Subscriber;

namespace RSBot.Training;

public class Bootstrap : IBotbase
{
    /// <inheritdoc />
    public string Author => "RSBot Team";

    /// <inheritdoc />
    public string Description => "Botbase focused on training in the best areas of the game.";

    /// <inheritdoc />
    public string Name => "RSBot.Training";

    /// <inheritdoc />
    public string Title => "Training";

    /// <inheritdoc />
    public string Version => "1.0.0";

    /// <inheritdoc />
    public bool Enabled { get; set; }

    /// <inheritdoc />
    public Area Area => Container.Bot.Area;

    /// <inheritdoc />
    public void Tick()
    {
        if (!Kernel.Bot.Running)
            return;

        if (Game.Player.Exchanging)
            return;

        if (Game.Player.Untouchable)
            return;

        if (Game.Player.State.LifeState == LifeState.Dead)
            return;

        //Begin the loopback if needed
        if (Container.Bot.Area.Position.DistanceToPlayer() > 80)
            Bundles.Loop.Start();

        if (Bundles.Loop.Running)
            return;

        //Nothing if in scroll state!
        if (
            Game.Player.State.ScrollState == ScrollState.NormalScroll
            || Game.Player.State.ScrollState == ScrollState.ThiefScroll
        )
            return;

        try
        {
            Container.Bot.Tick();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex);
        }
    }

    /// <inheritdoc />
    public Control View => Container.View;

    /// <inheritdoc />
    public void Start()
    {
        if (Kernel.Bot.Botbase.Area.Position.X == 0)
        {
            Log.WarnLang("ConfigureTrainingAreaBeforeStartBot");
            Kernel.Bot.Stop();
        }

        //Already reloading when config saved via ConfigSubscriber
        //Bundles.Reload();
        //Container.Bot.Reload();
    }

    /// <inheritdoc />
    public void Stop()
    {
        lock (Container.Lock)
        {
            if (Game.Player.InAction)
                SkillManager.CancelAction();

            Bundles.Stop();
        }
    }

    /// <inheritdoc />
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <inheritdoc />
    public void Initialize()
    {
        Container.Lock = new object();
        Container.Bot = new Botbase();

        //Bundles.Reload();

        BundleSubscriber.SubscribeEvents();
        ConfigSubscriber.SubscribeEvents();
        TeleportSubscriber.SubscribeEvents();

        ScriptManager.CommandHandlers.Add(new TrainingAreaScriptCommand());
        Log.Debug("[Training] Botbase registered to the kernel!");
    }

    /// <inheritdoc />
    public void Enable()
    {
        if (View != null)
            View.Enabled = true;
    }

    /// <inheritdoc />
    public void Disable()
    {
        if (View != null)
            View.Enabled = false;
    }
}
