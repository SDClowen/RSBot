using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Cryptography;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.NavMeshApi;

namespace RSBot.Core.Client;

public class ReferenceManager
{
    private const string ServerDep = "server_dep\\silkroad\\textdata";

    public int LanguageTab { get; set; }

    public Dictionary<string, RefText> TextData { get; } = new(50000);
    public Dictionary<uint, RefObjChar> CharacterData { get; } = new(20000);
    public Dictionary<uint, RefObjItem> ItemData { get; } = new(20000);
    public Dictionary<byte, RefLevel> LevelData { get; } = new(128);
    public Dictionary<uint, RefQuest> QuestData { get; } = new(1024);
    public Dictionary<uint, RefSkill> SkillData { get; } = new(35000);
    public Dictionary<uint, RefSkillMastery> SkillMasteryData { get; } = new(32);
    public Dictionary<int, RefAbilityByItemOptLevel> AbilityItemByOptLevel { get; } = new(256);
    public List<RefSkillByItemOptLevel> SkillByItemOptLevels { get; } = new(256);
    public List<RefExtraAbilityByEquipItemOptLevel> ExtraAbilityByEquipItemOptLevel { get; } = new(4096);
    public Dictionary<string, RefShop> Shops { get; } = new(128);
    public Dictionary<string, RefShopTab> ShopTabs { get; } = new(256);
    public Dictionary<string, RefShopGroup> ShopGroups { get; } = new(128);
    public List<RefMappingShopGroup> ShopGroupMapping { get; } = new(128);
    public List<RefMappingShopWithTab> ShopTabMapping { get; } = new(128);
    public List<RefShopGood> ShopGoods { get; } = new(4096);
    public Dictionary<string, RefPackageItemScrap> PackageItemScrap { get; } = new(2048);
    public List<RefTeleport> TeleportData { get; } = new(256);
    public List<RefTeleportLink> TeleportLinks { get; } = new(256);
    public Dictionary<int, RefOptionalTeleport> OptionalTeleports { get; } = new(32);
    public Dictionary<uint, RefQuestReward> QuestRewards { get; } = new(1024);
    public List<RefQuestRewardItem> QuestRewardItems { get; } = new(1024);
    public List<RefEventRewardItems> EventRewardItems { get; } = new(32);
    public GatewayInfo GatewayInfo { get; private set; }
    public DivisionInfo DivisionInfo { get; private set; }
    public VersionInfo VersionInfo { get; private set; }
    public List<RefMagicOpt> MagicOptions { get; } = new(1024);
    public List<RefMagicOptAssign> MagicOptionAssignments { get; } = new(128);

    public void Load(int languageTab, BackgroundWorker worker)
    {
        LanguageTab = languageTab; //until language wizard is reworked?

        var sw = Stopwatch.StartNew();

        worker.ReportProgress(0, "Client info");
        LoadClientInfo();

        worker.ReportProgress(5, "Map info");
        LoadMapInfo();

        worker.ReportProgress(10, "Texts");
        LoadTextData();

        worker.ReportProgress(20, "Characters");
        LoadCharacterData();

        worker.ReportProgress(30, "Items");
        LoadItemData();

        worker.ReportProgress(40, "Skills");
        LoadSkillData();

        worker.ReportProgress(50, "Quests");
        LoadQuestData();

        worker.ReportProgress(60, "Shops");
        LoadShopData();

        worker.ReportProgress(70, "Teleporters");
        LoadTeleportData();

        worker.ReportProgress(80, "Alchemy");
        LoadAlchemyData();

        worker.ReportProgress(90, "Misc");
        LoadOptLevelData();
        LoadLevelData();
        LoadEventRewardData();

        sw.Stop();

        Log.Debug(GetDebugInfo());
        Log.Notify($"Loaded all game data in {sw.ElapsedMilliseconds}ms!");

        worker.ReportProgress(100, "Done");
        EventManager.FireEvent("OnLoadGameData");
    }

