using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.Core.Objects;
using RSBot.Inventory.ViewModels;

namespace RSBot.Inventory.Views;

/// <summary>
/// Interaction logic for ItemProperties window
/// </summary>
public partial class ItemProperties : Window
{
    /// <summary>
    /// Initializes a new instance of the ItemProperties window
    /// </summary>
    /// <param name="inventoryItem">The inventory item to display properties for</param>
    public ItemProperties(InventoryItem inventoryItem)
    {
        InitializeComponent();
        DataContext = new ItemPropertiesViewModel(inventoryItem);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
} 