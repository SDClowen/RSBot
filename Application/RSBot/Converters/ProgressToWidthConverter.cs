using Avalonia.Data.Converters;
using System.Globalization;

namespace RSBot.Converters;

/// <summary>
/// View model for the splash screen that handles initialization and loading
/// </summary>
public class ProgressToWidthConverter : IValueConverter
{
    public static readonly ProgressToWidthConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int progress)
        {
            var width = 250.0 * (progress / 100.0);
            return Math.Max(0, Math.Min(250, width));
        }
        return 0.0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
