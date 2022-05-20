using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Cryptography;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Client
{
    public class ReferenceManager
    {
        public int LanguageTab { get; set; }

        public Dictionary<string, RefText> TextData { get; set; }
        public Dictionary<uint, RefObjChar> CharacterData { get; set; }
        public Dictionary<uint, RefObjItem> ItemData { get; set; }
        public Dictionary<byte, RefLevel> LevelData { get; set; }
        public Dictionary<uint, RefQuest> QuestData { get; set; }
        public Dictionary<uint, RefSkill> SkillData { get; set; }
        public Dictionary<uint, RefSkillMastery> SkillMasteryData { get; set; }
        public Dictionary<string, RefShop> Shops { get; set; }
        public Dictionary<string, RefShopTab> ShopTabs { get; set; }
        public Dictionary<string, RefShopGroup> ShopGroups { get; set; }
        public List<RefMappingShopGroup> ShopGroupMapping { get; set; }
        public List<RefMappingShopWithTab> ShopTabMapping { get; set; }
        public List<RefShopGood> ShopGoods { get; set; }
        public Dictionary<string, RefPackageItemScrap> PackageItemScrap { get; set; }
        public List<RefTeleport> TeleportData { get; set; }
        public List<RefTeleportLink> TeleportLinks { get; set; }
        public GatewayInfo GatewayInfo { get; set; }
        public DivisionInfo DivisionInfo { get; set; }
        public VersionInfo VersionInfo { get; set; }

        /// <summary>
        /// Gets the list of magic options
        /// </summary>
        public List<RefMagicOpt> MagicOptions { get; private set; }

        /// <summary>
        /// Gets the list of all magic option assignments
        /// </summary>
        public List<RefMagicOptAssign> MagicOptionAssignments { get; private set; }

        public void Load(int languageTab)
        {
            LanguageTab = languageTab; //until language wizard is reworked?

            DivisionInfo = DivisionInfo.Load();
            GatewayInfo = GatewayInfo.Load();
            VersionInfo = VersionInfo.Load();

            TextData = new Dictionary<string, RefText>(50000);

            //this.ObjectData = new Dictionary<uint, RefObjCommon>(50000);
            CharacterData = new Dictionary<uint, RefObjChar>(20000);
            ItemData = new Dictionary<uint, RefObjItem>(20000);

            LevelData = new Dictionary<byte, RefLevel>(128);
            QuestData = new Dictionary<uint, RefQuest>(1024);

            SkillData = new Dictionary<uint, RefSkill>(35000);
            SkillMasteryData = new Dictionary<uint, RefSkillMastery>(32);

            TeleportData = new List<RefTeleport>(256);
            TeleportLinks = new List<RefTeleportLink>(256);

            Shops = new Dictionary<string, RefShop>(128);
            ShopTabs = new Dictionary<string, RefShopTab>(256);
            ShopGroups = new Dictionary<string, RefShopGroup>(128);
            ShopGoods = new List<RefShopGood>(4096);
            ShopGroupMapping = new List<RefMappingShopGroup>(128);
            ShopTabMapping = new List<RefMappingShopWithTab>(128);
            PackageItemScrap = new Dictionary<string, RefPackageItemScrap>(2048);

            MagicOptionAssignments = new List<RefMagicOptAssign>(128);
            MagicOptions = new List<RefMagicOpt>(1024);

            Parallel.Invoke
            (
                () => LoadTextData(),
                () => LoadConditionalData("CharacterData.txt", CharacterData),
                () => LoadConditionalData("ItemData.txt", ItemData),
                () => LoadSkillData(),
                () => LoadReferenceFile("TeleportBuilding.txt", CharacterData),
                () => LoadReferenceFile("SkillMasteryData.txt", SkillMasteryData),
                () => LoadReferenceFile("LevelData.txt", LevelData),
                () => LoadReferenceFile("QuestData.txt", QuestData),
                () => LoadReferenceFile("TeleportData.txt", TeleportData),
                () => LoadReferenceFile("TeleportLink.txt", TeleportLinks),
                () => LoadReferenceFile("RefShop.txt", Shops),
                () => LoadReferenceFile("RefShopTab.txt", ShopTabs),
                () => LoadRefShopGoods("RefShopGoods.txt"),
                () => LoadReferenceFile("RefShopGroup.txt", ShopGroups),
                () => LoadReferenceFile("RefMappingShopGroup.txt", ShopGroupMapping),
                () => LoadReferenceFile("RefMappingShopWithTab.txt", ShopTabMapping),
                () => LoadScrapOfPackageItemData("RefScrapOfPackageItem.txt"),
                () => LoadReferenceFile("magicoption.txt", MagicOptions),
                () => LoadReferenceFile("magicoptionassign.txt", MagicOptionAssignments)
            );

            GC.Collect();
            EventManager.FireEvent("OnLoadGameData");
        }

        private void LoadTextData()
        {
            if (Game.ClientType >= GameClientType.Global)
                LoadReferenceListFile("TextUISystem.txt", TextData);
            else
                LoadReferenceFile("TextUISystem.txt", TextData);

            if (Game.ClientType >= GameClientType.Global)
                LoadReferenceListFile("TextZoneName.txt", TextData);
            else
                LoadReferenceFile("TextZoneName.txt", TextData);

            if (Game.ClientType >= GameClientType.Global)
            {
                LoadReferenceListFile("TextQuest_OtherString.txt", TextData);
                LoadReferenceListFile("TextData_Object.txt", TextData);
                LoadReferenceListFile("TextData_Equip&Skill.txt", TextData);
                LoadReferenceListFile("TextQuest_Speech&Name.txt", TextData);
                LoadReferenceListFile("TextQuest_QuestString.txt", TextData);
            }
            else
            {
                if (Game.ClientType >= GameClientType.Thailand)
                {
                    LoadReferenceListFile("TextDataName.txt", TextData);
                    LoadReferenceListFile("TextQuest.txt", TextData);
                    return;
                }

                LoadReferenceFile("TextDataName.txt", TextData);
                LoadReferenceFile("TextQuest.txt", TextData);
            }
        }

        private void LoadRefShopGoods(string file)
        {
            if (Game.ClientType > GameClientType.Chinese)
                LoadReferenceListFile(file, ShopGoods);
            else
                LoadReferenceFile(file, ShopGoods);
        }

        private void LoadScrapOfPackageItemData(string file)
        {
            if (Game.ClientType > GameClientType.Chinese)
                LoadReferenceListFile(file, PackageItemScrap);
            else
                LoadReferenceFile(file, PackageItemScrap);
        }

        private void LoadConditionalData<TKey, TReference>(string file, IDictionary<TKey, TReference> collection)
            where TReference : IReference<TKey>, new()
        {
            if (Game.ClientType < GameClientType.Thailand)
                LoadReferenceFile(file, collection);
            else
                LoadReferenceListFile(file, collection);
        }

        private void LoadSkillData()
        {
            if (Game.ClientType == GameClientType.Vietnam ||
                Game.ClientType == GameClientType.Vietnam274)
                LoadReferenceListFileEnc("SkillDataEnc.txt", SkillData);
            else if (Game.ClientType < GameClientType.Thailand)
                LoadReferenceFile("SkillData.txt", SkillData);
            else
                LoadReferenceListFile("SkillData.txt", SkillData);
        }

        private void LoadReferenceListFileEnc<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
    where TReference : IReference<TKey>, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                LoadReferenceListFileEnc(stream, destination);
        }

        private void LoadReferenceListFileEnc<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLineByCRLF();

                    //Skip invalid
                    if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                        continue;

                    LoadReferenceFileEnc(line, destination);
                }
            }
        }

        private void LoadReferenceFileEnc<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                LoadReferenceFileEnc(stream, destination);
        }

        private void LoadReferenceFileEnc<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var decryptedStream = new MemoryStream())
            {
                SkillCryptoHelper.DecryptStream(stream, decryptedStream, 0x8C1F);
                decryptedStream.Seek(0, SeekOrigin.Begin);

                LoadReferenceFile(decryptedStream, destination);
            }
        }

        private void LoadReferenceListFile<TReference>(string fileName, IList<TReference> destination)
            where TReference : IReference, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                LoadReferenceListFile(stream, destination);
        }

        private void LoadReferenceListFile<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                LoadReferenceListFile(stream, destination);
        }

        private void LoadReferenceFile<TReference>(string fileName, IList<TReference> destination)
            where TReference : IReference, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                LoadReferenceFile(stream, destination);
        }

        private void LoadReferenceFile<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                LoadReferenceFile(stream, destination);
        }

        private void LoadReferenceListFile<TReference>(Stream stream, IList<TReference> destination) where TReference : IReference, new()
        {
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLineByCRLF();

                    //Skip invalid
                    if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                        continue;

                    LoadReferenceFile(line, destination);
                }
            }
        }

        private void LoadReferenceListFile<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination) where TReference : IReference<TKey>, new()
        {
            using (var reader = new StreamReader(stream))
            {
                var builder = new StringBuilder(1024);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLineByCRLF(builder);

                    //Skip invalid
                    if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                        continue;

                    LoadReferenceFile(line, destination);
                }
            }
        }

        private void LoadReferenceFile<TReference>(Stream stream, IList<TReference> destination) where TReference : IReference, new()
        {
            using (var reader = new StreamReader(stream))
            {
                var builder = new StringBuilder(1024);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLineByCRLF(builder);

                    //Skip invalid
                    if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                        continue;

                    try
                    {
                        var reference = new TReference();
                        if (reference.Load(new ReferenceParser(line)))
                            destination.Add(reference);
                    }
                    catch
                    {
                        Debug.WriteLine($"Exception in reference line: {line}");
                    }
                }
            }
        }

        private void LoadReferenceFile<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLineByCRLF();

                    //Skip invalid
                    if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                        continue;

                    try
                    {
                        var reference = new TReference();
                        if (reference.Load(new ReferenceParser(line)))
                            destination[reference.PrimaryKey] = reference;
                    }
                    catch
                    {
                        Debug.WriteLine($"Exception in reference line: {line}");
                    }
                }
            }
        }

        /// <summary>
        /// Gets the tab.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        /// <returns></returns>
        public RefShopTab GetTab(string codeName)
        {
            return ShopTabs[codeName];
        }

        public string GetTranslation(string name)
        {
            if (TextData.TryGetValue(name, out RefText refText))
                return refText.Data;

            return name;
        }

        public RefObjCommon GetRefObjCommon(uint refObjID)
        {
            if (CharacterData.TryGetValue(refObjID, out RefObjChar refChar))
                return refChar;

            if (ItemData.TryGetValue(refObjID, out RefObjItem refItem))
                return refItem;

            return null;
        }

        public RefObjChar GetRefObjChar(uint id)
        {
            if (CharacterData.TryGetValue(id, out RefObjChar data))
                return data;

            return null;
        }

        public RefObjChar GetRefObjChar(string codeName)
        {
            return CharacterData.FirstOrDefault(obj => obj.Value.CodeName == codeName).Value;
        }

        public RefObjItem GetRefItem(uint id)
        {
            if (ItemData.TryGetValue(id, out RefObjItem data))
                return data;

            return null;
        }

        public RefObjItem GetRefItem(string codeName)
        {
            return ItemData.FirstOrDefault(obj => obj.Value.CodeName == codeName).Value;
        }

        public RefObjItem GetRefItem(TypeIdFilter filter)
        {
            return ItemData.FirstOrDefault(obj => filter.EqualsRefItem(obj.Value)).Value;
        }

        public RefSkill GetRefSkill(uint id)
        {
            if (SkillData.TryGetValue(id, out RefSkill data))
                return data;

            return null;
        }

        public RefSkillMastery GetRefSkillMastery(uint id)
        {
            if ((Game.ClientType == GameClientType.Chinese) &&
                id >= 273 && id <= 275)
                id = 277; // csro shit

            if (SkillMasteryData.TryGetValue(id, out RefSkillMastery data))
                return data;

            return null;
        }

        public RefQuest GetRefQuest(uint id)
        {
            if (QuestData.TryGetValue(id, out RefQuest data))
                return data;

            return null;
        }

        public RefLevel GetRefLevel(byte level)
        {
            if (LevelData.TryGetValue(level, out RefLevel data))
                return data;

            return null;
        }

        public RefShopGroup GetRefShopGroup(string npcCodeName)
        {
            return ShopGroups.FirstOrDefault(sg => sg.Value.RefNpcCodeName == npcCodeName).Value;
        }

        public RefShopGroup GetRefShopGroupById(ushort id)
        {
            return ShopGroups.FirstOrDefault(sg => sg.Value.Id == id).Value;
        }

        public RefPackageItemScrap GetRefPackageItem(string npcCodeName, byte tab, byte slot)
        {
            var shops = GetRefShopGroup(npcCodeName).GetShops();
            var tabs = shops[0].GetTabs();
            var goods = tabs[tab].GetGoods();
            return PackageItemScrap[goods.FirstOrDefault(s => s.SlotIndex == slot)?.RefPackageItemCodeName];
        }

        public RefPackageItemScrap GetRefPackageItemById(ushort id, byte group, byte tab, byte slot)
        {
            return PackageItemScrap[GetRefShopGroupById(id).GetShops()[group].GetTabs()[tab].GetGoods().FirstOrDefault(s => s.SlotIndex == slot).RefPackageItemCodeName];
        }

        public RefPackageItemScrap GetRefPackageItem(string codeName)
        {
            if (PackageItemScrap.TryGetValue(codeName, out RefPackageItemScrap data))
                return data;

            return null;
        }

        public List<RefPackageItemScrap> GetRefPackageItems(RefShopGroup group)
        {
            var result = new List<RefPackageItemScrap>();
            foreach (var shop in group.GetShops())
            {
                if (shop == null) continue;
                foreach (var tab in shop.GetTabs())
                {
                    if (tab == null) continue;
                    foreach (var good in tab.GetGoods())
                    {
                        if (good == null) continue;

                        if (!PackageItemScrap.ContainsKey(good.RefPackageItemCodeName)) continue;

                        if (result.FirstOrDefault(g => g.RefPackageItemCodeName == good.RefPackageItemCodeName) == null)
                            result.Add(PackageItemScrap[good.RefPackageItemCodeName]);
                    }
                }
            }

            return result;
        }

        public RefShopGood GetRefShopGood(string refPackageItemCodeName)
        {
            return ShopGoods.FirstOrDefault(sg => sg.RefPackageItemCodeName == refPackageItemCodeName);
        }

        public List<RefShopGood> GetRefShopGoods(RefShopGroup group)
        {
            return (from shop in @group.GetShops() where shop != null from tab in shop.GetTabs() where tab != null from good in tab.GetGoods() where good != null select good).ToList();
        }

        public byte GetRefShopGoodTabIndex(string npcCodeName, RefShopGood good)
        {
            var shopGroup = GetRefShopGroup(npcCodeName);
            if (shopGroup == null) return 0xFF;

            var availableShops = shopGroup.GetShops();

            foreach (var shop in availableShops)
            {
                var availableTabs = shop.GetTabs();

                for (byte i = 0; i < availableTabs.Count; i++)
                {
                    var goods = availableTabs[i].GetGoods();
                    var availableGood =
                        goods.FirstOrDefault(g => g.RefPackageItemCodeName == good.RefPackageItemCodeName);

                    if (availableGood != null)
                        return i;
                }
            }
            return 0xFF;
        }

        /// <summary>
        /// Gets the filtered items.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="degreeFrom">The degree from.</param>
        /// <param name="degreeTo">The degree to.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns></returns>
        public List<RefObjItem> GetFilteredItems(
            List<TypeIdFilter> filters,
            byte degreeFrom = 0,
            byte degreeTo = 0,
            ObjectGender gender = ObjectGender.Neutral,
            bool rare = false,
            string searchPattern = null)
        {
            var result = new List<RefObjItem>(10000);
            foreach (var refItem in ItemData.Values)
            {
                if (refItem.IsGold)
                    continue;

                foreach (var filter in filters)
                {
                    // step 1 compare typeids
                    if (!filter.EqualsRefItem(refItem))
                        continue;

                    // step 2 compare gender
                    var itemGender = (ObjectGender)refItem.ReqGender;
                    if (gender != ObjectGender.Neutral && itemGender != gender)
                        continue;

                    // step 3 compare searching item name
                    if (!string.IsNullOrEmpty(searchPattern))
                    {
                        var itemRealName = refItem.GetRealName();

                        if (itemRealName.IndexOf(searchPattern, StringComparison.InvariantCultureIgnoreCase) == -1)
                            continue;
                    }

                    // step 4 compare rare
                    if (rare && (byte)refItem.Rarity < 2)
                        continue;

                    // step 5 compare minimum degree
                    // dont need to check the if it is equip items
                    if (degreeFrom != 0 && refItem.Degree < degreeFrom)
                        continue;

                    // step 6 compare maximum degree
                    // dont need to check the if it is equip items
                    if (degreeTo != 0 && refItem.Degree > degreeTo)
                        continue;

                    result.Add(refItem);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the teleporters in the specific sector
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns></returns>
        public RefTeleport[] GetTeleporters(ushort regionId)
        {
            return TeleportData.Where(t => t.GenRegionID == regionId).ToArray();
        }

        /// <summary>
        /// Gets the ground teleporters.
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        /// <returns></returns>
        public RefTeleport[] GetGroundTeleporters(ushort regionId)
        {
            return TeleportData.Where(t => t.GenRegionID == regionId && t.AssocRefObjId == 0).ToArray();
        }

        /// <summary>
        /// Gets a magic option by its id
        /// </summary>
        /// <param name="id">The id of the magic option</param>
        /// <returns></returns>
        public RefMagicOpt GetMagicOption(uint id)
        {
            return MagicOptions?.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Gets the first magic option of the specified group
        /// </summary>
        /// <param name="group">The group</param>
        /// <returns></returns>
        public RefMagicOpt GetMagicOption(string group)
        {
            return MagicOptions?.FirstOrDefault(m => m.Group == group);
        }

        /// <summary>
        /// Gets a magic option by its group and degree
        /// </summary>
        /// <param name="group">The group</param>
        /// <param name="degree">The degree</param>
        /// <returns></returns>
        public RefMagicOpt GetMagicOption(string group, byte degree)
        {
            return MagicOptions?.FirstOrDefault(m => m.Group == group && m.Level == degree);
        }

        /// <summary>
        /// Gets a list of magic options for the specified type ids
        /// </summary>
        /// <param name="typeId3">The TID3</param>
        /// <param name="typeId4">The TID4</param>
        /// <returns></returns>
        public List<RefMagicOpt> GetAssignments(byte typeId3, byte typeId4)
        {
            return MagicOptionAssignments.FirstOrDefault(a => a.TypeId3 == typeId3 && a.TypeId4 == typeId4)?.AvailableMagicOptions.Select(GetMagicOption).ToList();
        }
    }
}