using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using RSBot.Trade.Components;
using SDUI.Controls;

namespace RSBot.Trade.Bundle;

/// <summary>
///     This bundle is used to keep control over the script manager before continuing to the next position.
/// </summary>
internal class RouteBundle
{
    private bool _blockedByRouteDialog;
    private bool _checkForTownScript;
    private bool _lastScriptIsTownScript;

    /// <summary>
    ///     The current route file. This could ether be a trade route or a town script.
    /// </summary>
    public string CurrentRouteFile { get; set; }

    /// <summary>
    ///     A value indicating if the town script is running.
    /// </summary>
    public bool TownscriptRunning { get; private set; }

    /// <summary>
    ///     A value indicating if the bot is waiting for a hunter.
    /// </summary>
    public bool WaitingForHunter { get; private set; }

    /// <summary>
    ///     A value indicating if the bot is waiting for a player to trace nearby.
    /// </summary>
    public bool WaitingForTracePlayer { get; private set; }

    /// <summary>
    ///     A value indicating if the bot is in a state of executing a command
    /// </summary>
    public bool ScriptManaggerIsRunning { get => ScriptManager.Running; }

    /// <summary>
    ///     Initializes the bundle.
    /// </summary>
    public void Initialize()
    {
        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnFinishScript", new Action<bool>(OnFinishScript));
    }

    /// <summary>
    ///     Triggered when a script is finished.
    /// </summary>
    private void OnFinishScript(bool error)
    {
        //Error during script execution -> Keep the current script and reload it to retry in the next tick cycle.
        if (error)
            return;

        if (!TradeBotbase.IsActive || !Game.Ready)
            return;

        TownscriptRunning = false;
        CurrentRouteFile = null;

        //Townscript finished?
        if (!_lastScriptIsTownScript)
        {
            _checkForTownScript = true;

            return;
        }

        _checkForTownScript = false;
        _lastScriptIsTownScript = false;
    }

    /// <summary>
    ///     Checks and runs the townscript.
    /// </summary>
    private string CheckForTownScript()
    {
        if (!TradeConfig.UseRouteScripts)
            return null;

        if (!TradeConfig.RunTownScript)
            return null;

        var filename = Path.Combine(ScriptManager.InitialDirectory, "Towns",
            Game.Player.Movement.Source.Region + ".rbs");

        if (!File.Exists(filename))
            return null;

        Log.NotifyLang("LoadingTownScript", filename);

        return filename;
    }

    /// <summary>
    ///     Starts the bundle.
    /// </summary>
    public void Start()
    {
        CurrentRouteFile = null;
        TownscriptRunning = false;
        WaitingForHunter = false;
        WaitingForTracePlayer = false;

        _lastScriptIsTownScript = false;
        _checkForTownScript = !TradeConfig.TracePlayer; //Don't check for town script if bot is set to trace mode!
    }

    /// <summary>
    ///     Ticks the route bundle
    /// </summary>
    public void Tick()
    {
        //Wait for player to revive
        if (Game.Player.State.LifeState == LifeState.Dead)
        {
            Log.Status("Waiting for resurrection");

            if (ScriptManager.Running && !ScriptManager.Paused)
                ScriptManager.Pause();

            return;
        }

        if (ShoppingManager.Running)
            return;

        //Interrupt in case of attack or waiting for the transport
        if ((ScriptManager.Running &&
             Bundles.TransportBundle.Busy) ||
            Bundles.AttackBundle.Busy)
        {
            if (!ScriptManager.Paused && ScriptManager.Running)
                ScriptManager.Pause();

            return;
        }

        if (_blockedByRouteDialog)
            return;

        //Can continue?
        if (!CheckHunterNearby() || !CheckTracePlayer())
            return;

        if (!TradeConfig.UseRouteScripts)
            return;

        if (Game.Player.Movement.HasDestination)
            return;

        //Run town script
        if (_checkForTownScript && !_lastScriptIsTownScript)
        {
            CurrentRouteFile = CheckForTownScript();
            _checkForTownScript = false;

            if (CurrentRouteFile != null)
            {
                _lastScriptIsTownScript = true;
                TownscriptRunning = true;

                ScriptManager.Load(CurrentRouteFile);
                Task.Run(() => ScriptManager.RunScript(false));

                Thread.Sleep(100);

                return;
            }

            TownscriptRunning = false;
        }

        //Nothing more to do, skip tick
        if (ScriptManager.Running && !ScriptManager.Paused)
            return;

        //Pick next route
        if (CurrentRouteFile == null && !ScriptManager.Running && TradeBotbase.IsActive && !_blockedByRouteDialog)
        {
            var restartNearby = false;

            CurrentRouteFile = GetNextRouteFile();
            if (CurrentRouteFile == null)
            {
                CurrentRouteFile = ShowRouteDialog();
                restartNearby = true;
            }

            if (CurrentRouteFile == null)
            {
                Log.Warn("[Trade] Could not find the next route!");
                Kernel.Bot.Stop();

                return;
            }

            _blockedByRouteDialog = false;

            Game.ShowNotification($"[RSBot] Picked trade route {Path.GetFileNameWithoutExtension(CurrentRouteFile)}");

            ScriptManager.Load(CurrentRouteFile);
            Task.Run(() => ScriptManager.RunScript(restartNearby));

            Thread.Sleep(100);

            return;
        }

        if (!ScriptManager.Running && CurrentRouteFile != null)
            ScriptManager.Load(CurrentRouteFile);

        //Continue previous script
        if ((!Game.Player.InAction && !ScriptManager.Running) || ScriptManager.Paused)
        {
            Task.Run(() => ScriptManager.RunScript());

            //Make sure that the next tick the script manager is ready
            Thread.Sleep(100);
        }
    }

