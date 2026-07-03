using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_DotNet_Test.Converters
{
    public class PriceChangeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var change = value switch
            {
                double d => d,
                decimal m => (double)m,
                _ => 0d
            };

            var key = change >= 0 ? "PositiveBrush" : "NegativeBrush";
            return Application.Current.Resources[key] as Brush ?? Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
