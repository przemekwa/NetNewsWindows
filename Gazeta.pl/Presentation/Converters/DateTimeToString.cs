using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Gazeta.pl.Presentation.Converters
{
    class DateTimeToString : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null)
                return value;
            DateTime? date = value as DateTime?;

            if (date == null)
            {
                return value;
            }
            else
            {
                return DateTime.Parse(date.ToString()).ToString ("dd-MM-yyyy HH:mm:ss");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
