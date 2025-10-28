using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Default.Bundle.Target;

internal class TargetBundle : IBundle
{
    private const int BLACKLIST_TIMEOUT = 5_000;

    #region Fields

    private Dictionary<uint, int> _blacklist;

    #endregion Fields

    #region Constructor

    public TargetBundle()
    {
        SubscribeEvents();
    }

    #endregion Constructor

    #region Events

    private void OnTargetBehindObstacle()
    {
        if (Game.SelectedEntity == null)
            return;

        var selectedEntityUniqueId = Game.SelectedEntity.UniqueId;
        Game.SelectedEntity?.TryDeselect();
        Game.SelectedEntity = null;

        Bundles.Movement.LastEntityWasBehindObstacle = true;

        if (_blacklist?.TryAdd(selectedEntityUniqueId, Kernel.TickCount) == true)
            Log.Debug($"Add mob [{selectedEntityUniqueId} to blacklist for {BLACKLIST_TIMEOUT}ms");
    }

    #endregion Events

    #region Methods

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnTargetBehindObstacle", OnTargetBehindObstacle);
    }

    /// <summary>
    ///     Botun ana hedef seçme döngüsünü tetikler.
    /// </summary>
    public void Invoke()
    {
        // Karalistenin süresi dolan canavarları temizle.
        _blacklist?.RemoveAll((uniqueId, tick) =>
        {
            var flag = Kernel.TickCount - tick > BLACKLIST_TIMEOUT;
            if (flag)
                Log.Debug($"Removed mob [{uniqueId} from blacklist!");

            return flag;
        });

        // Acil durum kontrolü: Tehlikeli bir canavar saldırıyorsa, daha zayıf olan saldırgana odaklan.
        var attacker = GetFromCurrentAttackers();
        if (attacker != null && Game.SelectedEntity == null)
        {
            Log.Debug("[TargetBundle] Emergency situation: Attacking the weaker mob first!");

            if (attacker.TrySelect())
                Bundles.Movement.LastEntityWasBehindObstacle = false;

            return;
        }

        // Mevcut hedeften daha zayıf bir saldırgan varsa, hedefi değiştir.
        if (attacker != null &&
            SpawnManager.TryGetEntity<SpawnedMonster>(Game.SelectedEntity.UniqueId, out var selectedMonster) &&
            (byte)attacker.Rarity < (byte)selectedMonster.Rarity)
        {
            Log.Debug("[TargetBundle] Emergency situation: Found a weaker mob to attack first, switching target!");

            if (attacker.TrySelect())
                Bundles.Movement.LastEntityWasBehindObstacle = false;

            return;
        }

        // Warlock modu aktifse ve hedefin üzerinde zaten iki debuff varsa, yeni hedef arama.
        var warlockModeEnabled = PlayerConfig.Get("RSBot.Skills.checkWarlockMode", false);
        if (warlockModeEnabled && Game.SelectedEntity?.State.HasTwoDots() == true)
            return;

        // Zaten geçerli ve canlı bir hedefe sahipsek, yeni hedef arama.
        if (Game.SelectedEntity?.State.LifeState == LifeState.Alive)
            return;

        // Hedef seçili ama bu bir canavar değilse, hedefi temizle.
        if (Game.SelectedEntity != null && Game.SelectedEntity is not SpawnedMonster)
            Game.SelectedEntity = null;

        // Yukarıdaki koşullar geçildiyse, en uygun yeni düşmanı bul.
        var monster = GetNearestEnemy();
        if (monster == null)
            return;

        // Canavarın görüş alanında olduğundan emin ol.
        if (!Container.Bot.Area.IsInSight(monster))
            return;

        // Canavarı hedef olarak seç.
        if (monster.TrySelect())
            Bundles.Movement.LastEntityWasBehindObstacle = false;
    }

    /// <summary>
    /// Acil bir durumda (örn. tehlikeli bir canavar saldırırken), saldıranlar arasından en zayıf olanını hedef olarak seçer.
    /// </summary>
    /// <returns>En zayıf saldırgan veya acil durum yoksa null.</returns>
    private SpawnedMonster GetFromCurrentAttackers()
    {
        var attackWeakerFirst = PlayerConfig.Get<bool>("RSBot.Training.checkAttackWeakerFirst");
        if (!attackWeakerFirst || !IsEmergencySituation())
            return null;

        if (!SpawnManager.TryGetEntities<SpawnedMonster>(e => e.AttackingPlayer && e.State.LifeState == LifeState.Alive,
                out var entities))
            return null;

        return entities.OrderBy(e => (byte)e.Rarity)
            .OrderBy(e => e.Record.Level)
            .OrderByDescending(e => e.Position.DistanceToPlayer())
            .FirstOrDefault();
    }

    /// <summary>
    /// Kaçınılması gereken (avoid) olarak işaretlenmiş bir canavarın saldırıp saldırmadığını kontrol ederek acil durumu belirler.
    /// </summary>
    /// <returns>Acil durum varsa true, yoksa false.</returns>
    private bool IsEmergencySituation()
    {
        return SpawnManager.Any<SpawnedMonster>(e =>
            e.AttackingPlayer && e.State.LifeState == LifeState.Alive && Bundles.Avoidance.AvoidMonster(e.Rarity));
    }

    /// <summary>
    /// Çevredeki en uygun düşmanı, yapılandırılmış kurallara göre filtreleyip sıralayarak bulur.
    /// </summary>
    /// <returns>Saldırı için en uygun canavar veya bulunamazsa null.</returns>
    private SpawnedMonster GetNearestEnemy()
    {
        var warlockModeEnabled = PlayerConfig.Get<bool>("RSBot.Skills.checkWarlockMode");
        var ignorePillar = PlayerConfig.Get<bool>("RSBot.Training.checkBoxDimensionPillar");

        // Canavarları bulmak için karmaşık bir filtreleme sorgusu çalıştır.
        if (!SpawnManager.TryGetEntities<SpawnedMonster>(m =>
                m.State.LifeState == LifeState.Alive && // Sadece canlı olanlar
                !(warlockModeEnabled && m.State.HasTwoDots()) && // Warlock modu için debuff kontrolü
                m.IsBehindObstacle == false && // Engellerin arkasında olmayanlar
                (_blacklist == null || !_blacklist.ContainsKey(m.UniqueId)) && // Karalistede olmayanlar
                (m.AttackingPlayer || !Bundles.Avoidance.AvoidMonster(m.Rarity)) && // Bize saldıran veya kaçınılmayacak türdekiler
                Container.Bot.Area.IsInSight(m) && // Eğitim alanı içinde olanlar
                !m.Record.IsPandora && // Pandora kutusu olmayanlar
                !(m.Record.IsDimensionPillar && ignorePillar) && // Boyut sütunu olmayanlar (isteğe bağlı)
                !m.Record.IsSummonFlower, out var entities)) // Çağırılmış çiçek olmayanlar
            return default;

        // Filtrelenmiş canavarları en uygun olanı bulmak için sırala.
        return entities.OrderBy(m => m.Movement.Source.DistanceTo(Container.Bot.Area.Position)) // 1. Eğitim alanının merkezine en yakın olan
            .OrderBy(m => Bundles.Avoidance.PreferMonster(m.Rarity)) // 2. Tercih edilen türler
            .OrderByDescending(m => m.AttackingPlayer) // 3. Bize saldıranlar (en yüksek öncelik)
            .FirstOrDefault();
    }

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    public void Refresh()
    {
        _blacklist = new Dictionary<uint, int>(8);
    }

    public void Stop()
    {
        _blacklist = null;
    }

    #endregion Methods
}