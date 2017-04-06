using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Prototype.Converters
{
    public class StringTimeConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            TimeSpan toBeReturned;
            TimeSpan.TryParse(value.ToString(), out toBeReturned);
            return toBeReturned;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }
    }
}
