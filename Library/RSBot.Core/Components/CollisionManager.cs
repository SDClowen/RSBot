using System.Diagnostics;
using System.Linq;
using System.Numerics;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.NavMeshApi;

namespace RSBot.Core.Components;

public static class CollisionManager
{

    /// <summary>
    ///     Gets a value indicating whether this instance is updating.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is updating; otherwise, <c>false</c>.
    /// </value>
    public static bool IsUpdating { get; private set; }

    /// <summary>
    ///     Gets the center region identifier.
    /// </summary>
    /// <value>
    ///     The center region identifier.
    /// </value>
    public static Region CenterRegion { get; private set; }


    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="CollisionManager" /> is enabled.
    /// </summary>
    /// <value>
    ///     <c>true</c> if enabled; otherwise, <c>false</c>.
    /// </value>
    public static bool Enabled
    {
        get => GlobalConfig.Get("RSBot.EnableCollisionDetection", true);
        set => GlobalConfig.Set("RSBot.EnableCollisionDetection", value);
    }

    private static NavMesh[] _loadedNavMeshes = new NavMesh[9];

    /// <summary>
    ///     Updates the collision that are currently stored as active.
    ///     If the center region equals the new one, no action will be executed.
    /// </summary>
    /// <param name="centerRegionId">The center region identifier.</param>
    public static void Update(Region region)
    {
        if (!Enabled)
            return;

        if (region == CenterRegion)
            return;

        IsUpdating = true;
        
        CenterRegion = region;

        var surrounding = CenterRegion.GetSurroundingRegions();
        for (var iRegion = 0; iRegion < 9; iRegion++)
        {
            var navSw = Stopwatch.StartNew();
            var actualRegion = surrounding[iRegion];

            if (!NavMeshManager.TryGetNavMesh(actualRegion.Id, out _loadedNavMeshes[iRegion]))
            {
                Log.Warn($"Could not load NavMesh for region 0x{actualRegion.Id:x4}");
                return;
            }

            navSw.Stop();
            Log.Debug($"Loaded navmesh in {navSw.ElapsedMilliseconds}ms (Ticks: {navSw.ElapsedTicks})");
        }

        IsUpdating = false;

        EventManager.FireEvent("OnUpdateCollisions");
    }

    /// <summary>
    ///     Determines whether [has collision between] [the specified source].
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="destination">The destination.</param>
    /// <returns>
    ///     <c>true</c> if [has collision between] [the specified source]; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasCollisionBetween(Position source, Position destination)
    {
        if (source.DistanceTo(destination) > 150)
            return false;

        var navMeshSrc = _loadedNavMeshes.FirstOrDefault(nm => nm != null && nm.Region == source.Region.Id);
        if (navMeshSrc == null)
            return false;

        var navMeshDest = _loadedNavMeshes.FirstOrDefault(nm => nm != null &&  nm.Region == destination.Region.Id);
        if (navMeshDest == null)
            return false;

        var srcOffset = new Vector3(source.XOffset, source.ZOffset, source.YOffset);
        var destOffset = new Vector3(destination.XOffset, destination.ZOffset, destination.YOffset);

        var navMeshTransformerSrc = new NavMeshTransform(source.Region.Id, srcOffset);
        if (!NavMeshManager.ResolveCellAndHeight(navMeshTransformerSrc))
            return false;

        var navMeshTransformerDest = new NavMeshTransform(destination.Region.Id, destOffset);
        if (!NavMeshManager.ResolveCellAndHeight(navMeshTransformerDest))
            return false;

        var hasCollision = !NavMeshManager.Raycast(navMeshTransformerSrc, navMeshTransformerDest, NavMeshRaycastType.Attack);

        return hasCollision;
    }

    public static NavMesh[] GetActiveMeshes() => _loadedNavMeshes;
}