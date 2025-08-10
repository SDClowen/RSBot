using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Lure.Components;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Lure.Bundle;

internal static class MovementBundle
{
    public static void Tick()
    {
        if (LureConfig.UseSpeedDrug &&
            Game.Player.State.ActiveBuffs.FindIndex(p => p.Record.Params.Contains(1752396901)) < 0)
        {
            var item = Game.Player.Inventory.GetItem(new TypeIdFilter(3, 3, 13, 1),
                p => p.Record.Desc1.Contains("_SPEED_"));
            item?.Use();
        }

        //Return to center?
        if (LureConfig.Area.Position.DistanceToPlayer() > 5 && LureConfig.StayAtCenterFor && !ScriptManager.Running)
        {
            Log.Status("Walking back to center...");

            Log.Debug("[Lure] Walking back to center");

            var moved = Game.Player.MoveTo(LureConfig.Area.Position, false);
            if (!moved)
                return;

            Log.Debug($"[Lure] Waiting at the center for {LureConfig.StayAtCenterForSeconds}s");

            EventManager.FireEvent("OnChangeStatusText",
                $"Waiting for {LureConfig.StayAtCenterForSeconds}s at center...");
            Thread.Sleep(LureConfig.StayAtCenterForSeconds * 1000);

            return;
        }

        if (LureConfig.UseScript)
        {
            if (!File.Exists(LureConfig.SelectedScriptPath))
            {
                Log.Error($"[Lure] The file for the script {LureConfig.SelectedScriptPath} does not exist!");

                Kernel.Bot.Stop();

                return;
            }

            if (ScriptManager.Running)
                return;

            Log.Status("Running lure script...");
            ScriptManager.Load(LureConfig.SelectedScriptPath);
            Task.Run(() => ScriptManager.RunScript(false));
        }

        if (LureConfig.StayAtCenter || Game.Player.Movement.Moving)
            return;

        var minDistance = LureConfig.Area.Radius / 1.5f;
        var destination = LureConfig.Area.GetRandomPosition();
        while (destination.DistanceToPlayer() < minDistance ||
               Game.Player.Position.HasCollisionBetween(destination))
            destination = LureConfig.Area.GetRandomPosition();

        Log.Status("Walking to random position...");
        Log.Debug(
            $"[Lure] Moving to random position {destination} (distance={destination.DistanceToPlayer()}, min. distance={minDistance})");
        Game.Player.MoveTo(destination);
    }
}