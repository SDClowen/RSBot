using RSBot.Core.Components.Collision;
using RSBot.Core.Components.Collision.Calculated;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace RSBot.Core.Components;

public static class CollisionManager
{
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
    public static bool Enabled { get; set; }

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
    public static void Initialize(string fileName)
    {
        LoadCollisions(fileName);

        IsInitialized = true;
    }

    /// <summary>
    /// Loads the collisions from the specified file path.
    /// </summary>
    /// <param name="path">The path.</param>
    public static void LoadCollisions(string path)
    {
        var sw = Stopwatch.StartNew();

        _loadedCollisions = new Dictionary<ushort, RSCollisionMesh>(1024);

        var fileStream = new BinaryReader(File.OpenRead(path));

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
        if (centerRegionId == CenterRegionId || !IsInitialized || !Enabled)
            return;

        IsUpdating = true;
        CenterRegionId = centerRegionId;

        ActiveCollisionMeshes = new List<CalculatedCollisionMesh>(9);

        var centerRegion = new Region(centerRegionId);
        var surroundedBy = Region.GetSurroundingRegions(centerRegion.XSector, centerRegion.YSector);

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
    internal static RSCollisionMesh? GetCollisionMesh(ushort regionId)
    {
        return _loadedCollisions.FirstOrDefault(r => r.Key == regionId).Value;
    }

    /// <summary>
    /// Determines whether [has collision between] [the specified source].
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <returns>
    ///   <c>true</c> if [has collision between] [the specified source]; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasCollisionBetween(Position? source, Position? destination)
    {
        if (!HasActiveMeshes)
            return false;

        if (source == null || destination == null)
            return false;

        return CollisionCalculator.GetCalculatedCollisionBetween(source, destination, ActiveCollisionMeshes) != null;
    }

    /// <summary>
    /// Gets the collision between the source and destination.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <returns>null if no collision was found</returns>
    public static CollisionResult? GetCollisionBetween(Position? source, Position? destination)
    {
        if (!HasActiveMeshes)
            return null;

        if (source == null || destination == null)
            return null;

        return CollisionCalculator.GetCalculatedCollisionBetween(source, destination, ActiveCollisionMeshes);
    }
}