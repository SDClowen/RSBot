using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using System.Threading.Tasks;
using RSBot.Items.Avalonia.Models;
using DynamicData;

namespace RSBot.Items.Avalonia.Services;

/// <summary>
/// Provides implementation for managing items, shopping lists, and filters in the RSBot Items plugin.
/// This service uses RSBot.Core functionality for item management and shopping operations.
/// </summary>
public class ItemService
{
    private List<RefShopGroup> _accessoryTrader;
    private List<RefShopGroup> _potionTrader;
    private List<RefShopGroup> _protectorTrader;
    private List<RefShopGroup> _stableKeeper;
    private List<RefShopGroup> _weaponTrader;

    public ItemService()
    {
        _accessoryTrader = new List<RefShopGroup>();
        _potionTrader = new List<RefShopGroup>();
        _protectorTrader = new List<RefShopGroup>();
        _stableKeeper = new List<RefShopGroup>();
        _weaponTrader = new List<RefShopGroup>();

        LoadGroups();
    }

    private void LoadGroups()
    {
        _accessoryTrader.Clear();
        _potionTrader.Clear();
        _protectorTrader.Clear();
        _stableKeeper.Clear();
        _weaponTrader.Clear();

        foreach (var group in Game.ReferenceManager.ShopGroups)
        {
            if (group.Value.CodeName.Contains("POTION") && !group.Value.CodeName.Contains("MALL_"))
                _potionTrader.Add(group.Value);

            if (group.Value.CodeName.Contains("WEAPON") && !group.Value.CodeName.Contains("MALL_"))
                _weaponTrader.Add(group.Value);

            if (group.Value.CodeName.Contains("PROTECTOR") && !group.Value.CodeName.Contains("MALL_"))
                _protectorTrader.Add(group.Value);

            if (group.Value.CodeName.Contains("ACCESSORY") && !group.Value.CodeName.Contains("MALL_"))
                _accessoryTrader.Add(group.Value);

            if (group.Value.CodeName.Contains("STABLE") && !group.Value.CodeName.Contains("MALL_"))
                _stableKeeper.Add(group.Value);
        }
    }

    public Dictionary<RefShopGood, int> ShoppingList => ShoppingManager.ShoppingList;
    public List<string> SellFilter => ShoppingManager.SellFilter;
    public List<string> StoreFilter => ShoppingManager.StoreFilter;

    public bool Enabled
    {
        get => PlayerConfig.Get("RSBot.Shopping.Enabled", true);
        set
        {
            PlayerConfig.Set("RSBot.Shopping.Enabled", value);
            ShoppingManager.Enabled = value;
        }
    }

    public bool RepairGear
    {
        get => PlayerConfig.Get("RSBot.Shopping.RepairGear", true);
        set
        {
            PlayerConfig.Set("RSBot.Shopping.RepairGear", value);
            ShoppingManager.RepairGear = value;
        }
    }

    public bool SellPetItems
    {
        get => PlayerConfig.Get("RSBot.Shopping.SellPetItems", true);
        set
        {
            PlayerConfig.Set("RSBot.Shopping.SellPetItems", value);
            ShoppingManager.SellPetItems = value;
        }
    }

    public bool StorePetItems
    {
        get => PlayerConfig.Get("RSBot.Shopping.StorePetItems", true);
        set
        {
            PlayerConfig.Set("RSBot.Shopping.StorePetItems", value);
            ShoppingManager.StorePetItems = value;
        }
    }

    public IEnumerable<string> GetStores(int npcType)
    {
        var groups = npcType switch
        {
            0 => _potionTrader,
            1 => _stableKeeper,
            2 => _protectorTrader,
            3 => _weaponTrader,
            4 => _accessoryTrader,
            _ => []
        };

        return groups.Select(g => g.CodeName);
    }

    public IEnumerable<RefObjItem> GetProducts(int storeIndex, bool showEquipment)
    {
        var groups = storeIndex switch
        {
            0 => _potionTrader,
            1 => _stableKeeper,
            2 => _protectorTrader,
            3 => _weaponTrader,
            4 => _accessoryTrader,
            _ => []
        };

        var result = new List<RefObjItem>();
        foreach (var group in groups)
        {
            var goods = Game.ReferenceManager.GetRefShopGoods(group);
            if (goods == null) continue;

            foreach (var good in goods)
            {
                var refPackageItem = Game.ReferenceManager.GetRefPackageItem(good.RefPackageItemCodeName);
                var item = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

                if (item == null)
                    continue;

                if (!showEquipment && item.TypeID2 == 1)
                    continue;

                if (refPackageItem.RefItemCodeName.Contains("_MALL_"))
                    continue;

                result.Add(item);
            }
        }

        return result;
    }

    public IEnumerable<ShoppingListItem> GetShoppingList()
    {
        return ShoppingList.Select(kvp => new ShoppingListItem(kvp.Key, kvp.Value));
    }

    public void AddToShoppingList(RefShopGood good, int amount)
    {
        if (!ShoppingList.ContainsKey(good))
            ShoppingList.Add(good, amount);
        else
            ShoppingList[good] += amount;

        SaveShoppingList();
    }

