using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace Windows
{
    public class ExpiredDateToBrushConverter : IValueConverter
    {
        public static readonly ExpiredDateToBrushConverter Instance = new();

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                if (date.Date < DateTime.Today)
                    return new SolidColorBrush(Color.Parse("#FFB3B3"));
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}

