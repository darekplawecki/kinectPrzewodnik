using Przewodnik.Models;
using Przewodnik.Utilities;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Przewodnik.ViewModels
{
    public class WeatherViewModel
    {
        public WeatherModel wm;
        
        public WeatherViewModel()
        {

            CookieAwareWebClient client = new CookieAwareWebClient();
            string link = "http://tvnmeteo.tvn24.pl/pogoda/wroclaw,49413/na-dzis-na-jutro,1.html";
            var result = client.DownloadData(link);
            var html = System.Text.Encoding.Default.GetString(result);

            wm = new WeatherModel(GetWheatherImage(html), GetTemperature(html), GetDescription(html));
        
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
            return "../Content/Weather/"+ weatherImage + ".png";
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

    }
}
