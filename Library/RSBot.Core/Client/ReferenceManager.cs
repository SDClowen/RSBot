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

        //public Dictionary<uint, RefObjCommon> ObjectData { get; set; }
        public Dictionary<uint, RefObjChar> CharacterData { get; set; }

        public Dictionary<uint, RefObjStruct> StructData { get; set; }
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

        public GatewayInfo GatewayInfo { get; set; }
        public DivisionInfo DivisionInfo { get; set; }
        public VersionInfo VersionInfo { get; set; }

        public List<RefTeleport> TeleportData { get; set; }
        public List<RefTeleportLink> TeleportLinks { get; set; }

        public void Load(int languageTab)
        {
            this.LanguageTab = languageTab; //until language wizard is reworked?

            DivisionInfo = DivisionInfo.Load();
            GatewayInfo = GatewayInfo.Load();
            VersionInfo = VersionInfo.Load();

            this.TextData = new Dictionary<string, RefText>(50000);

            //this.ObjectData = new Dictionary<uint, RefObjCommon>(50000);
            this.CharacterData = new Dictionary<uint, RefObjChar>(20000);
            this.StructData = new Dictionary<uint, RefObjStruct>(64);
            this.ItemData = new Dictionary<uint, RefObjItem>(20000);

            this.LevelData = new Dictionary<byte, RefLevel>(128);
            this.QuestData = new Dictionary<uint, RefQuest>(1024);

            this.SkillData = new Dictionary<uint, RefSkill>(35000);
            this.SkillMasteryData = new Dictionary<uint, RefSkillMastery>(32);

            this.TeleportData = new List<RefTeleport>(256);
            this.TeleportLinks = new List<RefTeleportLink>(256);

            this.Shops = new Dictionary<string, RefShop>(128);
            this.ShopTabs = new Dictionary<string, RefShopTab>(256);
            this.ShopGroups = new Dictionary<string, RefShopGroup>(128);
            this.ShopGoods = new List<RefShopGood>(4096);
            this.ShopGroupMapping = new List<RefMappingShopGroup>(128);
            this.ShopTabMapping = new List<RefMappingShopWithTab>(128);
            this.PackageItemScrap = new Dictionary<string, RefPackageItemScrap>(2048);

            Parallel.Invoke
            (
                () => this.LoadTextData(),

                () => this.LoadReferenceListFile("CharacterData.txt", this.CharacterData),
                () => this.LoadReferenceFile("TeleportBuilding.txt", this.StructData),
                () => this.LoadReferenceListFile("ItemData.txt", this.ItemData),

                () => this.LoadReferenceListFileEnc("SkillDataEnc.txt", this.SkillData),
                () => this.LoadReferenceFile("SkillMasteryData.txt", this.SkillMasteryData),

                () => this.LoadReferenceFile("LevelData.txt", this.LevelData),
                () => this.LoadReferenceFile("QuestData.txt", this.QuestData),

                () => this.LoadReferenceFile("TeleportData.txt", this.TeleportData),
                () => this.LoadReferenceFile("TeleportLink.txt", this.TeleportLinks),

                () => this.LoadReferenceFile("RefShop.txt", this.Shops),
                () => this.LoadReferenceFile("RefShopTab.txt", this.ShopTabs),
                () => this.LoadReferenceFile("RefShopGroup.txt", this.ShopGroups),
                () => this.LoadReferenceFile("RefShopGoods.txt", this.ShopGoods),
                () => this.LoadReferenceFile("RefMappingShopGroup.txt", this.ShopGroupMapping),
                () => this.LoadReferenceFile("RefMappingShopWithTab.txt", this.ShopTabMapping),
                () => this.LoadReferenceFile("RefScrapOfPackageItem.txt", this.PackageItemScrap)
            );

            //this.CopyObjects(this.CharacterData, this.ObjectData);
            //this.CopyObjects(this.StructData, this.ObjectData);
            //this.CopyObjects(this.ItemData, this.ObjectData);
            GC.Collect();
            Console.WriteLine("Loading SkillData:{0}", SkillData.Count);
            EventManager.FireEvent("OnLoadGameData");
        }

        private void LoadTextData()
        {
            //Load TextData synchronously, so we don't need lock
            this.LoadReferenceFile("TextUISystem.txt", this.TextData);
            this.LoadReferenceFile("TextZoneName.txt", this.TextData);
            this.LoadReferenceListFile("TextDataName.txt", this.TextData);
            this.LoadReferenceListFile("TextQuest.txt", this.TextData);
            
        }

        private void CopyObjects<TKey, TSource>(IDictionary<TKey, TSource> source, IDictionary<TKey, RefObjCommon> destination)
            where TSource : RefObjCommon
        {
            foreach (var item in source)
                destination[item.Key] = item.Value;
        }

        #region TO BE MERGED INTO FEWER FUNCTIONS SOON(TM)

        private void LoadReferenceListFileEnc<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
    where TReference : IReference<TKey>, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                this.LoadReferenceListFileEnc(stream, destination);
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

                    this.LoadReferenceFileEnc(line, destination);
                }
            }
        }

        private void LoadReferenceFileEnc<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                this.LoadReferenceFileEnc(stream, destination);
        }

        private void LoadReferenceFileEnc<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var decryptedStream = new MemoryStream())
            {
                SkillCryptoHelper.DecryptStream(stream, decryptedStream, 0x8C1F);
                decryptedStream.Seek(0, SeekOrigin.Begin);

                this.LoadReferenceFile(decryptedStream, destination);
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
                this.LoadReferenceListFile(stream, destination);
        }

        private void LoadReferenceFile<TReference>(string fileName, IList<TReference> destination)
            where TReference : IReference, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                this.LoadReferenceFile(stream, destination);
        }

        private void LoadReferenceFile<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
            where TReference : IReference<TKey>, new()
        {
            using (var stream = Game.MediaPk2.GetFile(fileName).GetStream())
                this.LoadReferenceFile(stream, destination);
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

                    this.LoadReferenceFile(line, destination);
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

                    this.LoadReferenceFile(line, destination);
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

        #endregion TO BE MERGED INTO FEWER FUNCTIONS SOON(TM)

        #region GetObject

        /// <summary>
        /// Gets the tab.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        /// <returns></returns>
        public RefShopTab GetTab(string codeName)
        {
            return this.ShopTabs[codeName];
        }

        public string GetTranslation(string name)
        {
            if (this.TextData.TryGetValue(name, out RefText refText))
                return refText.Data;

            return name;
        }

        //public TObj GetRefObj<TObj>(uint id)
        //    where TObj : RefObjCommon
        //{
        //    if (this.ObjectData.TryGetValue(id, out RefObjCommon refObjCommon))
        //    {
        //        if (refObjCommon is TObj obj)
        //            return obj;

        //        throw new ArgumentException($"[{refObjCommon.CodeName}] does not match the TObj ({typeof(TObj).Name})?");
        //    }

        //    return null;
        //}

        public RefObjCommon GetRefObjCommon(uint refObjID)
        {
            if (this.CharacterData.TryGetValue(refObjID, out RefObjChar refChar))
                return refChar;

            if (this.StructData.TryGetValue(refObjID, out RefObjStruct refStruct))
                return refStruct;

            if (this.ItemData.TryGetValue(refObjID, out RefObjItem refItem))
                return refItem;

            return null;
        }

        public RefObjChar GetRefObjChar(uint id)
        {
            if (this.CharacterData.TryGetValue(id, out RefObjChar data))
                return data;

            return null;
        }

        public RefObjChar GetRefObjChar(string codeName)
        {
            return this.CharacterData.FirstOrDefault(obj => obj.Value.CodeName == codeName).Value;
        }

        public RefObjStruct GetRefStruct(uint id)
        {
            if (this.StructData.TryGetValue(id, out RefObjStruct data))
                return data;

            return null;
        }

        public RefObjItem GetRefItem(uint id)
        {
            if (this.ItemData.TryGetValue(id, out RefObjItem data))
                return data;

            return null;
        }

        public RefObjItem GetRefItem(string codeName)
        {
            return this.ItemData.FirstOrDefault(obj => obj.Value.CodeName == codeName).Value;
        }

        public RefSkill GetRefSkill(uint id)
        {
            if (this.SkillData.TryGetValue(id, out RefSkill data))
                return data;

            return null;
        }

        public RefSkillMastery GetRefSkillMastery(uint id)
        {
            if (this.SkillMasteryData.TryGetValue(id, out RefSkillMastery data))
                return data;

            return null;
        }

        public RefQuest GetRefQuest(uint id)
        {
            if (this.QuestData.TryGetValue(id, out RefQuest data))
                return data;

            return null;
        }

        public RefLevel GetRefLevel(byte level)
        {
            if (this.LevelData.TryGetValue(level, out RefLevel data))
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
            return PackageItemScrap[GetRefShopGroup(npcCodeName).GetShops()[0].GetTabs()[tab].GetGoods().FirstOrDefault(s => s.SlotIndex == slot).RefPackageItemCodeName];
        }

        public RefPackageItemScrap GetRefPackageItemById(ushort id, byte group, byte tab, byte slot)
        {
            return PackageItemScrap[GetRefShopGroupById(id).GetShops()[group].GetTabs()[tab].GetGoods().FirstOrDefault(s => s.SlotIndex == slot).RefPackageItemCodeName];
        }

        public RefPackageItemScrap GetRefPackageItem(string codeName)
        {
            if (this.PackageItemScrap.TryGetValue(codeName, out RefPackageItemScrap data))
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
            var result = new List<RefObjItem>();

            foreach (var refItem in ItemData.Values)
            {
                foreach (var filter in filters)
                {
                    if (!filter.EqualsRefItem(refItem)) 
                        continue;

                    if (refItem.Service != 1) 
                        continue;

                    //Gear
                    if (refItem.TypeID2 == 1)
                    {
                        if (refItem.Degree >= degreeFrom && refItem.Degree <= degreeTo || degreeTo == 0)
                        {
                            var itemGender = (ObjectGender)refItem.ReqGender;
                            if (itemGender == gender || gender == ObjectGender.Neutral)
                            {
                                if (!string.IsNullOrEmpty(searchPattern))
                                {
                                    var itemRealName = refItem.GetRealName();

                                    if (itemRealName.IndexOf(searchPattern, StringComparison.InvariantCultureIgnoreCase) < 0)
                                        continue;
                                }

                                if (rare && (byte)refItem.Rarity < 2)
                                    continue;

                                result.Add(refItem);
                            }
                        }

                        continue;
                    }

                    //ETC
                    if (!string.IsNullOrEmpty(searchPattern))
                    {
                        var itemRealName = refItem.GetRealName();

                        if (itemRealName.IndexOf(searchPattern, StringComparison.InvariantCultureIgnoreCase) < 0)
                            continue;
                    }

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

        #endregion GetObject
    }
}