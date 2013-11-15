using Przewodnik.Models;
using Przewodnik.Utilities.DataLoader;
using System.Text;
using System.Text.RegularExpressions;

namespace Przewodnik.ViewModels
{
    public class WeatherViewModel
    {
        public WeatherModel wm;

        public WeatherViewModel()
        {
            WeatherLoader wl = WeatherLoader.Instance;
            wm = new WeatherModel();
            wm.WeatherImage = GetWheatherImage(wl.html);
            wm.Temperature = GetTemperature(wl.html);
            wm.Description = GetDescription(wl.html);
            wm.NameDay = GetNameDayNames(wl.htmlNameDay);
        }

        public static string GetWheatherImage(string file)
        {
            string pattern = "<span class=\"weatherIco size72x72 (.*?)\"></span>";
            Match m = Regex.Match(file, @pattern);
            string weatherImage = "";

            if (m.Success)
            {
                weatherImage = m.Groups[1].ToString();
            }
            return "../Content/Weather/" + weatherImage + ".png";
        }

        public static string GetTemperature(string file)
        {
            string pattern = "<span class=\"city_temperature city_49413_temperature\">(.*?)</span>";
            Match m = Regex.Match(file, @pattern);
            string temperature = "";

            if (m.Success)
            {
                temperature = m.Groups[1].ToString();
            }
            return temperature + " °C";
        }

        public static string GetDescription(string file)
        {
            string pattern = "<span class=\"strong\"><strong>(.*?)</strong></span>";
            Match m = Regex.Match(file, @pattern);
            string description = "";

            if (m.Success)
            {
                description = m.Groups[1].ToString();
            }

            byte[] bytes = Encoding.Default.GetBytes(description);
            description = Encoding.UTF8.GetString(bytes);

            return description;
        }

        public static string GetNameDayNames(string file)
        {
            string pattern = "<div id=\"nameDay\" class=\"small\">(.*?)</div>";
            Match m = Regex.Match(file, @pattern);
            string nameDayNames = "";

            if (m.Success)
            {
                nameDayNames = m.Groups[1].ToString();
            }

            byte[] bytes = Encoding.Default.GetBytes(nameDayNames);
            nameDayNames = Encoding.UTF8.GetString(bytes);

            return nameDayNames;
        }

    }
}
