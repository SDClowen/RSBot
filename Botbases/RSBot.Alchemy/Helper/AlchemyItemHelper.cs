using RSBot.Alchemy.Client.ReferenceObjects;
using RSBot.Core;
using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Alchemy.Helper
{
    internal class AlchemyItemHelper
    {
        public enum ElixirType
        {
            Shield,
            Weapon,
            Protector,
            Accessory,
            Unspecified
        }

        private const int ParamProtectorElixir = 16909056;
        private const int ParamWeaponElixir = 100663296;
        private const int ParamAccessoryElixir = 83886080;
        private const int ParamShieldElixir = 67108864;

        public static InventoryItem GetLuckyPowder(InventoryItem targetItem)
        {
            return Game.Player.Inventory.GetItems(new TypeIdFilter(3, 3, 10, 2)).FirstOrDefault(i => i.Record.ItemClass == targetItem.Record.Degree);
        }

        public static InventoryItem GetLuckyStone(InventoryItem targetItem)
        {
            return GetStoneByGroup(targetItem, RefMagicOpt.MaterialLuck);
        }

        public static InventoryItem GetAstralStone(InventoryItem targetItem)
        {
            return GetStoneByGroup(targetItem, RefMagicOpt.MaterialAstral);
        }

        public static InventoryItem GetImmortalStone(InventoryItem targetItem)
        {
            return GetStoneByGroup(targetItem, RefMagicOpt.MaterialImmortal);
        }

        public static InventoryItem GetSteadyStone(InventoryItem targetItem)
        {
            return GetStoneByGroup(targetItem, RefMagicOpt.MaterialSteady);
        }

        public static InventoryItem GetStoneByGroup(InventoryItem targetItem, string name)
        {
            return Game.Player.Inventory.FirstOrDefault(i => i.Record.Desc1 == name && i.Record.ItemClass == targetItem.Record.Degree);
        }

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

        public static List<InventoryItem> GetElixirItems(ElixirType elixirType = ElixirType.Unspecified)
        {
            if (elixirType == ElixirType.Protector)
                return Game.Player.Inventory.Where(i => i.Record.Param1 == ParamProtectorElixir).ToList();

            if (elixirType == ElixirType.Weapon)
                return Game.Player.Inventory.Where(i => i.Record.Param1 == ParamWeaponElixir).ToList();

            if (elixirType == ElixirType.Accessory)
                return Game.Player.Inventory.Where(i => i.Record.Param1 == ParamAccessoryElixir).ToList();

            if (elixirType == ElixirType.Shield)
                return Game.Player.Inventory.Where(i => i.Record.Param1 == ParamShieldElixir).ToList();

            if (elixirType == ElixirType.Unspecified)
                return Game.Player.Inventory.GetItems(new TypeIdFilter(3, 3, 10, 1)).ToList();

            return default;
        }
    }
}