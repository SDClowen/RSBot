using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RSBot.Alchemy.Bot;
using RSBot.Alchemy.Extension;
using RSBot.Alchemy.Helper;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Alchemy.Bundle.Enhance;

internal class EnhanceBundle : IAlchemyBundle
{
    private EnhanceBundleConfig _config;

    private bool _isStoneFusing;

    #region Constructor

    /// <summary>
    ///     Subscribes events
    /// </summary>
    public EnhanceBundle()
    {
        SubscribeEvents();

        _shouldRun = true;
    }

    #endregion Constructor

    #region Members

    private bool _shouldRun;

    private IEnumerable<InventoryItem> _luckyPowders;

    #endregion Members

    #region Methods

    public void Stop()
    {
        _shouldRun = false;
        _config = null;

        AlchemyManager.CancelPending();
    }

    /// <summary>
    ///     Starts this manager
    /// </summary>
    public void Start()
    {
        _shouldRun = true;
    }

    /// <summary>
    ///     Subscribes all required events
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent(
            "OnAlchemyDestroyed",
            new Action<InventoryItem, AlchemyType>(OnElixirAlchemyDestroyed)
        );
        EventManager.SubscribeEvent(
            "OnAlchemySuccess",
            new Action<InventoryItem, InventoryItem, AlchemyType>(OnElixirAlchemySuccess)
        );
        EventManager.SubscribeEvent("OnAlchemy", OnElixirAlchemy);
        EventManager.SubscribeEvent(
            "OnAlchemyFailed",
            new Action<InventoryItem, InventoryItem, AlchemyType>(OnElixirAlchemyFailed)
        );
        EventManager.SubscribeEvent("OnFuseRequest", new Action<AlchemyAction, AlchemyType>(OnFuseRequest));
    }

    /// <summary>
    ///     Runs a new tick of this manager
    /// </summary>
    /// <param name="engineConfig"></param>
    public void Run<T>(T engineConfig)
    {
        if (engineConfig is not EnhanceBundleConfig config)
            return;

        if (config.Item == null)
        {
            Log.Warn("[Alchemy] No item configured");
            Kernel.Bot.Stop();

            return;
        }

        //Item still there and available?
        var item = Game.Player.Inventory.GetItemAt(config.Item.Slot);
        if (item == null || item.Amount == 0)
        {
            Log.Warn("[Alchemy] Item to enhance is unavailable");
            Kernel.Bot.Stop();

            return;
        }

        //Config incomplete?
        if (!_shouldRun || Globals.Botbase.AlchemyEngine != AlchemyEngine.Enhance)
            return;

        if (config.Elixirs == null || !config.Elixirs.Any() || config.Elixirs.Sum(i => i.Amount) == 0)
        {
            Log.Warn("[Alchemy] No enhancement elixir selected");
            Kernel.Bot.Stop();

            return;
        }

        _config = config;
        _luckyPowders = AlchemyItemHelper.GetLuckyPowders(config.Item);

        //Bot should stop without lucky powder?
        if (!_luckyPowders.Any() && config.StopIfLuckyPowderEmpty)
        {
            Log.Warn("[Alchemy] No lucky powder left, stopping alchemy now!");

            Kernel.Bot.Stop();
            MessageBox.Show(
                "No more lucky powder left in the inventory.",
                "Lucky powder",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        //Max opt level reached?
        if (config.Item.OptLevel >= config.MaxOptLevel)
        {
            Log.Warn($"[Alchemy] Item is already +{config.Item.OptLevel}");

            Globals.View.AddLog(
                config.Item.Record.GetRealName(),
                $"The item's option level is {config.Item.OptLevel}/{config.MaxOptLevel}"
            );
            Kernel.Bot.Stop();

            return;
        }

        //Use steady stone?
        if (_config.UseSteadyStones && _config.Item.OptLevel >= 5)
        {
            var steadyStone = AlchemyItemHelper.GetSteadyStone(config.Item);

            if (
                steadyStone != null
                && steadyStone.Amount > 0
                && !AlchemyItemHelper.HasMagicOption(config.Item, RefMagicOpt.MaterialSteady)
            )
            {
                if (!AlchemyManager.TryFuseMagicStone(_config.Item, steadyStone))
                    return;

                _shouldRun = false;
                _isStoneFusing = true;

                return;
            }
        }

        //Use lucky stone?
        if (_config.UseLuckyStones && _config.Item.OptLevel >= 5)
        {
            var luckyStone = AlchemyItemHelper.GetLuckyStone(config.Item);

            if (
                luckyStone != null
                && luckyStone.Amount > 0
                && !AlchemyItemHelper.HasMagicOption(config.Item, RefMagicOpt.MaterialLuck)
            )
            {
                if (!AlchemyManager.TryFuseMagicStone(_config.Item, luckyStone))
                    return;

                _shouldRun = false;
                _isStoneFusing = true;

                return;
            }
        }

        //Use immortal stone?
        if (_config.UseImmortalStones && _config.Item.OptLevel >= 5)
        {
            var immortalStone = AlchemyItemHelper.GetImmortalStone(config.Item);

            if (
                immortalStone?.Amount > 0
                && !AlchemyItemHelper.HasMagicOption(config.Item, RefMagicOpt.MaterialImmortal)
            )
            {
                if (!AlchemyManager.TryFuseMagicStone(_config.Item, immortalStone))
                    return;

                _shouldRun = false;
                _isStoneFusing = true;

                return;
            }
        }

        //Use astral stone?
        if (_config.UseAstralStones && _config.Item.OptLevel >= 5)
        {
            var astralStone = AlchemyItemHelper.GetAstralStone(config.Item);

            if (
                astralStone != null
                && astralStone.Amount > 0
                && !AlchemyItemHelper.HasMagicOption(config.Item, RefMagicOpt.MaterialAstral)
            )
            {
                //Is immortal high enough?
                var magicOption = Game.ReferenceManager.GetMagicOption(
                    RefMagicOpt.MaterialImmortal,
                    (byte)config.Item.Record.Degree
                );

                //Can not fuse if immortal is not available (or not high enough)
                var magicOptionInfo = config.Item.MagicOptions?.FirstOrDefault(m => m.Id == magicOption.Id);
                if (magicOptionInfo == null)
                {
                    Log.Notify(
                        $"[Alchemy] Could not fuse {astralStone.Record.GetRealName()} because the immortality option is not high enough"
                    );

                    _config.UseAstralStones = false;
                    return;
                }

                if (!AlchemyManager.TryFuseMagicStone(_config.Item, astralStone))
                    return;

                _shouldRun = false;
                _isStoneFusing = true;

                return;
            }
        }

        var nextPlusValue = config.Item.OptLevel + 1;

        Log.Notify($"[Alchemy] Attempting +{nextPlusValue}...");

        SendFusePacket();

        _shouldRun = false;
    }

    /// <summary>
    ///     Sends the fuse packet to the server
    /// </summary>
    private void SendFusePacket()
    {
        if (_config == null || !_shouldRun || !_config.Elixirs.Any())
            return;

        var powder = _luckyPowders.FirstOrDefault();
        var elixir = Game.Player.Inventory.GetItem(_config.Elixirs.First().ItemId);

        AlchemyManager.TryFuseElixir(_config.Item, elixir, powder);
    }

    #endregion Methods

    #region Events

    /// <summary>
    ///     Will be triggered if any elixir alchemy operation was completed
    /// </summary>
    private void OnElixirAlchemy()
    {
        _shouldRun = true;
    }

    /// <summary>
    ///     Will be triggered if any elixir alchemy operation was successful
    /// </summary>
    /// <param name="newItem"></param>
    private void OnElixirAlchemySuccess(InventoryItem oldItem, InventoryItem newItem, AlchemyType type)
    {
        if (Globals.Botbase.AlchemyEngine != AlchemyEngine.Enhance)
            return;

        //After fusing a magic stone (steady, astral & co.) tell the bot to continue to fuse elixirs!
        if (Bootstrap.IsActive && _isStoneFusing)
        {
            _shouldRun = true;
            _isStoneFusing = false;
        }

        if (type != AlchemyType.Elixir)
            return;

        var message = Game
            .ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_SUCCESS")
            .JoymaxFormat(newItem.OptLevel);

        Log.Notify(message);
        Globals.View.AddLog(newItem.Record.GetRealName(), message);

        if (_config != null)
            _config.Item = newItem;

        _shouldRun = true;
    }

    /// <summary>
    ///     Will be triggered if the selected item was destroyed. Logs a message and stops the bot
    /// </summary>
    /// <param name="oldItem">The the item that has been destroyed</param>
    /// <param name="type">The type of alchemy that was triggered</param>
    private void OnElixirAlchemyDestroyed(InventoryItem oldItem, AlchemyType type)
    {
        _shouldRun = false;
    }

    /// <summary>
    ///     Will be triggered if any elixir alchemy operation has failed. Logs a message and resets the current item
    /// </summary>
    /// <param name="newItem">The new item after the action has failed</param>
    /// <param name="type">The type of alchemy that was triggered</param>
    private void OnElixirAlchemyFailed(InventoryItem oldItem, InventoryItem newItem, AlchemyType type)
    {
        if (type != AlchemyType.Elixir)
            return;

        _shouldRun = true;
        var message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL");
        Log.Warn(message);
        Globals.View.AddLog(newItem.Record.GetRealName(), message);

        if (oldItem == null)
            return;

        message = string.Empty;
        if (newItem.Durability < oldItem.Durability)
            message = Game
                .ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAILDOWN_DURABILITY")
                .JoymaxFormat(newItem.Durability);

        if (oldItem.OptLevel > 0 && newItem.OptLevel == 0)
            message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL_RESULT_OPTLV_ZERO");

        if (oldItem.OptLevel > 0 && oldItem.OptLevel < newItem.OptLevel)
            message = Game
                .ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL_RESULT_OPTLV_DOWN")
                .JoymaxFormat(newItem.OptLevel, _config.Item.OptLevel - newItem.OptLevel);

        //Additional message
        if (message != string.Empty)
        {
            Log.Debug(message);
            Globals.View.AddLog(newItem.Record.GetRealName(), message);
        }

        if (_config != null)
            _config.Item = newItem;
    }

    /// <summary>
    ///     Called when [fuse request].
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="type">The type.</param>
    private void OnFuseRequest(AlchemyAction action, AlchemyType type)
    {
        _shouldRun = false;
    }

    #endregion Events
}
