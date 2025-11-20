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
    public string Name => "RSBot.Training";

    public string DisplayName => "Training";

    public string TabText => DisplayName;

    public Area Area => Container.Bot.Area;

    /// <summary>
    ///     Ticks this instance. It's the botbase main-loop
    /// </summary>
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

    /// <summary>
    ///     Gets the view.
    /// </summary>
    /// <returns></returns>
    public Control View => Container.View;

    /// <summary>
    ///     Starts this instance.
    /// </summary>
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

    /// <summary>
    ///     Stops this instance.
    /// </summary>
    public void Stop()
    {
        lock (Container.Lock)
        {
            if (Game.Player.InAction)
                SkillManager.CancelAction();

            Bundles.Stop();
        }
    }

    /// <summary>
    ///     Always initialize the botbase so other botbases can make use of its otherwise internal features.
    /// </summary>
    public void Register()
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

    /// <summary>
    ///     Translate the botbase plugin
    /// </summary>
    /// <param name="language">The language</param>
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }
}
