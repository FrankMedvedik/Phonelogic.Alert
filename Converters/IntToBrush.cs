using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Phonelogic.Alert.Converters
{                
    public class IntToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? input = value as int?;
            if(input == null)
                return DependencyProperty.UnsetValue;

            switch (input)
            {
                case 0:
                    return new SolidColorBrush(Colors.Black);

                default:
                    return new SolidColorBrush(Colors.Red);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
