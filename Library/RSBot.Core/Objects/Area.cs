using RSBot.Core.Extensions;
using RSBot.Core.Objects.Spawn;
using System;
using System.Runtime.CompilerServices;

namespace RSBot.Core.Objects;

public class Area
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The center name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the center position.
    /// </summary>
    /// <value>
    /// The center position.
    /// </value>
    public Position Position { get; set; }

    /// <summary>
    /// Gets or sets the radius.
    /// </summary>
    /// <value>
    /// The radius.
    /// </value>
    public int Radius { get; set; }

    /// <summary>
    /// The random
    /// </summary>
    private Random _random = new(Environment.TickCount);

    /// <summary>
    /// Return training area from split
    /// </summary>
    public static Area FromSplit(string[] split)
    {
        if (!float.TryParse(split[1], out var posX))
            return null;

        if (!float.TryParse(split[2], out var posY))
            return null;

        if (!int.TryParse(split[3], out var radius))
            return null;

        return new Area
        {
            Name = split[0],
            Position = new Position(posX, posY),
            Radius = Math.Clamp(radius, 5, 100)
        };
    }

    /// <summary>
    /// Is destination position in sight
    /// </summary>
    /// <param name="position">The position.</param>
    /// <returns>If is in sight: <seealso cref="true"/> otherwise <seealso cref="false"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsInSight(SpawnedEntity entity)
    {
        return Position.DistanceTo(entity.Movement.Source) <= Radius;
    }

    /// <summary>
    /// Get random position on this area
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Position GetRandomPosition()
    {
        var angle = _random.Next(360);

        var newPosX = Position.X + Radius * Math.Cos(angle);
        var newPosY = Position.Y + Radius * Math.Sin(angle);

        return new Position((float) newPosX, (float) newPosY);
    }
}