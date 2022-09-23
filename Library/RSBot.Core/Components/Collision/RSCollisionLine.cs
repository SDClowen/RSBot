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
    public ushort RegionId;

    public RSCollisionLine(RSCollisionPoint source, RSCollisionPoint destination, ushort regionId)
    {
        Source = source;
        Destination = destination;
        RegionId = regionId;
    }
}