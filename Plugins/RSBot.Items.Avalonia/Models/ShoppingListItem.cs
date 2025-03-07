using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Items.Avalonia.Models;

/// <summary>
/// Represents an item in the shopping list with its reference and amount.
/// This model is used to display and manage items in the shopping list UI.
/// </summary>
public class ShoppingListItem
{
    /// <summary>
    /// Gets or sets the reference to the shop good
    /// </summary>
    public RefShopGood Good { get; }

    /// <summary>
    /// Gets or sets the amount to purchase
    /// </summary>
    public int Amount { get; }

    /// <summary>
    /// Gets the reference item object
    /// </summary>
    public RefObjItem RefItem { get; }

    /// <summary>
    /// Gets the name of the item
    /// </summary>
    public string Name => RefItem?.GetRealName() ?? Good.RefTabCodeName;

    /// <summary>
    /// Gets the icon path of the item
    /// </summary>
    public string Icon => RefItem?.AssocFileIcon ?? string.Empty;

    /// <summary>
    /// Initializes a new instance of the ShoppingListItem class
    /// </summary>
    public ShoppingListItem(RefShopGood good, int amount)
    {
        Good = good;
        Amount = amount;

        var refPackageItem = Game.ReferenceManager.GetRefPackageItem(good.RefPackageItemCodeName);
        var item = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

        RefItem = item;
    }
} 