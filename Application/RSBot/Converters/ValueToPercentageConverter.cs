using Avalonia.Data.Converters;
using System.Globalization;

namespace RSBot.Converters;

public class ValueToPercentageConverter : IMultiValueConverter
{
    public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Count == 2 && values[0] is double value && values[1] is double maxValue && maxValue > 0)
        {
            double percentage = (value / maxValue) * 100;
            return percentage >= 100 ? "99.99%" : $"{percentage:F2}%";
        }

        return "0.00%";
    }
}
