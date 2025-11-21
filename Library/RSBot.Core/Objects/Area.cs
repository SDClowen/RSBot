using System;
using System.Runtime.CompilerServices;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects;

public struct Area
{
    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The center name.
    /// </value>
    public string Name;

    /// <summary>
    ///     Gets or sets the center position.
    /// </summary>
    /// <value>
    ///     The center position.
    /// </value>
    public Position Position;

    /// <summary>
    ///     Gets or sets the radius.
    /// </summary>
    /// <value>
    ///     The radius.
    /// </value>
    public int Radius;

    /// <summary>
    ///     The random
    /// </summary>
    private static readonly Random _random = new(Environment.TickCount);

    /// <summary>
    ///     Initialize the instance
    /// </summary>
    /// <param name="name">The area name</param>
    /// <param name="pos">The circle pos</param>
    /// <param name="radius">the circle radius</param>
    public Area(string name, Position pos, int radius)
    {
        Name = name;
        Position = pos;
        Radius = radius;
    }

    /// <summary>
    ///     Return training area from split
    /// </summary>
    public static bool TryParse(string[] split, out Area area)
    {
        area = new Area { Name = split[0] };

        if (!Region.TryParse(split[1], out var regionId))
            return false;

        if (!float.TryParse(split[2], out var xOffset))
            return false;

        if (!float.TryParse(split[3], out var yOffset))
            return false;

        if (!float.TryParse(split[4], out var zOffset))
            return false;

        if (!int.TryParse(split[5], out var radius))
            return false;

        area.Position = new Position(regionId, xOffset, yOffset, zOffset);
        area.Radius = Math.Clamp(radius, 5, 100);

        return true;
    }

    /// <summary>
    ///     Is destination position in sight
    /// </summary>
    /// <param name="position">The position.</param>
    /// <returns>If is in sight: <seealso cref="true" /> otherwise <seealso cref="false" /></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsInSight(SpawnedEntity entity)
    {
        return Position.DistanceTo(entity.Movement.Source) <= Radius;
    }

    /// <summary>
    ///     Get random position on this area
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Position GetRandomPosition()
    {
        var angle = _random.Next(360);
        var radians = angle * (MathF.PI / 180f);

        var newPosX = Position.X + Radius / 1.5f * MathF.Cos(radians);
        var newPosY = Position.Y + Radius / 1.5f * MathF.Sin(radians);

        return new Position(newPosX, newPosY, Position.Region);
    }

    public string GetScriptLine()
    {
        return $"area {Position.Region} {Position.XOffset} {Position.YOffset} {Position.ZOffset} {Radius}";
    }
}
