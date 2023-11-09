using System.Numerics;
using RSBot.Core.Objects;
using RSBot.NavMeshApi;

namespace RSBot.Core.Components;

public static class CollisionManager
{


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
        if (!Enabled) 
            return false;
        
        if (source.DistanceTo(destination) > 150)
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
}