using RSBot.Core.Components.Collision;
using RSBot.Core.Components.Collision.Calculated;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace RSBot.Core.Components;

public static class CollisionManager
{
    private const string SupportedHeader = "RSNVM";
    private const int SupportedVersion = 1200;

    /// <summary>
    /// Gets a value indicating whether this instance is initialized.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
    /// </value>
    public static bool IsInitialized { get; private set; }

    /// <summary>
    /// Gets a value indicating whether this instance is updating.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is updating; otherwise, <c>false</c>.
    /// </value>
    public static bool IsUpdating { get; private set; }

    /// <summary>
    /// Gets the center region identifier.
    /// </summary>
    /// <value>
    /// The center region identifier.
    /// </value>
    public static Region CenterRegion { get; private set; }

    /// <summary>
    /// Gets a value indicating whether this instance has active collision meshes.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance has active meshes; otherwise, <c>false</c>.
    /// </value>
    public static bool HasActiveMeshes
    {
        get
        {
            if (!IsInitialized || !Enabled)
                return false;

            if (ActiveCollisionMeshes == null)
                return false;

            if (IsUpdating)
                return false;

            return ActiveCollisionMeshes.Count > 0;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="CollisionManager"/> is enabled.
    /// </summary>
    /// <value>
    ///   <c>true</c> if enabled; otherwise, <c>false</c>.
    /// </value>
    public static bool Enabled
    {
        get => GlobalConfig.Get("RSBot.EnableCollisionDetection", true);
        set => GlobalConfig.Set("RSBot.EnableCollisionDetection", value);
    }

    /// <summary>
    /// Gets the active collision meshes.
    /// </summary>
    /// <value>
    /// The active collision meshes.
    /// </value>
    public static List<CalculatedCollisionMesh> ActiveCollisionMeshes { get; private set; }

    private static Dictionary<Region, long> _lookupTable;

    private static Dictionary<Region, RSCollisionMesh> _loadedCollisions;

    /// <summary>
    /// Initializes the specified map data directory.
    /// </summary>
    public static void Initialize()
    {
        LoadLookupTable();

        IsInitialized = true;
    }

    /// <summary>
    /// Loads the collisions from the specified file path.
    /// </summary>
    /// <param name="path">The path.</param>
    public static void LoadLookupTable()
    {
        var sw = Stopwatch.StartNew();

        using var fileStream = new BinaryReader(File.OpenRead(Path.Combine(Kernel.BasePath, "Data", "Game", "map.rsc")));

        var header = fileStream.ReadString();
        var version = fileStream.ReadInt32();

        if (header != SupportedHeader || version != SupportedVersion)
        {
            Log.Error("[Collision] Outdated or invalid collision file!");

            return;
        }

        var lookupTableOffset = fileStream.ReadInt64();
        fileStream.BaseStream.Seek(lookupTableOffset, SeekOrigin.Begin);

        var entryCount = fileStream.ReadUInt16();
        _lookupTable = new(entryCount);

        for (var entryIndex = 0; entryIndex < entryCount; entryIndex++)
        {
            var regionId = fileStream.ReadUInt16();
            var fileOffset = fileStream.ReadInt64();

            _lookupTable.Add(regionId, fileOffset);
        }

        Log.Notify($"[Collision] Loaded lookup table for {_lookupTable.Count} collision regions in {sw.ElapsedMilliseconds}ms");

        EventManager.FireEvent("OnLoadCollisionLookupTable");
    }
    
    /// <summary>
    /// Loads the specified regions collision information.
    /// </summary>
    /// <param name="regions"></param>
    private static void LoadRegions(Region[] regions)
    {
        var sw = Stopwatch.StartNew();

        using var fileStream = new BinaryReader(File.OpenRead(Path.Combine(Kernel.BasePath, "Data", "Game", "map.rsc")));
        
        _loadedCollisions = new Dictionary<Region, RSCollisionMesh>(regions.Length);

        foreach (var region in regions)
        {
            if (!_lookupTable.ContainsKey(region)) 
            {
                Log.Debug($"[Collision] Could not find entry in lookup table for region with id [{region}]");

                continue;
            }

            fileStream.BaseStream.Seek(_lookupTable[region], SeekOrigin.Begin);
            
            var collisionMesh = new RSCollisionMesh(fileStream);
            _loadedCollisions.Add(collisionMesh.Region, collisionMesh);
        }

        Log.Debug($"[Collision] Loaded {_loadedCollisions.Count} collision regions in {sw.ElapsedMilliseconds}ms");

        EventManager.FireEvent("OnLoadCollisionRegions");
    }

    /// <summary>
    /// Updates the collision that are currently stored as active.
    /// If the center region equals the new one, no action will be executed.
    /// </summary>
    /// <param name="centerRegionId">The center region identifier.</param>
    public static void Update(Region region)
    {
        if (region.IsDungeon)
            return;

        if (region == CenterRegion && HasActiveMeshes || region == 0)
            return;
        
        CenterRegion = region;

        if (!Enabled)
        {
            ActiveCollisionMeshes = null;

            return;
        }

        if (!IsInitialized)
            Initialize();

        IsUpdating = true;
        ActiveCollisionMeshes = new List<CalculatedCollisionMesh>(9);

        var surroundedBy = CenterRegion.GetSurroundingRegions();

        LoadRegions(surroundedBy); 

        foreach (var surroundingRegion in surroundedBy.Where(region => _loadedCollisions.ContainsKey(region)))
        {
            var mesh = _loadedCollisions[surroundingRegion];
            var calculatedMesh = new CalculatedCollisionMesh(mesh);

            ActiveCollisionMeshes.Add(calculatedMesh);
        }

        IsUpdating = false;

        EventManager.FireEvent("OnUpdateCollisions");
    }

    /// <summary>
    /// Determines whether [has collision between] [the specified source].
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <returns>
    ///   <c>true</c> if [has collision between] [the specified source]; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasCollisionBetween(Position source, Position destination)
    {
        if (!HasActiveMeshes)
            return false;

        return CollisionCalculator.GetCalculatedCollisionBetween(source, destination, ActiveCollisionMeshes) != null;
    }

    /// <summary>
    /// Gets the collision between the source and destination.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <returns>null if no collision was found</returns>
    public static CollisionResult? GetCollisionBetween(Position source, Position destination)
    {
        if (!HasActiveMeshes)
            return null;

        return CollisionCalculator.GetCalculatedCollisionBetween(source, destination, ActiveCollisionMeshes);
    }
}