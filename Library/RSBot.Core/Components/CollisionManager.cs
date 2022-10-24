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
    private const int SupportedVersion = 1100;

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
    public static ushort CenterRegionId { get; private set; }

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
    public static bool Enabled => GlobalConfig.Get("RSBot.EnableCollisionDetection", true);

    /// <summary>
    /// Gets the active collision meshes.
    /// </summary>
    /// <value>
    /// The active collision meshes.
    /// </value>
    public static List<CalculatedCollisionMesh>? ActiveCollisionMeshes { get; private set; }

    private static Dictionary<ushort, RSCollisionMesh> _loadedCollisions;

    /// <summary>
    /// Initializes the specified map data directory.
    /// </summary>
    /// <param name="fileName">Path to the RS map.</param>
    public static void Initialize()
    {
        LoadCollisions();

        IsInitialized = true;
    }

    /// <summary>
    /// Loads the collisions from the specified file path.
    /// </summary>
    /// <param name="path">The path.</param>
    public static void LoadCollisions()
    {
        var sw = Stopwatch.StartNew();

        _loadedCollisions = new Dictionary<ushort, RSCollisionMesh>(1024);

        using var fileStream = new BinaryReader(File.OpenRead(Path.Combine(Environment.CurrentDirectory, "Data", "Game", "map.rsc")));

        var header = fileStream.ReadString();
        var version = fileStream.ReadInt32();

        if (header != SupportedHeader || version != SupportedVersion)
        {
            Log.Error("[Collision] Outdated or invalid collision file!");

            return;
        }

        while (fileStream.ReadBoolean())
        {
            var collisionMesh = new RSCollisionMesh(fileStream);

            _loadedCollisions.Add(collisionMesh.RegionId, collisionMesh);
        }

        Log.Notify($"[Collision] Loaded {_loadedCollisions.Count} collision regions in {sw.ElapsedMilliseconds}ms");

        EventManager.FireEvent("OnLoadCollisions");
    }

    /// <summary>
    /// Updates the collision that are currently stored as active.
    /// If the center region equals the new one, no action will be executed.
    /// </summary>
    /// <param name="centerRegionId">The center region identifier.</param>
    public static void Update(ushort centerRegionId)
    {
        if (GlobalConfig.Get("RSBot.EnableCollisionDetection", true))
            return;

        if (centerRegionId == CenterRegionId && HasActiveMeshes)
            return;

        CenterRegionId = centerRegionId;

        if (!Enabled)
        {
            ActiveCollisionMeshes = null;

            return;
        }

        IsUpdating = true;
        ActiveCollisionMeshes = new List<CalculatedCollisionMesh>(9);

        var centerRegion = new Region(centerRegionId);
        var surroundedBy = centerRegion.GetSurroundingRegions();

        foreach (var region in surroundedBy.Where(region => _loadedCollisions.ContainsKey(region.Id)))
        {
            var mesh = _loadedCollisions[region.Id];
            var calculatedMesh = new CalculatedCollisionMesh(mesh);

            ActiveCollisionMeshes.Add(calculatedMesh);
        }

        IsUpdating = false;

        Log.Debug($"[Collision] Loaded {ActiveCollisionMeshes.Count} regions!");
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