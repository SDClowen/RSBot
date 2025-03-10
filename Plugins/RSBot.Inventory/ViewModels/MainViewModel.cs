using Avalonia.Controls;
using Avalonia.Threading;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Inventory;
using RSBot.Inventory.Avalonia.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RSBot.Inventory.Avalonia.ViewModels;

/// <summary>
/// Main view model for managing inventory items and interactions
/// </summary>
public class MainViewModel : INotifyPropertyChanged
{
    private readonly object _lock = new();
    private int _selectedTab;
    private ObservableCollection<InventoryItem> _items;
    private string _freeSlots;
    private bool _autoSort;
    private InventoryItem _selectedItem;

    /// <summary>
    /// Initializes a new instance of the MainViewModel class
    /// </summary>
    public MainViewModel()
    {
        Items = [];
        SwitchTabCommand = new RelayCommand(SwitchTab);
        UseItemCommand = new RelayCommand(UseItem);
        DropItemCommand = new RelayCommand(DropItem);
        MoveToPetCommand = new RelayCommand(MoveToPet);
        MoveToPlayerCommand = new RelayCommand(MoveToPlayer);
        UseAtTrainingPlaceCommand = new RelayCommand(UseAtTrainingPlace);
        SortCommand = new RelayCommand(Sort);
        ShowPropertiesCommand = new RelayCommand(ShowProperties);
        MoveToLastDeathPositionCommand = new RelayCommand(MoveToLastDeathPosition);
        MoveToLastRecallPositionCommand = new RelayCommand(MoveToLastRecallPosition);
        SelectMapLocationCommand = new RelayCommand(SelectMapLocation);
        ToggleUseAtTrainingPlaceCommand = new RelayCommand(ToggleUseAtTrainingPlace);
        ToggleAutoUseAccordingToPurposeCommand = new RelayCommand(ToggleAutoUseAccordingToPurpose);

        LoadSettings();
        SubscribeToEvents();
    }

    /// <summary>
    /// Loads the settings from player configuration
    /// </summary>
    private void LoadSettings()
    {
        AutoSort = PlayerConfig.Get("RSBot.Inventory.AutoSort", false);
    }