    public void ChangeShoppingItemAmount(ShoppingListItem item, int newAmount)
    {
        if (ShoppingList.ContainsKey(item.Good))
            ShoppingList[item.Good] = newAmount;

        SaveShoppingList();
    }

    public void RemoveFromShoppingList(ShoppingListItem item)
    {
        if (ShoppingList.ContainsKey(item.Good))
            ShoppingList.Remove(item.Good);

        SaveShoppingList();
    }

    public void AddToSellFilter(string codeName)
    {
        if (!SellFilter.Contains(codeName))
            SellFilter.Add(codeName);

        SaveFilters();
    }

    public void RemoveFromSellFilter(string codeName)
    {
        if (SellFilter.Contains(codeName))
            SellFilter.Remove(codeName);

        SaveFilters();
    }

    public void AddToStoreFilter(string codeName)
    {
        if (!StoreFilter.Contains(codeName))
            StoreFilter.Add(codeName);

        SaveFilters();
    }

    public void RemoveFromStoreFilter(string codeName)
    {
        if (StoreFilter.Contains(codeName))
            StoreFilter.Remove(codeName);

        SaveFilters();
    }

    public void LoadFilters()
    {
        ShoppingManager.LoadFilters();
    }

    public void SaveFilters()
    {
        ShoppingManager.SaveFilters();
    }

    public async Task<List<RefObjItem>> QueryItemsAsync(List<TypeIdFilter> filters)
    {
        return await Task.Run(() =>
        {
            var items = Game.ReferenceManager.GetFilteredItems(filters);
            return items.Select(item => item).ToList();
        });
    }

    public IEnumerable<RefObjItem> SearchItems(string searchText, ItemFilters filters)
    {
        var typeFilters = new List<TypeIdFilter>();

        // Weapons
        if (filters.WeaponSword) typeFilters.Add(new TypeIdFilter(3, 1, 6, 2));
        if (filters.WeaponBlade) typeFilters.Add(new TypeIdFilter(3, 1, 6, 3));
        if (filters.WeaponSpear) typeFilters.Add(new TypeIdFilter(3, 1, 6, 4));
        if (filters.WeaponGlave) typeFilters.Add(new TypeIdFilter(3, 1, 6, 5));
        if (filters.WeaponBow) typeFilters.Add(new TypeIdFilter(3, 1, 6, 6));
        if (filters.Weapon1HSword) typeFilters.Add(new TypeIdFilter(3, 1, 6, 7));
        if (filters.Weapon2HSword) typeFilters.Add(new TypeIdFilter(3, 1, 6, 8));
        if (filters.WeaponAxe) typeFilters.Add(new TypeIdFilter(3, 1, 6, 9));
        if (filters.WeaponWRod) typeFilters.Add(new TypeIdFilter(3, 1, 6, 10));
        if (filters.WeaponStaff) typeFilters.Add(new TypeIdFilter(3, 1, 6, 11));
        if (filters.WeaponXBow) typeFilters.Add(new TypeIdFilter(3, 1, 6, 12));
        if (filters.WeaponDagger) typeFilters.Add(new TypeIdFilter(3, 1, 6, 13));
        if (filters.WeaponHarp) typeFilters.Add(new TypeIdFilter(3, 1, 6, 14));
        if (filters.WeaponCRod) typeFilters.Add(new TypeIdFilter(3, 1, 6, 15));

        // Armor
        if (filters.ArmorClothes) typeFilters.Add(new TypeIdFilter(3, 1, 1, 1));
        if (filters.ArmorLight) typeFilters.Add(new TypeIdFilter(3, 1, 1, 2));
        if (filters.ArmorHeavy) typeFilters.Add(new TypeIdFilter(3, 1, 1, 3));

        // Other
        if (filters.OtherQuest) typeFilters.Add(new TypeIdFilter(3, 3, 3, 1));
        if (filters.OtherAmmo) typeFilters.Add(new TypeIdFilter(3, 3, 4, 2));
        if (filters.OtherCoin) typeFilters.Add(new TypeIdFilter(3, 3, 5, 1));
        if (filters.OtherOther) typeFilters.Add(new TypeIdFilter { CompareByTypeID2 = true, TypeID2 = 3 });

        if (typeFilters.Count == 0)
            typeFilters.Add(new TypeIdFilter { CompareByTypeID1 = true, TypeID1 = 3 });

        var items = Game.ReferenceManager.GetFilteredItems(typeFilters);

        if (!string.IsNullOrEmpty(searchText))
            items = items.Where(i => i.GetRealName().Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();

        return items.Select(item =>item);
    }

    private void SaveShoppingList()
    {
        foreach (var group in Game.ReferenceManager.ShopGroups)
        {
            var values = new List<string>();
            foreach (var item in ShoppingList.Where(kvp => kvp.Key.RefTabCodeName == group.Key))
            {
                values.Add($"{item.Key.RefPackageItemCodeName}|{item.Value}");
            }

            PlayerConfig.SetArray($"RSBot.Shopping.{group.Key}", values);
        }
    }
} 