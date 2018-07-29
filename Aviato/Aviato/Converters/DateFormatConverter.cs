using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Aviato.Converters
{
    public class DateFormatConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            DateTime dt = DateTime.Parse(value.ToString());
            return dt.ToString("MM/dd/yyyy H:mm:ss tt");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            var dt = value.ToString();
            DateTime date = DateTime.ParseExact(dt, "MM/dd/yyyy H:mm:ss tt", CultureInfo.InvariantCulture);

            return date;
        }

    }
}
