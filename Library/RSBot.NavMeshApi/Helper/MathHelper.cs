using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RSBot.NavMeshApi.Helper;

internal static class MathHelper
{
    public const float Epsilon = 1e-6f; // 0.000001
    public const float Rad2Deg = 180.0f / MathF.PI;
    public const float Deg2Rad = MathF.PI / 180.0f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximately(this float a, float b, float threshold = Epsilon) =>
        MathF.Abs(a - b) < threshold;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximatelyZero(this float value, float threshold = Epsilon) => MathF.Abs(value) < threshold;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Clamp(this float value, float min, float max)
    {
        //Debug.Assert(max > min, $"min({min:0.000}) exceeded max({max:0.000}) value");
        return value < min ? min
            : value > max ? max
            : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Clamp(this int value, int min, int max)
    {
        Debug.Assert(max > min, $"min({min}) exceeded max({max}) value");
        return value < min ? min
            : value > max ? max
            : value;
    }

    public static int FloorToInt(float x) => (int)MathF.Floor(x);
}
