using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Przewodnik.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder result = new StringBuilder("");
            if (value == null) return null;
            else
            {
                DateTime when = (DateTime)value;
                if (when.Date.Equals(DateTime.Now.Date)) result.Append("Dzisiaj, ");
                else result.Append(when.ToString("DD MMMM YYYY, "));

                TimeSpan ts = DateTime.Now.Subtract(when);
                if (ts.TotalHours < 1)
                    result.AppendFormat("{0} minut temu", (int)ts.TotalMinutes);
                else if (ts.TotalDays < 1) result.AppendFormat("{0} godzin temu", (int)ts.TotalHours);

                return result;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }


}
