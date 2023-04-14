using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Trade.Components;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RSBot.Core.Objects.Spawn;
using SDUI.Controls;

namespace RSBot.Trade.Bundle;

/// <summary>
/// This bundle is used to keep control over the script manager before continuing to the next position.
/// </summary>
internal class RouteBundle
{
    public string CurrentRouteFile { get; set; }

    public bool TownscriptRunning { get; private set; }
        
    private bool _checkForTownScript;
    private bool _lastScriptIsTownScript;
    private bool _blockedByRouteDialog;

    public void Initialize()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnFinishScript", OnFinishScript);
    }

    /// <summary>
    /// Triggered when a script is finished.
    /// </summary>
    private void OnFinishScript()
    {
        TownscriptRunning = false;

        if (!TradeBotbase.IsActive)
            return;

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
    /// Checks and runs the townscript.
    /// </summary>
    private string CheckForTownScript()
    {
        if (!TradeConfig.UseRouteScripts)
            return null;

        if (!TradeConfig.RunTownScript)
            return null;

        var filename = Path.Combine(ScriptManager.InitialDirectory, "Towns", Game.Player.Movement.Source.Region + ".rbs");

        //The player is in town, therefore, we need to run the town script first.
        if (!File.Exists(filename))
            return null;

        Log.NotifyLang("LoadingTownScript", filename);

        return filename;
    }

    public void Start()
    {
        CurrentRouteFile = null;
        TownscriptRunning = false;

        if (TradeConfig.TracePlayer)
            return;

        _lastScriptIsTownScript = false;
        _checkForTownScript = true;
    }

    public void Tick()
    {
        if (TradeConfig.TracePlayer)
        {
            CheckTracePlayer();

            return;
        }

        if (!TradeConfig.UseRouteScripts)
            return;

        if (_blockedByRouteDialog)
            return;
            
        //Interrupt in case of attack or waiting for the transport
        if (ScriptManager.Running &&
            Bundles.TransportBundle.BlockProgression ||
            Bundles.AttackBundle.BlockProgression)
        {
            if (!ScriptManager.Paused)
                ScriptManager.Pause();

            return;
        }

        //Run town script
        if (_checkForTownScript && !_lastScriptIsTownScript)
        {
            CurrentRouteFile = CheckForTownScript();

            if (CurrentRouteFile != null)
            {
                _checkForTownScript = false;
                _lastScriptIsTownScript = true;
                TownscriptRunning = true;

                ScriptManager.Load(CurrentRouteFile);
                ScriptManager.RunScript(false);

                CurrentRouteFile = null;

                _lastScriptIsTownScript = false;

                return;
            }
        }

        //Nothing more to do, skip tick
        if (ScriptManager.Running && !ScriptManager.Paused)
            return;

        //Pick next route
        if (CurrentRouteFile == null && !ScriptManager.Running && TradeBotbase.IsActive && !_blockedByRouteDialog)
        {
            CurrentRouteFile = GetNextRouteFile() ?? ShowRouteDialog();

            if (CurrentRouteFile == null)
            {
                Log.Warn("[Trade] Could not find the next route!");
                Kernel.Bot.Stop();

                return;
            }

            _blockedByRouteDialog = false;

            Game.ShowNotification($"[RSBot] Picked trade route {Path.GetFileNameWithoutExtension(CurrentRouteFile)}");

            //Start at the first line of the script
            ScriptManager.Load(CurrentRouteFile);
            ScriptManager.RunScript(false);

            return;
        }

        if (!ScriptManager.Running && CurrentRouteFile != null)
            ScriptManager.Load(CurrentRouteFile);

        //Continue previous script
        if (!ScriptManager.Running || ScriptManager.Paused)
            ScriptManager.RunScript();
    }

    private void CheckTracePlayer()
    {
        if (string.IsNullOrEmpty(TradeConfig.TracePlayerName))
            return;

        if (!SpawnManager.TryGetEntity<SpawnedPlayer>(p => p.Name == TradeConfig.TracePlayerName, out var player))
            return;

        Game.Player.MoveTo(player.Position);
    }

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
    /// Returns the route file name
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

        //ToDo: Shuffle next route
        foreach (var file in TradeConfig.RouteScripts[selectedRouteList])
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

    public void Stop()
    {
        _blockedByRouteDialog = false;
        _lastScriptIsTownScript = false;
        CurrentRouteFile = null;
        TownscriptRunning = false;

        ScriptManager.Stop();
    }
}