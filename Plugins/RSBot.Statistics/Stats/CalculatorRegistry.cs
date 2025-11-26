using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core;

namespace RSBot.Statistics.Stats;

internal static class CalculatorRegistry
{
    /// <summary>
    ///     Gets the statistics.
    /// </summary>
    /// <value>
    ///     The statistics.
    /// </value>
    public static List<IStatisticCalculator> Calculators { get; private set; }

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        Calculators = new List<IStatisticCalculator>(20);
        LoadCalculators();
    }

    /// <summary>
    ///     Loads the calculators.
    /// </summary>
    private static void LoadCalculators()
    {
        var type = typeof(IStatisticCalculator);
        var types = AppDomain
            .CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
            .ToArray();

        foreach (var handler in types)
        {
            var instance = (IStatisticCalculator)Activator.CreateInstance(handler);
            instance.Initialize();
            Calculators.Add(instance);
        }

        Log.Debug($"Found {Calculators.Count} statistic calulators.");
    }
}