    private void LoadClientInfo()
    {
        DivisionInfo = DivisionInfo.Load();
        GatewayInfo = GatewayInfo.Load();
        VersionInfo = VersionInfo.Load();
    }

    private void LoadMapInfo()
    {
        RegionInfoManager.Load();
        NavMeshManager.Initialize(Game.DataPk2);
    }

    private void LoadLevelData()
    {
        LoadReferenceFile($"{ServerDep}\\LevelData.txt", LevelData);
    }

    private void LoadShopData()
    {
        LoadReferenceFile($"{ServerDep}\\RefShop.txt", Shops);
        LoadReferenceFile($"{ServerDep}\\RefShopTab.txt", ShopTabs);
        LoadReferenceFile($"{ServerDep}\\RefShopGroup.txt", ShopGroups);
        LoadReferenceFile($"{ServerDep}\\RefMappingShopGroup.txt", ShopGroupMapping);
        LoadReferenceFile($"{ServerDep}\\RefMappingShopWithTab.txt", ShopTabMapping);

        if (Game.ClientType >= GameClientType.Chinese)
            LoadReferenceListFile($"{ServerDep}\\RefScrapOfPackageItem.txt", PackageItemScrap);
        else
            LoadReferenceFile($"{ServerDep}\\RefScrapOfPackageItem.txt", PackageItemScrap);

        if (Game.ClientType >= GameClientType.Chinese)
            LoadReferenceListFile($"{ServerDep}\\RefShopGoods.txt", ShopGoods);
        else
            LoadReferenceFile($"{ServerDep}\\RefShopGoods.txt", ShopGoods);
    }

    private void LoadAlchemyData()
    {
        LoadReferenceFile($"{ServerDep}\\magicoption.txt", MagicOptions);
        if (MagicOptions.Count <= 1)
        {
            LoadReferenceFile($"{ServerDep}\\magicoption_all.txt", MagicOptions);
        }
        LoadReferenceFile($"{ServerDep}\\magicoptionassign.txt", MagicOptionAssignments);
    }

    private void LoadTeleportData()
    {
        LoadReferenceFile($"{ServerDep}\\TeleportBuilding.txt", CharacterData);
        LoadReferenceFile($"{ServerDep}\\TeleportData.txt", TeleportData);
        LoadReferenceFile($"{ServerDep}\\TeleportLink.txt", TeleportLinks);
        LoadReferenceFile($"{ServerDep}\\refoptionalteleport.txt", OptionalTeleports);
    }

    private void LoadItemData()
    {
        if (Game.ClientType < GameClientType.Thailand)
            LoadReferenceFile($"{ServerDep}\\ItemData.txt", ItemData);
        else
            LoadReferenceListFile($"{ServerDep}\\ItemData.txt", ItemData);
    }

    private void LoadOptLevelData()
    {
        if (Game.ClientType > GameClientType.Japanese_Old)
        {
            LoadReferenceFile($"{ServerDep}\\refabilitybyitemoptleveldata.txt", AbilityItemByOptLevel);
            LoadReferenceFile($"{ServerDep}\\refskillbyitemoptleveldata.txt", SkillByItemOptLevels);
        }

        if (Game.ClientType >= GameClientType.Chinese_Old)
            LoadReferenceFile($"{ServerDep}\\refextraabilitybyequipitemoptlevel.txt", ExtraAbilityByEquipItemOptLevel);
    }

    private void LoadQuestData()
    {
        LoadReferenceFile($"{ServerDep}\\refquestrewarditems.txt", QuestRewardItems);
        LoadReferenceFile($"{ServerDep}\\refqusetreward.txt", QuestRewards);

        if (Game.ClientType >= GameClientType.Chinese)
            LoadConditionalData($"{ServerDep}\\QuestData.txt", QuestData);
        else
            LoadReferenceFile($"{ServerDep}\\questdata.txt", QuestData);
    }

    private void LoadEventRewardData()
    {
        LoadReferenceFile($"{ServerDep}\\refeventrewarditems.txt", EventRewardItems);
    }

