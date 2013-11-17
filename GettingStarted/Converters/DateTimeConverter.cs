using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Przewodnik.Content.Traslations;

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
                if (when.Date.Equals(DateTime.Now.Date)) result.Append("");
                else result.Append(when.ToString("dd MMMM yyyy, "));

                TimeSpan ts = DateTime.Now.Subtract(when);
                if (ts.TotalHours < 1)
                {
                    if (ts.TotalMinutes < 2) result.AppendFormat("{0} {1}", (int)ts.TotalMinutes, AppResources.GetText("DT_minute_temu"));
                    else
                    {
                        if (ts.TotalMinutes < 22 && ts.TotalMinutes > 4)
                            result.AppendFormat("{0} {1}", (int)ts.TotalMinutes, AppResources.GetText("DT_minut_temu"));
                        else
                        {
                            if(LastPositionIn((int) ts.TotalMinutes) > 1 && LastPositionIn((int) ts.TotalMinutes) < 5 )
                                result.AppendFormat("{0} {1}", (int)ts.TotalMinutes, AppResources.GetText("DT_minuty_temu"));
                            else result.AppendFormat("{0} {1}", (int)ts.TotalMinutes, AppResources.GetText("DT_minut_temu"));
                        }
                    }
                }
                else
                {
                    if (ts.TotalHours < 2) result.AppendFormat("{0} {1}", (int)ts.TotalHours, AppResources.GetText("DT_godzine_temu"));
                    else
                    {
                        if (ts.TotalHours < 22 && ts.TotalHours > 4)
                            result.AppendFormat("{0} {1}", (int)ts.TotalHours, AppResources.GetText("DT_godzin_temu"));
                        else
                        {
                            if (LastPositionIn((int)ts.TotalHours) > 1 && LastPositionIn((int)ts.TotalHours) < 5)
                                result.AppendFormat("{0} {1}", (int)ts.TotalHours, AppResources.GetText("DT_godziny_temu"));
                            else result.AppendFormat("{0} {1}", (int)ts.TotalHours, AppResources.GetText("DT_godzin_temu"));
                        }
                    }
                }

                return result;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        private int LastPositionIn(int number)
        {
            char[] array = number.ToString().ToCharArray();
            return int.Parse(array.Last().ToString());
        }
    }


}
