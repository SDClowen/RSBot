using System.Diagnostics;
using NavMeshApi;
using RSBot.Core.Event;
using RSBot.Core.Objects;

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
        //ToDo: New collision calculation between source and destination
        return false;
    }
}