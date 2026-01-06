using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace QuanLyKhoThuoc.Converters
{
    // ConverterParameter format: "TrueString;FalseString"
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parts = (parameter as string)?.Split(';');
            if (value is bool b && parts != null && parts.Length >= 2)
                return b ? parts[0] : parts[1];
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}