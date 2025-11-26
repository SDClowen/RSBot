using RSBot.Statistics.Stats.Calculators;

namespace RSBot.Statistics.Stats;

internal interface IStatisticCalculator
{
    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    string Name { get; }

    /// <summary>
    ///     Gets the label.
    /// </summary>
    /// <value>
    ///     The label.
    /// </value>
    string Label { get; }

    /// <summary>
    ///     Gets the group.
    /// </summary>
    /// <value>
    ///     The group.
    /// </value>
    StatisticsGroup Group { get; }

    /// <summary>
    ///     Gets the value format.
    /// </summary>
    /// <value>
    ///     The value format.
    /// </value>
    string ValueFormat { get; }

    /// <summary>
    ///     Gets the type of the update.
    /// </summary>
    /// <value>
    ///     The type of the update.
    /// </value>
    UpdateType UpdateType { get; }

    /// <summary>
    ///     Collects the value of the calculator.
    /// </summary>
    /// <returns></returns>
    object GetValue();

    /// <summary>
    ///     Resets this calculator.
    /// </summary>
    void Reset();

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    void Initialize();
}
