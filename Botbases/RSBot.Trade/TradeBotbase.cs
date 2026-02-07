using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Plugins;
using RSBot.Trade.Bundle;
using RSBot.Trade.Components.Scripting;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Trade;

public class TradeBotbase : IBotbase
{
    /// <summary>
    /// Gets or sets a value indicating whether the feature is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    public static bool IsActive => Kernel.Bot?.Botbase.InternalName == "RSBot.Trade" && Kernel.Bot.Running;
    public string InternalName => "RSBot.Trade";

    public string DisplayName => "Trade";

    public string TabText => DisplayName;

    public Area Area => new();

    /// <summary>
    ///     Ticks this instance. It's the botbase main-loop
    /// </summary>
    public void Tick()
    {
        if (!Game.Ready || Game.Player == null)
            return;

        Bundles.Tick();
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
        if (!AssertPlayerIsTrader())
        {
            MessageBox.Show(
                "The active character can't trade goods! Make sure that you have the correct job and suite equiped.",
                "Can't trade",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
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
    ///     Triggered after the botbase was registered to the kernel.
    /// </summary>
    public void Register()
    {
        Log.Debug("[Trade] Botbase registered to the kernel!");

        ScriptManager.CommandHandlers.Add(new BuyGoodsScriptCommand());

        Bundles.Initialize();
    }

    /// <summary>
    ///     Translate the botbase plugin
    /// </summary>
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <summary>
    ///     Returns a value indicating if the active character is a trader
    /// </summary>
    /// <returns></returns>
    private bool AssertPlayerIsTrader()
    {
        if (Game.Player == null)
            return false;

        var gameIsJob2 = Game.ClientType > GameClientType.Vietnam;
        if (!gameIsJob2 && Game.Player.JobInformation is not { Type: JobType.Trade })
            return false;
        else if (gameIsJob2 && Game.Player.JobInformation is { Type: JobType.None })
            return false;

        if (Game.Player.Inventory.GetEquippedPartItems().FirstOrDefault(i => i.Record.IsJobOutfit) == null)
            return false;

        return true;
    }

    /// <inheritdoc />
    public void Initialize()
    {
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
