using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Components;

public class PickupManager
{
    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="PickupManager" /> is running.
    /// </summary>
    /// <value>
    ///     <c>true</c> if running; otherwise, <c>false</c>.
    /// </value>
    public static bool RunningPlayerPickup { get; private set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="PickupManager" /> is running for AbilityPet.
    /// </summary>
    /// <value>
    ///     <c>true</c> if running; otherwise, <c>false</c>.
    /// </value>
    public static bool RunningAbilityPetPickup { get; private set; }

    /// <summary>
    ///     Gets or sets the pickup items.
    /// </summary>
    /// <value>
    ///     The pickup items.
    /// </value>
    public static List<(string CodeName, bool PickOnlyChar)> PickupFilter { get; } = new();

    /// <summary>
    ///     Gets or sets a value indicating whether [pickup gold].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [pickup gold]; otherwise, <c>false</c>.
    /// </value>
    public static bool PickupGold => PlayerConfig.Get("RSBot.Items.Pickup.Gold", true);

    /// <summary>
    ///     Gets or sets a value indicating whether [pickup rare items].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [pickup rare items]; otherwise, <c>false</c>.
    /// </value>
    public static bool PickupRareItems => PlayerConfig.Get("RSBot.Items.Pickup.Rare", true);

    /// <summary>
    ///     Gets or sets a value indicating whether [pickup rare items].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [pickup rare items]; otherwise, <c>false</c>.
    /// </value>
    public static bool PickupBlueItems => PlayerConfig.Get("RSBot.Items.Pickup.Blue", true);

    /// <summary>
    ///     Gets or sets a value indicating whether [pickup quest items].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [pickup quest items]; otherwise, <c>false</c>.
    /// </value>
    public static bool PickupQuestItems => PlayerConfig.Get("RSBot.Items.Pickup.Quest", true);

    /// <summary>
    ///     Gets or sets a value indicating whether [pickup clean equips].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [pickup clean equips]; otherwise, <c>false</c>.
    /// </value>
    public static bool PickupAnyEquips => PlayerConfig.Get("RSBot.Items.Pickup.AnyEquips", true);

    /// <summary>
    ///     Gets or sets a value indicating whether [pickup everything].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [pickup everything]; otherwise, <c>false</c>.
    /// </value>
    public static bool PickupEverything => PlayerConfig.Get("RSBot.Items.Pickup.Everything", true);

    /// <summary>
    ///     Gets or sets a value indicating whether [use ability pet].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [use ability pet]; otherwise, <c>false</c>.
    /// </value>
    public static bool UseAbilityPet => PlayerConfig.Get("RSBot.Items.Pickup.EnableAbilityPet", true);

    /// <summary>
    ///     Gets or sets a value indicating whether [just pick my items].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [use ability pet]; otherwise, <c>false</c>.
    /// </value>
    public static bool JustPickMyItems => PlayerConfig.Get("RSBot.Items.Pickup.JustPickMyItems", false);

    /// <summary>
    ///     Runs the specified center position.
    /// </summary>
    /// <param name="playerPosition">The player position.</param>
    /// <param name="centerPosition">The center position.</param>
    /// <param name="radius">The radius.</param>
    public static void RunPlayer(Position playerPosition, Position centerPosition, int radius = 50)
    {
        if (RunningPlayerPickup)
            return;

        RunningPlayerPickup = true;
        try
        {
            var flag = UseAbilityPet && Game.Player.HasActiveAbilityPet;
            if (!SpawnManager.TryGetEntities<SpawnedItem>(i => Condition(i, centerPosition, radius, flag, flag),
                    out var entities))
            {
                RunningPlayerPickup = false;
                return;
            }

            foreach (var item in entities.OrderBy(item => item.Movement.Source.DistanceTo(playerPosition) /*.Take(5)*/))
            {
                if (!RunningPlayerPickup)
                    return;

                while (Game.Player.InAction)
                    Thread.Sleep(50);

                if (item.Record.IsSpecialtyGoodBox && Game.Player.Job2SpecialtyBag.Full)
                    continue;

                //Make sure the player is at the item's location
                //Game.Player.MoveTo(item.Movement.Source);
                item.Pickup();
            }
        }
        catch (Exception e)
        {
            Log.Fatal(e);
        }
        finally
        {
            RunningPlayerPickup = false;
        }
    }

    public static async void RunAbilityPet(Position centerPosition, int radius = 50)
    {
        if (RunningAbilityPetPickup)
            return;

        RunningAbilityPetPickup = true;

        try
        {
            if (!SpawnManager.TryGetEntities<SpawnedItem>(i => Condition(i, centerPosition, radius, true),
                    out var entities))
            {
                RunningAbilityPetPickup = false;
                return;
            }

            foreach (var item in entities.OrderBy(item =>
                         item.Movement.Source.DistanceTo(Game.Player.AbilityPet.Position)))
            {
                if (!RunningAbilityPetPickup)
                    return;

                if (item.Record.IsSpecialtyGoodBox && Game.Player.Job2SpecialtyBag.Full)
                    continue;

                await Game.Player.AbilityPet.PickupAsync(item.UniqueId);
                await Task.Yield();
            }
        }
        catch (Exception e)
        {
            Log.Fatal(e);
        }
        finally
        {
            RunningAbilityPetPickup = false;
        }
    }

    /// <summary>
    /// Bir eşyanın (item) alınıp alınmayacağını belirleyen merkezi filtreleme metodudur.
    /// </summary>
    /// <param name="e">Kontrol edilecek eşya.</param>
    /// <param name="centerPosition">Eğitim alanının merkezi.</param>
    /// <param name="radius">Eğitim alanının yarıçapı.</param>
    /// <param name="applyPickOnlyChar">Sadece karakterin alabileceği eşyalar filtresini uygula (pet için farklı davranış).</param>
    /// <param name="pickOnlyChar">Eşyanın sadece karakter tarafından mı alınacağını belirtir.</param>
    /// <returns>Eşya alınacaksa true, aksi takdirde false.</returns>
    private static bool Condition(
        SpawnedItem e,
        Position centerPosition,
        int radius,
        bool applyPickOnlyChar = false,
        bool pickOnlyChar = false
    )
    {
        var playerJid = Game.Player.JID;

        // "Sadece benim eşyalarımı topla" ayarı aktifse ve eşyanın sahibi biz değilsek, toplama.
        if (JustPickMyItems && e.OwnerJID != playerJid)
            return false;

        // Eşyanın hala başka bir sahibe ait bir düşme koruması varsa, toplama.
        if (e.HasOwner && e.OwnerJID != playerJid)
            return false;

        // Eğer bu kontrol pet için yapılıyorsa ve eşya bir engelin arkasındaysa, toplama.
        if (applyPickOnlyChar && e.IsBehindObstacle)
            return false;

        // Eşyanın eğitim alanı içinde olup olmadığını küçük bir toleransla kontrol et.
        const int tolerance = 15;
        var isInside = e.Movement.Source.DistanceTo(centerPosition) <= radius + tolerance;
        if (!isInside)
            return false;

        // Genel toplama ayarları (Config'den gelen):
        if (PickupGold && e.Record.IsGold && !(applyPickOnlyChar && pickOnlyChar))
            return true;

        if (PickupRareItems && (byte)e.Rarity >= 2)
            return true;

        if (PickupBlueItems && (byte)e.Rarity >= 1)
            return true;

        if (PickupAnyEquips && e.Record.IsEquip)
            return true;

        if (PickupQuestItems && e.Record.IsQuest)
            return true;

        if (PickupEverything)
            return true;

        // Özel filtre listesi (kullanıcının eklediği item'lar):
        if (applyPickOnlyChar)
        {
            if (PickupFilter.Any(p => p.CodeName == e.Record.CodeName && p.PickOnlyChar == pickOnlyChar))
                return true;
        }
        else if (PickupFilter.Any(p => p.CodeName == e.Record.CodeName))
        {
            return true;
        }

        // Yukarıdaki koşulların hiçbiri karşılanmazsa, eşyayı toplama.
        return false;
    }

    public static void AddFilter(string codeName, bool pickOnlyChar = false)
    {
        PickupFilter.RemoveAll(p => p.CodeName == codeName);
        PickupFilter.Add((codeName, pickOnlyChar));

        SaveFilter();
    }

    public static void RemoveFilter(string codeName)
    {
        PickupFilter.RemoveAll(p => p.CodeName == codeName);
        SaveFilter();
    }

    public static void LoadFilter()
    {
        var config = PlayerConfig.GetArray<string>("RSBot.Shopping.Pickup");

        foreach (var item in config)
        {
            var split = item.Split('|');
            if (split.Length < 2)
                continue;

            PickupFilter.Add((split[0], Convert.ToBoolean(split[1])));
        }
    }

    public static void SaveFilter()
    {
        var array = PickupFilter.Select(p => $"{p.CodeName}|{p.PickOnlyChar}").ToArray();
        if (array.Length == 0)
            return;

        PlayerConfig.SetArray("RSBot.Shopping.Pickup", array);
    }

    /// <summary>
    ///     Stops this instance.
    /// </summary>
    public static void Stop()
    {
        RunningPlayerPickup = false;
        RunningAbilityPetPickup = false;
    }
}