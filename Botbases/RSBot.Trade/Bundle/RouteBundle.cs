using System;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Trade.Components;
using System.IO;
using System.Linq;

namespace RSBot.Trade.Bundle
{
    /// <summary>
    /// This bundle is used to keep control over the scriptmanager before continuing to the next position.
    /// </summary>
    internal class RouteBundle
    {
        public string CurrentRouteFile { get; set; } = null;


        private object _lock;

        public void Initialize()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnFinishScript", OnFinishScript);
        }

        private void OnFinishScript()
        {
            if (!TradeBotbase.IsActive)
                return;
        }

        private void CheckForTownScript()
        {
            if (!TradeConfig.UseRouteScripts)
                return;

            if (!TradeConfig.RunTownScript)
                return;

            var filename = Path.Combine(ScriptManager.InitialDirectory, "Towns", Game.Player.Movement.Source.Region + ".rbs");

            //The player is in town, therefore, we need to run the town script first.
            if (!File.Exists(filename))
                return;

            Log.NotifyLang("LoadingTownScript", filename);
            
            lock (_lock)
            {
                ScriptManager.Load(filename);
                ScriptManager.RunScript(false);
            }
        }

        public void Start()
        {
            _lock = new object();
            CheckForTownScript();
        }
        

        public void Tick()
        {
            if (_lock == null)
                _lock = new object();

            lock (_lock)
            {
                if (!TradeConfig.UseRouteScripts)
                    return;

                //Interrupt in case of attack or waiting for the transport
                if (Bundles.TransportBundle.WaitingForTransport ||
                    Bundles.TransportBundle.TransportStuck ||
                    Bundles.AttackBundle.IsAttacking)
                {
                    if (ScriptManager.Running && !ScriptManager.IsPaused)
                        ScriptManager.Pause();

                    return;
                }

                if (ScriptManager.Running && !ScriptManager.IsPaused)
                    return;

                if (CurrentRouteFile == null && !ScriptManager.Running)
                {
                    var nextRouteFile = GetNextRouteFile();

                    if (nextRouteFile == null)
                    {
                        Log.Error("[Trade] No route found!");

                        Kernel.Bot.Stop();

                        return;
                    }

                    CurrentRouteFile = nextRouteFile;

                    Game.ShowNotification($"[Trade] Picked route {Path.GetFileNameWithoutExtension(nextRouteFile)}");

                    ScriptManager.Load(nextRouteFile);
                    ScriptManager.RunScript(false);

                    return;
                }
                
                if (ScriptManager.Commands == null && CurrentRouteFile != null) 
                    ScriptManager.Load(CurrentRouteFile);
                    
                ScriptManager.RunScript();
            }
        }

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
            ScriptManager.Stop();
        }
    }
}
