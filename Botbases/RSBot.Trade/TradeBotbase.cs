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
    /// Gets a value indicating whether the trade botbase is currently active and running.
    /// </summary>
    public static bool IsActive => Kernel.Bot?.Botbase.Name == "RSBot.Trade" && Kernel.Bot.Running;

    /// <inheritdoc />
    public string Author => "RSBot Team";

    /// <inheritdoc />
    public string Description => "Botbase focused on trading goods in the best areas of the game.";

    /// <inheritdoc />
    public string Name => "RSBot.Trade";

    /// <inheritdoc />
    public string Title => "Trade";

    /// <inheritdoc />
    public string Version => "1.0.0";

    /// <inheritdoc />
    public bool Enabled { get; set; }

    /// <inheritdoc />
    public Area Area => new();

    /// <inheritdoc />
    public void Tick()
    {
        if (!Game.Ready || Game.Player == null)
            return;

        Bundles.Tick();
    }

    /// <inheritdoc />
    public Control View => Views.View.Main;


    /// <inheritdoc />
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

    /// <inheritdoc />
    public void Stop()
    {
        Bundles.Stop();
    }

    /// <inheritdoc />
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <summary>
    /// Determines whether the current player is considered a trader based on job type and equipped items.
    /// </summary>
    /// <remarks>A player is considered a trader if they have the appropriate job type and are wearing the
    /// required job outfit. The criteria may vary depending on the game client type.</remarks>
    /// <returns>true if the player meets all criteria to be recognized as a trader; otherwise, false.</returns>
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
        Log.Debug("[Trade] Botbase registered to the kernel!");

        ScriptManager.CommandHandlers.Add(new BuyGoodsScriptCommand());

        Bundles.Initialize();
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
