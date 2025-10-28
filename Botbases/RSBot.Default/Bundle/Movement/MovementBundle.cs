using System.Threading;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Default.Bundle.Movement;

internal class MovementBundle : IBundle
{
    /// <summary>
    ///     Gets or sets the configuration.
    /// </summary>
    /// <value>
    ///     The configuration.
    /// </value>
    public MovementConfig Config { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [last entity was behind obstacle].
    ///     Used to move around even though the player is being attacked.
    /// </summary>
    /// <value>
    ///     <c>true</c> if [last entity was behind obstacle]; otherwise, <c>false</c>.
    /// </value>
    public bool LastEntityWasBehindObstacle { get; set; }

    /// <summary>
    -    ///     Botun ana hareket döngüsünü tetikler.
    /// </summary>
    public void Invoke()
    {
        // Eğer bir hedef seçiliyse veya son hedef bir engelin arkasında kalmadıysa, serbestçe hareket etme.
        if (Game.SelectedEntity != null && !LastEntityWasBehindObstacle)
            return;

        // Oyuncu saldırı altındaysa ve özel bir durum (engel) yoksa, yerinde kal.
        var playerUnderAttack =
            SpawnManager.Any<SpawnedMonster>(m => m.AttackingPlayer && Container.Bot.Area.IsInSight(m));
        if (playerUnderAttack && !LastEntityWasBehindObstacle)
            return;

        // Oyuncu zaten hareket ediyorsa, yeni bir komut gönderme.
        if (Game.Player.Movement.Moving)
            return;

        // Parti liderini takip etme modu aktifse ve oyuncu lider değilse...
        if (PlayerConfig.Get("RSBot.Party.AlwaysFollowPartyMaster", false) &&
            Game.Party.IsInParty &&
            !Game.Party.IsLeader)
        {
            if (Game.Player.InAction)
                return;

            // Liderle aradaki mesafe 10 birimden fazlaysa, lidere doğru yürü.
            var player = Game.Party.Leader?.Player;
            if (player != null && player.Position.DistanceToPlayer() >= 10) Game.Player.MoveTo(player.Position);

            return;
        }

        var distance = Game.Player.Position.DistanceTo(Container.Bot.Area.Position);
        var hasCollision = Game.Player.Position.HasCollisionBetween(Container.Bot.Area.Position);

        // Oyuncu eğitim alanının dışına çıktıysa veya merkeze yürüme modunda çok uzaklaştıysa, merkeze geri dön.
        if ((distance > Container.Bot.Area.Radius || (Config.WalkToCenter && distance > 3)) && !hasCollision)
        {
            Log.Status("Walking to center");
            Game.Player.MoveTo(Container.Bot.Area.Position);

            return;
        }

        // Sadece merkeze yürüme modu aktifse, rastgele hareket etme.
        if (Config.WalkToCenter)
            return;

        Log.Status("Walking around");

        // Alan içinde, arada engel olmayan rastgele bir nokta bul ve oraya yürü.
        // Bu, botun sıkışmasını önler ve sürekli aktif kalmasını sağlar.
        var destination = Container.Bot.Area.GetRandomPosition();

        var attempt = 0;
        while (Game.Player.Position.HasCollisionBetween(destination) &&
               distance < Container.Bot.Area.Radius)
        {
            destination = Container.Bot.Area.GetRandomPosition();
            if (attempt++ > 3)
                break;

            Thread.Sleep(100);
        }

        Game.Player.MoveTo(destination, false);
    }

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    public void Refresh()
    {
        Config = new MovementConfig
        {
            WalkAround = PlayerConfig.Get("RSBot.Training.radioWalkAround", true),
            WalkToCenter = PlayerConfig.Get<bool>("RSBot.Training.radioCenter")
        };
    }

    public void Stop()
    {
        LastEntityWasBehindObstacle = false;
    }
}