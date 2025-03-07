using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using RSBot.Items.Avalonia.Models;
using RSBot.Items.Avalonia.Services;

namespace RSBot.Items.Avalonia.ViewModels;

/// <summary>
/// Represents the main view model for the RSBot Items plugin.
/// This view model manages the interaction between the UI and the item service,
/// handling shopping lists, filters, and item searches using ReactiveUI.
/// </summary>
public class MainViewModel : ReactiveObject
{
    private readonly ItemService _itemService;
    private string _searchText;
    private int _selectedStoreIndex;
    private bool _showEquipment;
    private bool _isSearchMode;
    private ItemFilters _filters;
    private ObservableCollection<GroupedRefObjItem> _products;
    private ObservableCollection<ShoppingListItem> _shoppingList;
    private ObservableCollection<string> _stores;

    public MainViewModel()
    {
        _itemService = new();
        _filters = new ItemFilters();
        _products = new ObservableCollection<GroupedRefObjItem>();
        _shoppingList = new ObservableCollection<ShoppingListItem>();
        _stores = new ObservableCollection<string>();

        LoadStores();
        LoadShoppingList();

        SearchCommand = ReactiveCommand.CreateFromTask(SearchAsync);
        AddToShoppingListCommand = ReactiveCommand.Create<(RefObjItem, int)>(AddToShoppingList);
        RemoveFromShoppingListCommand = ReactiveCommand.Create<ShoppingListItem>(RemoveFromShoppingList);
        ChangeAmountCommand = ReactiveCommand.Create<(ShoppingListItem, int)>(ChangeAmount);
        LoadProductsCommand = ReactiveCommand.CreateFromTask(LoadProductsAsync);

        this.WhenAnyValue(x => x.SelectedStoreIndex)
            .Subscribe(_ => LoadProductsCommand.Execute().Subscribe());

        this.WhenAnyValue(x => x.ShowEquipment)
            .Subscribe(_ => LoadProductsCommand.Execute().Subscribe());

        this.WhenAnyValue(x => x.SearchText)
            .Subscribe(text =>
            {
                IsSearchMode = !string.IsNullOrWhiteSpace(text);
                if (IsSearchMode)
                    SearchCommand.Execute().Subscribe();
                else
                    LoadProductsCommand.Execute().Subscribe();
            });
    }

    public string SearchText
    {
        get => _searchText;
        set => this.RaiseAndSetIfChanged(ref _searchText, value);
    }

    public int SelectedStoreIndex
    {
        get => _selectedStoreIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedStoreIndex, value);
    }

    public bool ShowEquipment
    {
        get => _showEquipment;
        set => this.RaiseAndSetIfChanged(ref _showEquipment, value);
    }

    public bool IsSearchMode
    {
        get => _isSearchMode;
        set => this.RaiseAndSetIfChanged(ref _isSearchMode, value);
    }

    public ItemFilters Filters
    {
        get => _filters;
        set => this.RaiseAndSetIfChanged(ref _filters, value);
    }

    public ObservableCollection<GroupedRefObjItem> Products
    {
        get => _products;
        set => this.RaiseAndSetIfChanged(ref _products, value);
    }

    public ObservableCollection<ShoppingListItem> ShoppingList
    {
        get => _shoppingList;
        set => this.RaiseAndSetIfChanged(ref _shoppingList, value);
    }

    public ObservableCollection<string> Stores
    {
        get => _stores;
        set => this.RaiseAndSetIfChanged(ref _stores, value);
    }

    public ReactiveCommand<Unit, Unit> SearchCommand { get; }
    public ReactiveCommand<(RefObjItem Item, int Amount), Unit> AddToShoppingListCommand { get; }
    public ReactiveCommand<ShoppingListItem, Unit> RemoveFromShoppingListCommand { get; }
    public ReactiveCommand<(ShoppingListItem Item, int NewAmount), Unit> ChangeAmountCommand { get; }
    public ReactiveCommand<Unit, Unit> LoadProductsCommand { get; }

    private void LoadStores()
    {
        Stores.Clear();
        var stores = _itemService.GetStores(SelectedStoreIndex);
        foreach (var store in stores)
            Stores.Add(store);
    }

    private void LoadShoppingList()
    {
        ShoppingList.Clear();
        var items = _itemService.GetShoppingList();
        foreach (var item in items)
            ShoppingList.Add(item);
    }

    private async Task LoadProductsAsync()
    {
        Products.Clear();
        var products = _itemService.GetProducts(SelectedStoreIndex, ShowEquipment);
        var groupedProducts = products.GroupBy(p => GetGroupName(p));
        
        foreach (var group in groupedProducts.OrderBy(g => g.Key))
        {
            foreach (var product in group)
            {
                Products.Add(new GroupedRefObjItem(product, group.Key));
            }
        }
    }

    private string GetGroupName(RefObjItem item)
    {
        if (item.TypeID3 == 1) // Armor
        {
            return item.TypeID4 switch
            {
                1 => "Clothes",
                2 => "Light Armor",
                3 => "Heavy Armor",
                _ => "Other"
            };
        }
        else if (item.TypeID3 == 6) // Weapons
        {
            return item.TypeID4 switch
            {
                2 => "Swords",
                3 => "Blades",
                4 => "Spears",
                5 => "Glaves",
                6 => "Bows",
                7 => "1H Swords",
                8 => "2H Swords",
                9 => "Axes",
                10 => "Warmaces",
                11 => "Staffs",
                12 => "Crossbows",
                13 => "Daggers",
                14 => "Harps",
                15 => "Cleric Rods",
                _ => "Other"
            };
        }
        
        return "Other";
    }

    private async Task SearchAsync()
    {
        Products.Clear();
        var items = _itemService.SearchItems(SearchText, Filters);
        var groupedItems = items.GroupBy(p => GetGroupName(p));
        
        foreach (var group in groupedItems.OrderBy(g => g.Key))
        {
            foreach (var item in group)
            {
                Products.Add(new GroupedRefObjItem(item, group.Key));
            }
        }
    }

    private void AddToShoppingList((RefObjItem Item, int Amount) param)
    {
        var (item, amount) = param;
        var refShopGood = new RefShopGood { RefPackageItemCodeName = item.CodeName };
        _itemService.AddToShoppingList(refShopGood, amount);
        LoadShoppingList();
    }

    private void RemoveFromShoppingList(ShoppingListItem item)
    {
        _itemService.RemoveFromShoppingList(item);
        LoadShoppingList();
    }

    private void ChangeAmount((ShoppingListItem Item, int NewAmount) param)
    {
        var (item, newAmount) = param;
        _itemService.ChangeShoppingItemAmount(item, newAmount);
        LoadShoppingList();
    }
}

public class GroupedRefObjItem : RefObjItem
{
    public string GroupName { get; }

    public GroupedRefObjItem(RefObjItem original, string groupName) : base()
    {
        // Copy all properties from original
        foreach (var prop in typeof(RefObjItem).GetProperties())
        {
            if (prop.CanWrite)
                prop.SetValue(this, prop.GetValue(original));
        }

        GroupName = groupName;
    }
} 