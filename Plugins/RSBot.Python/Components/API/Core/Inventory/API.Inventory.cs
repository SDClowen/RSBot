using Python.Runtime;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Python.Components.API.Interface;
using RSBot.Python.Views;
using System.Collections.Generic;
using static System.Windows.Forms.Design.AxImporter;

namespace RSBot.Python.Components.API.Core.Inventory
{
    public class InventoryAPI : IPythonPlugin
    {
        private Main _main;

        /// <summary>
        /// Unique module name of the plugin.
        /// </summary>
        public string ModuleName => "inventory";

        /// <summary>
        /// Called once at startup to provide the main form to the plugin.
        /// </summary>
        /// <param name="main">Main form</param>
        public void Init(Main main)
        {
            _main = main;
        }
        
        private PyList BuildItemList(IEnumerable<InventoryItem> items)
        {
            var list = new PyList();

            foreach (var item in items)
            {
                if (item == null)
                    continue;

                var pyItem = new PyDict();
                pyItem.SetItem(new PyString("model"), new PyInt(item.ItemId));
                pyItem.SetItem(new PyString("servername"), new PyString(item.Record.CodeName));
                pyItem.SetItem(new PyString("name"), new PyString(item.Record.GetRealName()));
                pyItem.SetItem(new PyString("quantity"), new PyInt(item.Amount));
                pyItem.SetItem(new PyString("plus"), new PyInt(item.OptLevel));
                pyItem.SetItem(new PyString("rarity"), new PyString(item.Record.GetRarityName()));
                pyItem.SetItem(new PyString("durability"), new PyInt(item.Durability));
                pyItem.SetItem(new PyString("slot"), new PyInt(item.Slot));
                if (item.MagicOptions != null)
                {
                    var pyOptions = new PyList();
                    foreach (var magicOption in item.MagicOptions)
                    {
                        var option = Game.ReferenceManager.GetMagicOption(magicOption.Id);

                        if (option != null)
                            pyOptions.Append(new PyString(GetFusingTranslation(option,magicOption.Value)));
                    }
                    pyItem.SetItem(new PyString("magic_options"), new PyList(pyOptions));

                }
                if (item.Attributes != 0)
                {                    
                    var availableAttributes = ItemAttributesInfo.GetAvailableAttributeGroupsForItem(item.Record);

                    if (availableAttributes != null)
                    {
                        var pyAttributes = new PyList();
                        foreach (var attribute in availableAttributes)
                        {
                            var slot = ItemAttributesInfo.GetAttributeSlotForItem(attribute, item.Record);
                            var translation = attribute.GetTranslation();

                            pyAttributes.Append(new PyString($"{translation} +{item.Attributes.GetPercentage(slot)}%"));
                        }
                        pyItem.SetItem(new PyString("attributes"), new PyList(pyAttributes));
                    }

                }

                list.Append(pyItem);
            }

            return list;
        }
        private PyDict GetInventory()
        {
            using (Py.GIL())
            {
                var result = new PyDict();

                if (Game.Player == null || Game.Player.Inventory == null)
                {
                    result.SetItem(new PyString("size"), new PyInt(0));
                    result.SetItem(new PyString("gold"), new PyString("0"));
                    result.SetItem(new PyString("equipped"), new PyList());
                    result.SetItem(new PyString("inventory"), new PyList());
                    result.SetItem(new PyString("avatar"), new PyList());
                    return result;
                }
                var inventorySize = Game.Player.Inventory.Capacity;
                var gold = Game.Player.Gold;
                result.SetItem(new PyString("size"), new PyInt(inventorySize));
                result.SetItem(new PyString("gold"), new PyString(gold.ToString()));                

                var itemsEquipped = Game.Player.Inventory.GetEquippedPartItems();
                var itemsInventory = Game.Player.Inventory.GetNormalPartItems();
                var itemsAvatar = Game.Player.Avatars;

                var pyEquippedList = BuildItemList(itemsEquipped);
                var pyInventoryList = BuildItemList(itemsInventory);
                var pyAvatarList = BuildItemList(itemsAvatar);

                result.SetItem(new PyString("equipped"), pyEquippedList);
                result.SetItem(new PyString("items"), pyInventoryList);
                result.SetItem(new PyString("avatar"), pyAvatarList);

                return result;
            }
        }
        private PyList GetStorage()
        {
            using (Py.GIL())
            {
                var result = new PyList();

                if (Game.Player == null || Game.Player.Storage == null)
                {
                    return result;
                }
                var storage = Game.Player.Storage;
                result = BuildItemList(storage);

                return result;

            }
        }
        private PyList GetGuildStorage()
        {
            using (Py.GIL())
            {
                var result = new PyList();

                if (Game.Player == null || Game.Player.GuildStorage == null)
                {
                    return result;
                }
                var storage = Game.Player.GuildStorage;
                result = BuildItemList(storage);

                return result;

            }
        }
        private PyList GetPetStorage()
        {
            using (Py.GIL())
            {
                var result = new PyList();

                if (Game.Player == null || !Game.Player.HasActiveAbilityPet)
                {
                    return result;
                }
                var storage = Game.Player.AbilityPet.Inventory;
                result = BuildItemList(storage);

                return result;

            }
        }
        private PyDict GetJobPouch()
        {
            using (Py.GIL())
            {
                var result = new PyDict();

                if (Game.Player == null || Game.Player.Job2SpecialtyBag == null)
                {
                    return result;
                }
                var storage = Game.Player.Job2SpecialtyBag;
                result.SetItem(new PyString("size"), new PyInt(storage.Capacity));
                result.SetItem(new PyString("free_slots"), new PyInt(storage.FreeSlots));
                var list = new PyList();

                foreach (var item in storage)
                {
                    if (item == null)
                        continue;

                    var pyItem = new PyDict();
                    pyItem.SetItem(new PyString("servername"), new PyString(item.Record.CodeName));
                    pyItem.SetItem(new PyString("name"), new PyString(item.Record.GetRealName()));
                    pyItem.SetItem(new PyString("quantity"), new PyInt(item.Amount));
                    pyItem.SetItem(new PyString("slot"), new PyInt(item.Slot));

                    list.Append(pyItem);
                }
                result.SetItem(new PyString("items"), list);
                return result;

            }
        }
        public PyDict get_inventory()
        {
            return GetInventory();
        }
        public PyList get_storage()
        {
            return GetStorage();
        }
        public PyList get_guild_storage()
        {
            return GetGuildStorage();
        }
        public PyDict get_job_pouch()
        {
            return GetJobPouch();
        }
        public PyList get_pet_storage()
        {
            return GetPetStorage();
        }
        public string GetFusingTranslation(RefMagicOpt magicOption, uint value)
        {
            //TODO: Use and extend GetGroupTranslation instead of hard coding this
            switch (magicOption?.Group)
            {
                case "MATTR_INT":
                case "MATTR_AVATAR_INT":
                case "MATTR_INT_AVATAR":
                    return $"Int {value} Increase";

                case "MATTR_STR":
                case "MATTR_STR_AVATAR":
                case "MATTR_AVATAR_STR":
                    return $"Str {value} Increase";

                case "MATTR_DUR":
                case "MATTR_AVATAR_DRUA":
                    return $"Durability {value}% Increase";

                case "MATTR_EVADE_BLOCK":
                    return $"Blocking rate {value}";

                case "MATTR_AVATAR_DARA":
                    return $"Damage Absorption {value}% Increase";

                case "MATTR_AVATAR_ER":
                case "MATTR_ER":
                    return $"Parry rate {value}% Increase";

                case "MATTR_HR":
                case "MATTR_AVATAR_HR":
                    return $"Attack rate {value}% Increase";

                case "MATTR_RESIST_FROSTBITE":
                    return $"Freezing,FrostbiteHour {value}% Reduce";

                case "MATTR_RESIST_ESHOCK":
                    return $"Electrict shockHour {value}% Reduce";

                case "MATTR_RESIST_BURN":
                    return $"BurnHour {value}% Reduce";

                case "MATTR_RESIST_POISON":
                    return $"PoisoningHour {value}% Reduce";

                case "MATTR_LUCK":
                    return $"Lucky({value}Time/times)";

                case "MATTR_SOLID":
                    return $"Steady({value}Time/times)";
                    ;
                case "MATTR_ASTRAL":
                    return $"Astral({value}Time/times)";

                case "MATTR_ATHANASIA":
                    return $"Immortal({value}Time/times)";

                case "MATTR_AVATAR_MDIA":
                case "MATTR_AVATAR_MDIA_2":
                case "MATTR_AVATAR_MDIA_3":
                case "MATTR_AVATAR_MDIA_4":
                    return $"Ignore Monster Defense {value}% Probability";

                case "MATTR_HP":
                case "MATTR_AVATAR_HP":
                    return $"HP {value} Increase";

                case "MATTR_MP":
                case "MATTR_AVATAR_MP":
                    return $"MP {value} Increase";

                case "MATTR_CRITICAL":
                case "MATTR_EVADE_CRITICAL":
                    return $"Critical {value}";

                case "MATTR_NOT_REPARABLE":
                    return "Not repairable";

                case "MATTR_REGENHPMP":
                    return $"HP recovery/MP recovery {value}% Increase";

                case "MATTR_RESIST_ZOMBIE":
                    return $"ZombieHour {value}% Reduce";

                case "MATTR_RESIST_CSMP":
                    return $"CombustionProbability {value}% Reduce";

                case "MATTR_RESIST_SLEEP":
                    return $"SleepProbability {value}% Reduce";

                case "MATTR_RESIST_STUN":
                    return $"StunProbability {value}% Reduce";

                case "MATTR_RESIST_FEAR":
                    return $"FearProbability {value}% Reduce";

                case "MATTR_RESIST_DISEASE":
                    return $"DiseaseProbability {value}% Reduce";

                case "MATTR_DEC_MAXDUR":
                    return $"Maximum durability {value}% Reduce";
            }

            return magicOption?.Group ?? $"Error. Mag. opt. value: {value}";
        }
    }

}