    /// <summary>
    /// Gets or sets the collection of inventory items
    /// </summary>
    public ObservableCollection<InventoryItem> Items
    {
        get => _items;
        set
        {
            _items = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the currently selected inventory item
    /// </summary>
    public InventoryItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the selected tab index
    /// </summary>
    public int SelectedTab
    {
        get => _selectedTab;
        set
        {
            _selectedTab = value;
            OnPropertyChanged();
            UpdateInventoryList();
        }
    }

    /// <summary>
    /// Gets or sets the free slots text
    /// </summary>
    public string FreeSlots
    {
        get => _freeSlots;
        set
        {
            _freeSlots = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets whether auto sort is enabled
    /// </summary>
    public bool AutoSort
    {
        get => _autoSort;
        set
        {
            if (_autoSort == value) return;
            _autoSort = value;
            PlayerConfig.Set("RSBot.Inventory.AutoSort", value);
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets whether the current tab is the inventory tab
    /// </summary>
    public bool IsInventoryTab => SelectedTab == 0;

    /// <summary>
    /// Gets the command to switch between tabs
    /// </summary>
    public ICommand SwitchTabCommand { get; }

    /// <summary>
    /// Gets the command to use an item
    /// </summary>
    public ICommand UseItemCommand { get; }

    /// <summary>
    /// Gets the command to drop an item
    /// </summary>
    public ICommand DropItemCommand { get; }

    /// <summary>
    /// Gets the command to move an item to pet
    /// </summary>
    public ICommand MoveToPetCommand { get; }

    /// <summary>
    /// Gets the command to move an item to player
    /// </summary>
    public ICommand MoveToPlayerCommand { get; }

    /// <summary>
    /// Gets the command to use an item at training place
    /// </summary>
    public ICommand UseAtTrainingPlaceCommand { get; }

    /// <summary>
    /// Gets the command to sort inventory items
    /// </summary>
    public ICommand SortCommand { get; }

    /// <summary>
    /// Gets the command to show item properties
    /// </summary>
    public ICommand ShowPropertiesCommand { get; }

    /// <summary>
    /// Gets the command to move to last death position
    /// </summary>
    public ICommand MoveToLastDeathPositionCommand { get; }

    /// <summary>
    /// Gets the command to move to last recall position
    /// </summary>
    public ICommand MoveToLastRecallPositionCommand { get; }

    /// <summary>
    /// Gets the command to select map location
    /// </summary>
    public ICommand SelectMapLocationCommand { get; }

    /// <summary>
    /// Gets the command to toggle use at training place
    /// </summary>
    public ICommand ToggleUseAtTrainingPlaceCommand { get; }

    /// <summary>
    /// Gets the command to toggle auto use according to purpose
    /// </summary>
    public ICommand ToggleAutoUseAccordingToPurposeCommand { get; }

    /// <summary>
    /// Subscribes to game events
    /// </summary>
    private void SubscribeToEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnUpdateInventoryItem", new Action<byte>(OnUpdateInventoryItem));
        EventManager.SubscribeEvent("OnUseItem", new Action<byte>(OnUpdateInventoryItem));
        EventManager.SubscribeEvent("OnInventoryUpdate", UpdateInventoryList);
    }

    /// <summary>
    /// Handles the character load event
    /// </summary>
    private void OnLoadCharacter()
    {
        UpdateInventoryList();
    }

    /// <summary>
    /// Handles inventory item update event
    /// </summary>
    /// <param name="slot">The slot that was updated</param>
    private void OnUpdateInventoryItem(byte slot)
    {
        lock (_lock)
        {
            var inventoryItem = Game.Player.Inventory.GetItemAt(slot);
            if (inventoryItem == null)
                return;

            var existingItem = Items.FirstOrDefault(i => i.Slot == slot);
            if (existingItem != null)
            {
                var index = Items.IndexOf(existingItem);
                Items[index] = inventoryItem;
            }
        }
    }

    /// <summary>
    /// Switches to the specified tab
    /// </summary>
    /// <param name="parameter">The tab index</param>
    private void SwitchTab(object parameter)
    {
        if (int.TryParse(parameter?.ToString(), out int tab))
            SelectedTab = tab;
    }

    /// <summary>
    /// Uses the specified item
    /// </summary>
    /// <param name="parameter">The item to use</param>
    private void UseItem(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        item.Use();
    }

    /// <summary>
    /// Drops the specified item
    /// </summary>
    /// <param name="parameter">The item to drop</param>
    private void DropItem(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        var cos = SelectedTab == 3;
        if (cos && Game.Player.AbilityPet == null)
            return;

        item.Drop(cos, Game.Player.AbilityPet?.UniqueId ?? 0);
    }

    /// <summary>
    /// Moves the specified item to pet inventory
    /// </summary>
    /// <param name="parameter">The item to move</param>
    private void MoveToPet(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        if (!Game.Player.HasActiveVehicle)
        {
            Game.ShowNotification("[RSBot] No active pet to move items to!");
            return;
        }

        if (Game.Player.AbilityPet == null)
            return;

        var freeSlot = Game.Player.AbilityPet.Inventory.GetFreeSlot();
        if (freeSlot == 0xFF)
            return;

        var packet = new Packet(0x7034);
        packet.WriteByte(InventoryOperation.SP_MOVE_ITEM_PC_PET);
        packet.WriteUInt(Game.Player.AbilityPet.UniqueId);
        packet.WriteByte(item.Slot);
        packet.WriteByte(freeSlot);
        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    /// Moves the specified item to player inventory
    /// </summary>
    /// <param name="parameter">The item to move</param>
    private void MoveToPlayer(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        if (!Game.Player.HasActiveVehicle)
        {
            Game.ShowNotification("[RSBot] No active pet to move items from!");
            return;
        }

        if (Game.Player.AbilityPet == null)
            return;

        var freeSlot = Game.Player.Inventory.GetFreeSlot();
        if (freeSlot == 0xFF)
            return;

        var packet = new Packet(0x7034);
        packet.WriteByte(InventoryOperation.SP_MOVE_ITEM_PET_PC);
        packet.WriteUInt(Game.Player.AbilityPet.UniqueId);
        packet.WriteByte(item.Slot);
        packet.WriteByte(freeSlot);
        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    /// Uses the specified item at training place
    /// </summary>
    /// <param name="parameter">The item to use</param>
    private void UseAtTrainingPlace(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        EventManager.FireEvent("OnUseItemAtTrainplace", item);
    }

    /// <summary>
    /// Sorts the inventory items
    /// </summary>
    private void Sort(object parameter)
    {
        Game.Player.Inventory.Sort();
    }

    /// <summary>
    /// Updates the inventory list based on the selected tab
    /// </summary>
    private void UpdateInventoryList()
    {
        if (Game.Player == null)
            return;

        lock (_lock)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                Items.Clear();
                switch (SelectedTab)
                {
                    case 0: // Inventory
                        foreach (var item in Game.Player.Inventory.GetNormalPartItems())
                            Items.Add(item);
                        UpdateFreeSlots();
                        break;

                    case 1: // Equipment
                        foreach (var item in Game.Player.Inventory.GetEquippedPartItems())
                            Items.Add(item);
                        FreeSlots = $"{Items.Count} / 13";
                        break;

                    case 2: // Avatars
                        foreach (var item in Game.Player.Avatars)
                            Items.Add(item);
                        FreeSlots = "0";
                        break;

                    case 3: // Grab Pet
                        if (Game.Player.HasActiveAbilityPet)
                        {
                            foreach (var item in Game.Player.AbilityPet.Inventory)
                                Items.Add(item);
                            FreeSlots = $"{Game.Player.AbilityPet.Inventory.FreeSlots} / {Game.Player.AbilityPet.Inventory.Capacity}";
                        }
                        break;

                    case 4: // Storage
                        if (Game.Player.Storage != null)
                        {
                            foreach (var item in Game.Player.Storage)
                                Items.Add(item);
                            FreeSlots = $"{Game.Player.Storage.FreeSlots} / {Game.Player.Storage.Capacity}";
                        }
                        break;

                    case 5: // Guild Storage
                        if (Game.Player.GuildStorage != null)
                        {
                            foreach (var item in Game.Player.GuildStorage)
                                Items.Add(item);
                            FreeSlots = $"{Game.Player.GuildStorage.FreeSlots} / {Game.Player.GuildStorage.Capacity}";
                        }
                        break;

                    case 6: // Job Transport
                        if (Game.Player.JobTransport?.Inventory != null)
                        {
                            foreach (var item in Game.Player.JobTransport.Inventory)
                                Items.Add(item);
                            FreeSlots = $"{Game.Player.JobTransport.Inventory.FreeSlots} / {Game.Player.JobTransport.Inventory.Capacity}";
                        }
                        break;

                    case 7: // Job Equipment
                        if (Game.Player.Job2SpecialtyBag != null)
                        {
                            foreach (var item in Game.Player.Job2SpecialtyBag)
                                Items.Add(item);
                            FreeSlots = $"{Game.Player.Job2SpecialtyBag.FreeSlots} / {Game.Player.Job2SpecialtyBag.Capacity}";
                        }
                        break;

                    case 8: // Specialty
                        if (Game.Player.Job2 != null)
                        {
                            foreach (var item in Game.Player.Job2)
                                Items.Add(item);
                            FreeSlots = $"{Game.Player.Job2.FreeSlots} / {Game.Player.Job2.Capacity}";
                        }
                        break;

                    case 9: // Fellow Pet
                        if (Game.Player.HasActiveFellowPet)
                        {
                            foreach (var item in Game.Player.Fellow.Inventory)
                                Items.Add(item);
                            FreeSlots = $"{Game.Player.Fellow.Inventory.FreeSlots} / {Game.Player.Fellow.Inventory.Capacity}";
                        }
                        break;
                }
            });
        }
    }

    /// <summary>
    /// Updates the free slots text
    /// </summary>
    private void UpdateFreeSlots()
    {
        FreeSlots = $"Free slots: {Game.Player.Inventory.FreeSlots} / {Game.Player.Inventory.Capacity}";
    }

    /// <summary>
    /// Shows the properties window for the selected item
    /// </summary>
    private void ShowProperties(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        var window = new ItemProperties(item);
        window.Show();
    }

    /// <summary>
    /// Moves to the last death position using a reverse scroll
    /// </summary>
    private void MoveToLastDeathPosition(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        if (!item.Equals(new TypeIdFilter(3, 3, 3, 3)))
            return;

        item.UseTo(3);
    }

    /// <summary>
    /// Moves to the last recall position using a reverse scroll
    /// </summary>
    private void MoveToLastRecallPosition(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        if (!item.Equals(new TypeIdFilter(3, 3, 3, 3)))
            return;

        item.UseTo(2);
    }

    /// <summary>
    /// Opens the map selection dialog for a reverse scroll
    /// </summary>
    private void SelectMapLocation(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        if (!item.Equals(new TypeIdFilter(3, 3, 3, 3)))
            return;

        var menu = new ContextMenu();
        foreach (var teleport in Game.ReferenceManager.OptionalTeleports)
        {
            var mapName = Game.ReferenceManager.GetTranslation(teleport.Value.Region.ToString());
            var menuItem = new MenuItem { Header = mapName };

            menuItem.Click += (sender, args) => 
            {
                item.UseTo(7, teleport.Value.ID);
            };

            menu.Items.Add(menuItem);
        }

        menu.Open();
    }

    /// <summary>
    /// Toggles whether an item should be used at training place
    /// </summary>
    private void ToggleUseAtTrainingPlace(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        var itemsToUse = PlayerConfig.GetArray<string>("RSBot.Inventory.ItemsAtTrainplace").ToList();
        var useSelectedItem = itemsToUse.Contains(item.Record.CodeName);

        if (useSelectedItem)
            itemsToUse.Remove(item.Record.CodeName);
        else
            itemsToUse.Add(item.Record.CodeName);

        PlayerConfig.SetArray("RSBot.Inventory.ItemsAtTrainplace", itemsToUse.ToArray());
        UpdateInventoryList();
    }

    /// <summary>
    /// Toggles whether an item should be auto-used according to purpose
    /// </summary>
    private void ToggleAutoUseAccordingToPurpose(object parameter)
    {
        if (parameter is not InventoryItem item)
            return;

        var purposiveItems = PlayerConfig.GetArray<string>("RSBot.Inventory.AutoUseAccordingToPurpose").ToList();
        var useSelectedItem = purposiveItems.Contains(item.Record.CodeName);

        if (useSelectedItem)
            purposiveItems.Remove(item.Record.CodeName);
        else
            purposiveItems.Add(item.Record.CodeName);

        PlayerConfig.SetArray("RSBot.Inventory.AutoUseAccordingToPurpose", purposiveItems.ToArray());
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

/// <summary>
/// Implements a basic command that can always execute
/// </summary>
/// <remarks>
/// Initializes a new instance of the RelayCommand class
/// </remarks>
/// <param name="execute">The execution logic</param>
/// <param name="canExecute">The execution status logic</param>
public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand
{
    private readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    private readonly Func<object?, bool>? _canExecute = canExecute;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => _execute(parameter);

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
} 