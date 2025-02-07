using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers;
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
    private const int BufferSize = 4096;

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
    public GatewayInfo GatewayInfo { get; private set; }
    public DivisionInfo DivisionInfo { get; private set; }
    public VersionInfo VersionInfo { get; private set; }
    public List<RefMagicOpt> MagicOptions { get; } = new(1024);
    public List<RefMagicOptAssign> MagicOptionAssignments { get; } = new(128);

    
    /// <summary>
    /// Loads all game reference data asynchronously
    /// </summary>
    /// <param name="languageTab">The language tab index to use for loading text data</param>
    /// <param name="reportProgress">Action to report loading progress</param>
    public async Task LoadAsync(int languageTab, Action<int, string> reportProgress)
    {
        LanguageTab = languageTab;

        var sw = Stopwatch.StartNew();

        try
        {
            reportProgress(0, "Client info");
            await LoadClientInfoAsync();

            reportProgress(5, "Map info");
            await LoadMapInfoAsync();

            // Load text data first as it's needed by other loaders
            reportProgress(10, "Texts");
            await LoadTextDataAsync();

            // Load character and item data in parallel
            reportProgress(20, "Characters and Items");
            await Task.WhenAll(
                LoadCharacterDataAsync(),
                LoadItemDataAsync()
            );

            // Load skills and quests in parallel
            reportProgress(40, "Skills and Quests");
            await Task.WhenAll(
                LoadSkillDataAsync(),
                LoadQuestDataAsync()
            );

            // Load shops and teleporters in parallel
            reportProgress(60, "Shops and Teleporters");
            await Task.WhenAll(
                LoadShopDataAsync(),
                LoadTeleportDataAsync()
            );

            // Load alchemy and misc data in parallel
            reportProgress(80, "Alchemy and Misc");
            await Task.WhenAll(
                LoadAlchemyDataAsync(),
                LoadOptLevelDataAsync(),
                LoadLevelDataAsync()
            );

            sw.Stop();

            Log.Debug(GetDebugInfo());
            Log.Notify($"Loaded all game data in {sw.ElapsedMilliseconds}ms!");
            EventManager.FireEvent("OnLoadGameData");

            reportProgress(100, "Complete");
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to load game data: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Loads client information files asynchronously (Gateway, Division, Version)
    /// </summary>
    private async Task LoadClientInfoAsync()
    {
        await Task.WhenAll(
            Task.Run(() => DivisionInfo = DivisionInfo.Load()),
            Task.Run(() => GatewayInfo = GatewayInfo.Load()),
            Task.Run(() => VersionInfo = VersionInfo.Load())
        );
    }

    /// <summary>
    /// Loads map information data asynchronously
    /// </summary>
    private async Task LoadMapInfoAsync()
    {
        await Task.Run(() => {
            RegionInfoManager.Load();
            NavMeshManager.Initialize(Game.DataPk2);
        }).ConfigureAwait(false);
    }

    /// <summary>
    /// Loads level data asynchronously
    /// </summary>
    private async Task LoadLevelDataAsync()
    {
        await LoadReferenceFileAsync($"{ServerDep}\\LevelData.txt", LevelData);
    }

    /// <summary>
    /// Loads shop related data asynchronously (shops, tabs, groups, goods)
    /// </summary>
    private async Task LoadShopDataAsync()
    {
        await LoadReferenceFileAsync($"{ServerDep}\\RefShop.txt", Shops);
        await LoadReferenceFileAsync($"{ServerDep}\\RefShopTab.txt", ShopTabs);
        await LoadReferenceFileAsync($"{ServerDep}\\RefShopGroup.txt", ShopGroups);
        await LoadReferenceFileAsync($"{ServerDep}\\RefMappingShopGroup.txt", ShopGroupMapping);
        await LoadReferenceFileAsync($"{ServerDep}\\RefMappingShopWithTab.txt", ShopTabMapping);

        if (Game.ClientType > GameClientType.Chinese)
            await LoadReferenceListFileAsync($"{ServerDep}\\RefScrapOfPackageItem.txt", PackageItemScrap);
        else
            await LoadReferenceFileAsync($"{ServerDep}\\RefScrapOfPackageItem.txt", PackageItemScrap);

        if (Game.ClientType > GameClientType.Chinese)
            await LoadReferenceListFileAsync($"{ServerDep}\\RefShopGoods.txt", ShopGoods);
        else
            await LoadReferenceFileAsync($"{ServerDep}\\RefShopGoods.txt", ShopGoods);
    }

    /// <summary>
    /// Loads alchemy related data asynchronously
    /// </summary>
    private async Task LoadAlchemyDataAsync()
    {
        await LoadReferenceFileAsync($"{ServerDep}\\magicoption.txt", MagicOptions);
        await LoadReferenceFileAsync($"{ServerDep}\\magicoptionassign.txt", MagicOptionAssignments);
    }

    /// <summary>
    /// Loads teleport related data asynchronously (teleporters, links)
    /// </summary>
    private async Task LoadTeleportDataAsync()
    {
        await LoadReferenceFileAsync($"{ServerDep}\\TeleportBuilding.txt", CharacterData);
        await LoadReferenceFileAsync($"{ServerDep}\\TeleportData.txt", TeleportData);
        await LoadReferenceFileAsync($"{ServerDep}\\TeleportLink.txt", TeleportLinks);
        await LoadReferenceFileAsync($"{ServerDep}\\refoptionalteleport.txt", OptionalTeleports);
    }

    /// <summary>
    /// Loads item data asynchronously
    /// </summary>
    private async Task LoadItemDataAsync()
    {
        if (Game.ClientType < GameClientType.Thailand)
            await LoadReferenceFileAsync($"{ServerDep}\\ItemData.txt", ItemData);
        else
            await LoadReferenceListFileAsync($"{ServerDep}\\ItemData.txt", ItemData);
    }

    /// <summary>
    /// Loads optimization level data asynchronously
    /// </summary>
    private async Task LoadOptLevelDataAsync()
    {
        if (Game.ClientType > GameClientType.Japanese_Old)
        {
            await LoadReferenceFileAsync($"{ServerDep}\\refabilitybyitemoptleveldata.txt", AbilityItemByOptLevel);
            await LoadReferenceFileAsync($"{ServerDep}\\refskillbyitemoptleveldata.txt", SkillByItemOptLevels);
        }

        if (Game.ClientType >= GameClientType.Chinese)
            await LoadReferenceFileAsync($"{ServerDep}\\refextraabilitybyequipitemoptlevel.txt", ExtraAbilityByEquipItemOptLevel);
    }

    /// <summary>
    /// Loads quest data asynchronously
    /// </summary>
    private async Task LoadQuestDataAsync()
    {
        await LoadReferenceFileAsync($"{ServerDep}\\refquestrewarditems.txt", QuestRewardItems);
        await LoadReferenceFileAsync($"{ServerDep}\\refqusetreward.txt", QuestRewards);

        if (Game.ClientType > GameClientType.Chinese)
            await LoadConditionalDataAsync($"{ServerDep}\\QuestData.txt", QuestData);
        else
            await LoadReferenceFileAsync($"{ServerDep}\\questdata.txt", QuestData);
    }

    /// <summary>
    /// Loads text data asynchronously based on the selected language
    /// </summary>
    private async Task LoadTextDataAsync()
    {
        if (Game.ClientType >= GameClientType.Global)
            await LoadReferenceListFileAsync($"{ServerDep}\\TextUISystem.txt", TextData);
        else
            await LoadReferenceFileAsync($"{ServerDep}\\TextUISystem.txt", TextData);

        if (Game.ClientType >= GameClientType.Global)
            await LoadReferenceListFileAsync($"{ServerDep}\\TextZoneName.txt", TextData);
        else
            await LoadReferenceFileAsync($"{ServerDep}\\TextZoneName.txt", TextData);

        if (Game.ClientType >= GameClientType.Global)
        {
            await LoadReferenceListFileAsync($"{ServerDep}\\TextQuest_OtherString.txt", TextData);
            await LoadReferenceListFileAsync($"{ServerDep}\\TextData_Object.txt", TextData);
            await LoadReferenceListFileAsync($"{ServerDep}\\TextData_Equip&Skill.txt", TextData);
            await LoadReferenceListFileAsync($"{ServerDep}\\TextQuest_Speech&Name.txt", TextData);
            await LoadReferenceListFileAsync($"{ServerDep}\\TextQuest_QuestString.txt", TextData);
        }
        else
        {
            if (Game.ClientType >= GameClientType.Thailand)
            {
                await LoadReferenceListFileAsync($"{ServerDep}\\TextDataName.txt", TextData);
                await LoadReferenceListFileAsync($"{ServerDep}\\TextQuest.txt", TextData);
                return;
            }

            await LoadReferenceFileAsync($"{ServerDep}\\TextDataName.txt", TextData);
            await LoadReferenceFileAsync($"{ServerDep}\\TextQuest.txt", TextData);
        }
    }

    /// <summary>
    /// Loads character data asynchronously
    /// </summary>
    private async Task LoadCharacterDataAsync()
    {
        if (Game.ClientType < GameClientType.Thailand)
            await LoadReferenceFileAsync($"{ServerDep}\\CharacterData.txt", CharacterData);
        else
            await LoadReferenceListFileAsync($"{ServerDep}\\CharacterData.txt", CharacterData);
    }

    /// <summary>
    /// Loads conditional data asynchronously for a specific reference type
    /// </summary>
    /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="file">The file to load from</param>
    /// <param name="collection">The collection to load the data into</param>
    private async Task LoadConditionalDataAsync<TKey, TReference>(string file, IDictionary<TKey, TReference> collection)
        where TReference : IReference<TKey>, new()
    {
        if (Game.ClientType < GameClientType.Thailand)
            await LoadReferenceFileAsync(file, collection);
        else
            await LoadReferenceListFileAsync(file, collection);
    }

    /// <summary>
    /// Loads skill data asynchronously
    /// </summary>
    private async Task LoadSkillDataAsync()
    {
        if (Game.ClientType == GameClientType.Vietnam ||
            Game.ClientType == GameClientType.Vietnam274)
            await LoadReferenceListFileEncAsync($"{ServerDep}\\SkillDataEnc.txt", SkillData);
        else if (Game.ClientType < GameClientType.Thailand)
            await LoadReferenceFileAsync($"{ServerDep}\\SkillData.txt", SkillData);
        else
            await LoadReferenceListFileAsync($"{ServerDep}\\SkillData.txt", SkillData);

        await LoadReferenceFileAsync($"{ServerDep}\\SkillMasteryData.txt", SkillMasteryData);
    }

    /// <summary>
    /// Loads encrypted reference list from a file asynchronously
    /// </summary>
    /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="fileName">The file name to load from</param>
    /// <param name="destination">The dictionary to load the data into</param>
    private async Task LoadReferenceListFileEncAsync<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            await LoadReferenceListFileEncAsync(file.OpenRead().GetStream(), destination);
    }

    /// <summary>
    /// Loads encrypted reference list from a stream asynchronously
    /// </summary>
    /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="stream">The stream to read from</param>
    /// <param name="destination">The dictionary to load the data into</param>
    private async Task LoadReferenceListFileEncAsync<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        var filesToLoad = new List<string>();
        using (var reader = new StreamReader(stream))
        {
            var builder = new StringBuilder(1024);
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineByCRLFAsync(builder);

                //Skip invalid
                if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                    continue;

                filesToLoad.Add(line);
            }
        }

        var files = Game.MediaPk2.GetFileList(ServerDep, filesToLoad.ToArray());
        foreach (var file in files)
            await LoadReferenceFileAsync(file.OpenRead().GetStream(), destination);
    }

    /// <summary>
    /// Loads reference list from a stream asynchronously
    /// </summary>
    /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="stream">The stream to read from</param>
    /// <param name="destination">The dictionary to load the data into</param>
    private async Task LoadReferenceListFileAsync<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        var filesToLoad = new List<string>(16);

        using var reader = new StreamReader(stream);
        var builder = new StringBuilder(1024);

        //Read list of files to load
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineByCRLFAsync(builder);

            //Skip invalid
            if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                continue;
                        
            filesToLoad.Add(line);
        }

        var files = Game.MediaPk2.GetFileList(ServerDep, filesToLoad.ToArray());
        foreach (var file in files)
            await LoadReferenceFileAsync(file.OpenRead().GetStream(), destination);
    }

    /// <summary>
    /// Loads reference list from a stream asynchronously
    /// </summary>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="stream">The stream to read from</param>
    /// <param name="destination">The list to load the data into</param>
    private async Task LoadReferenceListFileAsync<TReference>(Stream stream, IList<TReference> destination)
        where TReference : IReference, new()
    {
        var filesToLoad = new List<string>(16);

        using var reader = new StreamReader(stream);
        var builder = new StringBuilder(1024);

        //Read list of files to load
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineByCRLFAsync(builder);

            //Skip invalid
            if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                continue;

            filesToLoad.Add(line);
        }

        var files = Game.MediaPk2.GetFileList(ServerDep, filesToLoad.ToArray());
        foreach (var file in files)
            await LoadReferenceFileAsync(file.OpenRead().GetStream(), destination);
    }
    
    /// <summary>
    /// Loads reference data from a stream asynchronously
    /// </summary>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="stream">The stream to read from</param>
    /// <param name="destination">The list to load the data into</param>
    private async Task LoadReferenceFileAsync<TReference>(Stream stream, IList<TReference> destination)
        where TReference : IReference, new()
    {
        using var reader = new StreamReader(stream);
        var builder = new StringBuilder(1024);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineByCRLFAsync(builder);

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

    /// <summary>
    /// Loads reference data from a stream asynchronously
    /// </summary>
    /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="stream">The stream to read from</param>
    /// <param name="destination">The dictionary to load the data into</param>
    private async Task LoadReferenceFileAsync<TKey, TReference>(Stream stream, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        using var reader = new StreamReader(stream);
        var builder = new StringBuilder(1024);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineByCRLFAsync(builder);

            //Skip invalid
            if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                continue;

            var reference = new TReference();
            reference.Load(new ReferenceParser(line));

            if (reference.PrimaryKey != null && !destination.ContainsKey(reference.PrimaryKey))
                destination.Add(reference.PrimaryKey, reference);
        }
    }

    /// <summary>
    /// Loads reference list from a file asynchronously
    /// </summary>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="fileName">The file name to load from</param>
    /// <param name="destination">The list to load the data into</param>
    private async Task LoadReferenceListFileAsync<TReference>(string fileName, IList<TReference> destination)
        where TReference : IReference, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            await LoadReferenceListFileAsync(file.OpenRead().GetStream(), destination);
    }

    /// <summary>
    /// Loads reference list from a file asynchronously
    /// </summary>
    /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="fileName">The file name to load from</param>
    /// <param name="destination">The dictionary to load the data into</param>
    private async Task LoadReferenceListFileAsync<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            await LoadReferenceListFileAsync(file.OpenRead().GetStream(), destination);
    }

    /// <summary>
    /// Loads reference data from a file asynchronously
    /// </summary>
    /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="fileName">The file name to load from</param>
    /// <param name="destination">The dictionary to load the data into</param>
    private async Task LoadReferenceFileAsync<TKey, TReference>(string fileName, IDictionary<TKey, TReference> destination)
        where TReference : IReference<TKey>, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            await LoadReferenceFileAsync(file.OpenRead().GetStream(), destination);
    }

    /// <summary>
    /// Loads reference data from a file asynchronously
    /// </summary>
    /// <typeparam name="TReference">The type of the reference object</typeparam>
    /// <param name="fileName">The file name to load from</param>
    /// <param name="destination">The list to load the data into</param>
    private async Task LoadReferenceFileAsync<TReference>(string fileName, IList<TReference> destination)
        where TReference : IReference, new()
    {
        if (Game.MediaPk2.TryGetFile(fileName, out var file))
            await LoadReferenceFileAsync(file.OpenRead().GetStream(), destination);
    }

    /// <summary>
    /// Gets a list of base skill IDs available in the game
    /// </summary>
    /// <returns>An enumerable of base skill IDs</returns>
    public IEnumerable<uint> GetBaseSkills()
    {
        return SkillData.Where(p => p.Value.Basic_Code.EndsWith("_BASE_01") && p.Value.Basic_Group != "xxx")
            .Select(p => p.Key);
    }

    /// <summary>
    /// Gets a shop tab by its code name
    /// </summary>
    /// <param name="codeName">The code name of the shop tab</param>
    /// <returns>The shop tab reference object</returns>
    public RefShopTab GetTab(string codeName)
    {
        return ShopTabs[codeName];
    }

    /// <summary>
    /// Gets the translated text for a given name based on the current language tab
    /// </summary>
    /// <param name="name">The name to translate</param>
    /// <returns>The translated text</returns>
    public string GetTranslation(string name)
    {
        if (TextData.TryGetValue(name, out var refText))
            return refText.Data;

        return name;
    }

    /// <summary>
    /// Gets a common object reference by its ID
    /// </summary>
    /// <param name="refObjID">The reference object ID</param>
    /// <returns>The common object reference</returns>
    public RefObjCommon GetRefObjCommon(uint refObjID)
    {
        if (refObjID == 0)
            return null;

        if (CharacterData.TryGetValue(refObjID, out var character))
            return character;

        if (ItemData.TryGetValue(refObjID, out var item))
            return item;

        return null;
    }

    /// <summary>
    /// Gets a character reference by its ID
    /// </summary>
    /// <param name="id">The character ID</param>
    /// <returns>The character reference object</returns>
    public RefObjChar GetRefObjChar(uint id)
    {
        if (id == 0)
            return null;

        return CharacterData.GetValueOrDefault(id);
    }

    /// <summary>
    /// Gets a character reference by its code name
    /// </summary>
    /// <param name="codeName">The character code name</param>
    /// <returns>The character reference object</returns>
    public RefObjChar GetRefObjChar(string codeName)
    {
        return CharacterData.Values.FirstOrDefault(p => p.CodeName == codeName);
    }

    /// <summary>
    /// Gets an item reference by its ID
    /// </summary>
    /// <param name="id">The item ID</param>
    /// <returns>The item reference object</returns>
    public RefObjItem GetRefItem(uint id)
    {
        if (id == 0)
            return null;

        return ItemData.GetValueOrDefault(id);
    }

    /// <summary>
    /// Gets an item reference by its code name
    /// </summary>
    /// <param name="codeName">The item code name</param>
    /// <returns>The item reference object</returns>
    public RefObjItem GetRefItem(string codeName)
    {
        return ItemData.FirstOrDefault(obj => obj.Value.CodeName == codeName).Value;
    }

    /// <summary>
    /// Gets an item reference by its type ID filter
    /// </summary>
    /// <param name="filter">The type ID filter</param>
    /// <returns>The item reference object</returns>
    public RefObjItem GetRefItem(TypeIdFilter filter)
    {
        return ItemData.FirstOrDefault(obj => filter.EqualsRefItem(obj.Value)).Value;
    }

    /// <summary>
    /// Gets a skill reference by its ID
    /// </summary>
    /// <param name="id">The skill ID</param>
    /// <returns>The skill reference object</returns>
    public RefSkill GetRefSkill(uint id)
    {
        if (SkillData.TryGetValue(id, out var data))
            return data;

        return null;
    }

    /// <summary>
    /// Gets a skill reference by its code name
    /// </summary>
    /// <param name="codeName">The skill code name</param>
    /// <returns>The skill reference object</returns>
    public RefSkill GetRefSkill(string codeName)
    {
        var skill = SkillData.FirstOrDefault(s => s.Value.Basic_Code == codeName);

        return skill.Value;
    }

    /// <summary>
    /// Gets a skill mastery reference by its ID
    /// </summary>
    /// <param name="id">The skill mastery ID</param>
    /// <returns>The skill mastery reference object</returns>
    public RefSkillMastery GetRefSkillMastery(uint id)
    {
        if (Game.ClientType == GameClientType.Chinese &&
            id >= 273 && id <= 275)
            id = 277; // csro shit

        if (SkillMasteryData.TryGetValue(id, out var data))
            return data;

        return null;
    }

    /// <summary>
    /// Gets a quest reference by its ID
    /// </summary>
    /// <param name="id">The quest ID</param>
    /// <returns>The quest reference object</returns>
    public RefQuest GetRefQuest(uint id)
    {
        if (QuestData.TryGetValue(id, out var data))
            return data;

        return null;
    }

    /// <summary>
    /// Gets a level reference by its level value
    /// </summary>
    /// <param name="level">The level value</param>
    /// <returns>The level reference object</returns>
    public RefLevel GetRefLevel(byte level)
    {
        if (LevelData.TryGetValue(level, out var data))
            return data;

        return null;
    }

    /// <summary>
    /// Gets a shop group reference by its NPC code name
    /// </summary>
    /// <param name="npcCodeName">The NPC code name</param>
    /// <returns>The shop group reference object</returns>
    public RefShopGroup GetRefShopGroup(string npcCodeName)
    {
        return ShopGroups.FirstOrDefault(sg => sg.Value.RefNpcCodeName == npcCodeName).Value;
    }

    /// <summary>
    /// Gets a shop group reference by its ID
    /// </summary>
    /// <param name="id">The shop group ID</param>
    /// <returns>The shop group reference object</returns>
    public RefShopGroup GetRefShopGroupById(ushort id)
    {
        return ShopGroups.FirstOrDefault(sg => sg.Value.Id == id).Value;
    }

    /// <summary>
    /// Gets a package item reference by NPC code name, tab and slot
    /// </summary>
    /// <param name="npcCodeName">The NPC code name</param>
    /// <param name="tab">The tab index</param>
    /// <param name="slot">The slot index</param>
    /// <returns>The package item reference object</returns>
    public RefPackageItemScrap GetRefPackageItem(string npcCodeName, byte tab, byte slot)
    {
        var shops = GetRefShopGroup(npcCodeName).GetShops();
        var tabs = shops[0].GetTabs();
        var goods = tabs[tab].GetGoods();
        return PackageItemScrap[goods.FirstOrDefault(s => s.SlotIndex == slot)?.RefPackageItemCodeName];
    }

    /// <summary>
    /// Gets a package item reference by its ID, group, tab and slot
    /// </summary>
    /// <param name="id">The package item ID</param>
    /// <param name="group">The group index</param>
    /// <param name="tab">The tab index</param>
    /// <param name="slot">The slot index</param>
    /// <returns>The package item reference object</returns>
    public RefPackageItemScrap GetRefPackageItemById(ushort id, byte group, byte tab, byte slot)
    {
        return PackageItemScrap[
            GetRefShopGroupById(id).GetShops()[group].GetTabs()[tab].GetGoods().FirstOrDefault(s => s.SlotIndex == slot)
                .RefPackageItemCodeName];
    }

    /// <summary>
    /// Gets a package item reference by its code name
    /// </summary>
    /// <param name="codeName">The package item code name</param>
    /// <returns>The package item reference object</returns>
    public RefPackageItemScrap GetRefPackageItem(string codeName)
    {
        if (PackageItemScrap.TryGetValue(codeName, out var data))
            return data;

        return null;
    }

    /// <summary>
    /// Gets a list of package items for a given shop group
    /// </summary>
    /// <param name="group">The shop group</param>
    /// <returns>A list of package item references</returns>
    public List<RefPackageItemScrap> GetRefPackageItems(RefShopGroup group)
    {
        if (group == null)
            return new List<RefPackageItemScrap>();

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

    /// <summary>
    /// Gets a shop good reference by its package item code name
    /// </summary>
    /// <param name="refPackageItemCodeName">The package item code name</param>
    /// <returns>The shop good reference object</returns>
    public RefShopGood GetRefShopGood(string refPackageItemCodeName)
    {
        return ShopGoods.FirstOrDefault(sg => sg.RefPackageItemCodeName == refPackageItemCodeName);
    }

    /// <summary>
    /// Gets a list of shop goods for a given shop group
    /// </summary>
    /// <param name="group">The shop group</param>
    /// <returns>A list of shop good references</returns>
    public List<RefShopGood> GetRefShopGoods(RefShopGroup group)
    {
        return (from shop in @group.GetShops()
            where shop != null
            from tab in shop.GetTabs()
            where tab != null
            from good in tab.GetGoods()
            where good != null
            select good).ToList();
    }

    /// <summary>
    /// Gets the tab index for a shop good in a specific NPC's shop
    /// </summary>
    /// <param name="npcCodeName">The NPC code name</param>
    /// <param name="good">The shop good</param>
    /// <returns>The tab index</returns>
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
    /// Gets a filtered list of items based on various criteria
    /// </summary>
    /// <param name="filters">The type ID filters</param>
    /// <param name="degreeFrom">The minimum degree</param>
    /// <param name="degreeTo">The maximum degree</param>
    /// <param name="gender">The gender filter</param>
    /// <param name="rare">Whether to include only rare items</param>
    /// <param name="searchPattern">The search pattern for item names</param>
    /// <returns>A list of filtered item references</returns>
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
    /// Gets an array of teleporters in a specific region
    /// </summary>
    /// <param name="region">The region</param>
    /// <returns>An array of teleporter references</returns>
    public RefTeleport[] GetTeleporters(Region region)
    {
        return TeleportData.Where(t => t.GenRegionID == region).ToArray();
    }

    /// <summary>
    /// Gets an array of ground teleporters in a specific region
    /// </summary>
    /// <param name="region">The region</param>
    /// <returns>An array of ground teleporter references</returns>
    public RefTeleport[] GetGroundTeleporters(Region region)
    {
        return TeleportData.Where(t => t.GenRegionID == region && t.AssocRefObjId == 0).ToArray();
    }

    /// <summary>
    /// Gets a magic option reference by its ID
    /// </summary>
    /// <param name="id">The magic option ID</param>
    /// <returns>The magic option reference object</returns>
    public RefMagicOpt GetMagicOption(uint id)
    {
        return MagicOptions?.FirstOrDefault(m => m.Id == id);
    }

    /// <summary>
    /// Gets a magic option reference by its group
    /// </summary>
    /// <param name="group">The magic option group</param>
    /// <returns>The magic option reference object</returns>
    public RefMagicOpt GetMagicOption(string group)
    {
        return MagicOptions?.FirstOrDefault(m => m.Group == group);
    }

    /// <summary>
    /// Gets a magic option reference by its group and degree
    /// </summary>
    /// <param name="group">The magic option group</param>
    /// <param name="degree">The magic option degree</param>
    /// <returns>The magic option reference object</returns>
    public RefMagicOpt GetMagicOption(string group, byte degree)
    {
        return MagicOptions?.FirstOrDefault(m => m.Group == group && m.Level == degree);
    }

    /// <summary>
    /// Gets a list of magic option assignments for specific type IDs
    /// </summary>
    /// <param name="typeId3">The third type ID</param>
    /// <param name="typeId4">The fourth type ID</param>
    /// <returns>A list of magic option references</returns>
    public List<RefMagicOpt> GetAssignments(byte typeId3, byte typeId4)
    {
        return MagicOptionAssignments.FirstOrDefault(a => a.TypeId3 == typeId3 && a.TypeId4 == typeId4)
            ?.AvailableMagicOptions.Select(GetMagicOption).ToList();
    }

    /// <summary>
    /// Gets an ability item reference by item ID and optimization level
    /// </summary>
    /// <param name="itemId">The item ID</param>
    /// <param name="optLevel">The optimization level</param>
    /// <returns>The ability item reference object</returns>
    public RefAbilityByItemOptLevel GetAbilityItem(uint itemId, byte optLevel)
    {
        return AbilityItemByOptLevel.Values.FirstOrDefault(p => p.ItemId == itemId && p.OptLevel == optLevel);
    }

    /// <summary>
    /// Gets a list of extra ability items for a specific item and optimization level
    /// </summary>
    /// <param name="itemId">The item ID</param>
    /// <param name="optLevel">The optimization level</param>
    /// <returns>An enumerable of extra ability item references</returns>
    public IEnumerable<RefExtraAbilityByEquipItemOptLevel> GetExtraAbilityItems(uint itemId, byte optLevel)
    {
        return ExtraAbilityByEquipItemOptLevel.Where(p => p.ItemId == itemId && p.OptLevel == optLevel);
    }

    /// <summary>
    /// Gets a list of quest reward items for a specific quest
    /// </summary>
    /// <param name="questId">The quest ID</param>
    /// <returns>An enumerable of quest reward item references</returns>
    public IEnumerable<RefQuestRewardItem> GetQuestRewardItems(uint questId)
    {
        return QuestRewardItems.Where(r => r.QuestId == questId);
    }

    /// <summary>
    /// Gets a quest reward reference by its quest ID
    /// </summary>
    /// <param name="questId">The quest ID</param>
    /// <returns>The quest reward reference object</returns>
    public RefQuestReward GetQuestReward(uint questId)
    {
        QuestRewards.TryGetValue(questId, out var result);

        return result;
    }

    /// <summary>
    /// Gets debug information about loaded reference data
    /// </summary>
    /// <returns>A string containing debug information</returns>
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