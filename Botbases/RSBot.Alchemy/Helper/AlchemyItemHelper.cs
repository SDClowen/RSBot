using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;

namespace RSBot.Alchemy.Helper;

internal class AlchemyItemHelper
{
    #region Enum

    public enum ElixirType
    {
        Shield,
        Weapon,
        Protector,
        Accessory,
        Unspecified,
    }

    #endregion Enum

    #region Constants

    private const int ParamProtectorElixir = 16909056;
    private const int ParamWeaponElixir = 100663296;
    private const int ParamAccessoryElixir = 83886080;
    private const int ParamShieldElixir = 67108864;

    #endregion Constants

    #region Methods

    /// <summary>
    ///     Gets the lucky powders.
    /// </summary>
    /// <param name="targetItem">The target item.</param>
    /// <returns></returns>
    public static IEnumerable<InventoryItem> GetLuckyPowders(InventoryItem targetItem)
    {
        var items = Game
            .Player.Inventory.GetItems(new TypeIdFilter(3, 3, 10, 2))
            .Where(i => i.Record.ItemClass == targetItem.Record.Degree);

        if (Game.ClientType >= GameClientType.Chinese && targetItem.Record.Degree >= 12)
        {
            var proofs = Game
                .Player.Inventory.GetItems(new TypeIdFilter(3, 3, 10, 8))
                .Where(x => x.Record.Param1 == targetItem.Record.ItemClass);
            items = items.Concat(proofs);
        }

        return items;
    }

    /// <summary>
    ///     Gets the lucky stone.
    /// </summary>
    /// <param name="targetItem">The target item.</param>
    /// <returns></returns>
    public static InventoryItem GetLuckyStone(InventoryItem targetItem)
    {
        return GetStonesByGroup(targetItem, RefMagicOpt.MaterialLuck).FirstOrDefault();
    }

    /// <summary>
    ///     Gets the astral stone.
    /// </summary>
    /// <param name="targetItem">The target item.</param>
    /// <returns></returns>
    public static InventoryItem GetAstralStone(InventoryItem targetItem)
    {
        return GetStonesByGroup(targetItem, RefMagicOpt.MaterialAstral).FirstOrDefault();
    }

    /// <summary>
    ///     Gets the immortal stone.
    /// </summary>
    /// <param name="targetItem">The target item.</param>
    /// <returns></returns>
    public static InventoryItem GetImmortalStone(InventoryItem targetItem)
    {
        return GetStonesByGroup(targetItem, RefMagicOpt.MaterialImmortal).FirstOrDefault();
    }

    /// <summary>
    ///     Gets the steady stone.
    /// </summary>
    /// <param name="targetItem">The target item.</param>
    /// <returns></returns>
    public static InventoryItem GetSteadyStone(InventoryItem targetItem)
    {
        return GetStonesByGroup(targetItem, RefMagicOpt.MaterialSteady).FirstOrDefault();
    }

    /// <summary>
    ///     Gets the stones by group.
    /// </summary>
    /// <param name="targetItem">The target item.</param>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    public static IEnumerable<InventoryItem> GetStonesByGroup(InventoryItem targetItem, string name)
    {
        return Game.Player.Inventory.Where(i =>
            i.Record.Desc1 == name && i.Record.ItemClass == targetItem.Record.Degree
        );
    }

    /// <summary>
    ///     Gets the stones by group.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    public static IEnumerable<InventoryItem> GetStonesByGroup(byte level, string name)
    {
        return Game.Player.Inventory.Where(i => i.Record.Desc1 == name && i.Record.ItemClass == level);
    }

    /// <summary>
    ///     Determines whether [has magic option] [the specified inventory item].
    /// </summary>
    /// <param name="inventoryItem">The inventory item.</param>
    /// <param name="materialGroup">The material group.</param>
    /// <returns>
    ///     <c>true</c> if [has magic option] [the specified inventory item]; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasMagicOption(InventoryItem inventoryItem, string materialGroup)
    {
        if (inventoryItem == null)
            return false;

        foreach (var i in inventoryItem.MagicOptions)
        {
            var option = Game.ReferenceManager.GetMagicOption(i.Id);

            if (option != null && option.Group == materialGroup)
                return true;
        }

        return false;
    }

    /// <summary>
    ///     Gets the elixir items.
    /// </summary>
    /// <param name="elixirType">Type of the elixir.</param>
    /// <returns></returns>
    public static IEnumerable<InventoryItem> GetElixirItems(int degree, ElixirType elixirType = ElixirType.Unspecified)
    {
        Func<int, Func<InventoryItem, bool>> elixirsAndEnhancers = degree switch
        {
            >= 12 => paramValue => item => item.Record.Param1 == degree && item.Record.Param3 == paramValue,
            _ => paramValue => item => item.Record.Param1 == paramValue,
        };
        var predicate = Game.ClientType switch
        {
            >= GameClientType.Chinese => elixirsAndEnhancers,
            _ => paramValue => item => item.Record.Param1 == paramValue,
        };

        if (elixirType == ElixirType.Protector)
            return Game.Player.Inventory.Where(predicate(ParamProtectorElixir));

        if (elixirType == ElixirType.Weapon)
            return Game.Player.Inventory.Where(predicate(ParamWeaponElixir));

        if (elixirType == ElixirType.Accessory)
            return Game.Player.Inventory.Where(predicate(ParamAccessoryElixir));

        if (elixirType == ElixirType.Shield)
            return Game.Player.Inventory.Where(predicate(ParamShieldElixir));

        if (elixirType == ElixirType.Unspecified)
            return Game.Player.Inventory.GetItems(new TypeIdFilter(3, 3, 10, 1));

        return default;
    }

    /// <summary>
    ///     Gets the attribute stones.
    /// </summary>
    /// <param name="targetItem">The target item.</param>
    /// <param name="group">The group.</param>
    /// <returns></returns>
    public static IEnumerable<InventoryItem> GetAttributeStones(InventoryItem targetItem, ItemAttributeGroup group)
    {
        var typeIdFilter = new TypeIdFilter(3, 3, 11, 2);

        var actualGroupName = ItemAttributesInfo.GetActualAttributeGroupNameForItem(targetItem.Record, group);
        var attributeStones = Game
            .Player.Inventory.GetItems(typeIdFilter)
            .Where(i => i.Record.Desc1 == actualGroupName);

        return attributeStones;
    }

    #endregion Methods
}