    private void LoadTextData()
    {
        if (Game.ClientType >= GameClientType.Chinese)
            LoadReferenceListFile($"{ServerDep}\\TextUISystem.txt", TextData);
        else
            LoadReferenceFile($"{ServerDep}\\TextUISystem.txt", TextData);

        if (Game.ClientType >= GameClientType.Chinese)
            LoadReferenceListFile($"{ServerDep}\\TextZoneName.txt", TextData);
        else
            LoadReferenceFile($"{ServerDep}\\TextZoneName.txt", TextData);
        if (Game.ClientType >= GameClientType.Chinese)
        {
            LoadReferenceListFile($"{ServerDep}\\TextQuest_OtherString.txt", TextData);
            LoadReferenceListFile($"{ServerDep}\\TextData_Object.txt", TextData);
            LoadReferenceListFile($"{ServerDep}\\TextData_Equip&Skill.txt", TextData);
            LoadReferenceListFile($"{ServerDep}\\TextQuest_Speech&Name.txt", TextData);
            LoadReferenceListFile($"{ServerDep}\\TextQuest_QuestString.txt", TextData);
        }
        else
        {
            if (Game.ClientType >= GameClientType.Thailand)
            {
                LoadReferenceListFile($"{ServerDep}\\TextDataName.txt", TextData);
                LoadReferenceListFile($"{ServerDep}\\TextQuest.txt", TextData);
                return;
            }

            LoadReferenceFile($"{ServerDep}\\TextDataName.txt", TextData);
            LoadReferenceFile($"{ServerDep}\\TextQuest.txt", TextData);
        }
    }

    private void LoadCharacterData()
    {
        if (Game.ClientType < GameClientType.Thailand)
            LoadReferenceFile($"{ServerDep}\\CharacterData.txt", CharacterData);
        else
            LoadReferenceListFile($"{ServerDep}\\CharacterData.txt", CharacterData);
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
        if (Game.ClientType == GameClientType.Vietnam || Game.ClientType == GameClientType.Vietnam274)
            LoadReferenceListFileEnc($"{ServerDep}\\SkillDataEnc.txt", SkillData);
        else if (Game.ClientType < GameClientType.Thailand)
            LoadReferenceFile($"{ServerDep}\\SkillData.txt", SkillData);
        else
            LoadReferenceListFile($"{ServerDep}\\SkillData.txt", SkillData);

        LoadReferenceFile($"{ServerDep}\\SkillMasteryData.txt", SkillMasteryData);
    }

