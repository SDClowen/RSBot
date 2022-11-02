using RSBot.Core.Objects;

namespace RSBot.Core.Components.Collision;

internal struct RSCollisionLine
{
    /// <summary>
    /// The source point.
    /// </summary>
    public RSCollisionPoint Source;

    /// <summary>
    /// The destination point.
    /// </summary>
    public RSCollisionPoint Destination;

    /// <summary>
    /// The region identifier of this collision line
    /// </summary>
    public Region Region;

    public RSCollisionLine(RSCollisionPoint source, RSCollisionPoint destination, Region region)
    {
        Source = source;
        Destination = destination;
        Region = region;
    }
}