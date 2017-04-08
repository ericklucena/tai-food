using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace TAIFood.Services
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                bool boolValue = (bool) value;

                if (boolValue)
                    return new SolidColorBrush(Colors.Green);
                else 
                    return new SolidColorBrush(Colors.Gray);
            }
            return (SolidColorBrush) Application.Current.Resources["PhoneAccentColor"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return new NotImplementedException();
        }
    }
}
