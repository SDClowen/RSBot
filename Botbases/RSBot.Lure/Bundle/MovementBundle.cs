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
        // Hız iksiri kullanma ayarı aktifse ve karakterde hız buff'ı yoksa, iksiri kullan.
        if (LureConfig.UseSpeedDrug &&
            Game.Player.State.ActiveBuffs.FindIndex(p => p.Record.Params.Contains(1752396901)) < 0)
        {
            var item = Game.Player.Inventory.GetItem(new TypeIdFilter(3, 3, 13, 1),
                p => p.Record.Desc1.Contains("_SPEED_"));
            item?.Use();
        }

        // Merkeze dönme ve bekleme mantığı: Script çalışmıyorken merkezden uzaklaşılmışsa...
        if (LureConfig.Area.Position.DistanceToPlayer() > 5 && LureConfig.StayAtCenterFor && !ScriptManager.Running)
        {
            Log.Status("Walking back to center...");

            // Merkeze yürü.
            var moved = Game.Player.MoveTo(LureConfig.Area.Position, false);
            if (!moved)
                return;

            // Ayarlanan süre kadar merkezde bekle. Bu, canavarların toplanması için zaman tanır.
            Log.Debug($"[Lure] Waiting at the center for {LureConfig.StayAtCenterForSeconds}s");
            EventManager.FireEvent("OnChangeStatusText",
                $"Waiting for {LureConfig.StayAtCenterForSeconds}s at center...");
            Thread.Sleep(LureConfig.StayAtCenterForSeconds * 1000);

            return;
        }

        // Lure (yaratık çekme) script'i kullanma mantığı.
        if (LureConfig.UseScript)
        {
            if (!File.Exists(LureConfig.SelectedScriptPath))
            {
                Log.Error($"[Lure] The file for the script {LureConfig.SelectedScriptPath} does not exist!");
                Kernel.Bot.Stop();
                return;
            }

            // Script zaten çalışıyorsa, başka bir hareket komutu gönderme.
            if (ScriptManager.Running)
                return;

            // Script'i yükle ve asenkron olarak çalıştır.
            Log.Status("Running lure script...");
            ScriptManager.Load(LureConfig.SelectedScriptPath);
            Task.Run(() => ScriptManager.RunScript(false));
        }

        // Merkezde bekleme modu aktifse veya oyuncu zaten hareket ediyorsa, yeni komut gönderme.
        if (LureConfig.StayAtCenter || Game.Player.Movement.Moving)
            return;

        // Rastgele hareket mantığı: Canavarları daha iyi çekmek için alanın merkezinden uzakta bir nokta seç.
        var minDistance = LureConfig.Area.Radius / 1.5f;
        var destination = LureConfig.Area.GetRandomPosition();
        while (destination.DistanceToPlayer() < minDistance ||
               Game.Player.Position.HasCollisionBetween(destination))
            destination = LureConfig.Area.GetRandomPosition();

        Log.Status("Walking to random position...");
        Game.Player.MoveTo(destination);
    }
}