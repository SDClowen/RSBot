using RSBot.Core.Network;

namespace RSBot.Core.Objects.Item;

public class RentInfo
{
    /// <summary>
    ///     Gets or sets the type.
    /// </summary>
    /// <value>
    ///     The type.
    /// </value>
    public uint Type { get; set; }

    /// <summary>
    ///     Gets or sets the can delete.
    /// </summary>
    /// <value>
    ///     The can delete.
    /// </value>
    public ushort CanDelete { get; set; }

    /// <summary>
    ///     Gets or sets the period begin time.
    /// </summary>
    /// <value>
    ///     The period begin time.
    /// </value>
    public ulong PeriodBeginTime { get; set; }

    /// <summary>
    ///     Gets or sets the period end time.
    /// </summary>
    /// <value>
    ///     The period end time.
    /// </value>
    public ulong PeriodEndTime { get; set; }

    /// <summary>
    ///     Gets or sets the can recharge.
    /// </summary>
    /// <value>
    ///     The can recharge.
    /// </value>
    public ushort CanRecharge { get; set; }

    /// <summary>
    ///     Gets or sets the meter rate time.
    /// </summary>
    /// <value>
    ///     The meter rate time.
    /// </value>
    public ulong MeterRateTime { get; set; }

    /// <summary>
    ///     Gets or sets the packing time.
    /// </summary>
    /// <value>
    ///     The packing time.
    /// </value>
    public ulong PackingTime { get; set; }

    /// <summary>
    ///     Creates a new RentInfo object from the given packet
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    internal static RentInfo FromPacket(Packet packet)
    {
        var result = new RentInfo { Type = packet.ReadUInt() };

        switch (result.Type)
        {
            case 1:
                result.CanDelete = packet.ReadUShort();

                if (Game.ClientType >= GameClientType.Chinese_Old && Game.ClientType != GameClientType.Rigid)
                {
                    result.PeriodBeginTime = packet.ReadULong();
                    result.PeriodEndTime = packet.ReadULong();
                }
                else
                {
                    result.PeriodBeginTime = packet.ReadUInt();
                    result.PeriodEndTime = packet.ReadUInt();
                }

                break;

            case 2:
                result.CanDelete = packet.ReadUShort();
                result.CanRecharge = packet.ReadUShort();

                /*if (Game.ClientType >= GameClientType.Chinese_Old)
                    result.MeterRateTime = packet.ReadULong();
                else*/
                result.MeterRateTime = packet.ReadUInt();

                break;

            case 3:
                result.CanDelete = packet.ReadUShort();
                result.CanRecharge = packet.ReadUShort();

                if (Game.ClientType >= GameClientType.Chinese_Old && Game.ClientType != GameClientType.Rigid)
                {
                    result.PeriodBeginTime = packet.ReadULong();
                    result.PeriodEndTime = packet.ReadULong();
                    result.PackingTime = packet.ReadULong();
                }
                else
                {
                    result.PeriodBeginTime = packet.ReadUInt();
                    result.PeriodEndTime = packet.ReadUInt();
                    result.PackingTime = packet.ReadUInt();
                }

                break;
        }

        return result;
    }
}
