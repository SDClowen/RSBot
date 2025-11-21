using RSBot.Core.Network;

namespace RSBot.Core.Objects;

public class JobInfo
{
    /// <summary>
    ///     Gets or sets the name of the character.
    /// </summary>
    /// <value>
    ///     The name of the character.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the job level.
    /// </summary>
    /// <value>
    ///     The job level.
    /// </value>
    public byte Level { get; set; }

    /// <summary>
    ///     Gets or sets the type of the job.
    /// </summary>
    /// <value>
    ///     The type of the job.
    /// </value>
    public JobType Type { get; set; }

    /// <summary>
    ///     Gets or sets the job rank.
    /// </summary>
    /// <value>
    ///     The job rank.
    /// </value>
    public byte Rank { get; set; }

    /// <summary>
    ///     Gets or sets the job title.
    /// </summary>
    /// <value>
    ///     The job title.
    /// </value>
    public byte Title { get; set; }

    /// <summary>
    ///     Gets or sets the job experience.
    /// </summary>
    /// <value>
    ///     The job experience.
    /// </value>
    public long Experience { get; set; }

    /// <summary>
    ///     Gets or sets the job contribution.
    /// </summary>
    /// <value>
    ///     The job contribution.
    /// </value>
    public uint Contribution { get; set; }

    /// <summary>
    ///     Gets or sets the job reward.
    /// </summary>
    /// <value>
    ///     The job reward.
    /// </value>
    public uint Reward { get; set; }

    /// <summary>
    ///     Creates a new JobInfo object from the given packet
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    internal static JobInfo FromPacket(Packet packet)
    {
        if (Game.ClientType <= GameClientType.Vietnam)
            return new JobInfo
            {
                Name = packet.ReadString(),
                Type = (JobType)packet.ReadByte(),
                Level = packet.ReadByte(),
                Experience = packet.ReadUInt(),
                Contribution = packet.ReadUInt(),
                Reward = packet.ReadUInt(),
            };

        return new JobInfo
        {
            Name = packet.ReadString(),
            Title = packet.ReadByte(),
            Rank = packet.ReadByte(),
            Type = (JobType)packet.ReadByte(),
            Level = packet.ReadByte(),
            Experience = packet.ReadLong(),
        };
    }
}