    /// <summary>
    ///     Returns a value indicating if a hunter is nearby.
    /// </summary>
    /// <returns></returns>
    private bool CheckHunterNearby()
    {
        var hunterNearby = !TradeConfig.WaitForHunter || SpawnManager.TryGetEntity<SpawnedPlayer>(
            p => p.WearsJobSuite && p.Job == JobType.Hunter,
            out _);

        WaitingForHunter = !hunterNearby;

        if (WaitingForHunter)
            Log.Status("Waiting for a hunter nearby...");

        return hunterNearby;
    }

    /// <summary>
    ///     Checks for the player to trace nearby (if configured)
    /// </summary>
    private bool CheckTracePlayer()
    {
        if (TradeConfig.UseRouteScripts)
        {
            WaitingForTracePlayer = false;

            return true;
        }

        if (string.IsNullOrEmpty(TradeConfig.TracePlayerName))
        {
            WaitingForTracePlayer = false;

            Log.Error("[Trade] Enter a name for a player to trace and try again.");

            Kernel.Bot.Stop();

            return false;
        }

        if (!SpawnManager.TryGetEntity<SpawnedPlayer>(p => p.Name == TradeConfig.TracePlayerName, out var player))
        {
            Log.Status($"Waiting for {TradeConfig.TracePlayerName} to trace");
            WaitingForTracePlayer = true;

            return false;
        }

        WaitingForTracePlayer = false;

        Game.Player.MoveTo(player.Position);

        return true;
    }

    /// <summary>
    ///     Shows the route picker dialog and waits for user input.
    /// </summary>
    /// <returns></returns>
    private string ShowRouteDialog()
    {
        _blockedByRouteDialog = true;

        var inputDialog = new InputDialog("Select route", "Select route",
            "Select the route to start from at the current location.", InputDialog.InputType.Combobox)
        {
            TopLevel = true,
            StartPosition = FormStartPosition.CenterScreen,
            ShowInTaskbar = true
        };

        if (TradeConfig.RouteScriptList.Count < TradeConfig.SelectedRouteListIndex)
            return null;

        var selectedRouteList = TradeConfig.RouteScriptList[TradeConfig.SelectedRouteListIndex];
        if (selectedRouteList == null || !TradeConfig.RouteScripts.ContainsKey(selectedRouteList))
            return null;

        foreach (var fileName in TradeConfig.RouteScripts[selectedRouteList]
                     .Select(Path.GetFileNameWithoutExtension))
            inputDialog.Selector.Items.Add(fileName);

        if (inputDialog.ShowDialog(Application.OpenForms[0]) != DialogResult.OK)
        {
            Log.Error("[Trade] No route found!");

            Kernel.Bot.Stop();

            _blockedByRouteDialog = false;

            return null;
        }

        _blockedByRouteDialog = false;

        return TradeConfig.RouteScripts[selectedRouteList].FirstOrDefault(s =>
            Path.GetFileNameWithoutExtension(s) == inputDialog.Selector.SelectedItem.ToString());
    }


    /// <summary>
    ///     Returns the route file name
    /// </summary>
    /// <returns></returns>
    public string GetNextRouteFile()
    {
        var selectedRouteList = TradeConfig.RouteScriptList[TradeConfig.SelectedRouteListIndex];

        if (!TradeConfig.RouteScripts.ContainsKey(selectedRouteList))
        {
            Log.Warn("[Trade] Next route not found!");

            return null;
        }

        var random = new Random();

        //Randomize next route
        foreach (var file in TradeConfig.RouteScripts[selectedRouteList]
                     .OrderBy(_ => random.Next(0, 100)))
        {
            ScriptManager.Load(file);

            var walkScript = ScriptManager.GetWalkScript();
            if (walkScript == null || walkScript.Count == 0)
                continue;

            var startPosition = walkScript.FirstOrDefault();
            if (startPosition.Region.Id != Game.Player.Position.Region.Id)
                continue;

            return file;
        }

        return null;
    }

    /// <summary>
    ///     Stops the bundle
    /// </summary>
    public void Stop()
    {
        CurrentRouteFile = null;
        TownscriptRunning = false;
        WaitingForHunter = false;
        WaitingForTracePlayer = false;

        _blockedByRouteDialog = false;
        _lastScriptIsTownScript = false;

        ScriptManager.Stop();
    }
}