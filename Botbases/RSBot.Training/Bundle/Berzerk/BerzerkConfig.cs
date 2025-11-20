namespace RSBot.Training.Bundle.Berzerk;

internal class BerzerkConfig
{
    /// <summary>
    ///     Gets or sets a value indicating whether [when full].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [when full]; otherwise, <c>false</c>.
    /// </value>
    public bool WhenFull { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [surrounded by monsters].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [surrounded by monsters]; otherwise, <c>false</c>.
    /// </value>
    public bool SurroundedByMonsters { get; set; }

    /// <summary>
    ///     Gets or sets the surrounding monster amount.
    /// </summary>
    /// <value>
    ///     The surrounding monster amount.
    /// </value>
    public byte SurroundingMonsterAmount { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [beeing attacked by aware monster].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [beeing attacked by aware monster]; otherwise, <c>false</c>.
    /// </value>
    public bool BeeingAttackedByAwareMonster { get; set; }

    public bool WhenTargetSpecificRartiyMonster { get; set; }
}
