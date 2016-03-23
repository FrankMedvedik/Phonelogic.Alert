using System;
using System.Windows;
using System.Windows.Data;
using Microsoft.Lync.Controls;

namespace Phonelogic.Alert.Converters
{                
    public class LyncAvailablityToBoolean  : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? input = value as int?;

            if (input == null)
                return DependencyProperty.UnsetValue;
           
            switch (input)
            {
                case (int)ContactAvailability.Free:
                    return true;

                default:
                    return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
