using System;

namespace RSBot.Core.Extensions;

public static class RandomExtensions
{
    /// <summary>
    ///     Returns a random floating-point number that is greater than or equal to <paramref name="min" />, and less than
    ///     <paramref name="max" />.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float NextFloat(this Random random, float min, float max)
    {
        return (max - min) * (float)random.NextDouble() + min;
    }

    /// <summary>
    ///     Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    public static float NextFloat(this Random random)
    {
        return (float)random.NextDouble();
    }
}
