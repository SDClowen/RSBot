namespace RSBot.Training.Bundle.Loop;

public class LoopConfig
{
    /// <summary>
    ///     Gets or sets the walk script.
    /// </summary>
    /// <value>
    ///     The walk script.
    /// </value>
    public string WalkScript { get; set; }

    /// <summary>
    ///     Gets a value indicating whether [use mount].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [use mount]; otherwise, <c>false</c>.
    /// </value>
    public bool UseVehicle { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [use speed drug].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [use speed drug]; otherwise, <c>false</c>.
    /// </value>
    public bool UseSpeedDrug { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [use speed drug].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [use speed drug]; otherwise, <c>false</c>.
    /// </value>
    public bool UseReverse { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [cast buffs].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [cast buffs]; otherwise, <c>false</c>.
    /// </value>
    public bool CastBuffs { get; set; }
}
