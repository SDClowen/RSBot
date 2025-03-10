using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using RSBot.Inventory.Avalonia.ViewModels;
using System.ComponentModel;

namespace RSBot.Inventory.Avalonia.Views;

/// <summary>
/// Main view for displaying and managing inventory items
/// </summary>
public partial class Main : UserControl
{
    private MainViewModel ViewModel => DataContext as MainViewModel;

    /// <summary>
    /// Initializes a new instance of the Main class
    /// </summary>
    public Main()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void DataGrid_ContextMenuOpening(object? sender, CancelEventArgs e)
    {
        if (sender is not DataGrid dataGrid)
            return;

        if (dataGrid.SelectedItem is not InventoryItem item)
        {
            e.Cancel = true;
            return;
        }

        var contextMenu = dataGrid.ContextMenu;
        if (contextMenu == null)
            return;

        var viewModel = DataContext as MainViewModel;
        if (viewModel == null)
            return;

        // Get menu items
        var useMenuItem = contextMenu.FindMenuItem("useMenuItem");
        var dropMenuItem = contextMenu.FindMenuItem("dropMenuItem");
        var moveToPetMenuItem = contextMenu.FindMenuItem("moveToPetMenuItem");
        var moveToPlayerMenuItem = contextMenu.FindMenuItem("moveToPlayerMenuItem");
        var useAtTrainingPlaceMenuItem = contextMenu.FindMenuItem("useAtTrainingPlaceMenuItem");
        var autoUseAccordingToPurposeMenuItem = contextMenu.FindMenuItem("autoUseAccordingToPurposeMenuItem");
        var moveToLastDeathPositionMenuItem = contextMenu.FindMenuItem("moveToLastDeathPositionMenuItem");
        var moveToLastRecallPositionMenuItem = contextMenu.FindMenuItem("moveToLastRecallPositionMenuItem");
        var selectMapLocationMenuItem = contextMenu.FindMenuItem("selectMapLocationMenuItem");

        // Handle non-inventory tabs
        if (viewModel.SelectedTab != 0)
        {
            useMenuItem.IsVisible = false;
            moveToLastDeathPositionMenuItem.IsVisible = false;
            moveToLastRecallPositionMenuItem.IsVisible = false;
            moveToPetMenuItem.IsVisible = false;
            moveToPlayerMenuItem.IsVisible = viewModel.SelectedTab == 3;
            selectMapLocationMenuItem.IsVisible = false;
            return;
        }

        // Handle item usage
        var canUse = (item.Record.CanUse & ObjectUseType.Yes) != 0;
        if (canUse)
        {
            var useItems = PlayerConfig.GetArray<string>("RSBot.Inventory.ItemsAtTrainplace");
            useAtTrainingPlaceMenuItem.IsChecked = useItems.Contains(item.Record.CodeName);
            useAtTrainingPlaceMenuItem.IsEnabled = true;

            var purposiveItems = PlayerConfig.GetArray<string>("RSBot.Inventory.AutoUseAccordingToPurpose");
            autoUseAccordingToPurposeMenuItem.IsChecked = purposiveItems.Contains(item.Record.CodeName);
            autoUseAccordingToPurposeMenuItem.IsEnabled = true;
        }
        else
        {
            useAtTrainingPlaceMenuItem.IsChecked = false;
            useAtTrainingPlaceMenuItem.IsEnabled = false;

            autoUseAccordingToPurposeMenuItem.IsChecked = false;
            autoUseAccordingToPurposeMenuItem.IsEnabled = false;
        }

        // Handle reverse scroll
        var isReverseScroll = item.Equals(new TypeIdFilter(3, 3, 3, 3));
        useMenuItem.IsVisible = !isReverseScroll;
        useMenuItem.IsEnabled = item.Record.CanUse != ObjectUseType.No;
        moveToLastDeathPositionMenuItem.IsVisible = isReverseScroll;
        moveToLastRecallPositionMenuItem.IsVisible = isReverseScroll;
        selectMapLocationMenuItem.IsVisible = isReverseScroll;
        dropMenuItem.IsVisible = item.Record.CanDrop != ObjectDropType.No;
    }
}

public static class ContextMenuExtensions
{
    public static MenuItem FindMenuItem(this ContextMenu menu, string name)
    {
        foreach (var item in menu.Items)
        {
            if (item is MenuItem menuItem && menuItem.Name == name)
                return menuItem;
        }
        return null;
    }
} 