    private void LoadReferenceListFileEnc<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            LoadReferenceListFileEnc(file.OpenRead().GetStream(), destination);
    }

    private void LoadReferenceListFileEnc<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        var filesToLoad = new List<string>();
        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLineByCRLF();

                //Skip invalid
                if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                    continue;

                filesToLoad.Add(line);
            }
        }

        var files = Game.MediaPk2.GetFileList(ServerDep, filesToLoad.ToArray());
        foreach (var file in files)
            LoadReferenceFileEnc(file.OpenRead().GetStream(), destination);
    }

    private void LoadReferenceFileEnc<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        using var decryptedStream = new MemoryStream();

        SkillCryptoHelper.DecryptStream(stream, decryptedStream, 0x8C1F);
        decryptedStream.Seek(0, SeekOrigin.Begin);

        LoadReferenceFile(decryptedStream, destination);
    }

    private void LoadReferenceListFile<TReference>(string fileName, IList<TReference> destination)
        where TReference : IReference, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            LoadReferenceListFile(file.OpenRead().GetStream(), destination);
    }

    private void LoadReferenceListFile<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            LoadReferenceListFile(file.OpenRead().GetStream(), destination);
    }

    private void LoadReferenceFile<TReference>(string fileName, IList<TReference> destination)
        where TReference : IReference, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            LoadReferenceFile(file.OpenRead().GetStream(), destination);
    }

    private void LoadReferenceFile<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            LoadReferenceFile(file.OpenRead().GetStream(), destination);
    }

    private void LoadReferenceListFile<TReference>(Stream stream, IList<TReference> destination)
        where TReference : IReference, new()
    {
        var filesToLoad = new List<string>(16);

        using var reader = new StreamReader(stream);
        var builder = new StringBuilder(1024);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLineByCRLF(builder);

            //Skip invalid
            if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                continue;

            filesToLoad.Add(line);
        }

        var files = Game.MediaPk2.GetFileList(ServerDep, filesToLoad.ToArray());
        foreach (var file in files)
            LoadReferenceFile(file.OpenRead().GetStream(), destination);
    }

    private void LoadReferenceListFile<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        var filesToLoad = new List<string>(16);

        using var reader = new StreamReader(stream);
        var builder = new StringBuilder(1024);

        //Read list of files to load
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLineByCRLF(builder);

            //Skip invalid
            if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                continue;

            filesToLoad.Add(line);
        }

        //Actual loading
        var files = Game.MediaPk2.GetFileList(ServerDep, filesToLoad.ToArray());
        foreach (var file in files)
            LoadReferenceFile(file.OpenRead().GetStream(), destination);
    }

    private void LoadReferenceFile<TReference>(Stream stream, IList<TReference> destination)
        where TReference : IReference, new()
    {
        using var reader = new StreamReader(stream);
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

    private void LoadReferenceFile<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        using var reader = new StreamReader(stream);
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

    public IEnumerable<uint> GetBaseSkills()
    {
        return SkillData
            .Where(p => p.Value.Basic_Code.EndsWith("_BASE_01") && p.Value.Basic_Group != "xxx")
            .Select(p => p.Key);
    }

    public RefShopTab GetTab(string codeName)
    {
        return ShopTabs[codeName];
    }

    public string GetTranslation(string name)
    {
        if (TextData.TryGetValue(name, out var refText))
            return refText.Data;

        return name;
    }

    public RefObjCommon GetRefObjCommon(uint refObjID)
    {
        if (CharacterData.TryGetValue(refObjID, out var refChar))
            return refChar;

        if (ItemData.TryGetValue(refObjID, out var refItem))
            return refItem;

        return null;
    }

    public RefObjChar GetRefObjChar(uint id)
    {
        if (CharacterData.TryGetValue(id, out var data))
            return data;

        return null;
    }

    public RefObjChar GetRefObjChar(string codeName)
    {
        return CharacterData.FirstOrDefault(obj => obj.Value.CodeName == codeName).Value;
    }

    public RefObjItem GetRefItem(uint id)
    {
        if (ItemData.TryGetValue(id, out var data))
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
        if (SkillData.TryGetValue(id, out var data))
            return data;

        return null;
    }

    public RefSkill GetRefSkill(string codeName)
    {
        var skill = SkillData.FirstOrDefault(s => s.Value.Basic_Code == codeName);

        return skill.Value;
    }

    public RefSkillMastery GetRefSkillMastery(uint id)
    {
        if (
            (Game.ClientType == GameClientType.Chinese_Old || Game.ClientType == GameClientType.Chinese)
            && id >= 273
            && id <= 275
        )
            id = 277; // csro shit

        if (SkillMasteryData.TryGetValue(id, out var data))
            return data;

        return null;
    }

    public RefQuest GetRefQuest(uint id)
    {
        if (QuestData.TryGetValue(id, out var data))
            return data;

        return null;
    }

    public RefLevel GetRefLevel(byte level)
    {
        if (LevelData.TryGetValue(level, out var data))
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
        return PackageItemScrap[
            GetRefShopGroupById(id)
                .GetShops()[group]
                .GetTabs()[tab]
                .GetGoods()
                .FirstOrDefault(s => s.SlotIndex == slot)
                .RefPackageItemCodeName
        ];
    }

    public RefPackageItemScrap GetRefPackageItem(string codeName)
    {
        if (PackageItemScrap.TryGetValue(codeName, out var data))
            return data;

        return null;
    }

    public List<RefPackageItemScrap> GetRefPackageItems(RefShopGroup group)
    {
        var result = new List<RefPackageItemScrap>();
        foreach (var shop in group.GetShops())
        {
            if (shop == null)
                continue;
            foreach (var tab in shop.GetTabs())
            {
                if (tab == null)
                    continue;
                foreach (var good in tab.GetGoods())
                {
                    if (good == null)
                        continue;

                    if (!PackageItemScrap.ContainsKey(good.RefPackageItemCodeName))
                        continue;

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
        return (
            from shop in @group.GetShops()
            where shop != null
            from tab in shop.GetTabs()
            where tab != null
            from good in tab.GetGoods()
            where good != null
            select good
        ).ToList();
    }

    public byte GetRefShopGoodTabIndex(string npcCodeName, RefShopGood good)
    {
        var shopGroup = GetRefShopGroup(npcCodeName);
        if (shopGroup == null)
            return 0xFF;

        var availableShops = shopGroup.GetShops();

        foreach (var shop in availableShops)
        {
            var availableTabs = shop.GetTabs();

            for (byte i = 0; i < availableTabs.Count; i++)
            {
                var goods = availableTabs[i].GetGoods();
                var availableGood = goods.FirstOrDefault(g => g.RefPackageItemCodeName == good.RefPackageItemCodeName);

                if (availableGood != null)
                    return i;
            }
        }

        return 0xFF;
    }

    /// <summary>
    ///     Gets the filtered items.
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
        string searchPattern = null
    )
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
    ///     Gets the teleporters in the specific sector
    /// </summary>
    /// <param name="regionId"></param>
    /// <returns></returns>
    public RefTeleport[] GetTeleporters(Region region)
    {
        return TeleportData.Where(t => t.GenRegionID == region).ToArray();
    }

    /// <summary>
    ///     Gets the ground teleporters.
    /// </summary>
    /// <param name="regionId">The region identifier.</param>
    /// <returns></returns>
    public RefTeleport[] GetGroundTeleporters(Region region)
    {
        return TeleportData.Where(t => t.GenRegionID == region && t.AssocRefObjId == 0).ToArray();
    }

    /// <summary>
    ///     Gets a magic option by its id
    /// </summary>
    /// <param name="id">The id of the magic option</param>
    /// <returns></returns>
    public RefMagicOpt GetMagicOption(uint id)
    {
        return MagicOptions?.FirstOrDefault(m => m.Id == id);
    }

    /// <summary>
    ///     Gets the first magic option of the specified group
    /// </summary>
    /// <param name="group">The group</param>
    /// <returns></returns>
    public RefMagicOpt GetMagicOption(string group)
    {
        return MagicOptions?.FirstOrDefault(m => m.Group == group);
    }

    /// <summary>
    ///     Gets a magic option by its group and degree
    /// </summary>
    /// <param name="group">The group</param>
    /// <param name="degree">The degree</param>
    /// <returns></returns>
    public RefMagicOpt GetMagicOption(string group, byte degree)
    {
        return MagicOptions?.FirstOrDefault(m => m.Group == group && m.Level == degree);
    }

    /// <summary>
    ///     Gets a list of magic options for the specified type ids
    /// </summary>
    /// <param name="typeId3">The TID3</param>
    /// <param name="typeId4">The TID4</param>
    /// <returns></returns>
    public List<RefMagicOpt> GetAssignments(byte typeId3, byte typeId4)
    {
        return MagicOptionAssignments
            .FirstOrDefault(a => a.TypeId3 == typeId3 && a.TypeId4 == typeId4)
            ?.AvailableMagicOptions.Select(GetMagicOption)
            .ToList();
    }

    /// <summary>
    ///     Gets a ability item for the specified <paramref name="itemId" /> and <paramref name="optLevel" />
    /// </summary>
    /// <param name="itemId">Item Id</param>
    /// <param name="optLevel">Opt Level</param>
    /// <returns></returns>
    public RefAbilityByItemOptLevel GetAbilityItem(uint itemId, byte optLevel)
    {
        return AbilityItemByOptLevel.Values.FirstOrDefault(p => p.ItemId == itemId && p.OptLevel == optLevel);
    }

    /// <summary>
    ///     Gets a ability item for the specified <paramref name="itemId" /> and <paramref name="optLevel" />
    /// </summary>
    /// <param name="itemId">Item Id</param>
    /// <param name="optLevel">Opt Level</param>
    /// <returns></returns>
    public IEnumerable<RefExtraAbilityByEquipItemOptLevel> GetExtraAbilityItems(uint itemId, byte optLevel)
    {
        return ExtraAbilityByEquipItemOptLevel.Where(p => p.ItemId == itemId && p.OptLevel == optLevel);
    }

    /// <summary>
    ///     Gets a list of reward items for the specified quest.
    /// </summary>
    /// <param name="questId"></param>
    /// <returns></returns>
    public IEnumerable<RefQuestRewardItem> GetQuestRewardItems(uint questId)
    {
        return QuestRewardItems.Where(r => r.QuestId == questId);
    }

    /// <summary>
    ///     Returns the reward for the specified quest
    /// </summary>
    /// <param name="questId"></param>
    /// <returns></returns>
    public RefQuestReward GetQuestReward(uint questId)
    {
        QuestRewards.TryGetValue(questId, out var result);

        return result;
    }

    public List<RefEventRewardItems> GetEventRewardItems(uint eventId)
    {
        return EventRewardItems.Where(r => r.EventId == eventId).ToList();
    }

    private string GetDebugInfo()
    {
        var builder = new StringBuilder("\n=== Reference information === \n");

        builder.AppendFormat("TextData: {0}\n", TextData.Count);
        builder.AppendFormat("CharacterData: {0}\n", CharacterData.Count);
        builder.AppendFormat("ItemData: {0}\n", ItemData.Count);
        builder.AppendFormat("SkillData: {0}\n", SkillData.Count);
        builder.AppendFormat("SkillMasteryData: {0}\n", SkillMasteryData.Count);
        builder.AppendFormat("QuestData: {0}\n", QuestData.Count);
        builder.AppendFormat("QuestRewards: {0}\n", QuestRewards.Count);
        builder.AppendFormat("QuestRewardItems: {0}\n", QuestRewardItems.Count);
        builder.AppendFormat("EventRewardItems: {0}\n", EventRewardItems.Count);
        builder.AppendFormat("TeleportData: {0}\n", TeleportData.Count);
        builder.AppendFormat("TeleportLinks: {0}\n", TeleportLinks.Count);
        builder.AppendFormat("OptionalTeleports: {0}\n", OptionalTeleports.Count);
        builder.AppendFormat("MagicOptions: {0}\n", MagicOptions.Count);
        builder.AppendFormat("MagicOptionAssignments: {0}\n", MagicOptionAssignments.Count);
        builder.AppendFormat("Shops: {0}\n", Shops.Count);
        builder.AppendFormat("ShopGroups: {0}\n", ShopGroups.Count);
        builder.AppendFormat("ShopGoods: {0}\n", ShopGoods.Count);
        builder.AppendFormat("ShopGroupMapping: {0}\n", ShopGroupMapping.Count);
        builder.AppendFormat("ShopTabs: {0}\n", ShopTabs.Count);
        builder.AppendFormat("ShopTabMapping: {0}\n", ShopTabMapping.Count);
        builder.AppendFormat("PackageItemScrap: {0}\n", PackageItemScrap.Count);
        builder.AppendFormat("AbilityItemByOptLevel: {0}\n", AbilityItemByOptLevel.Count);
        builder.AppendFormat("SkillByItemOptLevels: {0}\n", SkillByItemOptLevels.Count);
        builder.AppendFormat("ExtraAbilityByEquipItemOptLevel: {0}\n", ExtraAbilityByEquipItemOptLevel.Count);

        return builder.ToString();
    }
}
